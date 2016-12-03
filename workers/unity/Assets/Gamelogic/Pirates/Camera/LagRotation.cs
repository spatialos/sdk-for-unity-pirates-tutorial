using UnityEngine;

namespace Assets.Gamelogic.Pirates.Camera
{
    public class LagRotation : MonoBehaviour
    {
        public float Speed = 10f;

        Transform ourTransform;
        Transform ourParent;
        Quaternion ourLocalRotation;
        Quaternion ourParentsRotation;

        void Start()
        {
            ourTransform = transform;
            ourParent = ourTransform.parent;
            ourLocalRotation = ourTransform.localRotation;
            ourParentsRotation = ourParent.rotation;
        }

        void LateUpdate()
        {
            ourParentsRotation = Quaternion.Slerp(ourParentsRotation, ourParent.rotation, Time.deltaTime * Speed);
            ourTransform.rotation = ourParentsRotation * ourLocalRotation;
        }
    }
}