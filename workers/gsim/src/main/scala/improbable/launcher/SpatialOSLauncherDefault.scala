package improbable.launcher

import scala.sys.process._

object SpatialOSLauncherDefault extends App {
  "spatial build gsim".!
  "spatial local start default_launch.pb.json".!
}