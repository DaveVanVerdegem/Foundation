# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Added Toolbar method to spawn AxialGizmo helper.

### Changed

- Moved CreateFacade method to a new Toolbar class to bundle all toolbar methods.

## [0.1.9] - 2022-06-07

### Added

- Added methods to remove Hexagon tiles from HexagonGrid.
- Added float extension to detect its sign.

### Changed

- Made size property of Hexagon public.

## [0.1.8] - 2022-06-01

### Added

- Added Vector2 and Vector3 extensions to adjust x, y or z-values.
- Added Vector2 and Vector3 extensions to get direction to position.
- Added Vector3 extension to flatten a Vector3.
- Added Vector3 extension to get a flat distance.
- Added Vector3 extensions to get the nearest points on an axis or line direction.
- Added Transform extension to look at position around the Y-axis.
- Added Shuffle modifier List extension.
- Added Int extension to randomize its sign.

### Changed

- Added exceptions to Random List extensions.

## [0.1.7] - 2022-05-30

### Fixed

- Fixed missing static method for average calculations with vectors.

## [0.1.6] - 2022-05-30

### Added

- Added Vector2 and Vector3 extensions get average of list of vectors.

## [0.1.5] - 2022-05-25

### Added

- Added One Minus float extension to do one minus (1-x) operations.
- Added Random List extension that takes excluded items as a parameter.

## [0.1.4] - 2022-05-03

### Fixed

- Fixed missing Type parameter in AddUnique list extension.

## [0.1.3] - 2022-04-30

### Added

- Added list extension to add unique items to lists.

## [0.1.2] - 2022-04-29

### Added

- Added tool to create Facade file in Editor.

### Fixed

- Added .meta files for markdown files.

## [0.1.1] - 2022-04-26

### Added

- Changelog file (this)

### Fixed

- Added .md-extension to LICENSE.

### Removed

- Removed Facade pattern. Should be implemented as a tool in the future.

## [0.1.0] - 2022-03-23

### Added

- Extension methods for Floats.
- Extension methods for Int.
- Extension methods for Lists.
- Extension methods for Vector2s.
- Extension methods for Vector2Ints.
- Extension methods for Vector3s.
- Hexagonal grids.
- Maths angle calculator.
- A-star Pathfinding.
- Singleton pattern.
- Facade pattern template.