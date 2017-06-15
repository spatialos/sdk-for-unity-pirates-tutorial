using Assets.Gamelogic.EntityTemplates;
using Improbable;
using Improbable.Core;
using Improbable.Entity.Component;
using Improbable.Math;
using Improbable.Unity;
using Improbable.Unity.Core;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Core
{
    [WorkerType(WorkerPlatform.UnityWorker)]
    public class PlayerCreatingBehaviour : MonoBehaviour
    {
        [Require]
        private PlayerCreation.Writer PlayerCreationWriter;

        private void OnEnable()
        {
            PlayerCreationWriter.CommandReceiver.OnCreatePlayer.RegisterResponse(OnCreatePlayer);
        }

        private void OnDisable()
        {
            PlayerCreationWriter.CommandReceiver.OnCreatePlayer.DeregisterResponse();
        }

        private CreatePlayerResponse OnCreatePlayer(CreatePlayerRequest request, ICommandCallerInfo callerinfo)
        {
            CreatePlayerWithReservedId(callerinfo.CallerWorkerId);
            return new CreatePlayerResponse();
        }

        private void CreatePlayerWithReservedId(string clientWorkerId)
        {
            SpatialOS.Commands.ReserveEntityId(PlayerCreationWriter)
                .OnSuccess(reservedEntityId => CreatePlayer(clientWorkerId, reservedEntityId))
                .OnFailure(failure => OnFailedReservation(failure, clientWorkerId));
        }

        private void OnFailedReservation(ICommandErrorDetails response, string clientWorkerId)
        {
            Debug.LogError("Failed to Reserve EntityId for Player: " + response.ErrorMessage + ". Retrying...");
            CreatePlayerWithReservedId(clientWorkerId);
        }

        private void CreatePlayer(string clientWorkerId, EntityId entityId)
        {
            // Initial position is slightly randomised to prevent colliders interpenetrating at start
            var initialPosition = new Coordinates(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            var playerEntityTemplate = EntityTemplateFactory.CreatePlayerShipTemplate(clientWorkerId, initialPosition);
            SpatialOS.Commands.CreateEntity(PlayerCreationWriter, entityId, SimulationSettings.PlayerShipPrefabName, playerEntityTemplate)
                .OnFailure(failure => OnFailedPlayerCreation(failure, clientWorkerId, entityId));
        }

        private void OnFailedPlayerCreation(ICommandErrorDetails response, string clientWorkerId, EntityId entityId)
        {
            Debug.LogError("Failed to Create PlayerShip Entity: " + response.ErrorMessage + ". Retrying...");
            CreatePlayer(clientWorkerId, entityId);
        }
    }
}
