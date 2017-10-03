using Improbable;
using Improbable.Core;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Improbable.Worker;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on both client and server-side workers
    public class TransformReceiver : MonoBehaviour
    {
        // Inject access to the entity's Position and Rotation components
        [Require] private Position.Reader PositionReader;
        [Require] private Rotation.Reader RotationReader;

        void OnEnable()
        {
            // Initialize entity's gameobject transform from Position and Rotation component values
            transform.position = PositionReader.Data.coords.ToUnityVector();
            transform.rotation = Quaternion.Euler(0.0f, RotationReader.Data.rotation, 0.0f);

            // Register callback for when component changes
            PositionReader.ComponentUpdated.Add(OnPositionUpdated);
            RotationReader.ComponentUpdated.Add(OnRotationUpdated);
        }

        void OnDisable()
        {
            // Deregister callback for when component changes
            PositionReader.ComponentUpdated.Remove(OnPositionUpdated);
            RotationReader.ComponentUpdated.Remove(OnRotationUpdated);
        }

        // Callback for whenever one or more property of the Position standard library component is updated
        void OnPositionUpdated(Position.Update update)
        {
            /*
             * Only update the transform if this component is on a worker which isn't authorative over the
             * entity's Position standard library component.
             * This synchronises the entity's local representation on the worker with that of the entity on
             * whichever worker is authoritative over its Position and is responsible for its movement.
             */
			if (PositionReader.Authority == Authority.NotAuthoritative)
            {
                if (update.coords.HasValue)
                {
                    transform.position = update.coords.Value.ToUnityVector();
                }
            }
        }

        // Callback for whenever one or more property of the Rotation component is updated
        void OnRotationUpdated(Rotation.Update update)
        {
            /*
             * Only update the transform if this component is on a worker which isn't authorative over the
             * entity's Rotation component.
             * This synchronises the entity's local representation on the worker with that of the entity on
             * whichever worker is authoritative over its Rotation and is responsible for its movement.
             */
			if (RotationReader.Authority == Authority.NotAuthoritative)
            {
                if (update.rotation.HasValue)
                {
                    transform.rotation = Quaternion.Euler(0.0f, update.rotation.Value, 0.0f);
                }
            }
        }
    }
}
