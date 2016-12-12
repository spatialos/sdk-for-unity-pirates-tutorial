using Improbable.Math;
using Improbable.Worker;
using Improbable.General;
using Improbable.Unity.Core.Acls;
using Terrain = Improbable.Terrain.Terrain;
using TerrainData = Improbable.Terrain.TerrainData;
using UnityEngine;

public class TerrainEntityTemplate : MonoBehaviour
{
    // Template definition for a Terrain entity
    public static SnapshotEntity GenerateTerrainSnapshotEntityTemplate()
    {
        // Set name of Unity prefab associated with this entity
        var terrain = new SnapshotEntity {Prefab = "Terrain"};
        // Define components attached to snapshot entity
        terrain.Add(new Terrain.Data(new TerrainData()));
        terrain.Add(new WorldTransform.Data(new WorldTransformData(new Coordinates(5, 0, 0), 0)));

        // Grant FSim workers write-access over all of this entity's components, read-access for visual (e.g. client) workers
        var acl = Acl.GenerateServerAuthoritativeAcl(terrain);
        terrain.SetAcl(acl);

        return terrain;
    }
}
