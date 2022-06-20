using System;
using System.Collections.Generic;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using System.Text.Json.Serialization;

namespace HomeAssistantGenerated
{
	public interface IEntities
	{
		AlarmControlPanelEntities AlarmControlPanel { get; }

		AutomationEntities Automation { get; }

		BinarySensorEntities BinarySensor { get; }

		ButtonEntities Button { get; }

		CalendarEntities Calendar { get; }

		CameraEntities Camera { get; }

		ClimateEntities Climate { get; }

		DeviceTrackerEntities DeviceTracker { get; }

		EntityControllerEntities EntityController { get; }

		FanEntities Fan { get; }

		GroupEntities Group { get; }

		InputBooleanEntities InputBoolean { get; }

		InputSelectEntities InputSelect { get; }

		LightEntities Light { get; }

		MediaPlayerEntities MediaPlayer { get; }

		NumberEntities Number { get; }

		PersonEntities Person { get; }

		RemoteEntities Remote { get; }

		SceneEntities Scene { get; }

		ScriptEntities Script { get; }

		SelectEntities Select { get; }

		SensorEntities Sensor { get; }

		SunEntities Sun { get; }

		SwitchEntities Switch { get; }

		TimerEntities Timer { get; }

		UpdateEntities Update { get; }

		VacuumEntities Vacuum { get; }

		WeatherEntities Weather { get; }

		ZoneEntities Zone { get; }
	}

	public class Entities : IEntities
	{
		private readonly IHaContext _haContext;
		public Entities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AlarmControlPanelEntities AlarmControlPanel => new(_haContext);
		public AutomationEntities Automation => new(_haContext);
		public BinarySensorEntities BinarySensor => new(_haContext);
		public ButtonEntities Button => new(_haContext);
		public CalendarEntities Calendar => new(_haContext);
		public CameraEntities Camera => new(_haContext);
		public ClimateEntities Climate => new(_haContext);
		public DeviceTrackerEntities DeviceTracker => new(_haContext);
		public EntityControllerEntities EntityController => new(_haContext);
		public FanEntities Fan => new(_haContext);
		public GroupEntities Group => new(_haContext);
		public InputBooleanEntities InputBoolean => new(_haContext);
		public InputSelectEntities InputSelect => new(_haContext);
		public LightEntities Light => new(_haContext);
		public MediaPlayerEntities MediaPlayer => new(_haContext);
		public NumberEntities Number => new(_haContext);
		public PersonEntities Person => new(_haContext);
		public RemoteEntities Remote => new(_haContext);
		public SceneEntities Scene => new(_haContext);
		public ScriptEntities Script => new(_haContext);
		public SelectEntities Select => new(_haContext);
		public SensorEntities Sensor => new(_haContext);
		public SunEntities Sun => new(_haContext);
		public SwitchEntities Switch => new(_haContext);
		public TimerEntities Timer => new(_haContext);
		public UpdateEntities Update => new(_haContext);
		public VacuumEntities Vacuum => new(_haContext);
		public WeatherEntities Weather => new(_haContext);
		public ZoneEntities Zone => new(_haContext);
	}

	public class AlarmControlPanelEntities
	{
		private readonly IHaContext _haContext;
		public AlarmControlPanelEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Alarm</summary>
		public AlarmControlPanelEntity Alarm => new(_haContext, "alarm_control_panel.alarm");
	}

	public class AutomationEntities
	{
		private readonly IHaContext _haContext;
		public AutomationEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Ambiance To Day When Out of Bed</summary>
		public AutomationEntity AmbianceToDay => new(_haContext, "automation.ambiance_to_day");
		///<summary>Ambiance to Day after 9am on a week day</summary>
		public AutomationEntity AmbianceToDayAfter9amOnAWeekDay => new(_haContext, "automation.ambiance_to_day_after_9am_on_a_week_day");
		///<summary>Ambiance to Day at 12pm at the weekend</summary>
		public AutomationEntity AmbianceToDayAt12pmAtTheWeekend => new(_haContext, "automation.ambiance_to_day_at_12pm_at_the_weekend");
		///<summary>Ambiance to Night after 1am on a week day</summary>
		public AutomationEntity AmbianceToNightAfter1amOnAWeekDay => new(_haContext, "automation.ambiance_to_night_after_1am_on_a_week_day");
		///<summary>Ambiance To Night When In Bed</summary>
		public AutomationEntity AmbianceToNightWhenInBed => new(_haContext, "automation.ambiance_to_night_when_in_bed");
		///<summary>Andy is home</summary>
		public AutomationEntity AndyIsHome => new(_haContext, "automation.andy_is_home");
		///<summary>Patio door is open</summary>
		public AutomationEntity BackDoorIsOpen => new(_haContext, "automation.back_door_is_open");
		///<summary>Back Door Light Constrained</summary>
		public AutomationEntity BackDoorLightConstrained => new(_haContext, "automation.back_door_light_constrained");
		///<summary>Basement Hall Light Constrained</summary>
		public AutomationEntity BasementHallLightConstrained => new(_haContext, "automation.basement_hall_light_constrained");
		///<summary>Bathroom Light Constrained</summary>
		public AutomationEntity BathroomLightConstrained => new(_haContext, "automation.bathroom_light_constrained");
		///<summary>Bathroom Occupancy</summary>
		public AutomationEntity BathroomOccupancy => new(_haContext, "automation.bathroom_occupancy");
		///<summary>Out of bed</summary>
		public AutomationEntity BedSensorSetsInBedToOff => new(_haContext, "automation.bed_sensor_sets_in_bed_to_off");
		///<summary>In bed</summary>
		public AutomationEntity BedSensorSetsInBedToOn => new(_haContext, "automation.bed_sensor_sets_in_bed_to_on");
		///<summary>Bedside Lamp Constrained</summary>
		public AutomationEntity BedroomLampConstrained => new(_haContext, "automation.bedroom_lamp_constrained");
		///<summary>Bedroom Light Constrained</summary>
		public AutomationEntity BedroomLightConstrained => new(_haContext, "automation.bedroom_light_constrained");
		///<summary>Bedroom Lights Off Reset Mode</summary>
		public AutomationEntity BedroomLightsOffResetMode => new(_haContext, "automation.bedroom_lights_off_reset_mode");
		///<summary>Claire is home</summary>
		public AutomationEntity ClaireIsHome => new(_haContext, "automation.claire_is_home");
		///<summary>Dining Room Light Constrained</summary>
		public AutomationEntity DiningRoomLightConstrained => new(_haContext, "automation.dining_room_light_constrained");
		///<summary>Doorbell Notifications</summary>
		public AutomationEntity DoorbellNotifications => new(_haContext, "automation.doorbell_notifications");
		///<summary>Bookshelf Light Constrained</summary>
		public AutomationEntity DrawingRoomLampConstrained => new(_haContext, "automation.drawing_room_lamp_constrained");
		///<summary>Drawing Room Light Constrained</summary>
		public AutomationEntity DrawingRoomLightConstrained => new(_haContext, "automation.drawing_room_light_constrained");
		///<summary>Dressing Room Constrained</summary>
		public AutomationEntity DressingRoomConstrained => new(_haContext, "automation.dressing_room_constrained");
		///<summary>Electric Cabinet Occupancy</summary>
		public AutomationEntity ElectricCabinetOccupancy => new(_haContext, "automation.electric_cabinet_occupancy");
		///<summary>Feed Cats</summary>
		public AutomationEntity FeedCats => new(_haContext, "automation.feed_cats");
		///<summary>Floor Lamp Constrained</summary>
		public AutomationEntity FloorLampConstrained => new(_haContext, "automation.floor_lamp_constrained");
		///<summary>Front door closed after sunset</summary>
		public AutomationEntity FrontDoorClosedAfterSunset => new(_haContext, "automation.front_door_closed_after_sunset");
		///<summary>Front door open after sunset</summary>
		public AutomationEntity FrontDoorOpenAfterSunset => new(_haContext, "automation.front_door_open_after_sunset");
		///<summary>Guest Room Light Constrained</summary>
		public AutomationEntity GuestRoomLightConstrained => new(_haContext, "automation.guest_room_light_constrained");
		///<summary>Hallway Lamp Constrained</summary>
		public AutomationEntity HallwayLampConstrained => new(_haContext, "automation.hallway_lamp_constrained");
		///<summary>Hallway Light Constrained</summary>
		public AutomationEntity HallwayLightConstrained => new(_haContext, "automation.hallway_light_constrained");
		///<summary>Breakfast Bar Lamp Constrained</summary>
		public AutomationEntity KitchenLampConstrained => new(_haContext, "automation.kitchen_lamp_constrained");
		///<summary>Kitchen Light Constrained</summary>
		public AutomationEntity KitchenLightConstrained => new(_haContext, "automation.kitchen_light_constrained");
		///<summary>Patio person motion event snapshot - Andy iPhone</summary>
		public AutomationEntity KitchenMotionEventSnapshot => new(_haContext, "automation.kitchen_motion_event_snapshot");
		///<summary>Loft hatch closed</summary>
		public AutomationEntity LoftHatchClosed => new(_haContext, "automation.loft_hatch_closed");
		///<summary>Loft hatch open</summary>
		public AutomationEntity LoftHatchOpen => new(_haContext, "automation.loft_hatch_open");
		///<summary>Lounge Corner Lamp Constrained</summary>
		public AutomationEntity LoungeLampConstrained => new(_haContext, "automation.lounge_lamp_constrained");
		///<summary>Lounge Light Constrained</summary>
		public AutomationEntity LoungeLightConstrained => new(_haContext, "automation.lounge_light_constrained");
		///<summary>Lounge Lights Off Reset Mode</summary>
		public AutomationEntity LoungeLightsOffResetMode => new(_haContext, "automation.lounge_lights_off_reset_mode");
		///<summary>Lounge Motion Lighting</summary>
		public AutomationEntity LoungeMotionLighting => new(_haContext, "automation.lounge_motion_lighting");
		///<summary>Lounge Scene Watch Television</summary>
		public AutomationEntity LoungeSceneWatchTelevision2 => new(_haContext, "automation.lounge_scene_watch_television_2");
		///<summary>Low battery level detection & notification for all battery sensors</summary>
		public AutomationEntity LowBatteryLevelDetectionNotificationForAllBatterySensors => new(_haContext, "automation.low_battery_level_detection_notification_for_all_battery_sensors");
		///<summary>Mirror Light Constrained</summary>
		public AutomationEntity MirrorLightConstrained => new(_haContext, "automation.mirror_light_constrained");
		///<summary>Cellar Door Motion Detected</summary>
		public AutomationEntity PatioMotionDetected => new(_haContext, "automation.patio_motion_detected");
		///<summary>Patio person motion event snapshot - Claire iPhone</summary>
		public AutomationEntity PatioPersonMotionEventSnapshotClaireIphone => new(_haContext, "automation.patio_person_motion_event_snapshot_claire_iphone");
		///<summary>Send notification when alarm is Armed in Away mode</summary>
		public AutomationEntity SendNotificationWhenAlarmIsArmedInAwayMode => new(_haContext, "automation.send_notification_when_alarm_is_armed_in_away_mode");
		///<summary>Send notification when alarm is Armed in Home mode</summary>
		public AutomationEntity SendNotificationWhenAlarmIsArmedInHomeMode => new(_haContext, "automation.send_notification_when_alarm_is_armed_in_home_mode");
		///<summary>Send notification when alarm is arming</summary>
		public AutomationEntity SendNotificationWhenAlarmIsArming => new(_haContext, "automation.send_notification_when_alarm_is_arming");
		///<summary>Turn Off Ex Machina lights when alarm disarmed</summary>
		public AutomationEntity SendNotificationWhenAlarmIsDisarmed => new(_haContext, "automation.send_notification_when_alarm_is_disarmed");
		///<summary>Send notification when alarm is Disarmed</summary>
		public AutomationEntity SendNotificationWhenAlarmIsDisarmed2 => new(_haContext, "automation.send_notification_when_alarm_is_disarmed_2");
		///<summary>Send notification when alarm is pending</summary>
		public AutomationEntity SendNotificationWhenAlarmIsPending => new(_haContext, "automation.send_notification_when_alarm_is_pending");
		///<summary>Send notification when alarm triggered</summary>
		public AutomationEntity SendNotificationWhenAlarmTriggered2 => new(_haContext, "automation.send_notification_when_alarm_triggered_2");
		///<summary>Ambience to Evening</summary>
		public AutomationEntity SetAmbienceToEvening => new(_haContext, "automation.set_ambience_to_evening");
		///<summary>Set cat feeder varaibles on restart</summary>
		public AutomationEntity SetCatFeederVaraiblesOnRestart => new(_haContext, "automation.set_cat_feeder_varaibles_on_restart");
		///<summary>Shower timer finished</summary>
		public AutomationEntity ShowerTimerFinished => new(_haContext, "automation.shower_timer_finished");
		///<summary>Shower timer start</summary>
		public AutomationEntity ShowerTimerStart => new(_haContext, "automation.shower_timer_start");
		///<summary>Snug Lights Off Reset Mode</summary>
		public AutomationEntity SnugLightsOffResetMode => new(_haContext, "automation.snug_lights_off_reset_mode");
		///<summary>Snug Scene Normal</summary>
		public AutomationEntity SnugSceneNormal => new(_haContext, "automation.snug_scene_normal");
		///<summary>Snug Scene Watch Movie</summary>
		public AutomationEntity SnugSceneWatchMovie => new(_haContext, "automation.snug_scene_watch_movie");
		///<summary>Snug Switch Actions</summary>
		public AutomationEntity SnugSwitchActions => new(_haContext, "automation.snug_switch_actions");
		///<summary>Studio Light Constrained</summary>
		public AutomationEntity StudioLightConstrained => new(_haContext, "automation.studio_light_constrained");
		///<summary>Sump Alarm Triggered</summary>
		public AutomationEntity SumpAlarmTriggered => new(_haContext, "automation.sump_alarm_triggered");
		///<summary>Turn on back door light when car or person detected or back door is open</summary>
		public AutomationEntity TestPatioMotionOverride => new(_haContext, "automation.test_patio_motion_override");
		///<summary>Toilet Light Constrained</summary>
		public AutomationEntity ToiletLightConstrained => new(_haContext, "automation.toilet_light_constrained");
		///<summary>Toilet Occupancy</summary>
		public AutomationEntity ToiletOccupancy => new(_haContext, "automation.toilet_occupancy");
		///<summary>Trigger alarm while armed away</summary>
		public AutomationEntity TriggerAlarmWhileArmedAway => new(_haContext, "automation.trigger_alarm_while_armed_away");
		///<summary>Turn off back door light when no detection or door is shut</summary>
		public AutomationEntity TurnOffBackDoorLightWhenNoDetection => new(_haContext, "automation.turn_off_back_door_light_when_no_detection");
		///<summary>Turn off basement hall light when electric cabinet door closed</summary>
		public AutomationEntity TurnOffBasementHallLightWhenElectricCabinetDoorClosed => new(_haContext, "automation.turn_off_basement_hall_light_when_electric_cabinet_door_closed");
		///<summary>Turn on basement hall lights when electric cabinet door is open</summary>
		public AutomationEntity TurnOnBasementHallLightsWhenElectricCabinetDoorIsOpen => new(_haContext, "automation.turn_on_basement_hall_lights_when_electric_cabinet_door_is_open");
		///<summary>Turn On Ex Machina lights when alarm triggered</summary>
		public AutomationEntity TurnOnExMachinaLightsWhenAlarmTriggered => new(_haContext, "automation.turn_on_ex_machina_lights_when_alarm_triggered");
		///<summary>Turn Off Porch Light at 11pm</summary>
		public AutomationEntity TurnPorchLightOfAt11pm => new(_haContext, "automation.turn_porch_light_of_at_11pm");
		///<summary>Turn On Porch Light when Sun is set</summary>
		public AutomationEntity TurnPorchLightOnWhenSunIsSet => new(_haContext, "automation.turn_porch_light_on_when_sun_is_set");
		///<summary>Utility Room Light Constrained</summary>
		public AutomationEntity UtilityRoomLightConstrained => new(_haContext, "automation.utility_room_light_constrained");
	}

	public class BinarySensorEntities
	{
		private readonly IHaContext _haContext;
		public BinarySensorEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Andy's iPhone Focus</summary>
		public BinarySensorEntity AndySIphoneFocus => new(_haContext, "binary_sensor.andy_s_iphone_focus");
		///<summary>At Home</summary>
		public BinarySensorEntity AtHome => new(_haContext, "binary_sensor.at_home");
		///<summary>Backups Stale</summary>
		public BinarySensorEntity BackupsStale => new(_haContext, "binary_sensor.backups_stale");
		///<summary>Basement Hall Camera Is Dark</summary>
		public BinarySensorEntity BasementHallCameraIsDark => new(_haContext, "binary_sensor.basement_hall_camera_is_dark");
		///<summary>Basement Hall Camera Motion</summary>
		public BinarySensorEntity BasementHallCameraMotion => new(_haContext, "binary_sensor.basement_hall_camera_motion");
		///<summary>Basment Hall Motion</summary>
		public BinarySensorEntity BasementHallMotion => new(_haContext, "binary_sensor.basement_hall_motion");
		///<summary>Basement Hall Motion Sensors</summary>
		public BinarySensorEntity BasementHallMotionSensors => new(_haContext, "binary_sensor.basement_hall_motion_sensors");
		///<summary>Basement Stairs Motion</summary>
		public BinarySensorEntity BasementStairsMotion => new(_haContext, "binary_sensor.basement_stairs_motion");
		///<summary>Basement Stairs Motion battery low</summary>
		public BinarySensorEntity BasementStairsMotionBatteryLow => new(_haContext, "binary_sensor.basement_stairs_motion_battery_low");
		///<summary>Basement Stairs Motion Konnected</summary>
		public BinarySensorEntity BasementStairsMotionKonnected => new(_haContext, "binary_sensor.basement_stairs_motion_konnected");
		///<summary>Basement Stairs Motion tamper</summary>
		public BinarySensorEntity BasementStairsMotionTamper => new(_haContext, "binary_sensor.basement_stairs_motion_tamper");
		///<summary>Basement Thermostat fan</summary>
		public BinarySensorEntity BasementThermostatFan => new(_haContext, "binary_sensor.basement_thermostat_fan");
		///<summary>Basement Thermostat has leaf</summary>
		public BinarySensorEntity BasementThermostatHasLeaf => new(_haContext, "binary_sensor.basement_thermostat_has_leaf");
		///<summary>Basement Thermostat is locked</summary>
		public BinarySensorEntity BasementThermostatIsLocked => new(_haContext, "binary_sensor.basement_thermostat_is_locked");
		///<summary>Basement Thermostat is using emergency heat</summary>
		public BinarySensorEntity BasementThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.basement_thermostat_is_using_emergency_heat");
		///<summary>Basement Thermostat online</summary>
		public BinarySensorEntity BasementThermostatOnline => new(_haContext, "binary_sensor.basement_thermostat_online");
		///<summary>Bathroom Door</summary>
		public BinarySensorEntity BathroomDoor => new(_haContext, "binary_sensor.bathroom_door");
		///<summary>Bathroom Door battery low</summary>
		public BinarySensorEntity BathroomDoorBatteryLow => new(_haContext, "binary_sensor.bathroom_door_battery_low");
		///<summary>Bathroom Motion</summary>
		public BinarySensorEntity BathroomMotion => new(_haContext, "binary_sensor.bathroom_motion");
		///<summary>Bathroom Occupancy</summary>
		public BinarySensorEntity BathroomWasp => new(_haContext, "binary_sensor.bathroom_wasp");
		///<summary>Bedroom Motion</summary>
		public BinarySensorEntity BedroomMotion => new(_haContext, "binary_sensor.bedroom_motion");
		///<summary>Cellar Door</summary>
		public BinarySensorEntity CellarDoor => new(_haContext, "binary_sensor.cellar_door");
		///<summary>Claire’s iPhone Focus</summary>
		public BinarySensorEntity ClairesIphoneFocus => new(_haContext, "binary_sensor.claires_iphone_focus");
		///<summary>Dining Room Motion</summary>
		public BinarySensorEntity DiningRoomMotion => new(_haContext, "binary_sensor.dining_room_motion");
		///<summary>Dispenser Rotating</summary>
		public BinarySensorEntity DispenserRotating => new(_haContext, "binary_sensor.dispenser_rotating");
		///<summary>Doorbell Button</summary>
		public BinarySensorEntity DoorbellButton => new(_haContext, "binary_sensor.doorbell_button");
		///<summary>Downstairs Thermostat fan</summary>
		public BinarySensorEntity DownstairsThermostatFan => new(_haContext, "binary_sensor.downstairs_thermostat_fan");
		///<summary>Downstairs Thermostat has leaf</summary>
		public BinarySensorEntity DownstairsThermostatHasLeaf => new(_haContext, "binary_sensor.downstairs_thermostat_has_leaf");
		///<summary>Downstairs Thermostat is locked</summary>
		public BinarySensorEntity DownstairsThermostatIsLocked => new(_haContext, "binary_sensor.downstairs_thermostat_is_locked");
		///<summary>Downstairs Thermostat is using emergency heat</summary>
		public BinarySensorEntity DownstairsThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.downstairs_thermostat_is_using_emergency_heat");
		///<summary>Downstairs Thermostat online</summary>
		public BinarySensorEntity DownstairsThermostatOnline => new(_haContext, "binary_sensor.downstairs_thermostat_online");
		///<summary>Drawing Room Motion</summary>
		public BinarySensorEntity DrawingRoomMotion => new(_haContext, "binary_sensor.drawing_room_motion");
		///<summary>Dressing Room Motion</summary>
		public BinarySensorEntity DressingRoomMotion => new(_haContext, "binary_sensor.dressing_room_motion");
		///<summary>Electric Cabinet Door battery low</summary>
		public BinarySensorEntity ElectricCabinetDoorBatteryLow => new(_haContext, "binary_sensor.electric_cabinet_door_battery_low");
		///<summary>Electric Cabinet Door contact</summary>
		public BinarySensorEntity ElectricCabinetDoorContact => new(_haContext, "binary_sensor.electric_cabinet_door_contact");
		///<summary>ESPresense Bedroom</summary>
		public BinarySensorEntity EspresenseBedroom => new(_haContext, "binary_sensor.espresense_bedroom");
		///<summary>ESPresense DrawingRoom</summary>
		public BinarySensorEntity EspresenseDrawingroom => new(_haContext, "binary_sensor.espresense_drawingroom");
		///<summary>ESPresense Kitchen</summary>
		public BinarySensorEntity EspresenseKitchen => new(_haContext, "binary_sensor.espresense_kitchen");
		///<summary>ESPresense Lounge</summary>
		public BinarySensorEntity EspresenseLounge => new(_haContext, "binary_sensor.espresense_lounge");
		///<summary>ESPresense Snug</summary>
		public BinarySensorEntity EspresenseSnug => new(_haContext, "binary_sensor.espresense_snug");
		///<summary>ESPresense Studio</summary>
		public BinarySensorEntity EspresenseStudio => new(_haContext, "binary_sensor.espresense_studio");
		///<summary>eWeLink Smart Home: Update Available</summary>
		public BinarySensorEntity EwelinkSmartHomeUpdateAvailable => new(_haContext, "binary_sensor.ewelink_smart_home_update_available");
		///<summary>Front Door battery low</summary>
		public BinarySensorEntity FrontDoorBatteryLow => new(_haContext, "binary_sensor.front_door_battery_low");
		///<summary>Front Door contact</summary>
		public BinarySensorEntity FrontDoorContact => new(_haContext, "binary_sensor.front_door_contact");
		///<summary>Guest Room Motion</summary>
		public BinarySensorEntity GuestRoomMotion => new(_haContext, "binary_sensor.guest_room_motion");
		///<summary>homeassistant</summary>
		public BinarySensorEntity Homeassistant => new(_haContext, "binary_sensor.homeassistant");
		///<summary>In Bed</summary>
		public BinarySensorEntity InBed => new(_haContext, "binary_sensor.in_bed");
		///<summary>Kitchen Camera Is Dark</summary>
		public BinarySensorEntity KitchenCameraIsDark => new(_haContext, "binary_sensor.kitchen_camera_is_dark");
		///<summary>Kitchen Camera Motion</summary>
		public BinarySensorEntity KitchenCameraMotion => new(_haContext, "binary_sensor.kitchen_camera_motion");
		///<summary>Kitchen Motion</summary>
		public BinarySensorEntity KitchenMotion => new(_haContext, "binary_sensor.kitchen_motion");
		///<summary>Kitchen Motion Sensors</summary>
		public BinarySensorEntity KitchenMotionSensors => new(_haContext, "binary_sensor.kitchen_motion_sensors");
		///<summary>Landing Motion</summary>
		public BinarySensorEntity LandingMotion => new(_haContext, "binary_sensor.landing_motion");
		///<summary>Loft Hatch battery low</summary>
		public BinarySensorEntity LoftHatchBatteryLow => new(_haContext, "binary_sensor.loft_hatch_battery_low");
		///<summary>Loft Hatch contact</summary>
		public BinarySensorEntity LoftHatchContact => new(_haContext, "binary_sensor.loft_hatch_contact");
		///<summary>Lounge Motion</summary>
		public BinarySensorEntity LoungeMotion => new(_haContext, "binary_sensor.lounge_motion");
		///<summary>Manchester Road away</summary>
		public BinarySensorEntity ManchesterRoadAway => new(_haContext, "binary_sensor.manchester_road_away");
		///<summary>Patio Camera Is Dark</summary>
		public BinarySensorEntity PatioCameraIsDark => new(_haContext, "binary_sensor.patio_camera_is_dark");
		///<summary>Patio Camera Motion</summary>
		public BinarySensorEntity PatioCameraMotion => new(_haContext, "binary_sensor.patio_camera_motion");
		///<summary>Patio Door</summary>
		public BinarySensorEntity PatioDoor => new(_haContext, "binary_sensor.patio_door");
		///<summary>Remote UI</summary>
		public BinarySensorEntity RemoteUi => new(_haContext, "binary_sensor.remote_ui");
		///<summary>Snug Motion</summary>
		public BinarySensorEntity SnugMotion => new(_haContext, "binary_sensor.snug_motion");
		///<summary>Sonoff Bridge 1 Button1</summary>
		public BinarySensorEntity SonoffBridge1Button1 => new(_haContext, "binary_sensor.sonoff_bridge_1_button1");
		///<summary>Studio Motion</summary>
		public BinarySensorEntity StudioMotion => new(_haContext, "binary_sensor.studio_motion");
		///<summary>Sump Alarm Trigger</summary>
		public BinarySensorEntity SumpAlarmTrigger => new(_haContext, "binary_sensor.sump_alarm_trigger");
		///<summary>Toilet Door</summary>
		public BinarySensorEntity ToiletDoor => new(_haContext, "binary_sensor.toilet_door");
		///<summary>Toilet Door battery low</summary>
		public BinarySensorEntity ToiletDoorBatteryLow => new(_haContext, "binary_sensor.toilet_door_battery_low");
		///<summary>Toilet Motion</summary>
		public BinarySensorEntity ToiletMotion => new(_haContext, "binary_sensor.toilet_motion");
		///<summary>Toilet Occupancy</summary>
		public BinarySensorEntity ToiletWasp => new(_haContext, "binary_sensor.toilet_wasp");
		///<summary>UDMPRO Disk 0 Health</summary>
		public BinarySensorEntity UdmproDisk0Health => new(_haContext, "binary_sensor.udmpro_disk_0_health");
		///<summary>UniFi Dream Machine wan status</summary>
		public BinarySensorEntity UnifiDreamMachineWanStatus => new(_haContext, "binary_sensor.unifi_dream_machine_wan_status");
		///<summary>Updater</summary>
		public BinarySensorEntity Updater => new(_haContext, "binary_sensor.updater");
		///<summary>Upstairs Thermostat fan</summary>
		public BinarySensorEntity UpstairsThermostatFan => new(_haContext, "binary_sensor.upstairs_thermostat_fan");
		///<summary>Upstairs Thermostat has leaf</summary>
		public BinarySensorEntity UpstairsThermostatHasLeaf => new(_haContext, "binary_sensor.upstairs_thermostat_has_leaf");
		///<summary>Upstairs Thermostat is locked</summary>
		public BinarySensorEntity UpstairsThermostatIsLocked => new(_haContext, "binary_sensor.upstairs_thermostat_is_locked");
		///<summary>Upstairs Thermostat is using emergency heat</summary>
		public BinarySensorEntity UpstairsThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.upstairs_thermostat_is_using_emergency_heat");
		///<summary>Upstairs Thermostat online</summary>
		public BinarySensorEntity UpstairsThermostatOnline => new(_haContext, "binary_sensor.upstairs_thermostat_online");
		///<summary>Utility Room Motion</summary>
		public BinarySensorEntity UtilityRoomMotion => new(_haContext, "binary_sensor.utility_room_motion");
		///<summary>Withings in_bed Andy</summary>
		public BinarySensorEntity WithingsInBedAndy => new(_haContext, "binary_sensor.withings_in_bed_andy");
		///<summary>Withings in_bed Claire</summary>
		public BinarySensorEntity WithingsInBedClaire => new(_haContext, "binary_sensor.withings_in_bed_claire");
	}

	public class ButtonEntities
	{
		private readonly IHaContext _haContext;
		public ButtonEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement Hall Camera Reboot Device</summary>
		public ButtonEntity BasementHallCameraRebootDevice => new(_haContext, "button.basement_hall_camera_reboot_device");
		///<summary>ESPresense Bedroom Restart</summary>
		public ButtonEntity EspresenseBedroomRestart => new(_haContext, "button.espresense_bedroom_restart");
		///<summary>ESPresense Kitchen Restart</summary>
		public ButtonEntity EspresenseKitchenRestart => new(_haContext, "button.espresense_kitchen_restart");
		///<summary>ESPresense Lounge Restart</summary>
		public ButtonEntity EspresenseLoungeRestart => new(_haContext, "button.espresense_lounge_restart");
		///<summary>ESPresense Snug Restart</summary>
		public ButtonEntity EspresenseSnugRestart => new(_haContext, "button.espresense_snug_restart");
		///<summary>ONVIF_ICAMERA Reboot</summary>
		public ButtonEntity OnvifIcameraReboot => new(_haContext, "button.onvif_icamera_reboot");
	}

	public class CalendarEntities
	{
		private readonly IHaContext _haContext;
		public CalendarEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Contacts</summary>
		public CalendarEntity Contacts => new(_haContext, "calendar.contacts");
		///<summary>Garbage Collection</summary>
		public CalendarEntity GarbageCollection => new(_haContext, "calendar.garbage_collection");
		///<summary>Holidays in United Kingdom</summary>
		public CalendarEntity HolidaysInUnitedKingdom => new(_haContext, "calendar.holidays_in_united_kingdom");
		///<summary>home.andisoft@gmail.com</summary>
		public CalendarEntity HomeAndisoftGmailCom => new(_haContext, "calendar.home_andisoft_gmail_com");
	}

	public class CameraEntities
	{
		private readonly IHaContext _haContext;
		public CameraEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement Hall Camera Medium</summary>
		public CameraEntity BasementHallCameraMedium => new(_haContext, "camera.basement_hall_camera_medium");
		///<summary>Cellar Door Camera</summary>
		public CameraEntity CellarDoorCamera => new(_haContext, "camera.cellar_door_camera");
		///<summary>Cellar Door Camera</summary>
		public CameraEntity CellarDoorCamera2 => new(_haContext, "camera.cellar_door_camera_2");
		///<summary>Cellar Door Camera Main Stream</summary>
		public CameraEntity CellarDoorCameraMainstream => new(_haContext, "camera.cellar_door_camera_mainstream");
		///<summary>Kitchen Camera Medium</summary>
		public CameraEntity KitchenCameraMedium => new(_haContext, "camera.kitchen_camera_medium");
		///<summary>Mark Cleaning Map</summary>
		public CameraEntity MarkCleaningMap => new(_haContext, "camera.mark_cleaning_map");
		///<summary>Patio Camera Medium</summary>
		public CameraEntity PatioCameraMedium => new(_haContext, "camera.patio_camera_medium");
	}

	public class ClimateEntities
	{
		private readonly IHaContext _haContext;
		public ClimateEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement</summary>
		public ClimateEntity Basement => new(_haContext, "climate.basement");
		///<summary>Basement Thermostat</summary>
		public ClimateEntity BasementThermostat => new(_haContext, "climate.basement_thermostat");
		///<summary>Downstairs</summary>
		public ClimateEntity Downstairs => new(_haContext, "climate.downstairs");
		///<summary>Downstairs Thermostat</summary>
		public ClimateEntity DownstairsThermostat => new(_haContext, "climate.downstairs_thermostat");
		///<summary>Upstairs</summary>
		public ClimateEntity Upstairs => new(_haContext, "climate.upstairs");
		///<summary>Upstairs Thermostat</summary>
		public ClimateEntity UpstairsThermostat => new(_haContext, "climate.upstairs_thermostat");
	}

	public class DeviceTrackerEntities
	{
		private readonly IHaContext _haContext;
		public DeviceTrackerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Andrew’s iPhone iCloud</summary>
		public DeviceTrackerEntity AndrewsIphoneIcloud => new(_haContext, "device_tracker.andrews_iphone_icloud");
		///<summary>Andrew’s iPhone</summary>
		public DeviceTrackerEntity AndrewsIphoneTile => new(_haContext, "device_tracker.andrews_iphone_tile");
		///<summary>Andy's iPhone</summary>
		public DeviceTrackerEntity AndySIphone => new(_haContext, "device_tracker.andy_s_iphone");
		///<summary>Andy's Keys</summary>
		public DeviceTrackerEntity AndysKeys => new(_haContext, "device_tracker.andys_keys");
		///<summary>Basement Hall Camera</summary>
		public DeviceTrackerEntity BasementHallCamera => new(_haContext, "device_tracker.basement_hall_camera");
		///<summary>Car</summary>
		public DeviceTrackerEntity Car => new(_haContext, "device_tracker.car");
		///<summary>Cellar Door Camera</summary>
		public DeviceTrackerEntity CellarDoorCamera => new(_haContext, "device_tracker.cellar_door_camera");
		///<summary>Claire’s Apple Watch iCloud</summary>
		public DeviceTrackerEntity ClairesAppleWatchIcloud => new(_haContext, "device_tracker.claires_apple_watch_icloud");
		///<summary>Claire’s iPhone</summary>
		public DeviceTrackerEntity ClairesIphone => new(_haContext, "device_tracker.claires_iphone");
		///<summary>Claire’s iPhone iCloud</summary>
		public DeviceTrackerEntity ClairesIphoneIcloud => new(_haContext, "device_tracker.claires_iphone_icloud");
		///<summary>Claire’s iPhone</summary>
		public DeviceTrackerEntity ClairesIphoneTile => new(_haContext, "device_tracker.claires_iphone_tile");
		///<summary>Claire's Keys</summary>
		public DeviceTrackerEntity ClairesKeys => new(_haContext, "device_tracker.claires_keys");
		///<summary>Dream Machine Pro</summary>
		public DeviceTrackerEntity DreamMachinePro => new(_haContext, "device_tracker.dream_machine_pro");
		///<summary>ESPHome Cat Feeder</summary>
		public DeviceTrackerEntity EsphomeCatFeeder => new(_haContext, "device_tracker.esphome_cat_feeder");
		///<summary>ESPHome Doorbell</summary>
		public DeviceTrackerEntity EsphomeDoorbell => new(_haContext, "device_tracker.esphome_doorbell");
		///<summary>ESPHome Sump Alarm</summary>
		public DeviceTrackerEntity EsphomeSumpAlarm => new(_haContext, "device_tracker.esphome_sump_alarm");
		///<summary>ESPHome Weather Station</summary>
		public DeviceTrackerEntity EsphomeWeatherStation => new(_haContext, "device_tracker.esphome_weather_station");
		///<summary>espresense-bedroom</summary>
		public DeviceTrackerEntity EspresenseBedroom => new(_haContext, "device_tracker.espresense_bedroom");
		///<summary>espresense-kitchen</summary>
		public DeviceTrackerEntity EspresenseKitchen => new(_haContext, "device_tracker.espresense_kitchen");
		///<summary>espresense-lounge</summary>
		public DeviceTrackerEntity EspresenseLounge => new(_haContext, "device_tracker.espresense_lounge");
		///<summary>espresense-snug</summary>
		public DeviceTrackerEntity EspresenseSnug => new(_haContext, "device_tracker.espresense_snug");
		///<summary>hauser</summary>
		public DeviceTrackerEntity HauserAndy => new(_haContext, "device_tracker.hauser_andy");
		///<summary>hauser</summary>
		public DeviceTrackerEntity HauserClaire => new(_haContext, "device_tracker.hauser_claire");
		///<summary>Kitchen Camera</summary>
		public DeviceTrackerEntity KitchenCamera => new(_haContext, "device_tracker.kitchen_camera");
		///<summary>Konnected Basement</summary>
		public DeviceTrackerEntity KonnectedBasement => new(_haContext, "device_tracker.konnected_basement");
		///<summary>Konnected Downstairs</summary>
		public DeviceTrackerEntity KonnectedDownstairs => new(_haContext, "device_tracker.konnected_downstairs");
		///<summary>Konnected Upstairs</summary>
		public DeviceTrackerEntity KonnectedUpstairs => new(_haContext, "device_tracker.konnected_upstairs");
		///<summary>Patio Camera</summary>
		public DeviceTrackerEntity PatioCamera => new(_haContext, "device_tracker.patio_camera");
		///<summary>Car Key</summary>
		public DeviceTrackerEntity SpareKey => new(_haContext, "device_tracker.spare_key");
		///<summary>UAP-AC-LR-Basement</summary>
		public DeviceTrackerEntity UapAcLrBasement => new(_haContext, "device_tracker.uap_ac_lr_basement");
		///<summary>UAP-AC-LR-Upstairs</summary>
		public DeviceTrackerEntity UapAcLrUpstairs => new(_haContext, "device_tracker.uap_ac_lr_upstairs");
		///<summary>UAP-FlexHD-Groundfloor</summary>
		public DeviceTrackerEntity UapFlexhdGroundfloor => new(_haContext, "device_tracker.uap_flexhd_groundfloor");
		///<summary>UHDIW</summary>
		public DeviceTrackerEntity Uhdiw => new(_haContext, "device_tracker.uhdiw");
	}

	public class EntityControllerEntities
	{
		private readonly IHaContext _haContext;
		public EntityControllerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Snug Floor Lamp Controller</summary>
		public EntityControllerEntity SnugFloorLampController => new(_haContext, "entity_controller.snug_floor_lamp_controller");
		///<summary>Snug Light Controller</summary>
		public EntityControllerEntity SnugLightController => new(_haContext, "entity_controller.snug_light_controller");
	}

	public class FanEntities
	{
		private readonly IHaContext _haContext;
		public FanEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Bathroom Fan</summary>
		public FanEntity BathroomFan => new(_haContext, "fan.bathroom_fan");
		///<summary>Extractor Fan</summary>
		public FanEntity ExtractorFan => new(_haContext, "fan.extractor_fan");
	}

	public class GroupEntities
	{
		private readonly IHaContext _haContext;
		public GroupEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement</summary>
		public GroupEntity Basement => new(_haContext, "group.basement");
		///<summary>Basement Controllers</summary>
		public GroupEntity BasementControllers => new(_haContext, "group.basement_controllers");
		///<summary>Basement Hall</summary>
		public GroupEntity BasementHall => new(_haContext, "group.basement_hall");
		///<summary>Basement Hall Controllers</summary>
		public GroupEntity BasementHallControllers => new(_haContext, "group.basement_hall_controllers");
		///<summary>Basement Hall Overrides</summary>
		public GroupEntity BasementHallOverrides => new(_haContext, "group.basement_hall_overrides");
		///<summary>Basement Overrides</summary>
		public GroupEntity BasementOverrides => new(_haContext, "group.basement_overrides");
		///<summary>Bathroom</summary>
		public GroupEntity Bathroom => new(_haContext, "group.bathroom");
		///<summary>Bathroom Controllers</summary>
		public GroupEntity BathroomControllers => new(_haContext, "group.bathroom_controllers");
		///<summary>Bathroom Overrides</summary>
		public GroupEntity BathroomOverrides => new(_haContext, "group.bathroom_overrides");
		///<summary>Bedroom</summary>
		public GroupEntity Bedroom => new(_haContext, "group.bedroom");
		///<summary>Bedroom Overrides</summary>
		public GroupEntity BedroomOverrides => new(_haContext, "group.bedroom_overrides");
		///<summary>Climate Basement</summary>
		public GroupEntity ClimateBasement => new(_haContext, "group.climate_basement");
		///<summary>Climate Downstairs</summary>
		public GroupEntity ClimateDownstairs => new(_haContext, "group.climate_downstairs");
		///<summary>Climate Upstairs</summary>
		public GroupEntity ClimateUpstairs => new(_haContext, "group.climate_upstairs");
		///<summary>Day Overrides</summary>
		public GroupEntity DayOverrides => new(_haContext, "group.day_overrides");
		///<summary>Dining Room</summary>
		public GroupEntity DiningRoom => new(_haContext, "group.dining_room");
		///<summary>Dining Room Overrides</summary>
		public GroupEntity DiningRoomOverrides => new(_haContext, "group.dining_room_overrides");
		///<summary>Downstairs</summary>
		public GroupEntity Downstairs => new(_haContext, "group.downstairs");
		///<summary>Downstairs Controllers</summary>
		public GroupEntity DownstairsControllers => new(_haContext, "group.downstairs_controllers");
		///<summary>Downstairs Overrides</summary>
		public GroupEntity DownstairsOverrides => new(_haContext, "group.downstairs_overrides");
		///<summary>Drawing Room</summary>
		public GroupEntity DrawingRoom => new(_haContext, "group.drawing_room");
		///<summary>Drawing Room Controllers</summary>
		public GroupEntity DrawingRoomControllers => new(_haContext, "group.drawing_room_controllers");
		///<summary>Drawing Room Overrides</summary>
		public GroupEntity DrawingRoomOverrides => new(_haContext, "group.drawing_room_overrides");
		///<summary>Dressing room</summary>
		public GroupEntity DressingRoom => new(_haContext, "group.dressing_room");
		///<summary>Dressing Room Controllers</summary>
		public GroupEntity DressingRoomControllers => new(_haContext, "group.dressing_room_controllers");
		///<summary>Dressing Room Overrides</summary>
		public GroupEntity DressingRoomOverrides => new(_haContext, "group.dressing_room_overrides");
		///<summary>Electric cabinet</summary>
		public GroupEntity ElectricCabinet => new(_haContext, "group.electric_cabinet");
		///<summary>Entity Controllers</summary>
		public GroupEntity EntityControllers => new(_haContext, "group.entity_controllers");
		///<summary>Entity Overrides</summary>
		public GroupEntity EntityOverrides => new(_haContext, "group.entity_overrides");
		///<summary>Doorbell</summary>
		public GroupEntity EspDoorbell => new(_haContext, "group.esp_doorbell");
		///<summary>Evening Overrides</summary>
		public GroupEntity EveningOverrides => new(_haContext, "group.evening_overrides");
		///<summary>Guest Room</summary>
		public GroupEntity GuestBedroom => new(_haContext, "group.guest_bedroom");
		///<summary>Guest Room Controllers</summary>
		public GroupEntity GuestRoomControllers => new(_haContext, "group.guest_room_controllers");
		///<summary>Guest Room Overrides</summary>
		public GroupEntity GuestRoomOverrides => new(_haContext, "group.guest_room_overrides");
		///<summary>Hallway</summary>
		public GroupEntity Hallway => new(_haContext, "group.hallway");
		///<summary>Hallway Controllers</summary>
		public GroupEntity HallwayControllers => new(_haContext, "group.hallway_controllers");
		///<summary>Hallway Overrides</summary>
		public GroupEntity HallwayOverrides => new(_haContext, "group.hallway_overrides");
		///<summary>Kitchen</summary>
		public GroupEntity Kitchen => new(_haContext, "group.kitchen");
		///<summary>Kitchen Controllers</summary>
		public GroupEntity KitchenControllers => new(_haContext, "group.kitchen_controllers");
		///<summary>Kitchen Overrides</summary>
		public GroupEntity KitchenOverrides => new(_haContext, "group.kitchen_overrides");
		///<summary>Landing</summary>
		public GroupEntity Landing => new(_haContext, "group.landing");
		///<summary>Landing Controllers</summary>
		public GroupEntity LandingControllers => new(_haContext, "group.landing_controllers");
		///<summary>Landing Overrides</summary>
		public GroupEntity LandingOverrides => new(_haContext, "group.landing_overrides");
		///<summary>Lounge</summary>
		public GroupEntity Lounge => new(_haContext, "group.lounge");
		///<summary>Lounge Controllers</summary>
		public GroupEntity LoungeControllers => new(_haContext, "group.lounge_controllers");
		///<summary>Lounge Overrides</summary>
		public GroupEntity LoungeOverrides => new(_haContext, "group.lounge_overrides");
		///<summary>Bedroom Echo Show</summary>
		public GroupEntity MediaBedroomEchoShow => new(_haContext, "group.media_bedroom_echo_show");
		///<summary>Dining Room Echo Input</summary>
		public GroupEntity MediaDiningRoomEchoInput => new(_haContext, "group.media_dining_room_echo_input");
		///<summary>Drawing Room Echo Dot</summary>
		public GroupEntity MediaDrawingRoomEchoDot => new(_haContext, "group.media_drawing_room_echo_dot");
		///<summary>Dressing Room Echo Dot</summary>
		public GroupEntity MediaDressingRoomEchoDot => new(_haContext, "group.media_dressing_room_echo_dot");
		///<summary>Guest Room Echo Show</summary>
		public GroupEntity MediaGuestRoomEchoShow => new(_haContext, "group.media_guest_room_echo_show");
		///<summary>Hallway Tablet</summary>
		public GroupEntity MediaHallwayTablet => new(_haContext, "group.media_hallway_tablet");
		///<summary>Kitchen Echo Show</summary>
		public GroupEntity MediaKitchenEchoShow => new(_haContext, "group.media_kitchen_echo_show");
		///<summary>Landing Tablet</summary>
		public GroupEntity MediaLandingTablet => new(_haContext, "group.media_landing_tablet");
		///<summary>Lounge Echo Plus</summary>
		public GroupEntity MediaLoungeEchoPlus => new(_haContext, "group.media_lounge_echo_plus");
		///<summary>Snug Echo Input</summary>
		public GroupEntity MediaSnugEchoInput => new(_haContext, "group.media_snug_echo_input");
		///<summary>Utility Room Echo Dot</summary>
		public GroupEntity MediaUtilityRoomEchoDot => new(_haContext, "group.media_utility_room_echo_dot");
		///<summary>Night Overrides</summary>
		public GroupEntity NightOverrides => new(_haContext, "group.night_overrides");
		///<summary>Outside</summary>
		public GroupEntity Outside => new(_haContext, "group.outside");
		///<summary>Patio</summary>
		public GroupEntity Patio => new(_haContext, "group.patio");
		///<summary>Person Locations</summary>
		public GroupEntity PersonHomeAway => new(_haContext, "group.person_home_away");
		///<summary>Person Locations</summary>
		public GroupEntity PersonLocations => new(_haContext, "group.person_locations");
		///<summary>Porch</summary>
		public GroupEntity Porch => new(_haContext, "group.porch");
		///<summary>Snug</summary>
		public GroupEntity Snug => new(_haContext, "group.snug");
		///<summary>Snug Controllers</summary>
		public GroupEntity SnugControllers => new(_haContext, "group.snug_controllers");
		///<summary>Snug Overrides</summary>
		public GroupEntity SnugOverrides => new(_haContext, "group.snug_overrides");
		///<summary>Studio</summary>
		public GroupEntity Studio => new(_haContext, "group.studio");
		///<summary>Studio Controllers</summary>
		public GroupEntity StudioControllers => new(_haContext, "group.studio_controllers");
		///<summary>Studio Overrides</summary>
		public GroupEntity StudioOverrides => new(_haContext, "group.studio_overrides");
		///<summary>Toilet</summary>
		public GroupEntity Toilet => new(_haContext, "group.toilet");
		///<summary>Toilet Controllers</summary>
		public GroupEntity ToiletControllers => new(_haContext, "group.toilet_controllers");
		///<summary>Toilet Overrides</summary>
		public GroupEntity ToiletOverrides => new(_haContext, "group.toilet_overrides");
		///<summary>Upstairs</summary>
		public GroupEntity Upstairs => new(_haContext, "group.upstairs");
		///<summary>Upstairs Controllers</summary>
		public GroupEntity UpstairsControllers => new(_haContext, "group.upstairs_controllers");
		///<summary>Upstairs Overrides</summary>
		public GroupEntity UpstairsOverrides => new(_haContext, "group.upstairs_overrides");
		///<summary>Utility Controllers</summary>
		public GroupEntity UtilityControllers => new(_haContext, "group.utility_controllers");
		///<summary>Utility Overrides</summary>
		public GroupEntity UtilityOverrides => new(_haContext, "group.utility_overrides");
		///<summary>Utility Room</summary>
		public GroupEntity UtilityRoom => new(_haContext, "group.utility_room");
	}

	public class InputBooleanEntities
	{
		private readonly IHaContext _haContext;
		public InputBooleanEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Back Door Light Constrained</summary>
		public InputBooleanEntity BackDoorLightConstrained => new(_haContext, "input_boolean.back_door_light_constrained");
		///<summary>Basement Hall Light Constrained</summary>
		public InputBooleanEntity BasementHallLightConstrained => new(_haContext, "input_boolean.basement_hall_light_constrained");
		///<summary>Bathroom Light Constrained</summary>
		public InputBooleanEntity BathroomLightConstrained => new(_haContext, "input_boolean.bathroom_light_constrained");
		///<summary>Bedroom Light Constrained</summary>
		public InputBooleanEntity BedroomLightConstrained => new(_haContext, "input_boolean.bedroom_light_constrained");
		///<summary>Bedside Lamp Constrained</summary>
		public InputBooleanEntity BedsideLampConstrained => new(_haContext, "input_boolean.bedside_lamp_constrained");
		///<summary>Bookshelf Light Constrained</summary>
		public InputBooleanEntity BookshelfLightConstrained => new(_haContext, "input_boolean.bookshelf_light_constrained");
		///<summary>Breakfast Bar Lamp Constrained</summary>
		public InputBooleanEntity BreakfastBarLampConstrained => new(_haContext, "input_boolean.breakfast_bar_lamp_constrained");
		///<summary>Brewery Light Constrained</summary>
		public InputBooleanEntity BreweryLightConstrained => new(_haContext, "input_boolean.brewery_light_constrained");
		///<summary>Dining Room Light Constrained</summary>
		public InputBooleanEntity DiningRoomLightConstrained => new(_haContext, "input_boolean.dining_room_light_constrained");
		///<summary>Disable Next Feed</summary>
		public InputBooleanEntity DisableNextFeed => new(_haContext, "input_boolean.disable_next_feed");
		///<summary>Drawing Room Light Constrained</summary>
		public InputBooleanEntity DrawingRoomLightConstrained => new(_haContext, "input_boolean.drawing_room_light_constrained");
		///<summary>Dressing Room Light Constrained</summary>
		public InputBooleanEntity DressingRoomLightConstrained => new(_haContext, "input_boolean.dressing_room_light_constrained");
		///<summary>Evening Feed Complete</summary>
		public InputBooleanEntity EveningFeedComplete => new(_haContext, "input_boolean.evening_feed_complete");
		///<summary>Evening Feed Enabled</summary>
		public InputBooleanEntity EveningFeedEnabled => new(_haContext, "input_boolean.evening_feed_enabled");
		///<summary>Guest Room Light Constrained</summary>
		public InputBooleanEntity GuestRoomLightConstrained => new(_haContext, "input_boolean.guest_room_light_constrained");
		///<summary>Hallway Lamp Constrained</summary>
		public InputBooleanEntity HallwayLampConstrained => new(_haContext, "input_boolean.hallway_lamp_constrained");
		///<summary>Hallway Light Constrained</summary>
		public InputBooleanEntity HallwayLightConstrained => new(_haContext, "input_boolean.hallway_light_constrained");
		///<summary>In Bed</summary>
		public InputBooleanEntity InBed => new(_haContext, "input_boolean.in_bed");
		///<summary>in_shower</summary>
		public InputBooleanEntity InShower => new(_haContext, "input_boolean.in_shower");
		///<summary>Kitchen Light Constrained</summary>
		public InputBooleanEntity KitchenLightConstrained => new(_haContext, "input_boolean.kitchen_light_constrained");
		///<summary>Landing Light Constrained</summary>
		public InputBooleanEntity LandingLightConstrained => new(_haContext, "input_boolean.landing_light_constrained");
		///<summary>Lounge Corner Lamp Constrained</summary>
		public InputBooleanEntity LoungeCornerLampConstrained => new(_haContext, "input_boolean.lounge_corner_lamp_constrained");
		///<summary>Lounge Floor Lamp Constrained</summary>
		public InputBooleanEntity LoungeFloorLampConstrained => new(_haContext, "input_boolean.lounge_floor_lamp_constrained");
		///<summary>Lounge Light Constrained</summary>
		public InputBooleanEntity LoungeLightConstrained => new(_haContext, "input_boolean.lounge_light_constrained");
		///<summary>Mirror Light Constrained</summary>
		public InputBooleanEntity MirrorLightConstrained => new(_haContext, "input_boolean.mirror_light_constrained");
		///<summary>Morning Feed Complete</summary>
		public InputBooleanEntity MorningFeedComplete => new(_haContext, "input_boolean.morning_feed_complete");
		///<summary>Morning Feed Enabled</summary>
		public InputBooleanEntity MorningFeedEnabled => new(_haContext, "input_boolean.morning_feed_enabled");
		///<summary>netdaemon_basement_basement_lights</summary>
		public InputBooleanEntity NetdaemonBasementBasementLights => new(_haContext, "input_boolean.netdaemon_basement_basement_lights");
		///<summary>netdaemon_downstairs_downstairs_lights</summary>
		public InputBooleanEntity NetdaemonDownstairsDownstairsLights => new(_haContext, "input_boolean.netdaemon_downstairs_downstairs_lights");
		///<summary>netdaemon_house_light_modes</summary>
		public InputBooleanEntity NetdaemonHouseLightModes => new(_haContext, "input_boolean.netdaemon_house_light_modes");
		///<summary>netdaemon_house_state_manager</summary>
		public InputBooleanEntity NetdaemonHouseStateManager => new(_haContext, "input_boolean.netdaemon_house_state_manager");
		///<summary>netdaemon_outside_patio_back_door_light_control</summary>
		public InputBooleanEntity NetdaemonOutsidePatioBackDoorLightControl => new(_haContext, "input_boolean.netdaemon_outside_patio_back_door_light_control");
		///<summary>netdaemon_outside_patio_weather_station_ambient_light</summary>
		public InputBooleanEntity NetdaemonOutsidePatioWeatherStationAmbientLight => new(_haContext, "input_boolean.netdaemon_outside_patio_weather_station_ambient_light");
		///<summary>netdaemon_outside_porch_front_door</summary>
		public InputBooleanEntity NetdaemonOutsidePorchFrontDoor => new(_haContext, "input_boolean.netdaemon_outside_porch_front_door");
		///<summary>netdaemon_upstairs_bedroom_bedroom_mode</summary>
		public InputBooleanEntity NetdaemonUpstairsBedroomBedroomMode => new(_haContext, "input_boolean.netdaemon_upstairs_bedroom_bedroom_mode");
		///<summary>netdaemon_upstairs_bedroom_sleep_analyser</summary>
		public InputBooleanEntity NetdaemonUpstairsBedroomSleepAnalyser => new(_haContext, "input_boolean.netdaemon_upstairs_bedroom_sleep_analyser");
		///<summary>netdaemon_upstairs_upstairs_lights</summary>
		public InputBooleanEntity NetdaemonUpstairsUpstairsLights => new(_haContext, "input_boolean.netdaemon_upstairs_upstairs_lights");
		///<summary>Reload Netdaemon</summary>
		public InputBooleanEntity ReloadNetdaemon => new(_haContext, "input_boolean.reload_netdaemon");
		///<summary>Snug Floor Lamp Constrained</summary>
		public InputBooleanEntity SnugFloorLampConstrained => new(_haContext, "input_boolean.snug_floor_lamp_constrained");
		///<summary>Snug Light Constrained</summary>
		public InputBooleanEntity SnugLightConstrained => new(_haContext, "input_boolean.snug_light_constrained");
		///<summary>Studio Light Constrained</summary>
		public InputBooleanEntity StudioLightConstrained => new(_haContext, "input_boolean.studio_light_constrained");
		///<summary>Toilet Light Constrained</summary>
		public InputBooleanEntity ToiletLightConstrained => new(_haContext, "input_boolean.toilet_light_constrained");
		///<summary>Utility Room Light Constrained</summary>
		public InputBooleanEntity UtilityRoomLightConstrained => new(_haContext, "input_boolean.utility_room_light_constrained");
	}

	public class InputSelectEntities
	{
		private readonly IHaContext _haContext;
		public InputSelectEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Bathroom Mode</summary>
		public InputSelectEntity BathroomMode => new(_haContext, "input_select.bathroom_mode");
		///<summary>Bedroom Mode</summary>
		public InputSelectEntity BedroomMode => new(_haContext, "input_select.bedroom_mode");
		///<summary>Brightness</summary>
		public InputSelectEntity Brightness => new(_haContext, "input_select.brightness");
		///<summary>Light Control Mode</summary>
		public InputSelectEntity LightControlMode => new(_haContext, "input_select.light_control_mode");
		///<summary>Location Mode</summary>
		public InputSelectEntity LocationMode => new(_haContext, "input_select.location_mode");
		///<summary>Lounge Mode</summary>
		public InputSelectEntity LoungeMode => new(_haContext, "input_select.lounge_mode");
		///<summary>Snug Mode</summary>
		public InputSelectEntity SnugMode => new(_haContext, "input_select.snug_mode");
		///<summary>Time Of Day</summary>
		public InputSelectEntity TimeOfDay => new(_haContext, "input_select.time_of_day");
	}

	public class LightEntities
	{
		private readonly IHaContext _haContext;
		public LightEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>All Lights</summary>
		public LightEntity AllLights => new(_haContext, "light.all_lights");
		///<summary>Back Door Light</summary>
		public LightEntity BackDoor => new(_haContext, "light.back_door");
		///<summary>Basement Hall Light</summary>
		public LightEntity BasementHall => new(_haContext, "light.basement_hall");
		///<summary>Basement Hall Lights</summary>
		public LightEntity BasementHallLights => new(_haContext, "light.basement_hall_lights");
		///<summary>Basement Lights</summary>
		public LightEntity BasementLights => new(_haContext, "light.basement_lights");
		///<summary>Basement Stairs</summary>
		public LightEntity BasementStairs => new(_haContext, "light.basement_stairs");
		///<summary>Bathroom Light</summary>
		public LightEntity Bathroom => new(_haContext, "light.bathroom");
		///<summary>Bathroom Lights</summary>
		public LightEntity BathroomLights => new(_haContext, "light.bathroom_lights");
		///<summary>Bedroom Light</summary>
		public LightEntity Bedroom => new(_haContext, "light.bedroom");
		///<summary>Bedroom Lights</summary>
		public LightEntity BedroomLights => new(_haContext, "light.bedroom_lights");
		///<summary>Bedside Lamp</summary>
		public LightEntity BedsideLamp => new(_haContext, "light.bedside_lamp");
		///<summary>Bookshelf Light</summary>
		public LightEntity Bookshelf => new(_haContext, "light.bookshelf");
		///<summary>Breakfast Bar Lamp</summary>
		public LightEntity BreakfastBarLamp => new(_haContext, "light.breakfast_bar_lamp");
		///<summary>Brewery Light</summary>
		public LightEntity Brewery => new(_haContext, "light.brewery");
		///<summary>Cabinet Light</summary>
		public LightEntity Cabinet => new(_haContext, "light.cabinet");
		///<summary>Cellar Door Light</summary>
		public LightEntity CellarDoor => new(_haContext, "light.cellar_door");
		///<summary>Dining Room Light</summary>
		public LightEntity DiningRoom => new(_haContext, "light.dining_room");
		///<summary>Downstairs Lights</summary>
		public LightEntity DownstairsLights => new(_haContext, "light.downstairs_lights");
		///<summary>Drawing Room Light</summary>
		public LightEntity DrawingRoom => new(_haContext, "light.drawing_room");
		///<summary>Drawing Room Lights</summary>
		public LightEntity DrawingRoomLights => new(_haContext, "light.drawing_room_lights");
		///<summary>Dressing Room Light</summary>
		public LightEntity DressingRoom => new(_haContext, "light.dressing_room");
		///<summary>Garden Lights</summary>
		public LightEntity GardenLights => new(_haContext, "light.garden_lights");
		///<summary>Guest Room Light</summary>
		public LightEntity GuestRoom => new(_haContext, "light.guest_room");
		///<summary>Hallway Light</summary>
		public LightEntity Hallway => new(_haContext, "light.hallway");
		///<summary>Hallway Lamp</summary>
		public LightEntity HallwayLamp => new(_haContext, "light.hallway_lamp");
		///<summary>Hallway Lights</summary>
		public LightEntity HallwayLights => new(_haContext, "light.hallway_lights");
		///<summary>Inside Lights</summary>
		public LightEntity InsideLights => new(_haContext, "light.inside_lights");
		///<summary>Inside No Room Control Not Basement</summary>
		public LightEntity InsideNoRoomControlNotBasement => new(_haContext, "light.inside_no_room_control_not_basement");
		///<summary>Kitchen Light</summary>
		public LightEntity Kitchen => new(_haContext, "light.kitchen");
		///<summary>Kitchen Lights</summary>
		public LightEntity KitchenLights => new(_haContext, "light.kitchen_lights");
		///<summary>Landing Light</summary>
		public LightEntity Landing => new(_haContext, "light.landing");
		///<summary>Lounge Light</summary>
		public LightEntity Lounge => new(_haContext, "light.lounge");
		///<summary>Lounge Corner Lamp</summary>
		public LightEntity LoungeCornerLamp => new(_haContext, "light.lounge_corner_lamp");
		///<summary>Lounge Floor Lamp</summary>
		public LightEntity LoungeFloorLamp => new(_haContext, "light.lounge_floor_lamp");
		///<summary>Lounge Lights</summary>
		public LightEntity LoungeLights => new(_haContext, "light.lounge_lights");
		///<summary>Mirror  Light</summary>
		public LightEntity Mirror => new(_haContext, "light.mirror");
		///<summary>Outside Lights</summary>
		public LightEntity OutsideLights => new(_haContext, "light.outside_lights");
		///<summary>Patio Light</summary>
		public LightEntity Patio => new(_haContext, "light.patio");
		///<summary>Patio Lights</summary>
		public LightEntity PatioLights => new(_haContext, "light.patio_lights");
		///<summary>Porch Light</summary>
		public LightEntity Porch => new(_haContext, "light.porch");
		///<summary>Snug Light</summary>
		public LightEntity Snug => new(_haContext, "light.snug");
		///<summary>Snug Floor Lamp</summary>
		public LightEntity SnugFloorLamp => new(_haContext, "light.snug_floor_lamp");
		///<summary>Snug Lights</summary>
		public LightEntity SnugLights => new(_haContext, "light.snug_lights");
		///<summary>Studio Light</summary>
		public LightEntity Studio => new(_haContext, "light.studio");
		///<summary>Toilet Light</summary>
		public LightEntity Toilet => new(_haContext, "light.toilet");
		///<summary>Upstairs Lights</summary>
		public LightEntity UpstairsLights => new(_haContext, "light.upstairs_lights");
		///<summary>Utility Room Light</summary>
		public LightEntity UtilityRoom => new(_haContext, "light.utility_room");
		///<summary>Utility Room Lights</summary>
		public LightEntity UtilityRoomLights => new(_haContext, "light.utility_room_lights");
		///<summary>Without Room Control</summary>
		public LightEntity WithoutRoomControl => new(_haContext, "light.without_room_control");
	}

	public class MediaPlayerEntities
	{
		private readonly IHaContext _haContext;
		public MediaPlayerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>All Speakers</summary>
		public MediaPlayerEntity AllSpeakers => new(_haContext, "media_player.all_speakers");
		///<summary>Andrew's Echo Buds</summary>
		public MediaPlayerEntity AndrewSEchoBuds => new(_haContext, "media_player.andrew_s_echo_buds");
		///<summary>Andrew's Fire TV</summary>
		public MediaPlayerEntity AndrewSFireTv => new(_haContext, "media_player.andrew_s_fire_tv");
		///<summary>Andrew's Samsung TV 2020-U</summary>
		public MediaPlayerEntity AndrewSSamsungTv2020U => new(_haContext, "media_player.andrew_s_samsung_tv_2020_u");
		///<summary>Bedroom Echo Show</summary>
		public MediaPlayerEntity BedroomEchoShow => new(_haContext, "media_player.bedroom_echo_show");
		///<summary>Dining Room Echo Input</summary>
		public MediaPlayerEntity DiningRoomEchoInput => new(_haContext, "media_player.dining_room_echo_input");
		///<summary>Dining Room Radio</summary>
		public MediaPlayerEntity DiningRoomRadio => new(_haContext, "media_player.dining_room_radio");
		///<summary>Downstairs</summary>
		public MediaPlayerEntity Downstairs => new(_haContext, "media_player.downstairs");
		///<summary>Drawing Room Echo Dot</summary>
		public MediaPlayerEntity DrawingRoomEchoDot => new(_haContext, "media_player.drawing_room_echo_dot");
		///<summary>Dressing Room Echo Dot</summary>
		public MediaPlayerEntity DressingRoomEchoDot => new(_haContext, "media_player.dressing_room_echo_dot");
		///<summary>Guest Room Echo Show</summary>
		public MediaPlayerEntity GuestRoomEchoShow => new(_haContext, "media_player.guest_room_echo_show");
		///<summary>Hall Tablet</summary>
		public MediaPlayerEntity HallTablet => new(_haContext, "media_player.hall_tablet");
		///<summary>Kitchen Echo Show</summary>
		public MediaPlayerEntity KitchenEchoShow => new(_haContext, "media_player.kitchen_echo_show");
		///<summary>Landing Tablet</summary>
		public MediaPlayerEntity LandingTablet => new(_haContext, "media_player.landing_tablet");
		///<summary>Lounge Echo Plus</summary>
		public MediaPlayerEntity LoungeEchoPlus => new(_haContext, "media_player.lounge_echo_plus");
		///<summary>Lounge Fire TV</summary>
		public MediaPlayerEntity LoungeFireTv => new(_haContext, "media_player.lounge_fire_tv");
		///<summary>Snug</summary>
		public MediaPlayerEntity Snug => new(_haContext, "media_player.snug");
		///<summary>Snug Echo Input</summary>
		public MediaPlayerEntity SnugEchoInput => new(_haContext, "media_player.snug_echo_input");
		///<summary>Snug Projector</summary>
		public MediaPlayerEntity SnugProjector => new(_haContext, "media_player.snug_projector");
		public MediaPlayerEntity SnugRadio => new(_haContext, "media_player.snug_radio");
		///<summary>Spotify Andrew McInnes</summary>
		public MediaPlayerEntity SpotifyAndrewMcinnes => new(_haContext, "media_player.spotify_andrew_mcinnes");
		///<summary>Upstairs</summary>
		public MediaPlayerEntity Upstairs => new(_haContext, "media_player.upstairs");
		///<summary>Utility Room Echo Dot</summary>
		public MediaPlayerEntity UtilityRoomEchoDot => new(_haContext, "media_player.utility_room_echo_dot");
	}

	public class NumberEntities
	{
		private readonly IHaContext _haContext;
		public NumberEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement Hall Camera Microphone Level</summary>
		public NumberEntity BasementHallCameraMicrophoneLevel => new(_haContext, "number.basement_hall_camera_microphone_level");
		///<summary>ESPresense Bedroom Absorption</summary>
		public NumberEntity EspresenseBedroomAbsorption => new(_haContext, "number.espresense_bedroom_absorption");
		///<summary>ESPresense Bedroom Max Distance</summary>
		public NumberEntity EspresenseBedroomMaxDistance => new(_haContext, "number.espresense_bedroom_max_distance");
		///<summary>ESPresense DrawingRoom Max Distance</summary>
		public NumberEntity EspresenseDrawingroomMaxDistance => new(_haContext, "number.espresense_drawingroom_max_distance");
		///<summary>ESPresense Kitchen Max Distance</summary>
		public NumberEntity EspresenseKitchenMaxDistance => new(_haContext, "number.espresense_kitchen_max_distance");
		///<summary>ESPresense Lounge Absorption</summary>
		public NumberEntity EspresenseLoungeAbsorption => new(_haContext, "number.espresense_lounge_absorption");
		///<summary>ESPresense Lounge Max Distance</summary>
		public NumberEntity EspresenseLoungeMaxDistance => new(_haContext, "number.espresense_lounge_max_distance");
		///<summary>ESPresense Snug Absorption</summary>
		public NumberEntity EspresenseSnugAbsorption => new(_haContext, "number.espresense_snug_absorption");
		///<summary>ESPresense Snug Max Distance</summary>
		public NumberEntity EspresenseSnugMaxDistance => new(_haContext, "number.espresense_snug_max_distance");
		///<summary>ESPresense Studio Max Distance</summary>
		public NumberEntity EspresenseStudioMaxDistance => new(_haContext, "number.espresense_studio_max_distance");
		///<summary>Kitchen Camera Microphone Level</summary>
		public NumberEntity KitchenCameraMicrophoneLevel => new(_haContext, "number.kitchen_camera_microphone_level");
		///<summary>Patio Camera Microphone Level</summary>
		public NumberEntity PatioCameraMicrophoneLevel => new(_haContext, "number.patio_camera_microphone_level");
	}

	public class PersonEntities
	{
		private readonly IHaContext _haContext;
		public PersonEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Andy</summary>
		public PersonEntity Andy => new(_haContext, "person.andy");
		///<summary>Claire</summary>
		public PersonEntity Claire => new(_haContext, "person.claire");
	}

	public class RemoteEntities
	{
		private readonly IHaContext _haContext;
		public RemoteEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Snug Projector</summary>
		public RemoteEntity SnugProjector => new(_haContext, "remote.snug_projector");
	}

	public class SceneEntities
	{
		private readonly IHaContext _haContext;
		public SceneEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Bathroom Normal</summary>
		public SceneEntity BathroomNormal => new(_haContext, "scene.bathroom_normal");
		///<summary>Cleaning</summary>
		public SceneEntity Cleaning => new(_haContext, "scene.cleaning");
		///<summary>Get Ready For Bed</summary>
		public SceneEntity GetReadyForBed => new(_haContext, "scene.get_ready_for_bed");
		///<summary>Get Up</summary>
		public SceneEntity GetUp => new(_haContext, "scene.get_up");
		///<summary>Lighting Ambient</summary>
		public SceneEntity LightingAmbient => new(_haContext, "scene.lighting_ambient");
		///<summary>Lighting Bright</summary>
		public SceneEntity LightingBright => new(_haContext, "scene.lighting_bright");
		///<summary>Lighting Day</summary>
		public SceneEntity LightingDay => new(_haContext, "scene.lighting_day");
		///<summary>Lighting Evening</summary>
		public SceneEntity LightingEvening => new(_haContext, "scene.lighting_evening");
		///<summary>Lighting Night</summary>
		public SceneEntity LightingNight => new(_haContext, "scene.lighting_night");
		///<summary>Lights Up</summary>
		public SceneEntity LightsUp => new(_haContext, "scene.lights_up");
		///<summary>Lounge Normal</summary>
		public SceneEntity LoungeNormal => new(_haContext, "scene.lounge_normal");
		///<summary>Showering</summary>
		public SceneEntity Showering => new(_haContext, "scene.showering");
		///<summary>Watch Movie</summary>
		public SceneEntity WatchMovie => new(_haContext, "scene.watch_movie");
		///<summary>Watch TV</summary>
		public SceneEntity WatchTv => new(_haContext, "scene.watch_tv");
	}

	public class ScriptEntities
	{
		private readonly IHaContext _haContext;
		public ScriptEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Doorbell Alexa</summary>
		public ScriptEntity DoorbellAlexa => new(_haContext, "script.doorbell_alexa");
		///<summary>Entity Controller Reset</summary>
		public ScriptEntity EntityControllerReset => new(_haContext, "script.entity_controller_reset");
		///<summary>Feed Cats</summary>
		public ScriptEntity FeedCats => new(_haContext, "script.feed_cats");
		///<summary>Light Effect Continuous</summary>
		public ScriptEntity LightEffectContinuous => new(_haContext, "script.light_effect_continuous");
		///<summary>Light Effect Timed</summary>
		public ScriptEntity LightEffectTimed => new(_haContext, "script.light_effect_timed");
		///<summary>Notify Alexa Everywhere</summary>
		public ScriptEntity NotifyAlexaEverywhere => new(_haContext, "script.notify_alexa_everywhere");
		///<summary>Notify All</summary>
		public ScriptEntity NotifyAll => new(_haContext, "script.notify_all");
		///<summary>Notify Pushbullet</summary>
		public ScriptEntity NotifyPushbullet => new(_haContext, "script.notify_pushbullet");
		///<summary>Room Controller Reset</summary>
		public ScriptEntity RoomControllerReset => new(_haContext, "script.room_controller_reset");
	}

	public class SelectEntities
	{
		private readonly IHaContext _haContext;
		public SelectEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Basement Hall Camera Infrared Mode</summary>
		public SelectEntity BasementHallCameraInfraredMode => new(_haContext, "select.basement_hall_camera_infrared_mode");
		///<summary>Basement Hall Camera Recording Mode</summary>
		public SelectEntity BasementHallCameraRecordingMode => new(_haContext, "select.basement_hall_camera_recording_mode");
		///<summary>Kitchen Camera Infrared Mode</summary>
		public SelectEntity KitchenCameraInfraredMode => new(_haContext, "select.kitchen_camera_infrared_mode");
		///<summary>Kitchen Camera Recording Mode</summary>
		public SelectEntity KitchenCameraRecordingMode => new(_haContext, "select.kitchen_camera_recording_mode");
		///<summary>Patio Camera Infrared Mode</summary>
		public SelectEntity PatioCameraInfraredMode => new(_haContext, "select.patio_camera_infrared_mode");
		///<summary>Patio Camera Recording Mode</summary>
		public SelectEntity PatioCameraRecordingMode => new(_haContext, "select.patio_camera_recording_mode");
	}

	public class SensorEntities
	{
		private readonly IHaContext _haContext;
		public SensorEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Snug Switch linkquality</summary>
		public NumericSensorEntity E0x00124b00226650a6Linkquality => new(_haContext, "sensor.0x00124b00226650a6_linkquality");
		///<summary>AdGuard Average Processing Speed</summary>
		public NumericSensorEntity AdguardAverageProcessingSpeed => new(_haContext, "sensor.adguard_average_processing_speed");
		///<summary>AdGuard DNS Queries</summary>
		public NumericSensorEntity AdguardDnsQueries => new(_haContext, "sensor.adguard_dns_queries");
		///<summary>AdGuard DNS Queries Blocked</summary>
		public NumericSensorEntity AdguardDnsQueriesBlocked => new(_haContext, "sensor.adguard_dns_queries_blocked");
		///<summary>AdGuard DNS Queries Blocked Ratio</summary>
		public NumericSensorEntity AdguardDnsQueriesBlockedRatio => new(_haContext, "sensor.adguard_dns_queries_blocked_ratio");
		///<summary>AdGuard Parental Control Blocked</summary>
		public NumericSensorEntity AdguardParentalControlBlocked => new(_haContext, "sensor.adguard_parental_control_blocked");
		///<summary>AdGuard Rules Count</summary>
		public NumericSensorEntity AdguardRulesCount => new(_haContext, "sensor.adguard_rules_count");
		///<summary>AdGuard Safe Browsing Blocked</summary>
		public NumericSensorEntity AdguardSafeBrowsingBlocked => new(_haContext, "sensor.adguard_safe_browsing_blocked");
		///<summary>Andrew’s iPhone iCloud battery state</summary>
		public NumericSensorEntity AndrewsIphoneIcloudBatteryState => new(_haContext, "sensor.andrews_iphone_icloud_battery_state");
		///<summary>Andy's iPhone Average Active Pace</summary>
		public NumericSensorEntity AndySIphoneAverageActivePace => new(_haContext, "sensor.andy_s_iphone_average_active_pace");
		///<summary>Andy's iPhone Battery Level</summary>
		public NumericSensorEntity AndySIphoneBatteryLevel => new(_haContext, "sensor.andy_s_iphone_battery_level");
		///<summary>Andy's iPhone Distance</summary>
		public NumericSensorEntity AndySIphoneDistance => new(_haContext, "sensor.andy_s_iphone_distance");
		///<summary>Andy's iPhone Floors Ascended</summary>
		public NumericSensorEntity AndySIphoneFloorsAscended => new(_haContext, "sensor.andy_s_iphone_floors_ascended");
		///<summary>Andy's iPhone Floors Descended</summary>
		public NumericSensorEntity AndySIphoneFloorsDescended => new(_haContext, "sensor.andy_s_iphone_floors_descended");
		///<summary>Andy's iPhone Steps</summary>
		public NumericSensorEntity AndySIphoneSteps => new(_haContext, "sensor.andy_s_iphone_steps");
		///<summary>Andy's iPhone Storage</summary>
		public NumericSensorEntity AndySIphoneStorage => new(_haContext, "sensor.andy_s_iphone_storage");
		///<summary>Basement Hall Camera Disk Write Rate</summary>
		public NumericSensorEntity BasementHallCameraDiskWriteRate => new(_haContext, "sensor.basement_hall_camera_disk_write_rate");
		///<summary>Basement Hall Camera Storage Used</summary>
		public NumericSensorEntity BasementHallCameraStorageUsed => new(_haContext, "sensor.basement_hall_camera_storage_used");
		///<summary>Basement Stairs Motion battery</summary>
		public NumericSensorEntity BasementStairsMotionBattery => new(_haContext, "sensor.basement_stairs_motion_battery");
		///<summary>Basement Stairs Motion linkquality</summary>
		public NumericSensorEntity BasementStairsMotionLinkquality => new(_haContext, "sensor.basement_stairs_motion_linkquality");
		///<summary>Basement Stairs Motion voltage</summary>
		public NumericSensorEntity BasementStairsMotionVoltage => new(_haContext, "sensor.basement_stairs_motion_voltage");
		///<summary>Basement Thermostat humidity</summary>
		public NumericSensorEntity BasementThermostatHumidity => new(_haContext, "sensor.basement_thermostat_humidity");
		///<summary>Basement Thermostat target</summary>
		public NumericSensorEntity BasementThermostatTarget => new(_haContext, "sensor.basement_thermostat_target");
		///<summary>Basement Thermostat temperature</summary>
		public NumericSensorEntity BasementThermostatTemperature => new(_haContext, "sensor.basement_thermostat_temperature");
		///<summary>Bathroom Door battery</summary>
		public NumericSensorEntity BathroomDoorBattery => new(_haContext, "sensor.bathroom_door_battery");
		///<summary>Bathroom Door linkquality</summary>
		public NumericSensorEntity BathroomDoorLinkquality => new(_haContext, "sensor.bathroom_door_linkquality");
		///<summary>Bathroom Door voltage</summary>
		public NumericSensorEntity BathroomDoorVoltage => new(_haContext, "sensor.bathroom_door_voltage");
		///<summary>Bulb Energy Meter Energy Meter</summary>
		public NumericSensorEntity BulbEnergyMeterEnergyMeter => new(_haContext, "sensor.bulb_energy_meter_energy_meter");
		///<summary>Bulb Energy Meter Gas Meter</summary>
		public NumericSensorEntity BulbEnergyMeterGasMeter => new(_haContext, "sensor.bulb_energy_meter_gas_meter");
		///<summary>Cat Feeder Uptime</summary>
		public NumericSensorEntity CatFeederUptime => new(_haContext, "sensor.cat_feeder_uptime");
		///<summary>Cat Feeder WiFi Signal</summary>
		public NumericSensorEntity CatFeederWifiSignal => new(_haContext, "sensor.cat_feeder_wifi_signal");
		///<summary>Claire’s Apple Watch iCloud battery state</summary>
		public NumericSensorEntity ClairesAppleWatchIcloudBatteryState => new(_haContext, "sensor.claires_apple_watch_icloud_battery_state");
		///<summary>Claire’s iPhone Average Active Pace</summary>
		public NumericSensorEntity ClairesIphoneAverageActivePace => new(_haContext, "sensor.claires_iphone_average_active_pace");
		///<summary>Claire’s iPhone Battery Level</summary>
		public NumericSensorEntity ClairesIphoneBatteryLevel => new(_haContext, "sensor.claires_iphone_battery_level");
		///<summary>Claire’s iPhone Distance</summary>
		public NumericSensorEntity ClairesIphoneDistance => new(_haContext, "sensor.claires_iphone_distance");
		///<summary>Claire’s iPhone Floors Ascended</summary>
		public NumericSensorEntity ClairesIphoneFloorsAscended => new(_haContext, "sensor.claires_iphone_floors_ascended");
		///<summary>Claire’s iPhone Floors Descended</summary>
		public NumericSensorEntity ClairesIphoneFloorsDescended => new(_haContext, "sensor.claires_iphone_floors_descended");
		///<summary>Claire’s iPhone iCloud battery state</summary>
		public NumericSensorEntity ClairesIphoneIcloudBatteryState => new(_haContext, "sensor.claires_iphone_icloud_battery_state");
		///<summary>Claire’s iPhone Steps</summary>
		public NumericSensorEntity ClairesIphoneSteps => new(_haContext, "sensor.claires_iphone_steps");
		///<summary>Claire’s iPhone Storage</summary>
		public NumericSensorEntity ClairesIphoneStorage => new(_haContext, "sensor.claires_iphone_storage");
		///<summary>CO2 intensity</summary>
		public NumericSensorEntity Co2Intensity => new(_haContext, "sensor.co2_intensity");
		///<summary>Doorbell Uptime</summary>
		public NumericSensorEntity DoorbellUptime => new(_haContext, "sensor.doorbell_uptime");
		///<summary>Doorbell WiFi Signal</summary>
		public NumericSensorEntity DoorbellWifiSignal => new(_haContext, "sensor.doorbell_wifi_signal");
		///<summary>Downstairs Thermostat humidity</summary>
		public NumericSensorEntity DownstairsThermostatHumidity => new(_haContext, "sensor.downstairs_thermostat_humidity");
		///<summary>Downstairs Thermostat target</summary>
		public NumericSensorEntity DownstairsThermostatTarget => new(_haContext, "sensor.downstairs_thermostat_target");
		///<summary>Downstairs Thermostat temperature</summary>
		public NumericSensorEntity DownstairsThermostatTemperature => new(_haContext, "sensor.downstairs_thermostat_temperature");
		///<summary>Dwains Dashboard Latest version</summary>
		public NumericSensorEntity DwainsDashboardLatestVersion => new(_haContext, "sensor.dwains_dashboard_latest_version");
		///<summary>Electric Cabinet Door battery</summary>
		public NumericSensorEntity ElectricCabinetDoorBattery => new(_haContext, "sensor.electric_cabinet_door_battery");
		///<summary>Electric Cabinet Door linkquality</summary>
		public NumericSensorEntity ElectricCabinetDoorLinkquality => new(_haContext, "sensor.electric_cabinet_door_linkquality");
		///<summary>Electric Cabinet Door voltage</summary>
		public NumericSensorEntity ElectricCabinetDoorVoltage => new(_haContext, "sensor.electric_cabinet_door_voltage");
		///<summary>ESPresense Bedroom Free Mem</summary>
		public NumericSensorEntity EspresenseBedroomFreeMemory => new(_haContext, "sensor.espresense_bedroom_free_memory");
		///<summary>ESPresense Bedroom Uptime</summary>
		public NumericSensorEntity EspresenseBedroomUptime => new(_haContext, "sensor.espresense_bedroom_uptime");
		///<summary>ESPresense Kitchen Free Memory</summary>
		public NumericSensorEntity EspresenseKitchenFreeMemory => new(_haContext, "sensor.espresense_kitchen_free_memory");
		///<summary>ESPresense Kitchen Uptime</summary>
		public NumericSensorEntity EspresenseKitchenUptime => new(_haContext, "sensor.espresense_kitchen_uptime");
		///<summary>ESPresense Lounge Free Mem</summary>
		public NumericSensorEntity EspresenseLoungeFreeMemory => new(_haContext, "sensor.espresense_lounge_free_memory");
		///<summary>ESPresense Lounge Uptime</summary>
		public NumericSensorEntity EspresenseLoungeUptime => new(_haContext, "sensor.espresense_lounge_uptime");
		///<summary>ESPresense Snug Free Mem</summary>
		public NumericSensorEntity EspresenseSnugFreeMem => new(_haContext, "sensor.espresense_snug_free_mem");
		///<summary>ESPresense Snug Uptime</summary>
		public NumericSensorEntity EspresenseSnugUptime => new(_haContext, "sensor.espresense_snug_uptime");
		///<summary>Front Door battery</summary>
		public NumericSensorEntity FrontDoorBattery => new(_haContext, "sensor.front_door_battery");
		///<summary>Front Door linkquality</summary>
		public NumericSensorEntity FrontDoorLinkquality => new(_haContext, "sensor.front_door_linkquality");
		///<summary>Front Door voltage</summary>
		public NumericSensorEntity FrontDoorVoltage => new(_haContext, "sensor.front_door_voltage");
		///<summary>Grid fossil fuel percentage</summary>
		public NumericSensorEntity GridFossilFuelPercentage => new(_haContext, "sensor.grid_fossil_fuel_percentage");
		///<summary>hacs</summary>
		public NumericSensorEntity Hacs => new(_haContext, "sensor.hacs");
		///<summary>Kitchen Camera Disk Write Rate</summary>
		public NumericSensorEntity KitchenCameraDiskWriteRate => new(_haContext, "sensor.kitchen_camera_disk_write_rate");
		///<summary>Kitchen Camera Storage Used</summary>
		public NumericSensorEntity KitchenCameraStorageUsed => new(_haContext, "sensor.kitchen_camera_storage_used");
		///<summary>Loft Hatch battery</summary>
		public NumericSensorEntity LoftHatchBattery => new(_haContext, "sensor.loft_hatch_battery");
		///<summary>Loft Hatch linkquality</summary>
		public NumericSensorEntity LoftHatchLinkquality => new(_haContext, "sensor.loft_hatch_linkquality");
		///<summary>Loft Hatch voltage</summary>
		public NumericSensorEntity LoftHatchVoltage => new(_haContext, "sensor.loft_hatch_voltage");
		///<summary>Lounge TV Energy Meter</summary>
		public NumericSensorEntity LoungeTvEnergyMeter => new(_haContext, "sensor.lounge_tv_energy_meter");
		///<summary>Lounge TV Power Meter</summary>
		public NumericSensorEntity LoungeTvPowerMeter => new(_haContext, "sensor.lounge_tv_power_meter");
		///<summary>Lounge TV Volume</summary>
		public NumericSensorEntity LoungeTvVolume => new(_haContext, "sensor.lounge_tv_volume");
		///<summary>Mark Battery</summary>
		public NumericSensorEntity MarkBattery => new(_haContext, "sensor.mark_battery");
		///<summary>MFC-J5910DW Black Ink Remaining</summary>
		public NumericSensorEntity MfcJ5910dwBlackInkRemaining => new(_haContext, "sensor.mfc_j5910dw_black_ink_remaining");
		///<summary>MFC-J5910DW Cyan Ink Remaining</summary>
		public NumericSensorEntity MfcJ5910dwCyanInkRemaining => new(_haContext, "sensor.mfc_j5910dw_cyan_ink_remaining");
		///<summary>MFC-J5910DW Magenta Ink Remaining</summary>
		public NumericSensorEntity MfcJ5910dwMagentaInkRemaining => new(_haContext, "sensor.mfc_j5910dw_magenta_ink_remaining");
		///<summary>MFC-J5910DW Page Counter</summary>
		public NumericSensorEntity MfcJ5910dwPageCounter => new(_haContext, "sensor.mfc_j5910dw_page_counter");
		///<summary>MFC-J5910DW Yellow Ink Remaining</summary>
		public NumericSensorEntity MfcJ5910dwYellowInkRemaining => new(_haContext, "sensor.mfc_j5910dw_yellow_ink_remaining");
		///<summary>Patio Camera Disk Write Rate</summary>
		public NumericSensorEntity PatioCameraDiskWriteRate => new(_haContext, "sensor.patio_camera_disk_write_rate");
		///<summary>Patio Camera Storage Used</summary>
		public NumericSensorEntity PatioCameraStorageUsed => new(_haContext, "sensor.patio_camera_storage_used");
		///<summary>AdGuard Safe Searches Enforced</summary>
		public NumericSensorEntity SearchesSafeSearchEnforced => new(_haContext, "sensor.searches_safe_search_enforced");
		///<summary>Snug Switch battery</summary>
		public NumericSensorEntity SnugSwitchBattery => new(_haContext, "sensor.snug_switch_battery");
		///<summary>Snug Switch voltage</summary>
		public NumericSensorEntity SnugSwitchVoltage => new(_haContext, "sensor.snug_switch_voltage");
		///<summary>Sonoff Bridge 1 status</summary>
		public NumericSensorEntity SonoffBridge1Status => new(_haContext, "sensor.sonoff_bridge_1_status");
		///<summary>SpeedTest Download</summary>
		public NumericSensorEntity SpeedtestDownload => new(_haContext, "sensor.speedtest_download");
		///<summary>SpeedTest Ping</summary>
		public NumericSensorEntity SpeedtestPing => new(_haContext, "sensor.speedtest_ping");
		///<summary>SpeedTest Upload</summary>
		public NumericSensorEntity SpeedtestUpload => new(_haContext, "sensor.speedtest_upload");
		///<summary>Sump Alarm Uptime</summary>
		public NumericSensorEntity SumpAlarmUptime => new(_haContext, "sensor.sump_alarm_uptime");
		///<summary>Sump Alarm WiFi Signal</summary>
		public NumericSensorEntity SumpAlarmWifiSignal => new(_haContext, "sensor.sump_alarm_wifi_signal");
		///<summary>Toilet Door battery</summary>
		public NumericSensorEntity ToiletDoorBattery => new(_haContext, "sensor.toilet_door_battery");
		///<summary>Toilet Door linkquality</summary>
		public NumericSensorEntity ToiletDoorLinkquality => new(_haContext, "sensor.toilet_door_linkquality");
		///<summary>Toilet Door voltage</summary>
		public NumericSensorEntity ToiletDoorVoltage => new(_haContext, "sensor.toilet_door_voltage");
		///<summary>UDMPRO Recording Capacity</summary>
		public NumericSensorEntity UdmproRecordingCapacity => new(_haContext, "sensor.udmpro_recording_capacity");
		///<summary>UDMPRO Resolution: 4K Video</summary>
		public NumericSensorEntity UdmproResolution4kVideo => new(_haContext, "sensor.udmpro_resolution_4k_video");
		///<summary>UDMPRO Resolution: Free Space</summary>
		public NumericSensorEntity UdmproResolutionFreeSpace => new(_haContext, "sensor.udmpro_resolution_free_space");
		///<summary>UDMPRO Resolution: Hd Video</summary>
		public NumericSensorEntity UdmproResolutionHdVideo => new(_haContext, "sensor.udmpro_resolution_hd_video");
		///<summary>UDMPRO Storage Utilization</summary>
		public NumericSensorEntity UdmproStorageUtilization => new(_haContext, "sensor.udmpro_storage_utilization");
		///<summary>UDMPRO Type: Continuous Video</summary>
		public NumericSensorEntity UdmproTypeContinuousVideo => new(_haContext, "sensor.udmpro_type_continuous_video");
		///<summary>UDMPRO Type: Detections Video</summary>
		public NumericSensorEntity UdmproTypeDetectionsVideo => new(_haContext, "sensor.udmpro_type_detections_video");
		///<summary>UDMPRO Type: Timelapse Video</summary>
		public NumericSensorEntity UdmproTypeTimelapseVideo => new(_haContext, "sensor.udmpro_type_timelapse_video");
		///<summary>UniFi Dream Machine B received</summary>
		public NumericSensorEntity UnifiDreamMachineBReceived => new(_haContext, "sensor.unifi_dream_machine_b_received");
		///<summary>UniFi Dream Machine B sent</summary>
		public NumericSensorEntity UnifiDreamMachineBSent => new(_haContext, "sensor.unifi_dream_machine_b_sent");
		///<summary>UniFi Dream Machine KiB/s received</summary>
		public NumericSensorEntity UnifiDreamMachineKibSReceived => new(_haContext, "sensor.unifi_dream_machine_kib_s_received");
		///<summary>UniFi Dream Machine KiB/s sent</summary>
		public NumericSensorEntity UnifiDreamMachineKibSSent => new(_haContext, "sensor.unifi_dream_machine_kib_s_sent");
		///<summary>UniFi Dream Machine packets received</summary>
		public NumericSensorEntity UnifiDreamMachinePacketsReceived => new(_haContext, "sensor.unifi_dream_machine_packets_received");
		///<summary>UniFi Dream Machine packets/s received</summary>
		public NumericSensorEntity UnifiDreamMachinePacketsSReceived => new(_haContext, "sensor.unifi_dream_machine_packets_s_received");
		///<summary>UniFi Dream Machine packets/s sent</summary>
		public NumericSensorEntity UnifiDreamMachinePacketsSSent => new(_haContext, "sensor.unifi_dream_machine_packets_s_sent");
		///<summary>UniFi Dream Machine packets sent</summary>
		public NumericSensorEntity UnifiDreamMachinePacketsSent => new(_haContext, "sensor.unifi_dream_machine_packets_sent");
		///<summary>UK Confirmed</summary>
		public NumericSensorEntity UnitedKingdomCoronavirusConfirmed => new(_haContext, "sensor.united_kingdom_coronavirus_confirmed");
		///<summary>UK Current</summary>
		public NumericSensorEntity UnitedKingdomCoronavirusCurrent => new(_haContext, "sensor.united_kingdom_coronavirus_current");
		///<summary>UK Deaths</summary>
		public NumericSensorEntity UnitedKingdomCoronavirusDeaths => new(_haContext, "sensor.united_kingdom_coronavirus_deaths");
		///<summary>UK Recovered</summary>
		public NumericSensorEntity UnitedKingdomCoronavirusRecovered => new(_haContext, "sensor.united_kingdom_coronavirus_recovered");
		///<summary>Upstairs Thermostat humidity</summary>
		public NumericSensorEntity UpstairsThermostatHumidity => new(_haContext, "sensor.upstairs_thermostat_humidity");
		///<summary>Upstairs Thermostat target</summary>
		public NumericSensorEntity UpstairsThermostatTarget => new(_haContext, "sensor.upstairs_thermostat_target");
		///<summary>Upstairs Thermostat temperature</summary>
		public NumericSensorEntity UpstairsThermostatTemperature => new(_haContext, "sensor.upstairs_thermostat_temperature");
		///<summary>Weather Station Ambient Light</summary>
		public NumericSensorEntity WeatherStationAmbientLight => new(_haContext, "sensor.weather_station_ambient_light");
		///<summary>Weather Station Lux</summary>
		public NumericSensorEntity WeatherStationLux => new(_haContext, "sensor.weather_station_lux");
		///<summary>Weather Station Pressure</summary>
		public NumericSensorEntity WeatherStationPressure => new(_haContext, "sensor.weather_station_pressure");
		///<summary>Weather Station Relative Humidity</summary>
		public NumericSensorEntity WeatherStationRelativeHumidity => new(_haContext, "sensor.weather_station_relative_humidity");
		///<summary>Weather Station Temperature</summary>
		public NumericSensorEntity WeatherStationTemperature => new(_haContext, "sensor.weather_station_temperature");
		///<summary>Weather Station Uptime</summary>
		public NumericSensorEntity WeatherStationUptime => new(_haContext, "sensor.weather_station_uptime");
		///<summary>Weather Station WiFi Signal</summary>
		public NumericSensorEntity WeatherStationWifiSignal => new(_haContext, "sensor.weather_station_wifi_signal");
		///<summary>Withings body_temperature_c Andy</summary>
		public NumericSensorEntity WithingsBodyTemperatureCAndy => new(_haContext, "sensor.withings_body_temperature_c_andy");
		///<summary>Withings body_temperature_c Claire</summary>
		public NumericSensorEntity WithingsBodyTemperatureCClaire => new(_haContext, "sensor.withings_body_temperature_c_claire");
		///<summary>Withings bone_mass_kg Andy</summary>
		public NumericSensorEntity WithingsBoneMassKgAndy => new(_haContext, "sensor.withings_bone_mass_kg_andy");
		///<summary>Withings bone_mass_kg Claire</summary>
		public NumericSensorEntity WithingsBoneMassKgClaire => new(_haContext, "sensor.withings_bone_mass_kg_claire");
		///<summary>Withings diastolic_blood_pressure_mmhg Andy</summary>
		public NumericSensorEntity WithingsDiastolicBloodPressureMmhgAndy => new(_haContext, "sensor.withings_diastolic_blood_pressure_mmhg_andy");
		///<summary>Withings diastolic_blood_pressure_mmhg Claire</summary>
		public NumericSensorEntity WithingsDiastolicBloodPressureMmhgClaire => new(_haContext, "sensor.withings_diastolic_blood_pressure_mmhg_claire");
		///<summary>Withings fat_free_mass_kg Andy</summary>
		public NumericSensorEntity WithingsFatFreeMassKgAndy => new(_haContext, "sensor.withings_fat_free_mass_kg_andy");
		///<summary>Withings fat_free_mass_kg Claire</summary>
		public NumericSensorEntity WithingsFatFreeMassKgClaire => new(_haContext, "sensor.withings_fat_free_mass_kg_claire");
		///<summary>Withings fat_mass_kg Andy</summary>
		public NumericSensorEntity WithingsFatMassKgAndy => new(_haContext, "sensor.withings_fat_mass_kg_andy");
		///<summary>Withings fat_mass_kg Claire</summary>
		public NumericSensorEntity WithingsFatMassKgClaire => new(_haContext, "sensor.withings_fat_mass_kg_claire");
		///<summary>Withings fat_ratio_pct Andy</summary>
		public NumericSensorEntity WithingsFatRatioPctAndy => new(_haContext, "sensor.withings_fat_ratio_pct_andy");
		///<summary>Withings fat_ratio_pct Claire</summary>
		public NumericSensorEntity WithingsFatRatioPctClaire => new(_haContext, "sensor.withings_fat_ratio_pct_claire");
		///<summary>Withings heart_pulse_bpm Andy</summary>
		public NumericSensorEntity WithingsHeartPulseBpmAndy => new(_haContext, "sensor.withings_heart_pulse_bpm_andy");
		///<summary>Withings heart_pulse_bpm Claire</summary>
		public NumericSensorEntity WithingsHeartPulseBpmClaire => new(_haContext, "sensor.withings_heart_pulse_bpm_claire");
		///<summary>Withings muscle_mass_kg Andy</summary>
		public NumericSensorEntity WithingsMuscleMassKgAndy => new(_haContext, "sensor.withings_muscle_mass_kg_andy");
		///<summary>Withings muscle_mass_kg Claire</summary>
		public NumericSensorEntity WithingsMuscleMassKgClaire => new(_haContext, "sensor.withings_muscle_mass_kg_claire");
		///<summary>Withings pulse_wave_velocity Andy</summary>
		public NumericSensorEntity WithingsPulseWaveVelocityAndy => new(_haContext, "sensor.withings_pulse_wave_velocity_andy");
		///<summary>Withings pulse_wave_velocity Claire</summary>
		public NumericSensorEntity WithingsPulseWaveVelocityClaire => new(_haContext, "sensor.withings_pulse_wave_velocity_claire");
		///<summary>Withings skin_temperature_c Andy</summary>
		public NumericSensorEntity WithingsSkinTemperatureCAndy => new(_haContext, "sensor.withings_skin_temperature_c_andy");
		///<summary>Withings skin_temperature_c Claire</summary>
		public NumericSensorEntity WithingsSkinTemperatureCClaire => new(_haContext, "sensor.withings_skin_temperature_c_claire");
		///<summary>Withings spo2_pct Andy</summary>
		public NumericSensorEntity WithingsSpo2PctAndy => new(_haContext, "sensor.withings_spo2_pct_andy");
		///<summary>Withings spo2_pct Claire</summary>
		public NumericSensorEntity WithingsSpo2PctClaire => new(_haContext, "sensor.withings_spo2_pct_claire");
		///<summary>Withings systolic_blood_pressure_mmhg Andy</summary>
		public NumericSensorEntity WithingsSystolicBloodPressureMmhgAndy => new(_haContext, "sensor.withings_systolic_blood_pressure_mmhg_andy");
		///<summary>Withings systolic_blood_pressure_mmhg Claire</summary>
		public NumericSensorEntity WithingsSystolicBloodPressureMmhgClaire => new(_haContext, "sensor.withings_systolic_blood_pressure_mmhg_claire");
		///<summary>Withings temperature_c Andy</summary>
		public NumericSensorEntity WithingsTemperatureCAndy => new(_haContext, "sensor.withings_temperature_c_andy");
		///<summary>Withings temperature_c Claire</summary>
		public NumericSensorEntity WithingsTemperatureCClaire => new(_haContext, "sensor.withings_temperature_c_claire");
		///<summary>Withings weight_kg Andy</summary>
		public NumericSensorEntity WithingsWeightKgAndy => new(_haContext, "sensor.withings_weight_kg_andy");
		///<summary>Withings weight_kg Claire</summary>
		public NumericSensorEntity WithingsWeightKgClaire => new(_haContext, "sensor.withings_weight_kg_claire");
		///<summary>World Confirmed</summary>
		public NumericSensorEntity WorldwideCoronavirusConfirmed => new(_haContext, "sensor.worldwide_coronavirus_confirmed");
		///<summary>World Current</summary>
		public NumericSensorEntity WorldwideCoronavirusCurrent => new(_haContext, "sensor.worldwide_coronavirus_current");
		///<summary>World Deaths</summary>
		public NumericSensorEntity WorldwideCoronavirusDeaths => new(_haContext, "sensor.worldwide_coronavirus_deaths");
		///<summary>World Recovered</summary>
		public NumericSensorEntity WorldwideCoronavirusRecovered => new(_haContext, "sensor.worldwide_coronavirus_recovered");
		///<summary>Andrew's Echo Buds next Reminder</summary>
		public SensorEntity AndrewSEchoBudsNextReminder => new(_haContext, "sensor.andrew_s_echo_buds_next_reminder");
		///<summary>Andrew's Fire TV next Alarm</summary>
		public SensorEntity AndrewSFireTvNextAlarm => new(_haContext, "sensor.andrew_s_fire_tv_next_alarm");
		///<summary>Andrew's Fire TV next Reminder</summary>
		public SensorEntity AndrewSFireTvNextReminder => new(_haContext, "sensor.andrew_s_fire_tv_next_reminder");
		///<summary>Andrew's Fire TV next Timer</summary>
		public SensorEntity AndrewSFireTvNextTimer => new(_haContext, "sensor.andrew_s_fire_tv_next_timer");
		///<summary>Andrew's Samsung TV 2020-U next Alarm</summary>
		public SensorEntity AndrewSSamsungTv2020UNextAlarm => new(_haContext, "sensor.andrew_s_samsung_tv_2020_u_next_alarm");
		///<summary>Andrew's Samsung TV 2020-U next Reminder</summary>
		public SensorEntity AndrewSSamsungTv2020UNextReminder => new(_haContext, "sensor.andrew_s_samsung_tv_2020_u_next_reminder");
		///<summary>Andrew's Samsung TV 2020-U next Timer</summary>
		public SensorEntity AndrewSSamsungTv2020UNextTimer => new(_haContext, "sensor.andrew_s_samsung_tv_2020_u_next_timer");
		///<summary>Andy's iPhone Activity</summary>
		public SensorEntity AndySIphoneActivity => new(_haContext, "sensor.andy_s_iphone_activity");
		///<summary>Andy's iPhone Battery State</summary>
		public SensorEntity AndySIphoneBatteryState => new(_haContext, "sensor.andy_s_iphone_battery_state");
		///<summary>Andy's iPhone BSSID</summary>
		public SensorEntity AndySIphoneBssid => new(_haContext, "sensor.andy_s_iphone_bssid");
		///<summary>Andy's iPhone Connection Type</summary>
		public SensorEntity AndySIphoneConnectionType => new(_haContext, "sensor.andy_s_iphone_connection_type");
		///<summary>Andy's iPhone Geocoded Location</summary>
		public SensorEntity AndySIphoneGeocodedLocation => new(_haContext, "sensor.andy_s_iphone_geocoded_location");
		///<summary>Andy's iPhone Last Update Trigger</summary>
		public SensorEntity AndySIphoneLastUpdateTrigger => new(_haContext, "sensor.andy_s_iphone_last_update_trigger");
		///<summary>Andy's iPhone SIM 1</summary>
		public SensorEntity AndySIphoneSim1 => new(_haContext, "sensor.andy_s_iphone_sim_1");
		///<summary>Andy's iPhone SSID</summary>
		public SensorEntity AndySIphoneSsid => new(_haContext, "sensor.andy_s_iphone_ssid");
		///<summary>Backup State</summary>
		public SensorEntity BackupState => new(_haContext, "sensor.backup_state");
		///<summary>Basement Hall Camera Oldest Recording</summary>
		public SensorEntity BasementHallCameraOldestRecording => new(_haContext, "sensor.basement_hall_camera_oldest_recording");
		///<summary>Basement Thermostat hvac state</summary>
		public SensorEntity BasementThermostatHvacState => new(_haContext, "sensor.basement_thermostat_hvac_state");
		///<summary>Basement Thermostat operation mode</summary>
		public SensorEntity BasementThermostatOperationMode => new(_haContext, "sensor.basement_thermostat_operation_mode");
		///<summary>Bedroom Echo Show next Alarm</summary>
		public SensorEntity BedroomEchoShowNextAlarm => new(_haContext, "sensor.bedroom_echo_show_next_alarm");
		///<summary>Bedroom Echo Show next Reminder</summary>
		public SensorEntity BedroomEchoShowNextReminder => new(_haContext, "sensor.bedroom_echo_show_next_reminder");
		///<summary>Bedroom Echo Show next Timer</summary>
		public SensorEntity BedroomEchoShowNextTimer => new(_haContext, "sensor.bedroom_echo_show_next_timer");
		///<summary>Black Refuse</summary>
		public SensorEntity BlackRefuse => new(_haContext, "sensor.black_refuse");
		///<summary>Blue Paper</summary>
		public SensorEntity BluePaper => new(_haContext, "sensor.blue_paper");
		///<summary>Brown Recyclables</summary>
		public SensorEntity BrownRecyclables => new(_haContext, "sensor.brown_recyclables");
		///<summary>Cat Feeder BSSID</summary>
		public SensorEntity CatFeederBssid => new(_haContext, "sensor.cat_feeder_bssid");
		///<summary>Cat Feeder ESPHome Version</summary>
		public SensorEntity CatFeederEsphomeVersion => new(_haContext, "sensor.cat_feeder_esphome_version");
		///<summary>Cat Feeder IP</summary>
		public SensorEntity CatFeederIp => new(_haContext, "sensor.cat_feeder_ip");
		///<summary>Cat Feeder SSID</summary>
		public SensorEntity CatFeederSsid => new(_haContext, "sensor.cat_feeder_ssid");
		///<summary>Cellar Door Camera Actions</summary>
		public SensorEntity CellarDoorCameraActions => new(_haContext, "sensor.cellar_door_camera_actions");
		///<summary>Claire’s iPhone Activity</summary>
		public SensorEntity ClairesIphoneActivity => new(_haContext, "sensor.claires_iphone_activity");
		///<summary>Claire’s iPhone Battery State</summary>
		public SensorEntity ClairesIphoneBatteryState => new(_haContext, "sensor.claires_iphone_battery_state");
		///<summary>Claire’s iPhone BSSID</summary>
		public SensorEntity ClairesIphoneBssid => new(_haContext, "sensor.claires_iphone_bssid");
		///<summary>Claire’s iPhone Connection Type</summary>
		public SensorEntity ClairesIphoneConnectionType => new(_haContext, "sensor.claires_iphone_connection_type");
		///<summary>Claire’s iPhone Geocoded Location</summary>
		public SensorEntity ClairesIphoneGeocodedLocation => new(_haContext, "sensor.claires_iphone_geocoded_location");
		///<summary>Claire’s iPhone Last Update Trigger</summary>
		public SensorEntity ClairesIphoneLastUpdateTrigger => new(_haContext, "sensor.claires_iphone_last_update_trigger");
		///<summary>Claire’s iPhone SIM 1</summary>
		public SensorEntity ClairesIphoneSim1 => new(_haContext, "sensor.claires_iphone_sim_1");
		///<summary>Claire’s iPhone SSID</summary>
		public SensorEntity ClairesIphoneSsid => new(_haContext, "sensor.claires_iphone_ssid");
		///<summary>Dining Room Echo Input next Alarm</summary>
		public SensorEntity DiningRoomEchoInputNextAlarm => new(_haContext, "sensor.dining_room_echo_input_next_alarm");
		///<summary>Dining Room Echo Input next Reminder</summary>
		public SensorEntity DiningRoomEchoInputNextReminder => new(_haContext, "sensor.dining_room_echo_input_next_reminder");
		///<summary>Dining Room Echo Input next Timer</summary>
		public SensorEntity DiningRoomEchoInputNextTimer => new(_haContext, "sensor.dining_room_echo_input_next_timer");
		///<summary>Doorbell BSSID</summary>
		public SensorEntity DoorbellBssid => new(_haContext, "sensor.doorbell_bssid");
		///<summary>Doorbell ESPHome Version</summary>
		public SensorEntity DoorbellEsphomeVersion => new(_haContext, "sensor.doorbell_esphome_version");
		///<summary>Doorbell IP</summary>
		public SensorEntity DoorbellIp => new(_haContext, "sensor.doorbell_ip");
		///<summary>Doorbell SSID</summary>
		public SensorEntity DoorbellSsid => new(_haContext, "sensor.doorbell_ssid");
		///<summary>Downstairs Thermostat hvac state</summary>
		public SensorEntity DownstairsThermostatHvacState => new(_haContext, "sensor.downstairs_thermostat_hvac_state");
		///<summary>Downstairs Thermostat operation mode</summary>
		public SensorEntity DownstairsThermostatOperationMode => new(_haContext, "sensor.downstairs_thermostat_operation_mode");
		///<summary>Drawing Room Echo Dot next Alarm</summary>
		public SensorEntity DrawingRoomEchoDotNextAlarm => new(_haContext, "sensor.drawing_room_echo_dot_next_alarm");
		///<summary>Drawing Room Echo Dot next Reminder</summary>
		public SensorEntity DrawingRoomEchoDotNextReminder => new(_haContext, "sensor.drawing_room_echo_dot_next_reminder");
		///<summary>Drawing Room Echo Dot next Timer</summary>
		public SensorEntity DrawingRoomEchoDotNextTimer => new(_haContext, "sensor.drawing_room_echo_dot_next_timer");
		///<summary>Dressing Room Echo Dot next Alarm</summary>
		public SensorEntity DressingRoomEchoDotNextAlarm => new(_haContext, "sensor.dressing_room_echo_dot_next_alarm");
		///<summary>Dressing Room Echo Dot next Reminder</summary>
		public SensorEntity DressingRoomEchoDotNextReminder => new(_haContext, "sensor.dressing_room_echo_dot_next_reminder");
		///<summary>Dressing Room Echo Dot next Timer</summary>
		public SensorEntity DressingRoomEchoDotNextTimer => new(_haContext, "sensor.dressing_room_echo_dot_next_timer");
		///<summary>eWeLink Smart Home: Newest Version</summary>
		public SensorEntity EwelinkSmartHomeNewestVersion => new(_haContext, "sensor.ewelink_smart_home_newest_version");
		///<summary>eWeLink Smart Home: Version</summary>
		public SensorEntity EwelinkSmartHomeVersion => new(_haContext, "sensor.ewelink_smart_home_version");
		///<summary>Green Bio Waste</summary>
		public SensorEntity GreenBioWaste => new(_haContext, "sensor.green_bio_waste");
		///<summary>Guest Room Echo Show next Alarm</summary>
		public SensorEntity GuestRoomEchoShowNextAlarm => new(_haContext, "sensor.guest_room_echo_show_next_alarm");
		///<summary>Guest Room Echo Show next Reminder</summary>
		public SensorEntity GuestRoomEchoShowNextReminder => new(_haContext, "sensor.guest_room_echo_show_next_reminder");
		///<summary>Guest Room Echo Show next Timer</summary>
		public SensorEntity GuestRoomEchoShowNextTimer => new(_haContext, "sensor.guest_room_echo_show_next_timer");
		///<summary>Hall Tablet next Alarm</summary>
		public SensorEntity HallTabletNextAlarm => new(_haContext, "sensor.hall_tablet_next_alarm");
		///<summary>Hall Tablet next Reminder</summary>
		public SensorEntity HallTabletNextReminder => new(_haContext, "sensor.hall_tablet_next_reminder");
		///<summary>Hall Tablet next Timer</summary>
		public SensorEntity HallTabletNextTimer => new(_haContext, "sensor.hall_tablet_next_timer");
		///<summary>home.andisoft.co.uk</summary>
		public SensorEntity HomeAndisoftCoUk => new(_haContext, "sensor.home_andisoft_co_uk");
		///<summary>homeassistant</summary>
		public SensorEntity Homeassistant => new(_haContext, "sensor.homeassistant");
		///<summary>Kitchen Camera Oldest Recording</summary>
		public SensorEntity KitchenCameraOldestRecording => new(_haContext, "sensor.kitchen_camera_oldest_recording");
		///<summary>Kitchen Echo Show next Alarm</summary>
		public SensorEntity KitchenEchoShowNextAlarm => new(_haContext, "sensor.kitchen_echo_show_next_alarm");
		///<summary>Kitchen Echo Show next Reminder</summary>
		public SensorEntity KitchenEchoShowNextReminder => new(_haContext, "sensor.kitchen_echo_show_next_reminder");
		///<summary>Kitchen Echo Show next Timer</summary>
		public SensorEntity KitchenEchoShowNextTimer => new(_haContext, "sensor.kitchen_echo_show_next_timer");
		///<summary>Landing Tablet next Alarm</summary>
		public SensorEntity LandingTabletNextAlarm => new(_haContext, "sensor.landing_tablet_next_alarm");
		///<summary>Landing Tablet next Reminder</summary>
		public SensorEntity LandingTabletNextReminder => new(_haContext, "sensor.landing_tablet_next_reminder");
		///<summary>Landing Tablet next Timer</summary>
		public SensorEntity LandingTabletNextTimer => new(_haContext, "sensor.landing_tablet_next_timer");
		///<summary>local_ip</summary>
		public SensorEntity LocalIp => new(_haContext, "sensor.local_ip");
		///<summary>Lounge Echo Plus next Alarm</summary>
		public SensorEntity LoungeEchoPlusNextAlarm => new(_haContext, "sensor.lounge_echo_plus_next_alarm");
		///<summary>Lounge Echo Plus next Reminder</summary>
		public SensorEntity LoungeEchoPlusNextReminder => new(_haContext, "sensor.lounge_echo_plus_next_reminder");
		///<summary>Lounge Echo Plus next Timer</summary>
		public SensorEntity LoungeEchoPlusNextTimer => new(_haContext, "sensor.lounge_echo_plus_next_timer");
		///<summary>Lounge Fire TV next Alarm</summary>
		public SensorEntity LoungeFireTvNextAlarm => new(_haContext, "sensor.lounge_fire_tv_next_alarm");
		///<summary>Lounge Fire TV next Reminder</summary>
		public SensorEntity LoungeFireTvNextReminder => new(_haContext, "sensor.lounge_fire_tv_next_reminder");
		///<summary>Lounge Fire TV next Timer</summary>
		public SensorEntity LoungeFireTvNextTimer => new(_haContext, "sensor.lounge_fire_tv_next_timer");
		///<summary>Lounge TV Media Input Source</summary>
		public SensorEntity LoungeTvMediaInputSource => new(_haContext, "sensor.lounge_tv_media_input_source");
		///<summary>Lounge TV Media Playback Status</summary>
		public SensorEntity LoungeTvMediaPlaybackStatus => new(_haContext, "sensor.lounge_tv_media_playback_status");
		///<summary>Lounge TV Tv Channel</summary>
		public SensorEntity LoungeTvTvChannel => new(_haContext, "sensor.lounge_tv_tv_channel");
		///<summary>Lounge TV Tv Channel Name</summary>
		public SensorEntity LoungeTvTvChannelName => new(_haContext, "sensor.lounge_tv_tv_channel_name");
		///<summary>Manchester Road eta</summary>
		public SensorEntity ManchesterRoadEta => new(_haContext, "sensor.manchester_road_eta");
		///<summary>MFC-J5910DW Status</summary>
		public SensorEntity MfcJ5910dwStatus => new(_haContext, "sensor.mfc_j5910dw_status");
		///<summary>MFC-J5910DW Uptime</summary>
		public SensorEntity MfcJ5910dwUptime => new(_haContext, "sensor.mfc_j5910dw_uptime");
		///<summary>myip</summary>
		public SensorEntity Myip => new(_haContext, "sensor.myip");
		///<summary>Patio Camera Detected Object</summary>
		public SensorEntity PatioCameraDetectedObject => new(_haContext, "sensor.patio_camera_detected_object");
		///<summary>Patio Camera Oldest Recording</summary>
		public SensorEntity PatioCameraOldestRecording => new(_haContext, "sensor.patio_camera_oldest_recording");
		///<summary>Snug Echo Input next Alarm</summary>
		public SensorEntity SnugEchoInputNextAlarm => new(_haContext, "sensor.snug_echo_input_next_alarm");
		///<summary>Snug Echo Input next Reminder</summary>
		public SensorEntity SnugEchoInputNextReminder => new(_haContext, "sensor.snug_echo_input_next_reminder");
		///<summary>Snug Echo Input next Timer</summary>
		public SensorEntity SnugEchoInputNextTimer => new(_haContext, "sensor.snug_echo_input_next_timer");
		///<summary>Snug Switch action</summary>
		public SensorEntity SnugSwitchAction => new(_haContext, "sensor.snug_switch_action");
		///<summary>Sump Alarm BSSID</summary>
		public SensorEntity SumpAlarmBssid => new(_haContext, "sensor.sump_alarm_bssid");
		///<summary>Sump Alarm ESPHome Version</summary>
		public SensorEntity SumpAlarmEsphomeVersion => new(_haContext, "sensor.sump_alarm_esphome_version");
		///<summary>Sump Alarm IP</summary>
		public SensorEntity SumpAlarmIp => new(_haContext, "sensor.sump_alarm_ip");
		///<summary>Sump Alarm SSID</summary>
		public SensorEntity SumpAlarmSsid => new(_haContext, "sensor.sump_alarm_ssid");
		///<summary>UDMPRO Uptime</summary>
		public SensorEntity UdmproUptime => new(_haContext, "sensor.udmpro_uptime");
		///<summary>UniFi Dream Machine External IP</summary>
		public SensorEntity UnifiDreamMachineExternalIp => new(_haContext, "sensor.unifi_dream_machine_external_ip");
		///<summary>UniFi Dream Machine wan status</summary>
		public SensorEntity UnifiDreamMachineWanStatus => new(_haContext, "sensor.unifi_dream_machine_wan_status");
		///<summary>Upstairs Thermostat hvac state</summary>
		public SensorEntity UpstairsThermostatHvacState => new(_haContext, "sensor.upstairs_thermostat_hvac_state");
		///<summary>Upstairs Thermostat operation mode</summary>
		public SensorEntity UpstairsThermostatOperationMode => new(_haContext, "sensor.upstairs_thermostat_operation_mode");
		///<summary>Utility Room Echo Dot next Alarm</summary>
		public SensorEntity UtilityRoomEchoDotNextAlarm => new(_haContext, "sensor.utility_room_echo_dot_next_alarm");
		///<summary>Utility Room Echo Dot next Reminder</summary>
		public SensorEntity UtilityRoomEchoDotNextReminder => new(_haContext, "sensor.utility_room_echo_dot_next_reminder");
		///<summary>Utility Room Echo Dot next Timer</summary>
		public SensorEntity UtilityRoomEchoDotNextTimer => new(_haContext, "sensor.utility_room_echo_dot_next_timer");
		///<summary>Weather Station Altitude</summary>
		public SensorEntity WeatherStationAltitude => new(_haContext, "sensor.weather_station_altitude");
		///<summary>Weather Station BSSID</summary>
		public SensorEntity WeatherStationBssid => new(_haContext, "sensor.weather_station_bssid");
		///<summary>Weather Station ESPHome Version</summary>
		public SensorEntity WeatherStationEsphomeVersion => new(_haContext, "sensor.weather_station_esphome_version");
		///<summary>Weather Station Full spectrum light</summary>
		public SensorEntity WeatherStationFullSpectrumLight => new(_haContext, "sensor.weather_station_full_spectrum_light");
		///<summary>Weather Station Humidity</summary>
		public SensorEntity WeatherStationHumidity => new(_haContext, "sensor.weather_station_humidity");
		///<summary>Weather Station Infrared light</summary>
		public SensorEntity WeatherStationInfraredLight => new(_haContext, "sensor.weather_station_infrared_light");
		///<summary>Weather Station IP</summary>
		public SensorEntity WeatherStationIp => new(_haContext, "sensor.weather_station_ip");
		///<summary>Weather Station SSID</summary>
		public SensorEntity WeatherStationSsid => new(_haContext, "sensor.weather_station_ssid");
		///<summary>Weather Station Visible light</summary>
		public SensorEntity WeatherStationVisibleLight => new(_haContext, "sensor.weather_station_visible_light");
	}

	public class SunEntities
	{
		private readonly IHaContext _haContext;
		public SunEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Sun</summary>
		public SunEntity Sun => new(_haContext, "sun.sun");
	}

	public class SwitchEntities
	{
		private readonly IHaContext _haContext;
		public SwitchEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Outside Lights 1-Back Door Light</summary>
		public SwitchEntity E100032907e1 => new(_haContext, "switch.100032907e_1");
		///<summary>Outside Lights 1-Patio Light</summary>
		public SwitchEntity E100032907e2 => new(_haContext, "switch.100032907e_2");
		///<summary>Outside Lights 1-Porch Light</summary>
		public SwitchEntity E100032907e3 => new(_haContext, "switch.100032907e_3");
		///<summary>Outside Lights 1-Cellar Door Light</summary>
		public SwitchEntity E100032907e4 => new(_haContext, "switch.100032907e_4");
		///<summary>Basement Lights 2-Dining Room Light</summary>
		public SwitchEntity E100032a00d1 => new(_haContext, "switch.100032a00d_1");
		///<summary>Basement Lights 2-Snug Light</summary>
		public SwitchEntity E100032a00d2 => new(_haContext, "switch.100032a00d_2");
		///<summary>Basement Lights 2-Spare BL6</summary>
		public SwitchEntity E100032a00d3 => new(_haContext, "switch.100032a00d_3");
		///<summary>Basement Lights 2-Spare BL5</summary>
		public SwitchEntity E100032a00d4 => new(_haContext, "switch.100032a00d_4");
		///<summary>Basement Lights 1-Toilet Light</summary>
		public SwitchEntity E100032bd731 => new(_haContext, "switch.100032bd73_1");
		///<summary>Basement Lights 1-Utility Room Light</summary>
		public SwitchEntity E100032bd732 => new(_haContext, "switch.100032bd73_2");
		///<summary>Basement Lights 1-Basement Hall Light</summary>
		public SwitchEntity E100032bd733 => new(_haContext, "switch.100032bd73_3");
		///<summary>Basement Lights 1-Brewery Light</summary>
		public SwitchEntity E100032bd734 => new(_haContext, "switch.100032bd73_4");
		///<summary>Ground Floor 1-Lounge light</summary>
		public SwitchEntity E1000ba99771 => new(_haContext, "switch.1000ba9977_1");
		///<summary>Ground Floor 1-Hallway light</summary>
		public SwitchEntity E1000ba99772 => new(_haContext, "switch.1000ba9977_2");
		///<summary>Ground Floor 1-Extractor fan</summary>
		public SwitchEntity E1000ba99773 => new(_haContext, "switch.1000ba9977_3");
		///<summary>Ground Floor 1-Bookshelf light</summary>
		public SwitchEntity E1000ba99774 => new(_haContext, "switch.1000ba9977_4");
		///<summary>Ground Floor 2-Spare GL1</summary>
		public SwitchEntity E1000bab17a1 => new(_haContext, "switch.1000bab17a_1");
		///<summary>Ground Floor 2-Cabinet light</summary>
		public SwitchEntity E1000bab17a2 => new(_haContext, "switch.1000bab17a_2");
		///<summary>Ground Floor 2-Kitchen light</summary>
		public SwitchEntity E1000bab17a3 => new(_haContext, "switch.1000bab17a_3");
		///<summary>Ground Floor 2-Drawing Room light</summary>
		public SwitchEntity E1000bab17a4 => new(_haContext, "switch.1000bab17a_4");
		///<summary>Upstairs 1-Guest Room light</summary>
		public SwitchEntity E1000bab3811 => new(_haContext, "switch.1000bab381_1");
		///<summary>Upstairs 1-Landing light</summary>
		public SwitchEntity E1000bab3812 => new(_haContext, "switch.1000bab381_2");
		///<summary>Upstairs 1-Dressing Room light</summary>
		public SwitchEntity E1000bab3813 => new(_haContext, "switch.1000bab381_3");
		///<summary>Upstairs 1-Bathroom fan</summary>
		public SwitchEntity E1000bab3814 => new(_haContext, "switch.1000bab381_4");
		///<summary>Upstairs 2-Bedroom light</summary>
		public SwitchEntity E1000bab6de1 => new(_haContext, "switch.1000bab6de_1");
		///<summary>Upstairs 2-Studio light</summary>
		public SwitchEntity E1000bab6de2 => new(_haContext, "switch.1000bab6de_2");
		///<summary>Upstairs 2-Bathroom light</summary>
		public SwitchEntity E1000bab6de3 => new(_haContext, "switch.1000bab6de_3");
		///<summary>Upstairs 2-Mirror light</summary>
		public SwitchEntity E1000bab6de4 => new(_haContext, "switch.1000bab6de_4");
		///<summary>AdGuard Filtering</summary>
		public SwitchEntity AdguardFiltering => new(_haContext, "switch.adguard_filtering");
		///<summary>AdGuard Parental Control</summary>
		public SwitchEntity AdguardParentalControl => new(_haContext, "switch.adguard_parental_control");
		///<summary>AdGuard Protection</summary>
		public SwitchEntity AdguardProtection => new(_haContext, "switch.adguard_protection");
		///<summary>AdGuard Query Log</summary>
		public SwitchEntity AdguardQueryLog => new(_haContext, "switch.adguard_query_log");
		///<summary>AdGuard Safe Browsing</summary>
		public SwitchEntity AdguardSafeBrowsing => new(_haContext, "switch.adguard_safe_browsing");
		///<summary>AdGuard Safe Search</summary>
		public SwitchEntity AdguardSafeSearch => new(_haContext, "switch.adguard_safe_search");
		///<summary>All Speakers do not disturb switch</summary>
		public SwitchEntity AllSpeakersDoNotDisturbSwitch => new(_haContext, "switch.all_speakers_do_not_disturb_switch");
		///<summary>All Speakers repeat switch</summary>
		public SwitchEntity AllSpeakersRepeatSwitch => new(_haContext, "switch.all_speakers_repeat_switch");
		///<summary>All Speakers shuffle switch</summary>
		public SwitchEntity AllSpeakersShuffleSwitch => new(_haContext, "switch.all_speakers_shuffle_switch");
		///<summary>Andrew's Echo Buds do not disturb switch</summary>
		public SwitchEntity AndrewSEchoBudsDoNotDisturbSwitch => new(_haContext, "switch.andrew_s_echo_buds_do_not_disturb_switch");
		///<summary>Andrew's Fire TV do not disturb switch</summary>
		public SwitchEntity AndrewSFireTvDoNotDisturbSwitch => new(_haContext, "switch.andrew_s_fire_tv_do_not_disturb_switch");
		///<summary>Andrew's Samsung TV 2020-U do not disturb switch</summary>
		public SwitchEntity AndrewSSamsungTv2020UDoNotDisturbSwitch => new(_haContext, "switch.andrew_s_samsung_tv_2020_u_do_not_disturb_switch");
		///<summary>Andrew's Samsung TV 2020-U repeat switch</summary>
		public SwitchEntity AndrewSSamsungTv2020URepeatSwitch => new(_haContext, "switch.andrew_s_samsung_tv_2020_u_repeat_switch");
		///<summary>Andrew's Samsung TV 2020-U shuffle switch</summary>
		public SwitchEntity AndrewSSamsungTv2020UShuffleSwitch => new(_haContext, "switch.andrew_s_samsung_tv_2020_u_shuffle_switch");
		///<summary>Basement Hall Camera HDR Mode</summary>
		public SwitchEntity BasementHallCameraHdrMode => new(_haContext, "switch.basement_hall_camera_hdr_mode");
		///<summary>Basement Hall Camera Overlay: Show Bitrate</summary>
		public SwitchEntity BasementHallCameraOverlayShowBitrate => new(_haContext, "switch.basement_hall_camera_overlay_show_bitrate");
		///<summary>Basement Hall Camera Overlay: Show Date</summary>
		public SwitchEntity BasementHallCameraOverlayShowDate => new(_haContext, "switch.basement_hall_camera_overlay_show_date");
		///<summary>Basement Hall Camera Overlay: Show Logo</summary>
		public SwitchEntity BasementHallCameraOverlayShowLogo => new(_haContext, "switch.basement_hall_camera_overlay_show_logo");
		///<summary>Basement Hall Camera Overlay: Show Name</summary>
		public SwitchEntity BasementHallCameraOverlayShowName => new(_haContext, "switch.basement_hall_camera_overlay_show_name");
		///<summary>Basement Hall Camera Privacy Mode</summary>
		public SwitchEntity BasementHallCameraPrivacyMode => new(_haContext, "switch.basement_hall_camera_privacy_mode");
		///<summary>Basement Hall Camera Status Light On</summary>
		public SwitchEntity BasementHallCameraStatusLightOn => new(_haContext, "switch.basement_hall_camera_status_light_on");
		///<summary>Bedroom Echo Show do not disturb switch</summary>
		public SwitchEntity BedroomEchoShowDoNotDisturbSwitch => new(_haContext, "switch.bedroom_echo_show_do_not_disturb_switch");
		///<summary>Bedroom Echo Show repeat switch</summary>
		public SwitchEntity BedroomEchoShowRepeatSwitch => new(_haContext, "switch.bedroom_echo_show_repeat_switch");
		///<summary>Bedroom Echo Show shuffle switch</summary>
		public SwitchEntity BedroomEchoShowShuffleSwitch => new(_haContext, "switch.bedroom_echo_show_shuffle_switch");
		///<summary>Cat Feeder Restart</summary>
		public SwitchEntity CatFeederRestart => new(_haContext, "switch.cat_feeder_restart");
		///<summary>Cellar Door Camera Motion Detection</summary>
		public SwitchEntity CellarDoorCameraMotionDetection => new(_haContext, "switch.cellar_door_camera_motion_detection");
		///<summary>Cellar Door Camera Movies</summary>
		public SwitchEntity CellarDoorCameraMovies => new(_haContext, "switch.cellar_door_camera_movies");
		///<summary>Cellar Door Camera Still Images</summary>
		public SwitchEntity CellarDoorCameraStillImages => new(_haContext, "switch.cellar_door_camera_still_images");
		///<summary>Dining Room Echo Input do not disturb switch</summary>
		public SwitchEntity DiningRoomEchoInputDoNotDisturbSwitch => new(_haContext, "switch.dining_room_echo_input_do_not_disturb_switch");
		///<summary>Dining Room Echo Input repeat switch</summary>
		public SwitchEntity DiningRoomEchoInputRepeatSwitch => new(_haContext, "switch.dining_room_echo_input_repeat_switch");
		///<summary>Dining Room Echo Input shuffle switch</summary>
		public SwitchEntity DiningRoomEchoInputShuffleSwitch => new(_haContext, "switch.dining_room_echo_input_shuffle_switch");
		///<summary>Dispenser Motor</summary>
		public SwitchEntity DispenserMotor => new(_haContext, "switch.dispenser_motor");
		///<summary>Doorbell Chime</summary>
		public SwitchEntity DoorbellChime => new(_haContext, "switch.doorbell_chime");
		///<summary>Doorbell Chime Active</summary>
		public SwitchEntity DoorbellChimeActive => new(_haContext, "switch.doorbell_chime_active");
		///<summary>Doorbell Restart</summary>
		public SwitchEntity DoorbellRestart => new(_haContext, "switch.doorbell_restart");
		///<summary>Downstairs do not disturb switch</summary>
		public SwitchEntity DownstairsDoNotDisturbSwitch => new(_haContext, "switch.downstairs_do_not_disturb_switch");
		///<summary>Downstairs repeat switch</summary>
		public SwitchEntity DownstairsRepeatSwitch => new(_haContext, "switch.downstairs_repeat_switch");
		///<summary>Downstairs shuffle switch</summary>
		public SwitchEntity DownstairsShuffleSwitch => new(_haContext, "switch.downstairs_shuffle_switch");
		///<summary>Drawing Room Echo Dot do not disturb switch</summary>
		public SwitchEntity DrawingRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.drawing_room_echo_dot_do_not_disturb_switch");
		///<summary>Drawing Room Echo Dot repeat switch</summary>
		public SwitchEntity DrawingRoomEchoDotRepeatSwitch => new(_haContext, "switch.drawing_room_echo_dot_repeat_switch");
		///<summary>Drawing Room Echo Dot shuffle switch</summary>
		public SwitchEntity DrawingRoomEchoDotShuffleSwitch => new(_haContext, "switch.drawing_room_echo_dot_shuffle_switch");
		///<summary>Dressing Room Echo Dot do not disturb switch</summary>
		public SwitchEntity DressingRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.dressing_room_echo_dot_do_not_disturb_switch");
		///<summary>Dressing Room Echo Dot repeat switch</summary>
		public SwitchEntity DressingRoomEchoDotRepeatSwitch => new(_haContext, "switch.dressing_room_echo_dot_repeat_switch");
		///<summary>Dressing Room Echo Dot shuffle switch</summary>
		public SwitchEntity DressingRoomEchoDotShuffleSwitch => new(_haContext, "switch.dressing_room_echo_dot_shuffle_switch");
		///<summary>ESPresense Bedroom Active Scan</summary>
		public SwitchEntity EspresenseBedroomActiveScan => new(_haContext, "switch.espresense_bedroom_active_scan");
		///<summary>ESPresense Bedroom Arduino OTA</summary>
		public SwitchEntity EspresenseBedroomArduinoOta => new(_haContext, "switch.espresense_bedroom_arduino_ota");
		///<summary>ESPresense Bedroom Auto Update</summary>
		public SwitchEntity EspresenseBedroomAutoUpdate => new(_haContext, "switch.espresense_bedroom_auto_update");
		///<summary>ESPresense Bedroom OTA Update</summary>
		public SwitchEntity EspresenseBedroomOtaUpdate => new(_haContext, "switch.espresense_bedroom_ota_update");
		///<summary>ESPresense Bedroom Prerelease</summary>
		public SwitchEntity EspresenseBedroomPrerelease => new(_haContext, "switch.espresense_bedroom_prerelease");
		///<summary>ESPresense Bedroom Query</summary>
		public SwitchEntity EspresenseBedroomQuery => new(_haContext, "switch.espresense_bedroom_query");
		///<summary>ESPresense Bedroom Status LED</summary>
		public SwitchEntity EspresenseBedroomStatusLed => new(_haContext, "switch.espresense_bedroom_status_led");
		///<summary>ESPresense DrawingRoom Active Scan</summary>
		public SwitchEntity EspresenseDrawingroomActiveScan => new(_haContext, "switch.espresense_drawingroom_active_scan");
		///<summary>ESPresense DrawingRoom Query</summary>
		public SwitchEntity EspresenseDrawingroomQuery => new(_haContext, "switch.espresense_drawingroom_query");
		///<summary>ESPresense Kitchen Active Scan</summary>
		public SwitchEntity EspresenseKitchenActiveScan => new(_haContext, "switch.espresense_kitchen_active_scan");
		///<summary>ESPresense Kitchen Query</summary>
		public SwitchEntity EspresenseKitchenQuery => new(_haContext, "switch.espresense_kitchen_query");
		///<summary>ESPresense Kitchen Status LED</summary>
		public SwitchEntity EspresenseKitchenStatusLed => new(_haContext, "switch.espresense_kitchen_status_led");
		///<summary>ESPresense Lounge Active Scan</summary>
		public SwitchEntity EspresenseLoungeActiveScan => new(_haContext, "switch.espresense_lounge_active_scan");
		///<summary>ESPresense Lounge Arduino OTA</summary>
		public SwitchEntity EspresenseLoungeArduinoOta => new(_haContext, "switch.espresense_lounge_arduino_ota");
		///<summary>ESPresense Lounge Auto Update</summary>
		public SwitchEntity EspresenseLoungeAutoUpdate => new(_haContext, "switch.espresense_lounge_auto_update");
		///<summary>ESPresense Lounge Prerelease</summary>
		public SwitchEntity EspresenseLoungePrerelease => new(_haContext, "switch.espresense_lounge_prerelease");
		///<summary>ESPresense Lounge Query</summary>
		public SwitchEntity EspresenseLoungeQuery => new(_haContext, "switch.espresense_lounge_query");
		///<summary>ESPresense Lounge Status LED</summary>
		public SwitchEntity EspresenseLoungeStatusLed => new(_haContext, "switch.espresense_lounge_status_led");
		///<summary>ESPresense Snug Active Scan</summary>
		public SwitchEntity EspresenseSnugActiveScan => new(_haContext, "switch.espresense_snug_active_scan");
		///<summary>ESPresense Snug Arduino OTA</summary>
		public SwitchEntity EspresenseSnugArduinoOta => new(_haContext, "switch.espresense_snug_arduino_ota");
		///<summary>ESPresense Snug Auto Update</summary>
		public SwitchEntity EspresenseSnugAutoUpdate => new(_haContext, "switch.espresense_snug_auto_update");
		///<summary>ESPresense Snug Prerelease</summary>
		public SwitchEntity EspresenseSnugPrerelease => new(_haContext, "switch.espresense_snug_prerelease");
		///<summary>ESPresense Snug Query</summary>
		public SwitchEntity EspresenseSnugQuery => new(_haContext, "switch.espresense_snug_query");
		///<summary>ESPresense Snug Status LED</summary>
		public SwitchEntity EspresenseSnugStatusLed => new(_haContext, "switch.espresense_snug_status_led");
		///<summary>ESPresense Studio Active Scan</summary>
		public SwitchEntity EspresenseStudioActiveScan => new(_haContext, "switch.espresense_studio_active_scan");
		///<summary>ESPresense Studio Query</summary>
		public SwitchEntity EspresenseStudioQuery => new(_haContext, "switch.espresense_studio_query");
		///<summary>Guest Room Echo Show do not disturb switch</summary>
		public SwitchEntity GuestRoomEchoShowDoNotDisturbSwitch => new(_haContext, "switch.guest_room_echo_show_do_not_disturb_switch");
		///<summary>Guest Room Echo Show repeat switch</summary>
		public SwitchEntity GuestRoomEchoShowRepeatSwitch => new(_haContext, "switch.guest_room_echo_show_repeat_switch");
		///<summary>Guest Room Echo Show shuffle switch</summary>
		public SwitchEntity GuestRoomEchoShowShuffleSwitch => new(_haContext, "switch.guest_room_echo_show_shuffle_switch");
		///<summary>Hall Tablet do not disturb switch</summary>
		public SwitchEntity HallTabletDoNotDisturbSwitch => new(_haContext, "switch.hall_tablet_do_not_disturb_switch");
		///<summary>homeassistant Active</summary>
		public SwitchEntity HomeassistantActive => new(_haContext, "switch.homeassistant_active");
		///<summary>Kitchen Camera HDR Mode</summary>
		public SwitchEntity KitchenCameraHdrMode => new(_haContext, "switch.kitchen_camera_hdr_mode");
		///<summary>Kitchen Camera Overlay: Show Bitrate</summary>
		public SwitchEntity KitchenCameraOverlayShowBitrate => new(_haContext, "switch.kitchen_camera_overlay_show_bitrate");
		///<summary>Kitchen Camera Overlay: Show Date</summary>
		public SwitchEntity KitchenCameraOverlayShowDate => new(_haContext, "switch.kitchen_camera_overlay_show_date");
		///<summary>Kitchen Camera Overlay: Show Logo</summary>
		public SwitchEntity KitchenCameraOverlayShowLogo => new(_haContext, "switch.kitchen_camera_overlay_show_logo");
		///<summary>Kitchen Camera Overlay: Show Name</summary>
		public SwitchEntity KitchenCameraOverlayShowName => new(_haContext, "switch.kitchen_camera_overlay_show_name");
		///<summary>Kitchen Camera Privacy Mode</summary>
		public SwitchEntity KitchenCameraPrivacyMode => new(_haContext, "switch.kitchen_camera_privacy_mode");
		///<summary>Kitchen Camera Status Light On</summary>
		public SwitchEntity KitchenCameraStatusLightOn => new(_haContext, "switch.kitchen_camera_status_light_on");
		///<summary>Kitchen Echo Show do not disturb switch</summary>
		public SwitchEntity KitchenEchoShowDoNotDisturbSwitch => new(_haContext, "switch.kitchen_echo_show_do_not_disturb_switch");
		///<summary>Kitchen Echo Show repeat switch</summary>
		public SwitchEntity KitchenEchoShowRepeatSwitch => new(_haContext, "switch.kitchen_echo_show_repeat_switch");
		///<summary>Kitchen Echo Show shuffle switch</summary>
		public SwitchEntity KitchenEchoShowShuffleSwitch => new(_haContext, "switch.kitchen_echo_show_shuffle_switch");
		///<summary>Landing Tablet do not disturb switch</summary>
		public SwitchEntity LandingTabletDoNotDisturbSwitch => new(_haContext, "switch.landing_tablet_do_not_disturb_switch");
		///<summary>Lounge Echo Plus do not disturb switch</summary>
		public SwitchEntity LoungeEchoPlusDoNotDisturbSwitch => new(_haContext, "switch.lounge_echo_plus_do_not_disturb_switch");
		///<summary>Lounge Echo Plus repeat switch</summary>
		public SwitchEntity LoungeEchoPlusRepeatSwitch => new(_haContext, "switch.lounge_echo_plus_repeat_switch");
		///<summary>Lounge Echo Plus shuffle switch</summary>
		public SwitchEntity LoungeEchoPlusShuffleSwitch => new(_haContext, "switch.lounge_echo_plus_shuffle_switch");
		///<summary>Lounge Fire TV do not disturb switch</summary>
		public SwitchEntity LoungeFireTvDoNotDisturbSwitch => new(_haContext, "switch.lounge_fire_tv_do_not_disturb_switch");
		///<summary>Lounge TV</summary>
		public SwitchEntity LoungeTv => new(_haContext, "switch.lounge_tv");
		///<summary>Mark Schedule</summary>
		public SwitchEntity MarkSchedule => new(_haContext, "switch.mark_schedule");
		///<summary>Patio Camera Detections: Person</summary>
		public SwitchEntity PatioCameraDetectionsPerson => new(_haContext, "switch.patio_camera_detections_person");
		///<summary>Patio Camera Detections: Vehicle</summary>
		public SwitchEntity PatioCameraDetectionsVehicle => new(_haContext, "switch.patio_camera_detections_vehicle");
		///<summary>Patio Camera HDR Mode</summary>
		public SwitchEntity PatioCameraHdrMode => new(_haContext, "switch.patio_camera_hdr_mode");
		///<summary>Patio Camera High FPS</summary>
		public SwitchEntity PatioCameraHighFps => new(_haContext, "switch.patio_camera_high_fps");
		///<summary>Patio Camera Overlay: Show Bitrate</summary>
		public SwitchEntity PatioCameraOverlayShowBitrate => new(_haContext, "switch.patio_camera_overlay_show_bitrate");
		///<summary>Patio Camera Overlay: Show Date</summary>
		public SwitchEntity PatioCameraOverlayShowDate => new(_haContext, "switch.patio_camera_overlay_show_date");
		///<summary>Patio Camera Overlay: Show Logo</summary>
		public SwitchEntity PatioCameraOverlayShowLogo => new(_haContext, "switch.patio_camera_overlay_show_logo");
		///<summary>Patio Camera Overlay: Show Name</summary>
		public SwitchEntity PatioCameraOverlayShowName => new(_haContext, "switch.patio_camera_overlay_show_name");
		///<summary>Patio Camera Privacy Mode</summary>
		public SwitchEntity PatioCameraPrivacyMode => new(_haContext, "switch.patio_camera_privacy_mode");
		///<summary>Restart Weather Station</summary>
		public SwitchEntity RestartWeatherStation => new(_haContext, "switch.restart_weather_station");
		///<summary>Snug do not disturb switch</summary>
		public SwitchEntity SnugDoNotDisturbSwitch => new(_haContext, "switch.snug_do_not_disturb_switch");
		///<summary>Snug Echo Input do not disturb switch</summary>
		public SwitchEntity SnugEchoInputDoNotDisturbSwitch => new(_haContext, "switch.snug_echo_input_do_not_disturb_switch");
		///<summary>Snug Echo Input repeat switch</summary>
		public SwitchEntity SnugEchoInputRepeatSwitch => new(_haContext, "switch.snug_echo_input_repeat_switch");
		///<summary>Snug Echo Input shuffle switch</summary>
		public SwitchEntity SnugEchoInputShuffleSwitch => new(_haContext, "switch.snug_echo_input_shuffle_switch");
		///<summary>Snug repeat switch</summary>
		public SwitchEntity SnugRepeatSwitch => new(_haContext, "switch.snug_repeat_switch");
		///<summary>Snug shuffle switch</summary>
		public SwitchEntity SnugShuffleSwitch => new(_haContext, "switch.snug_shuffle_switch");
		///<summary>Sump Alarm Reset</summary>
		public SwitchEntity SumpAlarmReset => new(_haContext, "switch.sump_alarm_reset");
		///<summary>Sump Alarm Restart</summary>
		public SwitchEntity SumpAlarmRestart => new(_haContext, "switch.sump_alarm_restart");
		///<summary>Upstairs do not disturb switch</summary>
		public SwitchEntity UpstairsDoNotDisturbSwitch => new(_haContext, "switch.upstairs_do_not_disturb_switch");
		///<summary>Upstairs repeat switch</summary>
		public SwitchEntity UpstairsRepeatSwitch => new(_haContext, "switch.upstairs_repeat_switch");
		///<summary>Upstairs shuffle switch</summary>
		public SwitchEntity UpstairsShuffleSwitch => new(_haContext, "switch.upstairs_shuffle_switch");
		///<summary>Utility Room Echo Dot do not disturb switch</summary>
		public SwitchEntity UtilityRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.utility_room_echo_dot_do_not_disturb_switch");
		///<summary>Utility Room Echo Dot repeat switch</summary>
		public SwitchEntity UtilityRoomEchoDotRepeatSwitch => new(_haContext, "switch.utility_room_echo_dot_repeat_switch");
		///<summary>Utility Room Echo Dot shuffle switch</summary>
		public SwitchEntity UtilityRoomEchoDotShuffleSwitch => new(_haContext, "switch.utility_room_echo_dot_shuffle_switch");
	}

	public class TimerEntities
	{
		private readonly IHaContext _haContext;
		public TimerEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Lounge</summary>
		public TimerEntity Lounge => new(_haContext, "timer.lounge");
		///<summary>shower</summary>
		public TimerEntity Shower => new(_haContext, "timer.shower");
	}

	public class UpdateEntities
	{
		private readonly IHaContext _haContext;
		public UpdateEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>AdGuard Home: Update</summary>
		public UpdateEntity AdguardHomeUpdate => new(_haContext, "update.adguard_home_update");
		///<summary>AppDaemon: Update</summary>
		public UpdateEntity AppdaemonUpdate => new(_haContext, "update.appdaemon_update");
		///<summary>Check Home Assistant configuration: Update</summary>
		public UpdateEntity CheckHomeAssistantConfigurationUpdate => new(_haContext, "update.check_home_assistant_configuration_update");
		///<summary>Dream Machine Pro</summary>
		public UpdateEntity DreamMachinePro => new(_haContext, "update.dream_machine_pro");
		///<summary>ESPHome: Update</summary>
		public UpdateEntity EsphomeUpdate => new(_haContext, "update.esphome_update");
		///<summary>eWeLink Smart Home: Update</summary>
		public UpdateEntity EwelinkSmartHomeUpdate => new(_haContext, "update.ewelink_smart_home_update");
		///<summary>File editor: Update</summary>
		public UpdateEntity FileEditorUpdate => new(_haContext, "update.file_editor_update");
		///<summary>Glances: Update</summary>
		public UpdateEntity GlancesUpdate => new(_haContext, "update.glances_update");
		///<summary>Grafana: Update</summary>
		public UpdateEntity GrafanaUpdate => new(_haContext, "update.grafana_update");
		///<summary>Home Assistant Core: Update</summary>
		public UpdateEntity HomeAssistantCoreUpdate => new(_haContext, "update.home_assistant_core_update");
		///<summary>Home Assistant Google Drive Backup: Update</summary>
		public UpdateEntity HomeAssistantGoogleDriveBackupUpdate => new(_haContext, "update.home_assistant_google_drive_backup_update");
		///<summary>Home Assistant Supervisor: Update</summary>
		public UpdateEntity HomeAssistantSupervisorUpdate => new(_haContext, "update.home_assistant_supervisor_update");
		///<summary>InfluxDB: Update</summary>
		public UpdateEntity InfluxdbUpdate => new(_haContext, "update.influxdb_update");
		///<summary>MariaDB: Update</summary>
		public UpdateEntity MariadbUpdate => new(_haContext, "update.mariadb_update");
		///<summary>Mosquitto broker: Update</summary>
		public UpdateEntity MosquittoBrokerUpdate => new(_haContext, "update.mosquitto_broker_update");
		///<summary>motionEye: Update</summary>
		public UpdateEntity MotioneyeUpdate => new(_haContext, "update.motioneye_update");
		///<summary>NetDaemon V3 - beta: Update</summary>
		public UpdateEntity NetdaemonV3BetaUpdate => new(_haContext, "update.netdaemon_v3_beta_update");
		///<summary>Nginx Proxy Manager: Update</summary>
		public UpdateEntity NginxProxyManagerUpdate => new(_haContext, "update.nginx_proxy_manager_update");
		///<summary>Plex Media Server: Update</summary>
		public UpdateEntity PlexMediaServerUpdate => new(_haContext, "update.plex_media_server_update");
		///<summary>Portainer: Update</summary>
		public UpdateEntity PortainerUpdate => new(_haContext, "update.portainer_update");
		///<summary>Samba share: Update</summary>
		public UpdateEntity SambaShareUpdate => new(_haContext, "update.samba_share_update");
		///<summary>Studio Code Server: Update</summary>
		public UpdateEntity StudioCodeServerUpdate => new(_haContext, "update.studio_code_server_update");
		///<summary>TasmoAdmin: Update</summary>
		public UpdateEntity TasmoadminUpdate => new(_haContext, "update.tasmoadmin_update");
		///<summary>Terminal & SSH: Update</summary>
		public UpdateEntity TerminalSshUpdate => new(_haContext, "update.terminal_ssh_update");
		///<summary>UAP-AC-LR-Basement</summary>
		public UpdateEntity UapAcLrBasement => new(_haContext, "update.uap_ac_lr_basement");
		///<summary>UAP-AC-LR-Upstairs</summary>
		public UpdateEntity UapAcLrUpstairs => new(_haContext, "update.uap_ac_lr_upstairs");
		///<summary>UAP-FlexHD-Groundfloor</summary>
		public UpdateEntity UapFlexhdGroundfloor => new(_haContext, "update.uap_flexhd_groundfloor");
		///<summary>VSCode Remote: Update</summary>
		public UpdateEntity VscodeRemoteUpdate => new(_haContext, "update.vscode_remote_update");
		///<summary>WireGuard: Update</summary>
		public UpdateEntity WireguardUpdate => new(_haContext, "update.wireguard_update");
		///<summary>Zigbee2mqtt Edge: Update</summary>
		public UpdateEntity Zigbee2mqttEdgeUpdate => new(_haContext, "update.zigbee2mqtt_edge_update");
	}

	public class VacuumEntities
	{
		private readonly IHaContext _haContext;
		public VacuumEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Mark</summary>
		public VacuumEntity Mark => new(_haContext, "vacuum.mark");
	}

	public class WeatherEntities
	{
		private readonly IHaContext _haContext;
		public WeatherEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>stockport</summary>
		public WeatherEntity Stockport => new(_haContext, "weather.stockport");
	}

	public class ZoneEntities
	{
		private readonly IHaContext _haContext;
		public ZoneEntities(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Adam's</summary>
		public ZoneEntity AdamS => new(_haContext, "zone.adam_s");
		///<summary>Amy's</summary>
		public ZoneEntity AmyS => new(_haContext, "zone.amy_s");
		///<summary>Andy's Parent's</summary>
		public ZoneEntity AndySParentS => new(_haContext, "zone.andy_s_parent_s");
		///<summary>Andy's Work</summary>
		public ZoneEntity AndyWork => new(_haContext, "zone.andy_work");
		///<summary>Chris & Rach London</summary>
		public ZoneEntity ChrisRachLondon => new(_haContext, "zone.chris_rach_london");
		///<summary>Claire's Work</summary>
		public ZoneEntity ClaireWork => new(_haContext, "zone.claire_work");
		///<summary>Gym</summary>
		public ZoneEntity Gym => new(_haContext, "zone.gym");
		///<summary>Heaton Hops</summary>
		public ZoneEntity HeatonHops => new(_haContext, "zone.heaton_hops");
		///<summary>Heaton moor 1</summary>
		public ZoneEntity HeatonMoor1 => new(_haContext, "zone.heaton_moor_1");
		///<summary>Heaton Moor 2</summary>
		public ZoneEntity HeatonMoor2 => new(_haContext, "zone.heaton_moor_2");
		///<summary>Home</summary>
		public ZoneEntity Home => new(_haContext, "zone.home");
		///<summary>Man Utd</summary>
		public ZoneEntity ManUtd => new(_haContext, "zone.man_utd");
		///<summary>Rachael And Chris</summary>
		public ZoneEntity RachaelAndChris => new(_haContext, "zone.rachael_and_chris");
	}

	public record AlarmControlPanelEntity : Entity<AlarmControlPanelEntity, EntityState<AlarmControlPanelAttributes>, AlarmControlPanelAttributes>
	{
		public AlarmControlPanelEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public AlarmControlPanelEntity(Entity entity) : base(entity)
		{
		}
	}

	public record AutomationEntity : Entity<AutomationEntity, EntityState<AutomationAttributes>, AutomationAttributes>
	{
		public AutomationEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public AutomationEntity(Entity entity) : base(entity)
		{
		}
	}

	public record BinarySensorEntity : Entity<BinarySensorEntity, EntityState<BinarySensorAttributes>, BinarySensorAttributes>
	{
		public BinarySensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public BinarySensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ButtonEntity : Entity<ButtonEntity, EntityState<ButtonAttributes>, ButtonAttributes>
	{
		public ButtonEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ButtonEntity(Entity entity) : base(entity)
		{
		}
	}

	public record CalendarEntity : Entity<CalendarEntity, EntityState<CalendarAttributes>, CalendarAttributes>
	{
		public CalendarEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public CalendarEntity(Entity entity) : base(entity)
		{
		}
	}

	public record CameraEntity : Entity<CameraEntity, EntityState<CameraAttributes>, CameraAttributes>
	{
		public CameraEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public CameraEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ClimateEntity : Entity<ClimateEntity, EntityState<ClimateAttributes>, ClimateAttributes>
	{
		public ClimateEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ClimateEntity(Entity entity) : base(entity)
		{
		}
	}

	public record DeviceTrackerEntity : Entity<DeviceTrackerEntity, EntityState<DeviceTrackerAttributes>, DeviceTrackerAttributes>
	{
		public DeviceTrackerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public DeviceTrackerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record EntityControllerEntity : Entity<EntityControllerEntity, EntityState<EntityControllerAttributes>, EntityControllerAttributes>
	{
		public EntityControllerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public EntityControllerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record FanEntity : Entity<FanEntity, EntityState<FanAttributes>, FanAttributes>
	{
		public FanEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public FanEntity(Entity entity) : base(entity)
		{
		}
	}

	public record GroupEntity : Entity<GroupEntity, EntityState<GroupAttributes>, GroupAttributes>
	{
		public GroupEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public GroupEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputBooleanEntity : Entity<InputBooleanEntity, EntityState<InputBooleanAttributes>, InputBooleanAttributes>
	{
		public InputBooleanEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputBooleanEntity(Entity entity) : base(entity)
		{
		}
	}

	public record InputSelectEntity : Entity<InputSelectEntity, EntityState<InputSelectAttributes>, InputSelectAttributes>
	{
		public InputSelectEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public InputSelectEntity(Entity entity) : base(entity)
		{
		}
	}

	public record LightEntity : Entity<LightEntity, EntityState<LightAttributes>, LightAttributes>
	{
		public LightEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public LightEntity(Entity entity) : base(entity)
		{
		}
	}

	public record MediaPlayerEntity : Entity<MediaPlayerEntity, EntityState<MediaPlayerAttributes>, MediaPlayerAttributes>
	{
		public MediaPlayerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public MediaPlayerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record NumberEntity : NumericEntity<NumberEntity, NumericEntityState<NumberAttributes>, NumberAttributes>
	{
		public NumberEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public NumberEntity(Entity entity) : base(entity)
		{
		}
	}

	public record PersonEntity : Entity<PersonEntity, EntityState<PersonAttributes>, PersonAttributes>
	{
		public PersonEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public PersonEntity(Entity entity) : base(entity)
		{
		}
	}

	public record RemoteEntity : Entity<RemoteEntity, EntityState<RemoteAttributes>, RemoteAttributes>
	{
		public RemoteEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public RemoteEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SceneEntity : Entity<SceneEntity, EntityState<SceneAttributes>, SceneAttributes>
	{
		public SceneEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SceneEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ScriptEntity : Entity<ScriptEntity, EntityState<ScriptAttributes>, ScriptAttributes>
	{
		public ScriptEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ScriptEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SelectEntity : Entity<SelectEntity, EntityState<SelectAttributes>, SelectAttributes>
	{
		public SelectEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SelectEntity(Entity entity) : base(entity)
		{
		}
	}

	public record NumericSensorEntity : NumericEntity<NumericSensorEntity, NumericEntityState<NumericSensorAttributes>, NumericSensorAttributes>
	{
		public NumericSensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public NumericSensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SensorEntity : Entity<SensorEntity, EntityState<SensorAttributes>, SensorAttributes>
	{
		public SensorEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SensorEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SunEntity : Entity<SunEntity, EntityState<SunAttributes>, SunAttributes>
	{
		public SunEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SunEntity(Entity entity) : base(entity)
		{
		}
	}

	public record SwitchEntity : Entity<SwitchEntity, EntityState<SwitchAttributes>, SwitchAttributes>
	{
		public SwitchEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public SwitchEntity(Entity entity) : base(entity)
		{
		}
	}

	public record TimerEntity : Entity<TimerEntity, EntityState<TimerAttributes>, TimerAttributes>
	{
		public TimerEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public TimerEntity(Entity entity) : base(entity)
		{
		}
	}

	public record UpdateEntity : Entity<UpdateEntity, EntityState<UpdateAttributes>, UpdateAttributes>
	{
		public UpdateEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public UpdateEntity(Entity entity) : base(entity)
		{
		}
	}

	public record VacuumEntity : Entity<VacuumEntity, EntityState<VacuumAttributes>, VacuumAttributes>
	{
		public VacuumEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public VacuumEntity(Entity entity) : base(entity)
		{
		}
	}

	public record WeatherEntity : Entity<WeatherEntity, EntityState<WeatherAttributes>, WeatherAttributes>
	{
		public WeatherEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public WeatherEntity(Entity entity) : base(entity)
		{
		}
	}

	public record ZoneEntity : Entity<ZoneEntity, EntityState<ZoneAttributes>, ZoneAttributes>
	{
		public ZoneEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}

		public ZoneEntity(Entity entity) : base(entity)
		{
		}
	}

	public record AlarmControlPanelAttributes
	{
		[JsonPropertyName("changed_by")]
		public object? ChangedBy { get; init; }

		[JsonPropertyName("code_arm_required")]
		public bool? CodeArmRequired { get; init; }

		[JsonPropertyName("code_format")]
		public string? CodeFormat { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record AutomationAttributes
	{
		[JsonPropertyName("current")]
		public double? Current { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }

		[JsonPropertyName("last_triggered")]
		public string? LastTriggered { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record BinarySensorAttributes
	{
		[JsonPropertyName("adverts")]
		public double? Adverts { get; init; }

		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("battery")]
		public double? Battery { get; init; }

		[JsonPropertyName("battery_low")]
		public bool? BatteryLow { get; init; }

		[JsonPropertyName("box")]
		public string? Box { get; init; }

		[JsonPropertyName("contact")]
		public bool? Contact { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		[JsonPropertyName("event_score")]
		public double? EventScore { get; init; }

		[JsonPropertyName("firm")]
		public string? Firm { get; init; }

		[JsonPropertyName("freeHeap")]
		public double? FreeHeap { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("ip")]
		public string? Ip { get; init; }

		[JsonPropertyName("last_changed")]
		public string? LastChanged { get; init; }

		[JsonPropertyName("linkquality")]
		public double? Linkquality { get; init; }

		[JsonPropertyName("maxAllocHeap")]
		public double? MaxAllocHeap { get; init; }

		[JsonPropertyName("memFrag")]
		public double? MemFrag { get; init; }

		[JsonPropertyName("model")]
		public string? Model { get; init; }

		[JsonPropertyName("occupancy")]
		public bool? Occupancy { get; init; }

		[JsonPropertyName("queried")]
		public double? Queried { get; init; }

		[JsonPropertyName("reported")]
		public double? Reported { get; init; }

		[JsonPropertyName("reportHighWater")]
		public double? ReportHighWater { get; init; }

		[JsonPropertyName("resetReason")]
		public string? ResetReason { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("rssi")]
		public double? Rssi { get; init; }

		[JsonPropertyName("scanHighWater")]
		public double? ScanHighWater { get; init; }

		[JsonPropertyName("seen")]
		public double? Seen { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("tamper")]
		public bool? Tamper { get; init; }

		[JsonPropertyName("target")]
		public string? Target { get; init; }

		[JsonPropertyName("uptime")]
		public double? Uptime { get; init; }

		[JsonPropertyName("ver")]
		public string? Ver { get; init; }

		[JsonPropertyName("voltage")]
		public double? Voltage { get; init; }

		[JsonPropertyName("wasp")]
		public string? Wasp { get; init; }
	}

	public record ButtonAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }
	}

	public record CalendarAttributes
	{
		[JsonPropertyName("all_day")]
		public bool? AllDay { get; init; }

		[JsonPropertyName("description")]
		public string? Description { get; init; }

		[JsonPropertyName("end_time")]
		public string? EndTime { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("location")]
		public string? Location { get; init; }

		[JsonPropertyName("message")]
		public string? Message { get; init; }

		[JsonPropertyName("offset_reached")]
		public bool? OffsetReached { get; init; }

		[JsonPropertyName("start_time")]
		public string? StartTime { get; init; }
	}

	public record CameraAttributes
	{
		[JsonPropertyName("access_token")]
		public string? AccessToken { get; init; }

		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("bitrate")]
		public double? Bitrate { get; init; }

		[JsonPropertyName("brand")]
		public string? Brand { get; init; }

		[JsonPropertyName("channel_id")]
		public double? ChannelId { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("fps")]
		public double? Fps { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("frontend_stream_type")]
		public string? FrontendStreamType { get; init; }

		[JsonPropertyName("generated_at")]
		public string? GeneratedAt { get; init; }

		[JsonPropertyName("height")]
		public double? Height { get; init; }

		[JsonPropertyName("motion_detection")]
		public bool? MotionDetection { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("width")]
		public double? Width { get; init; }
	}

	public record ClimateAttributes
	{
		[JsonPropertyName("current_temperature")]
		public double? CurrentTemperature { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("hvac_action")]
		public string? HvacAction { get; init; }

		[JsonPropertyName("hvac_modes")]
		public object? HvacModes { get; init; }

		[JsonPropertyName("max_temp")]
		public double? MaxTemp { get; init; }

		[JsonPropertyName("min_temp")]
		public double? MinTemp { get; init; }

		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }

		[JsonPropertyName("preset_modes")]
		public object? PresetModes { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; init; }
	}

	public record DeviceTrackerAttributes
	{
		[JsonPropertyName("account_fetch_interval")]
		public double? AccountFetchInterval { get; init; }

		[JsonPropertyName("altitude")]
		public double? Altitude { get; init; }

		[JsonPropertyName("ap_mac")]
		public string? ApMac { get; init; }

		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("battery")]
		public double? Battery { get; init; }

		[JsonPropertyName("battery_level")]
		public double? BatteryLevel { get; init; }

		[JsonPropertyName("battery_status")]
		public string? BatteryStatus { get; init; }

		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }

		[JsonPropertyName("device_status")]
		public string? DeviceStatus { get; init; }

		[JsonPropertyName("essid")]
		public string? Essid { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[JsonPropertyName("hostname")]
		public string? Hostname { get; init; }

		[JsonPropertyName("host_name")]
		public string? HostName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("ip")]
		public string? Ip { get; init; }

		[JsonPropertyName("is_11r")]
		public bool? Is11r { get; init; }

		[JsonPropertyName("is_guest")]
		public bool? IsGuest { get; init; }

		[JsonPropertyName("_is_guest_by_uap")]
		public bool? IsGuestByUap { get; init; }

		[JsonPropertyName("is_lost")]
		public bool? IsLost { get; init; }

		[JsonPropertyName("is_wired")]
		public bool? IsWired { get; init; }

		[JsonPropertyName("last_lost_timestamp")]
		public string? LastLostTimestamp { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("low_power_mode")]
		public bool? LowPowerMode { get; init; }

		[JsonPropertyName("mac")]
		public string? Mac { get; init; }

		[JsonPropertyName("name")]
		public string? Name { get; init; }

		[JsonPropertyName("note")]
		public string? Note { get; init; }

		[JsonPropertyName("oui")]
		public string? Oui { get; init; }

		[JsonPropertyName("owner_fullname")]
		public string? OwnerFullname { get; init; }

		[JsonPropertyName("qos_policy_applied")]
		public bool? QosPolicyApplied { get; init; }

		[JsonPropertyName("radio")]
		public string? Radio { get; init; }

		[JsonPropertyName("radio_proto")]
		public string? RadioProto { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("ring_state")]
		public string? RingState { get; init; }

		[JsonPropertyName("source_type")]
		public string? SourceType { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("vertical_accuracy")]
		public double? VerticalAccuracy { get; init; }

		[JsonPropertyName("vlan")]
		public double? Vlan { get; init; }

		[JsonPropertyName("voip_state")]
		public string? VoipState { get; init; }
	}

	public record EntityControllerAttributes
	{
		[JsonPropertyName("delay")]
		public string? Delay { get; init; }

		[JsonPropertyName("end")]
		public string? End { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("last_triggered_at")]
		public string? LastTriggeredAt { get; init; }

		[JsonPropertyName("last_triggered_by")]
		public string? LastTriggeredBy { get; init; }

		[JsonPropertyName("sensor_type")]
		public string? SensorType { get; init; }

		[JsonPropertyName("start")]
		public string? Start { get; init; }
	}

	public record FanAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record GroupAttributes
	{
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("order")]
		public double? Order { get; init; }
	}

	public record InputBooleanAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }
	}

	public record InputSelectAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public record LightAttributes
	{
		[JsonPropertyName("brightness")]
		public double? Brightness { get; init; }

		[JsonPropertyName("color_mode")]
		public string? ColorMode { get; init; }

		[JsonPropertyName("color_temp")]
		public double? ColorTemp { get; init; }

		[JsonPropertyName("effect_list")]
		public object? EffectList { get; init; }

		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		[JsonPropertyName("flowing")]
		public bool? Flowing { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("max_mireds")]
		public double? MaxMireds { get; init; }

		[JsonPropertyName("min_mireds")]
		public double? MinMireds { get; init; }

		[JsonPropertyName("music_mode")]
		public bool? MusicMode { get; init; }

		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		[JsonPropertyName("supported_color_modes")]
		public object? SupportedColorModes { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("xy_color")]
		public object? XyColor { get; init; }
	}

	public record MediaPlayerAttributes
	{
		[JsonPropertyName("available")]
		public bool? Available { get; init; }

		[JsonPropertyName("bluetooth_list")]
		public object? BluetoothList { get; init; }

		[JsonPropertyName("connected_bluetooth")]
		public object? ConnectedBluetooth { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("entity_picture_local")]
		public string? EntityPictureLocal { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("is_volume_muted")]
		public bool? IsVolumeMuted { get; init; }

		[JsonPropertyName("last_called")]
		public bool? LastCalled { get; init; }

		[JsonPropertyName("last_called_summary")]
		public string? LastCalledSummary { get; init; }

		[JsonPropertyName("last_called_timestamp")]
		public double? LastCalledTimestamp { get; init; }

		[JsonPropertyName("media_album_name")]
		public string? MediaAlbumName { get; init; }

		[JsonPropertyName("media_artist")]
		public string? MediaArtist { get; init; }

		[JsonPropertyName("media_content_type")]
		public string? MediaContentType { get; init; }

		[JsonPropertyName("media_duration")]
		public double? MediaDuration { get; init; }

		[JsonPropertyName("media_position")]
		public double? MediaPosition { get; init; }

		[JsonPropertyName("media_position_updated_at")]
		public string? MediaPositionUpdatedAt { get; init; }

		[JsonPropertyName("media_title")]
		public string? MediaTitle { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("shuffle")]
		public bool? Shuffle { get; init; }

		[JsonPropertyName("source")]
		public string? Source { get; init; }

		[JsonPropertyName("source_list")]
		public object? SourceList { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }
	}

	public record NumberAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("max")]
		public double? Max { get; init; }

		[JsonPropertyName("min")]
		public double? Min { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }

		[JsonPropertyName("step")]
		public double? Step { get; init; }
	}

	public record PersonAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("source")]
		public string? Source { get; init; }

		[JsonPropertyName("user_id")]
		public string? UserId { get; init; }
	}

	public record RemoteAttributes
	{
		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record SceneAttributes
	{
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("id")]
		public string? Id { get; init; }
	}

	public record ScriptAttributes
	{
		[JsonPropertyName("current")]
		public double? Current { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("last_triggered")]
		public string? LastTriggered { get; init; }

		[JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public record SelectAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public record NumericSensorAttributes
	{
		[JsonPropertyName("account_fetch_interval")]
		public double? AccountFetchInterval { get; init; }

		[JsonPropertyName("action")]
		public object? Action { get; init; }

		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("Available")]
		public string? Available { get; init; }

		[JsonPropertyName("Available (Important)")]
		public string? AvailableImportant { get; init; }

		[JsonPropertyName("Available (Opportunistic)")]
		public string? AvailableOpportunistic { get; init; }

		[JsonPropertyName("battery")]
		public double? Battery { get; init; }

		[JsonPropertyName("battery_low")]
		public bool? BatteryLow { get; init; }

		[JsonPropertyName("battery_status")]
		public string? BatteryStatus { get; init; }

		[JsonPropertyName("bytes_received")]
		public double? BytesReceived { get; init; }

		[JsonPropertyName("bytes_sent")]
		public double? BytesSent { get; init; }

		[JsonPropertyName("contact")]
		public bool? Contact { get; init; }

		[JsonPropertyName("country_code")]
		public string? CountryCode { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }

		[JsonPropertyName("device_status")]
		public string? DeviceStatus { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("linkquality")]
		public double? Linkquality { get; init; }

		[JsonPropertyName("low_power_mode")]
		public bool? LowPowerMode { get; init; }

		[JsonPropertyName("occupancy")]
		public bool? Occupancy { get; init; }

		[JsonPropertyName("owner_fullname")]
		public string? OwnerFullname { get; init; }

		[JsonPropertyName("repositories")]
		public object? Repositories { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("server_country")]
		public string? ServerCountry { get; init; }

		[JsonPropertyName("server_id")]
		public string? ServerId { get; init; }

		[JsonPropertyName("server_name")]
		public string? ServerName { get; init; }

		[JsonPropertyName("state_class")]
		public string? StateClass { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("tamper")]
		public bool? Tamper { get; init; }

		[JsonPropertyName("Total")]
		public string? Total { get; init; }

		[JsonPropertyName("unit_of_measurement")]
		public string? UnitOfMeasurement { get; init; }

		[JsonPropertyName("voltage")]
		public double? Voltage { get; init; }
	}

	public record SensorAttributes
	{
		[JsonPropertyName("action")]
		public object? Action { get; init; }

		[JsonPropertyName("actions")]
		public object? Actions { get; init; }

		[JsonPropertyName("Administrative Area")]
		public string? AdministrativeArea { get; init; }

		[JsonPropertyName("Allows VoIP")]
		public bool? AllowsVoIP { get; init; }

		[JsonPropertyName("Areas Of Interest")]
		public string? AreasOfInterest { get; init; }

		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("backups")]
		public object? Backups { get; init; }

		[JsonPropertyName("backups_in_google_drive")]
		public double? BackupsInGoogleDrive { get; init; }

		[JsonPropertyName("backups_in_home_assistant")]
		public double? BackupsInHomeAssistant { get; init; }

		[JsonPropertyName("battery")]
		public double? Battery { get; init; }

		[JsonPropertyName("Carrier ID")]
		public string? CarrierID { get; init; }

		[JsonPropertyName("Carrier Name")]
		public string? CarrierName { get; init; }

		[JsonPropertyName("Cellular Technology")]
		public string? CellularTechnology { get; init; }

		[JsonPropertyName("Confidence")]
		public string? Confidence { get; init; }

		[JsonPropertyName("Country")]
		public string? Country { get; init; }

		[JsonPropertyName("Current Radio Technology")]
		public string? CurrentRadioTechnology { get; init; }

		[JsonPropertyName("days")]
		public double? Days { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("dismissed")]
		public object? Dismissed { get; init; }

		[JsonPropertyName("event_score")]
		public double? EventScore { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("Inland Water")]
		public string? InlandWater { get; init; }

		[JsonPropertyName("ISO Country Code")]
		public string? ISOCountryCode { get; init; }

		[JsonPropertyName("last_backup")]
		public string? LastBackup { get; init; }

		[JsonPropertyName("last_collection")]
		public string? LastCollection { get; init; }

		[JsonPropertyName("last_updated")]
		public string? LastUpdated { get; init; }

		[JsonPropertyName("last_uploaded")]
		public string? LastUploaded { get; init; }

		[JsonPropertyName("linkquality")]
		public object? Linkquality { get; init; }

		[JsonPropertyName("Locality")]
		public string? Locality { get; init; }

		[JsonPropertyName("Location")]
		public object? Location { get; init; }

		[JsonPropertyName("Low Power Mode")]
		public bool? LowPowerMode { get; init; }

		[JsonPropertyName("Mobile Country Code")]
		public string? MobileCountryCode { get; init; }

		[JsonPropertyName("Mobile Network Code")]
		public string? MobileNetworkCode { get; init; }

		[JsonPropertyName("Name")]
		public string? Name { get; init; }

		[JsonPropertyName("next_backup")]
		public string? NextBackup { get; init; }

		[JsonPropertyName("next_date")]
		public string? NextDate { get; init; }

		[JsonPropertyName("Ocean")]
		public string? Ocean { get; init; }

		[JsonPropertyName("Postal Code")]
		public string? PostalCode { get; init; }

		[JsonPropertyName("prior_value")]
		public string? PriorValue { get; init; }

		[JsonPropertyName("process_timestamp")]
		public string? ProcessTimestamp { get; init; }

		[JsonPropertyName("recurrence")]
		public string? Recurrence { get; init; }

		[JsonPropertyName("reminder")]
		public string? Reminder { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("size_in_google_drive")]
		public string? SizeInGoogleDrive { get; init; }

		[JsonPropertyName("size_in_home_assistant")]
		public string? SizeInHomeAssistant { get; init; }

		[JsonPropertyName("sorted_active")]
		public string? SortedActive { get; init; }

		[JsonPropertyName("sorted_all")]
		public string? SortedAll { get; init; }

		[JsonPropertyName("state_class")]
		public string? StateClass { get; init; }

		[JsonPropertyName("status")]
		public string? Status { get; init; }

		[JsonPropertyName("Sub Administrative Area")]
		public string? SubAdministrativeArea { get; init; }

		[JsonPropertyName("Sub Locality")]
		public string? SubLocality { get; init; }

		[JsonPropertyName("Sub Thoroughfare")]
		public string? SubThoroughfare { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("target")]
		public string? Target { get; init; }

		[JsonPropertyName("Thoroughfare")]
		public string? Thoroughfare { get; init; }

		[JsonPropertyName("Time Zone")]
		public string? TimeZone { get; init; }

		[JsonPropertyName("total_active")]
		public double? TotalActive { get; init; }

		[JsonPropertyName("total_all")]
		public double? TotalAll { get; init; }

		[JsonPropertyName("Types")]
		public object? Types { get; init; }

		[JsonPropertyName("voltage")]
		public double? Voltage { get; init; }

		[JsonPropertyName("Zones")]
		public object? Zones { get; init; }
	}

	public record SunAttributes
	{
		[JsonPropertyName("azimuth")]
		public double? Azimuth { get; init; }

		[JsonPropertyName("elevation")]
		public double? Elevation { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("next_dawn")]
		public string? NextDawn { get; init; }

		[JsonPropertyName("next_dusk")]
		public string? NextDusk { get; init; }

		[JsonPropertyName("next_midnight")]
		public string? NextMidnight { get; init; }

		[JsonPropertyName("next_noon")]
		public string? NextNoon { get; init; }

		[JsonPropertyName("next_rising")]
		public string? NextRising { get; init; }

		[JsonPropertyName("next_setting")]
		public string? NextSetting { get; init; }

		[JsonPropertyName("rising")]
		public bool? Rising { get; init; }
	}

	public record SwitchAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("restored")]
		public bool? Restored { get; init; }

		[JsonPropertyName("state")]
		public string? State { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("target")]
		public string? Target { get; init; }
	}

	public record TimerAttributes
	{
		[JsonPropertyName("duration")]
		public string? Duration { get; init; }

		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }
	}

	public record UpdateAttributes
	{
		[JsonPropertyName("auto_update")]
		public bool? AutoUpdate { get; init; }

		[JsonPropertyName("device_class")]
		public string? DeviceClass { get; init; }

		[JsonPropertyName("entity_picture")]
		public string? EntityPicture { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("in_progress")]
		public bool? InProgress { get; init; }

		[JsonPropertyName("installed_version")]
		public string? InstalledVersion { get; init; }

		[JsonPropertyName("latest_version")]
		public string? LatestVersion { get; init; }

		[JsonPropertyName("release_summary")]
		public string? ReleaseSummary { get; init; }

		[JsonPropertyName("release_url")]
		public string? ReleaseUrl { get; init; }

		[JsonPropertyName("skipped_version")]
		public object? SkippedVersion { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }

		[JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public record VacuumAttributes
	{
		[JsonPropertyName("battery_icon")]
		public string? BatteryIcon { get; init; }

		[JsonPropertyName("battery_level")]
		public double? BatteryLevel { get; init; }

		[JsonPropertyName("battery_level_at_clean_end")]
		public double? BatteryLevelAtCleanEnd { get; init; }

		[JsonPropertyName("battery_level_at_clean_start")]
		public double? BatteryLevelAtCleanStart { get; init; }

		[JsonPropertyName("clean_area")]
		public double? CleanArea { get; init; }

		[JsonPropertyName("clean_error_time")]
		public double? CleanErrorTime { get; init; }

		[JsonPropertyName("clean_pause_time")]
		public double? CleanPauseTime { get; init; }

		[JsonPropertyName("clean_start")]
		public string? CleanStart { get; init; }

		[JsonPropertyName("clean_stop")]
		public string? CleanStop { get; init; }

		[JsonPropertyName("clean_suspension_count")]
		public double? CleanSuspensionCount { get; init; }

		[JsonPropertyName("clean_suspension_time")]
		public double? CleanSuspensionTime { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("launched_from")]
		public string? LaunchedFrom { get; init; }

		[JsonPropertyName("status")]
		public string? Status { get; init; }

		[JsonPropertyName("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record WeatherAttributes
	{
		[JsonPropertyName("attribution")]
		public string? Attribution { get; init; }

		[JsonPropertyName("forecast")]
		public object? Forecast { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("humidity")]
		public double? Humidity { get; init; }

		[JsonPropertyName("ozone")]
		public double? Ozone { get; init; }

		[JsonPropertyName("pressure")]
		public double? Pressure { get; init; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; init; }

		[JsonPropertyName("visibility")]
		public double? Visibility { get; init; }

		[JsonPropertyName("wind_bearing")]
		public double? WindBearing { get; init; }

		[JsonPropertyName("wind_speed")]
		public double? WindSpeed { get; init; }
	}

	public record ZoneAttributes
	{
		[JsonPropertyName("editable")]
		public bool? Editable { get; init; }

		[JsonPropertyName("friendly_name")]
		public string? FriendlyName { get; init; }

		[JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[JsonPropertyName("latitude")]
		public double? Latitude { get; init; }

		[JsonPropertyName("longitude")]
		public double? Longitude { get; init; }

		[JsonPropertyName("passive")]
		public bool? Passive { get; init; }

		[JsonPropertyName("persons")]
		public object? Persons { get; init; }

		[JsonPropertyName("radius")]
		public double? Radius { get; init; }
	}

	public interface IServices
	{
		AdguardServices Adguard { get; }

		AlarmControlPanelServices AlarmControlPanel { get; }

		AlexaMediaServices AlexaMedia { get; }

		AutomationServices Automation { get; }

		ButtonServices Button { get; }

		CameraServices Camera { get; }

		ClimateServices Climate { get; }

		CloudServices Cloud { get; }

		ConversationServices Conversation { get; }

		CounterServices Counter { get; }

		CoverServices Cover { get; }

		DeviceTrackerServices DeviceTracker { get; }

		DwainsDashboardServices DwainsDashboard { get; }

		EntityControllerServices EntityController { get; }

		FanServices Fan { get; }

		FfmpegServices Ffmpeg { get; }

		FrontendServices Frontend { get; }

		GarbageCollectionServices GarbageCollection { get; }

		GoogleServices Google { get; }

		GroupServices Group { get; }

		HassioServices Hassio { get; }

		HomeassistantServices Homeassistant { get; }

		HumidifierServices Humidifier { get; }

		IcloudServices Icloud { get; }

		InputBooleanServices InputBoolean { get; }

		InputDatetimeServices InputDatetime { get; }

		InputNumberServices InputNumber { get; }

		InputSelectServices InputSelect { get; }

		InputTextServices InputText { get; }

		LightServices Light { get; }

		LockServices Lock { get; }

		LogbookServices Logbook { get; }

		LoggerServices Logger { get; }

		MediaPlayerServices MediaPlayer { get; }

		MotioneyeServices Motioneye { get; }

		MqttServices Mqtt { get; }

		NeatoServices Neato { get; }

		NestServices Nest { get; }

		NetdaemonServices Netdaemon { get; }

		NotifyServices Notify { get; }

		NumberServices Number { get; }

		OnvifServices Onvif { get; }

		PersistentNotificationServices PersistentNotification { get; }

		PersonServices Person { get; }

		RecorderServices Recorder { get; }

		RemoteServices Remote { get; }

		SceneServices Scene { get; }

		ScriptServices Script { get; }

		SelectServices Select { get; }

		ShoppingListServices ShoppingList { get; }

		SirenServices Siren { get; }

		SpeedtestdotnetServices Speedtestdotnet { get; }

		SpotcastServices Spotcast { get; }

		SqueezeboxServices Squeezebox { get; }

		SwitchServices Switch { get; }

		SystemLogServices SystemLog { get; }

		TemplateServices Template { get; }

		TimerServices Timer { get; }

		TtsServices Tts { get; }

		UnifiServices Unifi { get; }

		UnifiprotectServices Unifiprotect { get; }

		UpdateServices Update { get; }

		VacuumServices Vacuum { get; }

		YeelightServices Yeelight { get; }

		ZoneServices Zone { get; }
	}

	public class Services : IServices
	{
		private readonly IHaContext _haContext;
		public Services(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AdguardServices Adguard => new(_haContext);
		public AlarmControlPanelServices AlarmControlPanel => new(_haContext);
		public AlexaMediaServices AlexaMedia => new(_haContext);
		public AutomationServices Automation => new(_haContext);
		public ButtonServices Button => new(_haContext);
		public CameraServices Camera => new(_haContext);
		public ClimateServices Climate => new(_haContext);
		public CloudServices Cloud => new(_haContext);
		public ConversationServices Conversation => new(_haContext);
		public CounterServices Counter => new(_haContext);
		public CoverServices Cover => new(_haContext);
		public DeviceTrackerServices DeviceTracker => new(_haContext);
		public DwainsDashboardServices DwainsDashboard => new(_haContext);
		public EntityControllerServices EntityController => new(_haContext);
		public FanServices Fan => new(_haContext);
		public FfmpegServices Ffmpeg => new(_haContext);
		public FrontendServices Frontend => new(_haContext);
		public GarbageCollectionServices GarbageCollection => new(_haContext);
		public GoogleServices Google => new(_haContext);
		public GroupServices Group => new(_haContext);
		public HassioServices Hassio => new(_haContext);
		public HomeassistantServices Homeassistant => new(_haContext);
		public HumidifierServices Humidifier => new(_haContext);
		public IcloudServices Icloud => new(_haContext);
		public InputBooleanServices InputBoolean => new(_haContext);
		public InputDatetimeServices InputDatetime => new(_haContext);
		public InputNumberServices InputNumber => new(_haContext);
		public InputSelectServices InputSelect => new(_haContext);
		public InputTextServices InputText => new(_haContext);
		public LightServices Light => new(_haContext);
		public LockServices Lock => new(_haContext);
		public LogbookServices Logbook => new(_haContext);
		public LoggerServices Logger => new(_haContext);
		public MediaPlayerServices MediaPlayer => new(_haContext);
		public MotioneyeServices Motioneye => new(_haContext);
		public MqttServices Mqtt => new(_haContext);
		public NeatoServices Neato => new(_haContext);
		public NestServices Nest => new(_haContext);
		public NetdaemonServices Netdaemon => new(_haContext);
		public NotifyServices Notify => new(_haContext);
		public NumberServices Number => new(_haContext);
		public OnvifServices Onvif => new(_haContext);
		public PersistentNotificationServices PersistentNotification => new(_haContext);
		public PersonServices Person => new(_haContext);
		public RecorderServices Recorder => new(_haContext);
		public RemoteServices Remote => new(_haContext);
		public SceneServices Scene => new(_haContext);
		public ScriptServices Script => new(_haContext);
		public SelectServices Select => new(_haContext);
		public ShoppingListServices ShoppingList => new(_haContext);
		public SirenServices Siren => new(_haContext);
		public SpeedtestdotnetServices Speedtestdotnet => new(_haContext);
		public SpotcastServices Spotcast => new(_haContext);
		public SqueezeboxServices Squeezebox => new(_haContext);
		public SwitchServices Switch => new(_haContext);
		public SystemLogServices SystemLog => new(_haContext);
		public TemplateServices Template => new(_haContext);
		public TimerServices Timer => new(_haContext);
		public TtsServices Tts => new(_haContext);
		public UnifiServices Unifi => new(_haContext);
		public UnifiprotectServices Unifiprotect => new(_haContext);
		public UpdateServices Update => new(_haContext);
		public VacuumServices Vacuum => new(_haContext);
		public YeelightServices Yeelight => new(_haContext);
		public ZoneServices Zone => new(_haContext);
	}

	public class AdguardServices
	{
		private readonly IHaContext _haContext;
		public AdguardServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Add a new filter subscription to AdGuard Home.</summary>
		public void AddUrl(AdguardAddUrlParameters data)
		{
			_haContext.CallService("adguard", "add_url", null, data);
		}

		///<summary>Add a new filter subscription to AdGuard Home.</summary>
		///<param name="name">The name of the filter subscription. eg: Example</param>
		///<param name="url">The filter URL to subscribe to, containing the filter rules. eg: https://www.example.com/filter/1.txt</param>
		public void AddUrl(string @name, string @url)
		{
			_haContext.CallService("adguard", "add_url", null, new AdguardAddUrlParameters{Name = @name, Url = @url});
		}

		///<summary>Disables a filter subscription in AdGuard Home.</summary>
		public void DisableUrl(AdguardDisableUrlParameters data)
		{
			_haContext.CallService("adguard", "disable_url", null, data);
		}

		///<summary>Disables a filter subscription in AdGuard Home.</summary>
		///<param name="url">The filter subscription URL to disable. eg: https://www.example.com/filter/1.txt</param>
		public void DisableUrl(string @url)
		{
			_haContext.CallService("adguard", "disable_url", null, new AdguardDisableUrlParameters{Url = @url});
		}

		///<summary>Enables a filter subscription in AdGuard Home.</summary>
		public void EnableUrl(AdguardEnableUrlParameters data)
		{
			_haContext.CallService("adguard", "enable_url", null, data);
		}

		///<summary>Enables a filter subscription in AdGuard Home.</summary>
		///<param name="url">The filter subscription URL to enable. eg: https://www.example.com/filter/1.txt</param>
		public void EnableUrl(string @url)
		{
			_haContext.CallService("adguard", "enable_url", null, new AdguardEnableUrlParameters{Url = @url});
		}

		///<summary>Refresh all filter subscriptions in AdGuard Home.</summary>
		public void Refresh(AdguardRefreshParameters data)
		{
			_haContext.CallService("adguard", "refresh", null, data);
		}

		///<summary>Refresh all filter subscriptions in AdGuard Home.</summary>
		///<param name="force">Force update (bypasses AdGuard Home throttling). "true" to force, or "false" to omit for a regular refresh.</param>
		public void Refresh(bool? @force = null)
		{
			_haContext.CallService("adguard", "refresh", null, new AdguardRefreshParameters{Force = @force});
		}

		///<summary>Removes a filter subscription from AdGuard Home.</summary>
		public void RemoveUrl(AdguardRemoveUrlParameters data)
		{
			_haContext.CallService("adguard", "remove_url", null, data);
		}

		///<summary>Removes a filter subscription from AdGuard Home.</summary>
		///<param name="url">The filter subscription URL to remove. eg: https://www.example.com/filter/1.txt</param>
		public void RemoveUrl(string @url)
		{
			_haContext.CallService("adguard", "remove_url", null, new AdguardRemoveUrlParameters{Url = @url});
		}
	}

	public record AdguardAddUrlParameters
	{
		///<summary>The name of the filter subscription. eg: Example</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>The filter URL to subscribe to, containing the filter rules. eg: https://www.example.com/filter/1.txt</summary>
		[JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardDisableUrlParameters
	{
		///<summary>The filter subscription URL to disable. eg: https://www.example.com/filter/1.txt</summary>
		[JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardEnableUrlParameters
	{
		///<summary>The filter subscription URL to enable. eg: https://www.example.com/filter/1.txt</summary>
		[JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardRefreshParameters
	{
		///<summary>Force update (bypasses AdGuard Home throttling). "true" to force, or "false" to omit for a regular refresh.</summary>
		[JsonPropertyName("force")]
		public bool? Force { get; init; }
	}

	public record AdguardRemoveUrlParameters
	{
		///<summary>The filter subscription URL to remove. eg: https://www.example.com/filter/1.txt</summary>
		[JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public class AlarmControlPanelServices
	{
		private readonly IHaContext _haContext;
		public AlarmControlPanelServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmAway(ServiceTarget target, AlarmControlPanelAlarmArmAwayParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, data);
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm away the alarm control panel with. eg: 1234</param>
		public void AlarmArmAway(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, new AlarmControlPanelAlarmArmAwayParameters{Code = @code});
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmCustomBypass(ServiceTarget target, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, data);
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm custom bypass the alarm control panel with. eg: 1234</param>
		public void AlarmArmCustomBypass(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, new AlarmControlPanelAlarmArmCustomBypassParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmHome(ServiceTarget target, AlarmControlPanelAlarmArmHomeParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, data);
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm home the alarm control panel with. eg: 1234</param>
		public void AlarmArmHome(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, new AlarmControlPanelAlarmArmHomeParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmNight(ServiceTarget target, AlarmControlPanelAlarmArmNightParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, data);
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm night the alarm control panel with. eg: 1234</param>
		public void AlarmArmNight(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, new AlarmControlPanelAlarmArmNightParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmArmVacation(ServiceTarget target, AlarmControlPanelAlarmArmVacationParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, data);
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to arm vacation the alarm control panel with. eg: 1234</param>
		public void AlarmArmVacation(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, new AlarmControlPanelAlarmArmVacationParameters{Code = @code});
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmDisarm(ServiceTarget target, AlarmControlPanelAlarmDisarmParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, data);
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to disarm the alarm control panel with. eg: 1234</param>
		public void AlarmDisarm(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, new AlarmControlPanelAlarmDisarmParameters{Code = @code});
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The target for this service call</param>
		public void AlarmTrigger(ServiceTarget target, AlarmControlPanelAlarmTriggerParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, data);
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to trigger the alarm control panel with. eg: 1234</param>
		public void AlarmTrigger(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, new AlarmControlPanelAlarmTriggerParameters{Code = @code});
		}
	}

	public record AlarmControlPanelAlarmArmAwayParameters
	{
		///<summary>An optional code to arm away the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmCustomBypassParameters
	{
		///<summary>An optional code to arm custom bypass the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmHomeParameters
	{
		///<summary>An optional code to arm home the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmNightParameters
	{
		///<summary>An optional code to arm night the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmVacationParameters
	{
		///<summary>An optional code to arm vacation the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmDisarmParameters
	{
		///<summary>An optional code to disarm the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmTriggerParameters
	{
		///<summary>An optional code to trigger the alarm control panel with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class AlexaMediaServices
	{
		private readonly IHaContext _haContext;
		public AlexaMediaServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Clear last entries from Alexa history for each Alexa account.</summary>
		public void ClearHistory(AlexaMediaClearHistoryParameters data)
		{
			_haContext.CallService("alexa_media", "clear_history", null, data);
		}

		///<summary>Clear last entries from Alexa history for each Alexa account.</summary>
		///<param name="email">List of Alexa accounts to update. If empty, will delete from all known accounts. eg: my_email@alexa.com</param>
		///<param name="entries">Number of entries to clear from 1 to 50. If empty, clear 50. eg: 50</param>
		public void ClearHistory(object? @email = null, object? @entries = null)
		{
			_haContext.CallService("alexa_media", "clear_history", null, new AlexaMediaClearHistoryParameters{Email = @email, Entries = @entries});
		}

		///<summary>Force logout of Alexa Login account and deletion of .pickle. Intended for debugging use.</summary>
		public void ForceLogout(AlexaMediaForceLogoutParameters data)
		{
			_haContext.CallService("alexa_media", "force_logout", null, data);
		}

		///<summary>Force logout of Alexa Login account and deletion of .pickle. Intended for debugging use.</summary>
		///<param name="email">List of Alexa accounts to log out. If empty, will log out from all known accounts. eg: my_email@alexa.com</param>
		public void ForceLogout(object? @email = null)
		{
			_haContext.CallService("alexa_media", "force_logout", null, new AlexaMediaForceLogoutParameters{Email = @email});
		}

		///<summary>Forces update of last_called echo device for each Alexa account.</summary>
		public void UpdateLastCalled(AlexaMediaUpdateLastCalledParameters data)
		{
			_haContext.CallService("alexa_media", "update_last_called", null, data);
		}

		///<summary>Forces update of last_called echo device for each Alexa account.</summary>
		///<param name="email">List of Alexa accounts to update. If empty, will update all known accounts. eg: my_email@alexa.com</param>
		public void UpdateLastCalled(object? @email = null)
		{
			_haContext.CallService("alexa_media", "update_last_called", null, new AlexaMediaUpdateLastCalledParameters{Email = @email});
		}
	}

	public record AlexaMediaClearHistoryParameters
	{
		///<summary>List of Alexa accounts to update. If empty, will delete from all known accounts. eg: my_email@alexa.com</summary>
		[JsonPropertyName("email")]
		public object? Email { get; init; }

		///<summary>Number of entries to clear from 1 to 50. If empty, clear 50. eg: 50</summary>
		[JsonPropertyName("entries")]
		public object? Entries { get; init; }
	}

	public record AlexaMediaForceLogoutParameters
	{
		///<summary>List of Alexa accounts to log out. If empty, will log out from all known accounts. eg: my_email@alexa.com</summary>
		[JsonPropertyName("email")]
		public object? Email { get; init; }
	}

	public record AlexaMediaUpdateLastCalledParameters
	{
		///<summary>List of Alexa accounts to update. If empty, will update all known accounts. eg: my_email@alexa.com</summary>
		[JsonPropertyName("email")]
		public object? Email { get; init; }
	}

	public class AutomationServices
	{
		private readonly IHaContext _haContext;
		public AutomationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the automation configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("automation", "reload", null);
		}

		///<summary>Toggle (enable / disable) an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("automation", "toggle", target);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void Trigger(ServiceTarget target, AutomationTriggerParameters data)
		{
			_haContext.CallService("automation", "trigger", target, data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public void Trigger(ServiceTarget target, bool? @skipCondition = null)
		{
			_haContext.CallService("automation", "trigger", target, new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target, AutomationTurnOffParameters data)
		{
			_haContext.CallService("automation", "turn_off", target, data);
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public void TurnOff(ServiceTarget target, bool? @stopActions = null)
		{
			_haContext.CallService("automation", "turn_off", target, new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Enable an automation.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("automation", "turn_on", target);
		}
	}

	public record AutomationTriggerParameters
	{
		///<summary>Whether or not the conditions will be skipped.</summary>
		[JsonPropertyName("skip_condition")]
		public bool? SkipCondition { get; init; }
	}

	public record AutomationTurnOffParameters
	{
		///<summary>Stop currently running actions.</summary>
		[JsonPropertyName("stop_actions")]
		public bool? StopActions { get; init; }
	}

	public class ButtonServices
	{
		private readonly IHaContext _haContext;
		public ButtonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Press the button entity.</summary>
		///<param name="target">The target for this service call</param>
		public void Press(ServiceTarget target)
		{
			_haContext.CallService("button", "press", target);
		}
	}

	public class CameraServices
	{
		private readonly IHaContext _haContext;
		public CameraServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Disable the motion detection in a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void DisableMotionDetection(ServiceTarget target)
		{
			_haContext.CallService("camera", "disable_motion_detection", target);
		}

		///<summary>Enable the motion detection in a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void EnableMotionDetection(ServiceTarget target)
		{
			_haContext.CallService("camera", "enable_motion_detection", target);
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The target for this service call</param>
		public void PlayStream(ServiceTarget target, CameraPlayStreamParameters data)
		{
			_haContext.CallService("camera", "play_stream", target, data);
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mediaPlayer">Name(s) of media player to stream to.</param>
		///<param name="format">Stream format supported by media player.</param>
		public void PlayStream(ServiceTarget target, string @mediaPlayer, object? @format = null)
		{
			_haContext.CallService("camera", "play_stream", target, new CameraPlayStreamParameters{MediaPlayer = @mediaPlayer, Format = @format});
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The target for this service call</param>
		public void Record(ServiceTarget target, CameraRecordParameters data)
		{
			_haContext.CallService("camera", "record", target, data);
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</param>
		///<param name="duration">Target recording length.</param>
		///<param name="lookback">Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</param>
		public void Record(ServiceTarget target, string @filename, long? @duration = null, long? @lookback = null)
		{
			_haContext.CallService("camera", "record", target, new CameraRecordParameters{Filename = @filename, Duration = @duration, Lookback = @lookback});
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void Snapshot(ServiceTarget target, CameraSnapshotParameters data)
		{
			_haContext.CallService("camera", "snapshot", target, data);
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</param>
		public void Snapshot(ServiceTarget target, string @filename)
		{
			_haContext.CallService("camera", "snapshot", target, new CameraSnapshotParameters{Filename = @filename});
		}

		///<summary>Turn off camera.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_off", target);
		}

		///<summary>Turn on camera.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_on", target);
		}
	}

	public record CameraPlayStreamParameters
	{
		///<summary>Name(s) of media player to stream to.</summary>
		[JsonPropertyName("media_player")]
		public string? MediaPlayer { get; init; }

		///<summary>Stream format supported by media player.</summary>
		[JsonPropertyName("format")]
		public object? Format { get; init; }
	}

	public record CameraRecordParameters
	{
		///<summary>Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</summary>
		[JsonPropertyName("filename")]
		public string? Filename { get; init; }

		///<summary>Target recording length.</summary>
		[JsonPropertyName("duration")]
		public long? Duration { get; init; }

		///<summary>Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</summary>
		[JsonPropertyName("lookback")]
		public long? Lookback { get; init; }
	}

	public record CameraSnapshotParameters
	{
		///<summary>Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</summary>
		[JsonPropertyName("filename")]
		public string? Filename { get; init; }
	}

	public class ClimateServices
	{
		private readonly IHaContext _haContext;
		public ClimateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetAuxHeat(ServiceTarget target, ClimateSetAuxHeatParameters data)
		{
			_haContext.CallService("climate", "set_aux_heat", target, data);
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="auxHeat">New value of auxiliary heater.</param>
		public void SetAuxHeat(ServiceTarget target, bool @auxHeat)
		{
			_haContext.CallService("climate", "set_aux_heat", target, new ClimateSetAuxHeatParameters{AuxHeat = @auxHeat});
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetFanMode(ServiceTarget target, ClimateSetFanModeParameters data)
		{
			_haContext.CallService("climate", "set_fan_mode", target, data);
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="fanMode">New value of fan mode. eg: low</param>
		public void SetFanMode(ServiceTarget target, string @fanMode)
		{
			_haContext.CallService("climate", "set_fan_mode", target, new ClimateSetFanModeParameters{FanMode = @fanMode});
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHumidity(ServiceTarget target, ClimateSetHumidityParameters data)
		{
			_haContext.CallService("climate", "set_humidity", target, data);
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="humidity">New target humidity for climate device.</param>
		public void SetHumidity(ServiceTarget target, long @humidity)
		{
			_haContext.CallService("climate", "set_humidity", target, new ClimateSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHvacMode(ServiceTarget target, ClimateSetHvacModeParameters data)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, data);
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="hvacMode">New value of operation mode.</param>
		public void SetHvacMode(ServiceTarget target, object? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, new ClimateSetHvacModeParameters{HvacMode = @hvacMode});
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPresetMode(ServiceTarget target, ClimateSetPresetModeParameters data)
		{
			_haContext.CallService("climate", "set_preset_mode", target, data);
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="presetMode">New value of preset mode. eg: away</param>
		public void SetPresetMode(ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("climate", "set_preset_mode", target, new ClimateSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetSwingMode(ServiceTarget target, ClimateSetSwingModeParameters data)
		{
			_haContext.CallService("climate", "set_swing_mode", target, data);
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="swingMode">New value of swing mode. eg: horizontal</param>
		public void SetSwingMode(ServiceTarget target, string @swingMode)
		{
			_haContext.CallService("climate", "set_swing_mode", target, new ClimateSetSwingModeParameters{SwingMode = @swingMode});
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetTemperature(ServiceTarget target, ClimateSetTemperatureParameters data)
		{
			_haContext.CallService("climate", "set_temperature", target, data);
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="temperature">New target temperature for HVAC.</param>
		///<param name="targetTempHigh">New target high temperature for HVAC.</param>
		///<param name="targetTempLow">New target low temperature for HVAC.</param>
		///<param name="hvacMode">HVAC operation mode to set temperature to.</param>
		public void SetTemperature(ServiceTarget target, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, object? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_temperature", target, new ClimateSetTemperatureParameters{Temperature = @temperature, TargetTempHigh = @targetTempHigh, TargetTempLow = @targetTempLow, HvacMode = @hvacMode});
		}

		///<summary>Turn climate device off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_off", target);
		}

		///<summary>Turn climate device on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_on", target);
		}
	}

	public record ClimateSetAuxHeatParameters
	{
		///<summary>New value of auxiliary heater.</summary>
		[JsonPropertyName("aux_heat")]
		public bool? AuxHeat { get; init; }
	}

	public record ClimateSetFanModeParameters
	{
		///<summary>New value of fan mode. eg: low</summary>
		[JsonPropertyName("fan_mode")]
		public string? FanMode { get; init; }
	}

	public record ClimateSetHumidityParameters
	{
		///<summary>New target humidity for climate device.</summary>
		[JsonPropertyName("humidity")]
		public long? Humidity { get; init; }
	}

	public record ClimateSetHvacModeParameters
	{
		///<summary>New value of operation mode.</summary>
		[JsonPropertyName("hvac_mode")]
		public object? HvacMode { get; init; }
	}

	public record ClimateSetPresetModeParameters
	{
		///<summary>New value of preset mode. eg: away</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public record ClimateSetSwingModeParameters
	{
		///<summary>New value of swing mode. eg: horizontal</summary>
		[JsonPropertyName("swing_mode")]
		public string? SwingMode { get; init; }
	}

	public record ClimateSetTemperatureParameters
	{
		///<summary>New target temperature for HVAC.</summary>
		[JsonPropertyName("temperature")]
		public double? Temperature { get; init; }

		///<summary>New target high temperature for HVAC.</summary>
		[JsonPropertyName("target_temp_high")]
		public double? TargetTempHigh { get; init; }

		///<summary>New target low temperature for HVAC.</summary>
		[JsonPropertyName("target_temp_low")]
		public double? TargetTempLow { get; init; }

		///<summary>HVAC operation mode to set temperature to.</summary>
		[JsonPropertyName("hvac_mode")]
		public object? HvacMode { get; init; }
	}

	public class CloudServices
	{
		private readonly IHaContext _haContext;
		public CloudServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Make instance UI available outside over NabuCasa cloud</summary>
		public void RemoteConnect()
		{
			_haContext.CallService("cloud", "remote_connect", null);
		}

		///<summary>Disconnect UI from NabuCasa cloud</summary>
		public void RemoteDisconnect()
		{
			_haContext.CallService("cloud", "remote_disconnect", null);
		}
	}

	public class ConversationServices
	{
		private readonly IHaContext _haContext;
		public ConversationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Launch a conversation from a transcribed text.</summary>
		public void Process(ConversationProcessParameters data)
		{
			_haContext.CallService("conversation", "process", null, data);
		}

		///<summary>Launch a conversation from a transcribed text.</summary>
		///<param name="text">Transcribed text eg: Turn all lights on</param>
		public void Process(string? @text = null)
		{
			_haContext.CallService("conversation", "process", null, new ConversationProcessParameters{Text = @text});
		}
	}

	public record ConversationProcessParameters
	{
		///<summary>Transcribed text eg: Turn all lights on</summary>
		[JsonPropertyName("text")]
		public string? Text { get; init; }
	}

	public class CounterServices
	{
		private readonly IHaContext _haContext;
		public CounterServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Change counter parameters.</summary>
		///<param name="target">The target for this service call</param>
		public void Configure(ServiceTarget target, CounterConfigureParameters data)
		{
			_haContext.CallService("counter", "configure", target, data);
		}

		///<summary>Change counter parameters.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="minimum">New minimum value for the counter or None to remove minimum.</param>
		///<param name="maximum">New maximum value for the counter or None to remove maximum.</param>
		///<param name="step">New value for step.</param>
		///<param name="initial">New value for initial.</param>
		///<param name="value">New state value.</param>
		public void Configure(ServiceTarget target, long? @minimum = null, long? @maximum = null, long? @step = null, long? @initial = null, long? @value = null)
		{
			_haContext.CallService("counter", "configure", target, new CounterConfigureParameters{Minimum = @minimum, Maximum = @maximum, Step = @step, Initial = @initial, Value = @value});
		}

		///<summary>Decrement a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Decrement(ServiceTarget target)
		{
			_haContext.CallService("counter", "decrement", target);
		}

		///<summary>Increment a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Increment(ServiceTarget target)
		{
			_haContext.CallService("counter", "increment", target);
		}

		///<summary>Reset a counter.</summary>
		///<param name="target">The target for this service call</param>
		public void Reset(ServiceTarget target)
		{
			_haContext.CallService("counter", "reset", target);
		}
	}

	public record CounterConfigureParameters
	{
		///<summary>New minimum value for the counter or None to remove minimum.</summary>
		[JsonPropertyName("minimum")]
		public long? Minimum { get; init; }

		///<summary>New maximum value for the counter or None to remove maximum.</summary>
		[JsonPropertyName("maximum")]
		public long? Maximum { get; init; }

		///<summary>New value for step.</summary>
		[JsonPropertyName("step")]
		public long? Step { get; init; }

		///<summary>New value for initial.</summary>
		[JsonPropertyName("initial")]
		public long? Initial { get; init; }

		///<summary>New state value.</summary>
		[JsonPropertyName("value")]
		public long? Value { get; init; }
	}

	public class CoverServices
	{
		private readonly IHaContext _haContext;
		public CoverServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Close all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void CloseCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover", target);
		}

		///<summary>Close all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void CloseCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover_tilt", target);
		}

		///<summary>Open all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void OpenCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover", target);
		}

		///<summary>Open all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void OpenCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover_tilt", target);
		}

		///<summary>Move to specific position all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void SetCoverPosition(ServiceTarget target, CoverSetCoverPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_position", target, data);
		}

		///<summary>Move to specific position all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="position">Position of the cover</param>
		public void SetCoverPosition(ServiceTarget target, long @position)
		{
			_haContext.CallService("cover", "set_cover_position", target, new CoverSetCoverPositionParameters{Position = @position});
		}

		///<summary>Move to specific position all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		public void SetCoverTiltPosition(ServiceTarget target, CoverSetCoverTiltPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, data);
		}

		///<summary>Move to specific position all or specified cover tilt.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="tiltPosition">Tilt position of the cover.</param>
		public void SetCoverTiltPosition(ServiceTarget target, long @tiltPosition)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, new CoverSetCoverTiltPositionParameters{TiltPosition = @tiltPosition});
		}

		///<summary>Stop all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void StopCover(ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover", target);
		}

		///<summary>Stop all or specified cover.</summary>
		///<param name="target">The target for this service call</param>
		public void StopCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover_tilt", target);
		}

		///<summary>Toggle a cover open/closed.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle", target);
		}

		///<summary>Toggle a cover tilt open/closed.</summary>
		///<param name="target">The target for this service call</param>
		public void ToggleCoverTilt(ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle_cover_tilt", target);
		}
	}

	public record CoverSetCoverPositionParameters
	{
		///<summary>Position of the cover</summary>
		[JsonPropertyName("position")]
		public long? Position { get; init; }
	}

	public record CoverSetCoverTiltPositionParameters
	{
		///<summary>Tilt position of the cover.</summary>
		[JsonPropertyName("tilt_position")]
		public long? TiltPosition { get; init; }
	}

	public class DeviceTrackerServices
	{
		private readonly IHaContext _haContext;
		public DeviceTrackerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Control tracked device.</summary>
		public void See(DeviceTrackerSeeParameters data)
		{
			_haContext.CallService("device_tracker", "see", null, data);
		}

		///<summary>Control tracked device.</summary>
		///<param name="mac">MAC address of device eg: FF:FF:FF:FF:FF:FF</param>
		///<param name="devId">Id of device (find id in known_devices.yaml). eg: phonedave</param>
		///<param name="hostName">Hostname of device eg: Dave</param>
		///<param name="locationName">Name of location where device is located (not_home is away). eg: home</param>
		///<param name="gps">GPS coordinates where device is located (latitude, longitude). eg: [51.509802, -0.086692]</param>
		///<param name="gpsAccuracy">Accuracy of GPS coordinates.</param>
		///<param name="battery">Battery level of device.</param>
		public void See(string? @mac = null, string? @devId = null, string? @hostName = null, string? @locationName = null, object? @gps = null, long? @gpsAccuracy = null, long? @battery = null)
		{
			_haContext.CallService("device_tracker", "see", null, new DeviceTrackerSeeParameters{Mac = @mac, DevId = @devId, HostName = @hostName, LocationName = @locationName, Gps = @gps, GpsAccuracy = @gpsAccuracy, Battery = @battery});
		}
	}

	public record DeviceTrackerSeeParameters
	{
		///<summary>MAC address of device eg: FF:FF:FF:FF:FF:FF</summary>
		[JsonPropertyName("mac")]
		public string? Mac { get; init; }

		///<summary>Id of device (find id in known_devices.yaml). eg: phonedave</summary>
		[JsonPropertyName("dev_id")]
		public string? DevId { get; init; }

		///<summary>Hostname of device eg: Dave</summary>
		[JsonPropertyName("host_name")]
		public string? HostName { get; init; }

		///<summary>Name of location where device is located (not_home is away). eg: home</summary>
		[JsonPropertyName("location_name")]
		public string? LocationName { get; init; }

		///<summary>GPS coordinates where device is located (latitude, longitude). eg: [51.509802, -0.086692]</summary>
		[JsonPropertyName("gps")]
		public object? Gps { get; init; }

		///<summary>Accuracy of GPS coordinates.</summary>
		[JsonPropertyName("gps_accuracy")]
		public long? GpsAccuracy { get; init; }

		///<summary>Battery level of device.</summary>
		[JsonPropertyName("battery")]
		public long? Battery { get; init; }
	}

	public class DwainsDashboardServices
	{
		private readonly IHaContext _haContext;
		public DwainsDashboardServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Show a notification in the frontend.</summary>
		public void NotificationCreate(DwainsDashboardNotificationCreateParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_create", null, data);
		}

		///<summary>Show a notification in the frontend.</summary>
		///<param name="message">Message body of the notification. [Templates accepted] eg: Dishwasher is done! :D</param>
		///<param name="notificationId">Target ID of the notification, will replace a notification with the same Id. [Optional] eg: 1234</param>
		public void NotificationCreate(object? @message = null, object? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_create", null, new DwainsDashboardNotificationCreateParameters{Message = @message, NotificationId = @notificationId});
		}

		///<summary>Remove a notification from the frontend.</summary>
		public void NotificationDismiss(DwainsDashboardNotificationDismissParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_dismiss", null, data);
		}

		///<summary>Remove a notification from the frontend.</summary>
		///<param name="notificationId">Target ID of the notification, which should be removed. [Required] eg: 1234</param>
		public void NotificationDismiss(object? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_dismiss", null, new DwainsDashboardNotificationDismissParameters{NotificationId = @notificationId});
		}

		///<summary>Mark a notification read.</summary>
		public void NotificationMarkRead(DwainsDashboardNotificationMarkReadParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_mark_read", null, data);
		}

		///<summary>Mark a notification read.</summary>
		///<param name="notificationId">Target ID of the notification, which should be mark read. [Required] eg: 1234</param>
		public void NotificationMarkRead(object? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_mark_read", null, new DwainsDashboardNotificationMarkReadParameters{NotificationId = @notificationId});
		}

		///<summary>Reload dashboard configuration from Dwains dashboard</summary>
		public void Reload()
		{
			_haContext.CallService("dwains_dashboard", "reload", null);
		}
	}

	public record DwainsDashboardNotificationCreateParameters
	{
		///<summary>Message body of the notification. [Templates accepted] eg: Dishwasher is done! :D</summary>
		[JsonPropertyName("message")]
		public object? Message { get; init; }

		///<summary>Target ID of the notification, will replace a notification with the same Id. [Optional] eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public object? NotificationId { get; init; }
	}

	public record DwainsDashboardNotificationDismissParameters
	{
		///<summary>Target ID of the notification, which should be removed. [Required] eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public object? NotificationId { get; init; }
	}

	public record DwainsDashboardNotificationMarkReadParameters
	{
		///<summary>Target ID of the notification, which should be mark read. [Required] eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public object? NotificationId { get; init; }
	}

	public class EntityControllerServices
	{
		private readonly IHaContext _haContext;
		public EntityControllerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Clears the blocked state of an Entity Controller, if set</summary>
		public void ClearBlock(EntityControllerClearBlockParameters data)
		{
			_haContext.CallService("entity_controller", "clear_block", null, data);
		}

		///<summary>Clears the blocked state of an Entity Controller, if set</summary>
		///<param name="entityId">Name(s) of entities to change. eg: entity_controller.motion_light</param>
		public void ClearBlock(object? @entityId = null)
		{
			_haContext.CallService("entity_controller", "clear_block", null, new EntityControllerClearBlockParameters{EntityId = @entityId});
		}

		public void DisableStayMode()
		{
			_haContext.CallService("entity_controller", "disable_stay_mode", null);
		}

		public void EnableStayMode()
		{
			_haContext.CallService("entity_controller", "enable_stay_mode", null);
		}

		///<summary>Change the night mode start and end times, does nothing if night mode is not defined in configuration. If both start_time and end_time are not provided, it will set both to midnight, effectivly disabling night mode.</summary>
		public void SetNightMode(EntityControllerSetNightModeParameters data)
		{
			_haContext.CallService("entity_controller", "set_night_mode", null, data);
		}

		///<summary>Change the night mode start and end times, does nothing if night mode is not defined in configuration. If both start_time and end_time are not provided, it will set both to midnight, effectivly disabling night mode.</summary>
		///<param name="entityId">Name(s) of entities to change. eg: entity_controller.motion_light</param>
		///<param name="startTime">new start time to set night mode to. eg: sunset - 00:30:00 or '18:30:00' or now or constraint (set same as day start)</param>
		///<param name="endTime">new end time to set night mode to. eg: sunset + 03:00:00 or '21:30:00' or now or constraint (set same as day end)</param>
		public void SetNightMode(object? @entityId = null, object? @startTime = null, object? @endTime = null)
		{
			_haContext.CallService("entity_controller", "set_night_mode", null, new EntityControllerSetNightModeParameters{EntityId = @entityId, StartTime = @startTime, EndTime = @endTime});
		}
	}

	public record EntityControllerClearBlockParameters
	{
		///<summary>Name(s) of entities to change. eg: entity_controller.motion_light</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }
	}

	public record EntityControllerSetNightModeParameters
	{
		///<summary>Name(s) of entities to change. eg: entity_controller.motion_light</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>new start time to set night mode to. eg: sunset - 00:30:00 or '18:30:00' or now or constraint (set same as day start)</summary>
		[JsonPropertyName("start_time")]
		public object? StartTime { get; init; }

		///<summary>new end time to set night mode to. eg: sunset + 03:00:00 or '21:30:00' or now or constraint (set same as day end)</summary>
		[JsonPropertyName("end_time")]
		public object? EndTime { get; init; }
	}

	public class FanServices
	{
		private readonly IHaContext _haContext;
		public FanServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		public void DecreaseSpeed(ServiceTarget target, FanDecreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "decrease_speed", target, data);
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentageStep">Decrease speed by a percentage.</param>
		public void DecreaseSpeed(ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "decrease_speed", target, new FanDecreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		public void IncreaseSpeed(ServiceTarget target, FanIncreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "increase_speed", target, data);
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentageStep">Increase speed by a percentage.</param>
		public void IncreaseSpeed(ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "increase_speed", target, new FanIncreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The target for this service call</param>
		public void Oscillate(ServiceTarget target, FanOscillateParameters data)
		{
			_haContext.CallService("fan", "oscillate", target, data);
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="oscillating">Flag to turn on/off oscillation.</param>
		public void Oscillate(ServiceTarget target, bool @oscillating)
		{
			_haContext.CallService("fan", "oscillate", target, new FanOscillateParameters{Oscillating = @oscillating});
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The target for this service call</param>
		public void SetDirection(ServiceTarget target, FanSetDirectionParameters data)
		{
			_haContext.CallService("fan", "set_direction", target, data);
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="direction">The direction to rotate.</param>
		public void SetDirection(ServiceTarget target, object @direction)
		{
			_haContext.CallService("fan", "set_direction", target, new FanSetDirectionParameters{Direction = @direction});
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPercentage(ServiceTarget target, FanSetPercentageParameters data)
		{
			_haContext.CallService("fan", "set_percentage", target, data);
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="percentage">Percentage speed setting.</param>
		public void SetPercentage(ServiceTarget target, long @percentage)
		{
			_haContext.CallService("fan", "set_percentage", target, new FanSetPercentageParameters{Percentage = @percentage});
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetPresetMode(ServiceTarget target, FanSetPresetModeParameters data)
		{
			_haContext.CallService("fan", "set_preset_mode", target, data);
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="presetMode">New value of preset mode. eg: auto</param>
		public void SetPresetMode(ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("fan", "set_preset_mode", target, new FanSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Toggle the fan on/off.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("fan", "toggle", target);
		}

		///<summary>Turn fan off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("fan", "turn_off", target);
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, FanTurnOnParameters data)
		{
			_haContext.CallService("fan", "turn_on", target, data);
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="speed">Speed setting. eg: high</param>
		///<param name="percentage">Percentage speed setting.</param>
		///<param name="presetMode">Preset mode setting. eg: auto</param>
		public void TurnOn(ServiceTarget target, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			_haContext.CallService("fan", "turn_on", target, new FanTurnOnParameters{Speed = @speed, Percentage = @percentage, PresetMode = @presetMode});
		}
	}

	public record FanDecreaseSpeedParameters
	{
		///<summary>Decrease speed by a percentage.</summary>
		[JsonPropertyName("percentage_step")]
		public long? PercentageStep { get; init; }
	}

	public record FanIncreaseSpeedParameters
	{
		///<summary>Increase speed by a percentage.</summary>
		[JsonPropertyName("percentage_step")]
		public long? PercentageStep { get; init; }
	}

	public record FanOscillateParameters
	{
		///<summary>Flag to turn on/off oscillation.</summary>
		[JsonPropertyName("oscillating")]
		public bool? Oscillating { get; init; }
	}

	public record FanSetDirectionParameters
	{
		///<summary>The direction to rotate.</summary>
		[JsonPropertyName("direction")]
		public object? Direction { get; init; }
	}

	public record FanSetPercentageParameters
	{
		///<summary>Percentage speed setting.</summary>
		[JsonPropertyName("percentage")]
		public long? Percentage { get; init; }
	}

	public record FanSetPresetModeParameters
	{
		///<summary>New value of preset mode. eg: auto</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public record FanTurnOnParameters
	{
		///<summary>Speed setting. eg: high</summary>
		[JsonPropertyName("speed")]
		public string? Speed { get; init; }

		///<summary>Percentage speed setting.</summary>
		[JsonPropertyName("percentage")]
		public long? Percentage { get; init; }

		///<summary>Preset mode setting. eg: auto</summary>
		[JsonPropertyName("preset_mode")]
		public string? PresetMode { get; init; }
	}

	public class FfmpegServices
	{
		private readonly IHaContext _haContext;
		public FfmpegServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send a restart command to a ffmpeg based sensor.</summary>
		public void Restart(FfmpegRestartParameters data)
		{
			_haContext.CallService("ffmpeg", "restart", null, data);
		}

		///<summary>Send a restart command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will restart. Platform dependent.</param>
		public void Restart(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "restart", null, new FfmpegRestartParameters{EntityId = @entityId});
		}

		///<summary>Send a start command to a ffmpeg based sensor.</summary>
		public void Start(FfmpegStartParameters data)
		{
			_haContext.CallService("ffmpeg", "start", null, data);
		}

		///<summary>Send a start command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will start. Platform dependent.</param>
		public void Start(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "start", null, new FfmpegStartParameters{EntityId = @entityId});
		}

		///<summary>Send a stop command to a ffmpeg based sensor.</summary>
		public void Stop(FfmpegStopParameters data)
		{
			_haContext.CallService("ffmpeg", "stop", null, data);
		}

		///<summary>Send a stop command to a ffmpeg based sensor.</summary>
		///<param name="entityId">Name of entity that will stop. Platform dependent.</param>
		public void Stop(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "stop", null, new FfmpegStopParameters{EntityId = @entityId});
		}
	}

	public record FfmpegRestartParameters
	{
		///<summary>Name of entity that will restart. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStartParameters
	{
		///<summary>Name of entity that will start. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStopParameters
	{
		///<summary>Name of entity that will stop. Platform dependent.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }
	}

	public class FrontendServices
	{
		private readonly IHaContext _haContext;
		public FrontendServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload themes from YAML configuration.</summary>
		public void ReloadThemes()
		{
			_haContext.CallService("frontend", "reload_themes", null);
		}

		///<summary>Set a theme unless the client selected per-device theme.</summary>
		public void SetTheme(FrontendSetThemeParameters data)
		{
			_haContext.CallService("frontend", "set_theme", null, data);
		}

		///<summary>Set a theme unless the client selected per-device theme.</summary>
		///<param name="name">Name of a predefined theme eg: default</param>
		///<param name="mode">The mode the theme is for.</param>
		public void SetTheme(object @name, object? @mode = null)
		{
			_haContext.CallService("frontend", "set_theme", null, new FrontendSetThemeParameters{Name = @name, Mode = @mode});
		}
	}

	public record FrontendSetThemeParameters
	{
		///<summary>Name of a predefined theme eg: default</summary>
		[JsonPropertyName("name")]
		public object? Name { get; init; }

		///<summary>The mode the theme is for.</summary>
		[JsonPropertyName("mode")]
		public object? Mode { get; init; }
	}

	public class GarbageCollectionServices
	{
		private readonly IHaContext _haContext;
		public GarbageCollectionServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Manually add collection date.</summary>
		///<param name="target">The target for this service call</param>
		public void AddDate(ServiceTarget target, GarbageCollectionAddDateParameters data)
		{
			_haContext.CallService("garbage_collection", "add_date", target, data);
		}

		///<summary>Manually add collection date.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entityId">The garbage_collection sensor entity_id eg: sensor.general_waste</param>
		///<param name="date">Collection date to add eg: "2020-08-16"</param>
		public void AddDate(ServiceTarget target, object? @entityId = null, object? @date = null)
		{
			_haContext.CallService("garbage_collection", "add_date", target, new GarbageCollectionAddDateParameters{EntityId = @entityId, Date = @date});
		}

		///<summary>Set the last_collection attribute to the current date and time.</summary>
		///<param name="target">The target for this service call</param>
		public void CollectGarbage(ServiceTarget target, GarbageCollectionCollectGarbageParameters data)
		{
			_haContext.CallService("garbage_collection", "collect_garbage", target, data);
		}

		///<summary>Set the last_collection attribute to the current date and time.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entityId">The garbage_collection sensor entity_id eg: sensor.general_waste</param>
		///<param name="lastCollection">Date and time of the last collection (optional) eg: 2020-08-16 10:54:00</param>
		public void CollectGarbage(ServiceTarget target, object? @entityId = null, object? @lastCollection = null)
		{
			_haContext.CallService("garbage_collection", "collect_garbage", target, new GarbageCollectionCollectGarbageParameters{EntityId = @entityId, LastCollection = @lastCollection});
		}

		///<summary>Move the collection date by a number of days.</summary>
		///<param name="target">The target for this service call</param>
		public void OffsetDate(ServiceTarget target, GarbageCollectionOffsetDateParameters data)
		{
			_haContext.CallService("garbage_collection", "offset_date", target, data);
		}

		///<summary>Move the collection date by a number of days.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entityId">The garbage_collection sensor entity_id eg: sensor.general_waste</param>
		///<param name="date">Collection date to move eg: "2020-08-16"</param>
		///<param name="offset">Nuber of days to move (negative number will move it back) eg: 1</param>
		public void OffsetDate(ServiceTarget target, object? @entityId = null, object? @date = null, object? @offset = null)
		{
			_haContext.CallService("garbage_collection", "offset_date", target, new GarbageCollectionOffsetDateParameters{EntityId = @entityId, Date = @date, Offset = @offset});
		}

		///<summary>Remove automatically calculated collection date.</summary>
		///<param name="target">The target for this service call</param>
		public void RemoveDate(ServiceTarget target, GarbageCollectionRemoveDateParameters data)
		{
			_haContext.CallService("garbage_collection", "remove_date", target, data);
		}

		///<summary>Remove automatically calculated collection date.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entityId">The garbage_collection sensor entity_id eg: sensor.general_waste</param>
		///<param name="date">Collection date to remove eg: "2020-08-16"</param>
		public void RemoveDate(ServiceTarget target, object? @entityId = null, object? @date = null)
		{
			_haContext.CallService("garbage_collection", "remove_date", target, new GarbageCollectionRemoveDateParameters{EntityId = @entityId, Date = @date});
		}

		///<summary>Update the entity state and attributes. Used with the manual_update option, do defer the update after changing the automatically created schedule by automation trigered by the garbage_collection_loaded event.</summary>
		///<param name="target">The target for this service call</param>
		public void UpdateState(ServiceTarget target, GarbageCollectionUpdateStateParameters data)
		{
			_haContext.CallService("garbage_collection", "update_state", target, data);
		}

		///<summary>Update the entity state and attributes. Used with the manual_update option, do defer the update after changing the automatically created schedule by automation trigered by the garbage_collection_loaded event.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entityId">The garbage_collection sensor entity_id eg: sensor.general_waste</param>
		public void UpdateState(ServiceTarget target, object? @entityId = null)
		{
			_haContext.CallService("garbage_collection", "update_state", target, new GarbageCollectionUpdateStateParameters{EntityId = @entityId});
		}
	}

	public record GarbageCollectionAddDateParameters
	{
		///<summary>The garbage_collection sensor entity_id eg: sensor.general_waste</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>Collection date to add eg: "2020-08-16"</summary>
		[JsonPropertyName("date")]
		public object? Date { get; init; }
	}

	public record GarbageCollectionCollectGarbageParameters
	{
		///<summary>The garbage_collection sensor entity_id eg: sensor.general_waste</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>Date and time of the last collection (optional) eg: 2020-08-16 10:54:00</summary>
		[JsonPropertyName("last_collection")]
		public object? LastCollection { get; init; }
	}

	public record GarbageCollectionOffsetDateParameters
	{
		///<summary>The garbage_collection sensor entity_id eg: sensor.general_waste</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>Collection date to move eg: "2020-08-16"</summary>
		[JsonPropertyName("date")]
		public object? Date { get; init; }

		///<summary>Nuber of days to move (negative number will move it back) eg: 1</summary>
		[JsonPropertyName("offset")]
		public object? Offset { get; init; }
	}

	public record GarbageCollectionRemoveDateParameters
	{
		///<summary>The garbage_collection sensor entity_id eg: sensor.general_waste</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>Collection date to remove eg: "2020-08-16"</summary>
		[JsonPropertyName("date")]
		public object? Date { get; init; }
	}

	public record GarbageCollectionUpdateStateParameters
	{
		///<summary>The garbage_collection sensor entity_id eg: sensor.general_waste</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }
	}

	public class GoogleServices
	{
		private readonly IHaContext _haContext;
		public GoogleServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Add a new calendar event.</summary>
		public void AddEvent(GoogleAddEventParameters data)
		{
			_haContext.CallService("google", "add_event", null, data);
		}

		///<summary>Add a new calendar event.</summary>
		///<param name="calendarId">The id of the calendar you want. eg: Your email</param>
		///<param name="summary">Acts as the title of the event. eg: Bowling</param>
		///<param name="description">The description of the event. Optional. eg: Birthday bowling</param>
		///<param name="startDateTime">The date and time the event should start. eg: 2019-03-22 20:00:00</param>
		///<param name="endDateTime">The date and time the event should end. eg: 2019-03-22 22:00:00</param>
		///<param name="startDate">The date the whole day event should start. eg: 2019-03-10</param>
		///<param name="endDate">The date the whole day event should end. eg: 2019-03-11</param>
		///<param name="in">Days or weeks that you want to create the event in. eg: "days": 2 or "weeks": 2</param>
		public void AddEvent(string @calendarId, string @summary, string? @description = null, string? @startDateTime = null, string? @endDateTime = null, string? @startDate = null, string? @endDate = null, object? @in = null)
		{
			_haContext.CallService("google", "add_event", null, new GoogleAddEventParameters{CalendarId = @calendarId, Summary = @summary, Description = @description, StartDateTime = @startDateTime, EndDateTime = @endDateTime, StartDate = @startDate, EndDate = @endDate, In = @in});
		}

		///<summary>Scan for new calendars.</summary>
		public void ScanForCalendars()
		{
			_haContext.CallService("google", "scan_for_calendars", null);
		}
	}

	public record GoogleAddEventParameters
	{
		///<summary>The id of the calendar you want. eg: Your email</summary>
		[JsonPropertyName("calendar_id")]
		public string? CalendarId { get; init; }

		///<summary>Acts as the title of the event. eg: Bowling</summary>
		[JsonPropertyName("summary")]
		public string? Summary { get; init; }

		///<summary>The description of the event. Optional. eg: Birthday bowling</summary>
		[JsonPropertyName("description")]
		public string? Description { get; init; }

		///<summary>The date and time the event should start. eg: 2019-03-22 20:00:00</summary>
		[JsonPropertyName("start_date_time")]
		public string? StartDateTime { get; init; }

		///<summary>The date and time the event should end. eg: 2019-03-22 22:00:00</summary>
		[JsonPropertyName("end_date_time")]
		public string? EndDateTime { get; init; }

		///<summary>The date the whole day event should start. eg: 2019-03-10</summary>
		[JsonPropertyName("start_date")]
		public string? StartDate { get; init; }

		///<summary>The date the whole day event should end. eg: 2019-03-11</summary>
		[JsonPropertyName("end_date")]
		public string? EndDate { get; init; }

		///<summary>Days or weeks that you want to create the event in. eg: "days": 2 or "weeks": 2</summary>
		[JsonPropertyName("in")]
		public object? In { get; init; }
	}

	public class GroupServices
	{
		private readonly IHaContext _haContext;
		public GroupServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload group configuration, entities, and notify services.</summary>
		public void Reload()
		{
			_haContext.CallService("group", "reload", null);
		}

		///<summary>Remove a user group.</summary>
		public void Remove(GroupRemoveParameters data)
		{
			_haContext.CallService("group", "remove", null, data);
		}

		///<summary>Remove a user group.</summary>
		///<param name="objectId">Group id and part of entity id. eg: test_group</param>
		public void Remove(object @objectId)
		{
			_haContext.CallService("group", "remove", null, new GroupRemoveParameters{ObjectId = @objectId});
		}

		///<summary>Create/Update a user group.</summary>
		public void Set(GroupSetParameters data)
		{
			_haContext.CallService("group", "set", null, data);
		}

		///<summary>Create/Update a user group.</summary>
		///<param name="objectId">Group id and part of entity id. eg: test_group</param>
		///<param name="name">Name of group eg: My test group</param>
		///<param name="icon">Name of icon for the group. eg: mdi:camera</param>
		///<param name="entities">List of all members in the group. Not compatible with 'delta'. eg: domain.entity_id1, domain.entity_id2</param>
		///<param name="addEntities">List of members that will change on group listening. eg: domain.entity_id1, domain.entity_id2</param>
		///<param name="all">Enable this option if the group should only turn on when all entities are on.</param>
		public void Set(string @objectId, string? @name = null, object? @icon = null, object? @entities = null, object? @addEntities = null, bool? @all = null)
		{
			_haContext.CallService("group", "set", null, new GroupSetParameters{ObjectId = @objectId, Name = @name, Icon = @icon, Entities = @entities, AddEntities = @addEntities, All = @all});
		}
	}

	public record GroupRemoveParameters
	{
		///<summary>Group id and part of entity id. eg: test_group</summary>
		[JsonPropertyName("object_id")]
		public object? ObjectId { get; init; }
	}

	public record GroupSetParameters
	{
		///<summary>Group id and part of entity id. eg: test_group</summary>
		[JsonPropertyName("object_id")]
		public string? ObjectId { get; init; }

		///<summary>Name of group eg: My test group</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Name of icon for the group. eg: mdi:camera</summary>
		[JsonPropertyName("icon")]
		public object? Icon { get; init; }

		///<summary>List of all members in the group. Not compatible with 'delta'. eg: domain.entity_id1, domain.entity_id2</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>List of members that will change on group listening. eg: domain.entity_id1, domain.entity_id2</summary>
		[JsonPropertyName("add_entities")]
		public object? AddEntities { get; init; }

		///<summary>Enable this option if the group should only turn on when all entities are on.</summary>
		[JsonPropertyName("all")]
		public bool? All { get; init; }
	}

	public class HassioServices
	{
		private readonly IHaContext _haContext;
		public HassioServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Restart add-on.</summary>
		public void AddonRestart(HassioAddonRestartParameters data)
		{
			_haContext.CallService("hassio", "addon_restart", null, data);
		}

		///<summary>Restart add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonRestart(string @addon)
		{
			_haContext.CallService("hassio", "addon_restart", null, new HassioAddonRestartParameters{Addon = @addon});
		}

		///<summary>Start add-on.</summary>
		public void AddonStart(HassioAddonStartParameters data)
		{
			_haContext.CallService("hassio", "addon_start", null, data);
		}

		///<summary>Start add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStart(string @addon)
		{
			_haContext.CallService("hassio", "addon_start", null, new HassioAddonStartParameters{Addon = @addon});
		}

		///<summary>Write data to add-on stdin.</summary>
		public void AddonStdin(HassioAddonStdinParameters data)
		{
			_haContext.CallService("hassio", "addon_stdin", null, data);
		}

		///<summary>Write data to add-on stdin.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStdin(string @addon)
		{
			_haContext.CallService("hassio", "addon_stdin", null, new HassioAddonStdinParameters{Addon = @addon});
		}

		///<summary>Stop add-on.</summary>
		public void AddonStop(HassioAddonStopParameters data)
		{
			_haContext.CallService("hassio", "addon_stop", null, data);
		}

		///<summary>Stop add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonStop(string @addon)
		{
			_haContext.CallService("hassio", "addon_stop", null, new HassioAddonStopParameters{Addon = @addon});
		}

		///<summary>Update add-on. This service should be used with caution since add-on updates can contain breaking changes. It is highly recommended that you review release notes/change logs before updating an add-on.</summary>
		public void AddonUpdate(HassioAddonUpdateParameters data)
		{
			_haContext.CallService("hassio", "addon_update", null, data);
		}

		///<summary>Update add-on. This service should be used with caution since add-on updates can contain breaking changes. It is highly recommended that you review release notes/change logs before updating an add-on.</summary>
		///<param name="addon">The add-on slug. eg: core_ssh</param>
		public void AddonUpdate(string @addon)
		{
			_haContext.CallService("hassio", "addon_update", null, new HassioAddonUpdateParameters{Addon = @addon});
		}

		///<summary>Create a full backup.</summary>
		public void BackupFull(HassioBackupFullParameters data)
		{
			_haContext.CallService("hassio", "backup_full", null, data);
		}

		///<summary>Create a full backup.</summary>
		///<param name="name">Optional (default = current date and time). eg: Backup 1</param>
		///<param name="password">Optional password. eg: password</param>
		///<param name="compressed">Use compressed archives</param>
		public void BackupFull(string? @name = null, string? @password = null, bool? @compressed = null)
		{
			_haContext.CallService("hassio", "backup_full", null, new HassioBackupFullParameters{Name = @name, Password = @password, Compressed = @compressed});
		}

		///<summary>Create a partial backup.</summary>
		public void BackupPartial(HassioBackupPartialParameters data)
		{
			_haContext.CallService("hassio", "backup_partial", null, data);
		}

		///<summary>Create a partial backup.</summary>
		///<param name="homeassistant">Backup Home Assistant settings</param>
		///<param name="addons">Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</param>
		///<param name="folders">Optional list of directories. eg: ["homeassistant","share"]</param>
		///<param name="name">Optional (default = current date and time). eg: Partial backup 1</param>
		///<param name="password">Optional password. eg: password</param>
		///<param name="compressed">Use compressed archives</param>
		public void BackupPartial(bool? @homeassistant = null, object? @addons = null, object? @folders = null, string? @name = null, string? @password = null, bool? @compressed = null)
		{
			_haContext.CallService("hassio", "backup_partial", null, new HassioBackupPartialParameters{Homeassistant = @homeassistant, Addons = @addons, Folders = @folders, Name = @name, Password = @password, Compressed = @compressed});
		}

		///<summary>Reboot the host system.</summary>
		public void HostReboot()
		{
			_haContext.CallService("hassio", "host_reboot", null);
		}

		///<summary>Poweroff the host system.</summary>
		public void HostShutdown()
		{
			_haContext.CallService("hassio", "host_shutdown", null);
		}

		///<summary>Restore from full backup.</summary>
		public void RestoreFull(HassioRestoreFullParameters data)
		{
			_haContext.CallService("hassio", "restore_full", null, data);
		}

		///<summary>Restore from full backup.</summary>
		///<param name="slug">Slug of backup to restore from.</param>
		///<param name="password">Optional password. eg: password</param>
		public void RestoreFull(string @slug, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_full", null, new HassioRestoreFullParameters{Slug = @slug, Password = @password});
		}

		///<summary>Restore from partial backup.</summary>
		public void RestorePartial(HassioRestorePartialParameters data)
		{
			_haContext.CallService("hassio", "restore_partial", null, data);
		}

		///<summary>Restore from partial backup.</summary>
		///<param name="slug">Slug of backup to restore from.</param>
		///<param name="homeassistant">Restore Home Assistant</param>
		///<param name="folders">Optional list of directories. eg: ["homeassistant","share"]</param>
		///<param name="addons">Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</param>
		///<param name="password">Optional password. eg: password</param>
		public void RestorePartial(string @slug, bool? @homeassistant = null, object? @folders = null, object? @addons = null, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_partial", null, new HassioRestorePartialParameters{Slug = @slug, Homeassistant = @homeassistant, Folders = @folders, Addons = @addons, Password = @password});
		}
	}

	public record HassioAddonRestartParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStartParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStdinParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStopParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonUpdateParameters
	{
		///<summary>The add-on slug. eg: core_ssh</summary>
		[JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioBackupFullParameters
	{
		///<summary>Optional (default = current date and time). eg: Backup 1</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }

		///<summary>Use compressed archives</summary>
		[JsonPropertyName("compressed")]
		public bool? Compressed { get; init; }
	}

	public record HassioBackupPartialParameters
	{
		///<summary>Backup Home Assistant settings</summary>
		[JsonPropertyName("homeassistant")]
		public bool? Homeassistant { get; init; }

		///<summary>Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</summary>
		[JsonPropertyName("addons")]
		public object? Addons { get; init; }

		///<summary>Optional list of directories. eg: ["homeassistant","share"]</summary>
		[JsonPropertyName("folders")]
		public object? Folders { get; init; }

		///<summary>Optional (default = current date and time). eg: Partial backup 1</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }

		///<summary>Use compressed archives</summary>
		[JsonPropertyName("compressed")]
		public bool? Compressed { get; init; }
	}

	public record HassioRestoreFullParameters
	{
		///<summary>Slug of backup to restore from.</summary>
		[JsonPropertyName("slug")]
		public string? Slug { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public record HassioRestorePartialParameters
	{
		///<summary>Slug of backup to restore from.</summary>
		[JsonPropertyName("slug")]
		public string? Slug { get; init; }

		///<summary>Restore Home Assistant</summary>
		[JsonPropertyName("homeassistant")]
		public bool? Homeassistant { get; init; }

		///<summary>Optional list of directories. eg: ["homeassistant","share"]</summary>
		[JsonPropertyName("folders")]
		public object? Folders { get; init; }

		///<summary>Optional list of add-on slugs. eg: ["core_ssh","core_samba","core_mosquitto"]</summary>
		[JsonPropertyName("addons")]
		public object? Addons { get; init; }

		///<summary>Optional password. eg: password</summary>
		[JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public class HomeassistantServices
	{
		private readonly IHaContext _haContext;
		public HomeassistantServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Check the Home Assistant configuration files for errors. Errors will be displayed in the Home Assistant log.</summary>
		public void CheckConfig()
		{
			_haContext.CallService("homeassistant", "check_config", null);
		}

		///<summary>Reload a config entry that matches a target.</summary>
		///<param name="target">The target for this service call</param>
		public void ReloadConfigEntry(ServiceTarget target, HomeassistantReloadConfigEntryParameters data)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, data);
		}

		///<summary>Reload a config entry that matches a target.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="entryId">A configuration entry id eg: 8955375327824e14ba89e4b29cc3ec9a</param>
		public void ReloadConfigEntry(ServiceTarget target, string? @entryId = null)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, new HomeassistantReloadConfigEntryParameters{EntryId = @entryId});
		}

		///<summary>Reload the core configuration.</summary>
		public void ReloadCoreConfig()
		{
			_haContext.CallService("homeassistant", "reload_core_config", null);
		}

		///<summary>Restart the Home Assistant service.</summary>
		public void Restart()
		{
			_haContext.CallService("homeassistant", "restart", null);
		}

		///<summary>Save the persistent states (for entities derived from RestoreEntity) immediately. Maintain the normal periodic saving interval.</summary>
		public void SavePersistentStates()
		{
			_haContext.CallService("homeassistant", "save_persistent_states", null);
		}

		///<summary>Update the Home Assistant location.</summary>
		public void SetLocation(HomeassistantSetLocationParameters data)
		{
			_haContext.CallService("homeassistant", "set_location", null, data);
		}

		///<summary>Update the Home Assistant location.</summary>
		///<param name="latitude">Latitude of your location. eg: 32.87336</param>
		///<param name="longitude">Longitude of your location. eg: 117.22743</param>
		public void SetLocation(string @latitude, string @longitude)
		{
			_haContext.CallService("homeassistant", "set_location", null, new HomeassistantSetLocationParameters{Latitude = @latitude, Longitude = @longitude});
		}

		///<summary>Stop the Home Assistant service.</summary>
		public void Stop()
		{
			_haContext.CallService("homeassistant", "stop", null);
		}

		///<summary>Generic service to toggle devices on/off under any domain</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "toggle", target);
		}

		///<summary>Generic service to turn devices off under any domain.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_off", target);
		}

		///<summary>Generic service to turn devices on under any domain.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_on", target);
		}

		///<summary>Force one or more entities to update its data</summary>
		///<param name="target">The target for this service call</param>
		public void UpdateEntity(ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "update_entity", target);
		}
	}

	public record HomeassistantReloadConfigEntryParameters
	{
		///<summary>A configuration entry id eg: 8955375327824e14ba89e4b29cc3ec9a</summary>
		[JsonPropertyName("entry_id")]
		public string? EntryId { get; init; }
	}

	public record HomeassistantSetLocationParameters
	{
		///<summary>Latitude of your location. eg: 32.87336</summary>
		[JsonPropertyName("latitude")]
		public string? Latitude { get; init; }

		///<summary>Longitude of your location. eg: 117.22743</summary>
		[JsonPropertyName("longitude")]
		public string? Longitude { get; init; }
	}

	public class HumidifierServices
	{
		private readonly IHaContext _haContext;
		public HumidifierServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set target humidity of humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHumidity(ServiceTarget target, HumidifierSetHumidityParameters data)
		{
			_haContext.CallService("humidifier", "set_humidity", target, data);
		}

		///<summary>Set target humidity of humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="humidity">New target humidity for humidifier device.</param>
		public void SetHumidity(ServiceTarget target, long @humidity)
		{
			_haContext.CallService("humidifier", "set_humidity", target, new HumidifierSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set mode for humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void SetMode(ServiceTarget target, HumidifierSetModeParameters data)
		{
			_haContext.CallService("humidifier", "set_mode", target, data);
		}

		///<summary>Set mode for humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mode">New mode eg: away</param>
		public void SetMode(ServiceTarget target, string @mode)
		{
			_haContext.CallService("humidifier", "set_mode", target, new HumidifierSetModeParameters{Mode = @mode});
		}

		///<summary>Toggles a humidifier device.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "toggle", target);
		}

		///<summary>Turn humidifier device off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "turn_off", target);
		}

		///<summary>Turn humidifier device on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("humidifier", "turn_on", target);
		}
	}

	public record HumidifierSetHumidityParameters
	{
		///<summary>New target humidity for humidifier device.</summary>
		[JsonPropertyName("humidity")]
		public long? Humidity { get; init; }
	}

	public record HumidifierSetModeParameters
	{
		///<summary>New mode eg: away</summary>
		[JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public class IcloudServices
	{
		private readonly IHaContext _haContext;
		public IcloudServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Display a message on an Apple device.</summary>
		public void DisplayMessage(IcloudDisplayMessageParameters data)
		{
			_haContext.CallService("icloud", "display_message", null, data);
		}

		///<summary>Display a message on an Apple device.</summary>
		///<param name="account">Your iCloud account username (email) or account name. eg: steve@apple.com</param>
		///<param name="deviceName">The name of the Apple device to display the message. eg: stevesiphone</param>
		///<param name="message">The content of your message. eg: Hey Steve !</param>
		///<param name="sound">To make a sound when displaying the message.</param>
		public void DisplayMessage(string @account, string @deviceName, string @message, bool? @sound = null)
		{
			_haContext.CallService("icloud", "display_message", null, new IcloudDisplayMessageParameters{Account = @account, DeviceName = @deviceName, Message = @message, Sound = @sound});
		}

		///<summary>Make an Apple device in lost state.</summary>
		public void LostDevice(IcloudLostDeviceParameters data)
		{
			_haContext.CallService("icloud", "lost_device", null, data);
		}

		///<summary>Make an Apple device in lost state.</summary>
		///<param name="account">Your iCloud account username (email) or account name. eg: steve@apple.com</param>
		///<param name="deviceName">The name of the Apple device to set lost. eg: stevesiphone</param>
		///<param name="number">The phone number to call in lost mode (must contain country code). eg: +33450020100</param>
		///<param name="message">The message to display in lost mode. eg: Call me</param>
		public void LostDevice(string @account, string @deviceName, string @number, string @message)
		{
			_haContext.CallService("icloud", "lost_device", null, new IcloudLostDeviceParameters{Account = @account, DeviceName = @deviceName, Number = @number, Message = @message});
		}

		///<summary>Play sound on an Apple device.</summary>
		public void PlaySound(IcloudPlaySoundParameters data)
		{
			_haContext.CallService("icloud", "play_sound", null, data);
		}

		///<summary>Play sound on an Apple device.</summary>
		///<param name="account">Your iCloud account username (email) or account name. eg: steve@apple.com</param>
		///<param name="deviceName">The name of the Apple device to play a sound. eg: stevesiphone</param>
		public void PlaySound(string @account, string @deviceName)
		{
			_haContext.CallService("icloud", "play_sound", null, new IcloudPlaySoundParameters{Account = @account, DeviceName = @deviceName});
		}

		///<summary>Update iCloud devices.</summary>
		public void Update(IcloudUpdateParameters data)
		{
			_haContext.CallService("icloud", "update", null, data);
		}

		///<summary>Update iCloud devices.</summary>
		///<param name="account">Your iCloud account username (email) or account name. eg: steve@apple.com</param>
		public void Update(string @account)
		{
			_haContext.CallService("icloud", "update", null, new IcloudUpdateParameters{Account = @account});
		}
	}

	public record IcloudDisplayMessageParameters
	{
		///<summary>Your iCloud account username (email) or account name. eg: steve@apple.com</summary>
		[JsonPropertyName("account")]
		public string? Account { get; init; }

		///<summary>The name of the Apple device to display the message. eg: stevesiphone</summary>
		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }

		///<summary>The content of your message. eg: Hey Steve !</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>To make a sound when displaying the message.</summary>
		[JsonPropertyName("sound")]
		public bool? Sound { get; init; }
	}

	public record IcloudLostDeviceParameters
	{
		///<summary>Your iCloud account username (email) or account name. eg: steve@apple.com</summary>
		[JsonPropertyName("account")]
		public string? Account { get; init; }

		///<summary>The name of the Apple device to set lost. eg: stevesiphone</summary>
		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }

		///<summary>The phone number to call in lost mode (must contain country code). eg: +33450020100</summary>
		[JsonPropertyName("number")]
		public string? Number { get; init; }

		///<summary>The message to display in lost mode. eg: Call me</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record IcloudPlaySoundParameters
	{
		///<summary>Your iCloud account username (email) or account name. eg: steve@apple.com</summary>
		[JsonPropertyName("account")]
		public string? Account { get; init; }

		///<summary>The name of the Apple device to play a sound. eg: stevesiphone</summary>
		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }
	}

	public record IcloudUpdateParameters
	{
		///<summary>Your iCloud account username (email) or account name. eg: steve@apple.com</summary>
		[JsonPropertyName("account")]
		public string? Account { get; init; }
	}

	public class InputBooleanServices
	{
		private readonly IHaContext _haContext;
		public InputBooleanServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_boolean configuration</summary>
		public void Reload()
		{
			_haContext.CallService("input_boolean", "reload", null);
		}

		///<summary>Toggle an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "toggle", target);
		}

		///<summary>Turn off an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_off", target);
		}

		///<summary>Turn on an input boolean</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_on", target);
		}
	}

	public class InputDatetimeServices
	{
		private readonly IHaContext _haContext;
		public InputDatetimeServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_datetime configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_datetime", "reload", null);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The target for this service call</param>
		public void SetDatetime(ServiceTarget target, InputDatetimeSetDatetimeParameters data)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, data);
		}

		///<summary>This can be used to dynamically set the date and/or time.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="date">The target date the entity should be set to. eg: "2019-04-20"</param>
		///<param name="time">The target time the entity should be set to. eg: "05:04:20"</param>
		///<param name="datetime">The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</param>
		///<param name="timestamp">The target date & time the entity should be set to as expressed by a UNIX timestamp.</param>
		public void SetDatetime(ServiceTarget target, string? @date = null, DateTime? @time = null, string? @datetime = null, long? @timestamp = null)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, new InputDatetimeSetDatetimeParameters{Date = @date, Time = @time, Datetime = @datetime, Timestamp = @timestamp});
		}
	}

	public record InputDatetimeSetDatetimeParameters
	{
		///<summary>The target date the entity should be set to. eg: "2019-04-20"</summary>
		[JsonPropertyName("date")]
		public string? Date { get; init; }

		///<summary>The target time the entity should be set to. eg: "05:04:20"</summary>
		[JsonPropertyName("time")]
		public DateTime? Time { get; init; }

		///<summary>The target date & time the entity should be set to. eg: "2019-04-20 05:04:20"</summary>
		[JsonPropertyName("datetime")]
		public string? Datetime { get; init; }

		///<summary>The target date & time the entity should be set to as expressed by a UNIX timestamp.</summary>
		[JsonPropertyName("timestamp")]
		public long? Timestamp { get; init; }
	}

	public class InputNumberServices
	{
		private readonly IHaContext _haContext;
		public InputNumberServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Decrement the value of an input number entity by its stepping.</summary>
		///<param name="target">The target for this service call</param>
		public void Decrement(ServiceTarget target)
		{
			_haContext.CallService("input_number", "decrement", target);
		}

		///<summary>Increment the value of an input number entity by its stepping.</summary>
		///<param name="target">The target for this service call</param>
		public void Increment(ServiceTarget target)
		{
			_haContext.CallService("input_number", "increment", target);
		}

		///<summary>Reload the input_number configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_number", "reload", null);
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, InputNumberSetValueParameters data)
		{
			_haContext.CallService("input_number", "set_value", target, data);
		}

		///<summary>Set the value of an input number entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to.</param>
		public void SetValue(ServiceTarget target, double @value)
		{
			_haContext.CallService("input_number", "set_value", target, new InputNumberSetValueParameters{Value = @value});
		}
	}

	public record InputNumberSetValueParameters
	{
		///<summary>The target value the entity should be set to.</summary>
		[JsonPropertyName("value")]
		public double? Value { get; init; }
	}

	public class InputSelectServices
	{
		private readonly IHaContext _haContext;
		public InputSelectServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_select configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_select", "reload", null);
		}

		///<summary>Select the first option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectFirst(ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_first", target);
		}

		///<summary>Select the last option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectLast(ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_last", target);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectNext(ServiceTarget target, InputSelectSelectNextParameters data)
		{
			_haContext.CallService("input_select", "select_next", target, data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public void SelectNext(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_next", target, new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectOption(ServiceTarget target, InputSelectSelectOptionParameters data)
		{
			_haContext.CallService("input_select", "select_option", target, data);
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public void SelectOption(ServiceTarget target, string @option)
		{
			_haContext.CallService("input_select", "select_option", target, new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectPrevious(ServiceTarget target, InputSelectSelectPreviousParameters data)
		{
			_haContext.CallService("input_select", "select_previous", target, data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public void SelectPrevious(ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_previous", target, new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetOptions(ServiceTarget target, InputSelectSetOptionsParameters data)
		{
			_haContext.CallService("input_select", "set_options", target, data);
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public void SetOptions(ServiceTarget target, object @options)
		{
			_haContext.CallService("input_select", "set_options", target, new InputSelectSetOptionsParameters{Options = @options});
		}
	}

	public record InputSelectSelectNextParameters
	{
		///<summary>If the option should cycle from the last to the first.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSelectOptionParameters
	{
		///<summary>Option to be selected. eg: "Item A"</summary>
		[JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public record InputSelectSelectPreviousParameters
	{
		///<summary>If the option should cycle from the first to the last.</summary>
		[JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSetOptionsParameters
	{
		///<summary>Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class InputTextServices
	{
		private readonly IHaContext _haContext;
		public InputTextServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the input_text configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("input_text", "reload", null);
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, InputTextSetValueParameters data)
		{
			_haContext.CallService("input_text", "set_value", target, data);
		}

		///<summary>Set the value of an input text entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to. eg: This is an example text</param>
		public void SetValue(ServiceTarget target, string @value)
		{
			_haContext.CallService("input_text", "set_value", target, new InputTextSetValueParameters{Value = @value});
		}
	}

	public record InputTextSetValueParameters
	{
		///<summary>The target value the entity should be set to. eg: This is an example text</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class LightServices
	{
		private readonly IHaContext _haContext;
		public LightServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target, LightToggleParameters data)
		{
			_haContext.CallService("light", "toggle", target, data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="whiteValue">Number indicating level of white.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public void Toggle(ServiceTarget target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @whiteValue = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "toggle", target, new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, WhiteValue = @whiteValue, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target, LightTurnOffParameters data)
		{
			_haContext.CallService("light", "turn_off", target, data);
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public void TurnOff(ServiceTarget target, long? @transition = null, object? @flash = null)
		{
			_haContext.CallService("light", "turn_off", target, new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, LightTurnOnParameters data)
		{
			_haContext.CallService("light", "turn_on", target, data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public void TurnOn(ServiceTarget target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "turn_on", target, new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}
	}

	public record LightToggleParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>Color for the light in RGB-format. eg: [255, 100, 100]</summary>
		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		///<summary>A human readable color name.</summary>
		[JsonPropertyName("color_name")]
		public object? ColorName { get; init; }

		///<summary>Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</summary>
		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		///<summary>Color for the light in XY-format. eg: [0.52, 0.43]</summary>
		[JsonPropertyName("xy_color")]
		public object? XyColor { get; init; }

		///<summary>Color temperature for the light in mireds.</summary>
		[JsonPropertyName("color_temp")]
		public object? ColorTemp { get; init; }

		///<summary>Color temperature for the light in Kelvin.</summary>
		[JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		///<summary>Number indicating level of white.</summary>
		[JsonPropertyName("white_value")]
		public long? WhiteValue { get; init; }

		///<summary>Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		///<summary>Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness_pct")]
		public long? BrightnessPct { get; init; }

		///<summary>Name of a light profile to use. eg: relax</summary>
		[JsonPropertyName("profile")]
		public string? Profile { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }

		///<summary>Light effect.</summary>
		[JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public record LightTurnOffParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }
	}

	public record LightTurnOnParameters
	{
		///<summary>Duration it takes to get to next state.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }

		///<summary>The color for the light (based on RGB - red, green, blue).</summary>
		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		///<summary>A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</summary>
		[JsonPropertyName("rgbw_color")]
		public object? RgbwColor { get; init; }

		///<summary>A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</summary>
		[JsonPropertyName("rgbww_color")]
		public object? RgbwwColor { get; init; }

		///<summary>A human readable color name.</summary>
		[JsonPropertyName("color_name")]
		public object? ColorName { get; init; }

		///<summary>Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</summary>
		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		///<summary>Color for the light in XY-format. eg: [0.52, 0.43]</summary>
		[JsonPropertyName("xy_color")]
		public object? XyColor { get; init; }

		///<summary>Color temperature for the light in mireds.</summary>
		[JsonPropertyName("color_temp")]
		public object? ColorTemp { get; init; }

		///<summary>Color temperature for the light in Kelvin.</summary>
		[JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		///<summary>Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		///<summary>Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("brightness_pct")]
		public long? BrightnessPct { get; init; }

		///<summary>Change brightness by an amount.</summary>
		[JsonPropertyName("brightness_step")]
		public long? BrightnessStep { get; init; }

		///<summary>Change brightness by a percentage.</summary>
		[JsonPropertyName("brightness_step_pct")]
		public long? BrightnessStepPct { get; init; }

		///<summary>Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</summary>
		[JsonPropertyName("white")]
		public long? White { get; init; }

		///<summary>Name of a light profile to use. eg: relax</summary>
		[JsonPropertyName("profile")]
		public string? Profile { get; init; }

		///<summary>If the light should flash.</summary>
		[JsonPropertyName("flash")]
		public object? Flash { get; init; }

		///<summary>Light effect.</summary>
		[JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public class LockServices
	{
		private readonly IHaContext _haContext;
		public LockServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Lock(ServiceTarget target, LockLockParameters data)
		{
			_haContext.CallService("lock", "lock", target, data);
		}

		///<summary>Lock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to lock the lock with. eg: 1234</param>
		public void Lock(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "lock", target, new LockLockParameters{Code = @code});
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Open(ServiceTarget target, LockOpenParameters data)
		{
			_haContext.CallService("lock", "open", target, data);
		}

		///<summary>Open all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to open the lock with. eg: 1234</param>
		public void Open(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "open", target, new LockOpenParameters{Code = @code});
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		public void Unlock(ServiceTarget target, LockUnlockParameters data)
		{
			_haContext.CallService("lock", "unlock", target, data);
		}

		///<summary>Unlock all or specified locks.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="code">An optional code to unlock the lock with. eg: 1234</param>
		public void Unlock(ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "unlock", target, new LockUnlockParameters{Code = @code});
		}
	}

	public record LockLockParameters
	{
		///<summary>An optional code to lock the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockOpenParameters
	{
		///<summary>An optional code to open the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockUnlockParameters
	{
		///<summary>An optional code to unlock the lock with. eg: 1234</summary>
		[JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class LogbookServices
	{
		private readonly IHaContext _haContext;
		public LogbookServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Create a custom entry in your logbook.</summary>
		public void Log(LogbookLogParameters data)
		{
			_haContext.CallService("logbook", "log", null, data);
		}

		///<summary>Create a custom entry in your logbook.</summary>
		///<param name="name">Custom name for an entity, can be referenced with entity_id. eg: Kitchen</param>
		///<param name="message">Message of the custom logbook entry. eg: is being used</param>
		///<param name="entityId">Entity to reference in custom logbook entry.</param>
		///<param name="domain">Icon of domain to display in custom logbook entry. eg: light</param>
		public void Log(string @name, string @message, string? @entityId = null, string? @domain = null)
		{
			_haContext.CallService("logbook", "log", null, new LogbookLogParameters{Name = @name, Message = @message, EntityId = @entityId, Domain = @domain});
		}
	}

	public record LogbookLogParameters
	{
		///<summary>Custom name for an entity, can be referenced with entity_id. eg: Kitchen</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }

		///<summary>Message of the custom logbook entry. eg: is being used</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Entity to reference in custom logbook entry.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Icon of domain to display in custom logbook entry. eg: light</summary>
		[JsonPropertyName("domain")]
		public string? Domain { get; init; }
	}

	public class LoggerServices
	{
		private readonly IHaContext _haContext;
		public LoggerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set the default log level for integrations.</summary>
		public void SetDefaultLevel(LoggerSetDefaultLevelParameters data)
		{
			_haContext.CallService("logger", "set_default_level", null, data);
		}

		///<summary>Set the default log level for integrations.</summary>
		///<param name="level">Default severity level for all integrations.</param>
		public void SetDefaultLevel(object? @level = null)
		{
			_haContext.CallService("logger", "set_default_level", null, new LoggerSetDefaultLevelParameters{Level = @level});
		}

		///<summary>Set log level for integrations.</summary>
		public void SetLevel()
		{
			_haContext.CallService("logger", "set_level", null);
		}
	}

	public record LoggerSetDefaultLevelParameters
	{
		///<summary>Default severity level for all integrations.</summary>
		[JsonPropertyName("level")]
		public object? Level { get; init; }
	}

	public class MediaPlayerServices
	{
		private readonly IHaContext _haContext;
		public MediaPlayerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Send the media player the command to clear players playlist.</summary>
		///<param name="target">The target for this service call</param>
		public void ClearPlaylist(ServiceTarget target)
		{
			_haContext.CallService("media_player", "clear_playlist", target);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		public void Join(ServiceTarget target, MediaPlayerJoinParameters data)
		{
			_haContext.CallService("media_player", "join", target, data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: ["media_player.multiroom_player2","media_player.multiroom_player3"]</param>
		public void Join(ServiceTarget target, object? @groupMembers = null)
		{
			_haContext.CallService("media_player", "join", target, new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Send the media player the command for next track.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaNextTrack(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_next_track", target);
		}

		///<summary>Send the media player the command for pause.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPause(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_pause", target);
		}

		///<summary>Send the media player the command for play.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPlay(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play", target);
		}

		///<summary>Toggle media player play/pause state.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPlayPause(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play_pause", target);
		}

		///<summary>Send the media player the command for previous track.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaPreviousTrack(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_previous_track", target);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaSeek(ServiceTarget target, MediaPlayerMediaSeekParameters data)
		{
			_haContext.CallService("media_player", "media_seek", target, data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public void MediaSeek(ServiceTarget target, double @seekPosition)
		{
			_haContext.CallService("media_player", "media_seek", target, new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the stop command.</summary>
		///<param name="target">The target for this service call</param>
		public void MediaStop(ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_stop", target);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The target for this service call</param>
		public void PlayMedia(ServiceTarget target, MediaPlayerPlayMediaParameters data)
		{
			_haContext.CallService("media_player", "play_media", target, data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public void PlayMedia(ServiceTarget target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			_haContext.CallService("media_player", "play_media", target, new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The target for this service call</param>
		public void RepeatSet(ServiceTarget target, MediaPlayerRepeatSetParameters data)
		{
			_haContext.CallService("media_player", "repeat_set", target, data);
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The target for this service call</param>
		///<param name="repeat">Repeat mode to set.</param>
		public void RepeatSet(ServiceTarget target, object @repeat)
		{
			_haContext.CallService("media_player", "repeat_set", target, new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectSoundMode(ServiceTarget target, MediaPlayerSelectSoundModeParameters data)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public void SelectSoundMode(ServiceTarget target, string? @soundMode = null)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectSource(ServiceTarget target, MediaPlayerSelectSourceParameters data)
		{
			_haContext.CallService("media_player", "select_source", target, data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public void SelectSource(ServiceTarget target, string @source)
		{
			_haContext.CallService("media_player", "select_source", target, new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The target for this service call</param>
		public void ShuffleSet(ServiceTarget target, MediaPlayerShuffleSetParameters data)
		{
			_haContext.CallService("media_player", "shuffle_set", target, data);
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public void ShuffleSet(ServiceTarget target, bool @shuffle)
		{
			_haContext.CallService("media_player", "shuffle_set", target, new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Toggles a media player power state.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("media_player", "toggle", target);
		}

		///<summary>Turn a media player power off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_off", target);
		}

		///<summary>Turn a media player power on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_on", target);
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		///<param name="target">The target for this service call</param>
		public void Unjoin(ServiceTarget target)
		{
			_haContext.CallService("media_player", "unjoin", target);
		}

		///<summary>Turn a media player volume down.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeDown(ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_down", target);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeMute(ServiceTarget target, MediaPlayerVolumeMuteParameters data)
		{
			_haContext.CallService("media_player", "volume_mute", target, data);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public void VolumeMute(ServiceTarget target, bool @isVolumeMuted)
		{
			_haContext.CallService("media_player", "volume_mute", target, new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeSet(ServiceTarget target, MediaPlayerVolumeSetParameters data)
		{
			_haContext.CallService("media_player", "volume_set", target, data);
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public void VolumeSet(ServiceTarget target, double @volumeLevel)
		{
			_haContext.CallService("media_player", "volume_set", target, new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Turn a media player volume up.</summary>
		///<param name="target">The target for this service call</param>
		public void VolumeUp(ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_up", target);
		}
	}

	public record MediaPlayerJoinParameters
	{
		///<summary>The players which will be synced with the target player. eg: ["media_player.multiroom_player2","media_player.multiroom_player3"]</summary>
		[JsonPropertyName("group_members")]
		public object? GroupMembers { get; init; }
	}

	public record MediaPlayerMediaSeekParameters
	{
		///<summary>Position to seek to. The format is platform dependent.</summary>
		[JsonPropertyName("seek_position")]
		public double? SeekPosition { get; init; }
	}

	public record MediaPlayerPlayMediaParameters
	{
		///<summary>The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</summary>
		[JsonPropertyName("media_content_id")]
		public string? MediaContentId { get; init; }

		///<summary>The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</summary>
		[JsonPropertyName("media_content_type")]
		public string? MediaContentType { get; init; }

		///<summary>If the content should be played now or be added to the queue.</summary>
		[JsonPropertyName("enqueue")]
		public object? Enqueue { get; init; }

		///<summary>If the media should be played as an announcement. eg: true</summary>
		[JsonPropertyName("announce")]
		public bool? Announce { get; init; }
	}

	public record MediaPlayerRepeatSetParameters
	{
		///<summary>Repeat mode to set.</summary>
		[JsonPropertyName("repeat")]
		public object? Repeat { get; init; }
	}

	public record MediaPlayerSelectSoundModeParameters
	{
		///<summary>Name of the sound mode to switch to. eg: Music</summary>
		[JsonPropertyName("sound_mode")]
		public string? SoundMode { get; init; }
	}

	public record MediaPlayerSelectSourceParameters
	{
		///<summary>Name of the source to switch to. Platform dependent. eg: video1</summary>
		[JsonPropertyName("source")]
		public string? Source { get; init; }
	}

	public record MediaPlayerShuffleSetParameters
	{
		///<summary>True/false for enabling/disabling shuffle.</summary>
		[JsonPropertyName("shuffle")]
		public bool? Shuffle { get; init; }
	}

	public record MediaPlayerVolumeMuteParameters
	{
		///<summary>True/false for mute/unmute.</summary>
		[JsonPropertyName("is_volume_muted")]
		public bool? IsVolumeMuted { get; init; }
	}

	public record MediaPlayerVolumeSetParameters
	{
		///<summary>Volume level to set as float.</summary>
		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }
	}

	public class MotioneyeServices
	{
		private readonly IHaContext _haContext;
		public MotioneyeServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Trigger a motionEye action</summary>
		///<param name="target">The target for this service call</param>
		public void Action(ServiceTarget target, MotioneyeActionParameters data)
		{
			_haContext.CallService("motioneye", "action", target, data);
		}

		///<summary>Trigger a motionEye action</summary>
		///<param name="target">The target for this service call</param>
		///<param name="action">Action to trigger eg: snapshot</param>
		public void Action(ServiceTarget target, object @action)
		{
			_haContext.CallService("motioneye", "action", target, new MotioneyeActionParameters{Action = @action});
		}

		///<summary>Sets the text overlay for a camera.</summary>
		///<param name="target">The target for this service call</param>
		public void SetTextOverlay(ServiceTarget target, MotioneyeSetTextOverlayParameters data)
		{
			_haContext.CallService("motioneye", "set_text_overlay", target, data);
		}

		///<summary>Sets the text overlay for a camera.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="leftText">Text to display on the left eg: timestamp</param>
		///<param name="customLeftText">Custom text to display on the left eg: Hello on the left!</param>
		///<param name="rightText">Text to display on the right eg: timestamp</param>
		///<param name="customRightText">Custom text to display on the right eg: Hello on the right!</param>
		public void SetTextOverlay(ServiceTarget target, object? @leftText = null, string? @customLeftText = null, object? @rightText = null, string? @customRightText = null)
		{
			_haContext.CallService("motioneye", "set_text_overlay", target, new MotioneyeSetTextOverlayParameters{LeftText = @leftText, CustomLeftText = @customLeftText, RightText = @rightText, CustomRightText = @customRightText});
		}

		///<summary>Trigger a motionEye still snapshot</summary>
		///<param name="target">The target for this service call</param>
		public void Snapshot(ServiceTarget target)
		{
			_haContext.CallService("motioneye", "snapshot", target);
		}
	}

	public record MotioneyeActionParameters
	{
		///<summary>Action to trigger eg: snapshot</summary>
		[JsonPropertyName("action")]
		public object? Action { get; init; }
	}

	public record MotioneyeSetTextOverlayParameters
	{
		///<summary>Text to display on the left eg: timestamp</summary>
		[JsonPropertyName("left_text")]
		public object? LeftText { get; init; }

		///<summary>Custom text to display on the left eg: Hello on the left!</summary>
		[JsonPropertyName("custom_left_text")]
		public string? CustomLeftText { get; init; }

		///<summary>Text to display on the right eg: timestamp</summary>
		[JsonPropertyName("right_text")]
		public object? RightText { get; init; }

		///<summary>Custom text to display on the right eg: Hello on the right!</summary>
		[JsonPropertyName("custom_right_text")]
		public string? CustomRightText { get; init; }
	}

	public class MqttServices
	{
		private readonly IHaContext _haContext;
		public MqttServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Dump messages on a topic selector to the 'mqtt_dump.txt' file in your configuration folder.</summary>
		public void Dump(MqttDumpParameters data)
		{
			_haContext.CallService("mqtt", "dump", null, data);
		}

		///<summary>Dump messages on a topic selector to the 'mqtt_dump.txt' file in your configuration folder.</summary>
		///<param name="topic">topic to listen to eg: OpenZWave/#</param>
		///<param name="duration">how long we should listen for messages in seconds</param>
		public void Dump(string? @topic = null, long? @duration = null)
		{
			_haContext.CallService("mqtt", "dump", null, new MqttDumpParameters{Topic = @topic, Duration = @duration});
		}

		///<summary>Publish a message to an MQTT topic.</summary>
		public void Publish(MqttPublishParameters data)
		{
			_haContext.CallService("mqtt", "publish", null, data);
		}

		///<summary>Publish a message to an MQTT topic.</summary>
		///<param name="topic">Topic to publish payload. eg: /homeassistant/hello</param>
		///<param name="payload">Payload to publish. eg: This is great</param>
		///<param name="payloadTemplate">Template to render as payload value. Ignored if payload given. eg: {{ states('sensor.temperature') }}</param>
		///<param name="qos">Quality of Service to use.</param>
		///<param name="retain">If message should have the retain flag set.</param>
		public void Publish(string @topic, string? @payload = null, object? @payloadTemplate = null, object? @qos = null, bool? @retain = null)
		{
			_haContext.CallService("mqtt", "publish", null, new MqttPublishParameters{Topic = @topic, Payload = @payload, PayloadTemplate = @payloadTemplate, Qos = @qos, Retain = @retain});
		}

		///<summary>Reload all MQTT entities from YAML.</summary>
		public void Reload()
		{
			_haContext.CallService("mqtt", "reload", null);
		}
	}

	public record MqttDumpParameters
	{
		///<summary>topic to listen to eg: OpenZWave/#</summary>
		[JsonPropertyName("topic")]
		public string? Topic { get; init; }

		///<summary>how long we should listen for messages in seconds</summary>
		[JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record MqttPublishParameters
	{
		///<summary>Topic to publish payload. eg: /homeassistant/hello</summary>
		[JsonPropertyName("topic")]
		public string? Topic { get; init; }

		///<summary>Payload to publish. eg: This is great</summary>
		[JsonPropertyName("payload")]
		public string? Payload { get; init; }

		///<summary>Template to render as payload value. Ignored if payload given. eg: {{ states('sensor.temperature') }}</summary>
		[JsonPropertyName("payload_template")]
		public object? PayloadTemplate { get; init; }

		///<summary>Quality of Service to use.</summary>
		[JsonPropertyName("qos")]
		public object? Qos { get; init; }

		///<summary>If message should have the retain flag set.</summary>
		[JsonPropertyName("retain")]
		public bool? Retain { get; init; }
	}

	public class NeatoServices
	{
		private readonly IHaContext _haContext;
		public NeatoServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		///<param name="target">The target for this service call</param>
		public void CustomCleaning(ServiceTarget target, NeatoCustomCleaningParameters data)
		{
			_haContext.CallService("neato", "custom_cleaning", target, data);
		}

		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mode">Set the cleaning mode: 1 for eco and 2 for turbo. Defaults to turbo if not set.</param>
		///<param name="navigation">Set the navigation mode: 1 for normal, 2 for extra care, 3 for deep. Defaults to normal if not set.</param>
		///<param name="category">Whether to use a persistent map or not for cleaning (i.e. No go lines): 2 for no map, 4 for map. Default to using map if not set (and fallback to no map if no map is found).</param>
		///<param name="zone">Only supported on the Botvac D7. Name of the zone to clean. Defaults to no zone i.e. complete house cleanup. eg: Kitchen</param>
		public void CustomCleaning(ServiceTarget target, long? @mode = null, long? @navigation = null, long? @category = null, string? @zone = null)
		{
			_haContext.CallService("neato", "custom_cleaning", target, new NeatoCustomCleaningParameters{Mode = @mode, Navigation = @navigation, Category = @category, Zone = @zone});
		}
	}

	public record NeatoCustomCleaningParameters
	{
		///<summary>Set the cleaning mode: 1 for eco and 2 for turbo. Defaults to turbo if not set.</summary>
		[JsonPropertyName("mode")]
		public long? Mode { get; init; }

		///<summary>Set the navigation mode: 1 for normal, 2 for extra care, 3 for deep. Defaults to normal if not set.</summary>
		[JsonPropertyName("navigation")]
		public long? Navigation { get; init; }

		///<summary>Whether to use a persistent map or not for cleaning (i.e. No go lines): 2 for no map, 4 for map. Default to using map if not set (and fallback to no map if no map is found).</summary>
		[JsonPropertyName("category")]
		public long? Category { get; init; }

		///<summary>Only supported on the Botvac D7. Name of the zone to clean. Defaults to no zone i.e. complete house cleanup. eg: Kitchen</summary>
		[JsonPropertyName("zone")]
		public string? Zone { get; init; }
	}

	public class NestServices
	{
		private readonly IHaContext _haContext;
		public NestServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Cancel an existing estimated time of arrival window for a Nest structure.</summary>
		public void CancelEta(NestCancelEtaParameters data)
		{
			_haContext.CallService("nest", "cancel_eta", null, data);
		}

		///<summary>Cancel an existing estimated time of arrival window for a Nest structure.</summary>
		///<param name="tripId">Unique ID for the trip. eg: Leave Work</param>
		///<param name="structure">Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</param>
		public void CancelEta(string @tripId, object? @structure = null)
		{
			_haContext.CallService("nest", "cancel_eta", null, new NestCancelEtaParameters{TripId = @tripId, Structure = @structure});
		}

		///<summary>Set the away mode for a Nest structure.</summary>
		public void SetAwayMode(NestSetAwayModeParameters data)
		{
			_haContext.CallService("nest", "set_away_mode", null, data);
		}

		///<summary>Set the away mode for a Nest structure.</summary>
		///<param name="awayMode">New mode to set.</param>
		///<param name="structure">Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</param>
		public void SetAwayMode(object @awayMode, object? @structure = null)
		{
			_haContext.CallService("nest", "set_away_mode", null, new NestSetAwayModeParameters{AwayMode = @awayMode, Structure = @structure});
		}

		///<summary>Set or update the estimated time of arrival window for a Nest structure.</summary>
		public void SetEta(NestSetEtaParameters data)
		{
			_haContext.CallService("nest", "set_eta", null, data);
		}

		///<summary>Set or update the estimated time of arrival window for a Nest structure.</summary>
		///<param name="eta">Estimated time of arrival from now.</param>
		///<param name="etaWindow">Estimated time of arrival window.</param>
		///<param name="tripId">Unique ID for the trip. Default is auto-generated using a timestamp. eg: Leave Work</param>
		///<param name="structure">Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</param>
		public void SetEta(DateTime @eta, DateTime? @etaWindow = null, string? @tripId = null, object? @structure = null)
		{
			_haContext.CallService("nest", "set_eta", null, new NestSetEtaParameters{Eta = @eta, EtaWindow = @etaWindow, TripId = @tripId, Structure = @structure});
		}
	}

	public record NestCancelEtaParameters
	{
		///<summary>Unique ID for the trip. eg: Leave Work</summary>
		[JsonPropertyName("trip_id")]
		public string? TripId { get; init; }

		///<summary>Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</summary>
		[JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public record NestSetAwayModeParameters
	{
		///<summary>New mode to set.</summary>
		[JsonPropertyName("away_mode")]
		public object? AwayMode { get; init; }

		///<summary>Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</summary>
		[JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public record NestSetEtaParameters
	{
		///<summary>Estimated time of arrival from now.</summary>
		[JsonPropertyName("eta")]
		public DateTime? Eta { get; init; }

		///<summary>Estimated time of arrival window.</summary>
		[JsonPropertyName("eta_window")]
		public DateTime? EtaWindow { get; init; }

		///<summary>Unique ID for the trip. Default is auto-generated using a timestamp. eg: Leave Work</summary>
		[JsonPropertyName("trip_id")]
		public string? TripId { get; init; }

		///<summary>Name(s) of structure(s) to change. Defaults to all structures if not specified. eg: Apartment</summary>
		[JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public class NetdaemonServices
	{
		private readonly IHaContext _haContext;
		public NetdaemonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Create an entity</summary>
		public void EntityCreate(NetdaemonEntityCreateParameters data)
		{
			_haContext.CallService("netdaemon", "entity_create", null, data);
		}

		///<summary>Create an entity</summary>
		///<param name="entityId">The entity ID of the entity eg: sensor.awesome</param>
		///<param name="state">The state of the entity eg: Lorem ipsum</param>
		///<param name="icon">The icon for the entity eg: mdi:rocket-launch-outline</param>
		///<param name="unit">The unit of measurement for the entity</param>
		///<param name="options">List of options for a select entity</param>
		///<param name="attributes">The attributes of the entity</param>
		public void EntityCreate(object? @entityId = null, object? @state = null, object? @icon = null, object? @unit = null, object? @options = null, object? @attributes = null)
		{
			_haContext.CallService("netdaemon", "entity_create", null, new NetdaemonEntityCreateParameters{EntityId = @entityId, State = @state, Icon = @icon, Unit = @unit, Options = @options, Attributes = @attributes});
		}

		///<summary>Remove an entity</summary>
		public void EntityRemove(NetdaemonEntityRemoveParameters data)
		{
			_haContext.CallService("netdaemon", "entity_remove", null, data);
		}

		///<summary>Remove an entity</summary>
		///<param name="entityId">The entity ID of the entity eg: sensor.awesome</param>
		public void EntityRemove(object? @entityId = null)
		{
			_haContext.CallService("netdaemon", "entity_remove", null, new NetdaemonEntityRemoveParameters{EntityId = @entityId});
		}

		///<summary>Update an entity</summary>
		public void EntityUpdate(NetdaemonEntityUpdateParameters data)
		{
			_haContext.CallService("netdaemon", "entity_update", null, data);
		}

		///<summary>Update an entity</summary>
		///<param name="entityId">The entity ID of the entity eg: sensor.awesome</param>
		///<param name="state">The state of the entity eg: Lorem ipsum</param>
		///<param name="icon">The icon for the entity eg: mdi:rocket-launch-outline</param>
		///<param name="unit">The unit of measurement for the entity</param>
		///<param name="options">List of options for a select entity</param>
		///<param name="attributes">The attributes of the entity</param>
		public void EntityUpdate(object? @entityId = null, object? @state = null, object? @icon = null, object? @unit = null, object? @options = null, object? @attributes = null)
		{
			_haContext.CallService("netdaemon", "entity_update", null, new NetdaemonEntityUpdateParameters{EntityId = @entityId, State = @state, Icon = @icon, Unit = @unit, Options = @options, Attributes = @attributes});
		}

		///<summary>Register a new service for netdaemon, used by the daemon and not to be used by users</summary>
		public void RegisterService(NetdaemonRegisterServiceParameters data)
		{
			_haContext.CallService("netdaemon", "register_service", null, data);
		}

		///<summary>Register a new service for netdaemon, used by the daemon and not to be used by users</summary>
		///<param name="service">The name of the service to register</param>
		///<param name="class">The class that implements the service call</param>
		///<param name="method">The method to call</param>
		public void RegisterService(object? @service = null, object? @class = null, object? @method = null)
		{
			_haContext.CallService("netdaemon", "register_service", null, new NetdaemonRegisterServiceParameters{Service = @service, Class = @class, Method = @method});
		}

		public void ReloadApps()
		{
			_haContext.CallService("netdaemon", "reload_apps", null);
		}
	}

	public record NetdaemonEntityCreateParameters
	{
		///<summary>The entity ID of the entity eg: sensor.awesome</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>The state of the entity eg: Lorem ipsum</summary>
		[JsonPropertyName("state")]
		public object? State { get; init; }

		///<summary>The icon for the entity eg: mdi:rocket-launch-outline</summary>
		[JsonPropertyName("icon")]
		public object? Icon { get; init; }

		///<summary>The unit of measurement for the entity</summary>
		[JsonPropertyName("unit")]
		public object? Unit { get; init; }

		///<summary>List of options for a select entity</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }

		///<summary>The attributes of the entity</summary>
		[JsonPropertyName("attributes")]
		public object? Attributes { get; init; }
	}

	public record NetdaemonEntityRemoveParameters
	{
		///<summary>The entity ID of the entity eg: sensor.awesome</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }
	}

	public record NetdaemonEntityUpdateParameters
	{
		///<summary>The entity ID of the entity eg: sensor.awesome</summary>
		[JsonPropertyName("entity_id")]
		public object? EntityId { get; init; }

		///<summary>The state of the entity eg: Lorem ipsum</summary>
		[JsonPropertyName("state")]
		public object? State { get; init; }

		///<summary>The icon for the entity eg: mdi:rocket-launch-outline</summary>
		[JsonPropertyName("icon")]
		public object? Icon { get; init; }

		///<summary>The unit of measurement for the entity</summary>
		[JsonPropertyName("unit")]
		public object? Unit { get; init; }

		///<summary>List of options for a select entity</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }

		///<summary>The attributes of the entity</summary>
		[JsonPropertyName("attributes")]
		public object? Attributes { get; init; }
	}

	public record NetdaemonRegisterServiceParameters
	{
		///<summary>The name of the service to register</summary>
		[JsonPropertyName("service")]
		public object? Service { get; init; }

		///<summary>The class that implements the service call</summary>
		[JsonPropertyName("class")]
		public object? Class { get; init; }

		///<summary>The method to call</summary>
		[JsonPropertyName("method")]
		public object? Method { get; init; }
	}

	public class NotifyServices
	{
		private readonly IHaContext _haContext;
		public NotifyServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Sends a notification message using the alexa_media service.</summary>
		public void AlexaMedia(NotifyAlexaMediaParameters data)
		{
			_haContext.CallService("notify", "alexa_media", null, data);
		}

		///<summary>Sends a notification message using the alexa_media service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMedia(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media", null, new NotifyAlexaMediaParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_all_speakers integration.</summary>
		public void AlexaMediaAllSpeakers(NotifyAlexaMediaAllSpeakersParameters data)
		{
			_haContext.CallService("notify", "alexa_media_all_speakers", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_all_speakers integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaAllSpeakers(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_all_speakers", null, new NotifyAlexaMediaAllSpeakersParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_echo_buds integration.</summary>
		public void AlexaMediaAndrewSEchoBuds(NotifyAlexaMediaAndrewSEchoBudsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_echo_buds", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_echo_buds integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaAndrewSEchoBuds(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_echo_buds", null, new NotifyAlexaMediaAndrewSEchoBudsParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_fire_tv integration.</summary>
		public void AlexaMediaAndrewSFireTv(NotifyAlexaMediaAndrewSFireTvParameters data)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_fire_tv", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_fire_tv integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaAndrewSFireTv(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_fire_tv", null, new NotifyAlexaMediaAndrewSFireTvParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_samsung_tv_2020_u integration.</summary>
		public void AlexaMediaAndrewSSamsungTv2020U(NotifyAlexaMediaAndrewSSamsungTv2020UParameters data)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_samsung_tv_2020_u", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_andrew_s_samsung_tv_2020_u integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaAndrewSSamsungTv2020U(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_samsung_tv_2020_u", null, new NotifyAlexaMediaAndrewSSamsungTv2020UParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_bedroom_echo_show integration.</summary>
		public void AlexaMediaBedroomEchoShow(NotifyAlexaMediaBedroomEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_bedroom_echo_show", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_bedroom_echo_show integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaBedroomEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_bedroom_echo_show", null, new NotifyAlexaMediaBedroomEchoShowParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_dining_room_echo_input integration.</summary>
		public void AlexaMediaDiningRoomEchoInput(NotifyAlexaMediaDiningRoomEchoInputParameters data)
		{
			_haContext.CallService("notify", "alexa_media_dining_room_echo_input", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_dining_room_echo_input integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaDiningRoomEchoInput(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_dining_room_echo_input", null, new NotifyAlexaMediaDiningRoomEchoInputParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_downstairs integration.</summary>
		public void AlexaMediaDownstairs(NotifyAlexaMediaDownstairsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_downstairs", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_downstairs integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaDownstairs(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_downstairs", null, new NotifyAlexaMediaDownstairsParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_drawing_room_echo_dot integration.</summary>
		public void AlexaMediaDrawingRoomEchoDot(NotifyAlexaMediaDrawingRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_drawing_room_echo_dot", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_drawing_room_echo_dot integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaDrawingRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_drawing_room_echo_dot", null, new NotifyAlexaMediaDrawingRoomEchoDotParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_dressing_room_echo_dot integration.</summary>
		public void AlexaMediaDressingRoomEchoDot(NotifyAlexaMediaDressingRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_dressing_room_echo_dot", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_dressing_room_echo_dot integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaDressingRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_dressing_room_echo_dot", null, new NotifyAlexaMediaDressingRoomEchoDotParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_guest_room_echo_show integration.</summary>
		public void AlexaMediaGuestRoomEchoShow(NotifyAlexaMediaGuestRoomEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_guest_room_echo_show", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_guest_room_echo_show integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaGuestRoomEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_guest_room_echo_show", null, new NotifyAlexaMediaGuestRoomEchoShowParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_hall_tablet integration.</summary>
		public void AlexaMediaHallTablet(NotifyAlexaMediaHallTabletParameters data)
		{
			_haContext.CallService("notify", "alexa_media_hall_tablet", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_hall_tablet integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaHallTablet(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_hall_tablet", null, new NotifyAlexaMediaHallTabletParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_kitchen_echo_show integration.</summary>
		public void AlexaMediaKitchenEchoShow(NotifyAlexaMediaKitchenEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_kitchen_echo_show", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_kitchen_echo_show integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaKitchenEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_kitchen_echo_show", null, new NotifyAlexaMediaKitchenEchoShowParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_landing_tablet integration.</summary>
		public void AlexaMediaLandingTablet(NotifyAlexaMediaLandingTabletParameters data)
		{
			_haContext.CallService("notify", "alexa_media_landing_tablet", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_landing_tablet integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaLandingTablet(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_landing_tablet", null, new NotifyAlexaMediaLandingTabletParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_last_called integration.</summary>
		public void AlexaMediaLastCalled(NotifyAlexaMediaLastCalledParameters data)
		{
			_haContext.CallService("notify", "alexa_media_last_called", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_last_called integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaLastCalled(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_last_called", null, new NotifyAlexaMediaLastCalledParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_lounge_echo_plus integration.</summary>
		public void AlexaMediaLoungeEchoPlus(NotifyAlexaMediaLoungeEchoPlusParameters data)
		{
			_haContext.CallService("notify", "alexa_media_lounge_echo_plus", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_lounge_echo_plus integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaLoungeEchoPlus(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_lounge_echo_plus", null, new NotifyAlexaMediaLoungeEchoPlusParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_lounge_fire_tv integration.</summary>
		public void AlexaMediaLoungeFireTv(NotifyAlexaMediaLoungeFireTvParameters data)
		{
			_haContext.CallService("notify", "alexa_media_lounge_fire_tv", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_lounge_fire_tv integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaLoungeFireTv(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_lounge_fire_tv", null, new NotifyAlexaMediaLoungeFireTvParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_snug integration.</summary>
		public void AlexaMediaSnug(NotifyAlexaMediaSnugParameters data)
		{
			_haContext.CallService("notify", "alexa_media_snug", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_snug integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaSnug(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_snug", null, new NotifyAlexaMediaSnugParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_snug_echo_input integration.</summary>
		public void AlexaMediaSnugEchoInput(NotifyAlexaMediaSnugEchoInputParameters data)
		{
			_haContext.CallService("notify", "alexa_media_snug_echo_input", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_snug_echo_input integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaSnugEchoInput(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_snug_echo_input", null, new NotifyAlexaMediaSnugEchoInputParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_upstairs integration.</summary>
		public void AlexaMediaUpstairs(NotifyAlexaMediaUpstairsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_upstairs", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_upstairs integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaUpstairs(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_upstairs", null, new NotifyAlexaMediaUpstairsParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the alexa_media_utility_room_echo_dot integration.</summary>
		public void AlexaMediaUtilityRoomEchoDot(NotifyAlexaMediaUtilityRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_utility_room_echo_dot", null, data);
		}

		///<summary>Sends a notification message using the alexa_media_utility_room_echo_dot integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void AlexaMediaUtilityRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_utility_room_echo_dot", null, new NotifyAlexaMediaUtilityRoomEchoDotParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the mobile_app_andy_s_iphone integration.</summary>
		public void MobileAppAndySIphone(NotifyMobileAppAndySIphoneParameters data)
		{
			_haContext.CallService("notify", "mobile_app_andy_s_iphone", null, data);
		}

		///<summary>Sends a notification message using the mobile_app_andy_s_iphone integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void MobileAppAndySIphone(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_andy_s_iphone", null, new NotifyMobileAppAndySIphoneParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the mobile_app_claires_iphone integration.</summary>
		public void MobileAppClairesIphone(NotifyMobileAppClairesIphoneParameters data)
		{
			_haContext.CallService("notify", "mobile_app_claires_iphone", null, data);
		}

		///<summary>Sends a notification message using the mobile_app_claires_iphone integration.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void MobileAppClairesIphone(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_claires_iphone", null, new NotifyMobileAppClairesIphoneParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification message using the notify service.</summary>
		public void Notify(NotifyNotifyParameters data)
		{
			_haContext.CallService("notify", "notify", null, data);
		}

		///<summary>Sends a notification message using the notify service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void Notify(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "notify", null, new NotifyNotifyParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}

		///<summary>Sends a notification that is visible in the front-end.</summary>
		public void PersistentNotification(NotifyPersistentNotificationParameters data)
		{
			_haContext.CallService("notify", "persistent_notification", null, data);
		}

		///<summary>Sends a notification that is visible in the front-end.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		public void PersistentNotification(string @message, string? @title = null)
		{
			_haContext.CallService("notify", "persistent_notification", null, new NotifyPersistentNotificationParameters{Message = @message, Title = @title});
		}

		///<summary>Sends a notification message using the phones service.</summary>
		public void Phones(NotifyPhonesParameters data)
		{
			_haContext.CallService("notify", "phones", null, data);
		}

		///<summary>Sends a notification message using the phones service.</summary>
		///<param name="message">Message body of the notification. eg: The garage door has been open for 10 minutes.</param>
		///<param name="title">Title for your notification. eg: Your Garage Door Friend</param>
		///<param name="target">An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</param>
		///<param name="data">Extended information for notification. Optional depending on the platform. eg: platform specific</param>
		public void Phones(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "phones", null, new NotifyPhonesParameters{Message = @message, Title = @title, Target = @target, Data = @data});
		}
	}

	public record NotifyAlexaMediaParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAllSpeakersParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAndrewSEchoBudsParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAndrewSFireTvParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAndrewSSamsungTv2020UParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaBedroomEchoShowParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDiningRoomEchoInputParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDownstairsParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDrawingRoomEchoDotParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDressingRoomEchoDotParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaGuestRoomEchoShowParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaHallTabletParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaKitchenEchoShowParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLandingTabletParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLastCalledParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLoungeEchoPlusParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLoungeFireTvParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaSnugParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaSnugEchoInputParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaUpstairsParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaUtilityRoomEchoDotParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppAndySIphoneParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppClairesIphoneParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyNotifyParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyPersistentNotificationParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public record NotifyPhonesParameters
	{
		///<summary>Message body of the notification. eg: The garage door has been open for 10 minutes.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Title for your notification. eg: Your Garage Door Friend</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>An array of targets to send the notification to. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("target")]
		public object? Target { get; init; }

		///<summary>Extended information for notification. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public class NumberServices
	{
		private readonly IHaContext _haContext;
		public NumberServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SetValue(ServiceTarget target, NumberSetValueParameters data)
		{
			_haContext.CallService("number", "set_value", target, data);
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public void SetValue(ServiceTarget target, string? @value = null)
		{
			_haContext.CallService("number", "set_value", target, new NumberSetValueParameters{Value = @value});
		}
	}

	public record NumberSetValueParameters
	{
		///<summary>The target value the entity should be set to. eg: 42</summary>
		[JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class OnvifServices
	{
		private readonly IHaContext _haContext;
		public OnvifServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		///<param name="target">The target for this service call</param>
		public void Ptz(ServiceTarget target, OnvifPtzParameters data)
		{
			_haContext.CallService("onvif", "ptz", target, data);
		}

		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="tilt">Tilt direction.</param>
		///<param name="pan">Pan direction.</param>
		///<param name="zoom">Zoom.</param>
		///<param name="distance">Distance coefficient. Sets how much PTZ should be executed in one request.</param>
		///<param name="speed">Speed coefficient. Sets how fast PTZ will be executed.</param>
		///<param name="continuousDuration">Set ContinuousMove delay in seconds before stopping the move</param>
		///<param name="preset">PTZ preset profile token. Sets the preset profile token which is executed with GotoPreset eg: 1</param>
		///<param name="moveMode">PTZ moving mode.</param>
		public void Ptz(ServiceTarget target, object? @tilt = null, object? @pan = null, object? @zoom = null, double? @distance = null, double? @speed = null, double? @continuousDuration = null, string? @preset = null, object? @moveMode = null)
		{
			_haContext.CallService("onvif", "ptz", target, new OnvifPtzParameters{Tilt = @tilt, Pan = @pan, Zoom = @zoom, Distance = @distance, Speed = @speed, ContinuousDuration = @continuousDuration, Preset = @preset, MoveMode = @moveMode});
		}
	}

	public record OnvifPtzParameters
	{
		///<summary>Tilt direction.</summary>
		[JsonPropertyName("tilt")]
		public object? Tilt { get; init; }

		///<summary>Pan direction.</summary>
		[JsonPropertyName("pan")]
		public object? Pan { get; init; }

		///<summary>Zoom.</summary>
		[JsonPropertyName("zoom")]
		public object? Zoom { get; init; }

		///<summary>Distance coefficient. Sets how much PTZ should be executed in one request.</summary>
		[JsonPropertyName("distance")]
		public double? Distance { get; init; }

		///<summary>Speed coefficient. Sets how fast PTZ will be executed.</summary>
		[JsonPropertyName("speed")]
		public double? Speed { get; init; }

		///<summary>Set ContinuousMove delay in seconds before stopping the move</summary>
		[JsonPropertyName("continuous_duration")]
		public double? ContinuousDuration { get; init; }

		///<summary>PTZ preset profile token. Sets the preset profile token which is executed with GotoPreset eg: 1</summary>
		[JsonPropertyName("preset")]
		public string? Preset { get; init; }

		///<summary>PTZ moving mode.</summary>
		[JsonPropertyName("move_mode")]
		public object? MoveMode { get; init; }
	}

	public class PersistentNotificationServices
	{
		private readonly IHaContext _haContext;
		public PersistentNotificationServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Show a notification in the frontend.</summary>
		public void Create(PersistentNotificationCreateParameters data)
		{
			_haContext.CallService("persistent_notification", "create", null, data);
		}

		///<summary>Show a notification in the frontend.</summary>
		///<param name="message">Message body of the notification. [Templates accepted] eg: Please check your configuration.yaml.</param>
		///<param name="title">Optional title for your notification. [Templates accepted] eg: Test notification</param>
		///<param name="notificationId">Target ID of the notification, will replace a notification with the same ID. eg: 1234</param>
		public void Create(string @message, string? @title = null, string? @notificationId = null)
		{
			_haContext.CallService("persistent_notification", "create", null, new PersistentNotificationCreateParameters{Message = @message, Title = @title, NotificationId = @notificationId});
		}

		///<summary>Remove a notification from the frontend.</summary>
		public void Dismiss(PersistentNotificationDismissParameters data)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, data);
		}

		///<summary>Remove a notification from the frontend.</summary>
		///<param name="notificationId">Target ID of the notification, which should be removed. eg: 1234</param>
		public void Dismiss(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, new PersistentNotificationDismissParameters{NotificationId = @notificationId});
		}

		///<summary>Mark a notification read.</summary>
		public void MarkRead(PersistentNotificationMarkReadParameters data)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, data);
		}

		///<summary>Mark a notification read.</summary>
		///<param name="notificationId">Target ID of the notification, which should be mark read. eg: 1234</param>
		public void MarkRead(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, new PersistentNotificationMarkReadParameters{NotificationId = @notificationId});
		}
	}

	public record PersistentNotificationCreateParameters
	{
		///<summary>Message body of the notification. [Templates accepted] eg: Please check your configuration.yaml.</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Optional title for your notification. [Templates accepted] eg: Test notification</summary>
		[JsonPropertyName("title")]
		public string? Title { get; init; }

		///<summary>Target ID of the notification, will replace a notification with the same ID. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationDismissParameters
	{
		///<summary>Target ID of the notification, which should be removed. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationMarkReadParameters
	{
		///<summary>Target ID of the notification, which should be mark read. eg: 1234</summary>
		[JsonPropertyName("notification_id")]
		public string? NotificationId { get; init; }
	}

	public class PersonServices
	{
		private readonly IHaContext _haContext;
		public PersonServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the person configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("person", "reload", null);
		}
	}

	public class RecorderServices
	{
		private readonly IHaContext _haContext;
		public RecorderServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Stop the recording of events and state changes</summary>
		public void Disable()
		{
			_haContext.CallService("recorder", "disable", null);
		}

		///<summary>Start the recording of events and state changes</summary>
		public void Enable()
		{
			_haContext.CallService("recorder", "enable", null);
		}

		///<summary>Start purge task - to clean up old data from your database.</summary>
		public void Purge(RecorderPurgeParameters data)
		{
			_haContext.CallService("recorder", "purge", null, data);
		}

		///<summary>Start purge task - to clean up old data from your database.</summary>
		///<param name="keepDays">Number of history days to keep in database after purge.</param>
		///<param name="repack">Attempt to save disk space by rewriting the entire database file.</param>
		///<param name="applyFilter">Apply entity_id and event_type filter in addition to time based purge.</param>
		public void Purge(long? @keepDays = null, bool? @repack = null, bool? @applyFilter = null)
		{
			_haContext.CallService("recorder", "purge", null, new RecorderPurgeParameters{KeepDays = @keepDays, Repack = @repack, ApplyFilter = @applyFilter});
		}

		///<summary>Start purge task to remove specific entities from your database.</summary>
		///<param name="target">The target for this service call</param>
		public void PurgeEntities(ServiceTarget target, RecorderPurgeEntitiesParameters data)
		{
			_haContext.CallService("recorder", "purge_entities", target, data);
		}

		///<summary>Start purge task to remove specific entities from your database.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="domains">List the domains that need to be removed from the recorder database. eg: sun</param>
		///<param name="entityGlobs">List the glob patterns to select entities for removal from the recorder database. eg: domain*.object_id*</param>
		public void PurgeEntities(ServiceTarget target, object? @domains = null, object? @entityGlobs = null)
		{
			_haContext.CallService("recorder", "purge_entities", target, new RecorderPurgeEntitiesParameters{Domains = @domains, EntityGlobs = @entityGlobs});
		}
	}

	public record RecorderPurgeParameters
	{
		///<summary>Number of history days to keep in database after purge.</summary>
		[JsonPropertyName("keep_days")]
		public long? KeepDays { get; init; }

		///<summary>Attempt to save disk space by rewriting the entire database file.</summary>
		[JsonPropertyName("repack")]
		public bool? Repack { get; init; }

		///<summary>Apply entity_id and event_type filter in addition to time based purge.</summary>
		[JsonPropertyName("apply_filter")]
		public bool? ApplyFilter { get; init; }
	}

	public record RecorderPurgeEntitiesParameters
	{
		///<summary>List the domains that need to be removed from the recorder database. eg: sun</summary>
		[JsonPropertyName("domains")]
		public object? Domains { get; init; }

		///<summary>List the glob patterns to select entities for removal from the recorder database. eg: domain*.object_id*</summary>
		[JsonPropertyName("entity_globs")]
		public object? EntityGlobs { get; init; }
	}

	public class RemoteServices
	{
		private readonly IHaContext _haContext;
		public RemoteServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Deletes a command or a list of commands from the database.</summary>
		///<param name="target">The target for this service call</param>
		public void DeleteCommand(ServiceTarget target, RemoteDeleteCommandParameters data)
		{
			_haContext.CallService("remote", "delete_command", target, data);
		}

		///<summary>Deletes a command or a list of commands from the database.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="device">Name of the device from which commands will be deleted. eg: television</param>
		///<param name="command">A single command or a list of commands to delete. eg: Mute</param>
		public void DeleteCommand(ServiceTarget target, object @command, string? @device = null)
		{
			_haContext.CallService("remote", "delete_command", target, new RemoteDeleteCommandParameters{Device = @device, Command = @command});
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		///<param name="target">The target for this service call</param>
		public void LearnCommand(ServiceTarget target, RemoteLearnCommandParameters data)
		{
			_haContext.CallService("remote", "learn_command", target, data);
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="device">Device ID to learn command from. eg: television</param>
		///<param name="command">A single command or a list of commands to learn. eg: Turn on</param>
		///<param name="commandType">The type of command to be learned.</param>
		///<param name="alternative">If code must be stored as alternative (useful for discrete remotes).</param>
		///<param name="timeout">Timeout for the command to be learned.</param>
		public void LearnCommand(ServiceTarget target, string? @device = null, object? @command = null, object? @commandType = null, bool? @alternative = null, long? @timeout = null)
		{
			_haContext.CallService("remote", "learn_command", target, new RemoteLearnCommandParameters{Device = @device, Command = @command, CommandType = @commandType, Alternative = @alternative, Timeout = @timeout});
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		///<param name="target">The target for this service call</param>
		public void SendCommand(ServiceTarget target, RemoteSendCommandParameters data)
		{
			_haContext.CallService("remote", "send_command", target, data);
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="device">Device ID to send command to. eg: 32756745</param>
		///<param name="command">A single command or a list of commands to send. eg: Play</param>
		///<param name="numRepeats">The number of times you want to repeat the command(s).</param>
		///<param name="delaySecs">The time you want to wait in between repeated commands.</param>
		///<param name="holdSecs">The time you want to have it held before the release is send.</param>
		public void SendCommand(ServiceTarget target, object @command, string? @device = null, long? @numRepeats = null, double? @delaySecs = null, double? @holdSecs = null)
		{
			_haContext.CallService("remote", "send_command", target, new RemoteSendCommandParameters{Device = @device, Command = @command, NumRepeats = @numRepeats, DelaySecs = @delaySecs, HoldSecs = @holdSecs});
		}

		///<summary>Toggles a device.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("remote", "toggle", target);
		}

		///<summary>Sends the Power Off Command.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("remote", "turn_off", target);
		}

		///<summary>Sends the Power On Command.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, RemoteTurnOnParameters data)
		{
			_haContext.CallService("remote", "turn_on", target, data);
		}

		///<summary>Sends the Power On Command.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="activity">Activity ID or Activity Name to start. eg: BedroomTV</param>
		public void TurnOn(ServiceTarget target, string? @activity = null)
		{
			_haContext.CallService("remote", "turn_on", target, new RemoteTurnOnParameters{Activity = @activity});
		}
	}

	public record RemoteDeleteCommandParameters
	{
		///<summary>Name of the device from which commands will be deleted. eg: television</summary>
		[JsonPropertyName("device")]
		public string? Device { get; init; }

		///<summary>A single command or a list of commands to delete. eg: Mute</summary>
		[JsonPropertyName("command")]
		public object? Command { get; init; }
	}

	public record RemoteLearnCommandParameters
	{
		///<summary>Device ID to learn command from. eg: television</summary>
		[JsonPropertyName("device")]
		public string? Device { get; init; }

		///<summary>A single command or a list of commands to learn. eg: Turn on</summary>
		[JsonPropertyName("command")]
		public object? Command { get; init; }

		///<summary>The type of command to be learned.</summary>
		[JsonPropertyName("command_type")]
		public object? CommandType { get; init; }

		///<summary>If code must be stored as alternative (useful for discrete remotes).</summary>
		[JsonPropertyName("alternative")]
		public bool? Alternative { get; init; }

		///<summary>Timeout for the command to be learned.</summary>
		[JsonPropertyName("timeout")]
		public long? Timeout { get; init; }
	}

	public record RemoteSendCommandParameters
	{
		///<summary>Device ID to send command to. eg: 32756745</summary>
		[JsonPropertyName("device")]
		public string? Device { get; init; }

		///<summary>A single command or a list of commands to send. eg: Play</summary>
		[JsonPropertyName("command")]
		public object? Command { get; init; }

		///<summary>The number of times you want to repeat the command(s).</summary>
		[JsonPropertyName("num_repeats")]
		public long? NumRepeats { get; init; }

		///<summary>The time you want to wait in between repeated commands.</summary>
		[JsonPropertyName("delay_secs")]
		public double? DelaySecs { get; init; }

		///<summary>The time you want to have it held before the release is send.</summary>
		[JsonPropertyName("hold_secs")]
		public double? HoldSecs { get; init; }
	}

	public record RemoteTurnOnParameters
	{
		///<summary>Activity ID or Activity Name to start. eg: BedroomTV</summary>
		[JsonPropertyName("activity")]
		public string? Activity { get; init; }
	}

	public class SceneServices
	{
		private readonly IHaContext _haContext;
		public SceneServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Activate a scene with configuration.</summary>
		public void Apply(SceneApplyParameters data)
		{
			_haContext.CallService("scene", "apply", null, data);
		}

		///<summary>Activate a scene with configuration.</summary>
		///<param name="entities">The entities and the state that they need to be. eg: {"light.kitchen":"on","light.ceiling":{"state":"on","brightness":80}}</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public void Apply(object @entities, long? @transition = null)
		{
			_haContext.CallService("scene", "apply", null, new SceneApplyParameters{Entities = @entities, Transition = @transition});
		}

		///<summary>Creates a new scene.</summary>
		public void Create(SceneCreateParameters data)
		{
			_haContext.CallService("scene", "create", null, data);
		}

		///<summary>Creates a new scene.</summary>
		///<param name="sceneId">The entity_id of the new scene. eg: all_lights</param>
		///<param name="entities">The entities to control with the scene. eg: {"light.tv_back_light":"on","light.ceiling":{"state":"on","brightness":200}}</param>
		///<param name="snapshotEntities">The entities of which a snapshot is to be taken eg: ["light.ceiling","light.kitchen"]</param>
		public void Create(string @sceneId, object? @entities = null, object? @snapshotEntities = null)
		{
			_haContext.CallService("scene", "create", null, new SceneCreateParameters{SceneId = @sceneId, Entities = @entities, SnapshotEntities = @snapshotEntities});
		}

		///<summary>Reload the scene configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("scene", "reload", null);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, SceneTurnOnParameters data)
		{
			_haContext.CallService("scene", "turn_on", target, data);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public void TurnOn(ServiceTarget target, long? @transition = null)
		{
			_haContext.CallService("scene", "turn_on", target, new SceneTurnOnParameters{Transition = @transition});
		}
	}

	public record SceneApplyParameters
	{
		///<summary>The entities and the state that they need to be. eg: {"light.kitchen":"on","light.ceiling":{"state":"on","brightness":80}}</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>Transition duration it takes to bring devices to the state defined in the scene.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public record SceneCreateParameters
	{
		///<summary>The entity_id of the new scene. eg: all_lights</summary>
		[JsonPropertyName("scene_id")]
		public string? SceneId { get; init; }

		///<summary>The entities to control with the scene. eg: {"light.tv_back_light":"on","light.ceiling":{"state":"on","brightness":200}}</summary>
		[JsonPropertyName("entities")]
		public object? Entities { get; init; }

		///<summary>The entities of which a snapshot is to be taken eg: ["light.ceiling","light.kitchen"]</summary>
		[JsonPropertyName("snapshot_entities")]
		public object? SnapshotEntities { get; init; }
	}

	public record SceneTurnOnParameters
	{
		///<summary>Transition duration it takes to bring devices to the state defined in the scene.</summary>
		[JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public class ScriptServices
	{
		private readonly IHaContext _haContext;
		public ScriptServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void DoorbellAlexa()
		{
			_haContext.CallService("script", "doorbell_alexa", null);
		}

		public void EntityControllerReset()
		{
			_haContext.CallService("script", "entity_controller_reset", null);
		}

		public void FeedCats()
		{
			_haContext.CallService("script", "feed_cats", null);
		}

		public void LightEffectContinuous()
		{
			_haContext.CallService("script", "light_effect_continuous", null);
		}

		public void LightEffectTimed()
		{
			_haContext.CallService("script", "light_effect_timed", null);
		}

		public void NotifyAlexaEverywhere()
		{
			_haContext.CallService("script", "notify_alexa_everywhere", null);
		}

		public void NotifyAll()
		{
			_haContext.CallService("script", "notify_all", null);
		}

		public void NotifyPushbullet()
		{
			_haContext.CallService("script", "notify_pushbullet", null);
		}

		///<summary>Reload all the available scripts</summary>
		public void Reload()
		{
			_haContext.CallService("script", "reload", null);
		}

		public void RoomControllerReset()
		{
			_haContext.CallService("script", "room_controller_reset", null);
		}

		///<summary>Toggle script</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("script", "toggle", target);
		}

		///<summary>Turn off script</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("script", "turn_off", target);
		}

		///<summary>Turn on script</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("script", "turn_on", target);
		}
	}

	public class SelectServices
	{
		private readonly IHaContext _haContext;
		public SelectServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		public void SelectOption(ServiceTarget target, SelectSelectOptionParameters data)
		{
			_haContext.CallService("select", "select_option", target, data);
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public void SelectOption(ServiceTarget target, string @option)
		{
			_haContext.CallService("select", "select_option", target, new SelectSelectOptionParameters{Option = @option});
		}
	}

	public record SelectSelectOptionParameters
	{
		///<summary>Option to be selected. eg: "Item A"</summary>
		[JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public class ShoppingListServices
	{
		private readonly IHaContext _haContext;
		public ShoppingListServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Add an item to the shopping list.</summary>
		public void AddItem(ShoppingListAddItemParameters data)
		{
			_haContext.CallService("shopping_list", "add_item", null, data);
		}

		///<summary>Add an item to the shopping list.</summary>
		///<param name="name">The name of the item to add. eg: Beer</param>
		public void AddItem(string @name)
		{
			_haContext.CallService("shopping_list", "add_item", null, new ShoppingListAddItemParameters{Name = @name});
		}

		///<summary>Clear completed items from the shopping list.</summary>
		public void ClearCompletedItems()
		{
			_haContext.CallService("shopping_list", "clear_completed_items", null);
		}

		///<summary>Marks all items as completed in the shopping list. It does not remove the items.</summary>
		public void CompleteAll()
		{
			_haContext.CallService("shopping_list", "complete_all", null);
		}

		///<summary>Mark an item as completed in the shopping list.</summary>
		public void CompleteItem(ShoppingListCompleteItemParameters data)
		{
			_haContext.CallService("shopping_list", "complete_item", null, data);
		}

		///<summary>Mark an item as completed in the shopping list.</summary>
		///<param name="name">The name of the item to mark as completed (without removing). eg: Beer</param>
		public void CompleteItem(string @name)
		{
			_haContext.CallService("shopping_list", "complete_item", null, new ShoppingListCompleteItemParameters{Name = @name});
		}

		///<summary>Marks all items as incomplete in the shopping list.</summary>
		public void IncompleteAll()
		{
			_haContext.CallService("shopping_list", "incomplete_all", null);
		}

		///<summary>Marks an item as incomplete in the shopping list.</summary>
		public void IncompleteItem(ShoppingListIncompleteItemParameters data)
		{
			_haContext.CallService("shopping_list", "incomplete_item", null, data);
		}

		///<summary>Marks an item as incomplete in the shopping list.</summary>
		///<param name="name">The name of the item to mark as incomplete. eg: Beer</param>
		public void IncompleteItem(string @name)
		{
			_haContext.CallService("shopping_list", "incomplete_item", null, new ShoppingListIncompleteItemParameters{Name = @name});
		}
	}

	public record ShoppingListAddItemParameters
	{
		///<summary>The name of the item to add. eg: Beer</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record ShoppingListCompleteItemParameters
	{
		///<summary>The name of the item to mark as completed (without removing). eg: Beer</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record ShoppingListIncompleteItemParameters
	{
		///<summary>The name of the item to mark as incomplete. eg: Beer</summary>
		[JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public class SirenServices
	{
		private readonly IHaContext _haContext;
		public SirenServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles a siren.</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("siren", "toggle", target);
		}

		///<summary>Turn siren off.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("siren", "turn_off", target);
		}

		///<summary>Turn siren on.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target, SirenTurnOnParameters data)
		{
			_haContext.CallService("siren", "turn_on", target, data);
		}

		///<summary>Turn siren on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="tone">The tone to emit when turning the siren on. When `available_tones` property is a map, either the key or the value can be used. Must be supported by the integration. eg: fire</param>
		///<param name="volumeLevel">The volume level of the noise to emit when turning the siren on. Must be supported by the integration. eg: 0.5</param>
		///<param name="duration">The duration in seconds of the noise to emit when turning the siren on. Must be supported by the integration. eg: 15</param>
		public void TurnOn(ServiceTarget target, string? @tone = null, double? @volumeLevel = null, string? @duration = null)
		{
			_haContext.CallService("siren", "turn_on", target, new SirenTurnOnParameters{Tone = @tone, VolumeLevel = @volumeLevel, Duration = @duration});
		}
	}

	public record SirenTurnOnParameters
	{
		///<summary>The tone to emit when turning the siren on. When `available_tones` property is a map, either the key or the value can be used. Must be supported by the integration. eg: fire</summary>
		[JsonPropertyName("tone")]
		public string? Tone { get; init; }

		///<summary>The volume level of the noise to emit when turning the siren on. Must be supported by the integration. eg: 0.5</summary>
		[JsonPropertyName("volume_level")]
		public double? VolumeLevel { get; init; }

		///<summary>The duration in seconds of the noise to emit when turning the siren on. Must be supported by the integration. eg: 15</summary>
		[JsonPropertyName("duration")]
		public string? Duration { get; init; }
	}

	public class SpeedtestdotnetServices
	{
		private readonly IHaContext _haContext;
		public SpeedtestdotnetServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Immediately execute a speed test with Speedtest.net</summary>
		public void Speedtest()
		{
			_haContext.CallService("speedtestdotnet", "speedtest", null);
		}
	}

	public class SpotcastServices
	{
		private readonly IHaContext _haContext;
		public SpotcastServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Starts spotify playback on chromecast devices</summary>
		public void Start(SpotcastStartParameters data)
		{
			_haContext.CallService("spotcast", "start", null, data);
		}

		///<summary>Starts spotify playback on chromecast devices</summary>
		///<param name="deviceName">The friendly name of the chromecast or spotify connect device. First checks spotify device list for name (not used together with entity_id and spotify_device_id). eg: Livingroom</param>
		///<param name="spotifyDeviceId">Advanced users only. The spotify device id (not used together with entity_id or device_name). eg: 4363634563457346xcyvydgf3qwa</param>
		///<param name="entityId">The entity_id of the chromecast mediaplayer. Friendly name MUST match the spotify connect device name (not used together with device_name and spotify_device_id). eg: media_player.vardagsrum</param>
		///<param name="uri">Supported Spotify URI as string. None or empty uri will transfer the current/last playback (see parameter force_playback). eg: spotify:playlist:37i9dQZF1DX3yvAYDslnv8</param>
		///<param name="category">A category to fetch playlist from. See https://developer.spotify.com/console/get-browse-categories/ for a list of categories</param>
		///<param name="country">Country code to use with category. See https://spotipy.readthedocs.io/en/2.19.0/#spotipy.client.Spotify.country_codes for list of available codes</param>
		///<param name="limit">Limit of playlist to fetch in a given category. Default 20</param>
		///<param name="search">A Search request to the spotify API. Will play the most relevant search result.</param>
		///<param name="account">Optionally starts Spotify using an alternative account specified in config. eg: my_wifes</param>
		///<param name="forcePlayback">In case of transfering playback: If true starts playing the user's last playback even if nothing is currently playing. eg: True</param>
		///<param name="randomSong">Starts the playback at a random position in the playlist or album. eg: True</param>
		///<param name="repeat">Set repeat mode for playback. eg: track</param>
		///<param name="shuffle">Set shuffle mode for playback. eg: True</param>
		///<param name="offset">Set offset mode for playback. 0 is the first song. eg: 1</param>
		///<param name="startVolume">Set the volume for playback in percentage. eg: 50</param>
		///<param name="ignoreFullyPlayed">Set to ignore or not already played episodes in a podcast playlist eg: True</param>
		public void Start(string? @deviceName = null, string? @spotifyDeviceId = null, string? @entityId = null, string? @uri = null, string? @category = null, string? @country = null, long? @limit = null, string? @search = null, string? @account = null, bool? @forcePlayback = null, bool? @randomSong = null, object? @repeat = null, bool? @shuffle = null, long? @offset = null, long? @startVolume = null, bool? @ignoreFullyPlayed = null)
		{
			_haContext.CallService("spotcast", "start", null, new SpotcastStartParameters{DeviceName = @deviceName, SpotifyDeviceId = @spotifyDeviceId, EntityId = @entityId, Uri = @uri, Category = @category, Country = @country, Limit = @limit, Search = @search, Account = @account, ForcePlayback = @forcePlayback, RandomSong = @randomSong, Repeat = @repeat, Shuffle = @shuffle, Offset = @offset, StartVolume = @startVolume, IgnoreFullyPlayed = @ignoreFullyPlayed});
		}
	}

	public record SpotcastStartParameters
	{
		///<summary>The friendly name of the chromecast or spotify connect device. First checks spotify device list for name (not used together with entity_id and spotify_device_id). eg: Livingroom</summary>
		[JsonPropertyName("device_name")]
		public string? DeviceName { get; init; }

		///<summary>Advanced users only. The spotify device id (not used together with entity_id or device_name). eg: 4363634563457346xcyvydgf3qwa</summary>
		[JsonPropertyName("spotify_device_id")]
		public string? SpotifyDeviceId { get; init; }

		///<summary>The entity_id of the chromecast mediaplayer. Friendly name MUST match the spotify connect device name (not used together with device_name and spotify_device_id). eg: media_player.vardagsrum</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Supported Spotify URI as string. None or empty uri will transfer the current/last playback (see parameter force_playback). eg: spotify:playlist:37i9dQZF1DX3yvAYDslnv8</summary>
		[JsonPropertyName("uri")]
		public string? Uri { get; init; }

		///<summary>A category to fetch playlist from. See https://developer.spotify.com/console/get-browse-categories/ for a list of categories</summary>
		[JsonPropertyName("category")]
		public string? Category { get; init; }

		///<summary>Country code to use with category. See https://spotipy.readthedocs.io/en/2.19.0/#spotipy.client.Spotify.country_codes for list of available codes</summary>
		[JsonPropertyName("country")]
		public string? Country { get; init; }

		///<summary>Limit of playlist to fetch in a given category. Default 20</summary>
		[JsonPropertyName("limit")]
		public long? Limit { get; init; }

		///<summary>A Search request to the spotify API. Will play the most relevant search result.</summary>
		[JsonPropertyName("search")]
		public string? Search { get; init; }

		///<summary>Optionally starts Spotify using an alternative account specified in config. eg: my_wifes</summary>
		[JsonPropertyName("account")]
		public string? Account { get; init; }

		///<summary>In case of transfering playback: If true starts playing the user's last playback even if nothing is currently playing. eg: True</summary>
		[JsonPropertyName("force_playback")]
		public bool? ForcePlayback { get; init; }

		///<summary>Starts the playback at a random position in the playlist or album. eg: True</summary>
		[JsonPropertyName("random_song")]
		public bool? RandomSong { get; init; }

		///<summary>Set repeat mode for playback. eg: track</summary>
		[JsonPropertyName("repeat")]
		public object? Repeat { get; init; }

		///<summary>Set shuffle mode for playback. eg: True</summary>
		[JsonPropertyName("shuffle")]
		public bool? Shuffle { get; init; }

		///<summary>Set offset mode for playback. 0 is the first song. eg: 1</summary>
		[JsonPropertyName("offset")]
		public long? Offset { get; init; }

		///<summary>Set the volume for playback in percentage. eg: 50</summary>
		[JsonPropertyName("start_volume")]
		public long? StartVolume { get; init; }

		///<summary>Set to ignore or not already played episodes in a podcast playlist eg: True</summary>
		[JsonPropertyName("ignore_fully_played")]
		public bool? IgnoreFullyPlayed { get; init; }
	}

	public class SqueezeboxServices
	{
		private readonly IHaContext _haContext;
		public SqueezeboxServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		///<param name="target">The target for this service call</param>
		public void CallMethod(ServiceTarget target, SqueezeboxCallMethodParameters data)
		{
			_haContext.CallService("squeezebox", "call_method", target, data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: playlist</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["loadtracks", "album.titlesearch=Revolver"]</param>
		public void CallMethod(ServiceTarget target, string @command, object? @parameters = null)
		{
			_haContext.CallService("squeezebox", "call_method", target, new SqueezeboxCallMethodParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		///<param name="target">The target for this service call</param>
		public void CallQuery(ServiceTarget target, SqueezeboxCallQueryParameters data)
		{
			_haContext.CallService("squeezebox", "call_query", target, data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: albums</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["0", "20", "search:Revolver"]</param>
		public void CallQuery(ServiceTarget target, string @command, object? @parameters = null)
		{
			_haContext.CallService("squeezebox", "call_query", target, new SqueezeboxCallQueryParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		///<param name="target">The target for this service call</param>
		public void Sync(ServiceTarget target, SqueezeboxSyncParameters data)
		{
			_haContext.CallService("squeezebox", "sync", target, data);
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		///<param name="target">The target for this service call</param>
		///<param name="otherPlayer">Name of the other Squeezebox player to link. eg: media_player.living_room</param>
		public void Sync(ServiceTarget target, string @otherPlayer)
		{
			_haContext.CallService("squeezebox", "sync", target, new SqueezeboxSyncParameters{OtherPlayer = @otherPlayer});
		}

		///<summary>Remove this player from its sync group.</summary>
		///<param name="target">The target for this service call</param>
		public void Unsync(ServiceTarget target)
		{
			_haContext.CallService("squeezebox", "unsync", target);
		}
	}

	public record SqueezeboxCallMethodParameters
	{
		///<summary>Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: playlist</summary>
		[JsonPropertyName("command")]
		public string? Command { get; init; }

		///<summary>Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["loadtracks", "album.titlesearch=Revolver"]</summary>
		[JsonPropertyName("parameters")]
		public object? Parameters { get; init; }
	}

	public record SqueezeboxCallQueryParameters
	{
		///<summary>Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: albums</summary>
		[JsonPropertyName("command")]
		public string? Command { get; init; }

		///<summary>Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["0", "20", "search:Revolver"]</summary>
		[JsonPropertyName("parameters")]
		public object? Parameters { get; init; }
	}

	public record SqueezeboxSyncParameters
	{
		///<summary>Name of the other Squeezebox player to link. eg: media_player.living_room</summary>
		[JsonPropertyName("other_player")]
		public string? OtherPlayer { get; init; }
	}

	public class SwitchServices
	{
		private readonly IHaContext _haContext;
		public SwitchServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Toggles a switch state</summary>
		///<param name="target">The target for this service call</param>
		public void Toggle(ServiceTarget target)
		{
			_haContext.CallService("switch", "toggle", target);
		}

		///<summary>Turn a switch off</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_off", target);
		}

		///<summary>Turn a switch on</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_on", target);
		}
	}

	public class SystemLogServices
	{
		private readonly IHaContext _haContext;
		public SystemLogServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Clear all log entries.</summary>
		public void Clear()
		{
			_haContext.CallService("system_log", "clear", null);
		}

		///<summary>Write log entry.</summary>
		public void Write(SystemLogWriteParameters data)
		{
			_haContext.CallService("system_log", "write", null, data);
		}

		///<summary>Write log entry.</summary>
		///<param name="message">Message to log. eg: Something went wrong</param>
		///<param name="level">Log level.</param>
		///<param name="logger">Logger name under which to log the message. Defaults to 'system_log.external'. eg: mycomponent.myplatform</param>
		public void Write(string @message, object? @level = null, string? @logger = null)
		{
			_haContext.CallService("system_log", "write", null, new SystemLogWriteParameters{Message = @message, Level = @level, Logger = @logger});
		}
	}

	public record SystemLogWriteParameters
	{
		///<summary>Message to log. eg: Something went wrong</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Log level.</summary>
		[JsonPropertyName("level")]
		public object? Level { get; init; }

		///<summary>Logger name under which to log the message. Defaults to 'system_log.external'. eg: mycomponent.myplatform</summary>
		[JsonPropertyName("logger")]
		public string? Logger { get; init; }
	}

	public class TemplateServices
	{
		private readonly IHaContext _haContext;
		public TemplateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload all template entities.</summary>
		public void Reload()
		{
			_haContext.CallService("template", "reload", null);
		}
	}

	public class TimerServices
	{
		private readonly IHaContext _haContext;
		public TimerServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Cancel a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Cancel(ServiceTarget target)
		{
			_haContext.CallService("timer", "cancel", target);
		}

		///<summary>Finish a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Finish(ServiceTarget target)
		{
			_haContext.CallService("timer", "finish", target);
		}

		///<summary>Pause a timer.</summary>
		///<param name="target">The target for this service call</param>
		public void Pause(ServiceTarget target)
		{
			_haContext.CallService("timer", "pause", target);
		}

		public void Reload()
		{
			_haContext.CallService("timer", "reload", null);
		}

		///<summary>Start a timer</summary>
		///<param name="target">The target for this service call</param>
		public void Start(ServiceTarget target, TimerStartParameters data)
		{
			_haContext.CallService("timer", "start", target, data);
		}

		///<summary>Start a timer</summary>
		///<param name="target">The target for this service call</param>
		///<param name="duration">Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</param>
		public void Start(ServiceTarget target, string? @duration = null)
		{
			_haContext.CallService("timer", "start", target, new TimerStartParameters{Duration = @duration});
		}
	}

	public record TimerStartParameters
	{
		///<summary>Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</summary>
		[JsonPropertyName("duration")]
		public string? Duration { get; init; }
	}

	public class TtsServices
	{
		private readonly IHaContext _haContext;
		public TtsServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Remove all text-to-speech cache files and RAM cache.</summary>
		public void ClearCache()
		{
			_haContext.CallService("tts", "clear_cache", null);
		}

		///<summary>Say something using text-to-speech on a media player with cloud.</summary>
		public void CloudSay(TtsCloudSayParameters data)
		{
			_haContext.CallService("tts", "cloud_say", null, data);
		}

		///<summary>Say something using text-to-speech on a media player with cloud.</summary>
		///<param name="entityId">Name(s) of media player entities.</param>
		///<param name="message">Text to speak on devices. eg: My name is hanna</param>
		///<param name="cache">Control file cache of this message.</param>
		///<param name="language">Language to use for speech generation. eg: ru</param>
		///<param name="options">A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</param>
		public void CloudSay(string @entityId, string @message, bool? @cache = null, string? @language = null, object? @options = null)
		{
			_haContext.CallService("tts", "cloud_say", null, new TtsCloudSayParameters{EntityId = @entityId, Message = @message, Cache = @cache, Language = @language, Options = @options});
		}
	}

	public record TtsCloudSayParameters
	{
		///<summary>Name(s) of media player entities.</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>Text to speak on devices. eg: My name is hanna</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Control file cache of this message.</summary>
		[JsonPropertyName("cache")]
		public bool? Cache { get; init; }

		///<summary>Language to use for speech generation. eg: ru</summary>
		[JsonPropertyName("language")]
		public string? Language { get; init; }

		///<summary>A dictionary containing platform-specific options. Optional depending on the platform. eg: platform specific</summary>
		[JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class UnifiServices
	{
		private readonly IHaContext _haContext;
		public UnifiServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Try to get wireless client to reconnect to UniFi Network</summary>
		public void ReconnectClient(UnifiReconnectClientParameters data)
		{
			_haContext.CallService("unifi", "reconnect_client", null, data);
		}

		///<summary>Try to get wireless client to reconnect to UniFi Network</summary>
		///<param name="deviceId">Try reconnect client to wireless network</param>
		public void ReconnectClient(string @deviceId)
		{
			_haContext.CallService("unifi", "reconnect_client", null, new UnifiReconnectClientParameters{DeviceId = @deviceId});
		}

		///<summary>Clean up clients that has only been associated with the controller for a short period of time.</summary>
		public void RemoveClients()
		{
			_haContext.CallService("unifi", "remove_clients", null);
		}
	}

	public record UnifiReconnectClientParameters
	{
		///<summary>Try reconnect client to wireless network</summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; init; }
	}

	public class UnifiprotectServices
	{
		private readonly IHaContext _haContext;
		public UnifiprotectServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Adds a new custom message for Doorbells.</summary>
		public void AddDoorbellText(UnifiprotectAddDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "add_doorbell_text", null, data);
		}

		///<summary>Adds a new custom message for Doorbells.</summary>
		///<param name="deviceId">Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</param>
		///<param name="message">New custom message to add for Doorbells. Must be less than 30 characters. eg: Come In</param>
		public void AddDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "add_doorbell_text", null, new UnifiprotectAddDoorbellTextParameters{DeviceId = @deviceId, Message = @message});
		}

		///<summary>Removes an existing message for Doorbells.</summary>
		public void RemoveDoorbellText(UnifiprotectRemoveDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "remove_doorbell_text", null, data);
		}

		///<summary>Removes an existing message for Doorbells.</summary>
		///<param name="deviceId">Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</param>
		///<param name="message">Existing custom message to remove for Doorbells. eg: Go Away!</param>
		public void RemoveDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "remove_doorbell_text", null, new UnifiprotectRemoveDoorbellTextParameters{DeviceId = @deviceId, Message = @message});
		}

		///<summary>Use to set the paired doorbell(s) with a smart chime. </summary>
		public void SetChimePairedDoorbells(UnifiprotectSetChimePairedDoorbellsParameters data)
		{
			_haContext.CallService("unifiprotect", "set_chime_paired_doorbells", null, data);
		}

		///<summary>Use to set the paired doorbell(s) with a smart chime. </summary>
		///<param name="deviceId">The Chimes to link to the doorbells to</param>
		///<param name="doorbells">The Doorbells to link to the chime eg: binary_sensor.front_doorbell_doorbell</param>
		public void SetChimePairedDoorbells(string @deviceId, string? @doorbells = null)
		{
			_haContext.CallService("unifiprotect", "set_chime_paired_doorbells", null, new UnifiprotectSetChimePairedDoorbellsParameters{DeviceId = @deviceId, Doorbells = @doorbells});
		}

		///<summary>Sets the default doorbell message. This will be the message that is automatically selected when a message "expires".</summary>
		public void SetDefaultDoorbellText(UnifiprotectSetDefaultDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "set_default_doorbell_text", null, data);
		}

		///<summary>Sets the default doorbell message. This will be the message that is automatically selected when a message "expires".</summary>
		///<param name="deviceId">Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</param>
		///<param name="message">The default message for your Doorbell. Must be less than 30 characters. eg: Welcome!</param>
		public void SetDefaultDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "set_default_doorbell_text", null, new UnifiprotectSetDefaultDoorbellTextParameters{DeviceId = @deviceId, Message = @message});
		}

		///<summary>Use to dynamically set the message on a Doorbell LCD screen. This service should only be used to set dynamic messages (i.e. setting the current outdoor temperature on your Doorbell). Static messages should still be set using the Select entity and can be added/removed using the add_doorbell_text/remove_doorbell_text services. </summary>
		public void SetDoorbellMessage(UnifiprotectSetDoorbellMessageParameters data)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_message", null, data);
		}

		///<summary>Use to dynamically set the message on a Doorbell LCD screen. This service should only be used to set dynamic messages (i.e. setting the current outdoor temperature on your Doorbell). Static messages should still be set using the Select entity and can be added/removed using the add_doorbell_text/remove_doorbell_text services. </summary>
		///<param name="entityId">The Doorbell Text select entity for your Doorbell. eg: select.front_doorbell_camera_doorbell_text</param>
		///<param name="message">The message you would like to display on the LCD screen of your Doorbell. Must be less than 30 characters. eg: Welcome | 09:23 | 25°C</param>
		///<param name="duration">Number of minutes to display the message for before returning to the default message. The default is to not expire. eg: 5</param>
		public void SetDoorbellMessage(string @entityId, string @message, long? @duration = null)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_message", null, new UnifiprotectSetDoorbellMessageParameters{EntityId = @entityId, Message = @message, Duration = @duration});
		}
	}

	public record UnifiprotectAddDoorbellTextParameters
	{
		///<summary>Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; init; }

		///<summary>New custom message to add for Doorbells. Must be less than 30 characters. eg: Come In</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectRemoveDoorbellTextParameters
	{
		///<summary>Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; init; }

		///<summary>Existing custom message to remove for Doorbells. eg: Go Away!</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectSetChimePairedDoorbellsParameters
	{
		///<summary>The Chimes to link to the doorbells to</summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; init; }

		///<summary>The Doorbells to link to the chime eg: binary_sensor.front_doorbell_doorbell</summary>
		[JsonPropertyName("doorbells")]
		public string? Doorbells { get; init; }
	}

	public record UnifiprotectSetDefaultDoorbellTextParameters
	{
		///<summary>Any device from the UniFi Protect instance you want to change. In case you have multiple Protect Instances.</summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; init; }

		///<summary>The default message for your Doorbell. Must be less than 30 characters. eg: Welcome!</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectSetDoorbellMessageParameters
	{
		///<summary>The Doorbell Text select entity for your Doorbell. eg: select.front_doorbell_camera_doorbell_text</summary>
		[JsonPropertyName("entity_id")]
		public string? EntityId { get; init; }

		///<summary>The message you would like to display on the LCD screen of your Doorbell. Must be less than 30 characters. eg: Welcome | 09:23 | 25°C</summary>
		[JsonPropertyName("message")]
		public string? Message { get; init; }

		///<summary>Number of minutes to display the message for before returning to the default message. The default is to not expire. eg: 5</summary>
		[JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public class UpdateServices
	{
		private readonly IHaContext _haContext;
		public UpdateServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Removes the skipped version marker from an update.</summary>
		///<param name="target">The target for this service call</param>
		public void ClearSkipped(ServiceTarget target)
		{
			_haContext.CallService("update", "clear_skipped", target);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The target for this service call</param>
		public void Install(ServiceTarget target, UpdateInstallParameters data)
		{
			_haContext.CallService("update", "install", target, data);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The target for this service call</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public void Install(ServiceTarget target, string? @version = null, bool? @backup = null)
		{
			_haContext.CallService("update", "install", target, new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Mark currently available update as skipped.</summary>
		///<param name="target">The target for this service call</param>
		public void Skip(ServiceTarget target)
		{
			_haContext.CallService("update", "skip", target);
		}
	}

	public record UpdateInstallParameters
	{
		///<summary>Version to install, if omitted, the latest version will be installed. eg: 1.0.0</summary>
		[JsonPropertyName("version")]
		public string? Version { get; init; }

		///<summary>Backup before installing the update, if supported by the integration.</summary>
		[JsonPropertyName("backup")]
		public bool? Backup { get; init; }
	}

	public class VacuumServices
	{
		private readonly IHaContext _haContext;
		public VacuumServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Tell the vacuum cleaner to do a spot clean-up.</summary>
		///<param name="target">The target for this service call</param>
		public void CleanSpot(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "clean_spot", target);
		}

		///<summary>Locate the vacuum cleaner robot.</summary>
		///<param name="target">The target for this service call</param>
		public void Locate(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "locate", target);
		}

		///<summary>Pause the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Pause(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "pause", target);
		}

		///<summary>Tell the vacuum cleaner to return to its dock.</summary>
		///<param name="target">The target for this service call</param>
		public void ReturnToBase(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "return_to_base", target);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		public void SendCommand(ServiceTarget target, VacuumSendCommandParameters data)
		{
			_haContext.CallService("vacuum", "send_command", target, data);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="command">Command to execute. eg: set_dnd_timer</param>
		///<param name="params">Parameters for the command. eg: { "key": "value" }</param>
		public void SendCommand(ServiceTarget target, string @command, object? @params = null)
		{
			_haContext.CallService("vacuum", "send_command", target, new VacuumSendCommandParameters{Command = @command, Params = @params});
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		public void SetFanSpeed(ServiceTarget target, VacuumSetFanSpeedParameters data)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, data);
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="fanSpeed">Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</param>
		public void SetFanSpeed(ServiceTarget target, string @fanSpeed)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, new VacuumSetFanSpeedParameters{FanSpeed = @fanSpeed});
		}

		///<summary>Start or resume the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Start(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start", target);
		}

		///<summary>Start, pause, or resume the cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void StartPause(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start_pause", target);
		}

		///<summary>Stop the current cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void Stop(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "stop", target);
		}

		public void Toggle()
		{
			_haContext.CallService("vacuum", "toggle", null);
		}

		///<summary>Stop the current cleaning task and return to home.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOff(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_off", target);
		}

		///<summary>Start a new cleaning task.</summary>
		///<param name="target">The target for this service call</param>
		public void TurnOn(ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_on", target);
		}
	}

	public record VacuumSendCommandParameters
	{
		///<summary>Command to execute. eg: set_dnd_timer</summary>
		[JsonPropertyName("command")]
		public string? Command { get; init; }

		///<summary>Parameters for the command. eg: { "key": "value" }</summary>
		[JsonPropertyName("params")]
		public object? Params { get; init; }
	}

	public record VacuumSetFanSpeedParameters
	{
		///<summary>Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</summary>
		[JsonPropertyName("fan_speed")]
		public string? FanSpeed { get; init; }
	}

	public class YeelightServices
	{
		private readonly IHaContext _haContext;
		public YeelightServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		public void SetAutoDelayOffScene(ServiceTarget target, YeelightSetAutoDelayOffSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_auto_delay_off_scene", target, data);
		}

		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="minutes">The time to wait before automatically turning the light off.</param>
		///<param name="brightness">The brightness value to set.</param>
		public void SetAutoDelayOffScene(ServiceTarget target, long? @minutes = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_auto_delay_off_scene", target, new YeelightSetAutoDelayOffSceneParameters{Minutes = @minutes, Brightness = @brightness});
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		public void SetColorFlowScene(ServiceTarget target, YeelightSetColorFlowSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_flow_scene", target, data);
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public void SetColorFlowScene(ServiceTarget target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			_haContext.CallService("yeelight", "set_color_flow_scene", target, new YeelightSetColorFlowSceneParameters{Count = @count, Action = @action, Transitions = @transitions});
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		public void SetColorScene(ServiceTarget target, YeelightSetColorSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_scene", target, data);
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="brightness">The brightness value to set.</param>
		public void SetColorScene(ServiceTarget target, object? @rgbColor = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_color_scene", target, new YeelightSetColorSceneParameters{RgbColor = @rgbColor, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		public void SetColorTempScene(ServiceTarget target, YeelightSetColorTempSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_temp_scene", target, data);
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">The brightness value to set.</param>
		public void SetColorTempScene(ServiceTarget target, long? @kelvin = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_color_temp_scene", target, new YeelightSetColorTempSceneParameters{Kelvin = @kelvin, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		public void SetHsvScene(ServiceTarget target, YeelightSetHsvSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_hsv_scene", target, data);
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-359 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="brightness">The brightness value to set.</param>
		public void SetHsvScene(ServiceTarget target, object? @hsColor = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_hsv_scene", target, new YeelightSetHsvSceneParameters{HsColor = @hsColor, Brightness = @brightness});
		}

		///<summary>Set a operation mode.</summary>
		///<param name="target">The target for this service call</param>
		public void SetMode(ServiceTarget target, YeelightSetModeParameters data)
		{
			_haContext.CallService("yeelight", "set_mode", target, data);
		}

		///<summary>Set a operation mode.</summary>
		///<param name="target">The target for this service call</param>
		///<param name="mode">Operation mode.</param>
		public void SetMode(ServiceTarget target, object @mode)
		{
			_haContext.CallService("yeelight", "set_mode", target, new YeelightSetModeParameters{Mode = @mode});
		}

		///<summary>Enable or disable music_mode</summary>
		///<param name="target">The target for this service call</param>
		public void SetMusicMode(ServiceTarget target, YeelightSetMusicModeParameters data)
		{
			_haContext.CallService("yeelight", "set_music_mode", target, data);
		}

		///<summary>Enable or disable music_mode</summary>
		///<param name="target">The target for this service call</param>
		///<param name="musicMode">Use true or false to enable / disable music_mode</param>
		public void SetMusicMode(ServiceTarget target, bool @musicMode)
		{
			_haContext.CallService("yeelight", "set_music_mode", target, new YeelightSetMusicModeParameters{MusicMode = @musicMode});
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		///<param name="target">The target for this service call</param>
		public void StartFlow(ServiceTarget target, YeelightStartFlowParameters data)
		{
			_haContext.CallService("yeelight", "start_flow", target, data);
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		///<param name="target">The target for this service call</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public void StartFlow(ServiceTarget target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			_haContext.CallService("yeelight", "start_flow", target, new YeelightStartFlowParameters{Count = @count, Action = @action, Transitions = @transitions});
		}
	}

	public record YeelightSetAutoDelayOffSceneParameters
	{
		///<summary>The time to wait before automatically turning the light off.</summary>
		[JsonPropertyName("minutes")]
		public long? Minutes { get; init; }

		///<summary>The brightness value to set.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetColorFlowSceneParameters
	{
		///<summary>The number of times to run this flow (0 to run forever).</summary>
		[JsonPropertyName("count")]
		public long? Count { get; init; }

		///<summary>The action to take after the flow stops.</summary>
		[JsonPropertyName("action")]
		public object? Action { get; init; }

		///<summary>Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</summary>
		[JsonPropertyName("transitions")]
		public object? Transitions { get; init; }
	}

	public record YeelightSetColorSceneParameters
	{
		///<summary>Color for the light in RGB-format. eg: [255, 100, 100]</summary>
		[JsonPropertyName("rgb_color")]
		public object? RgbColor { get; init; }

		///<summary>The brightness value to set.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetColorTempSceneParameters
	{
		///<summary>Color temperature for the light in Kelvin.</summary>
		[JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		///<summary>The brightness value to set.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetHsvSceneParameters
	{
		///<summary>Color for the light in hue/sat format. Hue is 0-359 and Sat is 0-100. eg: [300, 70]</summary>
		[JsonPropertyName("hs_color")]
		public object? HsColor { get; init; }

		///<summary>The brightness value to set.</summary>
		[JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetModeParameters
	{
		///<summary>Operation mode.</summary>
		[JsonPropertyName("mode")]
		public object? Mode { get; init; }
	}

	public record YeelightSetMusicModeParameters
	{
		///<summary>Use true or false to enable / disable music_mode</summary>
		[JsonPropertyName("music_mode")]
		public bool? MusicMode { get; init; }
	}

	public record YeelightStartFlowParameters
	{
		///<summary>The number of times to run this flow (0 to run forever).</summary>
		[JsonPropertyName("count")]
		public long? Count { get; init; }

		///<summary>The action to take after the flow stops.</summary>
		[JsonPropertyName("action")]
		public object? Action { get; init; }

		///<summary>Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</summary>
		[JsonPropertyName("transitions")]
		public object? Transitions { get; init; }
	}

	public class ZoneServices
	{
		private readonly IHaContext _haContext;
		public ZoneServices(IHaContext haContext)
		{
			_haContext = haContext;
		}

		///<summary>Reload the YAML-based zone configuration.</summary>
		public void Reload()
		{
			_haContext.CallService("zone", "reload", null);
		}
	}

	public static class AlarmControlPanelEntityExtensionMethods
	{
		///<summary>Send the alarm the command for arm away.</summary>
		public static void AlarmArmAway(this AlarmControlPanelEntity target, AlarmControlPanelAlarmArmAwayParameters data)
		{
			target.CallService("alarm_arm_away", data);
		}

		///<summary>Send the alarm the command for arm away.</summary>
		public static void AlarmArmAway(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmArmAwayParameters data)
		{
			target.CallService("alarm_arm_away", data);
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to arm away the alarm control panel with. eg: 1234</param>
		public static void AlarmArmAway(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_arm_away", new AlarmControlPanelAlarmArmAwayParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm away.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to arm away the alarm control panel with. eg: 1234</param>
		public static void AlarmArmAway(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_arm_away", new AlarmControlPanelAlarmArmAwayParameters{Code = @code});
		}

		///<summary>Send arm custom bypass command.</summary>
		public static void AlarmArmCustomBypass(this AlarmControlPanelEntity target, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			target.CallService("alarm_arm_custom_bypass", data);
		}

		///<summary>Send arm custom bypass command.</summary>
		public static void AlarmArmCustomBypass(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			target.CallService("alarm_arm_custom_bypass", data);
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to arm custom bypass the alarm control panel with. eg: 1234</param>
		public static void AlarmArmCustomBypass(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_arm_custom_bypass", new AlarmControlPanelAlarmArmCustomBypassParameters{Code = @code});
		}

		///<summary>Send arm custom bypass command.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to arm custom bypass the alarm control panel with. eg: 1234</param>
		public static void AlarmArmCustomBypass(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_arm_custom_bypass", new AlarmControlPanelAlarmArmCustomBypassParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm home.</summary>
		public static void AlarmArmHome(this AlarmControlPanelEntity target, AlarmControlPanelAlarmArmHomeParameters data)
		{
			target.CallService("alarm_arm_home", data);
		}

		///<summary>Send the alarm the command for arm home.</summary>
		public static void AlarmArmHome(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmArmHomeParameters data)
		{
			target.CallService("alarm_arm_home", data);
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to arm home the alarm control panel with. eg: 1234</param>
		public static void AlarmArmHome(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_arm_home", new AlarmControlPanelAlarmArmHomeParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm home.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to arm home the alarm control panel with. eg: 1234</param>
		public static void AlarmArmHome(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_arm_home", new AlarmControlPanelAlarmArmHomeParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm night.</summary>
		public static void AlarmArmNight(this AlarmControlPanelEntity target, AlarmControlPanelAlarmArmNightParameters data)
		{
			target.CallService("alarm_arm_night", data);
		}

		///<summary>Send the alarm the command for arm night.</summary>
		public static void AlarmArmNight(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmArmNightParameters data)
		{
			target.CallService("alarm_arm_night", data);
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to arm night the alarm control panel with. eg: 1234</param>
		public static void AlarmArmNight(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_arm_night", new AlarmControlPanelAlarmArmNightParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm night.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to arm night the alarm control panel with. eg: 1234</param>
		public static void AlarmArmNight(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_arm_night", new AlarmControlPanelAlarmArmNightParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		public static void AlarmArmVacation(this AlarmControlPanelEntity target, AlarmControlPanelAlarmArmVacationParameters data)
		{
			target.CallService("alarm_arm_vacation", data);
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		public static void AlarmArmVacation(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmArmVacationParameters data)
		{
			target.CallService("alarm_arm_vacation", data);
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to arm vacation the alarm control panel with. eg: 1234</param>
		public static void AlarmArmVacation(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_arm_vacation", new AlarmControlPanelAlarmArmVacationParameters{Code = @code});
		}

		///<summary>Send the alarm the command for arm vacation.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to arm vacation the alarm control panel with. eg: 1234</param>
		public static void AlarmArmVacation(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_arm_vacation", new AlarmControlPanelAlarmArmVacationParameters{Code = @code});
		}

		///<summary>Send the alarm the command for disarm.</summary>
		public static void AlarmDisarm(this AlarmControlPanelEntity target, AlarmControlPanelAlarmDisarmParameters data)
		{
			target.CallService("alarm_disarm", data);
		}

		///<summary>Send the alarm the command for disarm.</summary>
		public static void AlarmDisarm(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmDisarmParameters data)
		{
			target.CallService("alarm_disarm", data);
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to disarm the alarm control panel with. eg: 1234</param>
		public static void AlarmDisarm(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_disarm", new AlarmControlPanelAlarmDisarmParameters{Code = @code});
		}

		///<summary>Send the alarm the command for disarm.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to disarm the alarm control panel with. eg: 1234</param>
		public static void AlarmDisarm(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_disarm", new AlarmControlPanelAlarmDisarmParameters{Code = @code});
		}

		///<summary>Send the alarm the command for trigger.</summary>
		public static void AlarmTrigger(this AlarmControlPanelEntity target, AlarmControlPanelAlarmTriggerParameters data)
		{
			target.CallService("alarm_trigger", data);
		}

		///<summary>Send the alarm the command for trigger.</summary>
		public static void AlarmTrigger(this IEnumerable<AlarmControlPanelEntity> target, AlarmControlPanelAlarmTriggerParameters data)
		{
			target.CallService("alarm_trigger", data);
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The AlarmControlPanelEntity to call this service for</param>
		///<param name="code">An optional code to trigger the alarm control panel with. eg: 1234</param>
		public static void AlarmTrigger(this AlarmControlPanelEntity target, string? @code = null)
		{
			target.CallService("alarm_trigger", new AlarmControlPanelAlarmTriggerParameters{Code = @code});
		}

		///<summary>Send the alarm the command for trigger.</summary>
		///<param name="target">The IEnumerable<AlarmControlPanelEntity> to call this service for</param>
		///<param name="code">An optional code to trigger the alarm control panel with. eg: 1234</param>
		public static void AlarmTrigger(this IEnumerable<AlarmControlPanelEntity> target, string? @code = null)
		{
			target.CallService("alarm_trigger", new AlarmControlPanelAlarmTriggerParameters{Code = @code});
		}
	}

	public static class AutomationEntityExtensionMethods
	{
		///<summary>Toggle (enable / disable) an automation.</summary>
		public static void Toggle(this AutomationEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle (enable / disable) an automation.</summary>
		public static void Toggle(this IEnumerable<AutomationEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Trigger the actions of an automation.</summary>
		public static void Trigger(this AutomationEntity target, AutomationTriggerParameters data)
		{
			target.CallService("trigger", data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		public static void Trigger(this IEnumerable<AutomationEntity> target, AutomationTriggerParameters data)
		{
			target.CallService("trigger", data);
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The AutomationEntity to call this service for</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public static void Trigger(this AutomationEntity target, bool? @skipCondition = null)
		{
			target.CallService("trigger", new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Trigger the actions of an automation.</summary>
		///<param name="target">The IEnumerable<AutomationEntity> to call this service for</param>
		///<param name="skipCondition">Whether or not the conditions will be skipped.</param>
		public static void Trigger(this IEnumerable<AutomationEntity> target, bool? @skipCondition = null)
		{
			target.CallService("trigger", new AutomationTriggerParameters{SkipCondition = @skipCondition});
		}

		///<summary>Disable an automation.</summary>
		public static void TurnOff(this AutomationEntity target, AutomationTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Disable an automation.</summary>
		public static void TurnOff(this IEnumerable<AutomationEntity> target, AutomationTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The AutomationEntity to call this service for</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public static void TurnOff(this AutomationEntity target, bool? @stopActions = null)
		{
			target.CallService("turn_off", new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Disable an automation.</summary>
		///<param name="target">The IEnumerable<AutomationEntity> to call this service for</param>
		///<param name="stopActions">Stop currently running actions.</param>
		public static void TurnOff(this IEnumerable<AutomationEntity> target, bool? @stopActions = null)
		{
			target.CallService("turn_off", new AutomationTurnOffParameters{StopActions = @stopActions});
		}

		///<summary>Enable an automation.</summary>
		public static void TurnOn(this AutomationEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Enable an automation.</summary>
		public static void TurnOn(this IEnumerable<AutomationEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class ButtonEntityExtensionMethods
	{
		///<summary>Press the button entity.</summary>
		public static void Press(this ButtonEntity target)
		{
			target.CallService("press");
		}

		///<summary>Press the button entity.</summary>
		public static void Press(this IEnumerable<ButtonEntity> target)
		{
			target.CallService("press");
		}
	}

	public static class CameraEntityExtensionMethods
	{
		///<summary>Disable the motion detection in a camera.</summary>
		public static void DisableMotionDetection(this CameraEntity target)
		{
			target.CallService("disable_motion_detection");
		}

		///<summary>Disable the motion detection in a camera.</summary>
		public static void DisableMotionDetection(this IEnumerable<CameraEntity> target)
		{
			target.CallService("disable_motion_detection");
		}

		///<summary>Enable the motion detection in a camera.</summary>
		public static void EnableMotionDetection(this CameraEntity target)
		{
			target.CallService("enable_motion_detection");
		}

		///<summary>Enable the motion detection in a camera.</summary>
		public static void EnableMotionDetection(this IEnumerable<CameraEntity> target)
		{
			target.CallService("enable_motion_detection");
		}

		///<summary>Play camera stream on supported media player.</summary>
		public static void PlayStream(this CameraEntity target, CameraPlayStreamParameters data)
		{
			target.CallService("play_stream", data);
		}

		///<summary>Play camera stream on supported media player.</summary>
		public static void PlayStream(this IEnumerable<CameraEntity> target, CameraPlayStreamParameters data)
		{
			target.CallService("play_stream", data);
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The CameraEntity to call this service for</param>
		///<param name="mediaPlayer">Name(s) of media player to stream to.</param>
		///<param name="format">Stream format supported by media player.</param>
		public static void PlayStream(this CameraEntity target, string @mediaPlayer, object? @format = null)
		{
			target.CallService("play_stream", new CameraPlayStreamParameters{MediaPlayer = @mediaPlayer, Format = @format});
		}

		///<summary>Play camera stream on supported media player.</summary>
		///<param name="target">The IEnumerable<CameraEntity> to call this service for</param>
		///<param name="mediaPlayer">Name(s) of media player to stream to.</param>
		///<param name="format">Stream format supported by media player.</param>
		public static void PlayStream(this IEnumerable<CameraEntity> target, string @mediaPlayer, object? @format = null)
		{
			target.CallService("play_stream", new CameraPlayStreamParameters{MediaPlayer = @mediaPlayer, Format = @format});
		}

		///<summary>Record live camera feed.</summary>
		public static void Record(this CameraEntity target, CameraRecordParameters data)
		{
			target.CallService("record", data);
		}

		///<summary>Record live camera feed.</summary>
		public static void Record(this IEnumerable<CameraEntity> target, CameraRecordParameters data)
		{
			target.CallService("record", data);
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The CameraEntity to call this service for</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</param>
		///<param name="duration">Target recording length.</param>
		///<param name="lookback">Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</param>
		public static void Record(this CameraEntity target, string @filename, long? @duration = null, long? @lookback = null)
		{
			target.CallService("record", new CameraRecordParameters{Filename = @filename, Duration = @duration, Lookback = @lookback});
		}

		///<summary>Record live camera feed.</summary>
		///<param name="target">The IEnumerable<CameraEntity> to call this service for</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. Must be mp4. eg: /tmp/snapshot_{{ entity_id.name }}.mp4</param>
		///<param name="duration">Target recording length.</param>
		///<param name="lookback">Target lookback period to include in addition to duration. Only available if there is currently an active HLS stream.</param>
		public static void Record(this IEnumerable<CameraEntity> target, string @filename, long? @duration = null, long? @lookback = null)
		{
			target.CallService("record", new CameraRecordParameters{Filename = @filename, Duration = @duration, Lookback = @lookback});
		}

		///<summary>Take a snapshot from a camera.</summary>
		public static void Snapshot(this CameraEntity target, CameraSnapshotParameters data)
		{
			target.CallService("snapshot", data);
		}

		///<summary>Take a snapshot from a camera.</summary>
		public static void Snapshot(this IEnumerable<CameraEntity> target, CameraSnapshotParameters data)
		{
			target.CallService("snapshot", data);
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The CameraEntity to call this service for</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</param>
		public static void Snapshot(this CameraEntity target, string @filename)
		{
			target.CallService("snapshot", new CameraSnapshotParameters{Filename = @filename});
		}

		///<summary>Take a snapshot from a camera.</summary>
		///<param name="target">The IEnumerable<CameraEntity> to call this service for</param>
		///<param name="filename">Template of a Filename. Variable is entity_id. eg: /tmp/snapshot_{{ entity_id.name }}.jpg</param>
		public static void Snapshot(this IEnumerable<CameraEntity> target, string @filename)
		{
			target.CallService("snapshot", new CameraSnapshotParameters{Filename = @filename});
		}

		///<summary>Turn off camera.</summary>
		public static void TurnOff(this CameraEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn off camera.</summary>
		public static void TurnOff(this IEnumerable<CameraEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn on camera.</summary>
		public static void TurnOn(this CameraEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn on camera.</summary>
		public static void TurnOn(this IEnumerable<CameraEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class ClimateEntityExtensionMethods
	{
		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		public static void SetAuxHeat(this ClimateEntity target, ClimateSetAuxHeatParameters data)
		{
			target.CallService("set_aux_heat", data);
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		public static void SetAuxHeat(this IEnumerable<ClimateEntity> target, ClimateSetAuxHeatParameters data)
		{
			target.CallService("set_aux_heat", data);
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="auxHeat">New value of auxiliary heater.</param>
		public static void SetAuxHeat(this ClimateEntity target, bool @auxHeat)
		{
			target.CallService("set_aux_heat", new ClimateSetAuxHeatParameters{AuxHeat = @auxHeat});
		}

		///<summary>Turn auxiliary heater on/off for climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="auxHeat">New value of auxiliary heater.</param>
		public static void SetAuxHeat(this IEnumerable<ClimateEntity> target, bool @auxHeat)
		{
			target.CallService("set_aux_heat", new ClimateSetAuxHeatParameters{AuxHeat = @auxHeat});
		}

		///<summary>Set fan operation for climate device.</summary>
		public static void SetFanMode(this ClimateEntity target, ClimateSetFanModeParameters data)
		{
			target.CallService("set_fan_mode", data);
		}

		///<summary>Set fan operation for climate device.</summary>
		public static void SetFanMode(this IEnumerable<ClimateEntity> target, ClimateSetFanModeParameters data)
		{
			target.CallService("set_fan_mode", data);
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="fanMode">New value of fan mode. eg: low</param>
		public static void SetFanMode(this ClimateEntity target, string @fanMode)
		{
			target.CallService("set_fan_mode", new ClimateSetFanModeParameters{FanMode = @fanMode});
		}

		///<summary>Set fan operation for climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="fanMode">New value of fan mode. eg: low</param>
		public static void SetFanMode(this IEnumerable<ClimateEntity> target, string @fanMode)
		{
			target.CallService("set_fan_mode", new ClimateSetFanModeParameters{FanMode = @fanMode});
		}

		///<summary>Set target humidity of climate device.</summary>
		public static void SetHumidity(this ClimateEntity target, ClimateSetHumidityParameters data)
		{
			target.CallService("set_humidity", data);
		}

		///<summary>Set target humidity of climate device.</summary>
		public static void SetHumidity(this IEnumerable<ClimateEntity> target, ClimateSetHumidityParameters data)
		{
			target.CallService("set_humidity", data);
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="humidity">New target humidity for climate device.</param>
		public static void SetHumidity(this ClimateEntity target, long @humidity)
		{
			target.CallService("set_humidity", new ClimateSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set target humidity of climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="humidity">New target humidity for climate device.</param>
		public static void SetHumidity(this IEnumerable<ClimateEntity> target, long @humidity)
		{
			target.CallService("set_humidity", new ClimateSetHumidityParameters{Humidity = @humidity});
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		public static void SetHvacMode(this ClimateEntity target, ClimateSetHvacModeParameters data)
		{
			target.CallService("set_hvac_mode", data);
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		public static void SetHvacMode(this IEnumerable<ClimateEntity> target, ClimateSetHvacModeParameters data)
		{
			target.CallService("set_hvac_mode", data);
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="hvacMode">New value of operation mode.</param>
		public static void SetHvacMode(this ClimateEntity target, object? @hvacMode = null)
		{
			target.CallService("set_hvac_mode", new ClimateSetHvacModeParameters{HvacMode = @hvacMode});
		}

		///<summary>Set HVAC operation mode for climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="hvacMode">New value of operation mode.</param>
		public static void SetHvacMode(this IEnumerable<ClimateEntity> target, object? @hvacMode = null)
		{
			target.CallService("set_hvac_mode", new ClimateSetHvacModeParameters{HvacMode = @hvacMode});
		}

		///<summary>Set preset mode for climate device.</summary>
		public static void SetPresetMode(this ClimateEntity target, ClimateSetPresetModeParameters data)
		{
			target.CallService("set_preset_mode", data);
		}

		///<summary>Set preset mode for climate device.</summary>
		public static void SetPresetMode(this IEnumerable<ClimateEntity> target, ClimateSetPresetModeParameters data)
		{
			target.CallService("set_preset_mode", data);
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="presetMode">New value of preset mode. eg: away</param>
		public static void SetPresetMode(this ClimateEntity target, string @presetMode)
		{
			target.CallService("set_preset_mode", new ClimateSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Set preset mode for climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="presetMode">New value of preset mode. eg: away</param>
		public static void SetPresetMode(this IEnumerable<ClimateEntity> target, string @presetMode)
		{
			target.CallService("set_preset_mode", new ClimateSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Set swing operation for climate device.</summary>
		public static void SetSwingMode(this ClimateEntity target, ClimateSetSwingModeParameters data)
		{
			target.CallService("set_swing_mode", data);
		}

		///<summary>Set swing operation for climate device.</summary>
		public static void SetSwingMode(this IEnumerable<ClimateEntity> target, ClimateSetSwingModeParameters data)
		{
			target.CallService("set_swing_mode", data);
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="swingMode">New value of swing mode. eg: horizontal</param>
		public static void SetSwingMode(this ClimateEntity target, string @swingMode)
		{
			target.CallService("set_swing_mode", new ClimateSetSwingModeParameters{SwingMode = @swingMode});
		}

		///<summary>Set swing operation for climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="swingMode">New value of swing mode. eg: horizontal</param>
		public static void SetSwingMode(this IEnumerable<ClimateEntity> target, string @swingMode)
		{
			target.CallService("set_swing_mode", new ClimateSetSwingModeParameters{SwingMode = @swingMode});
		}

		///<summary>Set target temperature of climate device.</summary>
		public static void SetTemperature(this ClimateEntity target, ClimateSetTemperatureParameters data)
		{
			target.CallService("set_temperature", data);
		}

		///<summary>Set target temperature of climate device.</summary>
		public static void SetTemperature(this IEnumerable<ClimateEntity> target, ClimateSetTemperatureParameters data)
		{
			target.CallService("set_temperature", data);
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The ClimateEntity to call this service for</param>
		///<param name="temperature">New target temperature for HVAC.</param>
		///<param name="targetTempHigh">New target high temperature for HVAC.</param>
		///<param name="targetTempLow">New target low temperature for HVAC.</param>
		///<param name="hvacMode">HVAC operation mode to set temperature to.</param>
		public static void SetTemperature(this ClimateEntity target, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, object? @hvacMode = null)
		{
			target.CallService("set_temperature", new ClimateSetTemperatureParameters{Temperature = @temperature, TargetTempHigh = @targetTempHigh, TargetTempLow = @targetTempLow, HvacMode = @hvacMode});
		}

		///<summary>Set target temperature of climate device.</summary>
		///<param name="target">The IEnumerable<ClimateEntity> to call this service for</param>
		///<param name="temperature">New target temperature for HVAC.</param>
		///<param name="targetTempHigh">New target high temperature for HVAC.</param>
		///<param name="targetTempLow">New target low temperature for HVAC.</param>
		///<param name="hvacMode">HVAC operation mode to set temperature to.</param>
		public static void SetTemperature(this IEnumerable<ClimateEntity> target, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, object? @hvacMode = null)
		{
			target.CallService("set_temperature", new ClimateSetTemperatureParameters{Temperature = @temperature, TargetTempHigh = @targetTempHigh, TargetTempLow = @targetTempLow, HvacMode = @hvacMode});
		}

		///<summary>Turn climate device off.</summary>
		public static void TurnOff(this ClimateEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn climate device off.</summary>
		public static void TurnOff(this IEnumerable<ClimateEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn climate device on.</summary>
		public static void TurnOn(this ClimateEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn climate device on.</summary>
		public static void TurnOn(this IEnumerable<ClimateEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class FanEntityExtensionMethods
	{
		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		public static void DecreaseSpeed(this FanEntity target, FanDecreaseSpeedParameters data)
		{
			target.CallService("decrease_speed", data);
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		public static void DecreaseSpeed(this IEnumerable<FanEntity> target, FanDecreaseSpeedParameters data)
		{
			target.CallService("decrease_speed", data);
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="percentageStep">Decrease speed by a percentage.</param>
		public static void DecreaseSpeed(this FanEntity target, long? @percentageStep = null)
		{
			target.CallService("decrease_speed", new FanDecreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Decrease the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="percentageStep">Decrease speed by a percentage.</param>
		public static void DecreaseSpeed(this IEnumerable<FanEntity> target, long? @percentageStep = null)
		{
			target.CallService("decrease_speed", new FanDecreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		public static void IncreaseSpeed(this FanEntity target, FanIncreaseSpeedParameters data)
		{
			target.CallService("increase_speed", data);
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		public static void IncreaseSpeed(this IEnumerable<FanEntity> target, FanIncreaseSpeedParameters data)
		{
			target.CallService("increase_speed", data);
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="percentageStep">Increase speed by a percentage.</param>
		public static void IncreaseSpeed(this FanEntity target, long? @percentageStep = null)
		{
			target.CallService("increase_speed", new FanIncreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Increase the speed of the fan by one speed or a percentage_step.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="percentageStep">Increase speed by a percentage.</param>
		public static void IncreaseSpeed(this IEnumerable<FanEntity> target, long? @percentageStep = null)
		{
			target.CallService("increase_speed", new FanIncreaseSpeedParameters{PercentageStep = @percentageStep});
		}

		///<summary>Oscillate the fan.</summary>
		public static void Oscillate(this FanEntity target, FanOscillateParameters data)
		{
			target.CallService("oscillate", data);
		}

		///<summary>Oscillate the fan.</summary>
		public static void Oscillate(this IEnumerable<FanEntity> target, FanOscillateParameters data)
		{
			target.CallService("oscillate", data);
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="oscillating">Flag to turn on/off oscillation.</param>
		public static void Oscillate(this FanEntity target, bool @oscillating)
		{
			target.CallService("oscillate", new FanOscillateParameters{Oscillating = @oscillating});
		}

		///<summary>Oscillate the fan.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="oscillating">Flag to turn on/off oscillation.</param>
		public static void Oscillate(this IEnumerable<FanEntity> target, bool @oscillating)
		{
			target.CallService("oscillate", new FanOscillateParameters{Oscillating = @oscillating});
		}

		///<summary>Set the fan rotation.</summary>
		public static void SetDirection(this FanEntity target, FanSetDirectionParameters data)
		{
			target.CallService("set_direction", data);
		}

		///<summary>Set the fan rotation.</summary>
		public static void SetDirection(this IEnumerable<FanEntity> target, FanSetDirectionParameters data)
		{
			target.CallService("set_direction", data);
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="direction">The direction to rotate.</param>
		public static void SetDirection(this FanEntity target, object @direction)
		{
			target.CallService("set_direction", new FanSetDirectionParameters{Direction = @direction});
		}

		///<summary>Set the fan rotation.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="direction">The direction to rotate.</param>
		public static void SetDirection(this IEnumerable<FanEntity> target, object @direction)
		{
			target.CallService("set_direction", new FanSetDirectionParameters{Direction = @direction});
		}

		///<summary>Set fan speed percentage.</summary>
		public static void SetPercentage(this FanEntity target, FanSetPercentageParameters data)
		{
			target.CallService("set_percentage", data);
		}

		///<summary>Set fan speed percentage.</summary>
		public static void SetPercentage(this IEnumerable<FanEntity> target, FanSetPercentageParameters data)
		{
			target.CallService("set_percentage", data);
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="percentage">Percentage speed setting.</param>
		public static void SetPercentage(this FanEntity target, long @percentage)
		{
			target.CallService("set_percentage", new FanSetPercentageParameters{Percentage = @percentage});
		}

		///<summary>Set fan speed percentage.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="percentage">Percentage speed setting.</param>
		public static void SetPercentage(this IEnumerable<FanEntity> target, long @percentage)
		{
			target.CallService("set_percentage", new FanSetPercentageParameters{Percentage = @percentage});
		}

		///<summary>Set preset mode for a fan device.</summary>
		public static void SetPresetMode(this FanEntity target, FanSetPresetModeParameters data)
		{
			target.CallService("set_preset_mode", data);
		}

		///<summary>Set preset mode for a fan device.</summary>
		public static void SetPresetMode(this IEnumerable<FanEntity> target, FanSetPresetModeParameters data)
		{
			target.CallService("set_preset_mode", data);
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="presetMode">New value of preset mode. eg: auto</param>
		public static void SetPresetMode(this FanEntity target, string @presetMode)
		{
			target.CallService("set_preset_mode", new FanSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Set preset mode for a fan device.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="presetMode">New value of preset mode. eg: auto</param>
		public static void SetPresetMode(this IEnumerable<FanEntity> target, string @presetMode)
		{
			target.CallService("set_preset_mode", new FanSetPresetModeParameters{PresetMode = @presetMode});
		}

		///<summary>Toggle the fan on/off.</summary>
		public static void Toggle(this FanEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle the fan on/off.</summary>
		public static void Toggle(this IEnumerable<FanEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn fan off.</summary>
		public static void TurnOff(this FanEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn fan off.</summary>
		public static void TurnOff(this IEnumerable<FanEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn fan on.</summary>
		public static void TurnOn(this FanEntity target, FanTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn fan on.</summary>
		public static void TurnOn(this IEnumerable<FanEntity> target, FanTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The FanEntity to call this service for</param>
		///<param name="speed">Speed setting. eg: high</param>
		///<param name="percentage">Percentage speed setting.</param>
		///<param name="presetMode">Preset mode setting. eg: auto</param>
		public static void TurnOn(this FanEntity target, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			target.CallService("turn_on", new FanTurnOnParameters{Speed = @speed, Percentage = @percentage, PresetMode = @presetMode});
		}

		///<summary>Turn fan on.</summary>
		///<param name="target">The IEnumerable<FanEntity> to call this service for</param>
		///<param name="speed">Speed setting. eg: high</param>
		///<param name="percentage">Percentage speed setting.</param>
		///<param name="presetMode">Preset mode setting. eg: auto</param>
		public static void TurnOn(this IEnumerable<FanEntity> target, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			target.CallService("turn_on", new FanTurnOnParameters{Speed = @speed, Percentage = @percentage, PresetMode = @presetMode});
		}
	}

	public static class InputBooleanEntityExtensionMethods
	{
		///<summary>Toggle an input boolean</summary>
		public static void Toggle(this InputBooleanEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle an input boolean</summary>
		public static void Toggle(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn off an input boolean</summary>
		public static void TurnOff(this InputBooleanEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn off an input boolean</summary>
		public static void TurnOff(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn on an input boolean</summary>
		public static void TurnOn(this InputBooleanEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn on an input boolean</summary>
		public static void TurnOn(this IEnumerable<InputBooleanEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class InputSelectEntityExtensionMethods
	{
		///<summary>Select the first option of an input select entity.</summary>
		public static void SelectFirst(this InputSelectEntity target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the first option of an input select entity.</summary>
		public static void SelectFirst(this IEnumerable<InputSelectEntity> target)
		{
			target.CallService("select_first");
		}

		///<summary>Select the last option of an input select entity.</summary>
		public static void SelectLast(this InputSelectEntity target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the last option of an input select entity.</summary>
		public static void SelectLast(this IEnumerable<InputSelectEntity> target)
		{
			target.CallService("select_last");
		}

		///<summary>Select the next options of an input select entity.</summary>
		public static void SelectNext(this InputSelectEntity target, InputSelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		public static void SelectNext(this IEnumerable<InputSelectEntity> target, InputSelectSelectNextParameters data)
		{
			target.CallService("select_next", data);
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this InputSelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_next", new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select the next options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the last to the first.</param>
		public static void SelectNext(this IEnumerable<InputSelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_next", new InputSelectSelectNextParameters{Cycle = @cycle});
		}

		///<summary>Select an option of an input select entity.</summary>
		public static void SelectOption(this InputSelectEntity target, InputSelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an input select entity.</summary>
		public static void SelectOption(this IEnumerable<InputSelectEntity> target, InputSelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this InputSelectEntity target, string @option)
		{
			target.CallService("select_option", new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select an option of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this IEnumerable<InputSelectEntity> target, string @option)
		{
			target.CallService("select_option", new InputSelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		public static void SelectPrevious(this InputSelectEntity target, InputSelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		public static void SelectPrevious(this IEnumerable<InputSelectEntity> target, InputSelectSelectPreviousParameters data)
		{
			target.CallService("select_previous", data);
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this InputSelectEntity target, bool? @cycle = null)
		{
			target.CallService("select_previous", new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Select the previous options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="cycle">If the option should cycle from the first to the last.</param>
		public static void SelectPrevious(this IEnumerable<InputSelectEntity> target, bool? @cycle = null)
		{
			target.CallService("select_previous", new InputSelectSelectPreviousParameters{Cycle = @cycle});
		}

		///<summary>Set the options of an input select entity.</summary>
		public static void SetOptions(this InputSelectEntity target, InputSelectSetOptionsParameters data)
		{
			target.CallService("set_options", data);
		}

		///<summary>Set the options of an input select entity.</summary>
		public static void SetOptions(this IEnumerable<InputSelectEntity> target, InputSelectSetOptionsParameters data)
		{
			target.CallService("set_options", data);
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The InputSelectEntity to call this service for</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public static void SetOptions(this InputSelectEntity target, object @options)
		{
			target.CallService("set_options", new InputSelectSetOptionsParameters{Options = @options});
		}

		///<summary>Set the options of an input select entity.</summary>
		///<param name="target">The IEnumerable<InputSelectEntity> to call this service for</param>
		///<param name="options">Options for the input select entity. eg: ["Item A", "Item B", "Item C"]</param>
		public static void SetOptions(this IEnumerable<InputSelectEntity> target, object @options)
		{
			target.CallService("set_options", new InputSelectSetOptionsParameters{Options = @options});
		}
	}

	public static class LightEntityExtensionMethods
	{
		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		public static void Toggle(this LightEntity target, LightToggleParameters data)
		{
			target.CallService("toggle", data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		public static void Toggle(this IEnumerable<LightEntity> target, LightToggleParameters data)
		{
			target.CallService("toggle", data);
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="whiteValue">Number indicating level of white.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void Toggle(this LightEntity target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @whiteValue = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("toggle", new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, WhiteValue = @whiteValue, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Toggles one or more lights, from on to off, or, off to on, based on their current state. </summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="whiteValue">Number indicating level of white.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void Toggle(this IEnumerable<LightEntity> target, long? @transition = null, object? @rgbColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @whiteValue = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("toggle", new LightToggleParameters{Transition = @transition, RgbColor = @rgbColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, WhiteValue = @whiteValue, Brightness = @brightness, BrightnessPct = @brightnessPct, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turns off one or more lights.</summary>
		public static void TurnOff(this LightEntity target, LightTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Turns off one or more lights.</summary>
		public static void TurnOff(this IEnumerable<LightEntity> target, LightTurnOffParameters data)
		{
			target.CallService("turn_off", data);
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public static void TurnOff(this LightEntity target, long? @transition = null, object? @flash = null)
		{
			target.CallService("turn_off", new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turns off one or more lights.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="flash">If the light should flash.</param>
		public static void TurnOff(this IEnumerable<LightEntity> target, long? @transition = null, object? @flash = null)
		{
			target.CallService("turn_off", new LightTurnOffParameters{Transition = @transition, Flash = @flash});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		public static void TurnOn(this LightEntity target, LightTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		public static void TurnOn(this IEnumerable<LightEntity> target, LightTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void TurnOn(this LightEntity target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("turn_on", new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}

		///<summary>Turn on one or more lights and adjust properties of the light, even when they are turned on already. </summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="transition">Duration it takes to get to next state.</param>
		///<param name="rgbColor">The color for the light (based on RGB - red, green, blue).</param>
		///<param name="rgbwColor">A list containing four integers between 0 and 255 representing the RGBW (red, green, blue, white) color for the light. eg: [255, 100, 100, 50]</param>
		///<param name="rgbwwColor">A list containing five integers between 0 and 255 representing the RGBWW (red, green, blue, cold white, warm white) color for the light. eg: [255, 100, 100, 50, 70]</param>
		///<param name="colorName">A human readable color name.</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-360 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="xyColor">Color for the light in XY-format. eg: [0.52, 0.43]</param>
		///<param name="colorTemp">Color temperature for the light in mireds.</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">Number indicating brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="brightnessPct">Number indicating percentage of full brightness, where 0 turns the light off, 1 is the minimum brightness and 100 is the maximum brightness supported by the light.</param>
		///<param name="brightnessStep">Change brightness by an amount.</param>
		///<param name="brightnessStepPct">Change brightness by a percentage.</param>
		///<param name="white">Set the light to white mode and change its brightness, where 0 turns the light off, 1 is the minimum brightness and 255 is the maximum brightness supported by the light.</param>
		///<param name="profile">Name of a light profile to use. eg: relax</param>
		///<param name="flash">If the light should flash.</param>
		///<param name="effect">Light effect.</param>
		public static void TurnOn(this IEnumerable<LightEntity> target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, object? @colorName = null, object? @hsColor = null, object? @xyColor = null, object? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, object? @flash = null, string? @effect = null)
		{
			target.CallService("turn_on", new LightTurnOnParameters{Transition = @transition, RgbColor = @rgbColor, RgbwColor = @rgbwColor, RgbwwColor = @rgbwwColor, ColorName = @colorName, HsColor = @hsColor, XyColor = @xyColor, ColorTemp = @colorTemp, Kelvin = @kelvin, Brightness = @brightness, BrightnessPct = @brightnessPct, BrightnessStep = @brightnessStep, BrightnessStepPct = @brightnessStepPct, White = @white, Profile = @profile, Flash = @flash, Effect = @effect});
		}
	}

	public static class MediaPlayerEntityExtensionMethods
	{
		///<summary>Send the media player the command to clear players playlist.</summary>
		public static void ClearPlaylist(this MediaPlayerEntity target)
		{
			target.CallService("clear_playlist");
		}

		///<summary>Send the media player the command to clear players playlist.</summary>
		public static void ClearPlaylist(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("clear_playlist");
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		public static void Join(this MediaPlayerEntity target, MediaPlayerJoinParameters data)
		{
			target.CallService("join", data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		public static void Join(this IEnumerable<MediaPlayerEntity> target, MediaPlayerJoinParameters data)
		{
			target.CallService("join", data);
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: ["media_player.multiroom_player2","media_player.multiroom_player3"]</param>
		public static void Join(this MediaPlayerEntity target, object? @groupMembers = null)
		{
			target.CallService("join", new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Group players together. Only works on platforms with support for player groups.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="groupMembers">The players which will be synced with the target player. eg: ["media_player.multiroom_player2","media_player.multiroom_player3"]</param>
		public static void Join(this IEnumerable<MediaPlayerEntity> target, object? @groupMembers = null)
		{
			target.CallService("join", new MediaPlayerJoinParameters{GroupMembers = @groupMembers});
		}

		///<summary>Send the media player the command for next track.</summary>
		public static void MediaNextTrack(this MediaPlayerEntity target)
		{
			target.CallService("media_next_track");
		}

		///<summary>Send the media player the command for next track.</summary>
		public static void MediaNextTrack(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_next_track");
		}

		///<summary>Send the media player the command for pause.</summary>
		public static void MediaPause(this MediaPlayerEntity target)
		{
			target.CallService("media_pause");
		}

		///<summary>Send the media player the command for pause.</summary>
		public static void MediaPause(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_pause");
		}

		///<summary>Send the media player the command for play.</summary>
		public static void MediaPlay(this MediaPlayerEntity target)
		{
			target.CallService("media_play");
		}

		///<summary>Send the media player the command for play.</summary>
		public static void MediaPlay(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_play");
		}

		///<summary>Toggle media player play/pause state.</summary>
		public static void MediaPlayPause(this MediaPlayerEntity target)
		{
			target.CallService("media_play_pause");
		}

		///<summary>Toggle media player play/pause state.</summary>
		public static void MediaPlayPause(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_play_pause");
		}

		///<summary>Send the media player the command for previous track.</summary>
		public static void MediaPreviousTrack(this MediaPlayerEntity target)
		{
			target.CallService("media_previous_track");
		}

		///<summary>Send the media player the command for previous track.</summary>
		public static void MediaPreviousTrack(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_previous_track");
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		public static void MediaSeek(this MediaPlayerEntity target, MediaPlayerMediaSeekParameters data)
		{
			target.CallService("media_seek", data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		public static void MediaSeek(this IEnumerable<MediaPlayerEntity> target, MediaPlayerMediaSeekParameters data)
		{
			target.CallService("media_seek", data);
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public static void MediaSeek(this MediaPlayerEntity target, double @seekPosition)
		{
			target.CallService("media_seek", new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the command to seek in current playing media.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="seekPosition">Position to seek to. The format is platform dependent.</param>
		public static void MediaSeek(this IEnumerable<MediaPlayerEntity> target, double @seekPosition)
		{
			target.CallService("media_seek", new MediaPlayerMediaSeekParameters{SeekPosition = @seekPosition});
		}

		///<summary>Send the media player the stop command.</summary>
		public static void MediaStop(this MediaPlayerEntity target)
		{
			target.CallService("media_stop");
		}

		///<summary>Send the media player the stop command.</summary>
		public static void MediaStop(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("media_stop");
		}

		///<summary>Send the media player the command for playing media.</summary>
		public static void PlayMedia(this MediaPlayerEntity target, MediaPlayerPlayMediaParameters data)
		{
			target.CallService("play_media", data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		public static void PlayMedia(this IEnumerable<MediaPlayerEntity> target, MediaPlayerPlayMediaParameters data)
		{
			target.CallService("play_media", data);
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public static void PlayMedia(this MediaPlayerEntity target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			target.CallService("play_media", new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Send the media player the command for playing media.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="mediaContentId">The ID of the content to play. Platform dependent. eg: https://home-assistant.io/images/cast/splash.png</param>
		///<param name="mediaContentType">The type of the content to play. Like image, music, tvshow, video, episode, channel or playlist. eg: music</param>
		///<param name="enqueue">If the content should be played now or be added to the queue.</param>
		///<param name="announce">If the media should be played as an announcement. eg: true</param>
		public static void PlayMedia(this IEnumerable<MediaPlayerEntity> target, string @mediaContentId, string @mediaContentType, object? @enqueue = null, bool? @announce = null)
		{
			target.CallService("play_media", new MediaPlayerPlayMediaParameters{MediaContentId = @mediaContentId, MediaContentType = @mediaContentType, Enqueue = @enqueue, Announce = @announce});
		}

		///<summary>Set repeat mode</summary>
		public static void RepeatSet(this MediaPlayerEntity target, MediaPlayerRepeatSetParameters data)
		{
			target.CallService("repeat_set", data);
		}

		///<summary>Set repeat mode</summary>
		public static void RepeatSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerRepeatSetParameters data)
		{
			target.CallService("repeat_set", data);
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="repeat">Repeat mode to set.</param>
		public static void RepeatSet(this MediaPlayerEntity target, object @repeat)
		{
			target.CallService("repeat_set", new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Set repeat mode</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="repeat">Repeat mode to set.</param>
		public static void RepeatSet(this IEnumerable<MediaPlayerEntity> target, object @repeat)
		{
			target.CallService("repeat_set", new MediaPlayerRepeatSetParameters{Repeat = @repeat});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		public static void SelectSoundMode(this MediaPlayerEntity target, MediaPlayerSelectSoundModeParameters data)
		{
			target.CallService("select_sound_mode", data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		public static void SelectSoundMode(this IEnumerable<MediaPlayerEntity> target, MediaPlayerSelectSoundModeParameters data)
		{
			target.CallService("select_sound_mode", data);
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public static void SelectSoundMode(this MediaPlayerEntity target, string? @soundMode = null)
		{
			target.CallService("select_sound_mode", new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change sound mode.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="soundMode">Name of the sound mode to switch to. eg: Music</param>
		public static void SelectSoundMode(this IEnumerable<MediaPlayerEntity> target, string? @soundMode = null)
		{
			target.CallService("select_sound_mode", new MediaPlayerSelectSoundModeParameters{SoundMode = @soundMode});
		}

		///<summary>Send the media player the command to change input source.</summary>
		public static void SelectSource(this MediaPlayerEntity target, MediaPlayerSelectSourceParameters data)
		{
			target.CallService("select_source", data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		public static void SelectSource(this IEnumerable<MediaPlayerEntity> target, MediaPlayerSelectSourceParameters data)
		{
			target.CallService("select_source", data);
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public static void SelectSource(this MediaPlayerEntity target, string @source)
		{
			target.CallService("select_source", new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Send the media player the command to change input source.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="source">Name of the source to switch to. Platform dependent. eg: video1</param>
		public static void SelectSource(this IEnumerable<MediaPlayerEntity> target, string @source)
		{
			target.CallService("select_source", new MediaPlayerSelectSourceParameters{Source = @source});
		}

		///<summary>Set shuffling state.</summary>
		public static void ShuffleSet(this MediaPlayerEntity target, MediaPlayerShuffleSetParameters data)
		{
			target.CallService("shuffle_set", data);
		}

		///<summary>Set shuffling state.</summary>
		public static void ShuffleSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerShuffleSetParameters data)
		{
			target.CallService("shuffle_set", data);
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public static void ShuffleSet(this MediaPlayerEntity target, bool @shuffle)
		{
			target.CallService("shuffle_set", new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Set shuffling state.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="shuffle">True/false for enabling/disabling shuffle.</param>
		public static void ShuffleSet(this IEnumerable<MediaPlayerEntity> target, bool @shuffle)
		{
			target.CallService("shuffle_set", new MediaPlayerShuffleSetParameters{Shuffle = @shuffle});
		}

		///<summary>Toggles a media player power state.</summary>
		public static void Toggle(this MediaPlayerEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggles a media player power state.</summary>
		public static void Toggle(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn a media player power off.</summary>
		public static void TurnOff(this MediaPlayerEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a media player power off.</summary>
		public static void TurnOff(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a media player power on.</summary>
		public static void TurnOn(this MediaPlayerEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn a media player power on.</summary>
		public static void TurnOn(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("turn_on");
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		public static void Unjoin(this MediaPlayerEntity target)
		{
			target.CallService("unjoin");
		}

		///<summary>Unjoin the player from a group. Only works on platforms with support for player groups.</summary>
		public static void Unjoin(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("unjoin");
		}

		///<summary>Turn a media player volume down.</summary>
		public static void VolumeDown(this MediaPlayerEntity target)
		{
			target.CallService("volume_down");
		}

		///<summary>Turn a media player volume down.</summary>
		public static void VolumeDown(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("volume_down");
		}

		///<summary>Mute a media player's volume.</summary>
		public static void VolumeMute(this MediaPlayerEntity target, MediaPlayerVolumeMuteParameters data)
		{
			target.CallService("volume_mute", data);
		}

		///<summary>Mute a media player's volume.</summary>
		public static void VolumeMute(this IEnumerable<MediaPlayerEntity> target, MediaPlayerVolumeMuteParameters data)
		{
			target.CallService("volume_mute", data);
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public static void VolumeMute(this MediaPlayerEntity target, bool @isVolumeMuted)
		{
			target.CallService("volume_mute", new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Mute a media player's volume.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="isVolumeMuted">True/false for mute/unmute.</param>
		public static void VolumeMute(this IEnumerable<MediaPlayerEntity> target, bool @isVolumeMuted)
		{
			target.CallService("volume_mute", new MediaPlayerVolumeMuteParameters{IsVolumeMuted = @isVolumeMuted});
		}

		///<summary>Set a media player's volume level.</summary>
		public static void VolumeSet(this MediaPlayerEntity target, MediaPlayerVolumeSetParameters data)
		{
			target.CallService("volume_set", data);
		}

		///<summary>Set a media player's volume level.</summary>
		public static void VolumeSet(this IEnumerable<MediaPlayerEntity> target, MediaPlayerVolumeSetParameters data)
		{
			target.CallService("volume_set", data);
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public static void VolumeSet(this MediaPlayerEntity target, double @volumeLevel)
		{
			target.CallService("volume_set", new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Set a media player's volume level.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="volumeLevel">Volume level to set as float.</param>
		public static void VolumeSet(this IEnumerable<MediaPlayerEntity> target, double @volumeLevel)
		{
			target.CallService("volume_set", new MediaPlayerVolumeSetParameters{VolumeLevel = @volumeLevel});
		}

		///<summary>Turn a media player volume up.</summary>
		public static void VolumeUp(this MediaPlayerEntity target)
		{
			target.CallService("volume_up");
		}

		///<summary>Turn a media player volume up.</summary>
		public static void VolumeUp(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("volume_up");
		}
	}

	public static class NeatoEntityExtensionMethods
	{
		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		public static void CustomCleaning(this VacuumEntity target, NeatoCustomCleaningParameters data)
		{
			target.CallService("custom_cleaning", data);
		}

		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		public static void CustomCleaning(this IEnumerable<VacuumEntity> target, NeatoCustomCleaningParameters data)
		{
			target.CallService("custom_cleaning", data);
		}

		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		///<param name="target">The VacuumEntity to call this service for</param>
		///<param name="mode">Set the cleaning mode: 1 for eco and 2 for turbo. Defaults to turbo if not set.</param>
		///<param name="navigation">Set the navigation mode: 1 for normal, 2 for extra care, 3 for deep. Defaults to normal if not set.</param>
		///<param name="category">Whether to use a persistent map or not for cleaning (i.e. No go lines): 2 for no map, 4 for map. Default to using map if not set (and fallback to no map if no map is found).</param>
		///<param name="zone">Only supported on the Botvac D7. Name of the zone to clean. Defaults to no zone i.e. complete house cleanup. eg: Kitchen</param>
		public static void CustomCleaning(this VacuumEntity target, long? @mode = null, long? @navigation = null, long? @category = null, string? @zone = null)
		{
			target.CallService("custom_cleaning", new NeatoCustomCleaningParameters{Mode = @mode, Navigation = @navigation, Category = @category, Zone = @zone});
		}

		///<summary>Zone Cleaning service call specific to Neato Botvacs.</summary>
		///<param name="target">The IEnumerable<VacuumEntity> to call this service for</param>
		///<param name="mode">Set the cleaning mode: 1 for eco and 2 for turbo. Defaults to turbo if not set.</param>
		///<param name="navigation">Set the navigation mode: 1 for normal, 2 for extra care, 3 for deep. Defaults to normal if not set.</param>
		///<param name="category">Whether to use a persistent map or not for cleaning (i.e. No go lines): 2 for no map, 4 for map. Default to using map if not set (and fallback to no map if no map is found).</param>
		///<param name="zone">Only supported on the Botvac D7. Name of the zone to clean. Defaults to no zone i.e. complete house cleanup. eg: Kitchen</param>
		public static void CustomCleaning(this IEnumerable<VacuumEntity> target, long? @mode = null, long? @navigation = null, long? @category = null, string? @zone = null)
		{
			target.CallService("custom_cleaning", new NeatoCustomCleaningParameters{Mode = @mode, Navigation = @navigation, Category = @category, Zone = @zone});
		}
	}

	public static class NumberEntityExtensionMethods
	{
		///<summary>Set the value of a Number entity.</summary>
		public static void SetValue(this NumberEntity target, NumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of a Number entity.</summary>
		public static void SetValue(this IEnumerable<NumberEntity> target, NumberSetValueParameters data)
		{
			target.CallService("set_value", data);
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The NumberEntity to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public static void SetValue(this NumberEntity target, string? @value = null)
		{
			target.CallService("set_value", new NumberSetValueParameters{Value = @value});
		}

		///<summary>Set the value of a Number entity.</summary>
		///<param name="target">The IEnumerable<NumberEntity> to call this service for</param>
		///<param name="value">The target value the entity should be set to. eg: 42</param>
		public static void SetValue(this IEnumerable<NumberEntity> target, string? @value = null)
		{
			target.CallService("set_value", new NumberSetValueParameters{Value = @value});
		}
	}

	public static class OnvifEntityExtensionMethods
	{
		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		public static void Ptz(this CameraEntity target, OnvifPtzParameters data)
		{
			target.CallService("ptz", data);
		}

		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		public static void Ptz(this IEnumerable<CameraEntity> target, OnvifPtzParameters data)
		{
			target.CallService("ptz", data);
		}

		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		///<param name="target">The CameraEntity to call this service for</param>
		///<param name="tilt">Tilt direction.</param>
		///<param name="pan">Pan direction.</param>
		///<param name="zoom">Zoom.</param>
		///<param name="distance">Distance coefficient. Sets how much PTZ should be executed in one request.</param>
		///<param name="speed">Speed coefficient. Sets how fast PTZ will be executed.</param>
		///<param name="continuousDuration">Set ContinuousMove delay in seconds before stopping the move</param>
		///<param name="preset">PTZ preset profile token. Sets the preset profile token which is executed with GotoPreset eg: 1</param>
		///<param name="moveMode">PTZ moving mode.</param>
		public static void Ptz(this CameraEntity target, object? @tilt = null, object? @pan = null, object? @zoom = null, double? @distance = null, double? @speed = null, double? @continuousDuration = null, string? @preset = null, object? @moveMode = null)
		{
			target.CallService("ptz", new OnvifPtzParameters{Tilt = @tilt, Pan = @pan, Zoom = @zoom, Distance = @distance, Speed = @speed, ContinuousDuration = @continuousDuration, Preset = @preset, MoveMode = @moveMode});
		}

		///<summary>If your ONVIF camera supports PTZ, you will be able to pan, tilt or zoom your camera.</summary>
		///<param name="target">The IEnumerable<CameraEntity> to call this service for</param>
		///<param name="tilt">Tilt direction.</param>
		///<param name="pan">Pan direction.</param>
		///<param name="zoom">Zoom.</param>
		///<param name="distance">Distance coefficient. Sets how much PTZ should be executed in one request.</param>
		///<param name="speed">Speed coefficient. Sets how fast PTZ will be executed.</param>
		///<param name="continuousDuration">Set ContinuousMove delay in seconds before stopping the move</param>
		///<param name="preset">PTZ preset profile token. Sets the preset profile token which is executed with GotoPreset eg: 1</param>
		///<param name="moveMode">PTZ moving mode.</param>
		public static void Ptz(this IEnumerable<CameraEntity> target, object? @tilt = null, object? @pan = null, object? @zoom = null, double? @distance = null, double? @speed = null, double? @continuousDuration = null, string? @preset = null, object? @moveMode = null)
		{
			target.CallService("ptz", new OnvifPtzParameters{Tilt = @tilt, Pan = @pan, Zoom = @zoom, Distance = @distance, Speed = @speed, ContinuousDuration = @continuousDuration, Preset = @preset, MoveMode = @moveMode});
		}
	}

	public static class RemoteEntityExtensionMethods
	{
		///<summary>Deletes a command or a list of commands from the database.</summary>
		public static void DeleteCommand(this RemoteEntity target, RemoteDeleteCommandParameters data)
		{
			target.CallService("delete_command", data);
		}

		///<summary>Deletes a command or a list of commands from the database.</summary>
		public static void DeleteCommand(this IEnumerable<RemoteEntity> target, RemoteDeleteCommandParameters data)
		{
			target.CallService("delete_command", data);
		}

		///<summary>Deletes a command or a list of commands from the database.</summary>
		///<param name="target">The RemoteEntity to call this service for</param>
		///<param name="device">Name of the device from which commands will be deleted. eg: television</param>
		///<param name="command">A single command or a list of commands to delete. eg: Mute</param>
		public static void DeleteCommand(this RemoteEntity target, object @command, string? @device = null)
		{
			target.CallService("delete_command", new RemoteDeleteCommandParameters{Device = @device, Command = @command});
		}

		///<summary>Deletes a command or a list of commands from the database.</summary>
		///<param name="target">The IEnumerable<RemoteEntity> to call this service for</param>
		///<param name="device">Name of the device from which commands will be deleted. eg: television</param>
		///<param name="command">A single command or a list of commands to delete. eg: Mute</param>
		public static void DeleteCommand(this IEnumerable<RemoteEntity> target, object @command, string? @device = null)
		{
			target.CallService("delete_command", new RemoteDeleteCommandParameters{Device = @device, Command = @command});
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		public static void LearnCommand(this RemoteEntity target, RemoteLearnCommandParameters data)
		{
			target.CallService("learn_command", data);
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		public static void LearnCommand(this IEnumerable<RemoteEntity> target, RemoteLearnCommandParameters data)
		{
			target.CallService("learn_command", data);
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		///<param name="target">The RemoteEntity to call this service for</param>
		///<param name="device">Device ID to learn command from. eg: television</param>
		///<param name="command">A single command or a list of commands to learn. eg: Turn on</param>
		///<param name="commandType">The type of command to be learned.</param>
		///<param name="alternative">If code must be stored as alternative (useful for discrete remotes).</param>
		///<param name="timeout">Timeout for the command to be learned.</param>
		public static void LearnCommand(this RemoteEntity target, string? @device = null, object? @command = null, object? @commandType = null, bool? @alternative = null, long? @timeout = null)
		{
			target.CallService("learn_command", new RemoteLearnCommandParameters{Device = @device, Command = @command, CommandType = @commandType, Alternative = @alternative, Timeout = @timeout});
		}

		///<summary>Learns a command or a list of commands from a device.</summary>
		///<param name="target">The IEnumerable<RemoteEntity> to call this service for</param>
		///<param name="device">Device ID to learn command from. eg: television</param>
		///<param name="command">A single command or a list of commands to learn. eg: Turn on</param>
		///<param name="commandType">The type of command to be learned.</param>
		///<param name="alternative">If code must be stored as alternative (useful for discrete remotes).</param>
		///<param name="timeout">Timeout for the command to be learned.</param>
		public static void LearnCommand(this IEnumerable<RemoteEntity> target, string? @device = null, object? @command = null, object? @commandType = null, bool? @alternative = null, long? @timeout = null)
		{
			target.CallService("learn_command", new RemoteLearnCommandParameters{Device = @device, Command = @command, CommandType = @commandType, Alternative = @alternative, Timeout = @timeout});
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		public static void SendCommand(this RemoteEntity target, RemoteSendCommandParameters data)
		{
			target.CallService("send_command", data);
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		public static void SendCommand(this IEnumerable<RemoteEntity> target, RemoteSendCommandParameters data)
		{
			target.CallService("send_command", data);
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		///<param name="target">The RemoteEntity to call this service for</param>
		///<param name="device">Device ID to send command to. eg: 32756745</param>
		///<param name="command">A single command or a list of commands to send. eg: Play</param>
		///<param name="numRepeats">The number of times you want to repeat the command(s).</param>
		///<param name="delaySecs">The time you want to wait in between repeated commands.</param>
		///<param name="holdSecs">The time you want to have it held before the release is send.</param>
		public static void SendCommand(this RemoteEntity target, object @command, string? @device = null, long? @numRepeats = null, double? @delaySecs = null, double? @holdSecs = null)
		{
			target.CallService("send_command", new RemoteSendCommandParameters{Device = @device, Command = @command, NumRepeats = @numRepeats, DelaySecs = @delaySecs, HoldSecs = @holdSecs});
		}

		///<summary>Sends a command or a list of commands to a device.</summary>
		///<param name="target">The IEnumerable<RemoteEntity> to call this service for</param>
		///<param name="device">Device ID to send command to. eg: 32756745</param>
		///<param name="command">A single command or a list of commands to send. eg: Play</param>
		///<param name="numRepeats">The number of times you want to repeat the command(s).</param>
		///<param name="delaySecs">The time you want to wait in between repeated commands.</param>
		///<param name="holdSecs">The time you want to have it held before the release is send.</param>
		public static void SendCommand(this IEnumerable<RemoteEntity> target, object @command, string? @device = null, long? @numRepeats = null, double? @delaySecs = null, double? @holdSecs = null)
		{
			target.CallService("send_command", new RemoteSendCommandParameters{Device = @device, Command = @command, NumRepeats = @numRepeats, DelaySecs = @delaySecs, HoldSecs = @holdSecs});
		}

		///<summary>Toggles a device.</summary>
		public static void Toggle(this RemoteEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggles a device.</summary>
		public static void Toggle(this IEnumerable<RemoteEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Sends the Power Off Command.</summary>
		public static void TurnOff(this RemoteEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Sends the Power Off Command.</summary>
		public static void TurnOff(this IEnumerable<RemoteEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Sends the Power On Command.</summary>
		public static void TurnOn(this RemoteEntity target, RemoteTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Sends the Power On Command.</summary>
		public static void TurnOn(this IEnumerable<RemoteEntity> target, RemoteTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Sends the Power On Command.</summary>
		///<param name="target">The RemoteEntity to call this service for</param>
		///<param name="activity">Activity ID or Activity Name to start. eg: BedroomTV</param>
		public static void TurnOn(this RemoteEntity target, string? @activity = null)
		{
			target.CallService("turn_on", new RemoteTurnOnParameters{Activity = @activity});
		}

		///<summary>Sends the Power On Command.</summary>
		///<param name="target">The IEnumerable<RemoteEntity> to call this service for</param>
		///<param name="activity">Activity ID or Activity Name to start. eg: BedroomTV</param>
		public static void TurnOn(this IEnumerable<RemoteEntity> target, string? @activity = null)
		{
			target.CallService("turn_on", new RemoteTurnOnParameters{Activity = @activity});
		}
	}

	public static class SceneEntityExtensionMethods
	{
		///<summary>Activate a scene.</summary>
		public static void TurnOn(this SceneEntity target, SceneTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Activate a scene.</summary>
		public static void TurnOn(this IEnumerable<SceneEntity> target, SceneTurnOnParameters data)
		{
			target.CallService("turn_on", data);
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The SceneEntity to call this service for</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public static void TurnOn(this SceneEntity target, long? @transition = null)
		{
			target.CallService("turn_on", new SceneTurnOnParameters{Transition = @transition});
		}

		///<summary>Activate a scene.</summary>
		///<param name="target">The IEnumerable<SceneEntity> to call this service for</param>
		///<param name="transition">Transition duration it takes to bring devices to the state defined in the scene.</param>
		public static void TurnOn(this IEnumerable<SceneEntity> target, long? @transition = null)
		{
			target.CallService("turn_on", new SceneTurnOnParameters{Transition = @transition});
		}
	}

	public static class ScriptEntityExtensionMethods
	{
		///<summary>Toggle script</summary>
		public static void Toggle(this ScriptEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggle script</summary>
		public static void Toggle(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn off script</summary>
		public static void TurnOff(this ScriptEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn off script</summary>
		public static void TurnOff(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn on script</summary>
		public static void TurnOn(this ScriptEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn on script</summary>
		public static void TurnOn(this IEnumerable<ScriptEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class SelectEntityExtensionMethods
	{
		///<summary>Select an option of an select entity.</summary>
		public static void SelectOption(this SelectEntity target, SelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an select entity.</summary>
		public static void SelectOption(this IEnumerable<SelectEntity> target, SelectSelectOptionParameters data)
		{
			target.CallService("select_option", data);
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The SelectEntity to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this SelectEntity target, string @option)
		{
			target.CallService("select_option", new SelectSelectOptionParameters{Option = @option});
		}

		///<summary>Select an option of an select entity.</summary>
		///<param name="target">The IEnumerable<SelectEntity> to call this service for</param>
		///<param name="option">Option to be selected. eg: "Item A"</param>
		public static void SelectOption(this IEnumerable<SelectEntity> target, string @option)
		{
			target.CallService("select_option", new SelectSelectOptionParameters{Option = @option});
		}
	}

	public static class SqueezeboxEntityExtensionMethods
	{
		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		public static void CallMethod(this MediaPlayerEntity target, SqueezeboxCallMethodParameters data)
		{
			target.CallService("call_method", data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		public static void CallMethod(this IEnumerable<MediaPlayerEntity> target, SqueezeboxCallMethodParameters data)
		{
			target.CallService("call_method", data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: playlist</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["loadtracks", "album.titlesearch=Revolver"]</param>
		public static void CallMethod(this MediaPlayerEntity target, string @command, object? @parameters = null)
		{
			target.CallService("call_method", new SqueezeboxCallMethodParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Call a custom Squeezebox JSONRPC API.</summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: playlist</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["loadtracks", "album.titlesearch=Revolver"]</param>
		public static void CallMethod(this IEnumerable<MediaPlayerEntity> target, string @command, object? @parameters = null)
		{
			target.CallService("call_method", new SqueezeboxCallMethodParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		public static void CallQuery(this MediaPlayerEntity target, SqueezeboxCallQueryParameters data)
		{
			target.CallService("call_query", data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		public static void CallQuery(this IEnumerable<MediaPlayerEntity> target, SqueezeboxCallQueryParameters data)
		{
			target.CallService("call_query", data);
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: albums</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["0", "20", "search:Revolver"]</param>
		public static void CallQuery(this MediaPlayerEntity target, string @command, object? @parameters = null)
		{
			target.CallService("call_query", new SqueezeboxCallQueryParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Call a custom Squeezebox JSONRPC API. Result will be stored in 'query_result' attribute of the Squeezebox entity. </summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="command">Command to pass to Logitech Media Server (p0 in the CLI documentation). eg: albums</param>
		///<param name="parameters">Array of additional parameters to pass to Logitech Media Server (p1, ..., pN in the CLI documentation).  eg: ["0", "20", "search:Revolver"]</param>
		public static void CallQuery(this IEnumerable<MediaPlayerEntity> target, string @command, object? @parameters = null)
		{
			target.CallService("call_query", new SqueezeboxCallQueryParameters{Command = @command, Parameters = @parameters});
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		public static void Sync(this MediaPlayerEntity target, SqueezeboxSyncParameters data)
		{
			target.CallService("sync", data);
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		public static void Sync(this IEnumerable<MediaPlayerEntity> target, SqueezeboxSyncParameters data)
		{
			target.CallService("sync", data);
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		///<param name="target">The MediaPlayerEntity to call this service for</param>
		///<param name="otherPlayer">Name of the other Squeezebox player to link. eg: media_player.living_room</param>
		public static void Sync(this MediaPlayerEntity target, string @otherPlayer)
		{
			target.CallService("sync", new SqueezeboxSyncParameters{OtherPlayer = @otherPlayer});
		}

		///<summary>Add another player to this player's sync group. If the other player is already in a sync group, it will leave it. </summary>
		///<param name="target">The IEnumerable<MediaPlayerEntity> to call this service for</param>
		///<param name="otherPlayer">Name of the other Squeezebox player to link. eg: media_player.living_room</param>
		public static void Sync(this IEnumerable<MediaPlayerEntity> target, string @otherPlayer)
		{
			target.CallService("sync", new SqueezeboxSyncParameters{OtherPlayer = @otherPlayer});
		}

		///<summary>Remove this player from its sync group.</summary>
		public static void Unsync(this MediaPlayerEntity target)
		{
			target.CallService("unsync");
		}

		///<summary>Remove this player from its sync group.</summary>
		public static void Unsync(this IEnumerable<MediaPlayerEntity> target)
		{
			target.CallService("unsync");
		}
	}

	public static class SwitchEntityExtensionMethods
	{
		///<summary>Toggles a switch state</summary>
		public static void Toggle(this SwitchEntity target)
		{
			target.CallService("toggle");
		}

		///<summary>Toggles a switch state</summary>
		public static void Toggle(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("toggle");
		}

		///<summary>Turn a switch off</summary>
		public static void TurnOff(this SwitchEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a switch off</summary>
		public static void TurnOff(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Turn a switch on</summary>
		public static void TurnOn(this SwitchEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Turn a switch on</summary>
		public static void TurnOn(this IEnumerable<SwitchEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class TimerEntityExtensionMethods
	{
		///<summary>Cancel a timer.</summary>
		public static void Cancel(this TimerEntity target)
		{
			target.CallService("cancel");
		}

		///<summary>Cancel a timer.</summary>
		public static void Cancel(this IEnumerable<TimerEntity> target)
		{
			target.CallService("cancel");
		}

		///<summary>Finish a timer.</summary>
		public static void Finish(this TimerEntity target)
		{
			target.CallService("finish");
		}

		///<summary>Finish a timer.</summary>
		public static void Finish(this IEnumerable<TimerEntity> target)
		{
			target.CallService("finish");
		}

		///<summary>Pause a timer.</summary>
		public static void Pause(this TimerEntity target)
		{
			target.CallService("pause");
		}

		///<summary>Pause a timer.</summary>
		public static void Pause(this IEnumerable<TimerEntity> target)
		{
			target.CallService("pause");
		}

		///<summary>Start a timer</summary>
		public static void Start(this TimerEntity target, TimerStartParameters data)
		{
			target.CallService("start", data);
		}

		///<summary>Start a timer</summary>
		public static void Start(this IEnumerable<TimerEntity> target, TimerStartParameters data)
		{
			target.CallService("start", data);
		}

		///<summary>Start a timer</summary>
		///<param name="target">The TimerEntity to call this service for</param>
		///<param name="duration">Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</param>
		public static void Start(this TimerEntity target, string? @duration = null)
		{
			target.CallService("start", new TimerStartParameters{Duration = @duration});
		}

		///<summary>Start a timer</summary>
		///<param name="target">The IEnumerable<TimerEntity> to call this service for</param>
		///<param name="duration">Duration the timer requires to finish. [optional] eg: 00:01:00 or 60</param>
		public static void Start(this IEnumerable<TimerEntity> target, string? @duration = null)
		{
			target.CallService("start", new TimerStartParameters{Duration = @duration});
		}
	}

	public static class UpdateEntityExtensionMethods
	{
		///<summary>Removes the skipped version marker from an update.</summary>
		public static void ClearSkipped(this UpdateEntity target)
		{
			target.CallService("clear_skipped");
		}

		///<summary>Removes the skipped version marker from an update.</summary>
		public static void ClearSkipped(this IEnumerable<UpdateEntity> target)
		{
			target.CallService("clear_skipped");
		}

		///<summary>Install an update for this device or service</summary>
		public static void Install(this UpdateEntity target, UpdateInstallParameters data)
		{
			target.CallService("install", data);
		}

		///<summary>Install an update for this device or service</summary>
		public static void Install(this IEnumerable<UpdateEntity> target, UpdateInstallParameters data)
		{
			target.CallService("install", data);
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The UpdateEntity to call this service for</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public static void Install(this UpdateEntity target, string? @version = null, bool? @backup = null)
		{
			target.CallService("install", new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Install an update for this device or service</summary>
		///<param name="target">The IEnumerable<UpdateEntity> to call this service for</param>
		///<param name="version">Version to install, if omitted, the latest version will be installed. eg: 1.0.0</param>
		///<param name="backup">Backup before installing the update, if supported by the integration.</param>
		public static void Install(this IEnumerable<UpdateEntity> target, string? @version = null, bool? @backup = null)
		{
			target.CallService("install", new UpdateInstallParameters{Version = @version, Backup = @backup});
		}

		///<summary>Mark currently available update as skipped.</summary>
		public static void Skip(this UpdateEntity target)
		{
			target.CallService("skip");
		}

		///<summary>Mark currently available update as skipped.</summary>
		public static void Skip(this IEnumerable<UpdateEntity> target)
		{
			target.CallService("skip");
		}
	}

	public static class VacuumEntityExtensionMethods
	{
		///<summary>Tell the vacuum cleaner to do a spot clean-up.</summary>
		public static void CleanSpot(this VacuumEntity target)
		{
			target.CallService("clean_spot");
		}

		///<summary>Tell the vacuum cleaner to do a spot clean-up.</summary>
		public static void CleanSpot(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("clean_spot");
		}

		///<summary>Locate the vacuum cleaner robot.</summary>
		public static void Locate(this VacuumEntity target)
		{
			target.CallService("locate");
		}

		///<summary>Locate the vacuum cleaner robot.</summary>
		public static void Locate(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("locate");
		}

		///<summary>Pause the cleaning task.</summary>
		public static void Pause(this VacuumEntity target)
		{
			target.CallService("pause");
		}

		///<summary>Pause the cleaning task.</summary>
		public static void Pause(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("pause");
		}

		///<summary>Tell the vacuum cleaner to return to its dock.</summary>
		public static void ReturnToBase(this VacuumEntity target)
		{
			target.CallService("return_to_base");
		}

		///<summary>Tell the vacuum cleaner to return to its dock.</summary>
		public static void ReturnToBase(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("return_to_base");
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		public static void SendCommand(this VacuumEntity target, VacuumSendCommandParameters data)
		{
			target.CallService("send_command", data);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		public static void SendCommand(this IEnumerable<VacuumEntity> target, VacuumSendCommandParameters data)
		{
			target.CallService("send_command", data);
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The VacuumEntity to call this service for</param>
		///<param name="command">Command to execute. eg: set_dnd_timer</param>
		///<param name="params">Parameters for the command. eg: { "key": "value" }</param>
		public static void SendCommand(this VacuumEntity target, string @command, object? @params = null)
		{
			target.CallService("send_command", new VacuumSendCommandParameters{Command = @command, Params = @params});
		}

		///<summary>Send a raw command to the vacuum cleaner.</summary>
		///<param name="target">The IEnumerable<VacuumEntity> to call this service for</param>
		///<param name="command">Command to execute. eg: set_dnd_timer</param>
		///<param name="params">Parameters for the command. eg: { "key": "value" }</param>
		public static void SendCommand(this IEnumerable<VacuumEntity> target, string @command, object? @params = null)
		{
			target.CallService("send_command", new VacuumSendCommandParameters{Command = @command, Params = @params});
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		public static void SetFanSpeed(this VacuumEntity target, VacuumSetFanSpeedParameters data)
		{
			target.CallService("set_fan_speed", data);
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		public static void SetFanSpeed(this IEnumerable<VacuumEntity> target, VacuumSetFanSpeedParameters data)
		{
			target.CallService("set_fan_speed", data);
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The VacuumEntity to call this service for</param>
		///<param name="fanSpeed">Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</param>
		public static void SetFanSpeed(this VacuumEntity target, string @fanSpeed)
		{
			target.CallService("set_fan_speed", new VacuumSetFanSpeedParameters{FanSpeed = @fanSpeed});
		}

		///<summary>Set the fan speed of the vacuum cleaner.</summary>
		///<param name="target">The IEnumerable<VacuumEntity> to call this service for</param>
		///<param name="fanSpeed">Platform dependent vacuum cleaner fan speed, with speed steps, like 'medium' or by percentage, between 0 and 100. eg: low</param>
		public static void SetFanSpeed(this IEnumerable<VacuumEntity> target, string @fanSpeed)
		{
			target.CallService("set_fan_speed", new VacuumSetFanSpeedParameters{FanSpeed = @fanSpeed});
		}

		///<summary>Start or resume the cleaning task.</summary>
		public static void Start(this VacuumEntity target)
		{
			target.CallService("start");
		}

		///<summary>Start or resume the cleaning task.</summary>
		public static void Start(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("start");
		}

		///<summary>Start, pause, or resume the cleaning task.</summary>
		public static void StartPause(this VacuumEntity target)
		{
			target.CallService("start_pause");
		}

		///<summary>Start, pause, or resume the cleaning task.</summary>
		public static void StartPause(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("start_pause");
		}

		///<summary>Stop the current cleaning task.</summary>
		public static void Stop(this VacuumEntity target)
		{
			target.CallService("stop");
		}

		///<summary>Stop the current cleaning task.</summary>
		public static void Stop(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("stop");
		}

		///<summary>Stop the current cleaning task and return to home.</summary>
		public static void TurnOff(this VacuumEntity target)
		{
			target.CallService("turn_off");
		}

		///<summary>Stop the current cleaning task and return to home.</summary>
		public static void TurnOff(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("turn_off");
		}

		///<summary>Start a new cleaning task.</summary>
		public static void TurnOn(this VacuumEntity target)
		{
			target.CallService("turn_on");
		}

		///<summary>Start a new cleaning task.</summary>
		public static void TurnOn(this IEnumerable<VacuumEntity> target)
		{
			target.CallService("turn_on");
		}
	}

	public static class YeelightEntityExtensionMethods
	{
		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		public static void SetAutoDelayOffScene(this LightEntity target, YeelightSetAutoDelayOffSceneParameters data)
		{
			target.CallService("set_auto_delay_off_scene", data);
		}

		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		public static void SetAutoDelayOffScene(this IEnumerable<LightEntity> target, YeelightSetAutoDelayOffSceneParameters data)
		{
			target.CallService("set_auto_delay_off_scene", data);
		}

		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="minutes">The time to wait before automatically turning the light off.</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetAutoDelayOffScene(this LightEntity target, long? @minutes = null, long? @brightness = null)
		{
			target.CallService("set_auto_delay_off_scene", new YeelightSetAutoDelayOffSceneParameters{Minutes = @minutes, Brightness = @brightness});
		}

		///<summary>Turns the light on to the specified brightness and sets a timer to turn it back off after the given number of minutes. If the light is off, Set a color scene, if light is off, it will be turned on.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="minutes">The time to wait before automatically turning the light off.</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetAutoDelayOffScene(this IEnumerable<LightEntity> target, long? @minutes = null, long? @brightness = null)
		{
			target.CallService("set_auto_delay_off_scene", new YeelightSetAutoDelayOffSceneParameters{Minutes = @minutes, Brightness = @brightness});
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		public static void SetColorFlowScene(this LightEntity target, YeelightSetColorFlowSceneParameters data)
		{
			target.CallService("set_color_flow_scene", data);
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		public static void SetColorFlowScene(this IEnumerable<LightEntity> target, YeelightSetColorFlowSceneParameters data)
		{
			target.CallService("set_color_flow_scene", data);
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public static void SetColorFlowScene(this LightEntity target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			target.CallService("set_color_flow_scene", new YeelightSetColorFlowSceneParameters{Count = @count, Action = @action, Transitions = @transitions});
		}

		///<summary>starts a color flow. If the light is off, it will be turned on.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public static void SetColorFlowScene(this IEnumerable<LightEntity> target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			target.CallService("set_color_flow_scene", new YeelightSetColorFlowSceneParameters{Count = @count, Action = @action, Transitions = @transitions});
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		public static void SetColorScene(this LightEntity target, YeelightSetColorSceneParameters data)
		{
			target.CallService("set_color_scene", data);
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		public static void SetColorScene(this IEnumerable<LightEntity> target, YeelightSetColorSceneParameters data)
		{
			target.CallService("set_color_scene", data);
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetColorScene(this LightEntity target, object? @rgbColor = null, long? @brightness = null)
		{
			target.CallService("set_color_scene", new YeelightSetColorSceneParameters{RgbColor = @rgbColor, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified RGB color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="rgbColor">Color for the light in RGB-format. eg: [255, 100, 100]</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetColorScene(this IEnumerable<LightEntity> target, object? @rgbColor = null, long? @brightness = null)
		{
			target.CallService("set_color_scene", new YeelightSetColorSceneParameters{RgbColor = @rgbColor, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		public static void SetColorTempScene(this LightEntity target, YeelightSetColorTempSceneParameters data)
		{
			target.CallService("set_color_temp_scene", data);
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		public static void SetColorTempScene(this IEnumerable<LightEntity> target, YeelightSetColorTempSceneParameters data)
		{
			target.CallService("set_color_temp_scene", data);
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetColorTempScene(this LightEntity target, long? @kelvin = null, long? @brightness = null)
		{
			target.CallService("set_color_temp_scene", new YeelightSetColorTempSceneParameters{Kelvin = @kelvin, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified color temperature. If the light is off, it will be turned on.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="kelvin">Color temperature for the light in Kelvin.</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetColorTempScene(this IEnumerable<LightEntity> target, long? @kelvin = null, long? @brightness = null)
		{
			target.CallService("set_color_temp_scene", new YeelightSetColorTempSceneParameters{Kelvin = @kelvin, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		public static void SetHsvScene(this LightEntity target, YeelightSetHsvSceneParameters data)
		{
			target.CallService("set_hsv_scene", data);
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		public static void SetHsvScene(this IEnumerable<LightEntity> target, YeelightSetHsvSceneParameters data)
		{
			target.CallService("set_hsv_scene", data);
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-359 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetHsvScene(this LightEntity target, object? @hsColor = null, long? @brightness = null)
		{
			target.CallService("set_hsv_scene", new YeelightSetHsvSceneParameters{HsColor = @hsColor, Brightness = @brightness});
		}

		///<summary>Changes the light to the specified HSV color and brightness. If the light is off, it will be turned on.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="hsColor">Color for the light in hue/sat format. Hue is 0-359 and Sat is 0-100. eg: [300, 70]</param>
		///<param name="brightness">The brightness value to set.</param>
		public static void SetHsvScene(this IEnumerable<LightEntity> target, object? @hsColor = null, long? @brightness = null)
		{
			target.CallService("set_hsv_scene", new YeelightSetHsvSceneParameters{HsColor = @hsColor, Brightness = @brightness});
		}

		///<summary>Set a operation mode.</summary>
		public static void SetMode(this LightEntity target, YeelightSetModeParameters data)
		{
			target.CallService("set_mode", data);
		}

		///<summary>Set a operation mode.</summary>
		public static void SetMode(this IEnumerable<LightEntity> target, YeelightSetModeParameters data)
		{
			target.CallService("set_mode", data);
		}

		///<summary>Set a operation mode.</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="mode">Operation mode.</param>
		public static void SetMode(this LightEntity target, object @mode)
		{
			target.CallService("set_mode", new YeelightSetModeParameters{Mode = @mode});
		}

		///<summary>Set a operation mode.</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="mode">Operation mode.</param>
		public static void SetMode(this IEnumerable<LightEntity> target, object @mode)
		{
			target.CallService("set_mode", new YeelightSetModeParameters{Mode = @mode});
		}

		///<summary>Enable or disable music_mode</summary>
		public static void SetMusicMode(this LightEntity target, YeelightSetMusicModeParameters data)
		{
			target.CallService("set_music_mode", data);
		}

		///<summary>Enable or disable music_mode</summary>
		public static void SetMusicMode(this IEnumerable<LightEntity> target, YeelightSetMusicModeParameters data)
		{
			target.CallService("set_music_mode", data);
		}

		///<summary>Enable or disable music_mode</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="musicMode">Use true or false to enable / disable music_mode</param>
		public static void SetMusicMode(this LightEntity target, bool @musicMode)
		{
			target.CallService("set_music_mode", new YeelightSetMusicModeParameters{MusicMode = @musicMode});
		}

		///<summary>Enable or disable music_mode</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="musicMode">Use true or false to enable / disable music_mode</param>
		public static void SetMusicMode(this IEnumerable<LightEntity> target, bool @musicMode)
		{
			target.CallService("set_music_mode", new YeelightSetMusicModeParameters{MusicMode = @musicMode});
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		public static void StartFlow(this LightEntity target, YeelightStartFlowParameters data)
		{
			target.CallService("start_flow", data);
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		public static void StartFlow(this IEnumerable<LightEntity> target, YeelightStartFlowParameters data)
		{
			target.CallService("start_flow", data);
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		///<param name="target">The LightEntity to call this service for</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public static void StartFlow(this LightEntity target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			target.CallService("start_flow", new YeelightStartFlowParameters{Count = @count, Action = @action, Transitions = @transitions});
		}

		///<summary>Start a custom flow, using transitions from https://yeelight.readthedocs.io/en/stable/yeelight.html#flow-objects</summary>
		///<param name="target">The IEnumerable<LightEntity> to call this service for</param>
		///<param name="count">The number of times to run this flow (0 to run forever).</param>
		///<param name="action">The action to take after the flow stops.</param>
		///<param name="transitions">Array of transitions, for desired effect. Examples https://yeelight.readthedocs.io/en/stable/flow.html eg: [{ "TemperatureTransition": [1900, 1000, 80] }, { "TemperatureTransition": [1900, 1000, 10] }]</param>
		public static void StartFlow(this IEnumerable<LightEntity> target, long? @count = null, object? @action = null, object? @transitions = null)
		{
			target.CallService("start_flow", new YeelightStartFlowParameters{Count = @count, Action = @action, Transitions = @transitions});
		}
	}
}