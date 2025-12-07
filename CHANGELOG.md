All notable changes to this project will be documented in this file.

---

## [1.0.6] - 2025-12-07

### Added

- Added PlayMode and EditMode test coverage for WeatherManager.
- Added mock services (MockWeatherService, MockToastService) to support isolated testing.
- Added coroutine extension helper (`AsCoroutine()`) for testing async weather requests in PlayMode.

### Changed

- Improved test assembly definitions to correctly separate EditMode and PlayMode tests.
- Updated WeatherManager to better support test-time dependency injection.

### Fixed

- Fixed issues where tests appeared only in PlayMode due to incorrect asmdef references.
- Resolved missing namespace issues (`IEnumerator`) in PlayMode tests.
- Fixed mock toast service behavior by adding `LastMessage` property.

##[1.0.5] - 2025-12-07
###Changed

- Refactored ToastService to support platform-specific dependency injection (IToastService) instead of static calls.

- Added default toast implementations for Android, iOS, and Editor.

- Removed internal static instantiation of toast service from WeatherManager.

- WeatherManager now supports custom toast service injection.

- Fully SOLID-compliant toast architecture (Open/Closed & Dependency Inversion).

- WeatherManager initialization updated to allow SDK default config or app-provided services.

###Fixed

- Fixed toast service initialization to prevent null reference exceptions when showing messages.

- Ensured toast behavior works consistently across Editor, Android, and iOS.

## [1.0.4] - 2025-12-07

### Removed

- Removed Android Toast gravity to Top-Center behavior because this not work on modern android.

## [1.0.3] - 2025-12-07

### Added

- Android Location Permission Added.

## [1.0.2] - 2025-12-07

### Changed

- Updated Android Toast behavior to attempt Top-Center positioning (later removed in 1.0.4 due to OS restrictions).

## [1.0.1] - 2025-12-07

### Added

- Added a public helper method to show any custom toast message.

## [1.0.0] - 2025-12-06

### Added

- Initial release of the **CleverTap Weather Unity SDK**
- Weather API integration (Open-Meteo)
- Current temperature + today max temperature support
- JSON response models
- Android Toast native bridge
- iOS Snackbar native bridge
- Prefab demo object for triggering toast/snackbar
- Clean UPM-ready folder structure
- SOLID-based architecture
- Unit test examples
- Example Weather App usage
- Full README documentation
