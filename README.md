# Fifteen Puzzle Game (C# Console Application)

## Description
This project is a console-based implementation of the classic Fifteen Puzzle game. The game consists of a grid of numbered tiles with one empty space. The objective is to arrange the tiles in numerical order by moving them into the empty space.

## Features
- Supports grid sizes from **3×3 to 9×9**
- Allows valid tile movements (up, down, left, right) if adjacent to the empty space
- Detects when the puzzle is solved
- Displays the board state in a formatted layout

## Technologies Used
- **C#** for core logic
- **Console Application** for user interaction
- **2D Array** for board representation

## Key Methods
- `init()` - Initializes the board with numbered tiles
- `draw()` - Prints the current board state
- `move(int tile)` - Moves the specified tile if possible
- `won()` - Checks if the puzzle is solved
- `greet()` - Displays a welcome message
