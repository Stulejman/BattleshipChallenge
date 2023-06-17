# Guestline Battleship challenge

Hi! Please find and enjoy the solution of Guestline battleships challenge. It was very tempting to implement more complex scenario of the game, however the requirements were strict, so we need to follow

# Game

Battleships game description, as well as Guestline requirements can be found here: https://medium.com/guestline-labs/hints-for-our-interview-process-and-code-test-ae647325f400

The game requires you to input the proper cell to shoot by typing proper cell name, such as A1, C5, etc...


## Build
Battleships are written in .NET 6. It is a console application. To run the game you need to build the project using proper dotnet version, and run Battleships.Console.exe application.

## Modes

There are two modes of the game depending on build configuration:
**Debug** - this mode will disclose a whole board for you, so you wont have to struggle with finding proper location of the ship to attack.
**Release** - the board is covered with a **fog of war**. You will uncover each cell with each shot.

## Implementation

The project was implemented with common coding practices, such as YAGNI, SOLID, DRY having on mind (I hope:).

![Alt text](./UML%20Class%20Diagram.jpg?raw=true "UML Class Diagram")