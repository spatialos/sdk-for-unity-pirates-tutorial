using Improbable.Ship;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Enable this MonoBehaviour on client workers only
    [EngineType(EnginePlatform.Client)]
    public class PlayerInputController : MonoBehaviour
    {
        /* 
         * Client will only have write-access for their own designated PlayerShip entity's ShipControls component,
         * so this MonoBehaviour will be enabled on the client's designated PlayerShip GameObject only and not on
         * the GameObject of other players' ships.
         */
        [Require] private ShipControls.Writer ShipControlsWriter;

        void Update ()
        {
            ShipControlsWriter.Send(new ShipControls.Update()
                .SetTargetSpeed(Mathf.Clamp01(Input.GetAxis("Vertical")))
                .SetTargetSteering(Input.GetAxis("Horizontal")));
        }
    }
}
