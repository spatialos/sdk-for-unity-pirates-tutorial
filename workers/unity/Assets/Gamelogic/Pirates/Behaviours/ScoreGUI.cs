using Improbable.Ship;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Enable this MonoBehaviour on client workers only
    [EngineType(EnginePlatform.Client)]
    public class ScoreGUI : MonoBehaviour
    {
        /* 
         * Client will only have write-access for their own designated PlayerShip entity's ShipControls component,
         * so this MonoBehaviour will be enabled on the client's designated PlayerShip GameObject only and not on
         * the GameObject of other players' ships.
         */
        [Require] private ShipControls.Writer ShipControlsWriter;

        private Text totalPointsGUI;

        private void Awake()
        {
            totalPointsGUI = GameObject.Find("Canvas").GetComponentInChildren<Text>();
            GameObject.Find("Background").GetComponent<Image>().color = Color.clear;
            updateGUI(0);
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        void updateGUI(int score)
        {
            if (score > 0)
            {
                GameObject.Find("Background").GetComponent<Image>().color = Color.white;
                var text = "Score: " + score.ToString() + " ";
                totalPointsGUI.text = text;
            }
            else
            {
                GameObject.Find("Background").GetComponent<Image>().color = Color.clear;
            }
        }
    }
}