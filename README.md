Convai

 # No-Code Convai Training Scene Editor (Unity WebGL)

This is a no-code training scene editor built in Unity 2022.3 LTS using URP and deployed for WebGL. It features runtime NPC spawning, persona assignment, in-world UI, and voice-based interaction using Convai.

## 🚀 Run Instructions

1. Open in Unity 2022.3.32f1 LTS
   - Uses URP and Addressables
2. Press Play in `MainScene.unity`
   - Use UI buttons to spawn NPCs
   - Click in the scene to place them
   - Assign persona (Cia/Aira) via floating selector
   - Talk using mic via built-in Convai Player Character

3. WebGL Build
   - Go to `File > Build Settings > WebGL > Build`
   - Ensure `IL2CPP`, Brotli compression, and 1024MB memory are enabled

## 🏗️ Architecture Overview

### 🎮 Runtime Features

| Feature                  | Tech Used                       |
|--------------------------|----------------------------------|
| Add/Remove NPCs          | World-space button UI + pooling |
| Convai Integration       | ConvaiNPC SDK + Character IDs   |
| Persona Selection        | Floating Canvas per NPC         |
| Drag & Drop Reposition   | Plane-raycasting + Lerp motion  |
| Dialogue Display         | `ConvaiNPC.onFinalResponse` hook|
| Addressable Loading      | Dynamic prefab spawning          |

### 🧠 System Structure

- NPCManager.cs         → Handles spawn, selection, and UI
- PersonaSelector.cs    → Floating selector + persona switcher
- ConvaiNPC.cs          → Handles voice + character response
- UIManager.cs          → Static UI button logic

## 🧪 Optimizations Applied (WebGL)

| Optimization                    | Result                               |
|----------------------------------|----------------------------------------|
| ✅ IL2CPP + Engine Stripping    | Smaller build size (~20% reduction)    |
| ✅ Crunch Texture Compression   | 50–70% smaller textures                |
| ✅ MP3 Audio Compression        | ~5x smaller audio size                 |
| ✅ Baked Lighting               | Zero GPU cost at runtime               |
| ✅ Shader Stripping             | Removed ~100+ shader variants          |
| ✅ Object Pooling for NPCs      | Eliminated GC spikes during spawn      |
| ✅ Addressables                 | Lazy-load large assets only when needed|

## 🌍 External Environments & APIs Used

- 🧠 Convai SDK
  - Real-time voice-to-character interaction
  - Used Convai Character IDs for “Cia” and “Aira”

- 🏙️ Unity URP Sample - Terminal Environment
  - Used for 3D background environment
  - Static and lightmap-baked

## 🧱 Challenges Faced

1. Reallusion Character Import
   - Imported characters had black textures and unlit shading
   - Fixed by converting materials to URP/Lit and simplifying hierarchies

2. Precise Repositioning on Drag
   - Z-axis overdrag issues when moving NPC toward the camera
   - Solved via `Plane.Raycast()` + XZ-clamped Lerp motion

## 🔮 Next Steps (Possible Extensions)

- 🔁 Undo/Redo system for NPC actions
- 💾 Save/Load scene state via JSON
- 🧩 Snap-to-grid or navmesh-aware placement
- 📦 Further GPU batching of static scene props
- 📱 Mobile WebGL variant with touch UI

## 🧑‍💻 Developer

- Vishal Dhiman
- XR | Unity | AR/VR | Lead Developer
