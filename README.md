# Escape Room Version Control
 
Where I (Jeremy) left off:

ModalityManager is the script that controls whether a certain player's camera (PC, VR, AR) is enabled or not, and is partially functional. When building for PC, AR/VR is flipped off successfully, and appears to also work for building in VR, although I wasn't able to explicitly test it because I couldn't view the scene on my laptop to ensure the PC playerController was off. Additionally, whatever logic that is necessary to determine if the headset wants to run in AR needs to be implemented, but that should be straightforward.

The XR rig has two main components currently missing.
   1. I used worldspace canvases for the PC playerController to display things such as the time remaining in a scene, as well as a reticle and interaction prompts. This could either be replicated in VR, or could be substituted with other gameObjects that could be flipped on and off in the modalityManager, such as a fixed timer on the wall. 
   2. The interaction system is currently set up to function with a raycast coming out of the player's main camera. I figured this would work by just attaching the same script to the VR rig's camera (or each hand controller), but was incorrect. However, there is a built-in ray-based interaction system for XR rig which I think you could use as a substitute.
