import improbable.worldApps._
import improbable.corelibrary.transforms.TransformState
import improbable.corelibrary.transforms.global.GlobalTransformState
import improbable.dapi.LaunchConfig
import improbable.fapi.bridge._
import improbable.fapi.network.RakNetLinkSettings
import improbable.natures.Terrain
import improbable.unity.asset.PrefabContext
import improbable.unity.fabric.AuthoritativeEntityOnly
import improbable.unity.fabric.engine.EnginePlatform._
import improbable.unity.fabric.satisfiers.SatisfyVisual
import improbable.unity.fabric.engine.{DownloadableUnityConstraintToEngineDescriptorResolver, EnginePlatform}
import improbable.unity.fabric.satisfiers.SatisfyPhysics

object Settings {
  val appsToStart = Seq(classOf[ClientEntityLifeCycleManager], classOf[WorldInitialiser])
  val qosStates = Set(TransformState.componentId, GlobalTransformState.componentId)
  val streamingQueryPolicy = DistanceAndTagsStreamingQueryPolicy(2000, Set(Terrain.name))
}

object ManualEngineStartupLaunchConfig extends DefaultPirateLauncher(false)

object AutomaticEngineStartupLaunchConfig extends DefaultPirateLauncher(true)

class DefaultPirateLauncher(autoStartEngines: Boolean = true) extends LaunchConfig(
  Settings.appsToStart,
  autoStartEngines,
  PiratesBridgeSettingsResolver,
  DownloadableUnityConstraintToEngineDescriptorResolver
)

object PiratesBridgeSettingsResolver extends CompositeBridgeSettingsResolver(
  PiratesUnityClientBridgeSettings, PiratesUnityFSimBridgeSettings
)

object PiratesUnityClientBridgeSettings extends BridgeSettingsResolver {

  private def clientEngineBridgeSettings = BridgeSettings(
    AlwaysDefaultContextDiscriminator(),
    RakNetLinkSettings(),
    EnginePlatform.UNITY_CLIENT_ENGINE,
    SatisfyVisual,
    AuthoritativeEntityOnly(),
    ConstantEngineLoadPolicy(0.5),
    UnreliableForSomeClassesStateUpdateQos(Settings.qosStates),
    streamingQueryPolicy = Settings.streamingQueryPolicy
  )

  override def engineTypeToBridgeSettings(engineType: String, metadata: String): Option[BridgeSettings] = {
    engineType match {
      case UNITY_CLIENT_ENGINE =>
        Some(clientEngineBridgeSettings)
      case _ =>
        None
    }
  }
}

object PiratesUnityFSimBridgeSettings extends BridgeSettingsResolver {

  private def physicsEngineBridgeSettings = BridgeSettings(
    AlwaysDefaultContextDiscriminator(),
    RakNetLinkSettings(),
    EnginePlatform.UNITY_FSIM_ENGINE,
    SatisfyPhysics,
    AuthoritativeEntityOnly(),
    MetricsEngineLoadPolicy,
    UnreliableForSomeClassesStateUpdateQos(Settings.qosStates),
    streamingQueryPolicy = Settings.streamingQueryPolicy
  )

  override def engineTypeToBridgeSettings(engineType: String, metadata: String): Option[BridgeSettings] = {
    engineType match {
      case UNITY_FSIM_ENGINE =>
        Some(physicsEngineBridgeSettings)
      case _ =>
        None
    }
  }
}

case class AlwaysDefaultContextDiscriminator() extends AssetContextDiscriminator {
  override def assetContextForEntity(entity: EngineEntity): String = {
    PrefabContext.DEFAULT
  }
}
