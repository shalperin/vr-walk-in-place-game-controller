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

### Assumptions For Running the Demo
- If you are trying to run the demo right out of the box:  Working Meta PC/VR via Meta Link or whatever.  You could also add Android support and build/push an APK to the Quest.  For other VR platforms you may need to reconfigure XR.

## Using this code in your project
- Consider starting with the stock Unity VR Template (the "current" one as of Thanksgiving 2025 with XRI 3.2.1 works great)
- An XR Rig based on XRI 3 (look in Assets/Samples/XR Interaction Toolkit to verify version).  In particular the XR Origin should have a CharacterController component.
= Model your scene graph, with links to XR Origin and the various Input actions in the right places.  (You will need to look at /Assets/Samples/XR Interaction Toolkit/3.2.1/Starter Assets/XRI Default Input Actions)

### Helpful Links
- [Demo Video](https://www.youtube.com/watch?v=DCtWDwu_-a8)
- [Code Walkthrough Video](https://www.youtube.com/watch?v=aNW7QOKruSc)
- [Primer on Input Actions](https://www.youtube.com/watch?v=JxAn7LmHIVs)

Copyright Samuel Halperin 2025

IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MODIFIES AND/OR CONVEYS THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED TO LOSS OF DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS), EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.

Please inquire at sqh@me.com for License
