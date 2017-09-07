using System.Collections.Generic;
using Improbable;
using UnityEngine;

namespace Assets.Gamelogic.Core
{
    public static class SimulationSettings
    {
        // Entity Prefab Names
        public static readonly string PlayerShipPrefabName = "PlayerShip";
        public static readonly string PirateShipPrefabName = "PirateShip";
        public static readonly string PlayerCreatorPrefabName = "PlayerCreator";
        public static readonly string TerrainPrefabName = "Terrain";

        // Worker Connection
        public static readonly int TargetServerFramerate = 60;
        public static readonly int TargetClientFramerate = 120;
        public static readonly int FixedFramerate = 10;

        // Heartbeats
        public static readonly float HeartbeatCheckIntervalSecs = 5;
        public static readonly uint TotalHeartbeatsBeforeTimeout = 10;
        public static readonly float HeartbeatSendingIntervalSecs = 5;

        // Pirates (used in lesson 8 of the tutorial!)
        public static readonly int PiratesSpawnDiameter = 300;
        public static readonly int TotalPirates = 50;

        // Connection
        public static readonly float ClientConnectionTimeoutSecs = 7;
        public static readonly float PlayerCreatorQueryRetrySecs = 4;
        public static readonly float PlayerEntityCreationRetrySecs = 4;

        // Snapshot
        public static readonly string DefaultRelativeSnapshotPath = "/../../../snapshots/default.snapshot";

        // Island placements (prefab name and coordinate location)
        public static readonly Dictionary<string, Vector3> IslandsEntityPlacements =
            new Dictionary<string, Vector3>
            {
                {"Island_01", new Vector3(10, -2.6f, -35)},
                {"Island_02", new Vector3(73, -2.6f, 0)},
                {"Island_03", new Vector3(-30, -2.6f, 26)},
                {"Island_04", new Vector3(-70, -2.6f, -40)},
                {"Island_Small_01", new Vector3(22, -2.6f, 64)},
                {"Island_Small_02", new Vector3(-160, -2.6f, -10)},
                {"Island_Small_03", new Vector3(-55, -2.6f, 70)},
                {"Island_Small_04", new Vector3(-100, -2.6f, 7)}
            };

        // Small fish generation
        public static readonly string SmallFishPrefabName = "SmallFish";
        public static readonly int TotalFishInShoal = 10;
        public static readonly List<Vector3> FishShoalStartingLocations = new List<Vector3>{new Vector3(5, 0, 0), new Vector3(-80, 0, 45) };
        public static readonly float ShoalRadius = 2f;
        public static readonly float ShoalMinDepth = -0.5f;
        public static readonly float ShoalMaxDepth = -1f;
        // Large fish generation
        public static readonly string LargeFishPrefabName = "LargeFish";
        public static readonly List<Vector3> LargeFishStartingLocations = new List<Vector3> { new Vector3(-10, -1.5f, 0) };

        // Creature steering behaviours
        public static readonly float DefaultInfluenceStrength = 1f;
        public static readonly float MaxSteeringTurnAngle = 1.5f; // degrees
        public static readonly float SteeringMovementSpeed = 2.2f;
        // Central attraction influence
        public static readonly float MaxDistanceFromCentre = 130f;
        // Flocking influence
        public static readonly string FlockMembershipTag = "FlockMember";
        public static readonly float FlockingAlignmentStrength = 1f;
        public static readonly float FlockingAlignmentDistance = 15f;
        public static readonly float FlockingCohesionStrength = 1f;
        public static readonly float FlockingCohesionDistance = 15f;
        public static readonly float FlockingSeparationStrength = 1f;
        public static readonly float FlockingSeparationDistance = 2f;
        // Island avoidance influence
        public static readonly string IslandTag = "Island";
        public static readonly float MaxIslandAvoidanceDistance = 60f;
        // Random wandering influence
        public static readonly float MaximumRandomTurnAngle = 20f; // degrees
        public static readonly float SecondsBetweenRandomSteeringChoices = 5f;

        // Camera
        public static readonly string CameraRootName = "Main Camera";
        public static readonly string CameraName = "Camera";

        // Tags
        public static readonly string CannonballTag = "Cannonball";
    }
}
