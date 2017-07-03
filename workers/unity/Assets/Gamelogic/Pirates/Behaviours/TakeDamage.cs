using Assets.Gamelogic.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on UnityWorker (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class TakeDamage : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.gameObject.tag == SimulationSettings.CannonballTag)
            {
            }
        }
    }
}