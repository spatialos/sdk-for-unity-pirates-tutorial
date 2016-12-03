package improbable.utils

import improbable.flagz.{FlagContainer, FlagInfo, ScalaFlagz}
import improbable.math.Vector3d

object SpawnerParameters extends FlagContainer {

  @FlagInfo(name = "pirates_max_ships", help = "The total number of pirate ships to be spawned")
  final val MAX_SHIPS = ScalaFlagz.valueOf(50)

}

object SpawnerUtils {

  // The distance between ships when they spawn.
  final val DISTANCE_BETWEEN_SHIPS = 20

  // The scale factor increases with each iteration of the spiral in order
  // to expand the distance between ships as they spawn further away
  // from the center of the spiral.
  final val SCALE_FACTOR_RATE = 0.1

  // Utility method to get the position of an entity in a spiral.
  // A modified method based on the algorithm from: http://stackoverflow.com/a/3706260/2669714
  def getSpiralSpawnPosition(shipIndex: Int, shipDistance : Int): Vector3d = {

    var spawnPositionX = 0 // world x-coordinate
    var spawnPositionZ = 0 // world z-coordinate

    var spawnVector = Tuple2(1, 0) // vector of the direction of spawning

    var segmentIndex = 0 // index along line segment
    var segmentLength = 1 // length of line segment

    // offsets the spawning position by a given factor
    // to make ships spawn further from each other
    // as we get further away from the center of the spiral
    var spawnDistanceScaleFactor = 1.0

    for (i <- 0 to shipIndex) {

      spawnPositionX += (spawnVector._1 * shipDistance)
      spawnPositionZ += (spawnVector._2 * shipDistance)
      segmentIndex += 1

      if (segmentIndex == segmentLength) {

        // line segment completed, rotate the direction by 90 degrees
        spawnVector = Tuple2(-spawnVector._2, spawnVector._1)

        if (spawnVector._2 == 0) {
          // increment segment length when spawnVector indicates we are
          // spawning horizontally in the x-axis
          segmentLength += 1
        }

        // reset the segment index
        segmentIndex = 0

        // increment the scaling factor
        spawnDistanceScaleFactor += SCALE_FACTOR_RATE
      }
    }

    return Vector3d(spawnDistanceScaleFactor * spawnPositionX, 0, spawnDistanceScaleFactor * spawnPositionZ)
  }
}
