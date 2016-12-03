package improbable.worldApps

import improbable.logging.Logger
import improbable.natures.Player
import improbable.papi._
import improbable.papi.engine.EngineId
import improbable.papi.world.AppWorld
import improbable.papi.world.messaging.{EngineConnected, EngineDisconnected}
import improbable.papi.worldapp.{WorldApp, WorldAppLifecycle}
import improbable.unity.fabric.engine.EnginePlatform

class ClientEntityLifeCycleManager(appWorld: AppWorld, logger: Logger, lifecycle: WorldAppLifecycle) extends WorldApp {

  private var clientIdToEntityIdMap = Map[EngineId, EntityId]()

  appWorld.messaging.subscribe {
    case msg: EngineConnected =>
      workerConnected(msg)
    case msg: EngineDisconnected =>
      workerDisconnected(msg)
  }

  private def workerConnected(msg: EngineConnected): Unit = {
    msg match {
      case EngineConnected(userId, EnginePlatform.UNITY_CLIENT_ENGINE, _) =>
        spawnPlayer(userId)
      case _ =>
    }
  }

  private def spawnPlayer(clientId: EngineId): Unit = {
    val playerEntityId = appWorld.entities.spawnEntity(Player(clientId))
    logger.info(s"Spawning Player with clientId $clientId and entityId $playerEntityId")
    clientIdToEntityIdMap += clientId -> playerEntityId
  }

  private def workerDisconnected(msg: EngineDisconnected): Unit = {
    msg match {
      case EngineDisconnected(userId, EnginePlatform.UNITY_CLIENT_ENGINE) =>
        deletePlayer(userId)
      case _ =>
    }
  }

  private def deletePlayer(clientId: EngineId) = {
    clientIdToEntityIdMap.get(clientId) match {
      case Some(id) =>
        appWorld.entities.destroyEntity(id)
        logger.info(s"Destroying player: $clientId with entityId $id")
        clientIdToEntityIdMap -= clientId
      case None =>
        logger.warn(s"Worker disconnected but could not find entity id for player: $clientId")
    }
  }
}
