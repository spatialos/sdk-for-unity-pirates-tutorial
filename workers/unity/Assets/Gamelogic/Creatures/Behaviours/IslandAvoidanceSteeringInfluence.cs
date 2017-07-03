using Assets.Gamelogic.Core;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours.Creatures
{
    // Enable this MonoBehaviour on UnityWorker (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class IslandAvoidanceSteeringInfluence : SteeringInfluence
    {
        /*
         * This influence steers the gameobject away from nearby islands gameobjects by combining
         * a repulsion vector from each nearby island. Each repulsion vector is scaled based on the
         * gameobject's distance from the island to ensure that closer islands provide stronger repulsion.
         */
           
        // At a distance from an island less than MaxAvoidanceDistance, will start steering away
        public float MaxAvoidanceDistance = SimulationSettings.MaxIslandAvoidanceDistance;

        public void OnAwake()
        {
            MaxAvoidanceDistance = SimulationSettings.MaxIslandAvoidanceDistance;
        }

        public override Vector3 GetInfluenceHeading()
        {            
            return GetIslandRepulsion();
        }

        private Vector3 GetIslandRepulsion()
        {
            Vector3 combinedRepulsionVector = Vector3.zero;
            // Combine repulsion vectors from all nearby island entities
            foreach (var island in GameObject.FindGameObjectsWithTag(SimulationSettings.IslandTag))
            {
                var distanceToIsland = Vector3.Distance(transform.position, island.transform.position);
                if (distanceToIsland < MaxAvoidanceDistance)
                {
                    var repulsionStrength = 1 - distanceToIsland / MaxAvoidanceDistance;
                    // Ignore island's y component
                    var vecFromIsland = Vector3.Normalize(new Vector3(transform.position.x - island.transform.position.x,
                                                                          0,
                                                                          transform.position.z - island.transform.position.z));
                    combinedRepulsionVector += vecFromIsland * repulsionStrength;
                }
            }
            return Vector3.Normalize(combinedRepulsionVector);
        }
    }
}
