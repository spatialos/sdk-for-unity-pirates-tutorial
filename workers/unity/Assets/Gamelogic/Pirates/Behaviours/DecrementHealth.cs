using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;


namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Enable this MonoBehaviour on FSim (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class DecrementHealth : MonoBehaviour
    {
        void OnEnable()
        {
        }

        void OnDisable()
        {
        }
    }
}