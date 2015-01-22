bomberman = { 
	sprite('bomberman2.png'),
	sprite('bomberman1.png'),
	sprite('bomberman3.png'),
}

bomberman[0] = bomberman[2];

bomb = sprite('bomb.png')

fire = sprite('fire.jpg')

title = text(_TEXT);

function reset()
	x = 1920
	i = 0

	bombdone = false
	bombtime = 0
end

function draw(time)

	time = math.floor(time * 15);
	
	if (bombtime > 0) and (time > bombtime + 10) then
		title.draw();
		local alph = (time - bombtime - 20) / 10;

		fire.draw(0, 0, 1 - alph );
		return;
	end

	x = 1920 - time*50
	i = (time) % 4

	if (bombtime == 0) and (x < 960) then
		bombtime = time
		print("bombtime", time)
	end

	if (bombtime > 0) then
		bomb.draw(960, 540 - 67);
	end

	bomberman[i].draw(x, 540 - 67);
end




