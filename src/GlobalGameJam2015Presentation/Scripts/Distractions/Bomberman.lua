
distraction = { }

distraction.bomberman = { 
	sprite('bomberman2.png'),
	sprite('bomberman1.png'),
	sprite('bomberman3.png'),
}
distraction.bomberman[0] = distraction.bomberman[2];

function distraction:reset()
	self.y = math.random(50, 800);
end

function distraction:draw(time)
	time = math.floor(time * 15);

	local x = 1920 - time*50
	local i = (time) % 4

	self.bomberman[i].draw(x, self.y);
end

