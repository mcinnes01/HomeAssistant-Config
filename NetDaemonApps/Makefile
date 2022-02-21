.PHONY: build 

generate:
	cd /usr/share/hassio/homeassistant/NetDaemonApps
	nd-codegen -o apps/HomeAssistantGenerated.cs

build:
	cd /usr/share/hassio/homeassistant/NetDaemonApps
	dotnet build -c Release
	dotnet publish -c Release -o out

publish:
	cd /usr/share/hassio/homeassistant/NetDaemonApps
	rm -rf ../netdaemon3
	cp -R out/ ../netdaemon3/
	rm -rf out