-- Starting position and size of window
X = 1680
Y = 0
Width = 1280
Height = 1024
-- use letterbox to keep aspect ratio in check if virtual buffer and real have diff ratios
-- (note: works only with some ratio differences, eh)
LetterBox = true
-- use borderless to avoid having decos around the window 
Borderless = true
-- allow exit from presentation
AllowExit = true
-- backcolor
Background = "#333"
-- size of the virtual buffer 
VirtualWidth = 1920
VirtualHeight = 1080
-- defaults for simple slides
DefaultFont = "Ubuntu"
DefaultSize = 72
-- enable and configure second screen function
SecondScreen = false
SecondScreenX = -1280
SecondScreenY = 0
--
TotalLength = "00:30:00"
LogDurations = "c:\\temp\\durations.txt"
-- 

defineSlide {
	options = { distractionfree = true },
	text = "Life after video games",
}

defineSlide {
	text = "A blink to the past",
	script = "MyPast.lua",
	duration = "00:02:00",
	notes = [[
		I was born in 1976.. ZX spec in 1985. Passions: games, building things
		286 in 1989, GW Basic, TD2 credits
	]]
}

defineSlide {
	text = "Work in Milestone",
	script = "Milestone.lua",
	duration = "00:03:00",
	notes = [[
		I worked at Milestone s.r.l. for 3 years, making racing videogames, TV show videogames and B2B videogames for TV set-top-boxes
		3D engine programmer for racing games which mostly failed to get to the market, game programmer on non-racing games
	]]
}


defineSlide {
	text = "Back to the present",
	duration = "00:03:00",
	notes = [[
		I work in deltatre
		There I worked and am working on TV graphics, result data gathering and data feeds for 10 years.
	]]
}

defineSlide {
	text = "Why I changed",
	duration = "00:03:00",
	notes = [[
		distance
		fear of unemployment
		crysis of sector
	]]
}

defineSlide {
	text = "What can you bring over ??",
	duration = "00:00:00",
}

defineSlide {
	text = "Attitude",
	duration = "00:00:00",
}

defineSlide {
	text = "Cooperation",
	duration = "00:00:00",
	notes = "specially interaction artist – programmer",
}

defineSlide {
	fontsize = 64,
	options = { distractionfree = true },
	text = 
[[
Some programming skills.. like..

C++, C, C#, Java, Assembly, math, DirectX, OpenGL, OpenAL, OpenCV, Lua, Python, JavaScript, Unity, DSLs, multiplatform, mobile, multithreading, networking, audio programming, shaders, design patterns, testing, agile methodologies, OOP, RESTful services, ...

buuut.. you don’t know PHP!
]],
	duration = "00:00:00",
	notes = [[ 
		a LOT of skills can be reused in the non-gaming industry
		a vg programmer is unlikely to know PHP or SQL, coming from gaming
		but seriously, what about what she/he knows ? 
	]],
}


defineSlide {
	text = "Is there anybody interested ?",
	duration = "00:00:00",
}

defineSlide {
	text = 'Smart and "Gets things done"\n\n(Joel Spolsky)',
	duration = "00:00:00",
}


defineSlide {
	text = "Attention to user engagement",
	duration = "00:00:00",
}


defineSlide {
	text = "And what could you bring back",
	duration = "00:00:00",
}

defineSlide {
	options = { distractionfree = true },
	fontsize = 64,
	text = 
[[
Some programming skills.. like..

C++, C, C#, Java, PHP, WebGL, SQL, JavaScript, Python, Ruby, ActionScript, DSLs, multiplatform, mobile, multithreading, networking, audio programming, content management systems, design patterns, testing, agile methodologies, OOP, RESTful services, ...

buuut.. you don’t know DirectX!
]],
	duration = "00:00:00",
}

defineSlide {
	text = "end",
	duration = "00:00:00",
}



defineSlide {
	text = "end",
	duration = "00:00:00",
}

