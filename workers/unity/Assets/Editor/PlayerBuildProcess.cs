using Assets.Gamelogic.Core;
using Improbable.Unity;
using Improbable.Unity.EditorTools.Build;
using System;
using System.IO;
using System.Linq;
using UnityEditor;

namespace Assets.Editor
{
    [InitializeOnLoad]
    public class PlayerBuildProcess : IPlayerBuildEvents
    {
        // Install the custom event handler
        static PlayerBuildProcess()
        {
            /* Each time you use Build development players or Build deployment players, SimpleBuildSystem.CreatePlayerBuildEventsAction
               is called, and a new PlayerBuildProcess event handler will be created */
            SimpleBuildSystem.CreatePlayerBuildEventsAction = () => new PlayerBuildProcess();
            // Configure the Unity editor build settings for running multiple scenes with the editor
            EditorBuildSettings.scenes = FormatAsBuildSettingsScenes(GetAllScenes());
        }

        #region Implement IPlayerBuildEvents

        // Overridden function to load (and optionally modify) scenes, then return an array of scene paths to be built into the worker
        public string[] GetScenes(WorkerPlatform workerType)
        {
            string[] scenePaths;

            switch (workerType)
            {
                case WorkerPlatform.UnityClient:
                    scenePaths = FormatSceneList(BuildSettings.ClientScenes, BuildSettings.ClientDefaultActiveScene);
                    break;
                case WorkerPlatform.UnityWorker:
                    scenePaths = FormatSceneList(BuildSettings.WorkerScenes, BuildSettings.WorkerDefaultActiveScene);
                    break;
                default:
                    throw new Exception("Attempting to get scenes for unrecognised worker platform");
            }

            return scenePaths;
        }

        // Overridden function called before any workers are built - use to do preliminary work such as saving scenes
        public void BeginBuild() { }

        // Overridden function called after all workers are built, even if errors occurred - use to clean up anything done in BeginBuild
        public void EndBuild() { }

        // Overridden function - use to do work such as copying additional files that need to be packaged with the worker
        public void BeginPackage(WorkerPlatform workerType, BuildTarget target, Config config, string packagePath) { }

        #endregion

        // Map array of scene paths to custom Unity type for saving as editor build settings
        private static EditorBuildSettingsScene[] FormatAsBuildSettingsScenes(string[] scenePaths)
        {
            return scenePaths.Select(scenePath => new EditorBuildSettingsScene(scenePath, true)).ToArray();
        }

        // Get all scenes for the purposes of adding to the Unity editor build settings
        private static string[] GetAllScenes()
        {
            return BuildSettings.ClientScenes.Union(BuildSettings.WorkerScenes).Select(FormatSceneName).ToArray();
        }

        // Ensures scene specified as default is listed (and therefore loaded) first
        private static string[] FormatSceneList(string[] sceneList, string defaultActiveScene)
        {
            return sceneList.OrderBy(scene => scene != defaultActiveScene).Select(FormatSceneName).ToArray();
        }

        // Formats scene name as it appears in your Unity project directory
        private static string FormatSceneName(string sceneName)
        {
            return Path.Combine(BuildSettings.SceneDirectory, sceneName) + ".unity";
        }
    }
}