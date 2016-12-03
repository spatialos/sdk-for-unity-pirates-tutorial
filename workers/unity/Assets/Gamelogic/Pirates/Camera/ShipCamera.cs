using Assets.Gamelogic.Pirates.Behaviours;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Camera
{
    public class ShipCamera : MonoBehaviour
    {
        public ShipController Control;
        public AnimationCurve Distance;
        public AnimationCurve Angle;

        private Transform ourTransform;

        void Start ()
        {
            ourTransform = transform;
        }

        void Update ()
        {
            if (Control != null)
            {
                var speed = Control.Speed;
                var rot = Quaternion.Euler(Angle.Evaluate(speed), 0f, 0f);
                ourTransform.localPosition = rot * Vector3.back * Distance.Evaluate(speed);
                ourTransform.localRotation = rot;
            }
        }
    }
}