
namespace Assets.Gamelogic.Core
{
    public static class BuildSettings
    {
        public static readonly string UnityClientScene = "UnityClient";
        public static readonly string SplashScreenScene = "SplashScreen";
        public static readonly string ClientDefaultActiveScene = UnityClientScene;
        public static readonly string[] ClientScenes = { UnityClientScene, SplashScreenScene };

        public static readonly string UnityWorkerScene = "UnityWorker";
        public static readonly string WorkerDefaultActiveScene = UnityWorkerScene;
        public static readonly string[] WorkerScenes = { UnityWorkerScene };

        public const string SceneDirectory = "Assets";
    }
}
