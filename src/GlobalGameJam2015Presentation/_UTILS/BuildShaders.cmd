@echo off

cd "C:\git\LifeAfterVideogamesGGJ2015\src\GlobalGameJam2015Presentation\Content\Shaders"

for %%i in (*.fx) do "C:\Program Files (x86)\MSBuild\MonoGame\v3.0\2MGFX.exe" %%i %%~ni.mgfxo /DX11 /DEBUG



