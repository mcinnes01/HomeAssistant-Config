.PHONY: build

generate:
	nd-codegen -o HomeAssistantGenerated.cs

build:
	dotnet publish -c Release -o out

publish:
	rm -rf ../netdaemon4
	cp -R out/ ../netdaemon4/
	mkdir -p ../netdaemon4/apps
	rm -rf out

gbp: generate build publish

update:
	dotnet tool update -g NetDaemon.HassModel.CodeGen