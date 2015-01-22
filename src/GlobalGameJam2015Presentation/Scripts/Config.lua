-- Starting position and size of window
X = 0
Y = 0
Width = 720	
Height = 576
-- use letterbox to keep aspect ratio in check if virtual buffer and real have diff ratios
-- (note: works only with some ratio differences, eh)
LetterBox = true
-- use borderless to avoid having decos around the window 
Borderless = false
-- allow exit from presentation
AllowExit = true
-- backcolor
Background = "#333"
-- size of the virtual buffer 
VirtualWidth = 1920
VirtualHeight = 1080
-- defaults for simple slides
DefaultFont = "Atari Classic Chunky"
DefaultSize = 72
FadeMilliseconds = 250
-- enable and configure second screen function
SecondScreen = true
SecondScreenX = 0
SecondScreenY = 0
--
TotalLength = "00:30:00"
LogDurations = "c:\\temp\\durations_{TIME}.txt"
-- 



defineSlide {
	options = { distractionfree = true },
	text = "Life after video games",
}

defineSlide {
	text = 
[[
Please wait..
a videogame programmer
is loading.
]],
	script = "MyPast.lua",
	duration = "00:03:30",
	notes = [[
		I was born in 1976.. ZX spec in about 1985. Passions: games, building things
		286 in 1989, fascinated by GW Basic, TD2 credits
	]]
}

defineSlide {
	text = "Work in Milestone",
	script = "Milestone.lua",
	duration = "00:01:00",
	notes = [[
		I worked at Milestone s.r.l. for 3 years, making racing videogames, TV show videogames and B2B videogames for TV set-top-boxes
		3D engine programmer for racing games which mostly failed to get to the market, game programmer on non-racing games
	]]
}


defineSlide {
	options = { distractionfree = true },
	text = "Back to the present",
	duration = "00:01:20",
	notes = [[
		I work in deltatre
		There I worked and am working on TV graphics, result data gathering and data feeds for 10 years.
	]]
}

defineSlide {
	text = "Why I changed",
	script = "Arkanoid.lua",
	duration = "00:02:48",
	notes = [[
		distance
		fear of unemployment / investing on seldom used skills
		crysis of industry
	]]
}

defineSlide {
	text = "What can you bring over ??",
	script = "BringOver.lua",
	duration = "00:00:28",
}

defineSlide {
	text = "Enthusiasm",
	duration = "00:00:28",
}

defineSlide {
	text = "Cooperation",
	duration = "00:01:52",
	notes = "specially interaction artist – programmer",
}

defineSlide {
	text = "Attention to user engagement",
	duration = "00:02:39",
}

defineSlide {
	text = "Attention to detail",
	duration = "00:00:40",
}

defineSlide {
	text = "Analytics",
	duration = "00:01:42",
}

defineSlide {
	text = "Problem solving",
	duration = "00:00:57",
}

defineSlide {
	text = "Sacrifice",
	duration = "00:01:04",
}


defineSlide {
	text = "Artistic skills",
	duration = "00:00:31",
}

defineSlide {
	fontsize = 48,
	options = { distractionfree = true },
	text = 
[[
Some programming skills.. like..

C++, C, C#, Java, Assembly, math, DirectX, OpenGL, OpenAL, OpenCV, Lua, Python, JavaScript, Unity, DSLs, multiplatform, mobile, multithreading, networking, audio programming, shaders, design patterns, testing, agile methodologies, OOP, RESTful services, ...

buuut.. not PHP!
]],
	duration = "00:01:08",
	notes = [[ 
		a LOT of skills can be reused in the non-gaming industry
		a vg programmer is unlikely to know PHP or SQL, coming from gaming
	]],
}


defineSlide {
	text = "But, is anybody interested ?",
	script = 'Bomb.lua',
	duration = "00:01:08",
}

defineSlide {
	text = 'Smart and "Gets things done"\n\n(Joel Spolsky)',
	duration = "00:02:13",
}

defineSlide {
	options = { distractionfree = true },
	fontsize = 24,
	text = 
[[
https://github.com/xanathar/LifeAfterVideogamesGGJ2015

Built using MonoGame 
http://www.monogame.net/

Powered by MoonSharp 
http://www.moonsharp.org/

8-bit font by Mark Simonson 
http://members.bitstream.net/marksim/atarimac/fonts.html

Product trademarks, logos, names, together with brands and any other trademark featured, referred or simply showed within the present material are the property of their respective rightful owner, trademark holders and Licensors. 

]],
	duration = "00:30:00",
}

