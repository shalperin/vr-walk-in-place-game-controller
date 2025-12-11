# You Don't Need A Treadmill!
## UDNAT

Hopefully this repo represents a reusable component for implementing a walk-in-place locomotion controller that others might find useful!

| [![Demo video](https://github.com/shalperin/YouDontNeedA_Treadmill/blob/master/demo-vid-thumb.png?raw=true)](https://www.youtube.com/watch?v=DCtWDwu_-a8) | [![Code walkthrough video](https://github.com/shalperin/YouDontNeedA_Treadmill/blob/master/walkthrough-vid-thumb.png?raw=true)](https://www.youtube.com/watch?v=aNW7QOKruSc) |
|---|---|

### Demo pre-built executable for Windows PC and Meta Quest PC/VR
https://shalperin.itch.io/udnat-demo


### To Run the Demo Via Building This Source Code In Unity
Left-trigger enables and disables walking.  Left-controller 'X' button jumps. Aspirationally the left menu button will display and hide some quick help. Otherwise, march in place
and pump your arms as you march. 

1. Clone the repo
2. Add the project to Unity Hub (and install the right version of Unity)
3. Open the scene /Assets/UDNAT/Scenes/BasicScene
4. Run

### Assumptions For Running the Demo
- If you are trying to run the demo right out of the box:  Working Meta PC/VR via Meta Link or whatever.  You could also add Android support and build/push an APK to the Quest.  For other VR platforms you may need to reconfigure XR.

  
### Tour of the Project
- Code lives in /Assets/UDNAT
- Game Objects live under UDNAT in the scene hierarchy
  

## Using this code in your project
- Consider starting with the stock Unity VR Template (the "current" one as of Thanksgiving 2025 with XRI 3.2.1 works great)
- An XR Rig based on XRI 3 (look in Assets/Samples/XR Interaction Toolkit to verify version).  In particular the XR Origin should have a CharacterController component.
- Model your scene hierarchy on the demo code, with links to XR Origin and the various Input actions in the right places.  (You will need to look at /Assets/Samples/XR Interaction Toolkit/3.2.1/Starter Assets/XRI Default Input Actions)

### Helpful Links
- [Demo Video](https://www.youtube.com/watch?v=DCtWDwu_-a8)
- [Code Walkthrough Video](https://www.youtube.com/watch?v=aNW7QOKruSc)
- [Primer on Input Actions](https://www.youtube.com/watch?v=JxAn7LmHIVs)

Copyright Samuel Halperin 2025

IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MODIFIES AND/OR CONVEYS THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED TO LOSS OF DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS), EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.


### Intuitions / Areas for someone to do research
- How we think about VR, especially with respect to cognitive load and simulator sickness may change as younger generations grow up having spent time in VR. ["VR naivete"]
- *Eventually* omni-directional treadmills will be a reality, and some more research into gameplay when the user is playing under aerobic load would be useful.
- Probably possible to establish via literature review (or empirically) that as heart rate increases, the tolerance for video game problem or puzzle solving decreases.
- Study this effect specifically in a VR exergame.
- Study this effect with an eye towards the next generation of VR users: does the magnitude of the effect change if the user is "VR naive" (never having used VR) or not (i.e. a regular Horizon Worlds, VR Chat user, or Gorilla Tag user) 

A free GNU General Public license is hereby granted to anyone doing nonprofit academic research.  If you need that more formally, reach out. http://shimi.run.
