# INTERACTIVE AIR HOCKEY

In this document, we will explain the basic functionalities of the main scripts we have write to create our interactive game project:

1) MainManager: The “MainManager” script controls the game flow in a general way:

1.1. In that script is where we init most of the game objects (and where we write all the code necessary for the restart of the game when it's necessary).

1.2. Also, this is the script where we control the goals scored by the two players (including the scoreboard update), and we control when a player wins the match (including the management of the victory text panels). 

1.3. Additionally, in that script we control if the ability is on, and all the general aspects we have to consider to apply and restart correctly the game special ability. 

2) PlayerManager: The “PlayerManager” script is very useful for us to manage all the things related directly to the player, such as the relation between the players and the special ability (when the ability is on or off, when the player collides with the special ability square, etc.). Also in that script we can control the sounds that affects directly to the players, and the force the sticks have to apply to the disk (puck) in order to move it.

3) PuckManager: The “PuckManager” script is very useful for us to manage all the things related directly to the puck (disk), such as the puck collision audios, and the force applied by the sticks to it.

IMPORTANT! Additionally, we have created a document where we explain the main mechanics of our game. We have uploaded it to the Aula Global too. That document its named "GAME MECHANICS".