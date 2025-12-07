# CleverTap Weather Unity SDK

The **CleverTap Weather Unity SDK** provides a clean, modular, UPM-ready Unity package that allows developers to:

- Retrieve **current temperature** of the user’s location using the **Open-Meteo Weather API**
- Display system-native **Toast (Android)** or **Snackbar (iOS)** messages through an exposed GameObject
- Integrate weather information into any Unity scene with minimal setup
- Follow SOLID principles using a service-driven architecture

This SDK is built for the CleverTap Unity Developer Assignment.

---

## Features

### Weather

- Fetch **current temperature** using latitude + longitude
- Fetch **today's max temperature** using latitude + longitude
- Clean JSON models
- Async API calls
- Interface-driven (`IWeatherService`, `IToastService` )

### Platform UI

- GameObject that triggers:
  - **Android Toast**
  - **iOS Snackbar**
- Simple interaction: attach → click → show message

### Architecture

- Follows **SOLID principles**
- Service-based dependency injection
- Clean UPM package folder structure

---

# Installation (Unity UPM)

Add this line to your project's `manifest.json`:

```json
"com.clevertap.weather": "https://github.com/Mohamedhazeem/CleverTap-Weather-Unity-SDK.git"
```
