package improbable.worldApps

import improbable.math.Vector3d
import improbable.natures.Terrain
import improbable.papi.world.AppWorld
import improbable.papi.worldapp.WorldApp

class WorldInitialiser(world: AppWorld) extends WorldApp {

  // Code here will be run when the simulation starts.
  world.entities.spawnEntity(Terrain(Vector3d.zero))

}
