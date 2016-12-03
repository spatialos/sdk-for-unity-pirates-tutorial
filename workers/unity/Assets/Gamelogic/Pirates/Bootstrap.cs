using Improbable.Unity;
using Improbable.Unity.Configuration;
using Improbable.Unity.Core;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public WorkerConfigurationData Configuration = new WorkerConfigurationData();

    public void Start()
    {
        UnityWorker.ApplyConfiguration(Configuration);

        switch (UnityWorker.Configuration.EnginePlatform)
        {
            case EnginePlatform.FSim:
                UnityWorker.OnDisconnected += reason => Application.Quit();

                var targetFramerate = 120;
                var fixedFramerate = 20;

                Application.targetFrameRate = targetFramerate;
                Time.fixedDeltaTime = 1.0f / fixedFramerate;
                break;
        }

        UnityWorker.Connect(gameObject);
    }    
}