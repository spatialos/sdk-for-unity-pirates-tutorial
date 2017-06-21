using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on client workers only
    [WorkerType(WorkerPlatform.UnityClient)]
    public class ScoreGUI : MonoBehaviour
    {
        /* 
         * Client will only have write-access for their own designated PlayerShip entity's ClientAuthorityCheck component,
         * so this MonoBehaviour will be enabled on the client's designated PlayerShip GameObject only and not on
         * the GameObject of other players' ships.
         */
        [Require]
        private ClientAuthorityCheck.Writer ClientAuthorityCheckWriter;

        private GameObject scoreCanvasUI;
        private Text totalPointsGUI;

        private void Awake()
        {
            scoreCanvasUI = GameObject.Find("ScoreCanvas");
            if (scoreCanvasUI)
            {
                totalPointsGUI = scoreCanvasUI.GetComponentInChildren<Text>();
                scoreCanvasUI.SetActive(false);
                updateGUI(0);
            }
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        void updateGUI(int score)
        {
            if (scoreCanvasUI)
            {
                if (score > 0)
                {
                    scoreCanvasUI.SetActive(true);
                    totalPointsGUI.text = score.ToString();
                }
                else
                {
                    scoreCanvasUI.SetActive(false);
                }
            }
        }
    }
}