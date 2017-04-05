using UnityEngine;

namespace Assets.Gamelogic.Global
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
        public static readonly uint TotalHeartbeatsBeforeTimeout = 3;
        public static readonly float HeartbeatSendingIntervalSecs = 5;

        // Pirates (used in lesson 8 of the tutorial!)
        public static readonly int PiratesSpawnDiameter = 300;
        public static readonly int TotalPirates = 50;

        // Connection
        public static readonly float ClientConnectionTimeoutSecs = 7;
        public static readonly float PlayerCreatorQueryRetrySecs = 4;
        public static readonly float PlayerEntityCreationRetrySecs = 4;

        // Snapshot
        public static readonly string DefaultSnapshotPath = Application.dataPath + "/../../../snapshots/default.snapshot";
    }
}
