using Improbable.Global;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on client workers only
    [WorkerType(WorkerPlatform.UnityClient)]
    public class CameraEnablerVisualizer : MonoBehaviour
    {
        /* 
         * Clients will only have write-access for their own designated PlayerShip entity's ClientAuthorityCheck component,
         * so this MonoBehaviour will be enabled on the client's designated PlayerShip GameObject only and not on
         * the GameObject of other players' ships.
         */
        [Require]
        private ClientAuthorityCheck.Writer ClientAuthorityCheckWriter;

        [SerializeField]
        private Vector3 CameraOffset;

        public void OnEnable()
        {
            var camera = Camera.main;
            camera.transform.parent = transform;
            camera.transform.localPosition = CameraOffset;
            camera.transform.LookAt(transform.position + Vector3.up);
        }
    }
}
