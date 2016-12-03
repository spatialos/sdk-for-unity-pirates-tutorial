using UnityEngine;

namespace Assets.Gamelogic.Pirates.Water
{
    public class RepositionWater : MonoBehaviour
    {
        private Transform ourTransform;
        private Transform cameraTransform;

        void Start ()
        {
            ourTransform = transform;
            if (UnityEngine.Camera.main)
            {
                cameraTransform = UnityEngine.Camera.main.transform;
            }
        }

        void LateUpdate()
        {
            if (cameraTransform != null)
            {
                var pos = cameraTransform.position;
                pos.y = 0.0f;

                if (ourTransform.position != pos)
                {
                    ourTransform.rotation = Quaternion.identity;
                    ourTransform.position = pos;
                }
            }
            else
            {
                if (UnityEngine.Camera.main)
                {
                    cameraTransform = UnityEngine.Camera.main.transform;
                }
            }
        }
    }
}