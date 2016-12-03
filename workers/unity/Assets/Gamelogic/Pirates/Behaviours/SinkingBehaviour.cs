using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    public class SinkingBehaviour : MonoBehaviour
    {
        public Animation SinkingAnimation;

        void OnEnable()
        {
            // Register your callbacks in OnEnable.
        }

        void OnDisable()
        {
            // Deregister your callbacks and rewind animations inside OnDisable.
        }

    }
}