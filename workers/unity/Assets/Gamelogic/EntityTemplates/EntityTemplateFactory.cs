using Assets.Gamelogic.Core;
using Improbable.Core;
using Improbable.Math;
using Improbable.Player;
using Improbable.Ship;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;
using Random = UnityEngine.Random; // Used in lesson 8
using Terrain = Improbable.Terrain.Terrain;

namespace Assets.Gamelogic.EntityTemplates
{
    // Factory class with static methods used to define templates for every created entity.
    public static class EntityTemplateFactory
    {
        // Defines the template for the PlayerShip entity.
        public static Entity CreatePlayerShipTemplate(string clientWorkerId, Coordinates initialPosition)
        {
            var playerEntityTemplate = new Entity();

            // Add components to the entity.
            playerEntityTemplate.Add(new WorldTransform.Data(initialPosition, 0));
            playerEntityTemplate.Add(new ClientConnection.Data(SimulationSettings.TotalHeartbeatsBeforeTimeout));
            playerEntityTemplate.Add(new ShipControls.Data(0, 0));
            playerEntityTemplate.Add(new ClientAuthorityCheck.Data());

            // Sets the access permisisons for each component on the entity relative to the client or server worker ids.
            var acl = Acl.Build()
                .SetReadAccess(CommonRequirementSets.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonRequirementSets.SpecificClientOnly(clientWorkerId))
                .SetWriteAccess<ClientConnection>(CommonRequirementSets.PhysicsOnly)
                .SetWriteAccess<ShipControls>(CommonRequirementSets.SpecificClientOnly(clientWorkerId))
                .SetWriteAccess<ClientAuthorityCheck>(CommonRequirementSets.SpecificClientOnly(clientWorkerId));
            playerEntityTemplate.SetAcl(acl);

            return playerEntityTemplate;
        }

        // Defines the template for the PlayerCreator entity.
        public static SnapshotEntity CreatePlayerCreatorTemplate()
        {
            var playerCreatorEntityTemplate = new SnapshotEntity { Prefab = SimulationSettings.PlayerCreatorPrefabName };

            // Add components to the entity.
            playerCreatorEntityTemplate.Add(new WorldTransform.Data(Coordinates.ZERO, 0));
            playerCreatorEntityTemplate.Add(new PlayerCreation.Data());

            // Sets the access permisisons for each component on the entity relative to the client or server worker ids.
            var acl = Acl.GenerateServerAuthoritativeAcl(playerCreatorEntityTemplate);
            playerCreatorEntityTemplate.SetAcl(acl);

            return playerCreatorEntityTemplate;
        }

        // Defines the template for the Terrain entity.
        public static SnapshotEntity CreateTerrainTemplate()
        {
            var terrainEntityTemplate = new SnapshotEntity { Prefab = SimulationSettings.TerrainPrefabName };

            // Add components to the entity.
            terrainEntityTemplate.Add(new Terrain.Data());
            terrainEntityTemplate.Add(new WorldTransform.Data(Coordinates.ZERO, 0));

            // Sets the access permisisons for each component on the entity relative to the client or server worker ids.
            var acl = Acl.GenerateServerAuthoritativeAcl(terrainEntityTemplate);
            terrainEntityTemplate.SetAcl(acl);

            return terrainEntityTemplate;
        }
    }
}
