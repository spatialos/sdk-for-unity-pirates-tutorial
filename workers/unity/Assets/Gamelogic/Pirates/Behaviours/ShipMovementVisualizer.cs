using Improbable.Corelibrary.Transforms;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    public class ShipMovementVisualizer : MonoBehaviour
    {
        [Require] protected TransformStateWriter TransformStateCheck;

        public float MovementSpeed = 7;
        public float TurningSpeed = 50;

        private ShipController shipController;

        public void OnEnable() {
            shipController = GetComponent<ShipController>();
        }
	
        public void Update () {
            var delta = Time.deltaTime;
            transform.rotation = transform.rotation*Quaternion.Euler(0f, shipController.Steering*delta*TurningSpeed, 0f);
            transform.position = transform.position +
                                 transform.localRotation*Vector3.forward*(shipController.Speed*delta*MovementSpeed);
        }
    }
}
