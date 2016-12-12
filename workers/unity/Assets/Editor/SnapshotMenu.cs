using System.Collections.Generic;
using System.IO;
using Assets.EntityTemplates;
using Improbable;
using Improbable.Worker;
using UnityEngine;
using JetBrains.Annotations;
using UnityEditor;

public class SnapshotMenu : MonoBehaviour
{
    private static readonly string InitialWorldSnapshotPath = Application.dataPath +
                                                              "/../../../snapshots/initial_world.snapshot";

    [MenuItem("Improbable/Snapshots/Generate Snapshot Programmatically")]
    [UsedImplicitly]
    private static void GenerateSnapshotProgrammatically()
    {
        var snapshotEntities = new Dictionary<EntityId, SnapshotEntity>();
        var currentEntityId = 0;
        
        snapshotEntities.Add(new EntityId(currentEntityId++), TerrainEntityTemplate.GenerateTerrainSnapshotEntityTemplate());
        snapshotEntities.Add(new EntityId(currentEntityId++), PlayerSpawnerEntityTemplate.GeneratePlayerSpawnerSnapshotEntityTemplate());

        SaveSnapshot(snapshotEntities);
    }

    private static void SaveSnapshot(IDictionary<EntityId, SnapshotEntity> snapshotEntities)
    {
        File.Delete(InitialWorldSnapshotPath);
        var maybeError = Snapshot.Save(InitialWorldSnapshotPath, snapshotEntities);

        if (maybeError.HasValue)
        {
            Debug.LogErrorFormat("Failed to generate initial world snapshot: {0}", maybeError.Value);
        }
        else
        {
            Debug.LogFormat("Successfully generated initial world snapshot at {0}", InitialWorldSnapshotPath);
        }
    }
}
