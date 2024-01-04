.DEFAULT_GOAL := help

all : clean restore build test publish

clean:
	dotnet clean

restore:
	dotnet restore

build:
	dotnet build

test:
	dotnet clean
	dotnet test

publish:
	dotnet publish -c Release

watch:
	dotnet watch

run:
	dotnet run --project .\BuberDinner.Api\

code-push:
	git add .
	git pull
	git commit -m "standard message"
	git push
	echo "code pushed to remote"


help:
	echo "I am the help"
