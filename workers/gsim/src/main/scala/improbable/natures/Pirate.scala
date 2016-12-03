package improbable.natures

import improbable.corelib.natures.{BaseNature, NatureApplication, NatureDescription}
import improbable.corelibrary.transforms.TransformNature
import improbable.math.Vector3d
import improbable.papi.entity.EntityPrefab
import improbable.papi.entity.behaviour.EntityBehaviourDescriptor
import improbable.ship.PlayerControls

object Pirate extends NatureDescription {

  override val dependencies = Set[NatureDescription](BaseNature, TransformNature)

  override def activeBehaviours: Set[EntityBehaviourDescriptor] = {
    Set()
  }

  def apply(position: Vector3d): NatureApplication = {
    application(
      states = Seq(
        PlayerControls(targetSpeed = 0, targetSteering = 0)
      ),
      natures = Seq(
        BaseNature(EntityPrefab("PirateShip")),
        TransformNature(globalPosition = position)
      )
    )
  }
}