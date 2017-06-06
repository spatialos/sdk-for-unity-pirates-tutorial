using Assets.Gamelogic.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours.Creatures
{
    // Enable this MonoBehaviour on UnityWorker (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class RandomWanderingSteeringInfluence : SteeringInfluence
    {
        /*
         * This influence randomly chooses a new favoured heading every so often to provide some
         * variety and sponteneity to the steering.
         */

        private Vector3 heading;

        protected new void OnEnable()
        {
            // As we are overriding the base class OnEnable function we must manually call it to enact its logic
            base.OnEnable();

            heading = transform.forward;
            // Initiate repeating callback to periodically change random heading
            InvokeRepeating("RandomizeSteering", 0, SimulationSettings.SecondsBetweenRandomSteeringChoices);
        }

        private new void OnDisable()
        {
            base.OnDisable();
            CancelInvoke("RandomizeSteering");
        }

        private void RandomizeSteering()
        {
            var randomTurnAngle = Random.Range(-SimulationSettings.MaximumRandomTurnAngle, SimulationSettings.MaximumRandomTurnAngle);
            heading = Quaternion.AngleAxis(randomTurnAngle, Vector3.up) * transform.forward * InfluenceStrength;
        }

        public override Vector3 GetInfluenceHeading()
        {
            return heading;
        }
    }
}
