using Improbable.Ship;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Enable this MonoBehaviour on client workers only
    [WorkerType(WorkerPlatform.UnityClient)]
    public class SinkingBehaviour : MonoBehaviour
    {
        public Animation SinkingAnimation;

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }
    }
}