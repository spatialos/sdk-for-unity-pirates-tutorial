using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class CannonFirer : MonoBehaviour
    {
        private Cannon cannon;

        private void Start()
        {
            cannon = gameObject.GetComponent<Cannon>();
        }

        private void OnEnable()
        {
            // Register your callbacks in OnEnable.
        }

        private void FireCannons(Vector3 direction)
        {
            if (cannon != null)
            {
                cannon.Fire(direction);
            }
        }

        private void OnDisable()
        {
            // De-register your callbacks in OnDisable.
        }
    }
}