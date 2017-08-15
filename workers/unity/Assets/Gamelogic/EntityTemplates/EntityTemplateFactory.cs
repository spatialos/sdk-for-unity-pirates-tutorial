using Assets.Gamelogic.Core;
using Improbable.Core;
using Improbable.Player;
using Improbable.Ship;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;
using Improbable;
using Improbable.Unity.Entity;
using Random = UnityEngine.Random; // Used in lesson 2
using System; // Used in lesson 2
using UnityEngine;

namespace Assets.Gamelogic.EntityTemplates
{
    // Factory class with static methods used to define templates for every created entity.
    public static class EntityTemplateFactory
    {
        // Defines the template for the PlayerShip entity.
        public static Entity CreatePlayerShipTemplate(string clientWorkerId, Vector3 initialPosition)
        {
            var playerEntityTemplate = EntityBuilder.Begin()
              // Add components to the entity, then set the access permissions for the component on the entity relative to the client or server worker ids.
              .AddPositionComponent(initialPosition, CommonRequirementSets.SpecificClientOnly(clientWorkerId))
              .AddMetadataComponent(SimulationSettings.PlayerShipPrefabName)
              .SetPersistence(false)
              .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
              .AddComponent(new Rotation.Data(0), CommonRequirementSets.SpecificClientOnly(clientWorkerId))
              .AddComponent(new ClientConnection.Data(SimulationSettings.TotalHeartbeatsBeforeTimeout), CommonRequirementSets.PhysicsOnly)
              .AddComponent(new ShipControls.Data(0, 0), CommonRequirementSets.SpecificClientOnly(clientWorkerId))
              .AddComponent(new ClientAuthorityCheck.Data(), CommonRequirementSets.SpecificClientOnly(clientWorkerId))
              .Build();

            return playerEntityTemplate;
        }

        // Defines the template for the PlayerCreator entity.
        public static Entity CreatePlayerCreatorTemplate()
        {
            var playerCreatorEntityTemplate = EntityBuilder.Begin()
              // Add components to the entity, then set the access permissions for the component on the entity relative to the client or server worker ids.
              .AddPositionComponent(new Vector3(-5, 0, 0), CommonRequirementSets.PhysicsOnly)
              .AddMetadataComponent(SimulationSettings.PlayerCreatorPrefabName)
              .SetPersistence(true)
              .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
              .AddComponent(new PlayerCreation.Data(), CommonRequirementSets.PhysicsOnly)
              .Build();

            return playerCreatorEntityTemplate;
        }

        // Template definition for a Island snapshot entity
        static public Entity GenerateIslandEntityTemplate(Vector3 initialPosition, string prefabName)
        {
            var islandEntityTemplate = EntityBuilder.Begin()
              // Add components to the entity, then set the access permissions for the component on the entity relative to the client or server worker ids.
              .AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
              .AddMetadataComponent(prefabName)
              .SetPersistence(true)
              .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
              .AddComponent(new Rotation.Data(0), CommonRequirementSets.PhysicsOnly)
              .Build();

            return islandEntityTemplate;
        }

        // Template definition for a SmallFish snapshot entity
        static public Entity GenerateSmallFishTemplate(Vector3 initialPosition)
        {
            var smallFishTemplate = EntityBuilder.Begin()
              // Add components to the entity, then set the access permissions for the component on the entity relative to the client or server worker ids.
              .AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
              .AddMetadataComponent(SimulationSettings.SmallFishPrefabName)
              .SetPersistence(true)
              .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
              .AddComponent(new Rotation.Data(0), CommonRequirementSets.PhysicsOnly)
              .Build();

            return smallFishTemplate;
        }

        // Template definition for a LargeFish snapshot entity
        static public Entity GenerateLargeFishTemplate(Vector3 initialPosition)
        {
            var largeFishTemplate = EntityBuilder.Begin()
              // Add components to the entity, then set the access permissions for the component on the entity relative to the client or server worker ids.
              .AddPositionComponent(initialPosition, CommonRequirementSets.PhysicsOnly)
              .AddMetadataComponent(SimulationSettings.LargeFishPrefabName)
              .SetPersistence(true)
              .SetReadAcl(CommonRequirementSets.PhysicsOrVisual)
              .AddComponent(new Rotation.Data(0), CommonRequirementSets.PhysicsOnly)
              .Build();
            
            return largeFishTemplate;
        }
    }
}
