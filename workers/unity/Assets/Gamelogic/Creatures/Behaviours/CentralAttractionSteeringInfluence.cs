using Assets.Gamelogic.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours.Creatures
{
    // Enable this MonoBehaviour on UnityWorker (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class CentralAttractionSteeringInfluence : SteeringInfluence
    {
        /*
         * This influence returns a vector directed towards the centre of the world. The influence
         * vector is scaled by distance, with small magnitudes close to the centre of the world, a
         * magnitude of at a distance of 'MaxDistanceFromCentre', and a magnitude greater than one if
         * the gameobject moves beyond that.
         */
        
        // Central attraction influence variables are exposed in the editor for tuning purposes
        [SerializeField] private float MaxDistanceFromCentre;

        public void OnAwake()
        {
            MaxDistanceFromCentre = SimulationSettings.MaxDistanceFromCentre;
        }

        public override Vector3 GetInfluenceHeading()
        {
            return GetCentralAttraction();
        }

        private Vector3 GetCentralAttraction()
        {
            var distanceToCentre = Vector3.Magnitude(gameObject.transform.position);
            var attractionStrength = distanceToCentre / MaxDistanceFromCentre;
            var vectorToCentre = -Vector3.Normalize(gameObject.transform.position);
            return vectorToCentre * attractionStrength * InfluenceStrength;
        }
    }
}
