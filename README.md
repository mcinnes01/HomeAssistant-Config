# Home Assistant Config

Work in progress

## Light control
Most lights are now migrated under Netdaemon, currently they have there own individual logic per light. The aim is to write a more generic LightApp implementation that I can pass parameters in such as the light entity, an array of motion triggers, time thresholds etc.

A few lights are still using entity controller in HA, these need removing.

## Switches
Currently some of the zigbee switches I'm using are using blueprints in HA, this is convenient for now, but ideally these need to move in to ND.

## Climate
I have three Nest learning thermostats, these really suck, especially the lack of an API for hot water control. I need to rewrite the code I had via the old homekit addons that allowed me to do this, but I can redo this in ND for the time being. However it looks like the old works with nest will be switched off later this year, so not sure how long that will work for. Despite being a very simple API google have not added partity in their new SDM API, although in fairness neither did Nest on their public API. Possibly a reason to replace them, also the connectivity with thread to heat link is patchy at best and this can result in hot water schedules being missed. A better option would bo to go to my original idea which heatmiser.

The shed UFH is running on Meross and I've setup the local mode. Sadly this has recently stopped working in that in is not being provided via homekit any more. Something to investigate.

## Tracking
People tracking is done using the HA companion, I also have some tile devices. The companion is pretty good as long as it's running in the background, especially on the iPhone. IPhone update frequency is patchy at best sadly and Tile is worse still. Using the iCloud integration to get the apple watch tracking and battery too.
