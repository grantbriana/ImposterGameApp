# ImposterGameApp

Briana Grant
CPSC3175: Object Oriented Design
Professor Obando
11/31/21

Final Project: Impostor - A Text-Based Game

Game Description The following project is a role playing game based on the
game "Among Us". The user is simply one crew member amongst a number of others on a
spaceship returning to Earth. However, a member of the crew is an impostor, which needs to be
found and attacked. It is the user's job to pinpoint the impostor aboard the space ship & attack
them. The user gets one chance to attack the correct crew member. The user wins the game if
they attack the crew member which is the impostor and loses the game if they attack a crew
member who is not the impostor.

User Level Description: You are a crew member on a spaceship returning to Earth. As the
mission goes on, strange events begin to occur... An impostor has boarded your spaceship.
Find Hints & clues among your spaceship in order to find the imposter & attack the imposter.
Implementation Description: The “Impostor” game is a text-based program that utilizes a
console. The progam implements seven design patterns including Game loop, Singleton,
Prototype, Observer, Template, Command, State, and the factory method.

Special Features: Special features of the program include the ability to parse up to four words
in the console, a restart command, and the ability to take and use weapons.

Patterns Used and Where:
1. Game Sequence Design Pattern: Game loop
- Found: Game.cs (Game class) in Play method.
- Implemented in classes: Program.cs (Program class).
- The method runs continuously during gameplay. Each turn of the loop, it
processes user input

2. Behavioral Design Pattern: Command
- Found: Command.cs (Command class)
- Implemented in classes: AttackCommand, BackCommand, DropCommand,
GoCommand, HelpCommand, InspectCommand, QuitCommand,
RestartCommand, TakeCommand, TalkCommand, WhereAmICommand
- The command object is used to encapsulate all information needed to perform an
action or trigger an event (a console command)

3. Behavioral Design Pattern: State
- Found: State.cs (State class), Player.cs (Player class)
- Implemented in classes: AttackCommand, BackCommand, DropCommand,
GoCommand, HelpCommand, InspectCommand, QuitCommand,
RestartCommand, TakeCommand, TalkCommand, WhereAmICommand, Player
(attack method)
- The finite state machine is used to control the behavior of the program under
different states and conditions.

4. Behavioral Design Pattern: Observer
- Found: Notification.cs (Notification class), NotificationCenter.cs
(NotificationCenter class)
- Implemented in classes: Player (WalkToPreviousRoom method: Line 63,
KillImposter method: Line 243, TalkTo method: Line 214, WalkTo method: Line 93)
- The finite state machine is used to control the behavior of the program and player
under different states and conditions.

5. Creational Design Pattern: Prototype
- Found: NPC.cs (NPC class)
- Implemented in classes: GameWorld (createWorld method: Line 80)
- Copies object without dependence on the prototype’s classes. Clones object
(NPC)

6. Creational Design Pattern: Factory Method
- Found: GameObject.cs (GameObject class)
- Implemented in classes: GameWorld (createWorld method)
- Provides an interface for creating objects in a superclass, but allows subclasses
to alter the type of objects that will be created.

7. Creational Design Pattern: Singleton
- Found: GameWorld.cs (GameWorld class)
- Implemented in classes: GameWorld (Line 18)
- Creates a single class responsible to make sure that only one instance of
that particular class is created in the program

Known Bugs/Problems:
1. Restart Command: Cannot start another program from visual studios Start button while
console (process) is running. Must exit program in order to do so or multiple programs
may run or restart will fail.
2. Player “Attack” Method/Command: If object is not found in inventory or NPC is not
found in current room, a null exception would be thrown. A try-catch function is put in
place to avoid this
