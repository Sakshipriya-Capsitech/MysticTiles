# **Mystic Tiles**

Mystic Tiles is a Unity-based 3D endless platformer game where players jump across colored tiles by pressing the correct buttons. The goal is to score as high as possible without falling.

## **Gameplay**

Platforms are colored Big Pink or Big Turquoise.

Players must press the Pink or Green button to jump on the corresponding tile.

Jumping on the correct tile scores 1 point.

Jumping on the wrong tile or falling off the platform ends the game.

Platforms fall shortly after the player lands on them.

🕹 Controls
Action	Input
Jump on Pink Tile	Press Pink Button
Jump on Green Tile	Press Green Button
Restart Game	Click Restart Button after Game Over
Exit Game	Click Exit Button

### **Controls**

Here’s an overview of the main scripts and their functionality:

Script	Purpose
GameManager.cs	Handles game state, scoring, high score, start, restart, and exit functions.
PlayerController.cs	Handles player input, jumping mechanics, collision detection, and idle/game-over logic.
CameraFollow.cs	Smoothly follows the player with an offset and rotates toward the player.
PlatformSpawner.cs	Spawns platforms ahead of the player and removes old ones.
PlatformTile.cs	Controls individual platform behavior, color assignment, and falling animation.
StartGame.cs	Loads the main game scene.
QuitGame.cs	Exits the game.

**⚡ Features**

- Smooth camera follow with rotation using Lerp and Slerp.
- Platform spawning system with automatic removal of old platforms.
- Colored platforms with random assignment each game.
- Jumping animations using DOTween (DOJump).
- High score saving using PlayerPrefs.
- Simple UI with score, high score, start, restart, and exit buttons.

**🛠 Installation & Setup**

1. Clone the repository:
git clone https://github.com/your-username/mystic-tiles.git

**📸 Game Preview**

<img width="1052" height="535" alt="Screenshot 2025-10-30 142643" src="https://github.com/user-attachments/assets/25b5c8ba-a7b2-47e2-ab3b-415f2457671b" />
<img width="916" height="532" alt="Screenshot 2025-10-30 142708" src="https://github.com/user-attachments/assets/11d807be-f94a-43a1-b43b-19ce31d99cc6" />
<img width="565" height="435" alt="Screenshot 2025-10-30 142741" src="https://github.com/user-attachments/assets/b48ff6a2-5387-4a74-adb4-178d00fecbcd" />


