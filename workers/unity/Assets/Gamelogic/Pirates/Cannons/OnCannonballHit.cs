using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class OnCannonballHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Cannonball")
            {
                // Update HitByCannonball's state event here!
            }
        }
    }
}