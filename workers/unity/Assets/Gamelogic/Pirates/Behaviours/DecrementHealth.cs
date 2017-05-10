using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on server-side workers only
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