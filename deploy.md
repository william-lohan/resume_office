$Env:GODOT_BIN --build-solutions --path ./ --no-window -q

$Env:GODOT_BIN --export "HTML5"

cp '.\Resume 2022.pdf' .\dist\

cd .\dist\

git init
git add -A
git commit -m 'deploy'

git push -f https://github.com/william-lohan/resume_office.git master:gh-pages
