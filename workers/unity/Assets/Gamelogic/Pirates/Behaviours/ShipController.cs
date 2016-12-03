using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    public class ShipController : MonoBehaviour
    {
        [Require] protected PlayerControlsReader PlayerControls;

        //Current speed (0-1 range)
        private float targetSpeed;
        public float Speed { get; private set; }

        //Current steering value (-1 to 1 range)
        private float targetSteering;
        public float Steering { get; private set; }

        public void Update()
        {
            var inputSpeed = PlayerControls.TargetSpeed;
            var inputSteering = PlayerControls.TargetSteering;

            var delta = Time.deltaTime;

            // Slowly decay the speed and steering values over time and make sharp turns slow down the ship.
            targetSpeed = Mathf.Lerp(targetSpeed, 0f, delta * (0.5f + Mathf.Abs(targetSteering)));
            targetSteering = Mathf.Lerp(targetSteering, 0f, delta * 3f);

            // Calculate the input-modified speed
            targetSpeed = Mathf.Clamp01(targetSpeed + delta * inputSpeed);
            Speed = Mathf.Lerp(Speed, targetSpeed, Mathf.Clamp01(delta * 5f));

            // Steering is affected by speed -- the slower the ship moves, the less maneuverable is the ship
            targetSteering = Mathf.Clamp(targetSteering + delta * 6 * inputSteering * (0.1f + 0.9f * Speed), -1f, 1f);
            Steering = Mathf.Lerp(Steering, targetSteering, delta * 5f);
        }
    }
}