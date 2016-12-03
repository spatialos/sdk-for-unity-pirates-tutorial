package improbable.behaviours

import improbable.corelib.util.EntityOwner
import improbable.papi.entity.{Entity, EntityBehaviour}
import improbable.ship.PlayerControls
import improbable.unity.papi.SpecificEngineConstraint

class DelegatePlayerControlsToClient(entity: Entity) extends EntityBehaviour {

  private val clientId = entity.watch[EntityOwner].ownerId

  override def onReady(): Unit = {
    entity.delegateState[PlayerControls](SpecificEngineConstraint(clientId.get.get))
  }
}
