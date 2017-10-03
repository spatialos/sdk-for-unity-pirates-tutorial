using Improbable;
using Improbable.Core;
using Improbable.Unity;
using Improbable.Unity.Configuration;
using Improbable.Unity.Core;
using Improbable.Unity.Core.EntityQueries;
using UnityEngine;
using UnityEngine.SceneManagement;

// Placed on a GameObject in a Unity scene to execute SpatialOS connection logic on startup.
namespace Assets.Gamelogic.Core
{
    public class Bootstrap : MonoBehaviour
    {
        public WorkerConfigurationData Configuration = new WorkerConfigurationData();

        // Called when the Play button is pressed in Unity.
        public void Start()
        {

            SpatialOS.ApplyConfiguration(Configuration);

            Time.fixedDeltaTime = 1.0f / SimulationSettings.FixedFramerate;

            // Distinguishes between when the Unity is running as a client or a server.
            switch (SpatialOS.Configuration.WorkerPlatform)
            {
                case WorkerPlatform.UnityWorker:
                    Application.targetFrameRate = SimulationSettings.TargetServerFramerate;
                    SpatialOS.OnDisconnected += reason => Application.Quit();
                    SpatialOS.Connect(gameObject);
                    break;
                case WorkerPlatform.UnityClient:
                    Application.targetFrameRate = SimulationSettings.TargetClientFramerate;
                    SpatialOS.OnConnected += CreatePlayer;
                    SceneManager.LoadScene(BuildSettings.SplashScreenScene, LoadSceneMode.Additive);
                    break;
            }
        }

        // Called when pressing Connect from the splash screen.
        public void ConnectToClient()
        {
            SpatialOS.Connect(gameObject);
        }

        // Search for the PlayerCreator entity in the world in order to send a CreatePlayer command.
        public static void CreatePlayer()
        {
            var playerCreatorQuery = Query.HasComponent<PlayerCreation>().ReturnOnlyEntityIds();
            SpatialOS.WorkerCommands.SendQuery(playerCreatorQuery)
                .OnSuccess(OnSuccessfulPlayerCreatorQuery)
                .OnFailure(OnFailedPlayerCreatorQuery);
        }

        private static void OnSuccessfulPlayerCreatorQuery(EntityQueryResult queryResult)
        {
            if (queryResult.EntityCount < 1)
            {
                Debug.LogError("Failed to find PlayerCreator. SpatialOS probably hadn't finished loading the initial snapshot. Try again in a few seconds.");
                return;
            }

            var playerCreatorEntityId = queryResult.Entities.First.Value.Key;
            RequestPlayerCreation(playerCreatorEntityId);
        }

        private static void OnFailedPlayerCreatorQuery(ICommandErrorDetails _)
        {
            Debug.LogError("PlayerCreator query failed. SpatialOS workers probably haven't started yet. Try again in a few seconds.");
        }

        // Send a CreatePlayer command to the PLayerCreator entity requesting a Player entity be spawned.
        private static void RequestPlayerCreation(EntityId playerCreatorEntityId)
        {
            SpatialOS.WorkerCommands.SendCommand(PlayerCreation.Commands.CreatePlayer.Descriptor, new CreatePlayerRequest(), playerCreatorEntityId)
                .OnFailure(response => OnCreatePlayerFailure(response, playerCreatorEntityId));
        }

        private static void OnCreatePlayerFailure(ICommandErrorDetails _, EntityId playerCreatorEntityId)
        {
            Debug.LogWarning("CreatePlayer command failed - you probably tried to connect too soon. Try again in a few seconds.");
        }
    }
}
