
distraction = { }

distraction.bomberman = { 
	sprite('bomberman2.png'),
	sprite('bomberman1.png'),
	sprite('bomberman3.png'),
}
distraction.bomberman[0] = distraction.bomberman[2];

function distraction:reset()
	self.x = 1920
	self.y = math.random(50, 800);
	self.i = 0
end

function distraction:draw(time)
	time = math.floor(time * 15);

	x = 1920 - time*50
	i = (time) % 4

	self.bomberman[i].draw(x, self.y);
end

