using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField]
        private GameObject CannonballPrefab;

        private float InitialVelocity = 15f;
        private float MaxPitch = 25f;
        private float MaxAimDeviationAngle = 5f;
        private float CannonFireDistance = 10f;

        private float timeCannonsWereLastFired;
        private float cannonRechargeTime;
        private Collider[] firerColliders;
        private float maxRange = 1f;

        [SerializeField]
        private AudioClip[] cannonFireAudioClips;
        [SerializeField]
        private AudioSource cannonFireAudioSource;

        void Start()
        {
            maxRange = CalculateMaxRange();
            firerColliders = gameObject.GetComponentsInChildren<Collider>();
        }

        public void Fire(Vector3 dir)
        {
            var firingPitch = Mathf.Clamp01(CannonFireDistance / maxRange) * MaxPitch;

            if (CannonballPrefab != null)
            {
                var cannonball = Instantiate(CannonballPrefab, transform.position+dir*0.6f, transform.rotation) as GameObject;
                var entityId = gameObject.EntityId();
                cannonball.GetComponent<DestroyCannonball>().firerEntityId = entityId;
                EnsureCannonBallWillNotCollideWithFirer(cannonball);
                FireCannonball(cannonball, dir, firingPitch);
                cannonFireAudioSource.PlayOneShot(cannonFireAudioClips[Random.Range(0, cannonFireAudioClips.Length)]);
            }
        }

        private void FireCannonball(GameObject cannonball, Vector3 firingDirection, float firingPitch)
        {
            var cannonballRigidbody = cannonball.GetComponent<Rigidbody>();

            if (cannonballRigidbody != null)
            {
                var deviation = Vector2.zero;

                // Deviate the aim a little
                if (MaxAimDeviationAngle > 0f)
                {
                    deviation = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    deviation.Normalize();
                    deviation *= MaxAimDeviationAngle;
                }

                // Calculate the initial velocity
                var firingDir = Quaternion.LookRotation(firingDirection);
                cannonballRigidbody.velocity = (firingDir * Quaternion.Euler(-firingPitch + deviation.x, deviation.y, 0f)) * Vector3.forward * InitialVelocity;
            }
            else
            {
                Debug.LogWarning("The cannon ball is missing its rigidbody");
            }
        }

        private float CalculateMaxRange()
        {
            // Vertical velocity can be calculated using the pitch and initial full velocity:
            var velocity = Mathf.Sin(Mathf.Deg2Rad * MaxPitch) * InitialVelocity;

            // This is how long it will take the fired cannon ball to reach the sea level
            var time = -velocity / (0.5f * Physics.gravity.y);

            // Now let's calculate the distance traveled horizontally in the same amount of time
            return Mathf.Cos(Mathf.Deg2Rad * MaxPitch) * InitialVelocity * time;
        }

        private void EnsureCannonBallWillNotCollideWithFirer(GameObject cannonball)
        {
            if (firerColliders == null) return;
            var col = cannonball.GetComponent<Collider>();
            if (col == null) return;
            foreach (var c in firerColliders)
            {
                Physics.IgnoreCollision(c, col);
            }
        }
    }
}