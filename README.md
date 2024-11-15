# Game Development Scripts

This repository contains a collection of C# scripts used for creating various functionalities in a game developed using Unity. Below is a brief overview of each script and its purpose:

## Files and Descriptions

### `Bullet.cs`
- **Purpose**: Manages the behavior of bullets fired by the player or enemies.
- **Features**: Includes collision detection and damage calculations.

### `CameraController.cs`
- **Purpose**: Controls the main camera movement to follow the player or focus points in the game.
- **Features**: Smooth transitions and adjustments to camera angles.

### `Enemy.cs`
- **Purpose**: Defines the basic behavior and attributes of an enemy in the game.
- **Features**: Movement, attack patterns, and interaction with the player.

### `EnemyBossMovement.cs`
- **Purpose**: Controls the movement patterns specifically for boss-type enemies.
- **Features**: Complex movement algorithms to challenge the player.

### `EnemyHealth.cs`
- **Purpose**: Manages the health of enemies, handling damage intake and death.
- **Features**: Damage response, health bar updates, and enemy despawn.

### `EnemySpawner.cs`
- **Purpose**: Manages the spawning of enemies at various points and times.
- **Features**: Configurable spawn rates and locations.

### `GameResult.cs`
- **Purpose**: Handles the end-of-game logic, calculating and displaying results.
- **Features**: Score tallying, win/lose determination, and UI display.

### `InfoBtn.cs`
- **Purpose**: Manages interactions with information buttons on the UI.
- **Features**: Displays tooltips or additional game details when clicked.

### `ItemCollector.cs`
- **Purpose**: Manages player interactions with collectible items in the game.
- **Features**: Item pickup and inventory updates.

### `LevelComplete.cs`
- **Purpose**: Manages the logic and UI updates when a level is completed.
- **Features**: Transition to next level or replay options.

### `ObjectMovement.cs`
- **Purpose**: Handles the movement of objects within the game world.
- **Features**: Allows translation and rotation of game objects.

### `OneMinuteTimers.cs`
- **Purpose**: Implements timers that count down from one minute for game events.
- **Features**: Can trigger events when the timer reaches zero.

### `PlayerAttacking.cs`
- **Purpose**: Manages the attacking mechanics of the player character.
- **Features**: Includes methods for initiating attacks and handling attack animations.

### `PlayerLife.cs`
- **Purpose**: Manages the player's health and life status in the game.
- **Features**: Provides functions to decrease health, handle player death, and respawn.

### `PlayerMovement.cs`
- **Purpose**: Controls the player's movement in the game environment.
- **Features**: Supports walking, running, jumping, and crouching.

### `SpawnPoints.cs`
- **Purpose**: Defines spawn points for players or objects in the game.
- **Features**: Allows dynamic setting of spawn locations.

### `StartMenu.cs`
- **Purpose**: Manages the start menu interface.
- **Features**: Includes functionalities to start the game, access settings, and quit the game.

## Installation

1. Ensure you have [Unity](https://unity.com/) installed.
2. Clone this repository into your Unity project's `Assets/Scripts` directory.
3. Attach the scripts to the appropriate game objects in your Unity scene.

