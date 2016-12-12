using System;
using Improbable.General;
using Improbable.Math;
using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // This MonoBehaviour will be enabled on both client and server-side workers
    public class ShipMovement : MonoBehaviour
    {
        /* 
         * An entity with this MonoBehaviour will have it enabled only for the single worker (whether client or FSim)
         * which has write-access for its WorldTransform component.
         */
        [Require] private WorldTransform.Writer WorldTransformWriter;

        public float MovementSpeed = 7;
        public float TurningSpeed = 50;

        private ShipController shipController;

        public void OnEnable()
        {
            shipController = GetComponent<ShipController>();

            // Initialize entity's gameobject transform from WorldTransform component values
            transform.position = WorldTransformWriter.Data.position.ToVector3();
            transform.rotation = Quaternion.Euler(0.0f, WorldTransformWriter.Data.rotation, 0.0f);
        }

        public void Update ()
        {
            // Move ship using local steering values
            if (shipController != null)
            {
                var delta = Time.deltaTime;
                transform.rotation = transform.rotation*
                                     Quaternion.Euler(0f, shipController.currentSteering*delta*TurningSpeed, 0f);
                transform.position = transform.position +
                                     transform.localRotation*Vector3.forward*(shipController.currentSpeed*delta*MovementSpeed);

                // Synchronise transform across all workers
                WorldTransformWriter.Send(new WorldTransform.Update().SetPosition(transform.position.ToCoordinates())
                                                                     .SetRotation((uint)transform.rotation.eulerAngles.y));
            }
        }
    }

    public static class Vector3Extensions
    {
        public static Coordinates ToCoordinates(this Vector3 vector3)
        {
            return new Coordinates(vector3.x, vector3.y, vector3.z);
        }
    }
}
