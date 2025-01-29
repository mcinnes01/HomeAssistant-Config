.PHONY: build

generate:
	nd-codegen -o HomeAssistantGenerated.cs

clean:
	rm -rf bin obj out
	dotnet clean

build:
	dotnet publish -c Release -o out

dev:
	dotnet publish -c Development -o out

publish:
	test -d ../netdaemonout && sudo chown -R holly:holly ../netdaemonout/ || true
	test -d ../netdaemonout && rm -rf ../netdaemonout || true
	cp -R out/ ../netdaemonout/
	mkdir ../netdaemonout/logs
	rm -rf out
	sudo chown -R holly:holly ../netdaemonout/

bp: build publish

gbp: generate clean build publish

gdp: generate clean dev publish

update: dotnet tool update -g NetDaemon.HassModel.CodeGen
