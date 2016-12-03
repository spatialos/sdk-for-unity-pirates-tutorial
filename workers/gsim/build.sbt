lazy val rootProject = SpatialOSBuild.root.settings(
  libraryDependencies += "improbable" %% "corelibrary" % SpatialOSBuild.improbableVersion
)
