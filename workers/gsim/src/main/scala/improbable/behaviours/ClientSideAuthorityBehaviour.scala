package improbable.behaviours

import improbable.corelibrary.transforms.TransformInterface
import improbable.papi.entity.EntityBehaviour

class ClientSideAuthorityBehaviour(transformInterface: TransformInterface) extends EntityBehaviour  {

  override def onReady(): Unit = {
    transformInterface.delegatePhysicsToClientOwner()
  }
}