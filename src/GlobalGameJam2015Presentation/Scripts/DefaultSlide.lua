title = text(_TEXT, _FONT, _FONTSIZE);

distractions = {
	"Distractions/Bomberman.lua",
	"Distractions/Zelda.lua",
	"Distractions/ZeldaRun.lua",
};

if (_OPTIONS.distractionfree) then
	distraction = { reset = function() end, draw = function() end };
	distractionTime = 0;
else
	local distractionidx = math.random(1, #distractions);
	dofile(distractions[distractionidx]);
	distractionTime = math.random(1, 60);
end


function reset()
	distraction:reset();
end

function draw(time, frame)
	title.draw();
	
	if (time >= distractionTime) then
		distraction:draw(time - distractionTime);
	end
	
end
