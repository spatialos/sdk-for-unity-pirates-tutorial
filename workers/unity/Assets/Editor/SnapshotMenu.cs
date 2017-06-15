using Assets.Gamelogic.Core;
using Assets.Gamelogic.EntityTemplates;
using Improbable;
using Improbable.Worker;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using Improbable.Math;
using Random = UnityEngine.Random;
using UnityEngine;

namespace Assets.Editor 
{
    public class SnapshotMenu : MonoBehaviour
    {
        [MenuItem("Improbable/Snapshots/Generate Default Snapshot")]
        [UsedImplicitly]
        private static void GenerateDefaultSnapshot()
        {
            var snapshotEntities = new Dictionary<EntityId, SnapshotEntity>();
            var currentEntityId = 1;

            snapshotEntities.Add(new EntityId(currentEntityId++), EntityTemplateFactory.CreatePlayerCreatorTemplate());
            PopulateSnapshotWithIslandTerrainEntities(ref snapshotEntities, ref currentEntityId);
            PopulateSnapshotWithSmallFishGroups(ref snapshotEntities, ref currentEntityId);
            PopulateSnapshotWithLargeFish(ref snapshotEntities, ref currentEntityId);

            SaveSnapshot(snapshotEntities);
        }

        // Create and island entity for each island prefab at its given world coordinates
        public static void PopulateSnapshotWithIslandTerrainEntities(ref Dictionary<EntityId, SnapshotEntity> snapshotEntities, ref int nextAvailableId)
        {
            foreach(var item in SimulationSettings.IslandsEntityPlacements)
            {
                snapshotEntities.Add(new EntityId(nextAvailableId++),
                    EntityTemplateFactory.GenerateIslandEntityTemplate(item.Value, item.Key));
            }
        }

        // Create shoal of small fish entities around given coordinates
        public static void PopulateSnapshotWithSmallFishGroups(ref Dictionary<EntityId, SnapshotEntity> snapshotEntities, ref int nextAvailableId)
        {
            foreach (var location in SimulationSettings.FishShoalStartingLocations)
            {
                for (var i = 0; i < SimulationSettings.TotalFishInShoal; i++)
                {
                    var nextFishCoodinates = new Coordinates(location.X + Random.Range(-SimulationSettings.ShoalRadius, SimulationSettings.ShoalRadius),
                                                             location.Y + Random.Range(SimulationSettings.ShoalMinDepth, SimulationSettings.ShoalMaxDepth),
                                                             location.Z + Random.Range(-SimulationSettings.ShoalRadius, SimulationSettings.ShoalRadius));
                    snapshotEntities.Add(new EntityId(nextAvailableId++), EntityTemplateFactory.GenerateSmallFishTemplate(nextFishCoodinates));
                }
            }
        }

        // Create large fish entities
        public static void PopulateSnapshotWithLargeFish(ref Dictionary<EntityId, SnapshotEntity> snapshotEntities, ref int nextAvailableId)
        {
            foreach (var location in SimulationSettings.LargeFishStartingLocations)
            {
                snapshotEntities.Add(new EntityId(nextAvailableId++), EntityTemplateFactory.GenerateLargeFishTemplate(location));
            }
        }

        private static void SaveSnapshot(IDictionary<EntityId, SnapshotEntity> snapshotEntities)
        {
            var snapshotPath = Application.dataPath + SimulationSettings.DefaultRelativeSnapshotPath;
            File.Delete(snapshotPath);
            var maybeError = Snapshot.Save(snapshotPath, snapshotEntities);

            if (maybeError.HasValue)
            {
	            Debug.LogErrorFormat("Failed to generate initial world snapshot: {0}", maybeError.Value);
            }
            else
            {
	            Debug.LogFormat("Successfully generated initial world snapshot at {0}", snapshotPath);
            }
        }
    }
}
