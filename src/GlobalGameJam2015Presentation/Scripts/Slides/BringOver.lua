
zak = { 
	sprite('zak/0.png'),
	sprite('zak/1.png'),
	sprite('zak/2.png'),
	sprite('zak/3.png'),
	sprite('zak/4.png'),
	sprite('zak/5.png'),
	sprite('zak/6.png'),
	sprite('zak/7.png'),
}

black = sprite("black.png");

zaktext = sprite("zak/txt.png");

function reset()
	x = 1920
	i = 0

	bombdone = false
	bombtime = 0
end

function draw(time)
	black.stretch(0, 0, 1920, 1080);

	local frame = math.floor(4 * time) % 8;

	zak[frame + 1].draw(0, 50);
	zaktext.draw(0, 790);

end




