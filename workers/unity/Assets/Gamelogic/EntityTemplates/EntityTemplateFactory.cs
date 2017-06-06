using System; // Used in lesson 8
using Assets.Gamelogic.Core; // Used in lesson 8
using Improbable.Core;
using Improbable.Math;
using Improbable.Player;
using Improbable.Ship;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;
using Random = UnityEngine.Random; // Used in lesson 8

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
            playerCreatorEntityTemplate.Add(new WorldTransform.Data(new Coordinates(-5, 0, 0), 0));
            playerCreatorEntityTemplate.Add(new PlayerCreation.Data());

            // Sets the access permisisons for each component on the entity relative to the client or server worker ids.
            var acl = Acl.GenerateServerAuthoritativeAcl(playerCreatorEntityTemplate);
            playerCreatorEntityTemplate.SetAcl(acl);

            return playerCreatorEntityTemplate;
        }

        // Template definition for a Island snapshot entity
        static public SnapshotEntity GenerateIslandEntityTemplate(Coordinates initialPosition, string prefabName)
        {
            var islandEntityTemplate = new SnapshotEntity { Prefab = prefabName };
            // Define components attached to entity
            islandEntityTemplate.Add(new WorldTransform.Data(new WorldTransformData(initialPosition, 0)));

            // Grant component access permissions
            var acl = Acl.Build()
                .SetReadAccess(CommonRequirementSets.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonRequirementSets.PhysicsOnly);
            islandEntityTemplate.SetAcl(acl);

            return islandEntityTemplate;
        }

        // Template definition for a SmallFish snapshot entity
        static public SnapshotEntity GenerateSmallFishTemplate(Coordinates initialPosition)
        {
            var smallFishTemplate = new SnapshotEntity { Prefab = SimulationSettings.SmallFishPrefabName };
            // Define components attached to entity
            smallFishTemplate.Add(new WorldTransform.Data(new WorldTransformData(initialPosition, 0)));

            // Grant component access permissions
            var acl = Acl.Build()
                .SetReadAccess(CommonRequirementSets.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonRequirementSets.PhysicsOnly);
            smallFishTemplate.SetAcl(acl);

            return smallFishTemplate;
        }

        // Template definition for a LargeFish snapshot entity
        static public SnapshotEntity GenerateLargeFishTemplate(Coordinates initialPosition)
        {
            var largeFishTemplate = new SnapshotEntity { Prefab = SimulationSettings.LargeFishPrefabName };
            // Define components attached to entity
            largeFishTemplate.Add(new WorldTransform.Data(new WorldTransformData(initialPosition, 0)));

            // Grant component access permissions
            var acl = Acl.Build()
                .SetReadAccess(CommonRequirementSets.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonRequirementSets.PhysicsOnly);
            largeFishTemplate.SetAcl(acl);

            return largeFishTemplate;
        }
    }
}
