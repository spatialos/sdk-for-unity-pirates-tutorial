using Improbable.Unity;
using Improbable.Unity.Visualizer;
using System.Collections.Generic;
using Assets.Gamelogic.Core;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours.Creatures
{
    // Enable this MonoBehaviour on UnityWorker (server-side) workers only
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class FlockingSteeringInfluence : SteeringInfluence
    {
        /*
         * This influence returns a vector which causes the gameobject to exhibit flocking behaviour
         * relative to other nearby gameobjects which bear the same FlockMembershipTag.
         */
        
        // Flocking influence variables are exposed in the editor for tuning purposes
        [SerializeField] private float alignmentStrength;
        [SerializeField] private float alignmentDistance;
        [SerializeField] private float cohesionStrength;
        [SerializeField] private float cohesionDistance;
        [SerializeField] private float separationStrength;
        [SerializeField] private float separationDistance;

        private List<GameObject> flockMembers = new List<GameObject>();

        public void OnAwake()
        {
            alignmentStrength = SimulationSettings.FlockingAlignmentStrength;
            alignmentDistance = SimulationSettings.FlockingAlignmentDistance;
            cohesionStrength = SimulationSettings.FlockingCohesionStrength;
            cohesionDistance = SimulationSettings.FlockingCohesionDistance;
            separationStrength = SimulationSettings.FlockingSeparationStrength;
            separationDistance = SimulationSettings.FlockingSeparationDistance;
        }

        public override Vector3 GetInfluenceHeading()
        {
            UpdateFlockMemberList();

            var heading = GetSeparationInfluence() * separationStrength +
                          GetCohesionInfluence() * cohesionStrength + 
                          GetAlignmentInfluence() * alignmentStrength;
            return heading;
        }

        public void UpdateFlockMemberList()
        {
            flockMembers.Clear();
            float maximumInfluenceDistance = Mathf.Max(alignmentDistance, cohesionDistance, separationDistance);
            foreach (var prospectiveFlockMember in GameObject.FindGameObjectsWithTag(SimulationSettings.FlockMembershipTag))
            {
                // Ignore prospective flock members which are too far away
                if (Vector3.Distance(prospectiveFlockMember.transform.position, gameObject.transform.position) > maximumInfluenceDistance)
                {
                    continue;
                }
                // Ignore prospective flock members which are heading a very different direction
                if (Vector3.Dot(this.transform.forward, prospectiveFlockMember.transform.forward) < 0)
                {
                    // Has at least 90 degree difference in heading, so skip
                    continue;
                }
                // Include this entity in the flock
                flockMembers.Add(prospectiveFlockMember);
            }
        }

        public Vector3 GetSeparationInfluence()
        {
            // Accumulate separation vector contributions
            var combinedSeparationVector = Vector3.zero;
            foreach (var flockMember in flockMembers)
            {
                var vecFromFlockMember = transform.position - flockMember.transform.position;
                var distanceToFlockMember = vecFromFlockMember.magnitude;
                if (distanceToFlockMember < separationDistance)
                {
                    combinedSeparationVector += (vecFromFlockMember*(1 - distanceToFlockMember / separationDistance))/flockMembers.Count;
                }
            }
            return combinedSeparationVector;
        }

        public Vector3 GetCohesionInfluence()
        {
            // Accumulate cohesion vector contributions
            var combinedCohesionVector = Vector3.zero;
            foreach (var flockMember in flockMembers)
            {
                var vecToFlockMember = flockMember.transform.position - transform.position;
                var distanceToFlockMember = vecToFlockMember.magnitude;
                if (distanceToFlockMember <= cohesionDistance)
                {
                    combinedCohesionVector += (vecToFlockMember * (distanceToFlockMember / cohesionDistance))/ flockMembers.Count;
                }
            }
            return combinedCohesionVector;
        }

        public Vector3 GetAlignmentInfluence()
        {
            // Accumulate alignment vector contributions
            var combinedAlignmentVector = Vector3.zero;
            foreach (var flockMember in flockMembers)
            {
                var distanceToFlockMember = Vector3.Distance(flockMember.transform.position, transform.position);
                if (distanceToFlockMember <= alignmentDistance)
                {
                    combinedAlignmentVector += (flockMember.transform.forward * (distanceToFlockMember / alignmentDistance))/ flockMembers.Count;
                }
            }
            return combinedAlignmentVector;
        }
    }
}
