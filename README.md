# Tic Tac Toe

This is a simple console-based Tic TacToe game written in **C#**.
You as the player play as **X**, and the computer (AI) plays as **O**.
The program supports different board sizes like (3x3, 5x5, 7x7, etc.). The BOARD_SIZE constant must be an odd number.

---

## Project Structure
TicTacToe
|
|-- Program.cs	-> Main game loop
|-- UI.cs		-> Handles input and output (Console.WriteLine/ReadLine)
|-- Logic.cs	-> Game rules, board, logic and AI

---

## How to Play
* The game shows you the board with row and column numbers.
* On your turn, type in a row number then a column number where you would like to play your **X**.
* The AI will then place an **O**.
* The game continues until:
	* You Win
	* The AI Wins
	* The board is full (Tie)

---

## Changing the Board Size
* Open **Logic.cs**
* On Line 11, change the following value to change the board size:
```
public const int BOARD_SIZE = 3;
```

---

## Features
* Flexible board size
* Simple AI
* Clean separation of functions for logic and UI

---

## Example Gameplay (3x3) Board
```
   1   2   3
 1   |   |	
  ---+---+---
 2   |   |	
  ---+---+---
 3   |   |	

Choose a Row (1-3):
1
Choose a Column (1-3):
1

The AI has played (2, 2).

```
* Console Clears and displays both the player move and AI move.
```
    1   2   3
 1 X |   |	
  ---+---+---
 2   | O |	
  ---+---+---
 3   |   |	

Choose a Row (1-3):
```