# Maze

Maze generator and solver that use backtracking.

## How to Use

### Maze Generator

```cs
MazeGenerator mazeGenerator = new MazeGenerator(new Size(100, 100));
mazeGenerator.Generate();
mazeGenerator.SaveAsImage("maze.bmp"); // Save a 1-to-1 bitmap.
mazeGenerator.SaveAsImage("maze-x5.bmp", 5); // Save an upscaled bitmap.
```

### Maze Solver

```cs
MazeSolver mazeSolver = new MazeSolver("maze.bmp"); // Must be the 1-to-1 version.
mazeSolver.Solve();
mazeSolver.SaveSolutionAsImage("solution.bmp"); // Save a 1-to-1 bitmap.
mazeSolver.SaveSolutionAsImage("solution-x5.bmp", 5); // Save an upscaled bitmap.
```

## Screenshots

### Form

![Form](media/form.png)

### Generated Maze

![Maze](media/maze.png)

### Solved Maze

![Solution](media/solution.png)
