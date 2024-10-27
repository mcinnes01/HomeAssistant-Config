.PHONY: build

generate:
	nd-codegen -o HomeAssistantGenerated.cs

build:
	dotnet publish -c Release -o out

dev:
	dotnet publish -c Development -o out

publish:
	sudo chown -R holly:holly ../netdaemonout/
	rm -rf ../netdaemonout
	cp -R out/ ../netdaemonout/
	rm -rf out
	sudo chown -R holly:holly ../netdaemonout/

bp: build publish

gbp: generate build publish

gdp: generate dev publish

update: dotnet tool update -g NetDaemon.HassModel.CodeGen
