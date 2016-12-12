using UnityEngine;
using Improbable.General;
using Improbable.Math;
using Improbable.Player;
using Improbable.Ship;
using Improbable.Unity.Core.Acls;
using Improbable.Worker;

namespace Assets.EntityTemplates
{
    public class PlayerShipEntityTemplate : MonoBehaviour
    {
        // Template definition for a PlayerShip snapshot entity
        static public Entity GeneratePlayerShipEntityTemplate(string clientWorkerId, Coordinates initialPosition)
        {
            var playerEntityTemplate = new Entity();
            // Define components attached to entity
            playerEntityTemplate.Add(new WorldTransform.Data(new WorldTransformData(initialPosition, 0)));
            playerEntityTemplate.Add(new PlayerLifecycle.Data(new PlayerLifecycleData(0, 3, 10)));
            playerEntityTemplate.Add(new ShipControls.Data(new ShipControlsData(0, 0)));

            // Grant component access permissions
            var acl = Acl.Build()
                .SetReadAccess(CommonPredicates.PhysicsOrVisual)
                .SetWriteAccess<WorldTransform>(CommonPredicates.SpecificClientOnly(clientWorkerId))
                .SetWriteAccess<ShipControls>(CommonPredicates.SpecificClientOnly(clientWorkerId))
                .SetWriteAccess<PlayerLifecycle>(CommonPredicates.PhysicsOnly);
            playerEntityTemplate.SetAcl(acl);

            return playerEntityTemplate;
        }
    }
}