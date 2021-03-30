# SC2KRepainter
Fixes palette animation in SimCity 2000 on modern Windows

# Instructions
Run SC2KRepainter.exe before or after you launch SimCity 2000 on modern Windows, like Windows 10, and the game's animations should start working. You must run the game with the "Reduced color mode" compatibility setting set to "8-bit (256) color".

# Side Effects
As this fixes palette-based animations in SC2K by forcing the game to repaint its entire window instead of just the sections the game wants, it has side effects. One example is that the price of things as you click and drag will disappear right after changing.

# Technical Description
SimCity 2000 uses palette swapping to animate lots of things in the game. Windows 10 (and I've heard some older versions like 8) still support 256-color compatibility mode, but don't update the results of changing palettes until the game repaints that part of the window. That's why you could often see little bits of the animations near things like the tile highlighted near your mouse cursor. On older versions of Windows, the actual palette being used to draw the screen would be updated, so the game wouldn't need to repaint anything to cause the animations to happen.

SC2KRepainter simply finds the SimCity 2000 window and invalidates the paint status of the entire window over and over again in a loop. This causes the game to redraw the entire window with every update, which allows you to see the animations. However, it also forces the game to repaint things it didn't expect, which is why the side effects previously mentioned occur. There may also be performance impacts, though I wouldn't think they'd be noticeable on a modern machine.

This whole problem seems like it could be much better solved by patching SimCity 2000 itself to repaint its window every time it changes the palette, and to fix the side effects, but that sort of low-level x86 assembly hacking is outside my wheelhouse.
