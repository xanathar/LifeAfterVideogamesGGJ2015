realgames = {
	sprite("Milestone/APEX.jpg"), 
	sprite("Milestone/EGT.jpg"), 
	sprite("Milestone/REvo.jpg"), 
	sprite("Milestone/S1.jpg"), 
	sprite("Milestone/S2.jpg"), 
	sprite("Milestone/SBK2011.jpg"), 
	sprite("Milestone/SBK.jpg"), 
	sprite("Milestone/SCAR.jpg"), 
	sprite("Milestone/XFUK.jpg"), --9
	sprite("Milestone/ERE.jpg"), 
}

fx = shader("Shaders/TestShader.mgfxo");

pos = {
	{ 200, 200 },
	{ 600, 600 },
	{ 1350, 550 },
	{ 300, 400 },
	{ 500, 200 },
	{ 1100, 150 },
	{ 1500, 200 },
	{ 900, 500 },
	{ 1400, 250 },
	{ 800, 100 },
}

title = text(_TEXT);

function reset()
	state = 0;
	time0 = 0;
end
 
function draw(time)
	time = time - time0;

	if (state == 0) then
		for i = 1, 8 do
			fx.set("DoIt", i % 2);
			fx.on();

			local alpha = 2*time - i
			local x, y = pos[i][1], pos[i][2];
			realgames[i].draw(x, y, alpha);
		end

		fx.off();
	elseif (state == 1) then
		for i = 1, #realgames do
			local alpha = 2*time - (i - 8)
			local x, y = pos[i][1], pos[i][2];

			if (i <= 8) then
				alpha = 1
			end

			realgames[i].draw(x, y, alpha);
		end
	elseif (state == 2) then
		for i = 1, #realgames do
			local x, y = pos[i][1], pos[i][2];

			if (i <= 8) then
				y = y + 981 * time * time;
			end

			realgames[i].draw(x, y, 1);		
		end
	elseif (state == 3) then
		for i = 8, 10 do
			local x, y = pos[i][1], pos[i][2];
			local alpha = 1;

			if (i <= 8) then
				alpha = 2*time
			end

			realgames[i].draw(x, y, alpha);		
		end
	end

	-- title.draw();
end

function click(time)
	state = state + 1;
	time0 = time;

	if (state == 4) then
		next();
	end
end





