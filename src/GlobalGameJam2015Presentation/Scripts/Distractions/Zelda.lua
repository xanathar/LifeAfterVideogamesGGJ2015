
distraction = { 
	link = sprite('zeldal.png'),
	enemy = sprite('zeldae.png'),
}

function distraction:reset()
	self.y = math.random(50, 800);
	self.dead = nil
end

function distraction:draw(time)
	local origtime = time;

	if (self.dead) and (self.dead < origtime) then
		if (origtime - self.dead < 1.0) then
			time = self.dead
		else
			time = time - 1.0;
		end
	end

	time = math.floor(time * 5);

	local x = -100 + time*50
	local i = (time) % 4

	local pos = { 0, 149, 0, 2*149 }
	local pose = { 0, 149, 0, 149 }

	local sy = pos[math.floor(i) + 1]
	local sye = pose[math.floor(i) + 1]

	if (not self.dead) then
		self.enemy.blit(140, sye, 140, 112, 1920 - x, self.y);

		if ((1920 - x - x) < 160) then
			self.dead = origtime;
		end
	end

	if (self.dead) and (self.dead < origtime) and (origtime - self.dead < 1.0) then
		self.link.blit(420, 149*3, 140, 112, x, self.y);
	else
		self.link.blit(420, sy, 140, 112, x, self.y);
	end



end

