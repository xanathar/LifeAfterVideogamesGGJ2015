# LifeAfterVideogamesGGJ2015

Slideshow "minigame" for the "Life after Videogames" presentation at Global Game Jam 2015 in Turin.

Product trademarks, logos, names, together with brands and any other trademark featured, referred or
simply showed within the present material are the property of their respective rightful owner, 
trademark holders and Licensors. 

Features:

* Supports standard slides in any easy way
* Slides can be scripted in Lua
* HLSL shaders are supported
* Fade effect between slides

## API

### Config.lua

Config.lua contains configuration parameters (documented in the file itself) and slides definitions.

Slides can be defined with the defineSlide function.

#### defineSlide(table) 
Adds a new slide to the slideshow. Can take these params in the table:

* text : The text of the slide. Gets passed to the slide script as _TEXT.
* font : An alternative font for the slide. Gets passed to the slide script as _FONT.
* fontsize : An alternative font size for the slide. Gets passed to the slide script as _FONTSIZE.
* notes: Notes to appear on the second screen
* duration : Expected duration of the slide
* script : The lua script implementing the slide. If nil, DefaultSlide.lua is used.
* options : A table which gets passed to the slide script. Be sure it contains only strings, booleans and numbers, otherwise it's a crash waiting to happen!
 
### Slides scripts

Slides are implemented in Lua scripts.

Slides can implement three methods:

* draw(time) : *mandatory* - Gets called every frame to draw the slide. time is in seconds, from the slide start.
* reset() : Called if the slide must be reset for any reason, or at the start of the slide itself.
* click() : Called when the user left-clicks.

The following functions are supported in slides.

#### next()

Goes to the next slide. 

#### prev()

Goes to the prev slide. 

#### text(text [,face [,fontsize]])

Creates a centered text sprite, with the given text, font face and size. Only text is mandatory. See "sprite" to see how to operate on sprites.

#### sprite(filename)

Creates a sprite reading the specified image file.

A sprites supports these functions:

* draw(x [,y [,opacity]]) : draws the sprite at (x,y) (0,0 by default) with the specified opacity (1.0 by default).
* blit(sx, sy, w, h, dx, dy [,opacity]) : draws at dx,dy a portion of the sprite which goes from sx,sy of the given width and height
* stretch(x, y, w, h, [,opacity]) : stretches the sprite to fill the rectangle at (x,y) of the given width and height

#### shader(filename)

Loads the specified precompiled HLSL shader.

A shader supports these functions:

* on() : activates the shader
* off() : deactivates the shader, restoring fixed pipeline functionality
* set(name, value) : sets a uniform named "name" to a float of the specified value





























