# Slide Maze Escape

A command-line sliding maze puzzle game built with **F# / .NET 10**.

The player moves through an 8x8 maze using `W`, `A`, `S`, and `D`.
Unlike normal movement games, the player keeps sliding in the chosen direction until a wall or boundary blocks the movement.
The goal is to reach the exit by choosing directions carefully.

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)  
  Verify with: `dotnet --version` (should show `10.x.x`)
  The version should start with `10`.

### Run

From the project root directory, run:

```bash
dotnet run
```

### Build

```bash
dotnet build
```

---

## How to Play

### Map Selection

When the game starts, the player selects one of three maps:

```
1. Basic Slide Maze (Easy)
2. Twisted Slide Maze (Medium)
3. Tight Slide Maze (Hard)

Q. Quit
```

Enter `1`, `2`, or `3` to choose a map.

You can also enter `Q` from the map selection screen to quit the game.

### Maze Layout

The game displays an 8x8 maze in the terminal.

- `P` represents the player.
- `E` represents the exit.
- `|` and `---` represent walls.
- The player starts outside the maze, below the bottom row.
- The exit is outside the maze, above the top row.
- The entrance and exit are shown as openings in the outer maze boundary.

### Controls

| Key | Action |
|-----|--------|
| `W` | Slide up |
| `A` | Slide left |
| `S` | Slide down |
| `D` | Slide right |
| `R` | Restart the current map |
| `M` | Return to map selection |
| `Q` | Quit the game |

The controls are case-insensitive, so lowercase inputs such as `w`, `a`, `s`, `d`, `r`, `m`, and `q` are also accepted.

### Movement Rule

When the player enters a movement command, the player does not move by only one tile.

Instead, the player keeps sliding in that direction until:

1. a wall blocks the next tile,
2. the boundary of the maze blocks movement, or
3. the player reaches the exit.

After sliding, the player stops on the last reachable tile.

If the player is already blocked in the chosen direction, the player stays in the same position and the maze is displayed again.

After each valid movement input, the game updates the player position and displays the updated maze in the terminal. If the movement is blocked immediately, the position does not change, but the maze is still displayed again.

### Invalid Input

If the player enters an input other than the valid commands (W, A, S, D, R, M, and Q), the game displays an error message and asks for another input.

The player position does not change after invalid input.

---

## Example

When the game starts, the map selection screen is displayed in the terminal:

```
Slide Maze Escape

Select a map:

1. Basic Slide Maze (Easy)
2. Twisted Slide Maze (Medium)
3. Tight Slide Maze (Hard)

Q. Quit

Enter 1, 2, 3, or Q: 1
```

After selecting a map, the maze is displayed in the terminal:

```
Slide Maze Escape
Map: Basic Slide Maze (Easy)
Controls: W/A/S/D = move, R = restart, M = map select, Q = quit

                          E
+---+---+---+---+---+---+   +---+
|                               |
+   +   +   +   +   +   +   +---+
|                               |
+   +---+---+---+   +   +   +   +
|                       |       |
+   +   +   +   +   +   +   +   +
|                   |           |
+   +   +   +---+---+   +   +   +
|                           |   |
+   +   +   +   +   +   +   +   +
|                               |
+---+---+   +   +   +   +   +   +
|               |               |
+   +   +   +   +   +---+   +---+
|               |               |
+---+---+   +---+---+---+---+---+
          P

Enter command: W
```

If the player reaches the exit, the game displays a win message in the terminal:

```
You reached the exit. You win!
```

Afther a short delay (1.5s), the game returns to the map selection screen.

---

## Project Structure

```
20230335_Gaeun_Seo_CS20200_Term_Project/
├── .gitignore
├── README.md
├── SlideMazeEscape.fsproj
└── SlideMazeEscape/
    ├── Types.fs        # Shared types such as Position, Direction, MazeMap, and GameState
    ├── Maze.fs         # Maze size, start/exit positions, wall data, and map definitions
    ├── Game.fs         # Movement logic, sliding behavior, input parsing, and win checking
    ├── Render.fs       # Terminal rendering for the maze, walls, player, and exit
    └── Program.fs      # Entry point, map selection, and main game loop
```

### File Overview

| File | Responsibility |
|------|----------------|
| `Types.fs` | Defines shared data types such as `Position`, `Direction`, `MazeMap`, and `GameState` |
| `Maze.fs` | Stores maze size, start and exit positions, wall data, map definitions, and initial state creation |
| `Game.fs` | Handles movement logic, sliding behavior, input parsing, restart checking, and win checking |
| `Render.fs` | Prints the maze, player, exit, walls, entrance, and exit opening in the terminal |
| `Program.fs` | Runs the map selection screen and main gameplay loop |

### Key Types

```fsharp
type Position = {
    Row: int
    Col: int
}

type Direction =
    | Up
    | Left
    | Down
    | Right

type MazeMap = {
    Name: string
    Difficulty: string
    Walls: (Position * Position) list
}

type GameState = {
    Player: Position
    Start: Position
    Exit: Position
    Map: MazeMap
}
```

---

## Requirement Changes

The original requirements document described a single 8x8 sliding maze. In the final implementation, I added two additional 8x8 maps and a map selection screen at the beginning of the game.

The original requirements specified `W`, `A`, `S`, and `D` for movement and `R` for restart. In the final implementation, I also added `Q` as an optional quit command. This was added as a convenience feature so that the player can close the game without having to reach the exit.

I also added `M` as an optional command to return to the map selection screen. This allows the player to choose a different map during gameplay.

When the player clears a map, the game now returns to the map selection screen after briefly displaying the win message. This was added because the final implementation contains multiple maps.

In the original requirements document, the player and exit were displayed outside the maze but visually aligned with the outer maze boundary. In the final implementation, I adjusted the rendering to make it clearer that the player and exit are outside the maze. As part of this change, the boundary segments directly in front of the entrance and exit are rendered as openings.

These changes preserve the original core gameplay rules: the player still moves with `W`, `A`, `S`, and `D`, slides until blocked by a wall or boundary, can restart with `R`, and wins by reaching the exit.

---

## Rules Summary

- The game is played in the terminal.
- The game uses an 8x8 maze.
- The player starts outside the maze, below the bottom row.
- The exit is outside the maze, above the top row.
- The player selects one of three maps before playing.
- The three maps have easy, medium, and hard difficulty levels.
- The player moves with `W`, `A`, `S`, and `D`.
- Movement commands are case-insensitive.
- After each valid movement input, the maze is displayed again.
- When the player moves, the player slides continuously in that direction.
- The player stops only when a wall, boundary, or exit prevents further sliding.
- `R` restarts the current map.
- `M` returns to the map selection screen.
- `Q` quits the game.
- Invalid input does not move the player.
- If the player is immediately blocked in the chosen direction, the player stays in the same position.
- The player wins by reaching the exit.
- After winning, the game returns to the map selection screen after a short delay.

---

## LLM Usage

I used a large language model while developing this project.

First, I used the LLM to get ideas for how to organize the code into multiple files. The initial implementation could have been written in a single file, but I wanted the project structure to be more readable. The LLM helped me decide to separate the code into files such as `Types.fs`, `Maze.fs`, `Game.fs`, `Render.fs`, and `Program.fs`.

Second, I used the LLM to get guidance after changing the project from a single-map game to a game with three selectable maps. I asked which files needed to be modified, which parts of the code should change, and what direction the changes should follow. Based on this, I updated the map data structure, added multiple map definitions, and implemented the map selection flow.

Third, I used the LLM to get ideas for how to place the player and the exit outside the maze. The original implementation placed them inside the 8x8 grid, but I wanted the player to start below the maze and the exit to appear above the maze. The LLM helped me revise the position representation and rendering logic for this design.

Overall, the LLM provided useful guidance for most of my requests. I used it to get suggestions and partial code examples for the tasks described above.

One issue that required an additional prompt was an F# type inference error. Some records using fields such as `Row` and `Col` needed explicit type annotations like `Position` and `GameState` because F# could not infer the exact record type.