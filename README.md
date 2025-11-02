# GameEngineLab3



Aaron Tran || 100825433



For the gameplay, the only things available is basic movement to move left and right with the A and D keys, and jumping with the Spacebar.

In the top left, you can click on buttons in order to either take damage, or set yourself on fire. You die when HP reaches 0, and you can toggle on and off the fire by pressing the button again.



**What element of your game adopts the chosen pattern?**



I decided to focus on the Observer pattern since I am able to understand it more comprehensively then the Command pattern, at least in terms of programming it in Unity. In the game itself, the Observer Pattern is used through the UI, showing a burning status when on fire and a health warning when below 50 HP. There is also the burning filter, where the camera observes when the player is on fire to activate the effect.



**Why is this pattern a good choice for spawning these objects?**



Overall this pattern is good to watch changes in state of other game objects in order to perform some other action. Though the game is rather crude, it does a basic job of showcasing how the UI and HUD watches the player in and adapts when their state is changed.



**Reflection**



Sadly I wasn't able to do more then just a simple toggle button. If I had more time it would have been nice to create a small game where the player might need to dodge falling fire, or even program more states such as a freezing effect. I also would have wanted to allow the fire to damage the player, while also implementing States more properly similar to how they were shown in lectures.



**References**



Some code was reused from the lecture slides, though adjusted to fit the project.

These two videos here helped me figure out how to use the Particles a bit more as well as implementing a Filter

https://www.youtube.com/watch?v=Oo6ktMZzzhg

https://youtu.be/5nWRrkaFpic?si=JYX4jCDqKljPCW2S



A Unity Discussion Page showing how to check when a Bool changes value

https://discussions.unity.com/t/how-to-check-when-a-bool-changes-value/143983



Finally, I did use Google and their AI to help search up some code to help guide me, mainly to help figure out how to create the Fade in and out effect

