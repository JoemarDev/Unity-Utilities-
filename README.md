# Unity-Utilities-
Re- usable scripts

## Doppler Effect

- Distant between Gameobject(Audio source) and Player 
- Increase (or decrease) in the frequency of sound 

 *  [Doppler Effect](DistantAudio.cs)

## Vuforia - Audio Player
- Audio to be played on targeted image
- Script to be applied on gameObject with - Image Target Behaviour (Script)
- Requires Audio Source component 
*  [Vuforia Audio Player](ImageTargetPlayAudio.cs)

## Clamped Movement using Screen Size 
- Restricts Players Movement 
- Takes into consideration different screen sizes using ViewportToWorldPoint

*  [Clamped Movement](ClampedMovement.cs)

## Left and Right Mobile Touch Input
-  Simple mobile touch input
- For left and right movement
- Based on screen size
[Touch Input](TouchInput.cs)

## Snapshoot Camera 
- Take images/ photos in unity to save them on file 
- save image as texture2D
* [SnapShoot Camera] (SnapShotCamera.cs)


## Improved WayPoint 

- Set automated path movement using transforms, to predefine the path.
- NOTE:  waypoint circut  & improved way point rely on each other //  
 Disclaimer: Improved Way Point created by Zaneris
 
*  [Better Way Point Follower](BetterWaypointFollower.cs)
* [Way Point](WaypointCircuit.cs)

## Object Fader

- Make an object fade 
- Lerp smoothly between fades
 - NOTE: change default Material from Opaque to Fade
 * [Object Fade](SingleObjectFader.cs)


## Screen Fader
  
  - sceen fader 
  - using UI panel, changes panel 
  *  [Fade In Panel](FadeIn.cs)
 
 
  ## Scene Transitions
  
  - Load between scenes, infinite loop  
  - Apply on a empty game object (Not Destroyed) 
  *  [Scene Picker](ScenePicker.cs)
  
   ## Camera Switching 
  - Switch between cameras 
  *  [Camera Switcher](CameraSwitch.cs)
  
  ## Timer 
- UI Input 
- Serialized fields to adjust timer speed
- Takes input value using Unity UI Input field element. 10+ Digits plus (long) 
