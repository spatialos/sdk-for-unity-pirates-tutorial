using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // This MonoBehaviour will be enabled on both client and server-side workers
    public class ShipController : MonoBehaviour
    {
        // Inject access to the entity's ShipControls component
        [Require] protected ShipControls.Reader ShipControlsReader;

        //Current speed (0-1 range)
        private float targetSpeed;
        public float currentSpeed { get; private set; }

        //Current steering value (-1 to 1 range)
        private float targetSteering;
        public float currentSteering { get; private set; }

        public void Update()
        {
            var inputSpeed = ShipControlsReader.Data.targetSpeed;
            var inputSteering = ShipControlsReader.Data.targetSteering;

            var delta = Time.deltaTime;

            // Slowly decay the speed and steering values over time and make sharp turns slow down the ship.
            targetSpeed = Mathf.Lerp(targetSpeed, 0f, delta * (0.5f + Mathf.Abs(targetSteering)));
            targetSteering = Mathf.Lerp(targetSteering, 0f, delta * 3f);

            // Calculate the input-modified speed
            targetSpeed = Mathf.Clamp01(targetSpeed + delta * inputSpeed);
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Mathf.Clamp01(delta * 5f));

            // Steering is affected by speed -- the slower the ship moves, the less maneuverable is the ship
            targetSteering = Mathf.Clamp(targetSteering + delta * 6 * inputSteering * (0.1f + 0.9f * currentSpeed), -1f, 1f);
            currentSteering = Mathf.Lerp(currentSteering, targetSteering, delta * 5f);
        }
    }
}