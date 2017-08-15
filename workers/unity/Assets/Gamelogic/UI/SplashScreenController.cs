using Assets.Gamelogic.Core;
using Assets.Gamelogic.Utils;
using Improbable.Unity.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gamelogic.UI
{
    public class SplashScreenController : MonoBehaviour
    {
        [SerializeField]
        private GameObject NotReadyWarning;
        [SerializeField]
        private Button ConnectButton;
        [SerializeField]
        private GameObject Spinner;


        public void AttemptToConnect()
        {
            // Disable connect button
            ConnectButton.interactable = false;

            // Hide warning if already shown
            NotReadyWarning.SetActive(false);

            // Start loading spinner
            Spinner.SetActive(true);

            AttemptConnection();
        }

        private void AttemptConnection()
        {
            Bootstrap bootstrap = FindObjectOfType<Bootstrap>();
            if (!bootstrap)
            {
                throw new Exception("Couldn't find Bootstrap script on GameEntry in UnityScene");
            }
            bootstrap.ConnectToClient();

            // In case the client connection is successful this coroutine is destroyed as part of unloading
            // the splash screen so ConnectionTimeout won't be called
            StartCoroutine(TimerUtils.WaitAndPerform(SimulationSettings.ClientConnectionTimeoutSecs, ConnectionTimeout));
        }

        private void ConnectionTimeout()
        {
            if (SpatialOS.IsConnected)
            {
                SpatialOS.Disconnect();
            }

            Spinner.SetActive(false);
            NotReadyWarning.SetActive(true);
            ConnectButton.interactable = true;
        }
    }
}

