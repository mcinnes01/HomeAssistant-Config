.PHONY: build 

generate:
	nd-codegen -o apps/HomeAssistantGenerated.cs

build:
	dotnet build -c Release
	dotnet publish -c Release -o out

publish:
	rm -rf ../netdaemon3
	cp -R out/ ../netdaemon3/
	mkdir -p ../netdaemon3/apps
	rm -rf out

gbp: generate build publish