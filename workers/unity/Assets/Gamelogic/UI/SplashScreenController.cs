using System;
using Assets.Gamelogic.Utils;
using Improbable.Unity.Core;
using UnityEngine;
using UnityEngine.UI;
using Assets.Gamelogic.Global;

namespace Assets.Gamelogic.UI
{
    public class SplashScreenController : MonoBehaviour
    {
        [SerializeField]
        private GameObject NotReadyWarning;
        [SerializeField]
        private Button ConnectButton;

        private static SplashScreenController instance;
        private const string GameEntryGameObject = "GameEntry";

        private void Awake()
        {
            instance = this;
        }

        public void AttemptToConnect()
        {
            DisableConnectButton();
            instance.AttemptConnection();
        }

        private void DisableConnectButton()
        {
            ConnectButton.interactable = false;
            ConnectButton.GetComponent<CursorHoverEffect>().ShowDefaultCursor();
        }

        private void AttemptConnection()
        {
            if (!GameObject.Find(GameEntryGameObject).GetComponent<Bootstrap>())
            {
                throw new Exception("Couldn't find Bootstrap script on GameEntry in ClientScene");
            }
            Bootstrap bootstrap = GameObject.Find(GameEntryGameObject).GetComponent<Bootstrap>();
            bootstrap.AttemptToConnectClient();
            StartCoroutine(TimerUtils.WaitAndPerform(SimulationSettings.ClientConnectionTimeoutSecs, ConnectionTimeout));
        }

        private void ConnectionTimeout()
        {
            if (SpatialOS.IsConnected)
            {
                SpatialOS.Disconnect();
            }
            instance.NotReadyWarning.SetActive(true);
            ConnectButton.interactable = true;
        }

        public static void HideSplashScreen()
        {
            if (instance != null)
            {
                instance.NotReadyWarning.SetActive(false);
                instance.gameObject.SetActive(false);
            }
        }
    }
}

