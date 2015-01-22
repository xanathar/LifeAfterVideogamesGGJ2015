bars = shader('Shaders/ZXSpectrumBars.mgfxo')
title = text(_TEXT);

function reset()
	x = 1920
	i = 0

	bombdone = false
	bombtime = 0
end

function draw(time)

	bars.set("Time", time);
	bars.set("Rand", math.random(1, 100));
	bars.on();

	title.draw();

	bars.off();
end




