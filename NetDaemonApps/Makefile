.PHONY: build 

generate:
	nd-codegen -o HomeAssistantGenerated.cs

build:
	dotnet publish -c Release -o out

publish:
	rm -rf ../netdaemon3
	cp -R out/ ../netdaemon3/
	mkdir -p ../netdaemon3/apps
	rm -rf out

gbp: generate build publish

update:
	dotnet tool update -g JoySoftware.NetDaemon.HassModel.CodeGen