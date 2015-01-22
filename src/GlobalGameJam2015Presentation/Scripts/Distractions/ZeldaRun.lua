
distraction = { 
	link = sprite('zeldal.png'),
	enemy = sprite('zeldae.png'),
}

function distraction:reset()
	self.y = math.random(50, 800);
	self.fear = nil
end

function distraction:draw(time)
	local origtime = time;

	time = math.floor(time * 5);

	local x = -100 + time*50
	local i = (time) % 4

	local pos = { 0, 149, 0, 2*149 }
	local pos2 = { 0, 149, 0, 149 }
	local sy = pos[math.floor(i) + 1]
	local sy2 = pos2[math.floor(i) + 1]

	self.enemy.blit(140, sy2, 140, 112, 1920 - x, self.y);

	if (not self.fear) then
		if ((1920 - x - x) < 300) then
			self.fear = x + time * 50;
		end
	end

	if (self.fear) then
		x = self.fear - time*50;
		self.link.blit(140, sy, 140, 112, x, self.y);
	else
		self.link.blit(420, sy, 140, 112, x, self.y);
	end



end

