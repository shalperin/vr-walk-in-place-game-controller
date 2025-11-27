# You Don't Need A Treadmill!
## UDNAT

This is the walking-controller from the soon-to-be-released game.

Left-trigger enables and disables walking.  Otherwise, march in place
and pump your arms as you march.

### To Run the Demo 
1. Clone the repo
2. Add the project to Unity Hub (and install the right version of Unity)
3. Open the scene /Assets/\_UDNAT/Scenes/BasicScene
4. Run

### Tour of the Project
- Code lives in /Assets/\_UDNAT
- Game Objects live under 'udnat' in the scene hierarchy

### Assumptions
- If you are trying to run the demo right out of the box:  Working Meta PC/VR via Meta Link or whatever.  You could also add Android support and build/push an APK.
- If you are trying to use udnat in your own project: 
-- Consider starting with the stock Unity VR Template (the "current" one as of Thanksgiving 2025 with XRI 3.2.1 works great)
-- An XR Rig based on XRI 3 (look in Assets/Samples/XR Interaction Toolkit to verify version).  In particular the XR Origin should have a CharacterController component.
== Model your scene graph, with links to XR Origin and the various Input actions in the right places.  (You will need to look at /Assets/Samples/XR Interaction Toolkit/3.2.1/Starter Assets/XRI Default Input Actions)

### Helpful Links
- [Demo Video](https://www.youtube.com/watch?v=DCtWDwu_-a8)
- [Code Walkthrough Video](https://www.youtube.com/watch?v=aNW7QOKruSc)
- [Primer on Input Actions](https://www.youtube.com/watch?v=JxAn7LmHIVs)


