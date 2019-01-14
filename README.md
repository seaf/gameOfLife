# Conway's Game of Life

An implementation of Conway's Game of Life in 64-bit integer space done as a personal project. Console and Windows Forms interfaces are provided, along with standard Game of Life rules (b2/s23), with flexbility for variations and additions.

## Project Structure ##

**GameOfLife.Core**

Primary project for components of the simulation.

**GameOfLife.Console**

The command-line program for interacting with the Game of Life simulation. Consumes GameOfLife.Core.

**GameOfLife.WinForms**

A Windows Forms application for viewing patterns within a small section of the game grid. Consumes GameOfLife.Core.

**GameOfLife.Test**

A test project containing unit testing around game logic and core types.

## About the Projects

Projects are written in C# targeting the .NET Framework 4.7.2. GameOfLife.Console uses C# 7.3 to leverage the addition of support for async Main methods in C# 7.1.

## Playing the Game -- Command-Line

Build the GameOfLife solution, or GameOfLife.Console project, via Visual Studio 2017 or the .NET Framework 4.7.2 SDK.

If running from Visual Studio 2017, right-click the GameOfLife.Console project and ensure it is `Set as StartUp Project`. You can then run the program by clicking `Start` on the taskbar, or hitting `F5`.

If running from the command line, locate the GameOfLife.Console.exe file in the build directory and execute it.

The console application supports input from the command-line if no arguments are given, or by reading input from a file if the `--file (-f) {pathToFile}` argument is given.

Expected File Format (if using file input):

* Empty lines, or lines beginning with \# are ignored. \# signifies a comment line.
* Lines of the form `(x, y)` represent a living cell at the start of the game with unsigned, 64-bit integer coordinates x (row), y (column). These should be entered one per line.

Example input files are located in GameOfLife.Core\Patterns with .rgol extension.

## Playing the Game -- GUI

Build the GameOfLife solution, or GameOfLife.WinForms project, via Visual Studio 2017 or the .NET Framework 4.7.2 SDK.

If running from Visual Studio 2017, right-click the GameOfLife.WinForms project and ensure it is `Set as StartUp Project`. You can then run the program by clicking `Start` on the taskbar, or hitting `F5`.

If running from the command line, locate the GameOfLife.WinForms.exe file in the build directory and execute it.

Clicking `Load Pattern` will open a file dialog to select an input file. Sample patterns are available in the starting directory. Once a pattern is loaded, click `Run Game` or `Stop Game` to start/stop the simulation. By altering the values in the `Generation Delay` or `Cell Scale` boxes, you can modify the delay between generations of the game and the size of each cell within the grid.

*NOTE*: The displayed grid is of limited size and depending on the state of the game may not be displaying all activity. Entering too large a scale factor may also shift a visible pattern outside of the visible grid. 

## Running Tests

Tests can be executed from the Test Explorer window within Visual Studio 2017 after building the solution.
