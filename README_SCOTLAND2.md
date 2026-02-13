Scotland2-ready modifications

What was added:
- app/src/main/cpp/libmoxxie.cpp : native loader entry exporting setup/load/JNI_OnLoad
- app/src/main/cpp/CMakeLists.txt : CMakeLists for building libmoxxie.so via NDK
- app/build.gradle : (attempted) edits to enable externalNativeBuild CMake integration and abiFilters (arm64-v8a)
- PCMod/ : example PC plugin using BepInEx IL2CPP-style skeleton (Plugin.cs + PCMod.csproj)
- .github/workflows/build-so.yml : builds libmoxxie.so (NDK via Gradle or CMake) and uploads artifact
- .github/workflows/build-windows-sml2.yml : builds PC plugin DLL on windows-latest

Notes:
- The PC plugin project references placeholder 'libs' paths in the csproj. Adjust HintPath or provide reference assemblies in CI.
- The gradle edits were applied if an app/build.gradle was found; please review manually to ensure no conflicts with existing native build config.
- Push to repo and run the 'Build libmoxxie.so' workflow to produce the .so artifact.
- If you want I can prepare a PR instead of a zip.

