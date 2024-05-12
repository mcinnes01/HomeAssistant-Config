.PHONY: build

generate:
	nd-codegen -o HomeAssistantGenerated.cs

build:
	dotnet publish -c Release -o out

dev:
	dotnet publish -c Development -o out

publish:
	rm -rf ../netdaemon4
	cp -R out/ ../netdaemon4/
	rm -rf out

gbp: generate build publish

gdp: generate dev publish

update: dotnet tool update -g NetDaemon.HassModel.CodeGen
