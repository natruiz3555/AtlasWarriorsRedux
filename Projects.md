Quick architecture discussion:

This solution uses 'Shared Projects' in the way most solutions would use Libraries.
This is because it has been written with Monogame's ability to port to multiple 
platforms in mind. As such, we don't necessarily have access to dlls - and 
everything will have to be recompiled. It was that or shared source files - which
seemed uglier and more maintenance heavy to me.

I haven't used the shared monogame library stuff either, as I'm hoping to be able
to make a non-monogame UI that is accessible to the vision impaired.

The projects are as follows:

  - GLGameApp
    The 'Game' application for desktop users

  - Screen reader app
	The 'Game' application for screen reader players    

  - AtlasWarriorsGame
    Shared project that contains the actual game objects and logic.  The models
	and controllers to GLGameApp's view.

  - AtlasWarriorsGame.Tests
    NUnit test project for AtlasWarriorsGame.

  - UiCommon
    Stuff that multiple interfaces need, but that I still want to keep
	seperated.

  - MgUiCommon
    Common code between graphical user interfaces, including Map Drawing (for instance)