INSTRUCTIONS:

Juice:
Call CameraScript.Shake(power) in any script to shake the screen.
Call FixedTime.FreezeTime(seconds) in any script to freeze the game. (good for powerful impacts)

Sound:
Attach a SoundManager script to a gameobject that you want to produce sound.
In the inspector, add the sound files under "sounds". Write names for the sounds under "names".
In a script, add a SoundManager variable, and in Start link the component to it.
Now, call _soundManager.Play(soundName) to play a sound.
You can add a lot of optional variables as well, such as whether it should loop, if it's spatial and the volume.

(TIP: Giving multiple sounds the same name will select a random one that matches the name.)

--------------------
Character Select:
	Adding new Character Portraits
To add new character portraits, simply add a new child to the "Character Selection" Gameobject. It will automatically orden them because of its Grid Layout Group.
Every Portrait must have the "Character Template" Script attached to it. In this script, you put the gameobject of your character & The Characters Name.
This gameobject will be shown when a player selects this portrait by pressing the "A" Button.

	Character Selecting
Hovering over a Portrait and pressing "A" will pick that character. When picked, the mouse will be locked.
When picking a portrait a raycast will be shot downwards from the middle of the MouseUI Elements - It should be put in the top left corner if your sprite implies that.
^ 
The player can un-choose their character by pressing "B" this will allow them to move the mouse again and pick a new character.

	Other UI Elements
There Are Lerping UI Elements, this visually notifies the player that they picked a character or are able to start the game.
In script you can change what position they Lerp to, their return position will always be their original position when the scene is loaded.

	Character Visualization
The Left/Right Side of the UI Visualize the chosen character. This is done with a rendertexture.
There is a Mask on the P1_Panel and P2_Panel to make sure the rendertexture can't be shown outside of these panels.
If You want you can move these Panels around and change there shape, the rendertexture will still render in them the same way.

	But Tibau, I want to lerp even MORE stuff
If you want to lerp move stuff (which is perfectly normal), you can call UILerper.LerpUI() in any script to lerp stuff
Call this with the rectTransform (since we're dealing with UI),your Endposition and your lerpSpeed. Don't forget to also save a startPosition of what you're going
to be lerping in the Start Method (Just like I did with the Border in the "PlayerUI" Script) This allows it to be Un-Lerped again by the same Method.

	Altering Character Select
If You don't want the Whole Character Visualization Thing, you can remove the LoadCharacter() & UnLoadCharacter() Methods, be careful to still lock the mouse if you want to.
CharacterSelectManager currently also checks if mousesAreLocked before he proceeds to the next scene, you'd also have to add a bool to replace MouseIsLocked then.
ChosenCharacterSaver is the Script that will eventually save which characters were chosen and go to the Game Scene.

	UI Hierarchy
Yeah I'm actually making a part about this I'm sorry
The bottom most thing in the UI Hierarchy will be the top most thing on your screen.
So, if you want your mouse to be above something in the game, you will place the Mouse gameObject under it in the Hierarchy (f.e. Character Selection is above P1Mouse)
Since I wanted the StartGameUI to be shown above the Mouse UI, I placed it lower in the Hierarchy 

--------------------
Main Menu:
	Buttons
Main Menu has 2 buttons atm that, when clicked, call a method in the SceneChanger Script. it's simple but does what it needs to do.

	ResetGame Scripts
There is also a Reset Game Script on the Main Camera, because we have 2 gameobjects (GameController & ChosenCharacterSaver) that we DontDestroyOnLoad,
we need to destroy them when coming back to the main menu. This way the game can be played again from the beginning.

--------------------
In-Game:
	Debug Mode (!)
Currently the GameController is in Debug mode, this means that you can play the GameScene and it will work. In debug it spawns a basic character.
When you're playtesting the game, turn DebugMode off so that you can play the characters you chose in the Character Select

	Camera Stuff
When the players spawn, they're T-Posing for half a seconds so I moved the camera up before the game starts. This way you cant see the Tpose and
the camera pans down and tbh it looks intended.

	Character Spawning
There is a spawnPoint for both players, these can be moved around, their forward is also the forward that the players will be spawned on.
The gameController handles the spawning of the players. If you want something special to happen when the players are spawned you can add it to the CreatePlayer() method
It's a good amount of code but the comments should help

	Health
Currently Players' health is being visually shown with a square that is being scaled, this is all done in the SetHealthImageWidth() method in the GameUIManagerScript.
If you want to do something else than scale a square, just add code onto the gameUIManager Script.

	Player Portraits
Player portraits are being set via a script on the PlayerPrefabs that Holds a sprite

	WaitTime until Game start
I added a wait time until the game can start. This wait is done with a Coroutine in the GameControllerScript.
In the Awake() method a Coroutine is started called WaitToStartGame(). It may surprise you but this will wait to start the game.
If you want more stuff to happen before the game starts you can add stuff into the BeforeGameStart() method (currently I just pause the game there)
stuff that need to happen as soon as the game starts, need to go in the GameStart() method. 

	Ending The Game
When a player dies, they call the EndGame() method in the GameController script. this will notify the game that the OTHER player has won.
It will then start a coroutine for x amount of seconds, after that the WinnerScene will be loaded that displays the winner's number
Again, if you want more stuf to happen here you can add a new method in EndGame() or in the Coroutine()

--------------------	
	Players:
To use the player prefab: 
	Duplicate The original Player prefab.
	Switch out the model with your own.
	Add "AttackCollider" prefabs to the limbs the player uses to fight.
	Duplicate the animationController and switch out the animations & values


General:
	All movement parameters are adjustable in the Player inspector (PhysicsController).

	MaxHealth
	Flinch time - how long player loses control when he gets hit
	Knockback force - how hard players gets knocked back when hit
	Can control during attack - if player is able to move while performing an attack (this will always be false if the attack uses motion from the animation).

Attacks:
	A player has 2 attacks: Normal Attack & Special atttack. Both attacks have same parameters.

	Attack damage
	Attack colliders - Drag the AttackColliders your attack uses in here
	Attack duration - How long the attack takes to perform
	Attack damage time range - The time window in which the attack will damage the opponent. (some attacks need to charge up first or leave the player vunerable after they performed it)
	Use attack motion - Does the motion of the attack animation take over when performing an attack?

