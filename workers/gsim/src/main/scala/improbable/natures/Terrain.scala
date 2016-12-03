package improbable.natures

import improbable.corelib.natures.{BaseNature, NatureApplication, NatureDescription}
import improbable.corelibrary.transforms.TransformNature
import improbable.math.Vector3d
import improbable.papi.entity.EntityPrefab
import improbable.papi.entity.behaviour.EntityBehaviourDescriptor

object Terrain extends NatureDescription {

  override val dependencies = Set[NatureDescription](BaseNature, TransformNature)

  override def activeBehaviours: Set[EntityBehaviourDescriptor] = Set.empty

  def apply(position: Vector3d): NatureApplication = {
    application(
      states = Seq.empty,
      natures = Seq(
        BaseNature(EntityPrefab("Terrain")),
        TransformNature(position)
      )
    )
  }
}
