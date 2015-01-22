arkanoid = sprite("arkanoid1.png");
ball = sprite("arkanoidb.png");
brick = sprite("brick.png");
brickdbg = sprite("brickdbg.png");

--X 298, 22 bricks, W=1320
--Y 496, 3 bricks, H = 90

title = text(_TEXT);

wall = { }

function reset()
	x = 960
	y = 980
	dx = -1
	dy = -1
	
	for x = 1, 22 do
		for y = 1, 3 do
			local tile = { x = x * 60 + 238, y = y * 30 + 466 };
			table.insert(wall, tile);
		end
	end
end

function draw(time)
	title.draw();
	x = x + 10*dx
	y = y + 10*dy
	
	if (y < 0) then y = 0; dy = -dy; end
	if (y > 980) then y = 980; dy = -dy; end
	if (x < 0) then x = 0; dx = -dx; end
	if (x > 1910) then x = 1910; dx = -dx; end
	
	for _, v in pairs(wall) do
		if (not v.hit) and (collision(x, y, v)) then
			x = x - dx;
			y = y - dx;
			if (lateralCollision(x, y, v)) then dx = -dx; 
			else dy = -dy; end
			
			v.hit = true;
		end
		
		if (v.hit) then brick.draw(v.x, v.y); end; -- else brickdbg.draw(v.x, v.y); end
	end
	
	
	local ax = math.max(0, math.min(x - 78, 1920 - 157));

	arkanoid.draw(ax, 1000);
	ball.draw(x, y);
end

function collision(x, y, tile)
	return x+25 > tile.x and x < tile.x+60 and y + 20 > tile.y and y < tile.y + 30;
end

function lateralCollision(x, y, tile)
	return false;
end


