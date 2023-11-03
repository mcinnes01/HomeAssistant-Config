.PHONY: build

generate:
	cd NetDaemonApps && nd-codegen -o HomeAssistantGenerated.cs && cd ../

build:
	dotnet publish NetDaemonApps -c Release -o NetDaemonApps/out

publish:
	rm -rf netdaemon4
	cp -R out/ netdaemon4/
	mkdir -p netdaemon4/apps
	rm -rf out

gbp: generate build publish

update:
	dotnet tool update -g NetDaemon.HassModel.CodeGen --prerelease