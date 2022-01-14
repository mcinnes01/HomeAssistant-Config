using System;
using System.Collections.Generic;

namespace HomeAssistantGenerated
{
	public interface IEntities
	{
		AlarmControlPanelEntities AlarmControlPanel { get; }

		AutomationEntities Automation { get; }

		BinarySensorEntities BinarySensor { get; }

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

		PersistentNotificationEntities PersistentNotification { get; }

		PersonEntities Person { get; }

		SceneEntities Scene { get; }

		ScriptEntities Script { get; }

		SelectEntities Select { get; }

		SensorEntities Sensor { get; }

		SunEntities Sun { get; }

		SwitchEntities Switch { get; }

		TimerEntities Timer { get; }

		VacuumEntities Vacuum { get; }

		WeatherEntities Weather { get; }

		ZoneEntities Zone { get; }
	}

	public class Entities : IEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public Entities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AlarmControlPanelEntities AlarmControlPanel => new(_haContext);
		public AutomationEntities Automation => new(_haContext);
		public BinarySensorEntities BinarySensor => new(_haContext);
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
		public PersistentNotificationEntities PersistentNotification => new(_haContext);
		public PersonEntities Person => new(_haContext);
		public SceneEntities Scene => new(_haContext);
		public ScriptEntities Script => new(_haContext);
		public SelectEntities Select => new(_haContext);
		public SensorEntities Sensor => new(_haContext);
		public SunEntities Sun => new(_haContext);
		public SwitchEntities Switch => new(_haContext);
		public TimerEntities Timer => new(_haContext);
		public VacuumEntities Vacuum => new(_haContext);
		public WeatherEntities Weather => new(_haContext);
		public ZoneEntities Zone => new(_haContext);
	}

	public class AlarmControlPanelEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AlarmControlPanelEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AlarmControlPanelEntity Alarm => new(_haContext, "alarm_control_panel.alarm");
	}

	public class AutomationEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AutomationEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public AutomationEntity AmbianceToDay => new(_haContext, "automation.ambiance_to_day");
		public AutomationEntity AmbianceToDayAfter9amOnAWeekDay => new(_haContext, "automation.ambiance_to_day_after_9am_on_a_week_day");
		public AutomationEntity AmbianceToDayAt12pmAtTheWeekend => new(_haContext, "automation.ambiance_to_day_at_12pm_at_the_weekend");
		public AutomationEntity AmbianceToNightAfter1amOnAWeekDay => new(_haContext, "automation.ambiance_to_night_after_1am_on_a_week_day");
		public AutomationEntity AmbianceToNightWhenInBed => new(_haContext, "automation.ambiance_to_night_when_in_bed");
		public AutomationEntity AndyIsHome => new(_haContext, "automation.andy_is_home");
		public AutomationEntity BackDoorIsOpen => new(_haContext, "automation.back_door_is_open");
		public AutomationEntity BackDoorLightConstrained => new(_haContext, "automation.back_door_light_constrained");
		public AutomationEntity BasementHallLightConstrained => new(_haContext, "automation.basement_hall_light_constrained");
		public AutomationEntity BathroomLightConstrained => new(_haContext, "automation.bathroom_light_constrained");
		public AutomationEntity BathroomOccupancy => new(_haContext, "automation.bathroom_occupancy");
		public AutomationEntity BedSensorSetsInBedToOff => new(_haContext, "automation.bed_sensor_sets_in_bed_to_off");
		public AutomationEntity BedSensorSetsInBedToOn => new(_haContext, "automation.bed_sensor_sets_in_bed_to_on");
		public AutomationEntity BedroomLampConstrained => new(_haContext, "automation.bedroom_lamp_constrained");
		public AutomationEntity BedroomLightConstrained => new(_haContext, "automation.bedroom_light_constrained");
		public AutomationEntity BedroomLightsOffResetMode => new(_haContext, "automation.bedroom_lights_off_reset_mode");
		public AutomationEntity ClaireIsHome => new(_haContext, "automation.claire_is_home");
		public AutomationEntity DiningRoomLightConstrained => new(_haContext, "automation.dining_room_light_constrained");
		public AutomationEntity DoorbellNotifications => new(_haContext, "automation.doorbell_notifications");
		public AutomationEntity DrawingRoomLampConstrained => new(_haContext, "automation.drawing_room_lamp_constrained");
		public AutomationEntity DrawingRoomLightConstrained => new(_haContext, "automation.drawing_room_light_constrained");
		public AutomationEntity DressingRoomConstrained => new(_haContext, "automation.dressing_room_constrained");
		public AutomationEntity ElectricCabinetOccupancy => new(_haContext, "automation.electric_cabinet_occupancy");
		public AutomationEntity FeedCats => new(_haContext, "automation.feed_cats");
		public AutomationEntity FloorLampConstrained => new(_haContext, "automation.floor_lamp_constrained");
		public AutomationEntity FrontDoorClosedAfterSunset => new(_haContext, "automation.front_door_closed_after_sunset");
		public AutomationEntity FrontDoorOpenAfterSunset => new(_haContext, "automation.front_door_open_after_sunset");
		public AutomationEntity GuestRoomLightConstrained => new(_haContext, "automation.guest_room_light_constrained");
		public AutomationEntity HallwayLampConstrained => new(_haContext, "automation.hallway_lamp_constrained");
		public AutomationEntity HallwayLightConstrained => new(_haContext, "automation.hallway_light_constrained");
		public AutomationEntity KitchenLampConstrained => new(_haContext, "automation.kitchen_lamp_constrained");
		public AutomationEntity KitchenLightConstrained => new(_haContext, "automation.kitchen_light_constrained");
		public AutomationEntity KitchenMotionEventSnapshot => new(_haContext, "automation.kitchen_motion_event_snapshot");
		public AutomationEntity LoftHatchClosed => new(_haContext, "automation.loft_hatch_closed");
		public AutomationEntity LoftHatchOpen => new(_haContext, "automation.loft_hatch_open");
		public AutomationEntity LoungeLampConstrained => new(_haContext, "automation.lounge_lamp_constrained");
		public AutomationEntity LoungeLightConstrained => new(_haContext, "automation.lounge_light_constrained");
		public AutomationEntity LoungeLightsOffResetMode => new(_haContext, "automation.lounge_lights_off_reset_mode");
		public AutomationEntity LoungeMotionLighting => new(_haContext, "automation.lounge_motion_lighting");
		public AutomationEntity LoungeSceneWatchTelevision2 => new(_haContext, "automation.lounge_scene_watch_television_2");
		public AutomationEntity LowBatteryLevelDetectionNotificationForAllBatterySensors => new(_haContext, "automation.low_battery_level_detection_notification_for_all_battery_sensors");
		public AutomationEntity MirrorLightConstrained => new(_haContext, "automation.mirror_light_constrained");
		public AutomationEntity PatioMotionDetected => new(_haContext, "automation.patio_motion_detected");
		public AutomationEntity PatioPersonMotionEventSnapshotClaireIphone => new(_haContext, "automation.patio_person_motion_event_snapshot_claire_iphone");
		public AutomationEntity SendNotificationWhenAlarmIsArmedInAwayMode => new(_haContext, "automation.send_notification_when_alarm_is_armed_in_away_mode");
		public AutomationEntity SendNotificationWhenAlarmIsArmedInHomeMode => new(_haContext, "automation.send_notification_when_alarm_is_armed_in_home_mode");
		public AutomationEntity SendNotificationWhenAlarmIsArming => new(_haContext, "automation.send_notification_when_alarm_is_arming");
		public AutomationEntity SendNotificationWhenAlarmIsDisarmed => new(_haContext, "automation.send_notification_when_alarm_is_disarmed");
		public AutomationEntity SendNotificationWhenAlarmIsDisarmed2 => new(_haContext, "automation.send_notification_when_alarm_is_disarmed_2");
		public AutomationEntity SendNotificationWhenAlarmIsPending => new(_haContext, "automation.send_notification_when_alarm_is_pending");
		public AutomationEntity SendNotificationWhenAlarmTriggered2 => new(_haContext, "automation.send_notification_when_alarm_triggered_2");
		public AutomationEntity SetAmbienceToEvening => new(_haContext, "automation.set_ambience_to_evening");
		public AutomationEntity ShowerTimerFinished => new(_haContext, "automation.shower_timer_finished");
		public AutomationEntity ShowerTimerStart => new(_haContext, "automation.shower_timer_start");
		public AutomationEntity SnugLightsOffResetMode => new(_haContext, "automation.snug_lights_off_reset_mode");
		public AutomationEntity SnugSceneNormal => new(_haContext, "automation.snug_scene_normal");
		public AutomationEntity SnugSceneWatchMovie => new(_haContext, "automation.snug_scene_watch_movie");
		public AutomationEntity SnugSwitchActions => new(_haContext, "automation.snug_switch_actions");
		public AutomationEntity StudioLightConstrained => new(_haContext, "automation.studio_light_constrained");
		public AutomationEntity SumpAlarmTriggered => new(_haContext, "automation.sump_alarm_triggered");
		public AutomationEntity TestPatioMotionOverride => new(_haContext, "automation.test_patio_motion_override");
		public AutomationEntity ToiletLightConstrained => new(_haContext, "automation.toilet_light_constrained");
		public AutomationEntity ToiletOccupancy => new(_haContext, "automation.toilet_occupancy");
		public AutomationEntity TriggerAlarmWhileArmedAway => new(_haContext, "automation.trigger_alarm_while_armed_away");
		public AutomationEntity TurnOffBackDoorLightWhenNoDetection => new(_haContext, "automation.turn_off_back_door_light_when_no_detection");
		public AutomationEntity TurnOffBasementHallLightWhenElectricCabinetDoorClosed => new(_haContext, "automation.turn_off_basement_hall_light_when_electric_cabinet_door_closed");
		public AutomationEntity TurnOnBasementHallLightsWhenElectricCabinetDoorIsOpen => new(_haContext, "automation.turn_on_basement_hall_lights_when_electric_cabinet_door_is_open");
		public AutomationEntity TurnOnExMachinaLightsWhenAlarmTriggered => new(_haContext, "automation.turn_on_ex_machina_lights_when_alarm_triggered");
		public AutomationEntity TurnPorchLightOfAt11pm => new(_haContext, "automation.turn_porch_light_of_at_11pm");
		public AutomationEntity TurnPorchLightOnWhenSunIsSet => new(_haContext, "automation.turn_porch_light_on_when_sun_is_set");
		public AutomationEntity UtilityRoomLightConstrained => new(_haContext, "automation.utility_room_light_constrained");
	}

	public class BinarySensorEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public BinarySensorEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public BinarySensorEntity AndrewsIphoneFocus => new(_haContext, "binary_sensor.andrews_iphone_focus");
		public BinarySensorEntity AtHome => new(_haContext, "binary_sensor.at_home");
		public BinarySensorEntity BackupsStale => new(_haContext, "binary_sensor.backups_stale");
		public BinarySensorEntity BasementHallMotion => new(_haContext, "binary_sensor.basement_hall_motion");
		public BinarySensorEntity BasementStairsMotion => new(_haContext, "binary_sensor.basement_stairs_motion");
		public BinarySensorEntity BasementStairsMotionBatteryLow => new(_haContext, "binary_sensor.basement_stairs_motion_battery_low");
		public BinarySensorEntity BasementStairsMotionOccupancy => new(_haContext, "binary_sensor.basement_stairs_motion_occupancy");
		public BinarySensorEntity BasementStairsMotionTamper => new(_haContext, "binary_sensor.basement_stairs_motion_tamper");
		public BinarySensorEntity BasementThermostatFan => new(_haContext, "binary_sensor.basement_thermostat_fan");
		public BinarySensorEntity BasementThermostatHasLeaf => new(_haContext, "binary_sensor.basement_thermostat_has_leaf");
		public BinarySensorEntity BasementThermostatIsLocked => new(_haContext, "binary_sensor.basement_thermostat_is_locked");
		public BinarySensorEntity BasementThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.basement_thermostat_is_using_emergency_heat");
		public BinarySensorEntity BasementThermostatOnline => new(_haContext, "binary_sensor.basement_thermostat_online");
		public BinarySensorEntity BathroomDoor => new(_haContext, "binary_sensor.bathroom_door");
		public BinarySensorEntity BathroomDoorBatteryLow => new(_haContext, "binary_sensor.bathroom_door_battery_low");
		public BinarySensorEntity BathroomMotion => new(_haContext, "binary_sensor.bathroom_motion");
		public BinarySensorEntity BathroomWasp => new(_haContext, "binary_sensor.bathroom_wasp");
		public BinarySensorEntity BedroomMotion => new(_haContext, "binary_sensor.bedroom_motion");
		public BinarySensorEntity CellarDoor => new(_haContext, "binary_sensor.cellar_door");
		public BinarySensorEntity ClairesIphoneFocus => new(_haContext, "binary_sensor.claires_iphone_focus");
		public BinarySensorEntity DiningRoomMotion => new(_haContext, "binary_sensor.dining_room_motion");
		public BinarySensorEntity DisableNextFeed => new(_haContext, "binary_sensor.disable_next_feed");
		public BinarySensorEntity DispenserRotating => new(_haContext, "binary_sensor.dispenser_rotating");
		public BinarySensorEntity DoorbellButton => new(_haContext, "binary_sensor.doorbell_button");
		public BinarySensorEntity DownstairsThermostatFan => new(_haContext, "binary_sensor.downstairs_thermostat_fan");
		public BinarySensorEntity DownstairsThermostatHasLeaf => new(_haContext, "binary_sensor.downstairs_thermostat_has_leaf");
		public BinarySensorEntity DownstairsThermostatIsLocked => new(_haContext, "binary_sensor.downstairs_thermostat_is_locked");
		public BinarySensorEntity DownstairsThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.downstairs_thermostat_is_using_emergency_heat");
		public BinarySensorEntity DownstairsThermostatOnline => new(_haContext, "binary_sensor.downstairs_thermostat_online");
		public BinarySensorEntity DrawingRoomMotion => new(_haContext, "binary_sensor.drawing_room_motion");
		public BinarySensorEntity DressingRoomMotion => new(_haContext, "binary_sensor.dressing_room_motion");
		public BinarySensorEntity ElectricCabinetDoorBatteryLow => new(_haContext, "binary_sensor.electric_cabinet_door_battery_low");
		public BinarySensorEntity ElectricCabinetDoorContact => new(_haContext, "binary_sensor.electric_cabinet_door_contact");
		public BinarySensorEntity EspresenseBedroom => new(_haContext, "binary_sensor.espresense_bedroom");
		public BinarySensorEntity EspresenseDrawingroom => new(_haContext, "binary_sensor.espresense_drawingroom");
		public BinarySensorEntity EspresenseKitchen => new(_haContext, "binary_sensor.espresense_kitchen");
		public BinarySensorEntity EspresenseLounge => new(_haContext, "binary_sensor.espresense_lounge");
		public BinarySensorEntity EspresenseSnug => new(_haContext, "binary_sensor.espresense_snug");
		public BinarySensorEntity EspresenseStudio => new(_haContext, "binary_sensor.espresense_studio");
		public BinarySensorEntity EveningFeedComplete => new(_haContext, "binary_sensor.evening_feed_complete");
		public BinarySensorEntity EveningFeedEnabled => new(_haContext, "binary_sensor.evening_feed_enabled");
		public BinarySensorEntity EwelinkSmartHomeUpdateAvailable => new(_haContext, "binary_sensor.ewelink_smart_home_update_available");
		public BinarySensorEntity FrontDoorBatteryLow => new(_haContext, "binary_sensor.front_door_battery_low");
		public BinarySensorEntity FrontDoorContact => new(_haContext, "binary_sensor.front_door_contact");
		public BinarySensorEntity GuestRoomMotion => new(_haContext, "binary_sensor.guest_room_motion");
		public BinarySensorEntity HallwayMotion => new(_haContext, "binary_sensor.hallway_motion");
		public BinarySensorEntity Homeassistant => new(_haContext, "binary_sensor.homeassistant");
		public BinarySensorEntity InBed => new(_haContext, "binary_sensor.in_bed");
		public BinarySensorEntity IsDarkBasementHallCamera => new(_haContext, "binary_sensor.is_dark_basement_hall_camera");
		public BinarySensorEntity IsDarkKitchenCamera => new(_haContext, "binary_sensor.is_dark_kitchen_camera");
		public BinarySensorEntity IsDarkPatioCamera => new(_haContext, "binary_sensor.is_dark_patio_camera");
		public BinarySensorEntity KitchenMotion => new(_haContext, "binary_sensor.kitchen_motion");
		public BinarySensorEntity LandingMotion => new(_haContext, "binary_sensor.landing_motion");
		public BinarySensorEntity LoftHatchBatteryLow => new(_haContext, "binary_sensor.loft_hatch_battery_low");
		public BinarySensorEntity LoftHatchContact => new(_haContext, "binary_sensor.loft_hatch_contact");
		public BinarySensorEntity LoungeMotion => new(_haContext, "binary_sensor.lounge_motion");
		public BinarySensorEntity ManchesterRoadAway => new(_haContext, "binary_sensor.manchester_road_away");
		public BinarySensorEntity MorningFeedComplete => new(_haContext, "binary_sensor.morning_feed_complete");
		public BinarySensorEntity MorningFeedEnabled => new(_haContext, "binary_sensor.morning_feed_enabled");
		public BinarySensorEntity MotionBasementHallCamera => new(_haContext, "binary_sensor.motion_basement_hall_camera");
		public BinarySensorEntity MotionKitchenCamera => new(_haContext, "binary_sensor.motion_kitchen_camera");
		public BinarySensorEntity MotionPatioCamera => new(_haContext, "binary_sensor.motion_patio_camera");
		public BinarySensorEntity PatioDoor => new(_haContext, "binary_sensor.patio_door");
		public BinarySensorEntity PatioMotion => new(_haContext, "binary_sensor.patio_motion");
		public BinarySensorEntity RemoteUi => new(_haContext, "binary_sensor.remote_ui");
		public BinarySensorEntity SnugMotion => new(_haContext, "binary_sensor.snug_motion");
		public BinarySensorEntity SonoffBridge1Button1 => new(_haContext, "binary_sensor.sonoff_bridge_1_button1");
		public BinarySensorEntity StudioMotion => new(_haContext, "binary_sensor.studio_motion");
		public BinarySensorEntity SumpAlarmTrigger => new(_haContext, "binary_sensor.sump_alarm_trigger");
		public BinarySensorEntity ToiletDoor => new(_haContext, "binary_sensor.toilet_door");
		public BinarySensorEntity ToiletDoorBatteryLow => new(_haContext, "binary_sensor.toilet_door_battery_low");
		public BinarySensorEntity ToiletMotion => new(_haContext, "binary_sensor.toilet_motion");
		public BinarySensorEntity ToiletWasp => new(_haContext, "binary_sensor.toilet_wasp");
		public BinarySensorEntity UnifiDreamMachineWanStatus => new(_haContext, "binary_sensor.unifi_dream_machine_wan_status");
		public BinarySensorEntity UnifiDreamMachineWanStatus2 => new(_haContext, "binary_sensor.unifi_dream_machine_wan_status_2");
		public BinarySensorEntity Updater => new(_haContext, "binary_sensor.updater");
		public BinarySensorEntity UpstairsThermostatFan => new(_haContext, "binary_sensor.upstairs_thermostat_fan");
		public BinarySensorEntity UpstairsThermostatHasLeaf => new(_haContext, "binary_sensor.upstairs_thermostat_has_leaf");
		public BinarySensorEntity UpstairsThermostatIsLocked => new(_haContext, "binary_sensor.upstairs_thermostat_is_locked");
		public BinarySensorEntity UpstairsThermostatIsUsingEmergencyHeat => new(_haContext, "binary_sensor.upstairs_thermostat_is_using_emergency_heat");
		public BinarySensorEntity UpstairsThermostatOnline => new(_haContext, "binary_sensor.upstairs_thermostat_online");
		public BinarySensorEntity UtilityRoomMotion => new(_haContext, "binary_sensor.utility_room_motion");
		public BinarySensorEntity WithingsInBedAndy => new(_haContext, "binary_sensor.withings_in_bed_andy");
		public BinarySensorEntity WithingsInBedClaire => new(_haContext, "binary_sensor.withings_in_bed_claire");
	}

	public class CalendarEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CalendarEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public CalendarEntity Contacts => new(_haContext, "calendar.contacts");
		public CalendarEntity GarbageCollection => new(_haContext, "calendar.garbage_collection");
		public CalendarEntity HolidaysInUnitedKingdom => new(_haContext, "calendar.holidays_in_united_kingdom");
		public CalendarEntity HomeAndisoftGmailCom => new(_haContext, "calendar.home_andisoft_gmail_com");
	}

	public class CameraEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CameraEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public CameraEntity BasementHallCamera => new(_haContext, "camera.basement_hall_camera");
		public CameraEntity CellarDoorCamera => new(_haContext, "camera.cellar_door_camera");
		public CameraEntity CellarDoorCamera2 => new(_haContext, "camera.cellar_door_camera_2");
		public CameraEntity CellarDoorCameraMainstream => new(_haContext, "camera.cellar_door_camera_mainstream");
		public CameraEntity KitchenCamera => new(_haContext, "camera.kitchen_camera");
		public CameraEntity MarkCleaningMap => new(_haContext, "camera.mark_cleaning_map");
		public CameraEntity PatioCamera => new(_haContext, "camera.patio_camera");
	}

	public class ClimateEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ClimateEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public ClimateEntity Basement => new(_haContext, "climate.basement");
		public ClimateEntity BasementThermostat => new(_haContext, "climate.basement_thermostat");
		public ClimateEntity Downstairs => new(_haContext, "climate.downstairs");
		public ClimateEntity DownstairsThermostat => new(_haContext, "climate.downstairs_thermostat");
		public ClimateEntity Upstairs => new(_haContext, "climate.upstairs");
		public ClimateEntity UpstairsThermostat => new(_haContext, "climate.upstairs_thermostat");
	}

	public class DeviceTrackerEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public DeviceTrackerEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public DeviceTrackerEntity AndrewsIphone => new(_haContext, "device_tracker.andrews_iphone");
		public DeviceTrackerEntity AndrewsIphoneTile => new(_haContext, "device_tracker.andrews_iphone_tile");
		public DeviceTrackerEntity AndysKeys => new(_haContext, "device_tracker.andys_keys");
		public DeviceTrackerEntity Car => new(_haContext, "device_tracker.car");
		public DeviceTrackerEntity ClairesIphone => new(_haContext, "device_tracker.claires_iphone");
		public DeviceTrackerEntity ClairesIphoneTile => new(_haContext, "device_tracker.claires_iphone_tile");
		public DeviceTrackerEntity ClairesKeys => new(_haContext, "device_tracker.claires_keys");
		public DeviceTrackerEntity HauserAndy => new(_haContext, "device_tracker.hauser_andy");
		public DeviceTrackerEntity HauserClaire => new(_haContext, "device_tracker.hauser_claire");
		public DeviceTrackerEntity SpareKey => new(_haContext, "device_tracker.spare_key");
	}

	public class EntityControllerEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public EntityControllerEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public EntityControllerEntity BasementHallLightController => new(_haContext, "entity_controller.basement_hall_light_controller");
		public EntityControllerEntity BathroomLightController => new(_haContext, "entity_controller.bathroom_light_controller");
		public EntityControllerEntity BookshelfLightController => new(_haContext, "entity_controller.bookshelf_light_controller");
		public EntityControllerEntity BreakfastBarLampController => new(_haContext, "entity_controller.breakfast_bar_lamp_controller");
		public EntityControllerEntity DiningRoomLightController => new(_haContext, "entity_controller.dining_room_light_controller");
		public EntityControllerEntity DrawingRoomLightController => new(_haContext, "entity_controller.drawing_room_light_controller");
		public EntityControllerEntity DressingRoomLightController => new(_haContext, "entity_controller.dressing_room_light_controller");
		public EntityControllerEntity GuestRoomLightController => new(_haContext, "entity_controller.guest_room_light_controller");
		public EntityControllerEntity HallwayLampController => new(_haContext, "entity_controller.hallway_lamp_controller");
		public EntityControllerEntity HallwayLightController => new(_haContext, "entity_controller.hallway_light_controller");
		public EntityControllerEntity KitchenLightController => new(_haContext, "entity_controller.kitchen_light_controller");
		public EntityControllerEntity LandingLightController => new(_haContext, "entity_controller.landing_light_controller");
		public EntityControllerEntity LoungeCornerLampController => new(_haContext, "entity_controller.lounge_corner_lamp_controller");
		public EntityControllerEntity LoungeFloorLampController => new(_haContext, "entity_controller.lounge_floor_lamp_controller");
		public EntityControllerEntity LoungeLightController => new(_haContext, "entity_controller.lounge_light_controller");
		public EntityControllerEntity MirrorLightController => new(_haContext, "entity_controller.mirror_light_controller");
		public EntityControllerEntity SnugFloorLampController => new(_haContext, "entity_controller.snug_floor_lamp_controller");
		public EntityControllerEntity SnugLightController => new(_haContext, "entity_controller.snug_light_controller");
		public EntityControllerEntity StudioLightController => new(_haContext, "entity_controller.studio_light_controller");
		public EntityControllerEntity ToiletLightController => new(_haContext, "entity_controller.toilet_light_controller");
		public EntityControllerEntity UtilityRoomLightController => new(_haContext, "entity_controller.utility_room_light_controller");
	}

	public class FanEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public FanEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public FanEntity BathroomFan => new(_haContext, "fan.bathroom_fan");
		public FanEntity ExtractorFan => new(_haContext, "fan.extractor_fan");
	}

	public class GroupEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public GroupEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public GroupEntity Basement => new(_haContext, "group.basement");
		public GroupEntity BasementControllers => new(_haContext, "group.basement_controllers");
		public GroupEntity BasementHall => new(_haContext, "group.basement_hall");
		public GroupEntity BasementHallControllers => new(_haContext, "group.basement_hall_controllers");
		public GroupEntity BasementHallLights => new(_haContext, "group.basement_hall_lights");
		public GroupEntity BasementHallMotionSensors => new(_haContext, "group.basement_hall_motion_sensors");
		public GroupEntity BasementHallOverrides => new(_haContext, "group.basement_hall_overrides");
		public GroupEntity BasementOverrides => new(_haContext, "group.basement_overrides");
		public GroupEntity Bathroom => new(_haContext, "group.bathroom");
		public GroupEntity BathroomControllers => new(_haContext, "group.bathroom_controllers");
		public GroupEntity BathroomLights => new(_haContext, "group.bathroom_lights");
		public GroupEntity BathroomOverrides => new(_haContext, "group.bathroom_overrides");
		public GroupEntity Bedroom => new(_haContext, "group.bedroom");
		public GroupEntity BedroomLights => new(_haContext, "group.bedroom_lights");
		public GroupEntity BedroomOverrides => new(_haContext, "group.bedroom_overrides");
		public GroupEntity ClimateBasement => new(_haContext, "group.climate_basement");
		public GroupEntity ClimateDownstairs => new(_haContext, "group.climate_downstairs");
		public GroupEntity ClimateUpstairs => new(_haContext, "group.climate_upstairs");
		public GroupEntity DayOverrides => new(_haContext, "group.day_overrides");
		public GroupEntity DiningRoom => new(_haContext, "group.dining_room");
		public GroupEntity DiningRoomControllers => new(_haContext, "group.dining_room_controllers");
		public GroupEntity DiningRoomOverrides => new(_haContext, "group.dining_room_overrides");
		public GroupEntity Downstairs => new(_haContext, "group.downstairs");
		public GroupEntity DownstairsControllers => new(_haContext, "group.downstairs_controllers");
		public GroupEntity DownstairsOverrides => new(_haContext, "group.downstairs_overrides");
		public GroupEntity DrawingRoom => new(_haContext, "group.drawing_room");
		public GroupEntity DrawingRoomControllers => new(_haContext, "group.drawing_room_controllers");
		public GroupEntity DrawingRoomLights => new(_haContext, "group.drawing_room_lights");
		public GroupEntity DrawingRoomOverrides => new(_haContext, "group.drawing_room_overrides");
		public GroupEntity DressingRoom => new(_haContext, "group.dressing_room");
		public GroupEntity DressingRoomControllers => new(_haContext, "group.dressing_room_controllers");
		public GroupEntity DressingRoomOverrides => new(_haContext, "group.dressing_room_overrides");
		public GroupEntity ElectricCabinet => new(_haContext, "group.electric_cabinet");
		public GroupEntity EntityControllers => new(_haContext, "group.entity_controllers");
		public GroupEntity EntityOverrides => new(_haContext, "group.entity_overrides");
		public GroupEntity EspDoorbell => new(_haContext, "group.esp_doorbell");
		public GroupEntity EveningOverrides => new(_haContext, "group.evening_overrides");
		public GroupEntity GuestBedroom => new(_haContext, "group.guest_bedroom");
		public GroupEntity GuestRoomControllers => new(_haContext, "group.guest_room_controllers");
		public GroupEntity GuestRoomOverrides => new(_haContext, "group.guest_room_overrides");
		public GroupEntity Hallway => new(_haContext, "group.hallway");
		public GroupEntity HallwayControllers => new(_haContext, "group.hallway_controllers");
		public GroupEntity HallwayLights => new(_haContext, "group.hallway_lights");
		public GroupEntity HallwayOverrides => new(_haContext, "group.hallway_overrides");
		public GroupEntity Kitchen => new(_haContext, "group.kitchen");
		public GroupEntity KitchenControllers => new(_haContext, "group.kitchen_controllers");
		public GroupEntity KitchenLights => new(_haContext, "group.kitchen_lights");
		public GroupEntity KitchenMotionSensors => new(_haContext, "group.kitchen_motion_sensors");
		public GroupEntity KitchenOverrides => new(_haContext, "group.kitchen_overrides");
		public GroupEntity Landing => new(_haContext, "group.landing");
		public GroupEntity LandingControllers => new(_haContext, "group.landing_controllers");
		public GroupEntity LandingOverrides => new(_haContext, "group.landing_overrides");
		public GroupEntity Lounge => new(_haContext, "group.lounge");
		public GroupEntity LoungeControllers => new(_haContext, "group.lounge_controllers");
		public GroupEntity LoungeLights => new(_haContext, "group.lounge_lights");
		public GroupEntity LoungeOverrides => new(_haContext, "group.lounge_overrides");
		public GroupEntity MediaBedroomEchoShow => new(_haContext, "group.media_bedroom_echo_show");
		public GroupEntity MediaDiningRoomEchoInput => new(_haContext, "group.media_dining_room_echo_input");
		public GroupEntity MediaDrawingRoomEchoDot => new(_haContext, "group.media_drawing_room_echo_dot");
		public GroupEntity MediaDressingRoomEchoDot => new(_haContext, "group.media_dressing_room_echo_dot");
		public GroupEntity MediaGuestRoomEchoShow => new(_haContext, "group.media_guest_room_echo_show");
		public GroupEntity MediaHallwayTablet => new(_haContext, "group.media_hallway_tablet");
		public GroupEntity MediaKitchenEchoShow => new(_haContext, "group.media_kitchen_echo_show");
		public GroupEntity MediaLandingTablet => new(_haContext, "group.media_landing_tablet");
		public GroupEntity MediaLoungeEchoPlus => new(_haContext, "group.media_lounge_echo_plus");
		public GroupEntity MediaSnugEchoInput => new(_haContext, "group.media_snug_echo_input");
		public GroupEntity MediaUtilityRoomEchoDot => new(_haContext, "group.media_utility_room_echo_dot");
		public GroupEntity NightOverrides => new(_haContext, "group.night_overrides");
		public GroupEntity Outside => new(_haContext, "group.outside");
		public GroupEntity Patio => new(_haContext, "group.patio");
		public GroupEntity PatioLights => new(_haContext, "group.patio_lights");
		public GroupEntity PersonHomeAway => new(_haContext, "group.person_home_away");
		public GroupEntity PersonLocations => new(_haContext, "group.person_locations");
		public GroupEntity Porch => new(_haContext, "group.porch");
		public GroupEntity Snug => new(_haContext, "group.snug");
		public GroupEntity SnugControllers => new(_haContext, "group.snug_controllers");
		public GroupEntity SnugLights => new(_haContext, "group.snug_lights");
		public GroupEntity SnugOverrides => new(_haContext, "group.snug_overrides");
		public GroupEntity Studio => new(_haContext, "group.studio");
		public GroupEntity StudioControllers => new(_haContext, "group.studio_controllers");
		public GroupEntity StudioOverrides => new(_haContext, "group.studio_overrides");
		public GroupEntity Toilet => new(_haContext, "group.toilet");
		public GroupEntity ToiletControllers => new(_haContext, "group.toilet_controllers");
		public GroupEntity ToiletOverrides => new(_haContext, "group.toilet_overrides");
		public GroupEntity Upstairs => new(_haContext, "group.upstairs");
		public GroupEntity UpstairsControllers => new(_haContext, "group.upstairs_controllers");
		public GroupEntity UpstairsOverrides => new(_haContext, "group.upstairs_overrides");
		public GroupEntity UtilityControllers => new(_haContext, "group.utility_controllers");
		public GroupEntity UtilityOverrides => new(_haContext, "group.utility_overrides");
		public GroupEntity UtilityRoom => new(_haContext, "group.utility_room");
	}

	public class InputBooleanEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputBooleanEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public InputBooleanEntity AutomationsPresence => new(_haContext, "input_boolean.automations_presence");
		public InputBooleanEntity AutomationsPresenceBle => new(_haContext, "input_boolean.automations_presence_ble");
		public InputBooleanEntity BackDoorLightConstrained => new(_haContext, "input_boolean.back_door_light_constrained");
		public InputBooleanEntity BasementHallLightConstrained => new(_haContext, "input_boolean.basement_hall_light_constrained");
		public InputBooleanEntity BathroomLightConstrained => new(_haContext, "input_boolean.bathroom_light_constrained");
		public InputBooleanEntity BedroomLightConstrained => new(_haContext, "input_boolean.bedroom_light_constrained");
		public InputBooleanEntity BedsideLampConstrained => new(_haContext, "input_boolean.bedside_lamp_constrained");
		public InputBooleanEntity BookshelfLightConstrained => new(_haContext, "input_boolean.bookshelf_light_constrained");
		public InputBooleanEntity BreakfastBarLampConstrained => new(_haContext, "input_boolean.breakfast_bar_lamp_constrained");
		public InputBooleanEntity BreweryLightConstrained => new(_haContext, "input_boolean.brewery_light_constrained");
		public InputBooleanEntity DiningRoomLightConstrained => new(_haContext, "input_boolean.dining_room_light_constrained");
		public InputBooleanEntity DisableBasementLighting => new(_haContext, "input_boolean.disable_basement_lighting");
		public InputBooleanEntity DisableEntityControlledLighting => new(_haContext, "input_boolean.disable_entity_controlled_lighting");
		public InputBooleanEntity DisableNextFeed => new(_haContext, "input_boolean.disable_next_feed");
		public InputBooleanEntity DrawingRoomLightConstrained => new(_haContext, "input_boolean.drawing_room_light_constrained");
		public InputBooleanEntity DressingRoomLightConstrained => new(_haContext, "input_boolean.dressing_room_light_constrained");
		public InputBooleanEntity EveningFeedComplete => new(_haContext, "input_boolean.evening_feed_complete");
		public InputBooleanEntity EveningFeedEnabled => new(_haContext, "input_boolean.evening_feed_enabled");
		public InputBooleanEntity GuestMode => new(_haContext, "input_boolean.guest_mode");
		public InputBooleanEntity GuestRoomLightConstrained => new(_haContext, "input_boolean.guest_room_light_constrained");
		public InputBooleanEntity Guests => new(_haContext, "input_boolean.guests");
		public InputBooleanEntity HallwayLampConstrained => new(_haContext, "input_boolean.hallway_lamp_constrained");
		public InputBooleanEntity HallwayLightConstrained => new(_haContext, "input_boolean.hallway_light_constrained");
		public InputBooleanEntity InBed => new(_haContext, "input_boolean.in_bed");
		public InputBooleanEntity InShower => new(_haContext, "input_boolean.in_shower");
		public InputBooleanEntity KitchenLightConstrained => new(_haContext, "input_boolean.kitchen_light_constrained");
		public InputBooleanEntity LandingLightConstrained => new(_haContext, "input_boolean.landing_light_constrained");
		public InputBooleanEntity LoungeCornerLampConstrained => new(_haContext, "input_boolean.lounge_corner_lamp_constrained");
		public InputBooleanEntity LoungeFloorLampConstrained => new(_haContext, "input_boolean.lounge_floor_lamp_constrained");
		public InputBooleanEntity LoungeLightConstrained => new(_haContext, "input_boolean.lounge_light_constrained");
		public InputBooleanEntity MirrorLightConstrained => new(_haContext, "input_boolean.mirror_light_constrained");
		public InputBooleanEntity MorningFeedComplete => new(_haContext, "input_boolean.morning_feed_complete");
		public InputBooleanEntity MorningFeedEnabled => new(_haContext, "input_boolean.morning_feed_enabled");
		public InputBooleanEntity PatioMotion => new(_haContext, "input_boolean.patio_motion");
		public InputBooleanEntity SnugFloorLampConstrained => new(_haContext, "input_boolean.snug_floor_lamp_constrained");
		public InputBooleanEntity SnugLightConstrained => new(_haContext, "input_boolean.snug_light_constrained");
		public InputBooleanEntity StudioLightConstrained => new(_haContext, "input_boolean.studio_light_constrained");
		public InputBooleanEntity ToiletLightConstrained => new(_haContext, "input_boolean.toilet_light_constrained");
		public InputBooleanEntity UtilityRoomLightConstrained => new(_haContext, "input_boolean.utility_room_light_constrained");
	}

    public class InputSelectEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputSelectEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public InputSelectEntity Ambience => new(_haContext, "input_select.ambience");
		public InputSelectEntity AndyClaireIphoneLocation => new(_haContext, "input_select.andy_claire_iphone_location");
		public InputSelectEntity BathroomPresence => new(_haContext, "input_select.bathroom_presence");
		public InputSelectEntity BedroomMode => new(_haContext, "input_select.bedroom_mode");
		public InputSelectEntity BedroomPresence => new(_haContext, "input_select.bedroom_presence");
		public InputSelectEntity ClaireLocation => new(_haContext, "input_select.claire_location");
		public InputSelectEntity DiningRoomPresence => new(_haContext, "input_select.dining_room_presence");
		public InputSelectEntity DrawingRoomPresence => new(_haContext, "input_select.drawing_room_presence");
		public InputSelectEntity DressingRoomPresence => new(_haContext, "input_select.dressing_room_presence");
		public InputSelectEntity GuestRoomPresence => new(_haContext, "input_select.guest_room_presence");
		public InputSelectEntity HousePresence => new(_haContext, "input_select.house_presence");
		public InputSelectEntity KitchenPresence => new(_haContext, "input_select.kitchen_presence");
		public InputSelectEntity LightControlMode => new(_haContext, "input_select.light_control_mode");
		public InputSelectEntity LocationMode => new(_haContext, "input_select.location_mode");
		public InputSelectEntity LoungeMode => new(_haContext, "input_select.lounge_mode");
		public InputSelectEntity LoungePresence => new(_haContext, "input_select.lounge_presence");
		public InputSelectEntity LoungeState => new(_haContext, "input_select.lounge_state");
		public InputSelectEntity SnugMode => new(_haContext, "input_select.snug_mode");
		public InputSelectEntity SnugPresence => new(_haContext, "input_select.snug_presence");
		public InputSelectEntity StudioPresence => new(_haContext, "input_select.studio_presence");
		public InputSelectEntity ThemeSelector => new(_haContext, "input_select.theme_selector");
		public InputSelectEntity ToiletPresence => new(_haContext, "input_select.toilet_presence");
		public InputSelectEntity UtilityRoomPresence => new(_haContext, "input_select.utility_room_presence");
	}

	public class LightEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public LightEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public LightEntity AllLights => new(_haContext, "light.all_lights");
		public LightEntity BackDoor => new(_haContext, "light.back_door");
		public LightEntity BasementHall => new(_haContext, "light.basement_hall");
		public LightEntity BasementHallLights => new(_haContext, "light.basement_hall_lights");
		public LightEntity BasementLights => new(_haContext, "light.basement_lights");
		public LightEntity BasementSpare5 => new(_haContext, "light.basement_spare_5");
		public LightEntity BasementSpare6 => new(_haContext, "light.basement_spare_6");
		public LightEntity BasementStairs => new(_haContext, "light.basement_stairs");
		public LightEntity Bathroom => new(_haContext, "light.bathroom");
		public LightEntity BathroomLights => new(_haContext, "light.bathroom_lights");
		public LightEntity Bedroom => new(_haContext, "light.bedroom");
		public LightEntity BedroomLights => new(_haContext, "light.bedroom_lights");
		public LightEntity BedsideLamp => new(_haContext, "light.bedside_lamp");
		public LightEntity Bookshelf => new(_haContext, "light.bookshelf");
		public LightEntity BreakfastBarLamp => new(_haContext, "light.breakfast_bar_lamp");
		public LightEntity Brewery => new(_haContext, "light.brewery");
		public LightEntity Cabinet => new(_haContext, "light.cabinet");
		public LightEntity CellarDoor => new(_haContext, "light.cellar_door");
		public LightEntity DiningRoom => new(_haContext, "light.dining_room");
		public LightEntity DownstairsLights => new(_haContext, "light.downstairs_lights");
		public LightEntity DrawingRoom => new(_haContext, "light.drawing_room");
		public LightEntity DrawingRoomLights => new(_haContext, "light.drawing_room_lights");
		public LightEntity DressingRoom => new(_haContext, "light.dressing_room");
		public LightEntity GardenLights => new(_haContext, "light.garden_lights");
		public LightEntity GroundfloorSpare1 => new(_haContext, "light.groundfloor_spare_1");
		public LightEntity GuestRoom => new(_haContext, "light.guest_room");
		public LightEntity Hallway => new(_haContext, "light.hallway");
		public LightEntity HallwayLamp => new(_haContext, "light.hallway_lamp");
		public LightEntity HallwayLights => new(_haContext, "light.hallway_lights");
		public LightEntity InsideLights => new(_haContext, "light.inside_lights");
		public LightEntity Kitchen => new(_haContext, "light.kitchen");
		public LightEntity KitchenLights => new(_haContext, "light.kitchen_lights");
		public LightEntity Landing => new(_haContext, "light.landing");
		public LightEntity Lounge => new(_haContext, "light.lounge");
		public LightEntity LoungeCornerLamp => new(_haContext, "light.lounge_corner_lamp");
		public LightEntity LoungeFloorLamp => new(_haContext, "light.lounge_floor_lamp");
		public LightEntity LoungeLights => new(_haContext, "light.lounge_lights");
		public LightEntity Mirror => new(_haContext, "light.mirror");
		public LightEntity OutsideLights => new(_haContext, "light.outside_lights");
		public LightEntity Patio => new(_haContext, "light.patio");
		public LightEntity PatioLights => new(_haContext, "light.patio_lights");
		public LightEntity Porch => new(_haContext, "light.porch");
		public LightEntity Snug => new(_haContext, "light.snug");
		public LightEntity SnugFloorLamp => new(_haContext, "light.snug_floor_lamp");
		public LightEntity SnugLights => new(_haContext, "light.snug_lights");
		public LightEntity Studio => new(_haContext, "light.studio");
		public LightEntity Toilet => new(_haContext, "light.toilet");
		public LightEntity UpstairsLights => new(_haContext, "light.upstairs_lights");
		public LightEntity UtilityRoom => new(_haContext, "light.utility_room");
		public LightEntity UtilityRoomLights => new(_haContext, "light.utility_room_lights");
		public LightEntity Yeelights => new(_haContext, "light.yeelights");
	}

	public class MediaPlayerEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public MediaPlayerEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public MediaPlayerEntity AllSpeakers => new(_haContext, "media_player.all_speakers");
		public MediaPlayerEntity AndrewSEchoBuds => new(_haContext, "media_player.andrew_s_echo_buds");
		public MediaPlayerEntity AndrewSFireTv => new(_haContext, "media_player.andrew_s_fire_tv");
		public MediaPlayerEntity BedroomEchoShow => new(_haContext, "media_player.bedroom_echo_show");
		public MediaPlayerEntity DiningRoomEchoInput => new(_haContext, "media_player.dining_room_echo_input");
		public MediaPlayerEntity DiningRoomRadio => new(_haContext, "media_player.dining_room_radio");
		public MediaPlayerEntity Downstairs => new(_haContext, "media_player.downstairs");
		public MediaPlayerEntity DrawingRoomEchoDot => new(_haContext, "media_player.drawing_room_echo_dot");
		public MediaPlayerEntity DressingRoomEchoDot => new(_haContext, "media_player.dressing_room_echo_dot");
		public MediaPlayerEntity GuestRoomEchoShow => new(_haContext, "media_player.guest_room_echo_show");
		public MediaPlayerEntity HallTablet => new(_haContext, "media_player.hall_tablet");
		public MediaPlayerEntity KitchenEchoShow => new(_haContext, "media_player.kitchen_echo_show");
		public MediaPlayerEntity LandingTablet => new(_haContext, "media_player.landing_tablet");
		public MediaPlayerEntity LoungeEchoPlus => new(_haContext, "media_player.lounge_echo_plus");
		public MediaPlayerEntity LoungeFireTv => new(_haContext, "media_player.lounge_fire_tv");
		public MediaPlayerEntity Snug => new(_haContext, "media_player.snug");
		public MediaPlayerEntity SnugEchoInput => new(_haContext, "media_player.snug_echo_input");
		public MediaPlayerEntity SnugRadio => new(_haContext, "media_player.snug_radio");
		public MediaPlayerEntity SpotifyAndrewMcinnes => new(_haContext, "media_player.spotify_andrew_mcinnes");
		public MediaPlayerEntity Upstairs => new(_haContext, "media_player.upstairs");
		public MediaPlayerEntity UtilityRoomEchoDot => new(_haContext, "media_player.utility_room_echo_dot");
	}

	public class NumberEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NumberEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public NumberEntity EspresenseBedroomMaxDistance => new(_haContext, "number.espresense_bedroom_max_distance");
		public NumberEntity EspresenseDrawingroomMaxDistance => new(_haContext, "number.espresense_drawingroom_max_distance");
		public NumberEntity EspresenseKitchenMaxDistance => new(_haContext, "number.espresense_kitchen_max_distance");
		public NumberEntity EspresenseLoungeMaxDistance => new(_haContext, "number.espresense_lounge_max_distance");
		public NumberEntity EspresenseSnugMaxDistance => new(_haContext, "number.espresense_snug_max_distance");
		public NumberEntity EspresenseStudioMaxDistance => new(_haContext, "number.espresense_studio_max_distance");
		public NumberEntity MicrophoneLevelBasementHallCamera => new(_haContext, "number.microphone_level_basement_hall_camera");
		public NumberEntity MicrophoneLevelKitchenCamera => new(_haContext, "number.microphone_level_kitchen_camera");
		public NumberEntity MicrophoneLevelPatioCamera => new(_haContext, "number.microphone_level_patio_camera");
		public NumberEntity WideDynamicRangeBasementHallCamera => new(_haContext, "number.wide_dynamic_range_basement_hall_camera");
		public NumberEntity WideDynamicRangeKitchenCamera => new(_haContext, "number.wide_dynamic_range_kitchen_camera");
		public NumberEntity WideDynamicRangePatioCamera => new(_haContext, "number.wide_dynamic_range_patio_camera");
	}

	public class PersistentNotificationEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public PersistentNotificationEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public PersistentNotificationEntity HttpLogin => new(_haContext, "persistent_notification.http_login");
	}

	public class PersonEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public PersonEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public PersonEntity Andy => new(_haContext, "person.andy");
		public PersonEntity Claire => new(_haContext, "person.claire");
	}

	public class SceneEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SceneEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public SceneEntity BathroomNormal => new(_haContext, "scene.bathroom_normal");
		public SceneEntity GetReadyForBed => new(_haContext, "scene.get_ready_for_bed");
		public SceneEntity GetUp => new(_haContext, "scene.get_up");
		public SceneEntity LightingAmbient => new(_haContext, "scene.lighting_ambient");
		public SceneEntity LightingBright => new(_haContext, "scene.lighting_bright");
		public SceneEntity LightingDay => new(_haContext, "scene.lighting_day");
		public SceneEntity LightingEvening => new(_haContext, "scene.lighting_evening");
		public SceneEntity LightingNight => new(_haContext, "scene.lighting_night");
		public SceneEntity LightsUp => new(_haContext, "scene.lights_up");
		public SceneEntity LoungeNormal => new(_haContext, "scene.lounge_normal");
		public SceneEntity Showering => new(_haContext, "scene.showering");
		public SceneEntity WatchMovie => new(_haContext, "scene.watch_movie");
		public SceneEntity WatchTv => new(_haContext, "scene.watch_tv");
	}

	public class ScriptEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ScriptEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public ScriptEntity DoorbellAlexa => new(_haContext, "script.doorbell_alexa");
		public ScriptEntity EntityControllerReset => new(_haContext, "script.entity_controller_reset");
		public ScriptEntity FeedCats => new(_haContext, "script.feed_cats");
		public ScriptEntity LightEffectContinuous => new(_haContext, "script.light_effect_continuous");
		public ScriptEntity LightEffectTimed => new(_haContext, "script.light_effect_timed");
		public ScriptEntity NotifyAlexaEverywhere => new(_haContext, "script.notify_alexa_everywhere");
		public ScriptEntity NotifyAll => new(_haContext, "script.notify_all");
		public ScriptEntity NotifyPushbullet => new(_haContext, "script.notify_pushbullet");
		public ScriptEntity RoomControllerReset => new(_haContext, "script.room_controller_reset");
	}

	public class SelectEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SelectEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public SelectEntity InfraredBasementHallCamera => new(_haContext, "select.infrared_basement_hall_camera");
		public SelectEntity InfraredKitchenCamera => new(_haContext, "select.infrared_kitchen_camera");
		public SelectEntity InfraredPatioCamera => new(_haContext, "select.infrared_patio_camera");
		public SelectEntity RecordingModeBasementHallCamera => new(_haContext, "select.recording_mode_basement_hall_camera");
		public SelectEntity RecordingModeKitchenCamera => new(_haContext, "select.recording_mode_kitchen_camera");
		public SelectEntity RecordingModePatioCamera => new(_haContext, "select.recording_mode_patio_camera");
	}

	public class SensorEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SensorEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public SensorEntity AdguardAverageProcessingSpeed => new(_haContext, "sensor.adguard_average_processing_speed");
		public SensorEntity AdguardDnsQueries => new(_haContext, "sensor.adguard_dns_queries");
		public SensorEntity AdguardDnsQueriesBlocked => new(_haContext, "sensor.adguard_dns_queries_blocked");
		public SensorEntity AdguardDnsQueriesBlockedRatio => new(_haContext, "sensor.adguard_dns_queries_blocked_ratio");
		public SensorEntity AdguardParentalControlBlocked => new(_haContext, "sensor.adguard_parental_control_blocked");
		public SensorEntity AdguardRulesCount => new(_haContext, "sensor.adguard_rules_count");
		public SensorEntity AdguardSafeBrowsingBlocked => new(_haContext, "sensor.adguard_safe_browsing_blocked");
		public SensorEntity AndrewSEchoBudsNextReminder => new(_haContext, "sensor.andrew_s_echo_buds_next_reminder");
		public SensorEntity AndrewSFireTvNextAlarm => new(_haContext, "sensor.andrew_s_fire_tv_next_alarm");
		public SensorEntity AndrewSFireTvNextReminder => new(_haContext, "sensor.andrew_s_fire_tv_next_reminder");
		public SensorEntity AndrewSFireTvNextTimer => new(_haContext, "sensor.andrew_s_fire_tv_next_timer");
		public SensorEntity AndrewsIphoneActivity => new(_haContext, "sensor.andrews_iphone_activity");
		public SensorEntity AndrewsIphoneAverageActivePace => new(_haContext, "sensor.andrews_iphone_average_active_pace");
		public SensorEntity AndrewsIphoneBatteryLevel => new(_haContext, "sensor.andrews_iphone_battery_level");
		public SensorEntity AndrewsIphoneBatteryState => new(_haContext, "sensor.andrews_iphone_battery_state");
		public SensorEntity AndrewsIphoneBssid => new(_haContext, "sensor.andrews_iphone_bssid");
		public SensorEntity AndrewsIphoneConnectionType => new(_haContext, "sensor.andrews_iphone_connection_type");
		public SensorEntity AndrewsIphoneDistance => new(_haContext, "sensor.andrews_iphone_distance");
		public SensorEntity AndrewsIphoneFloorsAscended => new(_haContext, "sensor.andrews_iphone_floors_ascended");
		public SensorEntity AndrewsIphoneFloorsDescended => new(_haContext, "sensor.andrews_iphone_floors_descended");
		public SensorEntity AndrewsIphoneGeocodedLocation => new(_haContext, "sensor.andrews_iphone_geocoded_location");
		public SensorEntity AndrewsIphoneLastUpdateTrigger => new(_haContext, "sensor.andrews_iphone_last_update_trigger");
		public SensorEntity AndrewsIphoneSim1 => new(_haContext, "sensor.andrews_iphone_sim_1");
		public SensorEntity AndrewsIphoneSsid => new(_haContext, "sensor.andrews_iphone_ssid");
		public SensorEntity AndrewsIphoneSteps => new(_haContext, "sensor.andrews_iphone_steps");
		public SensorEntity AndrewsIphoneStorage => new(_haContext, "sensor.andrews_iphone_storage");
		public SensorEntity AndyClaireIphone => new(_haContext, "sensor.andy_claire_iphone");
		public SensorEntity AndyKeysTile => new(_haContext, "sensor.andy_keys_tile");
		public SensorEntity BackupState => new(_haContext, "sensor.backup_state");
		public SensorEntity BasementStairsMotionBattery => new(_haContext, "sensor.basement_stairs_motion_battery");
		public SensorEntity BasementThermostatHumidity => new(_haContext, "sensor.basement_thermostat_humidity");
		public SensorEntity BasementThermostatHvacState => new(_haContext, "sensor.basement_thermostat_hvac_state");
		public SensorEntity BasementThermostatOperationMode => new(_haContext, "sensor.basement_thermostat_operation_mode");
		public SensorEntity BasementThermostatTarget => new(_haContext, "sensor.basement_thermostat_target");
		public SensorEntity BasementThermostatTemperature => new(_haContext, "sensor.basement_thermostat_temperature");
		public SensorEntity BathroomDoorBattery => new(_haContext, "sensor.bathroom_door_battery");
		public SensorEntity BedroomEchoShowNextAlarm => new(_haContext, "sensor.bedroom_echo_show_next_alarm");
		public SensorEntity BedroomEchoShowNextReminder => new(_haContext, "sensor.bedroom_echo_show_next_reminder");
		public SensorEntity BedroomEchoShowNextTimer => new(_haContext, "sensor.bedroom_echo_show_next_timer");
		public SensorEntity BlackRefuse => new(_haContext, "sensor.black_refuse");
		public SensorEntity BluePaper => new(_haContext, "sensor.blue_paper");
		public SensorEntity BrotherHl3150cdwSeries => new(_haContext, "sensor.brother_hl_3150cdw_series");
		public SensorEntity BrotherHl3150cdwSeriesBlackTonerCartridge => new(_haContext, "sensor.brother_hl_3150cdw_series_black_toner_cartridge");
		public SensorEntity BrotherHl3150cdwSeriesCyanTonerCartridge => new(_haContext, "sensor.brother_hl_3150cdw_series_cyan_toner_cartridge");
		public SensorEntity BrotherHl3150cdwSeriesMagentaTonerCartridge => new(_haContext, "sensor.brother_hl_3150cdw_series_magenta_toner_cartridge");
		public SensorEntity BrotherHl3150cdwSeriesYellowTonerCartridge => new(_haContext, "sensor.brother_hl_3150cdw_series_yellow_toner_cartridge");
		public SensorEntity BrotherMfcJ5910dw => new(_haContext, "sensor.brother_mfc_j5910dw");
		public SensorEntity BrotherMfcJ5910dwBlackInkCartridge => new(_haContext, "sensor.brother_mfc_j5910dw_black_ink_cartridge");
		public SensorEntity BrotherMfcJ5910dwCyanInkCartridge => new(_haContext, "sensor.brother_mfc_j5910dw_cyan_ink_cartridge");
		public SensorEntity BrotherMfcJ5910dwMagentaInkCartridge => new(_haContext, "sensor.brother_mfc_j5910dw_magenta_ink_cartridge");
		public SensorEntity BrotherMfcJ5910dwYellowInkCartridge => new(_haContext, "sensor.brother_mfc_j5910dw_yellow_ink_cartridge");
		public SensorEntity BrownRecyclables => new(_haContext, "sensor.brown_recyclables");
		public SensorEntity BulbEnergyMeterEnergyMeter => new(_haContext, "sensor.bulb_energy_meter_energy_meter");
		public SensorEntity BulbEnergyMeterGasMeter => new(_haContext, "sensor.bulb_energy_meter_gas_meter");
		public SensorEntity BulbEnergyMeterGasMeterCalorific => new(_haContext, "sensor.bulb_energy_meter_gas_meter_calorific");
		public SensorEntity BulbEnergyMeterGasMeterTime => new(_haContext, "sensor.bulb_energy_meter_gas_meter_time");
		public SensorEntity BulbEnergyMeterGasMeterVolume => new(_haContext, "sensor.bulb_energy_meter_gas_meter_volume");
		public SensorEntity CarKeysTile => new(_haContext, "sensor.car_keys_tile");
		public SensorEntity CatFeederBssid => new(_haContext, "sensor.cat_feeder_bssid");
		public SensorEntity CatFeederEsphomeVersion => new(_haContext, "sensor.cat_feeder_esphome_version");
		public SensorEntity CatFeederIp => new(_haContext, "sensor.cat_feeder_ip");
		public SensorEntity CatFeederSsid => new(_haContext, "sensor.cat_feeder_ssid");
		public SensorEntity CatFeederUptime => new(_haContext, "sensor.cat_feeder_uptime");
		public SensorEntity CatFeederWifiSignal => new(_haContext, "sensor.cat_feeder_wifi_signal");
		public SensorEntity ClaireKeysTile => new(_haContext, "sensor.claire_keys_tile");
		public SensorEntity ClairesIphoneActivity => new(_haContext, "sensor.claires_iphone_activity");
		public SensorEntity ClairesIphoneAverageActivePace => new(_haContext, "sensor.claires_iphone_average_active_pace");
		public SensorEntity ClairesIphoneBatteryLevel => new(_haContext, "sensor.claires_iphone_battery_level");
		public SensorEntity ClairesIphoneBatteryState => new(_haContext, "sensor.claires_iphone_battery_state");
		public SensorEntity ClairesIphoneBssid => new(_haContext, "sensor.claires_iphone_bssid");
		public SensorEntity ClairesIphoneConnectionType => new(_haContext, "sensor.claires_iphone_connection_type");
		public SensorEntity ClairesIphoneDistance => new(_haContext, "sensor.claires_iphone_distance");
		public SensorEntity ClairesIphoneFloorsAscended => new(_haContext, "sensor.claires_iphone_floors_ascended");
		public SensorEntity ClairesIphoneFloorsDescended => new(_haContext, "sensor.claires_iphone_floors_descended");
		public SensorEntity ClairesIphoneGeocodedLocation => new(_haContext, "sensor.claires_iphone_geocoded_location");
		public SensorEntity ClairesIphoneLastUpdateTrigger => new(_haContext, "sensor.claires_iphone_last_update_trigger");
		public SensorEntity ClairesIphoneSim1 => new(_haContext, "sensor.claires_iphone_sim_1");
		public SensorEntity ClairesIphoneSsid => new(_haContext, "sensor.claires_iphone_ssid");
		public SensorEntity ClairesIphoneSteps => new(_haContext, "sensor.claires_iphone_steps");
		public SensorEntity ClairesIphoneStorage => new(_haContext, "sensor.claires_iphone_storage");
		public SensorEntity DiningRoomEchoInputNextAlarm => new(_haContext, "sensor.dining_room_echo_input_next_alarm");
		public SensorEntity DiningRoomEchoInputNextReminder => new(_haContext, "sensor.dining_room_echo_input_next_reminder");
		public SensorEntity DiningRoomEchoInputNextTimer => new(_haContext, "sensor.dining_room_echo_input_next_timer");
		public SensorEntity DoorbellBssid => new(_haContext, "sensor.doorbell_bssid");
		public SensorEntity DoorbellEsphomeVersion => new(_haContext, "sensor.doorbell_esphome_version");
		public SensorEntity DoorbellIp => new(_haContext, "sensor.doorbell_ip");
		public SensorEntity DoorbellSsid => new(_haContext, "sensor.doorbell_ssid");
		public SensorEntity DoorbellUptime => new(_haContext, "sensor.doorbell_uptime");
		public SensorEntity DoorbellWifiSignal => new(_haContext, "sensor.doorbell_wifi_signal");
		public SensorEntity DownstairsThermostatCurrentTemperature => new(_haContext, "sensor.downstairs_thermostat_current_temperature");
		public SensorEntity DownstairsThermostatHumidity => new(_haContext, "sensor.downstairs_thermostat_humidity");
		public SensorEntity DownstairsThermostatHvacState => new(_haContext, "sensor.downstairs_thermostat_hvac_state");
		public SensorEntity DownstairsThermostatOperationMode => new(_haContext, "sensor.downstairs_thermostat_operation_mode");
		public SensorEntity DownstairsThermostatTarget => new(_haContext, "sensor.downstairs_thermostat_target");
		public SensorEntity DownstairsThermostatTemperature => new(_haContext, "sensor.downstairs_thermostat_temperature");
		public SensorEntity DrawingRoomEchoDotNextAlarm => new(_haContext, "sensor.drawing_room_echo_dot_next_alarm");
		public SensorEntity DrawingRoomEchoDotNextReminder => new(_haContext, "sensor.drawing_room_echo_dot_next_reminder");
		public SensorEntity DrawingRoomEchoDotNextTimer => new(_haContext, "sensor.drawing_room_echo_dot_next_timer");
		public SensorEntity DressingRoomEchoDotNextAlarm => new(_haContext, "sensor.dressing_room_echo_dot_next_alarm");
		public SensorEntity DressingRoomEchoDotNextReminder => new(_haContext, "sensor.dressing_room_echo_dot_next_reminder");
		public SensorEntity DressingRoomEchoDotNextTimer => new(_haContext, "sensor.dressing_room_echo_dot_next_timer");
		public SensorEntity DwainsDashboardLatestVersion => new(_haContext, "sensor.dwains_dashboard_latest_version");
		public SensorEntity ElectricCabinetDoorBattery => new(_haContext, "sensor.electric_cabinet_door_battery");
		public SensorEntity ElectricCabinetDoorLinkquality => new(_haContext, "sensor.electric_cabinet_door_linkquality");
		public SensorEntity ElectricCabinetDoorVoltage => new(_haContext, "sensor.electric_cabinet_door_voltage");
		public SensorEntity EwelinkSmartHomeNewestVersion => new(_haContext, "sensor.ewelink_smart_home_newest_version");
		public SensorEntity EwelinkSmartHomeVersion => new(_haContext, "sensor.ewelink_smart_home_version");
		public SensorEntity FrontDoorBattery => new(_haContext, "sensor.front_door_battery");
		public SensorEntity FrontDoorLinkquality => new(_haContext, "sensor.front_door_linkquality");
		public SensorEntity FrontDoorVoltage => new(_haContext, "sensor.front_door_voltage");
		public SensorEntity GreenBioWaste => new(_haContext, "sensor.green_bio_waste");
		public SensorEntity GuestRoomEchoShowNextAlarm => new(_haContext, "sensor.guest_room_echo_show_next_alarm");
		public SensorEntity GuestRoomEchoShowNextReminder => new(_haContext, "sensor.guest_room_echo_show_next_reminder");
		public SensorEntity GuestRoomEchoShowNextTimer => new(_haContext, "sensor.guest_room_echo_show_next_timer");
		public SensorEntity Hacs => new(_haContext, "sensor.hacs");
		public SensorEntity HallTabletNextAlarm => new(_haContext, "sensor.hall_tablet_next_alarm");
		public SensorEntity HallTabletNextReminder => new(_haContext, "sensor.hall_tablet_next_reminder");
		public SensorEntity HallTabletNextTimer => new(_haContext, "sensor.hall_tablet_next_timer");
		public SensorEntity Hass => new(_haContext, "sensor.hass");
		public SensorEntity Hl3150cdwBWCounter => new(_haContext, "sensor.hl_3150cdw_b_w_counter");
		public SensorEntity Hl3150cdwBeltUnitRemainingLife => new(_haContext, "sensor.hl_3150cdw_belt_unit_remaining_life");
		public SensorEntity Hl3150cdwBlackDrumRemainingLife => new(_haContext, "sensor.hl_3150cdw_black_drum_remaining_life");
		public SensorEntity Hl3150cdwBlackTonerRemaining => new(_haContext, "sensor.hl_3150cdw_black_toner_remaining");
		public SensorEntity Hl3150cdwColorCounter => new(_haContext, "sensor.hl_3150cdw_color_counter");
		public SensorEntity Hl3150cdwCyanDrumRemainingLife => new(_haContext, "sensor.hl_3150cdw_cyan_drum_remaining_life");
		public SensorEntity Hl3150cdwCyanTonerRemaining => new(_haContext, "sensor.hl_3150cdw_cyan_toner_remaining");
		public SensorEntity Hl3150cdwFuserRemainingLife => new(_haContext, "sensor.hl_3150cdw_fuser_remaining_life");
		public SensorEntity Hl3150cdwMagentaDrumRemainingLife => new(_haContext, "sensor.hl_3150cdw_magenta_drum_remaining_life");
		public SensorEntity Hl3150cdwMagentaTonerRemaining => new(_haContext, "sensor.hl_3150cdw_magenta_toner_remaining");
		public SensorEntity Hl3150cdwPageCounter => new(_haContext, "sensor.hl_3150cdw_page_counter");
		public SensorEntity Hl3150cdwPfKit1RemainingLife => new(_haContext, "sensor.hl_3150cdw_pf_kit_1_remaining_life");
		public SensorEntity Hl3150cdwStatus => new(_haContext, "sensor.hl_3150cdw_status");
		public SensorEntity Hl3150cdwYellowDrumRemainingLife => new(_haContext, "sensor.hl_3150cdw_yellow_drum_remaining_life");
		public SensorEntity Hl3150cdwYellowTonerRemaining => new(_haContext, "sensor.hl_3150cdw_yellow_toner_remaining");
		public SensorEntity KitchenEchoShowNextAlarm => new(_haContext, "sensor.kitchen_echo_show_next_alarm");
		public SensorEntity KitchenEchoShowNextReminder => new(_haContext, "sensor.kitchen_echo_show_next_reminder");
		public SensorEntity KitchenEchoShowNextTimer => new(_haContext, "sensor.kitchen_echo_show_next_timer");
		public SensorEntity LandingTabletNextAlarm => new(_haContext, "sensor.landing_tablet_next_alarm");
		public SensorEntity LandingTabletNextReminder => new(_haContext, "sensor.landing_tablet_next_reminder");
		public SensorEntity LandingTabletNextTimer => new(_haContext, "sensor.landing_tablet_next_timer");
		public SensorEntity LocalIp => new(_haContext, "sensor.local_ip");
		public SensorEntity LoftHatchBattery => new(_haContext, "sensor.loft_hatch_battery");
		public SensorEntity LoftHatchLinkquality => new(_haContext, "sensor.loft_hatch_linkquality");
		public SensorEntity LoftHatchVoltage => new(_haContext, "sensor.loft_hatch_voltage");
		public SensorEntity LoungeEchoPlusNextAlarm => new(_haContext, "sensor.lounge_echo_plus_next_alarm");
		public SensorEntity LoungeEchoPlusNextReminder => new(_haContext, "sensor.lounge_echo_plus_next_reminder");
		public SensorEntity LoungeEchoPlusNextTimer => new(_haContext, "sensor.lounge_echo_plus_next_timer");
		public SensorEntity LoungeFireTvNextAlarm => new(_haContext, "sensor.lounge_fire_tv_next_alarm");
		public SensorEntity LoungeFireTvNextReminder => new(_haContext, "sensor.lounge_fire_tv_next_reminder");
		public SensorEntity LoungeFireTvNextTimer => new(_haContext, "sensor.lounge_fire_tv_next_timer");
		public SensorEntity LoungeTvEnergyMeter => new(_haContext, "sensor.lounge_tv_energy_meter");
		public SensorEntity LoungeTvMediaInputSource => new(_haContext, "sensor.lounge_tv_media_input_source");
		public SensorEntity LoungeTvMediaPlaybackStatus => new(_haContext, "sensor.lounge_tv_media_playback_status");
		public SensorEntity LoungeTvPowerMeter => new(_haContext, "sensor.lounge_tv_power_meter");
		public SensorEntity LoungeTvTvChannel => new(_haContext, "sensor.lounge_tv_tv_channel");
		public SensorEntity LoungeTvTvChannelName => new(_haContext, "sensor.lounge_tv_tv_channel_name");
		public SensorEntity LoungeTvVolume => new(_haContext, "sensor.lounge_tv_volume");
		public SensorEntity ManchesterRoadEta => new(_haContext, "sensor.manchester_road_eta");
		public SensorEntity MarkBattery => new(_haContext, "sensor.mark_battery");
		public SensorEntity MfcJ5910dwBlackInkRemaining => new(_haContext, "sensor.mfc_j5910dw_black_ink_remaining");
		public SensorEntity MfcJ5910dwCyanInkRemaining => new(_haContext, "sensor.mfc_j5910dw_cyan_ink_remaining");
		public SensorEntity MfcJ5910dwMagentaInkRemaining => new(_haContext, "sensor.mfc_j5910dw_magenta_ink_remaining");
		public SensorEntity MfcJ5910dwPageCounter => new(_haContext, "sensor.mfc_j5910dw_page_counter");
		public SensorEntity MfcJ5910dwStatus => new(_haContext, "sensor.mfc_j5910dw_status");
		public SensorEntity MfcJ5910dwYellowInkRemaining => new(_haContext, "sensor.mfc_j5910dw_yellow_ink_remaining");
		public SensorEntity MotionRecordingBasementHallCamera => new(_haContext, "sensor.motion_recording_basement_hall_camera");
		public SensorEntity MotionRecordingKitchenCamera => new(_haContext, "sensor.motion_recording_kitchen_camera");
		public SensorEntity MotionRecordingPatioCamera => new(_haContext, "sensor.motion_recording_patio_camera");
		public SensorEntity Myip => new(_haContext, "sensor.myip");
		public SensorEntity NetdaemonStatus => new(_haContext, "sensor.netdaemon_status");
		public SensorEntity PatioCameraDetectedObject => new(_haContext, "sensor.patio_camera_detected_object");
		public SensorEntity SearchesSafeSearchEnforced => new(_haContext, "sensor.searches_safe_search_enforced");
		public SensorEntity SnugEchoInputNextAlarm => new(_haContext, "sensor.snug_echo_input_next_alarm");
		public SensorEntity SnugEchoInputNextReminder => new(_haContext, "sensor.snug_echo_input_next_reminder");
		public SensorEntity SnugEchoInputNextTimer => new(_haContext, "sensor.snug_echo_input_next_timer");
		public SensorEntity SnugSwitchAction => new(_haContext, "sensor.snug_switch_action");
		public SensorEntity SnugSwitchBattery => new(_haContext, "sensor.snug_switch_battery");
		public SensorEntity SonoffBridge1Status => new(_haContext, "sensor.sonoff_bridge_1_status");
		public SensorEntity SpeedtestDownload => new(_haContext, "sensor.speedtest_download");
		public SensorEntity SpeedtestPing => new(_haContext, "sensor.speedtest_ping");
		public SensorEntity SpeedtestUpload => new(_haContext, "sensor.speedtest_upload");
		public SensorEntity SumpAlarmBssid => new(_haContext, "sensor.sump_alarm_bssid");
		public SensorEntity SumpAlarmEsphomeVersion => new(_haContext, "sensor.sump_alarm_esphome_version");
		public SensorEntity SumpAlarmIp => new(_haContext, "sensor.sump_alarm_ip");
		public SensorEntity SumpAlarmSsid => new(_haContext, "sensor.sump_alarm_ssid");
		public SensorEntity SumpAlarmUptime => new(_haContext, "sensor.sump_alarm_uptime");
		public SensorEntity SumpAlarmWifiSignal => new(_haContext, "sensor.sump_alarm_wifi_signal");
		public SensorEntity ToiletDoorBattery => new(_haContext, "sensor.toilet_door_battery");
		public SensorEntity UnifiDreamMachineBReceived => new(_haContext, "sensor.unifi_dream_machine_b_received");
		public SensorEntity UnifiDreamMachineBSent => new(_haContext, "sensor.unifi_dream_machine_b_sent");
		public SensorEntity UnifiDreamMachineExternalIp => new(_haContext, "sensor.unifi_dream_machine_external_ip");
		public SensorEntity UnifiDreamMachineKibSReceived => new(_haContext, "sensor.unifi_dream_machine_kib_s_received");
		public SensorEntity UnifiDreamMachineKibSSent => new(_haContext, "sensor.unifi_dream_machine_kib_s_sent");
		public SensorEntity UnifiDreamMachineKibSSent2 => new(_haContext, "sensor.unifi_dream_machine_kib_s_sent_2");
		public SensorEntity UnifiDreamMachinePacketsReceived => new(_haContext, "sensor.unifi_dream_machine_packets_received");
		public SensorEntity UnifiDreamMachinePacketsSReceived => new(_haContext, "sensor.unifi_dream_machine_packets_s_received");
		public SensorEntity UnifiDreamMachinePacketsSSent => new(_haContext, "sensor.unifi_dream_machine_packets_s_sent");
		public SensorEntity UnifiDreamMachinePacketsSSent2 => new(_haContext, "sensor.unifi_dream_machine_packets_s_sent_2");
		public SensorEntity UnifiDreamMachinePacketsSent => new(_haContext, "sensor.unifi_dream_machine_packets_sent");
		public SensorEntity UnifiDreamMachineWanStatus => new(_haContext, "sensor.unifi_dream_machine_wan_status");
		public SensorEntity UnitedKingdomCoronavirusConfirmed => new(_haContext, "sensor.united_kingdom_coronavirus_confirmed");
		public SensorEntity UnitedKingdomCoronavirusCurrent => new(_haContext, "sensor.united_kingdom_coronavirus_current");
		public SensorEntity UnitedKingdomCoronavirusDeaths => new(_haContext, "sensor.united_kingdom_coronavirus_deaths");
		public SensorEntity UnitedKingdomCoronavirusRecovered => new(_haContext, "sensor.united_kingdom_coronavirus_recovered");
		public SensorEntity UpstairsThermostatCurrentTemperature => new(_haContext, "sensor.upstairs_thermostat_current_temperature");
		public SensorEntity UpstairsThermostatHumidity => new(_haContext, "sensor.upstairs_thermostat_humidity");
		public SensorEntity UpstairsThermostatHvacState => new(_haContext, "sensor.upstairs_thermostat_hvac_state");
		public SensorEntity UpstairsThermostatOperationMode => new(_haContext, "sensor.upstairs_thermostat_operation_mode");
		public SensorEntity UpstairsThermostatTarget => new(_haContext, "sensor.upstairs_thermostat_target");
		public SensorEntity UpstairsThermostatTemperature => new(_haContext, "sensor.upstairs_thermostat_temperature");
		public SensorEntity UtilityRoomEchoDotNextAlarm => new(_haContext, "sensor.utility_room_echo_dot_next_alarm");
		public SensorEntity UtilityRoomEchoDotNextReminder => new(_haContext, "sensor.utility_room_echo_dot_next_reminder");
		public SensorEntity UtilityRoomEchoDotNextTimer => new(_haContext, "sensor.utility_room_echo_dot_next_timer");
		public SensorEntity WeatherStationAltitude => new(_haContext, "sensor.weather_station_altitude");
		public SensorEntity WeatherStationAmbientLight => new(_haContext, "sensor.weather_station_ambient_light");
		public SensorEntity WeatherStationBssid => new(_haContext, "sensor.weather_station_bssid");
		public SensorEntity WeatherStationEsphomeVersion => new(_haContext, "sensor.weather_station_esphome_version");
		public SensorEntity WeatherStationHumidity => new(_haContext, "sensor.weather_station_humidity");
		public SensorEntity WeatherStationIp => new(_haContext, "sensor.weather_station_ip");
		public SensorEntity WeatherStationPressure => new(_haContext, "sensor.weather_station_pressure");
		public SensorEntity WeatherStationRelativeHumidity => new(_haContext, "sensor.weather_station_relative_humidity");
		public SensorEntity WeatherStationSsid => new(_haContext, "sensor.weather_station_ssid");
		public SensorEntity WeatherStationTemperature => new(_haContext, "sensor.weather_station_temperature");
		public SensorEntity WeatherStationUptime => new(_haContext, "sensor.weather_station_uptime");
		public SensorEntity WeatherStationWifiSignal => new(_haContext, "sensor.weather_station_wifi_signal");
		public SensorEntity WithingsBodyTemperatureCAndy => new(_haContext, "sensor.withings_body_temperature_c_andy");
		public SensorEntity WithingsBodyTemperatureCClaire => new(_haContext, "sensor.withings_body_temperature_c_claire");
		public SensorEntity WithingsBoneMassKgAndy => new(_haContext, "sensor.withings_bone_mass_kg_andy");
		public SensorEntity WithingsBoneMassKgClaire => new(_haContext, "sensor.withings_bone_mass_kg_claire");
		public SensorEntity WithingsDiastolicBloodPressureMmhgAndy => new(_haContext, "sensor.withings_diastolic_blood_pressure_mmhg_andy");
		public SensorEntity WithingsDiastolicBloodPressureMmhgClaire => new(_haContext, "sensor.withings_diastolic_blood_pressure_mmhg_claire");
		public SensorEntity WithingsFatFreeMassKgAndy => new(_haContext, "sensor.withings_fat_free_mass_kg_andy");
		public SensorEntity WithingsFatFreeMassKgClaire => new(_haContext, "sensor.withings_fat_free_mass_kg_claire");
		public SensorEntity WithingsFatMassKgAndy => new(_haContext, "sensor.withings_fat_mass_kg_andy");
		public SensorEntity WithingsFatMassKgClaire => new(_haContext, "sensor.withings_fat_mass_kg_claire");
		public SensorEntity WithingsFatRatioPctAndy => new(_haContext, "sensor.withings_fat_ratio_pct_andy");
		public SensorEntity WithingsFatRatioPctClaire => new(_haContext, "sensor.withings_fat_ratio_pct_claire");
		public SensorEntity WithingsHeartPulseBpmAndy => new(_haContext, "sensor.withings_heart_pulse_bpm_andy");
		public SensorEntity WithingsHeartPulseBpmClaire => new(_haContext, "sensor.withings_heart_pulse_bpm_claire");
		public SensorEntity WithingsHeightMAndy => new(_haContext, "sensor.withings_height_m_andy");
		public SensorEntity WithingsHeightMClaire => new(_haContext, "sensor.withings_height_m_claire");
		public SensorEntity WithingsHydrationAndy => new(_haContext, "sensor.withings_hydration_andy");
		public SensorEntity WithingsHydrationClaire => new(_haContext, "sensor.withings_hydration_claire");
		public SensorEntity WithingsMuscleMassKgAndy => new(_haContext, "sensor.withings_muscle_mass_kg_andy");
		public SensorEntity WithingsMuscleMassKgClaire => new(_haContext, "sensor.withings_muscle_mass_kg_claire");
		public SensorEntity WithingsPulseWaveVelocityAndy => new(_haContext, "sensor.withings_pulse_wave_velocity_andy");
		public SensorEntity WithingsPulseWaveVelocityClaire => new(_haContext, "sensor.withings_pulse_wave_velocity_claire");
		public SensorEntity WithingsSkinTemperatureCAndy => new(_haContext, "sensor.withings_skin_temperature_c_andy");
		public SensorEntity WithingsSkinTemperatureCClaire => new(_haContext, "sensor.withings_skin_temperature_c_claire");
		public SensorEntity WithingsSleepBreathingDisturbancesIntensityAndy => new(_haContext, "sensor.withings_sleep_breathing_disturbances_intensity_andy");
		public SensorEntity WithingsSleepBreathingDisturbancesIntensityClaire => new(_haContext, "sensor.withings_sleep_breathing_disturbances_intensity_claire");
		public SensorEntity WithingsSleepDeepDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_deep_duration_seconds_andy");
		public SensorEntity WithingsSleepDeepDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_deep_duration_seconds_claire");
		public SensorEntity WithingsSleepHeartRateAverageBpmAndy => new(_haContext, "sensor.withings_sleep_heart_rate_average_bpm_andy");
		public SensorEntity WithingsSleepHeartRateAverageBpmClaire => new(_haContext, "sensor.withings_sleep_heart_rate_average_bpm_claire");
		public SensorEntity WithingsSleepHeartRateMaxBpmAndy => new(_haContext, "sensor.withings_sleep_heart_rate_max_bpm_andy");
		public SensorEntity WithingsSleepHeartRateMaxBpmClaire => new(_haContext, "sensor.withings_sleep_heart_rate_max_bpm_claire");
		public SensorEntity WithingsSleepHeartRateMinBpmAndy => new(_haContext, "sensor.withings_sleep_heart_rate_min_bpm_andy");
		public SensorEntity WithingsSleepHeartRateMinBpmClaire => new(_haContext, "sensor.withings_sleep_heart_rate_min_bpm_claire");
		public SensorEntity WithingsSleepLightDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_light_duration_seconds_andy");
		public SensorEntity WithingsSleepLightDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_light_duration_seconds_claire");
		public SensorEntity WithingsSleepRemDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_rem_duration_seconds_andy");
		public SensorEntity WithingsSleepRemDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_rem_duration_seconds_claire");
		public SensorEntity WithingsSleepRespiratoryAverageBpmAndy => new(_haContext, "sensor.withings_sleep_respiratory_average_bpm_andy");
		public SensorEntity WithingsSleepRespiratoryAverageBpmClaire => new(_haContext, "sensor.withings_sleep_respiratory_average_bpm_claire");
		public SensorEntity WithingsSleepRespiratoryMaxBpmAndy => new(_haContext, "sensor.withings_sleep_respiratory_max_bpm_andy");
		public SensorEntity WithingsSleepRespiratoryMaxBpmClaire => new(_haContext, "sensor.withings_sleep_respiratory_max_bpm_claire");
		public SensorEntity WithingsSleepRespiratoryMinBpmAndy => new(_haContext, "sensor.withings_sleep_respiratory_min_bpm_andy");
		public SensorEntity WithingsSleepRespiratoryMinBpmClaire => new(_haContext, "sensor.withings_sleep_respiratory_min_bpm_claire");
		public SensorEntity WithingsSleepScoreAndy => new(_haContext, "sensor.withings_sleep_score_andy");
		public SensorEntity WithingsSleepScoreClaire => new(_haContext, "sensor.withings_sleep_score_claire");
		public SensorEntity WithingsSleepSnoringAndy => new(_haContext, "sensor.withings_sleep_snoring_andy");
		public SensorEntity WithingsSleepSnoringClaire => new(_haContext, "sensor.withings_sleep_snoring_claire");
		public SensorEntity WithingsSleepSnoringEposodeCountAndy => new(_haContext, "sensor.withings_sleep_snoring_eposode_count_andy");
		public SensorEntity WithingsSleepSnoringEposodeCountClaire => new(_haContext, "sensor.withings_sleep_snoring_eposode_count_claire");
		public SensorEntity WithingsSleepTosleepDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_tosleep_duration_seconds_andy");
		public SensorEntity WithingsSleepTosleepDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_tosleep_duration_seconds_claire");
		public SensorEntity WithingsSleepTowakeupDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_towakeup_duration_seconds_andy");
		public SensorEntity WithingsSleepTowakeupDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_towakeup_duration_seconds_claire");
		public SensorEntity WithingsSleepWakeupCountAndy => new(_haContext, "sensor.withings_sleep_wakeup_count_andy");
		public SensorEntity WithingsSleepWakeupCountClaire => new(_haContext, "sensor.withings_sleep_wakeup_count_claire");
		public SensorEntity WithingsSleepWakeupDurationSecondsAndy => new(_haContext, "sensor.withings_sleep_wakeup_duration_seconds_andy");
		public SensorEntity WithingsSleepWakeupDurationSecondsClaire => new(_haContext, "sensor.withings_sleep_wakeup_duration_seconds_claire");
		public SensorEntity WithingsSpo2PctAndy => new(_haContext, "sensor.withings_spo2_pct_andy");
		public SensorEntity WithingsSpo2PctClaire => new(_haContext, "sensor.withings_spo2_pct_claire");
		public SensorEntity WithingsSystolicBloodPressureMmhgAndy => new(_haContext, "sensor.withings_systolic_blood_pressure_mmhg_andy");
		public SensorEntity WithingsSystolicBloodPressureMmhgClaire => new(_haContext, "sensor.withings_systolic_blood_pressure_mmhg_claire");
		public SensorEntity WithingsTemperatureCAndy => new(_haContext, "sensor.withings_temperature_c_andy");
		public SensorEntity WithingsTemperatureCClaire => new(_haContext, "sensor.withings_temperature_c_claire");
		public SensorEntity WithingsWeightKgAndy => new(_haContext, "sensor.withings_weight_kg_andy");
		public SensorEntity WithingsWeightKgClaire => new(_haContext, "sensor.withings_weight_kg_claire");
		public SensorEntity WorldwideCoronavirusConfirmed => new(_haContext, "sensor.worldwide_coronavirus_confirmed");
		public SensorEntity WorldwideCoronavirusCurrent => new(_haContext, "sensor.worldwide_coronavirus_current");
		public SensorEntity WorldwideCoronavirusDeaths => new(_haContext, "sensor.worldwide_coronavirus_deaths");
		public SensorEntity WorldwideCoronavirusRecovered => new(_haContext, "sensor.worldwide_coronavirus_recovered");
	}

	public class SunEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SunEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public SunEntity Sun => new(_haContext, "sun.sun");
	}

	public class SwitchEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SwitchEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public SwitchEntity E100032907e1 => new(_haContext, "switch.100032907e_1");
		public SwitchEntity E100032907e2 => new(_haContext, "switch.100032907e_2");
		public SwitchEntity E100032907e3 => new(_haContext, "switch.100032907e_3");
		public SwitchEntity E100032907e4 => new(_haContext, "switch.100032907e_4");
		public SwitchEntity E100032a00d1 => new(_haContext, "switch.100032a00d_1");
		public SwitchEntity E100032a00d2 => new(_haContext, "switch.100032a00d_2");
		public SwitchEntity E100032a00d3 => new(_haContext, "switch.100032a00d_3");
		public SwitchEntity E100032a00d4 => new(_haContext, "switch.100032a00d_4");
		public SwitchEntity E100032bd731 => new(_haContext, "switch.100032bd73_1");
		public SwitchEntity E100032bd732 => new(_haContext, "switch.100032bd73_2");
		public SwitchEntity E100032bd733 => new(_haContext, "switch.100032bd73_3");
		public SwitchEntity E100032bd734 => new(_haContext, "switch.100032bd73_4");
		public SwitchEntity E1000ba99771 => new(_haContext, "switch.1000ba9977_1");
		public SwitchEntity E1000ba99772 => new(_haContext, "switch.1000ba9977_2");
		public SwitchEntity E1000ba99773 => new(_haContext, "switch.1000ba9977_3");
		public SwitchEntity E1000ba99774 => new(_haContext, "switch.1000ba9977_4");
		public SwitchEntity E1000bab17a1 => new(_haContext, "switch.1000bab17a_1");
		public SwitchEntity E1000bab17a2 => new(_haContext, "switch.1000bab17a_2");
		public SwitchEntity E1000bab17a3 => new(_haContext, "switch.1000bab17a_3");
		public SwitchEntity E1000bab17a4 => new(_haContext, "switch.1000bab17a_4");
		public SwitchEntity E1000bab3811 => new(_haContext, "switch.1000bab381_1");
		public SwitchEntity E1000bab3812 => new(_haContext, "switch.1000bab381_2");
		public SwitchEntity E1000bab3813 => new(_haContext, "switch.1000bab381_3");
		public SwitchEntity E1000bab3814 => new(_haContext, "switch.1000bab381_4");
		public SwitchEntity E1000bab6de1 => new(_haContext, "switch.1000bab6de_1");
		public SwitchEntity E1000bab6de2 => new(_haContext, "switch.1000bab6de_2");
		public SwitchEntity E1000bab6de3 => new(_haContext, "switch.1000bab6de_3");
		public SwitchEntity E1000bab6de4 => new(_haContext, "switch.1000bab6de_4");
		public SwitchEntity AdguardFiltering => new(_haContext, "switch.adguard_filtering");
		public SwitchEntity AdguardParentalControl => new(_haContext, "switch.adguard_parental_control");
		public SwitchEntity AdguardProtection => new(_haContext, "switch.adguard_protection");
		public SwitchEntity AdguardQueryLog => new(_haContext, "switch.adguard_query_log");
		public SwitchEntity AdguardSafeBrowsing => new(_haContext, "switch.adguard_safe_browsing");
		public SwitchEntity AdguardSafeSearch => new(_haContext, "switch.adguard_safe_search");
		public SwitchEntity AllSpeakersDoNotDisturbSwitch => new(_haContext, "switch.all_speakers_do_not_disturb_switch");
		public SwitchEntity AllSpeakersRepeatSwitch => new(_haContext, "switch.all_speakers_repeat_switch");
		public SwitchEntity AllSpeakersShuffleSwitch => new(_haContext, "switch.all_speakers_shuffle_switch");
		public SwitchEntity AndrewSEchoBudsDoNotDisturbSwitch => new(_haContext, "switch.andrew_s_echo_buds_do_not_disturb_switch");
		public SwitchEntity AndrewSFireTvDoNotDisturbSwitch => new(_haContext, "switch.andrew_s_fire_tv_do_not_disturb_switch");
		public SwitchEntity BasementHallCameraOverlayShowBitrate => new(_haContext, "switch.basement_hall_camera_overlay_show_bitrate");
		public SwitchEntity BasementHallCameraOverlayShowDate => new(_haContext, "switch.basement_hall_camera_overlay_show_date");
		public SwitchEntity BasementHallCameraOverlayShowLogo => new(_haContext, "switch.basement_hall_camera_overlay_show_logo");
		public SwitchEntity BasementHallCameraOverlayShowName => new(_haContext, "switch.basement_hall_camera_overlay_show_name");
		public SwitchEntity BedroomEchoShowDoNotDisturbSwitch => new(_haContext, "switch.bedroom_echo_show_do_not_disturb_switch");
		public SwitchEntity BedroomEchoShowRepeatSwitch => new(_haContext, "switch.bedroom_echo_show_repeat_switch");
		public SwitchEntity BedroomEchoShowShuffleSwitch => new(_haContext, "switch.bedroom_echo_show_shuffle_switch");
		public SwitchEntity BoostHotWater => new(_haContext, "switch.boost_hot_water");
		public SwitchEntity CatFeederRestart => new(_haContext, "switch.cat_feeder_restart");
		public SwitchEntity CellarDoorCameraMotionDetection => new(_haContext, "switch.cellar_door_camera_motion_detection");
		public SwitchEntity CellarDoorCameraMovies => new(_haContext, "switch.cellar_door_camera_movies");
		public SwitchEntity CellarDoorCameraStillImages => new(_haContext, "switch.cellar_door_camera_still_images");
		public SwitchEntity DiningRoomEchoInputDoNotDisturbSwitch => new(_haContext, "switch.dining_room_echo_input_do_not_disturb_switch");
		public SwitchEntity DiningRoomEchoInputRepeatSwitch => new(_haContext, "switch.dining_room_echo_input_repeat_switch");
		public SwitchEntity DiningRoomEchoInputShuffleSwitch => new(_haContext, "switch.dining_room_echo_input_shuffle_switch");
		public SwitchEntity DispenserMotor => new(_haContext, "switch.dispenser_motor");
		public SwitchEntity DoorbellChime => new(_haContext, "switch.doorbell_chime");
		public SwitchEntity DoorbellChimeActive => new(_haContext, "switch.doorbell_chime_active");
		public SwitchEntity DoorbellRestart => new(_haContext, "switch.doorbell_restart");
		public SwitchEntity DownstairsDoNotDisturbSwitch => new(_haContext, "switch.downstairs_do_not_disturb_switch");
		public SwitchEntity DownstairsRepeatSwitch => new(_haContext, "switch.downstairs_repeat_switch");
		public SwitchEntity DownstairsShuffleSwitch => new(_haContext, "switch.downstairs_shuffle_switch");
		public SwitchEntity DrawingRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.drawing_room_echo_dot_do_not_disturb_switch");
		public SwitchEntity DrawingRoomEchoDotRepeatSwitch => new(_haContext, "switch.drawing_room_echo_dot_repeat_switch");
		public SwitchEntity DrawingRoomEchoDotShuffleSwitch => new(_haContext, "switch.drawing_room_echo_dot_shuffle_switch");
		public SwitchEntity DressingRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.dressing_room_echo_dot_do_not_disturb_switch");
		public SwitchEntity DressingRoomEchoDotRepeatSwitch => new(_haContext, "switch.dressing_room_echo_dot_repeat_switch");
		public SwitchEntity DressingRoomEchoDotShuffleSwitch => new(_haContext, "switch.dressing_room_echo_dot_shuffle_switch");
		public SwitchEntity EspresenseBedroomActiveScan => new(_haContext, "switch.espresense_bedroom_active_scan");
		public SwitchEntity EspresenseBedroomQuery => new(_haContext, "switch.espresense_bedroom_query");
		public SwitchEntity EspresenseDrawingroomActiveScan => new(_haContext, "switch.espresense_drawingroom_active_scan");
		public SwitchEntity EspresenseDrawingroomQuery => new(_haContext, "switch.espresense_drawingroom_query");
		public SwitchEntity EspresenseKitchenActiveScan => new(_haContext, "switch.espresense_kitchen_active_scan");
		public SwitchEntity EspresenseKitchenQuery => new(_haContext, "switch.espresense_kitchen_query");
		public SwitchEntity EspresenseLoungeActiveScan => new(_haContext, "switch.espresense_lounge_active_scan");
		public SwitchEntity EspresenseLoungeQuery => new(_haContext, "switch.espresense_lounge_query");
		public SwitchEntity EspresenseSnugActiveScan => new(_haContext, "switch.espresense_snug_active_scan");
		public SwitchEntity EspresenseSnugQuery => new(_haContext, "switch.espresense_snug_query");
		public SwitchEntity EspresenseStudioActiveScan => new(_haContext, "switch.espresense_studio_active_scan");
		public SwitchEntity EspresenseStudioQuery => new(_haContext, "switch.espresense_studio_query");
		public SwitchEntity GuestRoomEchoShowDoNotDisturbSwitch => new(_haContext, "switch.guest_room_echo_show_do_not_disturb_switch");
		public SwitchEntity GuestRoomEchoShowRepeatSwitch => new(_haContext, "switch.guest_room_echo_show_repeat_switch");
		public SwitchEntity GuestRoomEchoShowShuffleSwitch => new(_haContext, "switch.guest_room_echo_show_shuffle_switch");
		public SwitchEntity HallTabletDoNotDisturbSwitch => new(_haContext, "switch.hall_tablet_do_not_disturb_switch");
		public SwitchEntity HdrModeBasementHallCamera => new(_haContext, "switch.hdr_mode_basement_hall_camera");
		public SwitchEntity HdrModeKitchenCamera => new(_haContext, "switch.hdr_mode_kitchen_camera");
		public SwitchEntity HdrModePatioCamera => new(_haContext, "switch.hdr_mode_patio_camera");
		public SwitchEntity HighFpsBasementHallCamera => new(_haContext, "switch.high_fps_basement_hall_camera");
		public SwitchEntity HighFpsKitchenCamera => new(_haContext, "switch.high_fps_kitchen_camera");
		public SwitchEntity HighFpsPatioCamera => new(_haContext, "switch.high_fps_patio_camera");
		public SwitchEntity HomeOccupied => new(_haContext, "switch.home_occupied");
		public SwitchEntity KitchenCameraOverlayShowBitrate => new(_haContext, "switch.kitchen_camera_overlay_show_bitrate");
		public SwitchEntity KitchenCameraOverlayShowDate => new(_haContext, "switch.kitchen_camera_overlay_show_date");
		public SwitchEntity KitchenCameraOverlayShowLogo => new(_haContext, "switch.kitchen_camera_overlay_show_logo");
		public SwitchEntity KitchenCameraOverlayShowName => new(_haContext, "switch.kitchen_camera_overlay_show_name");
		public SwitchEntity KitchenEchoShowDoNotDisturbSwitch => new(_haContext, "switch.kitchen_echo_show_do_not_disturb_switch");
		public SwitchEntity KitchenEchoShowRepeatSwitch => new(_haContext, "switch.kitchen_echo_show_repeat_switch");
		public SwitchEntity KitchenEchoShowShuffleSwitch => new(_haContext, "switch.kitchen_echo_show_shuffle_switch");
		public SwitchEntity LandingTabletDoNotDisturbSwitch => new(_haContext, "switch.landing_tablet_do_not_disturb_switch");
		public SwitchEntity LoungeEchoPlusDoNotDisturbSwitch => new(_haContext, "switch.lounge_echo_plus_do_not_disturb_switch");
		public SwitchEntity LoungeEchoPlusRepeatSwitch => new(_haContext, "switch.lounge_echo_plus_repeat_switch");
		public SwitchEntity LoungeEchoPlusShuffleSwitch => new(_haContext, "switch.lounge_echo_plus_shuffle_switch");
		public SwitchEntity LoungeFireTvDoNotDisturbSwitch => new(_haContext, "switch.lounge_fire_tv_do_not_disturb_switch");
		public SwitchEntity LoungeTv => new(_haContext, "switch.lounge_tv");
		public SwitchEntity MarkSchedule => new(_haContext, "switch.mark_schedule");
		public SwitchEntity NetdaemonBedroomlightoffnomovement => new(_haContext, "switch.netdaemon_bedroomlightoffnomovement");
		public SwitchEntity NetdaemonBedroomlightonmovement => new(_haContext, "switch.netdaemon_bedroomlightonmovement");
		public SwitchEntity NetdaemonBedroomlights => new(_haContext, "switch.netdaemon_bedroomlights");
		public SwitchEntity NetdaemonHelloWorldApp => new(_haContext, "switch.netdaemon_hello_world_app");
		public SwitchEntity NetdaemonHelloappcontext => new(_haContext, "switch.netdaemon_helloappcontext");
		public SwitchEntity NetdaemonHelloworldapp => new(_haContext, "switch.netdaemon_helloworldapp");
		public SwitchEntity NetdaemonHelloworldv2app => new(_haContext, "switch.netdaemon_helloworldv2app");
		public SwitchEntity NetdaemonHelloyamlapp => new(_haContext, "switch.netdaemon_helloyamlapp");
		public SwitchEntity NetdaemonLightonmovement => new(_haContext, "switch.netdaemon_lightonmovement");
		public SwitchEntity NetdaemonSchedulingapp => new(_haContext, "switch.netdaemon_schedulingapp");
		public SwitchEntity NetdaemonWeatherstationambientlight => new(_haContext, "switch.netdaemon_weatherstationambientlight");
		public SwitchEntity NetdaemonWeatherstationhighambientlight => new(_haContext, "switch.netdaemon_weatherstationhighambientlight");
		public SwitchEntity NetdaemonWeatherstationlowambientlight => new(_haContext, "switch.netdaemon_weatherstationlowambientlight");
		public SwitchEntity NetdaemonYamlConfigApp => new(_haContext, "switch.netdaemon_yaml_config_app");
		public SwitchEntity PatioCameraDetectionsPerson => new(_haContext, "switch.patio_camera_detections_person");
		public SwitchEntity PatioCameraDetectionsVehicle => new(_haContext, "switch.patio_camera_detections_vehicle");
		public SwitchEntity PatioCameraOverlayShowBitrate => new(_haContext, "switch.patio_camera_overlay_show_bitrate");
		public SwitchEntity PatioCameraOverlayShowDate => new(_haContext, "switch.patio_camera_overlay_show_date");
		public SwitchEntity PatioCameraOverlayShowLogo => new(_haContext, "switch.patio_camera_overlay_show_logo");
		public SwitchEntity PatioCameraOverlayShowName => new(_haContext, "switch.patio_camera_overlay_show_name");
		public SwitchEntity PrivacyModeBasementHallCamera => new(_haContext, "switch.privacy_mode_basement_hall_camera");
		public SwitchEntity PrivacyModeKitchenCamera => new(_haContext, "switch.privacy_mode_kitchen_camera");
		public SwitchEntity PrivacyModePatioCamera => new(_haContext, "switch.privacy_mode_patio_camera");
		public SwitchEntity RestartWeatherStation => new(_haContext, "switch.restart_weather_station");
		public SwitchEntity SnugDoNotDisturbSwitch => new(_haContext, "switch.snug_do_not_disturb_switch");
		public SwitchEntity SnugEchoInputDoNotDisturbSwitch => new(_haContext, "switch.snug_echo_input_do_not_disturb_switch");
		public SwitchEntity SnugEchoInputRepeatSwitch => new(_haContext, "switch.snug_echo_input_repeat_switch");
		public SwitchEntity SnugEchoInputShuffleSwitch => new(_haContext, "switch.snug_echo_input_shuffle_switch");
		public SwitchEntity SnugRepeatSwitch => new(_haContext, "switch.snug_repeat_switch");
		public SwitchEntity SnugShuffleSwitch => new(_haContext, "switch.snug_shuffle_switch");
		public SwitchEntity StatusLightOnBasementHallCamera => new(_haContext, "switch.status_light_on_basement_hall_camera");
		public SwitchEntity StatusLightOnKitchenCamera => new(_haContext, "switch.status_light_on_kitchen_camera");
		public SwitchEntity StatusLightOnPatioCamera => new(_haContext, "switch.status_light_on_patio_camera");
		public SwitchEntity SumpAlarmReset => new(_haContext, "switch.sump_alarm_reset");
		public SwitchEntity SumpAlarmRestart => new(_haContext, "switch.sump_alarm_restart");
		public SwitchEntity UpstairsDoNotDisturbSwitch => new(_haContext, "switch.upstairs_do_not_disturb_switch");
		public SwitchEntity UpstairsRepeatSwitch => new(_haContext, "switch.upstairs_repeat_switch");
		public SwitchEntity UpstairsShuffleSwitch => new(_haContext, "switch.upstairs_shuffle_switch");
		public SwitchEntity UtilityRoomEchoDotDoNotDisturbSwitch => new(_haContext, "switch.utility_room_echo_dot_do_not_disturb_switch");
		public SwitchEntity UtilityRoomEchoDotRepeatSwitch => new(_haContext, "switch.utility_room_echo_dot_repeat_switch");
		public SwitchEntity UtilityRoomEchoDotShuffleSwitch => new(_haContext, "switch.utility_room_echo_dot_shuffle_switch");
	}

	public class TimerEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public TimerEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public TimerEntity Lounge => new(_haContext, "timer.lounge");
		public TimerEntity Shower => new(_haContext, "timer.shower");
	}

	public class VacuumEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public VacuumEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public VacuumEntity Mark => new(_haContext, "vacuum.mark");
	}

	public class WeatherEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public WeatherEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public WeatherEntity Stockport => new(_haContext, "weather.stockport");
	}

	public class ZoneEntities
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ZoneEntities(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public ZoneEntity AdamS => new(_haContext, "zone.adam_s");
		public ZoneEntity AmyS => new(_haContext, "zone.amy_s");
		public ZoneEntity AndySParentS => new(_haContext, "zone.andy_s_parent_s");
		public ZoneEntity AndyWork => new(_haContext, "zone.andy_work");
		public ZoneEntity ClaireWork => new(_haContext, "zone.claire_work");
		public ZoneEntity GrampaS => new(_haContext, "zone.grampa_s");
		public ZoneEntity Gym => new(_haContext, "zone.gym");
		public ZoneEntity HeatonHops => new(_haContext, "zone.heaton_hops");
		public ZoneEntity HeatonMoor1 => new(_haContext, "zone.heaton_moor_1");
		public ZoneEntity HeatonMoor2 => new(_haContext, "zone.heaton_moor_2");
		public ZoneEntity Home => new(_haContext, "zone.home");
		public ZoneEntity ManUtd => new(_haContext, "zone.man_utd");
		public ZoneEntity RachaelAndChris => new(_haContext, "zone.rachael_and_chris");
	}

	public record AlarmControlPanelEntity : NetDaemon.HassModel.Entities.Entity<AlarmControlPanelEntity, NetDaemon.HassModel.Entities.EntityState<AlarmControlPanelAttributes>, AlarmControlPanelAttributes>
	{
		public AlarmControlPanelEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record AutomationEntity : NetDaemon.HassModel.Entities.Entity<AutomationEntity, NetDaemon.HassModel.Entities.EntityState<AutomationAttributes>, AutomationAttributes>
	{
		public AutomationEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record BinarySensorEntity : NetDaemon.HassModel.Entities.Entity<BinarySensorEntity, NetDaemon.HassModel.Entities.EntityState<BinarySensorAttributes>, BinarySensorAttributes>
	{
		public BinarySensorEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record CalendarEntity : NetDaemon.HassModel.Entities.Entity<CalendarEntity, NetDaemon.HassModel.Entities.EntityState<CalendarAttributes>, CalendarAttributes>
	{
		public CalendarEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record CameraEntity : NetDaemon.HassModel.Entities.Entity<CameraEntity, NetDaemon.HassModel.Entities.EntityState<CameraAttributes>, CameraAttributes>
	{
		public CameraEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record ClimateEntity : NetDaemon.HassModel.Entities.Entity<ClimateEntity, NetDaemon.HassModel.Entities.EntityState<ClimateAttributes>, ClimateAttributes>
	{
		public ClimateEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record DeviceTrackerEntity : NetDaemon.HassModel.Entities.Entity<DeviceTrackerEntity, NetDaemon.HassModel.Entities.EntityState<DeviceTrackerAttributes>, DeviceTrackerAttributes>
	{
		public DeviceTrackerEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record EntityControllerEntity : NetDaemon.HassModel.Entities.Entity<EntityControllerEntity, NetDaemon.HassModel.Entities.EntityState<EntityControllerAttributes>, EntityControllerAttributes>
	{
		public EntityControllerEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record FanEntity : NetDaemon.HassModel.Entities.Entity<FanEntity, NetDaemon.HassModel.Entities.EntityState<FanAttributes>, FanAttributes>
	{
		public FanEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record GroupEntity : NetDaemon.HassModel.Entities.Entity<GroupEntity, NetDaemon.HassModel.Entities.EntityState<GroupAttributes>, GroupAttributes>
	{
		public GroupEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record InputBooleanEntity : NetDaemon.HassModel.Entities.Entity<InputBooleanEntity, NetDaemon.HassModel.Entities.EntityState<InputBooleanAttributes>, InputBooleanAttributes>
	{
		public InputBooleanEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record InputSelectEntity : 
		NetDaemon.HassModel.Entities.Entity<InputSelectEntity, 
		NetDaemon.HassModel.Entities.EntityState<InputSelectAttributes>, 
		InputSelectAttributes>
	{
		public InputSelectEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : 
			base(haContext, entityId)
		{
		}
	}

    public record TypedInputSelect<TEnum> : InputSelectEntity
		where TEnum : Enum, new()
    {
		public TEnum Options => new();
        public TypedInputSelect(IHaContext haContext, string entityId) 
			: base(haContext, entityId)
        {
        }
    }
    public record LightEntity : NetDaemon.HassModel.Entities.Entity<LightEntity, NetDaemon.HassModel.Entities.EntityState<LightAttributes>, LightAttributes>
	{
		public LightEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record MediaPlayerEntity : NetDaemon.HassModel.Entities.Entity<MediaPlayerEntity, NetDaemon.HassModel.Entities.EntityState<MediaPlayerAttributes>, MediaPlayerAttributes>
	{
		public MediaPlayerEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record NumberEntity : NetDaemon.HassModel.Entities.Entity<NumberEntity, NetDaemon.HassModel.Entities.EntityState<NumberAttributes>, NumberAttributes>
	{
		public NumberEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record PersistentNotificationEntity : NetDaemon.HassModel.Entities.Entity<PersistentNotificationEntity, NetDaemon.HassModel.Entities.EntityState<PersistentNotificationAttributes>, PersistentNotificationAttributes>
	{
		public PersistentNotificationEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record PersonEntity : NetDaemon.HassModel.Entities.Entity<PersonEntity, NetDaemon.HassModel.Entities.EntityState<PersonAttributes>, PersonAttributes>
	{
		public PersonEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record SceneEntity : NetDaemon.HassModel.Entities.Entity<SceneEntity, NetDaemon.HassModel.Entities.EntityState<SceneAttributes>, SceneAttributes>
	{
		public SceneEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record ScriptEntity : NetDaemon.HassModel.Entities.Entity<ScriptEntity, NetDaemon.HassModel.Entities.EntityState<ScriptAttributes>, ScriptAttributes>
	{
		public ScriptEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record SelectEntity : NetDaemon.HassModel.Entities.Entity<SelectEntity, NetDaemon.HassModel.Entities.EntityState<SelectAttributes>, SelectAttributes>
	{
		public SelectEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record SensorEntity : NetDaemon.HassModel.Entities.Entity<SensorEntity, NetDaemon.HassModel.Entities.EntityState<SensorAttributes>, SensorAttributes>
	{
		public SensorEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record SunEntity : NetDaemon.HassModel.Entities.Entity<SunEntity, NetDaemon.HassModel.Entities.EntityState<SunAttributes>, SunAttributes>
	{
		public SunEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record SwitchEntity : NetDaemon.HassModel.Entities.Entity<SwitchEntity, NetDaemon.HassModel.Entities.EntityState<SwitchAttributes>, SwitchAttributes>
	{
		public SwitchEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record TimerEntity : NetDaemon.HassModel.Entities.Entity<TimerEntity, NetDaemon.HassModel.Entities.EntityState<TimerAttributes>, TimerAttributes>
	{
		public TimerEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record VacuumEntity : NetDaemon.HassModel.Entities.Entity<VacuumEntity, NetDaemon.HassModel.Entities.EntityState<VacuumAttributes>, VacuumAttributes>
	{
		public VacuumEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record WeatherEntity : NetDaemon.HassModel.Entities.Entity<WeatherEntity, NetDaemon.HassModel.Entities.EntityState<WeatherAttributes>, WeatherAttributes>
	{
		public WeatherEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record ZoneEntity : NetDaemon.HassModel.Entities.Entity<ZoneEntity, NetDaemon.HassModel.Entities.EntityState<ZoneAttributes>, ZoneAttributes>
	{
		public ZoneEntity(NetDaemon.HassModel.Common.IHaContext haContext, string entityId) : base(haContext, entityId)
		{
		}
	}

	public record AlarmControlPanelAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("changed_by")]
		public object? ChangedBy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("code_arm_required")]
		public bool? CodeArmRequired { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("code_format")]
		public string? CodeFormat { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record AutomationAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("current")]
		public double? Current { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
		public string? Id { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_triggered")]
		public string? LastTriggered { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("mode")]
		public string? Mode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record BinarySensorAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("adverts")]
		public double? Adverts { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery")]
		public double? Battery { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_low")]
		public bool? BatteryLow { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("box")]
		public string? Box { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("contact")]
		public bool? Contact { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_class")]
		public string? DeviceClass { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_id")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("event_object")]
		public object? EventObject { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("event_score")]
		public double? EventScore { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("event_thumbnail")]
		public object? EventThumbnail { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("firm")]
		public string? Firm { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("freeHeap")]
		public double? FreeHeap { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("ip")]
		public string? Ip { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_changed")]
		public string? LastChanged { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_tripped_time")]
		public string? LastTrippedTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("linkquality")]
		public double? Linkquality { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("maxAllocHeap")]
		public double? MaxAllocHeap { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("minFreeHeap")]
		public double? MinFreeHeap { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("newest_version")]
		public string? NewestVersion { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("occupancy")]
		public bool? Occupancy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("release_notes")]
		public string? ReleaseNotes { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("reported")]
		public double? Reported { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("resetReason")]
		public string? ResetReason { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("rssi")]
		public double? Rssi { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("seen")]
		public double? Seen { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("tamper")]
		public bool? Tamper { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("target")]
		public string? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("uptime")]
		public double? Uptime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("ver")]
		public string? Ver { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("voltage")]
		public double? Voltage { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("wasp")]
		public string? Wasp { get; init; }
	}

	public record CalendarAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("all_day")]
		public bool? AllDay { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("description")]
		public string? Description { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("end_time")]
		public string? EndTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("location")]
		public string? Location { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("offset_reached")]
		public bool? OffsetReached { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("start_time")]
		public string? StartTime { get; init; }
	}

	public record CameraAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("access_token")]
		public string? AccessToken { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("bitrate")]
		public double? Bitrate { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("brand")]
		public string? Brand { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("camera_id")]
		public string? CameraId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("channel_id")]
		public double? ChannelId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("chime_duration")]
		public double? ChimeDuration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("chime_enabled")]
		public bool? ChimeEnabled { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_picture")]
		public string? EntityPicture { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("fps")]
		public double? Fps { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("frontend_stream_type")]
		public string? FrontendStreamType { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("generated_at")]
		public string? GeneratedAt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("height")]
		public double? Height { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("is_dark")]
		public bool? IsDark { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("mic_sensitivity")]
		public double? MicSensitivity { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("motion_detection")]
		public bool? MotionDetection { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("privacy_mode")]
		public bool? PrivacyMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("up_since")]
		public string? UpSince { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("wdr_value")]
		public double? WdrValue { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("width")]
		public double? Width { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("zoom_position")]
		public double? ZoomPosition { get; init; }
	}

	public record ClimateAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("current_temperature")]
		public double? CurrentTemperature { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("hvac_action")]
		public string? HvacAction { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("hvac_modes")]
		public object? HvacModes { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("max_temp")]
		public double? MaxTemp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("min_temp")]
		public double? MinTemp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("preset_mode")]
		public string? PresetMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("preset_modes")]
		public object? PresetModes { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("temperature")]
		public double? Temperature { get; init; }
	}

	public record DeviceTrackerAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("altitude")]
		public double? Altitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_level")]
		public double? BatteryLevel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("is_lost")]
		public bool? IsLost { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_lost_timestamp")]
		public string? LastLostTimestamp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("latitude")]
		public double? Latitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("longitude")]
		public double? Longitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("ring_state")]
		public string? RingState { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("source_type")]
		public string? SourceType { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("vertical_accuracy")]
		public double? VerticalAccuracy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("voip_state")]
		public string? VoipState { get; init; }
	}

	public record EntityControllerAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("backoff_count")]
		public double? BackoffCount { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("delay")]
		public string? Delay { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("end")]
		public string? End { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("end_time")]
		public string? EndTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("expires_at")]
		public string? ExpiresAt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_triggered_at")]
		public string? LastTriggeredAt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_triggered_by")]
		public string? LastTriggeredBy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("reset_at")]
		public string? ResetAt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("sensor_type")]
		public string? SensorType { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("service_data")]
		public object? ServiceData { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("start")]
		public string? Start { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("start_time")]
		public string? StartTime { get; init; }
	}

	public record FanAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record GroupAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_id")]
		public object? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("order")]
		public double? Order { get; init; }
	}

	public record InputBooleanAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("editable")]
		public bool? Editable { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }
	}

	public record InputSelectAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("editable")]
		public bool? Editable { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("options")]
		public object? Options { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record LightAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("brightness")]
		public double? Brightness { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("color_mode")]
		public string? ColorMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("color_temp")]
		public double? ColorTemp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("effect_list")]
		public object? EffectList { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_id")]
		public object? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("flowing")]
		public bool? Flowing { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("hs_color")]
		public object? HsColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("max_mireds")]
		public double? MaxMireds { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("min_mireds")]
		public double? MinMireds { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("music_mode")]
		public bool? MusicMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("rgb_color")]
		public object? RgbColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_color_modes")]
		public object? SupportedColorModes { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("xy_color")]
		public object? XyColor { get; init; }
	}

	public record MediaPlayerAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("available")]
		public bool? Available { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("bluetooth_list")]
		public object? BluetoothList { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("connected_bluetooth")]
		public object? ConnectedBluetooth { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("is_volume_muted")]
		public bool? IsVolumeMuted { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_called")]
		public bool? LastCalled { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_called_summary")]
		public string? LastCalledSummary { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_called_timestamp")]
		public double? LastCalledTimestamp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("media_content_type")]
		public string? MediaContentType { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("media_position_updated_at")]
		public string? MediaPositionUpdatedAt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("shuffle")]
		public bool? Shuffle { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("source")]
		public string? Source { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("source_list")]
		public object? SourceList { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("volume_level")]
		public double? VolumeLevel { get; init; }
	}

	public record NumberAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("max")]
		public double? Max { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("min")]
		public double? Min { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("mode")]
		public string? Mode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("step")]
		public double? Step { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record PersistentNotificationAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("title")]
		public string? Title { get; init; }
	}

	public record PersonAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("editable")]
		public bool? Editable { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_picture")]
		public string? EntityPicture { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("gps_accuracy")]
		public double? GpsAccuracy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
		public string? Id { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("latitude")]
		public double? Latitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("longitude")]
		public double? Longitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("source")]
		public string? Source { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("user_id")]
		public string? UserId { get; init; }
	}

	public record SceneAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("entity_id")]
		public object? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
		public string? Id { get; init; }
	}

	public record ScriptAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("current")]
		public double? Current { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_triggered")]
		public string? LastTriggered { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("mode")]
		public string? Mode { get; init; }
	}

	public record SelectAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("options")]
		public object? Options { get; init; }
	}

	public record SensorAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("action")]
		public object? Action { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Administrative Area")]
		public string? AdministrativeArea { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Allows VoIP")]
		public bool? AllowsVoIP { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Areas Of Interest")]
		public string? AreasOfInterest { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Available")]
		public string? Available { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Available (Important)")]
		public string? AvailableImportant { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Available (Opportunistic)")]
		public string? AvailableOpportunistic { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("backups")]
		public object? Backups { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("backups_in_google_drive")]
		public double? BackupsInGoogleDrive { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("backups_in_home_assistant")]
		public double? BackupsInHomeAssistant { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery")]
		public double? Battery { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_low")]
		public bool? BatteryLow { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("bytes_received")]
		public double? BytesReceived { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("bytes_sent")]
		public double? BytesSent { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Carrier ID")]
		public string? CarrierID { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Carrier Name")]
		public string? CarrierName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("command_set")]
		public string? CommandSet { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Confidence")]
		public string? Confidence { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("contact")]
		public bool? Contact { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("counter")]
		public double? Counter { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Country")]
		public string? Country { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Current Radio Technology")]
		public string? CurrentRadioTechnology { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("days")]
		public double? Days { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_class")]
		public string? DeviceClass { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("dismissed")]
		public object? Dismissed { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("distance")]
		public double? Distance { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("event_score")]
		public double? EventScore { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("event_thumbnail")]
		public object? EventThumbnail { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("holidays")]
		public string? Holidays { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("info")]
		public string? Info { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Inland Water")]
		public string? InlandWater { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("integration")]
		public string? Integration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("ISO Country Code")]
		public string? ISOCountryCode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_backup")]
		public string? LastBackup { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_collection")]
		public string? LastCollection { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_updated")]
		public string? LastUpdated { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("last_uploaded")]
		public string? LastUploaded { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("linkquality")]
		public double? Linkquality { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Locality")]
		public string? Locality { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("location")]
		public string? Location_0 { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Location")]
		public object? Location_1 { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Low Power Mode")]
		public bool? LowPowerMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("marker_high_level")]
		public double? MarkerHighLevel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("marker_low_level")]
		public double? MarkerLowLevel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("marker_type")]
		public string? MarkerType { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Mobile Country Code")]
		public string? MobileCountryCode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Mobile Network Code")]
		public string? MobileNetworkCode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_date")]
		public string? NextDate { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("number_of_loaded_apps")]
		public double? NumberOfLoadedApps { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("number_of_running_apps")]
		public double? NumberOfRunningApps { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("occupancy")]
		public bool? Occupancy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Ocean")]
		public string? Ocean { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Postal Code")]
		public string? PostalCode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("prior_value")]
		public string? PriorValue { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("process_timestamp")]
		public string? ProcessTimestamp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("recurrence")]
		public object? Recurrence { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("remaining_pages")]
		public double? RemainingPages { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("reminder")]
		public object? Reminder { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("repositories")]
		public object? Repositories { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("serial")]
		public object? Serial { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("server_country")]
		public string? ServerCountry { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("server_id")]
		public string? ServerId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("server_name")]
		public string? ServerName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("size_in_google_drive")]
		public string? SizeInGoogleDrive { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("size_in_home_assistant")]
		public string? SizeInHomeAssistant { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("sorted_active")]
		public string? SortedActive { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("sorted_all")]
		public string? SortedAll { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("state_class")]
		public string? StateClass { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("state_message")]
		public object? StateMessage { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("state_reason")]
		public object? StateReason { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("status")]
		public string? Status { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Sub Administrative Area")]
		public string? SubAdministrativeArea { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Sub Locality")]
		public string? SubLocality { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Sub Thoroughfare")]
		public string? SubThoroughfare { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("tamper")]
		public bool? Tamper { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Thoroughfare")]
		public string? Thoroughfare { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Time Zone")]
		public string? TimeZone { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Total")]
		public string? Total { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("total_active")]
		public double? TotalActive { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("total_all")]
		public double? TotalAll { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Types")]
		public object? Types { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("unit_of_measurement")]
		public string? UnitOfMeasurement { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("uri_supported")]
		public string? UriSupported { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("version")]
		public string? Version { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("voltage")]
		public double? Voltage { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("Zones")]
		public object? Zones { get; init; }
	}

	public record SunAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("azimuth")]
		public double? Azimuth { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("elevation")]
		public double? Elevation { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_dawn")]
		public string? NextDawn { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_dusk")]
		public string? NextDusk { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_midnight")]
		public string? NextMidnight { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_noon")]
		public string? NextNoon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_rising")]
		public string? NextRising { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("next_setting")]
		public string? NextSetting { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("rising")]
		public bool? Rising { get; init; }
	}

	public record SwitchAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_class")]
		public string? DeviceClass { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("device_model")]
		public string? DeviceModel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("integration")]
		public string? Integration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("restored")]
		public bool? Restored { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("runtime_info")]
		public object? RuntimeInfo { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("state")]
		public string? State { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record TimerAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("duration")]
		public string? Duration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("editable")]
		public bool? Editable { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }
	}

	public record VacuumAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_icon")]
		public string? BatteryIcon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_level")]
		public double? BatteryLevel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_level_at_clean_end")]
		public double? BatteryLevelAtCleanEnd { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("battery_level_at_clean_start")]
		public double? BatteryLevelAtCleanStart { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_area")]
		public double? CleanArea { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_error_time")]
		public double? CleanErrorTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_pause_time")]
		public double? CleanPauseTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_start")]
		public string? CleanStart { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_stop")]
		public string? CleanStop { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_suspension_count")]
		public double? CleanSuspensionCount { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("clean_suspension_time")]
		public double? CleanSuspensionTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("launched_from")]
		public string? LaunchedFrom { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("status")]
		public string? Status { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("supported_features")]
		public double? SupportedFeatures { get; init; }
	}

	public record WeatherAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("attribution")]
		public string? Attribution { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("forecast")]
		public object? Forecast { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("humidity")]
		public double? Humidity { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("ozone")]
		public double? Ozone { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("pressure")]
		public double? Pressure { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("temperature")]
		public double? Temperature { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("visibility")]
		public double? Visibility { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("wind_bearing")]
		public double? WindBearing { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("wind_speed")]
		public double? WindSpeed { get; init; }
	}

	public record ZoneAttributes
	{
		[System.Text.Json.Serialization.JsonPropertyNameAttribute("editable")]
		public bool? Editable { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("friendly_name")]
		public string? FriendlyName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("latitude")]
		public double? Latitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("longitude")]
		public double? Longitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("passive")]
		public bool? Passive { get; init; }

		[System.Text.Json.Serialization.JsonPropertyNameAttribute("radius")]
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

		SceneServices Scene { get; }

		ScriptServices Script { get; }

		SelectServices Select { get; }

		ShoppingListServices ShoppingList { get; }

		SpeedtestdotnetServices Speedtestdotnet { get; }

		SqueezeboxServices Squeezebox { get; }

		SwitchServices Switch { get; }

		SystemLogServices SystemLog { get; }

		TemplateServices Template { get; }

		TimerServices Timer { get; }

		TtsServices Tts { get; }

		UnifiprotectServices Unifiprotect { get; }

		VacuumServices Vacuum { get; }

		YeelightServices Yeelight { get; }

		ZoneServices Zone { get; }
	}

	public class Services : IServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public Services(NetDaemon.HassModel.Common.IHaContext haContext)
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
		public SceneServices Scene => new(_haContext);
		public ScriptServices Script => new(_haContext);
		public SelectServices Select => new(_haContext);
		public ShoppingListServices ShoppingList => new(_haContext);
		public SpeedtestdotnetServices Speedtestdotnet => new(_haContext);
		public SqueezeboxServices Squeezebox => new(_haContext);
		public SwitchServices Switch => new(_haContext);
		public SystemLogServices SystemLog => new(_haContext);
		public TemplateServices Template => new(_haContext);
		public TimerServices Timer => new(_haContext);
		public TtsServices Tts => new(_haContext);
		public UnifiprotectServices Unifiprotect => new(_haContext);
		public VacuumServices Vacuum => new(_haContext);
		public YeelightServices Yeelight => new(_haContext);
		public ZoneServices Zone => new(_haContext);
	}

	public class AdguardServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AdguardServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AddUrl(AdguardAddUrlParameters data)
		{
			_haContext.CallService("adguard", "add_url", null, data);
		}

		public void AddUrl(string @name, string @url)
		{
			_haContext.CallService("adguard", "add_url", null, new
			{
			@name, @url
			}

			);
		}

		public void DisableUrl(AdguardDisableUrlParameters data)
		{
			_haContext.CallService("adguard", "disable_url", null, data);
		}

		public void DisableUrl(string @url)
		{
			_haContext.CallService("adguard", "disable_url", null, new
			{
			@url
			}

			);
		}

		public void EnableUrl(AdguardEnableUrlParameters data)
		{
			_haContext.CallService("adguard", "enable_url", null, data);
		}

		public void EnableUrl(string @url)
		{
			_haContext.CallService("adguard", "enable_url", null, new
			{
			@url
			}

			);
		}

		public void Refresh(AdguardRefreshParameters data)
		{
			_haContext.CallService("adguard", "refresh", null, data);
		}

		public void Refresh(bool? @force = null)
		{
			_haContext.CallService("adguard", "refresh", null, new
			{
			@force
			}

			);
		}

		public void RemoveUrl(AdguardRemoveUrlParameters data)
		{
			_haContext.CallService("adguard", "remove_url", null, data);
		}

		public void RemoveUrl(string @url)
		{
			_haContext.CallService("adguard", "remove_url", null, new
			{
			@url
			}

			);
		}
	}

	public record AdguardAddUrlParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardDisableUrlParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardEnableUrlParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public record AdguardRefreshParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("force")]
		public bool? Force { get; init; }
	}

	public record AdguardRemoveUrlParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("url")]
		public string? Url { get; init; }
	}

	public class AlarmControlPanelServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AlarmControlPanelServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AlarmArmAway(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmArmAwayParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, data);
		}

		public void AlarmArmAway(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_away", target, new
			{
			@code
			}

			);
		}

		public void AlarmArmCustomBypass(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, data);
		}

		public void AlarmArmCustomBypass(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_custom_bypass", target, new
			{
			@code
			}

			);
		}

		public void AlarmArmHome(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmArmHomeParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, data);
		}

		public void AlarmArmHome(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_home", target, new
			{
			@code
			}

			);
		}

		public void AlarmArmNight(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmArmNightParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, data);
		}

		public void AlarmArmNight(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_night", target, new
			{
			@code
			}

			);
		}

		public void AlarmArmVacation(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmArmVacationParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, data);
		}

		public void AlarmArmVacation(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_arm_vacation", target, new
			{
			@code
			}

			);
		}

		public void AlarmDisarm(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmDisarmParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, data);
		}

		public void AlarmDisarm(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_disarm", target, new
			{
			@code
			}

			);
		}

		public void AlarmTrigger(NetDaemon.HassModel.Entities.ServiceTarget target, AlarmControlPanelAlarmTriggerParameters data)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, data);
		}

		public void AlarmTrigger(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("alarm_control_panel", "alarm_trigger", target, new
			{
			@code
			}

			);
		}
	}

	public record AlarmControlPanelAlarmArmAwayParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmCustomBypassParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmHomeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmNightParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmArmVacationParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmDisarmParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record AlarmControlPanelAlarmTriggerParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class AlexaMediaServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AlexaMediaServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void ClearHistory(AlexaMediaClearHistoryParameters data)
		{
			_haContext.CallService("alexa_media", "clear_history", null, data);
		}

		public void ClearHistory(string? @email = null, string? @entries = null)
		{
			_haContext.CallService("alexa_media", "clear_history", null, new
			{
			@email, @entries
			}

			);
		}

		public void ForceLogout(AlexaMediaForceLogoutParameters data)
		{
			_haContext.CallService("alexa_media", "force_logout", null, data);
		}

		public void ForceLogout(string? @email = null)
		{
			_haContext.CallService("alexa_media", "force_logout", null, new
			{
			@email
			}

			);
		}

		public void UpdateLastCalled(AlexaMediaUpdateLastCalledParameters data)
		{
			_haContext.CallService("alexa_media", "update_last_called", null, data);
		}

		public void UpdateLastCalled(string? @email = null)
		{
			_haContext.CallService("alexa_media", "update_last_called", null, new
			{
			@email
			}

			);
		}
	}

	public record AlexaMediaClearHistoryParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("email")]
		public string? Email { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("entries")]
		public string? Entries { get; init; }
	}

	public record AlexaMediaForceLogoutParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("email")]
		public string? Email { get; init; }
	}

	public record AlexaMediaUpdateLastCalledParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("email")]
		public string? Email { get; init; }
	}

	public class AutomationServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public AutomationServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("automation", "reload", null);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("automation", "toggle", target);
		}

		public void Trigger(NetDaemon.HassModel.Entities.ServiceTarget target, AutomationTriggerParameters data)
		{
			_haContext.CallService("automation", "trigger", target, data);
		}

		public void Trigger(NetDaemon.HassModel.Entities.ServiceTarget target, bool? @skipCondition = null)
		{
			_haContext.CallService("automation", "trigger", target, new
			{
			@skip_condition = @skipCondition
			}

			);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target, AutomationTurnOffParameters data)
		{
			_haContext.CallService("automation", "turn_off", target, data);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target, bool? @stopActions = null)
		{
			_haContext.CallService("automation", "turn_off", target, new
			{
			@stop_actions = @stopActions
			}

			);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("automation", "turn_on", target);
		}
	}

	public record AutomationTriggerParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("skipCondition")]
		public bool? SkipCondition { get; init; }
	}

	public record AutomationTurnOffParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("stopActions")]
		public bool? StopActions { get; init; }
	}

	public class ButtonServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ButtonServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Press(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("button", "press", target);
		}
	}

	public class CameraServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CameraServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void DisableMotionDetection(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("camera", "disable_motion_detection", target);
		}

		public void EnableMotionDetection(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("camera", "enable_motion_detection", target);
		}

		public void PlayStream(NetDaemon.HassModel.Entities.ServiceTarget target, CameraPlayStreamParameters data)
		{
			_haContext.CallService("camera", "play_stream", target, data);
		}

		public void PlayStream(NetDaemon.HassModel.Entities.ServiceTarget target, string @mediaPlayer, string? @format = null)
		{
			_haContext.CallService("camera", "play_stream", target, new
			{
			@media_player = @mediaPlayer, @format
			}

			);
		}

		public void Record(NetDaemon.HassModel.Entities.ServiceTarget target, CameraRecordParameters data)
		{
			_haContext.CallService("camera", "record", target, data);
		}

		public void Record(NetDaemon.HassModel.Entities.ServiceTarget target, string @filename, long? @duration = null, long? @lookback = null)
		{
			_haContext.CallService("camera", "record", target, new
			{
			@filename, @duration, @lookback
			}

			);
		}

		public void Snapshot(NetDaemon.HassModel.Entities.ServiceTarget target, CameraSnapshotParameters data)
		{
			_haContext.CallService("camera", "snapshot", target, data);
		}

		public void Snapshot(NetDaemon.HassModel.Entities.ServiceTarget target, string @filename)
		{
			_haContext.CallService("camera", "snapshot", target, new
			{
			@filename
			}

			);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("camera", "turn_on", target);
		}
	}

	public record CameraPlayStreamParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("mediaPlayer")]
		public string? MediaPlayer { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("format")]
		public string? Format { get; init; }
	}

	public record CameraRecordParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("filename")]
		public string? Filename { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public long? Duration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("lookback")]
		public long? Lookback { get; init; }
	}

	public record CameraSnapshotParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("filename")]
		public string? Filename { get; init; }
	}

	public class ClimateServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ClimateServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void SetAuxHeat(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetAuxHeatParameters data)
		{
			_haContext.CallService("climate", "set_aux_heat", target, data);
		}

		public void SetAuxHeat(NetDaemon.HassModel.Entities.ServiceTarget target, bool @auxHeat)
		{
			_haContext.CallService("climate", "set_aux_heat", target, new
			{
			@aux_heat = @auxHeat
			}

			);
		}

		public void SetFanMode(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetFanModeParameters data)
		{
			_haContext.CallService("climate", "set_fan_mode", target, data);
		}

		public void SetFanMode(NetDaemon.HassModel.Entities.ServiceTarget target, string @fanMode)
		{
			_haContext.CallService("climate", "set_fan_mode", target, new
			{
			@fan_mode = @fanMode
			}

			);
		}

		public void SetHumidity(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetHumidityParameters data)
		{
			_haContext.CallService("climate", "set_humidity", target, data);
		}

		public void SetHumidity(NetDaemon.HassModel.Entities.ServiceTarget target, long @humidity)
		{
			_haContext.CallService("climate", "set_humidity", target, new
			{
			@humidity
			}

			);
		}

		public void SetHvacMode(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetHvacModeParameters data)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, data);
		}

		public void SetHvacMode(NetDaemon.HassModel.Entities.ServiceTarget target, string? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_hvac_mode", target, new
			{
			@hvac_mode = @hvacMode
			}

			);
		}

		public void SetPresetMode(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetPresetModeParameters data)
		{
			_haContext.CallService("climate", "set_preset_mode", target, data);
		}

		public void SetPresetMode(NetDaemon.HassModel.Entities.ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("climate", "set_preset_mode", target, new
			{
			@preset_mode = @presetMode
			}

			);
		}

		public void SetSwingMode(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetSwingModeParameters data)
		{
			_haContext.CallService("climate", "set_swing_mode", target, data);
		}

		public void SetSwingMode(NetDaemon.HassModel.Entities.ServiceTarget target, string @swingMode)
		{
			_haContext.CallService("climate", "set_swing_mode", target, new
			{
			@swing_mode = @swingMode
			}

			);
		}

		public void SetTemperature(NetDaemon.HassModel.Entities.ServiceTarget target, ClimateSetTemperatureParameters data)
		{
			_haContext.CallService("climate", "set_temperature", target, data);
		}

		public void SetTemperature(NetDaemon.HassModel.Entities.ServiceTarget target, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, string? @hvacMode = null)
		{
			_haContext.CallService("climate", "set_temperature", target, new
			{
			@temperature, @target_temp_high = @targetTempHigh, @target_temp_low = @targetTempLow, @hvac_mode = @hvacMode
			}

			);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("climate", "turn_on", target);
		}
	}

	public record ClimateSetAuxHeatParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("auxHeat")]
		public bool? AuxHeat { get; init; }
	}

	public record ClimateSetFanModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("fanMode")]
		public string? FanMode { get; init; }
	}

	public record ClimateSetHumidityParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("humidity")]
		public long? Humidity { get; init; }
	}

	public record ClimateSetHvacModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("hvacMode")]
		public string? HvacMode { get; init; }
	}

	public record ClimateSetPresetModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("presetMode")]
		public string? PresetMode { get; init; }
	}

	public record ClimateSetSwingModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("swingMode")]
		public string? SwingMode { get; init; }
	}

	public record ClimateSetTemperatureParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("temperature")]
		public double? Temperature { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("targetTempHigh")]
		public double? TargetTempHigh { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("targetTempLow")]
		public double? TargetTempLow { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("hvacMode")]
		public string? HvacMode { get; init; }
	}

	public class CloudServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CloudServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void RemoteConnect()
		{
			_haContext.CallService("cloud", "remote_connect", null);
		}

		public void RemoteDisconnect()
		{
			_haContext.CallService("cloud", "remote_disconnect", null);
		}
	}

	public class ConversationServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ConversationServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Process(ConversationProcessParameters data)
		{
			_haContext.CallService("conversation", "process", null, data);
		}

		public void Process(string? @text = null)
		{
			_haContext.CallService("conversation", "process", null, new
			{
			@text
			}

			);
		}
	}

	public record ConversationProcessParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("text")]
		public string? Text { get; init; }
	}

	public class CounterServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CounterServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Configure(NetDaemon.HassModel.Entities.ServiceTarget target, CounterConfigureParameters data)
		{
			_haContext.CallService("counter", "configure", target, data);
		}

		public void Configure(NetDaemon.HassModel.Entities.ServiceTarget target, long? @minimum = null, long? @maximum = null, long? @step = null, long? @initial = null, long? @value = null)
		{
			_haContext.CallService("counter", "configure", target, new
			{
			@minimum, @maximum, @step, @initial, @value
			}

			);
		}

		public void Decrement(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("counter", "decrement", target);
		}

		public void Increment(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("counter", "increment", target);
		}

		public void Reset(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("counter", "reset", target);
		}
	}

	public record CounterConfigureParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("minimum")]
		public long? Minimum { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("maximum")]
		public long? Maximum { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("step")]
		public long? Step { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("initial")]
		public long? Initial { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("value")]
		public long? Value { get; init; }
	}

	public class CoverServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public CoverServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CloseCover(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover", target);
		}

		public void CloseCoverTilt(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "close_cover_tilt", target);
		}

		public void OpenCover(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover", target);
		}

		public void OpenCoverTilt(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "open_cover_tilt", target);
		}

		public void SetCoverPosition(NetDaemon.HassModel.Entities.ServiceTarget target, CoverSetCoverPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_position", target, data);
		}

		public void SetCoverPosition(NetDaemon.HassModel.Entities.ServiceTarget target, long @position)
		{
			_haContext.CallService("cover", "set_cover_position", target, new
			{
			@position
			}

			);
		}

		public void SetCoverTiltPosition(NetDaemon.HassModel.Entities.ServiceTarget target, CoverSetCoverTiltPositionParameters data)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, data);
		}

		public void SetCoverTiltPosition(NetDaemon.HassModel.Entities.ServiceTarget target, long @tiltPosition)
		{
			_haContext.CallService("cover", "set_cover_tilt_position", target, new
			{
			@tilt_position = @tiltPosition
			}

			);
		}

		public void StopCover(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover", target);
		}

		public void StopCoverTilt(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "stop_cover_tilt", target);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle", target);
		}

		public void ToggleCoverTilt(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("cover", "toggle_cover_tilt", target);
		}
	}

	public record CoverSetCoverPositionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("position")]
		public long? Position { get; init; }
	}

	public record CoverSetCoverTiltPositionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("tiltPosition")]
		public long? TiltPosition { get; init; }
	}

	public class DeviceTrackerServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public DeviceTrackerServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void See(DeviceTrackerSeeParameters data)
		{
			_haContext.CallService("device_tracker", "see", null, data);
		}

		public void See(string? @mac = null, string? @devId = null, string? @hostName = null, string? @locationName = null, object? @gps = null, long? @gpsAccuracy = null, long? @battery = null)
		{
			_haContext.CallService("device_tracker", "see", null, new
			{
			@mac, @dev_id = @devId, @host_name = @hostName, @location_name = @locationName, @gps, @gps_accuracy = @gpsAccuracy, @battery
			}

			);
		}
	}

	public record DeviceTrackerSeeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("mac")]
		public string? Mac { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("devId")]
		public string? DevId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("hostName")]
		public string? HostName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("locationName")]
		public string? LocationName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("gps")]
		public object? Gps { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("gpsAccuracy")]
		public long? GpsAccuracy { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("battery")]
		public long? Battery { get; init; }
	}

	public class DwainsDashboardServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public DwainsDashboardServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Installed()
		{
			_haContext.CallService("dwains_dashboard", "installed", null);
		}

		public void NotificationCreate(DwainsDashboardNotificationCreateParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_create", null, data);
		}

		public void NotificationCreate(string? @message = null, string? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_create", null, new
			{
			@message, @notification_id = @notificationId
			}

			);
		}

		public void NotificationDismiss(DwainsDashboardNotificationDismissParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_dismiss", null, data);
		}

		public void NotificationDismiss(string? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_dismiss", null, new
			{
			@notification_id = @notificationId
			}

			);
		}

		public void NotificationMarkRead(DwainsDashboardNotificationMarkReadParameters data)
		{
			_haContext.CallService("dwains_dashboard", "notification_mark_read", null, data);
		}

		public void NotificationMarkRead(string? @notificationId = null)
		{
			_haContext.CallService("dwains_dashboard", "notification_mark_read", null, new
			{
			@notification_id = @notificationId
			}

			);
		}

		public void Reload()
		{
			_haContext.CallService("dwains_dashboard", "reload", null);
		}
	}

	public record DwainsDashboardNotificationCreateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public record DwainsDashboardNotificationDismissParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public record DwainsDashboardNotificationMarkReadParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public class EntityControllerServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public EntityControllerServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void ClearBlock(EntityControllerClearBlockParameters data)
		{
			_haContext.CallService("entity_controller", "clear_block", null, data);
		}

		public void ClearBlock(string? @entityId = null)
		{
			_haContext.CallService("entity_controller", "clear_block", null, new
			{
			@entity_id = @entityId
			}

			);
		}

		public void DisableStayMode()
		{
			_haContext.CallService("entity_controller", "disable_stay_mode", null);
		}

		public void EnableStayMode()
		{
			_haContext.CallService("entity_controller", "enable_stay_mode", null);
		}

		public void SetNightMode(EntityControllerSetNightModeParameters data)
		{
			_haContext.CallService("entity_controller", "set_night_mode", null, data);
		}

		public void SetNightMode(string? @entityId = null, string? @startTime = null, string? @endTime = null)
		{
			_haContext.CallService("entity_controller", "set_night_mode", null, new
			{
			@entity_id = @entityId, @start_time = @startTime, @end_time = @endTime
			}

			);
		}
	}

	public record EntityControllerClearBlockParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }
	}

	public record EntityControllerSetNightModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("startTime")]
		public string? StartTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("endTime")]
		public string? EndTime { get; init; }
	}

	public class FanServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public FanServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void DecreaseSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, FanDecreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "decrease_speed", target, data);
		}

		public void DecreaseSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "decrease_speed", target, new
			{
			@percentage_step = @percentageStep
			}

			);
		}

		public void IncreaseSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, FanIncreaseSpeedParameters data)
		{
			_haContext.CallService("fan", "increase_speed", target, data);
		}

		public void IncreaseSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, long? @percentageStep = null)
		{
			_haContext.CallService("fan", "increase_speed", target, new
			{
			@percentage_step = @percentageStep
			}

			);
		}

		public void Oscillate(NetDaemon.HassModel.Entities.ServiceTarget target, FanOscillateParameters data)
		{
			_haContext.CallService("fan", "oscillate", target, data);
		}

		public void Oscillate(NetDaemon.HassModel.Entities.ServiceTarget target, bool @oscillating)
		{
			_haContext.CallService("fan", "oscillate", target, new
			{
			@oscillating
			}

			);
		}

		public void SetDirection(NetDaemon.HassModel.Entities.ServiceTarget target, FanSetDirectionParameters data)
		{
			_haContext.CallService("fan", "set_direction", target, data);
		}

		public void SetDirection(NetDaemon.HassModel.Entities.ServiceTarget target, string @direction)
		{
			_haContext.CallService("fan", "set_direction", target, new
			{
			@direction
			}

			);
		}

		public void SetPercentage(NetDaemon.HassModel.Entities.ServiceTarget target, FanSetPercentageParameters data)
		{
			_haContext.CallService("fan", "set_percentage", target, data);
		}

		public void SetPercentage(NetDaemon.HassModel.Entities.ServiceTarget target, long @percentage)
		{
			_haContext.CallService("fan", "set_percentage", target, new
			{
			@percentage
			}

			);
		}

		public void SetPresetMode(NetDaemon.HassModel.Entities.ServiceTarget target, FanSetPresetModeParameters data)
		{
			_haContext.CallService("fan", "set_preset_mode", target, data);
		}

		public void SetPresetMode(NetDaemon.HassModel.Entities.ServiceTarget target, string @presetMode)
		{
			_haContext.CallService("fan", "set_preset_mode", target, new
			{
			@preset_mode = @presetMode
			}

			);
		}

		public void SetSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, FanSetSpeedParameters data)
		{
			_haContext.CallService("fan", "set_speed", target, data);
		}

		public void SetSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, string @speed)
		{
			_haContext.CallService("fan", "set_speed", target, new
			{
			@speed
			}

			);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("fan", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("fan", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, FanTurnOnParameters data)
		{
			_haContext.CallService("fan", "turn_on", target, data);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			_haContext.CallService("fan", "turn_on", target, new
			{
			@speed, @percentage, @preset_mode = @presetMode
			}

			);
		}
	}

	public record FanDecreaseSpeedParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("percentageStep")]
		public long? PercentageStep { get; init; }
	}

	public record FanIncreaseSpeedParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("percentageStep")]
		public long? PercentageStep { get; init; }
	}

	public record FanOscillateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("oscillating")]
		public bool? Oscillating { get; init; }
	}

	public record FanSetDirectionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("direction")]
		public string? Direction { get; init; }
	}

	public record FanSetPercentageParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("percentage")]
		public long? Percentage { get; init; }
	}

	public record FanSetPresetModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("presetMode")]
		public string? PresetMode { get; init; }
	}

	public record FanSetSpeedParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("speed")]
		public string? Speed { get; init; }
	}

	public record FanTurnOnParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("speed")]
		public string? Speed { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("percentage")]
		public long? Percentage { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("presetMode")]
		public string? PresetMode { get; init; }
	}

	public class FfmpegServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public FfmpegServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Restart(FfmpegRestartParameters data)
		{
			_haContext.CallService("ffmpeg", "restart", null, data);
		}

		public void Restart(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "restart", null, new
			{
			@entity_id = @entityId
			}

			);
		}

		public void Start(FfmpegStartParameters data)
		{
			_haContext.CallService("ffmpeg", "start", null, data);
		}

		public void Start(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "start", null, new
			{
			@entity_id = @entityId
			}

			);
		}

		public void Stop(FfmpegStopParameters data)
		{
			_haContext.CallService("ffmpeg", "stop", null, data);
		}

		public void Stop(string? @entityId = null)
		{
			_haContext.CallService("ffmpeg", "stop", null, new
			{
			@entity_id = @entityId
			}

			);
		}
	}

	public record FfmpegRestartParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStartParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }
	}

	public record FfmpegStopParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }
	}

	public class FrontendServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public FrontendServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void ReloadThemes()
		{
			_haContext.CallService("frontend", "reload_themes", null);
		}

		public void SetTheme(FrontendSetThemeParameters data)
		{
			_haContext.CallService("frontend", "set_theme", null, data);
		}

		public void SetTheme(string @name, string? @mode = null)
		{
			_haContext.CallService("frontend", "set_theme", null, new
			{
			@name, @mode
			}

			);
		}
	}

	public record FrontendSetThemeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public class GarbageCollectionServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public GarbageCollectionServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CollectGarbage(GarbageCollectionCollectGarbageParameters data)
		{
			_haContext.CallService("garbage_collection", "collect_garbage", null, data);
		}

		public void CollectGarbage(string? @entityId = null, string? @lastCollection = null)
		{
			_haContext.CallService("garbage_collection", "collect_garbage", null, new
			{
			@entity_id = @entityId, @last_collection = @lastCollection
			}

			);
		}
	}

	public record GarbageCollectionCollectGarbageParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("lastCollection")]
		public string? LastCollection { get; init; }
	}

	public class GoogleServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public GoogleServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AddEvent(GoogleAddEventParameters data)
		{
			_haContext.CallService("google", "add_event", null, data);
		}

		public void AddEvent(string @calendarId, string @summary, string? @description = null, string? @startDateTime = null, string? @endDateTime = null, string? @startDate = null, string? @endDate = null, object? @in = null)
		{
			_haContext.CallService("google", "add_event", null, new
			{
			@calendar_id = @calendarId, @summary, @description, @start_date_time = @startDateTime, @end_date_time = @endDateTime, @start_date = @startDate, @end_date = @endDate, @in
			}

			);
		}

		public void FoundCalendar()
		{
			_haContext.CallService("google", "found_calendar", null);
		}

		public void ScanForCalendars()
		{
			_haContext.CallService("google", "scan_for_calendars", null);
		}
	}

	public record GoogleAddEventParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("calendarId")]
		public string? CalendarId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("summary")]
		public string? Summary { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("description")]
		public string? Description { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("startDateTime")]
		public string? StartDateTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("endDateTime")]
		public string? EndDateTime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("startDate")]
		public string? StartDate { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("endDate")]
		public string? EndDate { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("in")]
		public object? In { get; init; }
	}

	public class GroupServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public GroupServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("group", "reload", null);
		}

		public void Remove(GroupRemoveParameters data)
		{
			_haContext.CallService("group", "remove", null, data);
		}

		public void Remove(object @objectId)
		{
			_haContext.CallService("group", "remove", null, new
			{
			@object_id = @objectId
			}

			);
		}

		public void Set(GroupSetParameters data)
		{
			_haContext.CallService("group", "set", null, data);
		}

		public void Set(string @objectId, string? @name = null, string? @icon = null, object? @entities = null, object? @addEntities = null, bool? @all = null)
		{
			_haContext.CallService("group", "set", null, new
			{
			@object_id = @objectId, @name, @icon, @entities, @add_entities = @addEntities, @all
			}

			);
		}
	}

	public record GroupRemoveParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("objectId")]
		public object? ObjectId { get; init; }
	}

	public record GroupSetParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("objectId")]
		public string? ObjectId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("entities")]
		public object? Entities { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("addEntities")]
		public object? AddEntities { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("all")]
		public bool? All { get; init; }
	}

	public class HassioServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public HassioServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AddonRestart(HassioAddonRestartParameters data)
		{
			_haContext.CallService("hassio", "addon_restart", null, data);
		}

		public void AddonRestart(string @addon)
		{
			_haContext.CallService("hassio", "addon_restart", null, new
			{
			@addon
			}

			);
		}

		public void AddonStart(HassioAddonStartParameters data)
		{
			_haContext.CallService("hassio", "addon_start", null, data);
		}

		public void AddonStart(string @addon)
		{
			_haContext.CallService("hassio", "addon_start", null, new
			{
			@addon
			}

			);
		}

		public void AddonStdin(HassioAddonStdinParameters data)
		{
			_haContext.CallService("hassio", "addon_stdin", null, data);
		}

		public void AddonStdin(string @addon)
		{
			_haContext.CallService("hassio", "addon_stdin", null, new
			{
			@addon
			}

			);
		}

		public void AddonStop(HassioAddonStopParameters data)
		{
			_haContext.CallService("hassio", "addon_stop", null, data);
		}

		public void AddonStop(string @addon)
		{
			_haContext.CallService("hassio", "addon_stop", null, new
			{
			@addon
			}

			);
		}

		public void AddonUpdate(HassioAddonUpdateParameters data)
		{
			_haContext.CallService("hassio", "addon_update", null, data);
		}

		public void AddonUpdate(string @addon)
		{
			_haContext.CallService("hassio", "addon_update", null, new
			{
			@addon
			}

			);
		}

		public void BackupFull(HassioBackupFullParameters data)
		{
			_haContext.CallService("hassio", "backup_full", null, data);
		}

		public void BackupFull(string? @name = null, string? @password = null)
		{
			_haContext.CallService("hassio", "backup_full", null, new
			{
			@name, @password
			}

			);
		}

		public void BackupPartial(HassioBackupPartialParameters data)
		{
			_haContext.CallService("hassio", "backup_partial", null, data);
		}

		public void BackupPartial(object? @addons = null, object? @folders = null, string? @name = null, string? @password = null)
		{
			_haContext.CallService("hassio", "backup_partial", null, new
			{
			@addons, @folders, @name, @password
			}

			);
		}

		public void HostReboot()
		{
			_haContext.CallService("hassio", "host_reboot", null);
		}

		public void HostShutdown()
		{
			_haContext.CallService("hassio", "host_shutdown", null);
		}

		public void RestoreFull(HassioRestoreFullParameters data)
		{
			_haContext.CallService("hassio", "restore_full", null, data);
		}

		public void RestoreFull(string @slug, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_full", null, new
			{
			@slug, @password
			}

			);
		}

		public void RestorePartial(HassioRestorePartialParameters data)
		{
			_haContext.CallService("hassio", "restore_partial", null, data);
		}

		public void RestorePartial(string @slug, bool? @homeassistant = null, object? @folders = null, object? @addons = null, string? @password = null)
		{
			_haContext.CallService("hassio", "restore_partial", null, new
			{
			@slug, @homeassistant, @folders, @addons, @password
			}

			);
		}
	}

	public record HassioAddonRestartParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStartParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStdinParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonStopParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioAddonUpdateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addon")]
		public string? Addon { get; init; }
	}

	public record HassioBackupFullParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public record HassioBackupPartialParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("addons")]
		public object? Addons { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("folders")]
		public object? Folders { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public record HassioRestoreFullParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("slug")]
		public string? Slug { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public record HassioRestorePartialParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("slug")]
		public string? Slug { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("homeassistant")]
		public bool? Homeassistant { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("folders")]
		public object? Folders { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("addons")]
		public object? Addons { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("password")]
		public string? Password { get; init; }
	}

	public class HomeassistantServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public HomeassistantServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CheckConfig()
		{
			_haContext.CallService("homeassistant", "check_config", null);
		}

		public void ReloadConfigEntry(NetDaemon.HassModel.Entities.ServiceTarget target, HomeassistantReloadConfigEntryParameters data)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, data);
		}

		public void ReloadConfigEntry(NetDaemon.HassModel.Entities.ServiceTarget target, string? @entryId = null)
		{
			_haContext.CallService("homeassistant", "reload_config_entry", target, new
			{
			@entry_id = @entryId
			}

			);
		}

		public void ReloadCoreConfig()
		{
			_haContext.CallService("homeassistant", "reload_core_config", null);
		}

		public void Restart()
		{
			_haContext.CallService("homeassistant", "restart", null);
		}

		public void SavePersistentStates()
		{
			_haContext.CallService("homeassistant", "save_persistent_states", null);
		}

		public void SetLocation(HomeassistantSetLocationParameters data)
		{
			_haContext.CallService("homeassistant", "set_location", null, data);
		}

		public void SetLocation(string @latitude, string @longitude)
		{
			_haContext.CallService("homeassistant", "set_location", null, new
			{
			@latitude, @longitude
			}

			);
		}

		public void Stop()
		{
			_haContext.CallService("homeassistant", "stop", null);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "turn_on", target);
		}

		public void UpdateEntity(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("homeassistant", "update_entity", target);
		}
	}

	public record HomeassistantReloadConfigEntryParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entryId")]
		public string? EntryId { get; init; }
	}

	public record HomeassistantSetLocationParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("latitude")]
		public string? Latitude { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("longitude")]
		public string? Longitude { get; init; }
	}

	public class InputBooleanServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputBooleanServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("input_boolean", "reload", null);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_boolean", "turn_on", target);
		}
	}

	public class InputDatetimeServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputDatetimeServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("input_datetime", "reload", null);
		}

		public void SetDatetime(NetDaemon.HassModel.Entities.ServiceTarget target, InputDatetimeSetDatetimeParameters data)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, data);
		}

		public void SetDatetime(NetDaemon.HassModel.Entities.ServiceTarget target, string? @date = null, DateTime? @time = null, string? @datetime = null, long? @timestamp = null)
		{
			_haContext.CallService("input_datetime", "set_datetime", target, new
			{
			@date, @time, @datetime, @timestamp
			}

			);
		}
	}

	public record InputDatetimeSetDatetimeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("date")]
		public string? Date { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("time")]
		public DateTime? Time { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("datetime")]
		public string? Datetime { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("timestamp")]
		public long? Timestamp { get; init; }
	}

	public class InputNumberServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputNumberServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Decrement(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_number", "decrement", target);
		}

		public void Increment(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_number", "increment", target);
		}

		public void Reload()
		{
			_haContext.CallService("input_number", "reload", null);
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, InputNumberSetValueParameters data)
		{
			_haContext.CallService("input_number", "set_value", target, data);
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, double @value)
		{
			_haContext.CallService("input_number", "set_value", target, new
			{
			@value
			}

			);
		}
	}

	public record InputNumberSetValueParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("value")]
		public double? Value { get; init; }
	}

	public class InputSelectServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputSelectServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("input_select", "reload", null);
		}

		public void SelectFirst(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_first", target);
		}

		public void SelectLast(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("input_select", "select_last", target);
		}

		public void SelectNext(NetDaemon.HassModel.Entities.ServiceTarget target, InputSelectSelectNextParameters data)
		{
			_haContext.CallService("input_select", "select_next", target, data);
		}

		public void SelectNext(NetDaemon.HassModel.Entities.ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_next", target, new
			{
			@cycle
			}

			);
		}

		public void SelectOption(NetDaemon.HassModel.Entities.ServiceTarget target, InputSelectSelectOptionParameters data)
		{
			_haContext.CallService("input_select", "select_option", target, data);
		}

		public void SelectOption(NetDaemon.HassModel.Entities.ServiceTarget target, string @option)
		{
			_haContext.CallService("input_select", "select_option", target, new
			{
			@option
			}

			);
		}

		public void SelectPrevious(NetDaemon.HassModel.Entities.ServiceTarget target, InputSelectSelectPreviousParameters data)
		{
			_haContext.CallService("input_select", "select_previous", target, data);
		}

		public void SelectPrevious(NetDaemon.HassModel.Entities.ServiceTarget target, bool? @cycle = null)
		{
			_haContext.CallService("input_select", "select_previous", target, new
			{
			@cycle
			}

			);
		}

		public void SetOptions(NetDaemon.HassModel.Entities.ServiceTarget target, InputSelectSetOptionsParameters data)
		{
			_haContext.CallService("input_select", "set_options", target, data);
		}

		public void SetOptions(NetDaemon.HassModel.Entities.ServiceTarget target, object @options)
		{
			_haContext.CallService("input_select", "set_options", target, new
			{
			@options
			}

			);
		}
	}

	public record InputSelectSelectNextParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSelectOptionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public record InputSelectSelectPreviousParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("cycle")]
		public bool? Cycle { get; init; }
	}

	public record InputSelectSetOptionsParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class InputTextServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public InputTextServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("input_text", "reload", null);
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, InputTextSetValueParameters data)
		{
			_haContext.CallService("input_text", "set_value", target, data);
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, string @value)
		{
			_haContext.CallService("input_text", "set_value", target, new
			{
			@value
			}

			);
		}
	}

	public record InputTextSetValueParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class LightServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public LightServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target, LightToggleParameters data)
		{
			_haContext.CallService("light", "toggle", target, data);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target, long? @transition = null, object? @rgbColor = null, string? @colorName = null, object? @hsColor = null, object? @xyColor = null, long? @colorTemp = null, long? @kelvin = null, long? @whiteValue = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, string? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "toggle", target, new
			{
			@transition, @rgb_color = @rgbColor, @color_name = @colorName, @hs_color = @hsColor, @xy_color = @xyColor, @color_temp = @colorTemp, @kelvin, @white_value = @whiteValue, @brightness, @brightness_pct = @brightnessPct, @profile, @flash, @effect
			}

			);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target, LightTurnOffParameters data)
		{
			_haContext.CallService("light", "turn_off", target, data);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target, long? @transition = null, string? @flash = null)
		{
			_haContext.CallService("light", "turn_off", target, new
			{
			@transition, @flash
			}

			);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, LightTurnOnParameters data)
		{
			_haContext.CallService("light", "turn_on", target, data);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, string? @colorName = null, object? @hsColor = null, object? @xyColor = null, long? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, string? @flash = null, string? @effect = null)
		{
			_haContext.CallService("light", "turn_on", target, new
			{
			@transition, @rgb_color = @rgbColor, @rgbw_color = @rgbwColor, @rgbww_color = @rgbwwColor, @color_name = @colorName, @hs_color = @hsColor, @xy_color = @xyColor, @color_temp = @colorTemp, @kelvin, @brightness, @brightness_pct = @brightnessPct, @brightness_step = @brightnessStep, @brightness_step_pct = @brightnessStepPct, @white, @profile, @flash, @effect
			}

			);
		}
	}

	public record LightToggleParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("transition")]
		public long? Transition { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("rgbColor")]
		public object? RgbColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("colorName")]
		public string? ColorName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("hsColor")]
		public object? HsColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("xyColor")]
		public object? XyColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("colorTemp")]
		public long? ColorTemp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("whiteValue")]
		public long? WhiteValue { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightnessPct")]
		public long? BrightnessPct { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("profile")]
		public string? Profile { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("flash")]
		public string? Flash { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public record LightTurnOffParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("transition")]
		public long? Transition { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("flash")]
		public string? Flash { get; init; }
	}

	public record LightTurnOnParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("transition")]
		public long? Transition { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("rgbColor")]
		public object? RgbColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("rgbwColor")]
		public object? RgbwColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("rgbwwColor")]
		public object? RgbwwColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("colorName")]
		public string? ColorName { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("hsColor")]
		public object? HsColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("xyColor")]
		public object? XyColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("colorTemp")]
		public long? ColorTemp { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightnessPct")]
		public long? BrightnessPct { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightnessStep")]
		public long? BrightnessStep { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightnessStepPct")]
		public long? BrightnessStepPct { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("white")]
		public long? White { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("profile")]
		public string? Profile { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("flash")]
		public string? Flash { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("effect")]
		public string? Effect { get; init; }
	}

	public class LockServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public LockServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Lock(NetDaemon.HassModel.Entities.ServiceTarget target, LockLockParameters data)
		{
			_haContext.CallService("lock", "lock", target, data);
		}

		public void Lock(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "lock", target, new
			{
			@code
			}

			);
		}

		public void Open(NetDaemon.HassModel.Entities.ServiceTarget target, LockOpenParameters data)
		{
			_haContext.CallService("lock", "open", target, data);
		}

		public void Open(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "open", target, new
			{
			@code
			}

			);
		}

		public void Unlock(NetDaemon.HassModel.Entities.ServiceTarget target, LockUnlockParameters data)
		{
			_haContext.CallService("lock", "unlock", target, data);
		}

		public void Unlock(NetDaemon.HassModel.Entities.ServiceTarget target, string? @code = null)
		{
			_haContext.CallService("lock", "unlock", target, new
			{
			@code
			}

			);
		}
	}

	public record LockLockParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockOpenParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public record LockUnlockParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("code")]
		public string? Code { get; init; }
	}

	public class LogbookServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public LogbookServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Log(LogbookLogParameters data)
		{
			_haContext.CallService("logbook", "log", null, data);
		}

		public void Log(string @name, string @message, string? @entityId = null, string? @domain = null)
		{
			_haContext.CallService("logbook", "log", null, new
			{
			@name, @message, @entity_id = @entityId, @domain
			}

			);
		}
	}

	public record LogbookLogParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("domain")]
		public string? Domain { get; init; }
	}

	public class LoggerServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public LoggerServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void SetDefaultLevel(LoggerSetDefaultLevelParameters data)
		{
			_haContext.CallService("logger", "set_default_level", null, data);
		}

		public void SetDefaultLevel(string? @level = null)
		{
			_haContext.CallService("logger", "set_default_level", null, new
			{
			@level
			}

			);
		}

		public void SetLevel()
		{
			_haContext.CallService("logger", "set_level", null);
		}
	}

	public record LoggerSetDefaultLevelParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("level")]
		public string? Level { get; init; }
	}

	public class MediaPlayerServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public MediaPlayerServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void ClearPlaylist(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "clear_playlist", target);
		}

		public void Join(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerJoinParameters data)
		{
			_haContext.CallService("media_player", "join", target, data);
		}

		public void Join(NetDaemon.HassModel.Entities.ServiceTarget target, object? @groupMembers = null)
		{
			_haContext.CallService("media_player", "join", target, new
			{
			@group_members = @groupMembers
			}

			);
		}

		public void MediaNextTrack(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_next_track", target);
		}

		public void MediaPause(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_pause", target);
		}

		public void MediaPlay(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play", target);
		}

		public void MediaPlayPause(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_play_pause", target);
		}

		public void MediaPreviousTrack(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_previous_track", target);
		}

		public void MediaSeek(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerMediaSeekParameters data)
		{
			_haContext.CallService("media_player", "media_seek", target, data);
		}

		public void MediaSeek(NetDaemon.HassModel.Entities.ServiceTarget target, double @seekPosition)
		{
			_haContext.CallService("media_player", "media_seek", target, new
			{
			@seek_position = @seekPosition
			}

			);
		}

		public void MediaStop(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "media_stop", target);
		}

		public void PlayMedia(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerPlayMediaParameters data)
		{
			_haContext.CallService("media_player", "play_media", target, data);
		}

		public void PlayMedia(NetDaemon.HassModel.Entities.ServiceTarget target, string @mediaContentId, string @mediaContentType)
		{
			_haContext.CallService("media_player", "play_media", target, new
			{
			@media_content_id = @mediaContentId, @media_content_type = @mediaContentType
			}

			);
		}

		public void RepeatSet(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerRepeatSetParameters data)
		{
			_haContext.CallService("media_player", "repeat_set", target, data);
		}

		public void RepeatSet(NetDaemon.HassModel.Entities.ServiceTarget target, string @repeat)
		{
			_haContext.CallService("media_player", "repeat_set", target, new
			{
			@repeat
			}

			);
		}

		public void SelectSoundMode(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerSelectSoundModeParameters data)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, data);
		}

		public void SelectSoundMode(NetDaemon.HassModel.Entities.ServiceTarget target, string? @soundMode = null)
		{
			_haContext.CallService("media_player", "select_sound_mode", target, new
			{
			@sound_mode = @soundMode
			}

			);
		}

		public void SelectSource(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerSelectSourceParameters data)
		{
			_haContext.CallService("media_player", "select_source", target, data);
		}

		public void SelectSource(NetDaemon.HassModel.Entities.ServiceTarget target, string @source)
		{
			_haContext.CallService("media_player", "select_source", target, new
			{
			@source
			}

			);
		}

		public void ShuffleSet(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerShuffleSetParameters data)
		{
			_haContext.CallService("media_player", "shuffle_set", target, data);
		}

		public void ShuffleSet(NetDaemon.HassModel.Entities.ServiceTarget target, bool @shuffle)
		{
			_haContext.CallService("media_player", "shuffle_set", target, new
			{
			@shuffle
			}

			);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "turn_on", target);
		}

		public void Unjoin(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "unjoin", target);
		}

		public void VolumeDown(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_down", target);
		}

		public void VolumeMute(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerVolumeMuteParameters data)
		{
			_haContext.CallService("media_player", "volume_mute", target, data);
		}

		public void VolumeMute(NetDaemon.HassModel.Entities.ServiceTarget target, bool @isVolumeMuted)
		{
			_haContext.CallService("media_player", "volume_mute", target, new
			{
			@is_volume_muted = @isVolumeMuted
			}

			);
		}

		public void VolumeSet(NetDaemon.HassModel.Entities.ServiceTarget target, MediaPlayerVolumeSetParameters data)
		{
			_haContext.CallService("media_player", "volume_set", target, data);
		}

		public void VolumeSet(NetDaemon.HassModel.Entities.ServiceTarget target, double @volumeLevel)
		{
			_haContext.CallService("media_player", "volume_set", target, new
			{
			@volume_level = @volumeLevel
			}

			);
		}

		public void VolumeUp(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("media_player", "volume_up", target);
		}
	}

	public record MediaPlayerJoinParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("groupMembers")]
		public object? GroupMembers { get; init; }
	}

	public record MediaPlayerMediaSeekParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("seekPosition")]
		public double? SeekPosition { get; init; }
	}

	public record MediaPlayerPlayMediaParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("mediaContentId")]
		public string? MediaContentId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("mediaContentType")]
		public string? MediaContentType { get; init; }
	}

	public record MediaPlayerRepeatSetParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("repeat")]
		public string? Repeat { get; init; }
	}

	public record MediaPlayerSelectSoundModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("soundMode")]
		public string? SoundMode { get; init; }
	}

	public record MediaPlayerSelectSourceParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("source")]
		public string? Source { get; init; }
	}

	public record MediaPlayerShuffleSetParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("shuffle")]
		public bool? Shuffle { get; init; }
	}

	public record MediaPlayerVolumeMuteParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("isVolumeMuted")]
		public bool? IsVolumeMuted { get; init; }
	}

	public record MediaPlayerVolumeSetParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("volumeLevel")]
		public double? VolumeLevel { get; init; }
	}

	public class MotioneyeServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public MotioneyeServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Action(NetDaemon.HassModel.Entities.ServiceTarget target, MotioneyeActionParameters data)
		{
			_haContext.CallService("motioneye", "action", target, data);
		}

		public void Action(NetDaemon.HassModel.Entities.ServiceTarget target, string @action)
		{
			_haContext.CallService("motioneye", "action", target, new
			{
			@action
			}

			);
		}

		public void SetTextOverlay(NetDaemon.HassModel.Entities.ServiceTarget target, MotioneyeSetTextOverlayParameters data)
		{
			_haContext.CallService("motioneye", "set_text_overlay", target, data);
		}

		public void SetTextOverlay(NetDaemon.HassModel.Entities.ServiceTarget target, string? @leftText = null, string? @customLeftText = null, string? @rightText = null, string? @customRightText = null)
		{
			_haContext.CallService("motioneye", "set_text_overlay", target, new
			{
			@left_text = @leftText, @custom_left_text = @customLeftText, @right_text = @rightText, @custom_right_text = @customRightText
			}

			);
		}

		public void Snapshot(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("motioneye", "snapshot", target);
		}
	}

	public record MotioneyeActionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("action")]
		public string? Action { get; init; }
	}

	public record MotioneyeSetTextOverlayParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("leftText")]
		public string? LeftText { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("customLeftText")]
		public string? CustomLeftText { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("rightText")]
		public string? RightText { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("customRightText")]
		public string? CustomRightText { get; init; }
	}

	public class MqttServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public MqttServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Dump(MqttDumpParameters data)
		{
			_haContext.CallService("mqtt", "dump", null, data);
		}

		public void Dump(string? @topic = null, long? @duration = null)
		{
			_haContext.CallService("mqtt", "dump", null, new
			{
			@topic, @duration
			}

			);
		}

		public void Publish(MqttPublishParameters data)
		{
			_haContext.CallService("mqtt", "publish", null, data);
		}

		public void Publish(string @topic, string? @payload = null, object? @payloadTemplate = null, string? @qos = null, bool? @retain = null)
		{
			_haContext.CallService("mqtt", "publish", null, new
			{
			@topic, @payload, @payload_template = @payloadTemplate, @qos, @retain
			}

			);
		}
	}

	public record MqttDumpParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("topic")]
		public string? Topic { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record MqttPublishParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("topic")]
		public string? Topic { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("payload")]
		public string? Payload { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("payloadTemplate")]
		public object? PayloadTemplate { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("qos")]
		public string? Qos { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("retain")]
		public bool? Retain { get; init; }
	}

	public class NeatoServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NeatoServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CustomCleaning(NetDaemon.HassModel.Entities.ServiceTarget target, NeatoCustomCleaningParameters data)
		{
			_haContext.CallService("neato", "custom_cleaning", target, data);
		}

		public void CustomCleaning(NetDaemon.HassModel.Entities.ServiceTarget target, long? @mode = null, long? @navigation = null, long? @category = null, string? @zone = null)
		{
			_haContext.CallService("neato", "custom_cleaning", target, new
			{
			@mode, @navigation, @category, @zone
			}

			);
		}
	}

	public record NeatoCustomCleaningParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("mode")]
		public long? Mode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("navigation")]
		public long? Navigation { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("category")]
		public long? Category { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("zone")]
		public string? Zone { get; init; }
	}

	public class NestServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NestServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CancelEta(NestCancelEtaParameters data)
		{
			_haContext.CallService("nest", "cancel_eta", null, data);
		}

		public void CancelEta(string @tripId, object? @structure = null)
		{
			_haContext.CallService("nest", "cancel_eta", null, new
			{
			@trip_id = @tripId, @structure
			}

			);
		}

		public void SetAwayMode(NestSetAwayModeParameters data)
		{
			_haContext.CallService("nest", "set_away_mode", null, data);
		}

		public void SetAwayMode(string @awayMode, object? @structure = null)
		{
			_haContext.CallService("nest", "set_away_mode", null, new
			{
			@away_mode = @awayMode, @structure
			}

			);
		}

		public void SetEta(NestSetEtaParameters data)
		{
			_haContext.CallService("nest", "set_eta", null, data);
		}

		public void SetEta(DateTime @eta, DateTime? @etaWindow = null, string? @tripId = null, object? @structure = null)
		{
			_haContext.CallService("nest", "set_eta", null, new
			{
			@eta, @eta_window = @etaWindow, @trip_id = @tripId, @structure
			}

			);
		}
	}

	public record NestCancelEtaParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("tripId")]
		public string? TripId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public record NestSetAwayModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("awayMode")]
		public string? AwayMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public record NestSetEtaParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("eta")]
		public DateTime? Eta { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("etaWindow")]
		public DateTime? EtaWindow { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("tripId")]
		public string? TripId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("structure")]
		public object? Structure { get; init; }
	}

	public class NetdaemonServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NetdaemonServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void EntityCreate(NetdaemonEntityCreateParameters data)
		{
			_haContext.CallService("netdaemon", "entity_create", null, data);
		}

		public void EntityCreate(string? @entityId = null, string? @state = null, string? @icon = null, string? @unit = null, string? @attributes = null)
		{
			_haContext.CallService("netdaemon", "entity_create", null, new
			{
			@entity_id = @entityId, @state, @icon, @unit, @attributes
			}

			);
		}

		public void EntityRemove(NetdaemonEntityRemoveParameters data)
		{
			_haContext.CallService("netdaemon", "entity_remove", null, data);
		}

		public void EntityRemove(string? @entityId = null)
		{
			_haContext.CallService("netdaemon", "entity_remove", null, new
			{
			@entity_id = @entityId
			}

			);
		}

		public void EntityUpdate(NetdaemonEntityUpdateParameters data)
		{
			_haContext.CallService("netdaemon", "entity_update", null, data);
		}

		public void EntityUpdate(string? @entityId = null, string? @state = null, string? @icon = null, string? @unit = null, string? @attributes = null)
		{
			_haContext.CallService("netdaemon", "entity_update", null, new
			{
			@entity_id = @entityId, @state, @icon, @unit, @attributes
			}

			);
		}

		public void RegisterService(NetdaemonRegisterServiceParameters data)
		{
			_haContext.CallService("netdaemon", "register_service", null, data);
		}

		public void RegisterService(string? @service = null, string? @class = null, string? @method = null)
		{
			_haContext.CallService("netdaemon", "register_service", null, new
			{
			@service, @class, @method
			}

			);
		}

		public void ReloadApps()
		{
			_haContext.CallService("netdaemon", "reload_apps", null);
		}
	}

	public record NetdaemonEntityCreateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("state")]
		public string? State { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("unit")]
		public string? Unit { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("attributes")]
		public string? Attributes { get; init; }
	}

	public record NetdaemonEntityRemoveParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }
	}

	public record NetdaemonEntityUpdateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("state")]
		public string? State { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("icon")]
		public string? Icon { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("unit")]
		public string? Unit { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("attributes")]
		public string? Attributes { get; init; }
	}

	public record NetdaemonRegisterServiceParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("service")]
		public string? Service { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("class")]
		public string? Class { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("method")]
		public string? Method { get; init; }
	}

	public class NotifyServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NotifyServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AlexaMedia(NotifyAlexaMediaParameters data)
		{
			_haContext.CallService("notify", "alexa_media", null, data);
		}

		public void AlexaMedia(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaAllSpeakers(NotifyAlexaMediaAllSpeakersParameters data)
		{
			_haContext.CallService("notify", "alexa_media_all_speakers", null, data);
		}

		public void AlexaMediaAllSpeakers(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_all_speakers", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaAndrewSEchoBuds(NotifyAlexaMediaAndrewSEchoBudsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_echo_buds", null, data);
		}

		public void AlexaMediaAndrewSEchoBuds(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_echo_buds", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaAndrewSFireTv(NotifyAlexaMediaAndrewSFireTvParameters data)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_fire_tv", null, data);
		}

		public void AlexaMediaAndrewSFireTv(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_andrew_s_fire_tv", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaBedroomEchoShow(NotifyAlexaMediaBedroomEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_bedroom_echo_show", null, data);
		}

		public void AlexaMediaBedroomEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_bedroom_echo_show", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaDiningRoomEchoInput(NotifyAlexaMediaDiningRoomEchoInputParameters data)
		{
			_haContext.CallService("notify", "alexa_media_dining_room_echo_input", null, data);
		}

		public void AlexaMediaDiningRoomEchoInput(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_dining_room_echo_input", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaDownstairs(NotifyAlexaMediaDownstairsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_downstairs", null, data);
		}

		public void AlexaMediaDownstairs(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_downstairs", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaDrawingRoomEchoDot(NotifyAlexaMediaDrawingRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_drawing_room_echo_dot", null, data);
		}

		public void AlexaMediaDrawingRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_drawing_room_echo_dot", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaDressingRoomEchoDot(NotifyAlexaMediaDressingRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_dressing_room_echo_dot", null, data);
		}

		public void AlexaMediaDressingRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_dressing_room_echo_dot", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaGuestRoomEchoShow(NotifyAlexaMediaGuestRoomEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_guest_room_echo_show", null, data);
		}

		public void AlexaMediaGuestRoomEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_guest_room_echo_show", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaHallTablet(NotifyAlexaMediaHallTabletParameters data)
		{
			_haContext.CallService("notify", "alexa_media_hall_tablet", null, data);
		}

		public void AlexaMediaHallTablet(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_hall_tablet", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaKitchenEchoShow(NotifyAlexaMediaKitchenEchoShowParameters data)
		{
			_haContext.CallService("notify", "alexa_media_kitchen_echo_show", null, data);
		}

		public void AlexaMediaKitchenEchoShow(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_kitchen_echo_show", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaLandingTablet(NotifyAlexaMediaLandingTabletParameters data)
		{
			_haContext.CallService("notify", "alexa_media_landing_tablet", null, data);
		}

		public void AlexaMediaLandingTablet(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_landing_tablet", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaLastCalled(NotifyAlexaMediaLastCalledParameters data)
		{
			_haContext.CallService("notify", "alexa_media_last_called", null, data);
		}

		public void AlexaMediaLastCalled(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_last_called", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaLoungeEchoPlus(NotifyAlexaMediaLoungeEchoPlusParameters data)
		{
			_haContext.CallService("notify", "alexa_media_lounge_echo_plus", null, data);
		}

		public void AlexaMediaLoungeEchoPlus(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_lounge_echo_plus", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaLoungeFireTv(NotifyAlexaMediaLoungeFireTvParameters data)
		{
			_haContext.CallService("notify", "alexa_media_lounge_fire_tv", null, data);
		}

		public void AlexaMediaLoungeFireTv(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_lounge_fire_tv", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaSnug(NotifyAlexaMediaSnugParameters data)
		{
			_haContext.CallService("notify", "alexa_media_snug", null, data);
		}

		public void AlexaMediaSnug(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_snug", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaSnugEchoInput(NotifyAlexaMediaSnugEchoInputParameters data)
		{
			_haContext.CallService("notify", "alexa_media_snug_echo_input", null, data);
		}

		public void AlexaMediaSnugEchoInput(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_snug_echo_input", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaUpstairs(NotifyAlexaMediaUpstairsParameters data)
		{
			_haContext.CallService("notify", "alexa_media_upstairs", null, data);
		}

		public void AlexaMediaUpstairs(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_upstairs", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void AlexaMediaUtilityRoomEchoDot(NotifyAlexaMediaUtilityRoomEchoDotParameters data)
		{
			_haContext.CallService("notify", "alexa_media_utility_room_echo_dot", null, data);
		}

		public void AlexaMediaUtilityRoomEchoDot(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "alexa_media_utility_room_echo_dot", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void MobileAppAndrewsIphone(NotifyMobileAppAndrewsIphoneParameters data)
		{
			_haContext.CallService("notify", "mobile_app_andrews_iphone", null, data);
		}

		public void MobileAppAndrewsIphone(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_andrews_iphone", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void MobileAppClairesIphone(NotifyMobileAppClairesIphoneParameters data)
		{
			_haContext.CallService("notify", "mobile_app_claires_iphone", null, data);
		}

		public void MobileAppClairesIphone(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "mobile_app_claires_iphone", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void Notify(NotifyNotifyParameters data)
		{
			_haContext.CallService("notify", "notify", null, data);
		}

		public void Notify(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "notify", null, new
			{
			@message, @title, @target, @data
			}

			);
		}

		public void PersistentNotification(NotifyPersistentNotificationParameters data)
		{
			_haContext.CallService("notify", "persistent_notification", null, data);
		}

		public void PersistentNotification(string @message, string? @title = null)
		{
			_haContext.CallService("notify", "persistent_notification", null, new
			{
			@message, @title
			}

			);
		}

		public void Phones(NotifyPhonesParameters data)
		{
			_haContext.CallService("notify", "phones", null, data);
		}

		public void Phones(string @message, string? @title = null, object? @target = null, object? @data = null)
		{
			_haContext.CallService("notify", "phones", null, new
			{
			@message, @title, @target, @data
			}

			);
		}
	}

	public record NotifyAlexaMediaParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAllSpeakersParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAndrewSEchoBudsParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaAndrewSFireTvParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaBedroomEchoShowParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDiningRoomEchoInputParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDownstairsParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDrawingRoomEchoDotParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaDressingRoomEchoDotParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaGuestRoomEchoShowParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaHallTabletParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaKitchenEchoShowParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLandingTabletParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLastCalledParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLoungeEchoPlusParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaLoungeFireTvParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaSnugParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaSnugEchoInputParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaUpstairsParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyAlexaMediaUtilityRoomEchoDotParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppAndrewsIphoneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyMobileAppClairesIphoneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyNotifyParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public record NotifyPersistentNotificationParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }
	}

	public record NotifyPhonesParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("target")]
		public object? Target { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("data")]
		public object? Data { get; init; }
	}

	public class NumberServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public NumberServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, NumberSetValueParameters data)
		{
			_haContext.CallService("number", "set_value", target, data);
		}

		public void SetValue(NetDaemon.HassModel.Entities.ServiceTarget target, string? @value = null)
		{
			_haContext.CallService("number", "set_value", target, new
			{
			@value
			}

			);
		}
	}

	public record NumberSetValueParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("value")]
		public string? Value { get; init; }
	}

	public class OnvifServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public OnvifServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Ptz(NetDaemon.HassModel.Entities.ServiceTarget target, OnvifPtzParameters data)
		{
			_haContext.CallService("onvif", "ptz", target, data);
		}

		public void Ptz(NetDaemon.HassModel.Entities.ServiceTarget target, string? @tilt = null, string? @pan = null, string? @zoom = null, double? @distance = null, double? @speed = null, double? @continuousDuration = null, string? @preset = null, string? @moveMode = null)
		{
			_haContext.CallService("onvif", "ptz", target, new
			{
			@tilt, @pan, @zoom, @distance, @speed, @continuous_duration = @continuousDuration, @preset, @move_mode = @moveMode
			}

			);
		}
	}

	public record OnvifPtzParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("tilt")]
		public string? Tilt { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("pan")]
		public string? Pan { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("zoom")]
		public string? Zoom { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("distance")]
		public double? Distance { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("speed")]
		public double? Speed { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("continuousDuration")]
		public double? ContinuousDuration { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("preset")]
		public string? Preset { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("moveMode")]
		public string? MoveMode { get; init; }
	}

	public class PersistentNotificationServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public PersistentNotificationServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Create(PersistentNotificationCreateParameters data)
		{
			_haContext.CallService("persistent_notification", "create", null, data);
		}

		public void Create(string @message, string? @title = null, string? @notificationId = null)
		{
			_haContext.CallService("persistent_notification", "create", null, new
			{
			@message, @title, @notification_id = @notificationId
			}

			);
		}

		public void Dismiss(PersistentNotificationDismissParameters data)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, data);
		}

		public void Dismiss(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "dismiss", null, new
			{
			@notification_id = @notificationId
			}

			);
		}

		public void MarkRead(PersistentNotificationMarkReadParameters data)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, data);
		}

		public void MarkRead(string @notificationId)
		{
			_haContext.CallService("persistent_notification", "mark_read", null, new
			{
			@notification_id = @notificationId
			}

			);
		}
	}

	public record PersistentNotificationCreateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("title")]
		public string? Title { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationDismissParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public record PersistentNotificationMarkReadParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("notificationId")]
		public string? NotificationId { get; init; }
	}

	public class PersonServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public PersonServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("person", "reload", null);
		}
	}

	public class RecorderServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public RecorderServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Disable()
		{
			_haContext.CallService("recorder", "disable", null);
		}

		public void Enable()
		{
			_haContext.CallService("recorder", "enable", null);
		}

		public void Purge(RecorderPurgeParameters data)
		{
			_haContext.CallService("recorder", "purge", null, data);
		}

		public void Purge(long? @keepDays = null, bool? @repack = null, bool? @applyFilter = null)
		{
			_haContext.CallService("recorder", "purge", null, new
			{
			@keep_days = @keepDays, @repack, @apply_filter = @applyFilter
			}

			);
		}

		public void PurgeEntities(NetDaemon.HassModel.Entities.ServiceTarget target, RecorderPurgeEntitiesParameters data)
		{
			_haContext.CallService("recorder", "purge_entities", target, data);
		}

		public void PurgeEntities(NetDaemon.HassModel.Entities.ServiceTarget target, object? @domains = null, object? @entityGlobs = null)
		{
			_haContext.CallService("recorder", "purge_entities", target, new
			{
			@domains, @entity_globs = @entityGlobs
			}

			);
		}
	}

	public record RecorderPurgeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("keepDays")]
		public long? KeepDays { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("repack")]
		public bool? Repack { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("applyFilter")]
		public bool? ApplyFilter { get; init; }
	}

	public record RecorderPurgeEntitiesParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("domains")]
		public object? Domains { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("entityGlobs")]
		public object? EntityGlobs { get; init; }
	}

	public class SceneServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SceneServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Apply(SceneApplyParameters data)
		{
			_haContext.CallService("scene", "apply", null, data);
		}

		public void Apply(object @entities, long? @transition = null)
		{
			_haContext.CallService("scene", "apply", null, new
			{
			@entities, @transition
			}

			);
		}

		public void Create(SceneCreateParameters data)
		{
			_haContext.CallService("scene", "create", null, data);
		}

		public void Create(string @sceneId, object? @entities = null, object? @snapshotEntities = null)
		{
			_haContext.CallService("scene", "create", null, new
			{
			@scene_id = @sceneId, @entities, @snapshot_entities = @snapshotEntities
			}

			);
		}

		public void Reload()
		{
			_haContext.CallService("scene", "reload", null);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, SceneTurnOnParameters data)
		{
			_haContext.CallService("scene", "turn_on", target, data);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target, long? @transition = null)
		{
			_haContext.CallService("scene", "turn_on", target, new
			{
			@transition
			}

			);
		}
	}

	public record SceneApplyParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entities")]
		public object? Entities { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public record SceneCreateParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("sceneId")]
		public string? SceneId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("entities")]
		public object? Entities { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("snapshotEntities")]
		public object? SnapshotEntities { get; init; }
	}

	public record SceneTurnOnParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("transition")]
		public long? Transition { get; init; }
	}

	public class ScriptServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ScriptServices(NetDaemon.HassModel.Common.IHaContext haContext)
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

		public void Reload()
		{
			_haContext.CallService("script", "reload", null);
		}

		public void RoomControllerReset()
		{
			_haContext.CallService("script", "room_controller_reset", null);
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("script", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("script", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("script", "turn_on", target);
		}
	}

	public class SelectServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SelectServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void SelectOption(NetDaemon.HassModel.Entities.ServiceTarget target, SelectSelectOptionParameters data)
		{
			_haContext.CallService("select", "select_option", target, data);
		}

		public void SelectOption(NetDaemon.HassModel.Entities.ServiceTarget target, string @option)
		{
			_haContext.CallService("select", "select_option", target, new
			{
			@option
			}

			);
		}
	}

	public record SelectSelectOptionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("option")]
		public string? Option { get; init; }
	}

	public class ShoppingListServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ShoppingListServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AddItem(ShoppingListAddItemParameters data)
		{
			_haContext.CallService("shopping_list", "add_item", null, data);
		}

		public void AddItem(string @name)
		{
			_haContext.CallService("shopping_list", "add_item", null, new
			{
			@name
			}

			);
		}

		public void ClearCompletedItems()
		{
			_haContext.CallService("shopping_list", "clear_completed_items", null);
		}

		public void CompleteAll()
		{
			_haContext.CallService("shopping_list", "complete_all", null);
		}

		public void CompleteItem(ShoppingListCompleteItemParameters data)
		{
			_haContext.CallService("shopping_list", "complete_item", null, data);
		}

		public void CompleteItem(string @name)
		{
			_haContext.CallService("shopping_list", "complete_item", null, new
			{
			@name
			}

			);
		}

		public void IncompleteAll()
		{
			_haContext.CallService("shopping_list", "incomplete_all", null);
		}

		public void IncompleteItem(ShoppingListIncompleteItemParameters data)
		{
			_haContext.CallService("shopping_list", "incomplete_item", null, data);
		}

		public void IncompleteItem(string @name)
		{
			_haContext.CallService("shopping_list", "incomplete_item", null, new
			{
			@name
			}

			);
		}
	}

	public record ShoppingListAddItemParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record ShoppingListCompleteItemParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public record ShoppingListIncompleteItemParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		public string? Name { get; init; }
	}

	public class SpeedtestdotnetServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SpeedtestdotnetServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Speedtest()
		{
			_haContext.CallService("speedtestdotnet", "speedtest", null);
		}
	}

	public class SqueezeboxServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SqueezeboxServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CallMethod(NetDaemon.HassModel.Entities.ServiceTarget target, SqueezeboxCallMethodParameters data)
		{
			_haContext.CallService("squeezebox", "call_method", target, data);
		}

		public void CallMethod(NetDaemon.HassModel.Entities.ServiceTarget target, string @command, object? @parameters = null)
		{
			_haContext.CallService("squeezebox", "call_method", target, new
			{
			@command, @parameters
			}

			);
		}

		public void CallQuery(NetDaemon.HassModel.Entities.ServiceTarget target, SqueezeboxCallQueryParameters data)
		{
			_haContext.CallService("squeezebox", "call_query", target, data);
		}

		public void CallQuery(NetDaemon.HassModel.Entities.ServiceTarget target, string @command, object? @parameters = null)
		{
			_haContext.CallService("squeezebox", "call_query", target, new
			{
			@command, @parameters
			}

			);
		}

		public void Sync(NetDaemon.HassModel.Entities.ServiceTarget target, SqueezeboxSyncParameters data)
		{
			_haContext.CallService("squeezebox", "sync", target, data);
		}

		public void Sync(NetDaemon.HassModel.Entities.ServiceTarget target, string @otherPlayer)
		{
			_haContext.CallService("squeezebox", "sync", target, new
			{
			@other_player = @otherPlayer
			}

			);
		}

		public void Unsync(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("squeezebox", "unsync", target);
		}
	}

	public record SqueezeboxCallMethodParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("command")]
		public string? Command { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("parameters")]
		public object? Parameters { get; init; }
	}

	public record SqueezeboxCallQueryParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("command")]
		public string? Command { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("parameters")]
		public object? Parameters { get; init; }
	}

	public record SqueezeboxSyncParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("otherPlayer")]
		public string? OtherPlayer { get; init; }
	}

	public class SwitchServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SwitchServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Toggle(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("switch", "toggle", target);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("switch", "turn_on", target);
		}
	}

	public class SystemLogServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public SystemLogServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Clear()
		{
			_haContext.CallService("system_log", "clear", null);
		}

		public void Write(SystemLogWriteParameters data)
		{
			_haContext.CallService("system_log", "write", null, data);
		}

		public void Write(string @message, string? @level = null, string? @logger = null)
		{
			_haContext.CallService("system_log", "write", null, new
			{
			@message, @level, @logger
			}

			);
		}
	}

	public record SystemLogWriteParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("level")]
		public string? Level { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("logger")]
		public string? Logger { get; init; }
	}

	public class TemplateServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public TemplateServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("template", "reload", null);
		}
	}

	public class TimerServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public TimerServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Cancel(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("timer", "cancel", target);
		}

		public void Finish(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("timer", "finish", target);
		}

		public void Pause(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("timer", "pause", target);
		}

		public void Reload()
		{
			_haContext.CallService("timer", "reload", null);
		}

		public void Start(NetDaemon.HassModel.Entities.ServiceTarget target, TimerStartParameters data)
		{
			_haContext.CallService("timer", "start", target, data);
		}

		public void Start(NetDaemon.HassModel.Entities.ServiceTarget target, string? @duration = null)
		{
			_haContext.CallService("timer", "start", target, new
			{
			@duration
			}

			);
		}
	}

	public record TimerStartParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public string? Duration { get; init; }
	}

	public class TtsServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public TtsServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void ClearCache()
		{
			_haContext.CallService("tts", "clear_cache", null);
		}

		public void CloudSay(TtsCloudSayParameters data)
		{
			_haContext.CallService("tts", "cloud_say", null, data);
		}

		public void CloudSay(string @entityId, string @message, bool? @cache = null, string? @language = null, object? @options = null)
		{
			_haContext.CallService("tts", "cloud_say", null, new
			{
			@entity_id = @entityId, @message, @cache, @language, @options
			}

			);
		}
	}

	public record TtsCloudSayParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("cache")]
		public bool? Cache { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("language")]
		public string? Language { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("options")]
		public object? Options { get; init; }
	}

	public class UnifiprotectServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public UnifiprotectServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void AddDoorbellText(UnifiprotectAddDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "add_doorbell_text", null, data);
		}

		public void AddDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "add_doorbell_text", null, new
			{
			@device_id = @deviceId, @message
			}

			);
		}

		public void ProfileWsMessages(UnifiprotectProfileWsMessagesParameters data)
		{
			_haContext.CallService("unifiprotect", "profile_ws_messages", null, data);
		}

		public void ProfileWsMessages(string @deviceId, long @duration)
		{
			_haContext.CallService("unifiprotect", "profile_ws_messages", null, new
			{
			@device_id = @deviceId, @duration
			}

			);
		}

		public void RemoveDoorbellText(UnifiprotectRemoveDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "remove_doorbell_text", null, data);
		}

		public void RemoveDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "remove_doorbell_text", null, new
			{
			@device_id = @deviceId, @message
			}

			);
		}

		public void SetDefaultDoorbellText(UnifiprotectSetDefaultDoorbellTextParameters data)
		{
			_haContext.CallService("unifiprotect", "set_default_doorbell_text", null, data);
		}

		public void SetDefaultDoorbellText(string @deviceId, string @message)
		{
			_haContext.CallService("unifiprotect", "set_default_doorbell_text", null, new
			{
			@device_id = @deviceId, @message
			}

			);
		}

		public void SetDoorbellChimeDuration(UnifiprotectSetDoorbellChimeDurationParameters data)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_chime_duration", null, data);
		}

		public void SetDoorbellChimeDuration(string @entityId, long @chimeDuration)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_chime_duration", null, new
			{
			@entity_id = @entityId, @chime_duration = @chimeDuration
			}

			);
		}

		public void SetDoorbellLcdMessage(UnifiprotectSetDoorbellLcdMessageParameters data)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_lcd_message", null, data);
		}

		public void SetDoorbellLcdMessage(string @entityId, string @message, long? @duration = null)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_lcd_message", null, new
			{
			@entity_id = @entityId, @message, @duration
			}

			);
		}

		public void SetDoorbellMessage(UnifiprotectSetDoorbellMessageParameters data)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_message", null, data);
		}

		public void SetDoorbellMessage(string @entityId, string @message, long? @duration = null)
		{
			_haContext.CallService("unifiprotect", "set_doorbell_message", null, new
			{
			@entity_id = @entityId, @message, @duration
			}

			);
		}

		public void SetHdrMode(UnifiprotectSetHdrModeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_hdr_mode", null, data);
		}

		public void SetHdrMode(string @entityId, bool? @hdrOn = null)
		{
			_haContext.CallService("unifiprotect", "set_hdr_mode", null, new
			{
			@entity_id = @entityId, @hdr_on = @hdrOn
			}

			);
		}

		public void SetHighfpsVideoMode(UnifiprotectSetHighfpsVideoModeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_highfps_video_mode", null, data);
		}

		public void SetHighfpsVideoMode(string @entityId, bool? @highFpsOn = null)
		{
			_haContext.CallService("unifiprotect", "set_highfps_video_mode", null, new
			{
			@entity_id = @entityId, @high_fps_on = @highFpsOn
			}

			);
		}

		public void SetIrMode(UnifiprotectSetIrModeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_ir_mode", null, data);
		}

		public void SetIrMode(string @entityId, string? @irMode = null)
		{
			_haContext.CallService("unifiprotect", "set_ir_mode", null, new
			{
			@entity_id = @entityId, @ir_mode = @irMode
			}

			);
		}

		public void SetMicVolume(UnifiprotectSetMicVolumeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_mic_volume", null, data);
		}

		public void SetMicVolume(string @entityId, long? @level = null)
		{
			_haContext.CallService("unifiprotect", "set_mic_volume", null, new
			{
			@entity_id = @entityId, @level
			}

			);
		}

		public void SetPrivacyMode(UnifiprotectSetPrivacyModeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_privacy_mode", null, data);
		}

		public void SetPrivacyMode(string @entityId, bool? @privacyMode = null, long? @micLevel = null, string? @recordingMode = null)
		{
			_haContext.CallService("unifiprotect", "set_privacy_mode", null, new
			{
			@entity_id = @entityId, @privacy_mode = @privacyMode, @mic_level = @micLevel, @recording_mode = @recordingMode
			}

			);
		}

		public void SetRecordingMode(UnifiprotectSetRecordingModeParameters data)
		{
			_haContext.CallService("unifiprotect", "set_recording_mode", null, data);
		}

		public void SetRecordingMode(string @entityId, string @recordingMode)
		{
			_haContext.CallService("unifiprotect", "set_recording_mode", null, new
			{
			@entity_id = @entityId, @recording_mode = @recordingMode
			}

			);
		}

		public void SetStatusLight(UnifiprotectSetStatusLightParameters data)
		{
			_haContext.CallService("unifiprotect", "set_status_light", null, data);
		}

		public void SetStatusLight(string @entityId, bool? @lightOn = null)
		{
			_haContext.CallService("unifiprotect", "set_status_light", null, new
			{
			@entity_id = @entityId, @light_on = @lightOn
			}

			);
		}

		public void SetWdrValue(UnifiprotectSetWdrValueParameters data)
		{
			_haContext.CallService("unifiprotect", "set_wdr_value", null, data);
		}

		public void SetWdrValue(string @entityId, long? @value = null)
		{
			_haContext.CallService("unifiprotect", "set_wdr_value", null, new
			{
			@entity_id = @entityId, @value
			}

			);
		}

		public void SetZoomPosition(UnifiprotectSetZoomPositionParameters data)
		{
			_haContext.CallService("unifiprotect", "set_zoom_position", null, data);
		}

		public void SetZoomPosition(string @entityId, long? @position = null)
		{
			_haContext.CallService("unifiprotect", "set_zoom_position", null, new
			{
			@entity_id = @entityId, @position
			}

			);
		}
	}

	public record UnifiprotectAddDoorbellTextParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("deviceId")]
		public string? DeviceId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectProfileWsMessagesParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("deviceId")]
		public string? DeviceId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record UnifiprotectRemoveDoorbellTextParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("deviceId")]
		public string? DeviceId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectSetDefaultDoorbellTextParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("deviceId")]
		public string? DeviceId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }
	}

	public record UnifiprotectSetDoorbellChimeDurationParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("chimeDuration")]
		public long? ChimeDuration { get; init; }
	}

	public record UnifiprotectSetDoorbellLcdMessageParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record UnifiprotectSetDoorbellMessageParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("message")]
		public string? Message { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("duration")]
		public long? Duration { get; init; }
	}

	public record UnifiprotectSetHdrModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("hdrOn")]
		public bool? HdrOn { get; init; }
	}

	public record UnifiprotectSetHighfpsVideoModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("highFpsOn")]
		public bool? HighFpsOn { get; init; }
	}

	public record UnifiprotectSetIrModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("irMode")]
		public string? IrMode { get; init; }
	}

	public record UnifiprotectSetMicVolumeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("level")]
		public long? Level { get; init; }
	}

	public record UnifiprotectSetPrivacyModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("privacyMode")]
		public bool? PrivacyMode { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("micLevel")]
		public long? MicLevel { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("recordingMode")]
		public string? RecordingMode { get; init; }
	}

	public record UnifiprotectSetRecordingModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("recordingMode")]
		public string? RecordingMode { get; init; }
	}

	public record UnifiprotectSetStatusLightParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("lightOn")]
		public bool? LightOn { get; init; }
	}

	public record UnifiprotectSetWdrValueParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("value")]
		public long? Value { get; init; }
	}

	public record UnifiprotectSetZoomPositionParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("entityId")]
		public string? EntityId { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("position")]
		public long? Position { get; init; }
	}

	public class VacuumServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public VacuumServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void CleanSpot(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "clean_spot", target);
		}

		public void Locate(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "locate", target);
		}

		public void Pause(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "pause", target);
		}

		public void ReturnToBase(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "return_to_base", target);
		}

		public void SendCommand(NetDaemon.HassModel.Entities.ServiceTarget target, VacuumSendCommandParameters data)
		{
			_haContext.CallService("vacuum", "send_command", target, data);
		}

		public void SendCommand(NetDaemon.HassModel.Entities.ServiceTarget target, string @command, object? @params = null)
		{
			_haContext.CallService("vacuum", "send_command", target, new
			{
			@command, @params
			}

			);
		}

		public void SetFanSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, VacuumSetFanSpeedParameters data)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, data);
		}

		public void SetFanSpeed(NetDaemon.HassModel.Entities.ServiceTarget target, string @fanSpeed)
		{
			_haContext.CallService("vacuum", "set_fan_speed", target, new
			{
			@fan_speed = @fanSpeed
			}

			);
		}

		public void Start(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start", target);
		}

		public void StartPause(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "start_pause", target);
		}

		public void Stop(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "stop", target);
		}

		public void Toggle()
		{
			_haContext.CallService("vacuum", "toggle", null);
		}

		public void TurnOff(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_off", target);
		}

		public void TurnOn(NetDaemon.HassModel.Entities.ServiceTarget target)
		{
			_haContext.CallService("vacuum", "turn_on", target);
		}
	}

	public record VacuumSendCommandParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("command")]
		public string? Command { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("params")]
		public object? Params { get; init; }
	}

	public record VacuumSetFanSpeedParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("fanSpeed")]
		public string? FanSpeed { get; init; }
	}

	public class YeelightServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public YeelightServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void SetAutoDelayOffScene(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetAutoDelayOffSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_auto_delay_off_scene", target, data);
		}

		public void SetAutoDelayOffScene(NetDaemon.HassModel.Entities.ServiceTarget target, long? @minutes = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_auto_delay_off_scene", target, new
			{
			@minutes, @brightness
			}

			);
		}

		public void SetColorFlowScene(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetColorFlowSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_flow_scene", target, data);
		}

		public void SetColorFlowScene(NetDaemon.HassModel.Entities.ServiceTarget target, long? @count = null, string? @action = null, object? @transitions = null)
		{
			_haContext.CallService("yeelight", "set_color_flow_scene", target, new
			{
			@count, @action, @transitions
			}

			);
		}

		public void SetColorScene(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetColorSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_scene", target, data);
		}

		public void SetColorScene(NetDaemon.HassModel.Entities.ServiceTarget target, object? @rgbColor = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_color_scene", target, new
			{
			@rgb_color = @rgbColor, @brightness
			}

			);
		}

		public void SetColorTempScene(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetColorTempSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_color_temp_scene", target, data);
		}

		public void SetColorTempScene(NetDaemon.HassModel.Entities.ServiceTarget target, long? @kelvin = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_color_temp_scene", target, new
			{
			@kelvin, @brightness
			}

			);
		}

		public void SetHsvScene(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetHsvSceneParameters data)
		{
			_haContext.CallService("yeelight", "set_hsv_scene", target, data);
		}

		public void SetHsvScene(NetDaemon.HassModel.Entities.ServiceTarget target, object? @hsColor = null, long? @brightness = null)
		{
			_haContext.CallService("yeelight", "set_hsv_scene", target, new
			{
			@hs_color = @hsColor, @brightness
			}

			);
		}

		public void SetMode(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetModeParameters data)
		{
			_haContext.CallService("yeelight", "set_mode", target, data);
		}

		public void SetMode(NetDaemon.HassModel.Entities.ServiceTarget target, string @mode)
		{
			_haContext.CallService("yeelight", "set_mode", target, new
			{
			@mode
			}

			);
		}

		public void SetMusicMode(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightSetMusicModeParameters data)
		{
			_haContext.CallService("yeelight", "set_music_mode", target, data);
		}

		public void SetMusicMode(NetDaemon.HassModel.Entities.ServiceTarget target, bool @musicMode)
		{
			_haContext.CallService("yeelight", "set_music_mode", target, new
			{
			@music_mode = @musicMode
			}

			);
		}

		public void StartFlow(NetDaemon.HassModel.Entities.ServiceTarget target, YeelightStartFlowParameters data)
		{
			_haContext.CallService("yeelight", "start_flow", target, data);
		}

		public void StartFlow(NetDaemon.HassModel.Entities.ServiceTarget target, long? @count = null, string? @action = null, object? @transitions = null)
		{
			_haContext.CallService("yeelight", "start_flow", target, new
			{
			@count, @action, @transitions
			}

			);
		}
	}

	public record YeelightSetAutoDelayOffSceneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("minutes")]
		public long? Minutes { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetColorFlowSceneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("count")]
		public long? Count { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("action")]
		public string? Action { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("transitions")]
		public object? Transitions { get; init; }
	}

	public record YeelightSetColorSceneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("rgbColor")]
		public object? RgbColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetColorTempSceneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("kelvin")]
		public long? Kelvin { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetHsvSceneParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("hsColor")]
		public object? HsColor { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("brightness")]
		public long? Brightness { get; init; }
	}

	public record YeelightSetModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("mode")]
		public string? Mode { get; init; }
	}

	public record YeelightSetMusicModeParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("musicMode")]
		public bool? MusicMode { get; init; }
	}

	public record YeelightStartFlowParameters
	{
		[System.Text.Json.Serialization.JsonPropertyName("count")]
		public long? Count { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("action")]
		public string? Action { get; init; }

		[System.Text.Json.Serialization.JsonPropertyName("transitions")]
		public object? Transitions { get; init; }
	}

	public class ZoneServices
	{
		private readonly NetDaemon.HassModel.Common.IHaContext _haContext;
		public ZoneServices(NetDaemon.HassModel.Common.IHaContext haContext)
		{
			_haContext = haContext;
		}

		public void Reload()
		{
			_haContext.CallService("zone", "reload", null);
		}
	}

	public static class AlarmControlPanelEntityExtensionMethods
	{
		public static void AlarmArmAway(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmArmAwayParameters data)
		{
			entity.CallService("alarm_arm_away", data);
		}

		public static void AlarmArmAway(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_arm_away", new
			{
			@code
			}

			);
		}

		public static void AlarmArmCustomBypass(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmArmCustomBypassParameters data)
		{
			entity.CallService("alarm_arm_custom_bypass", data);
		}

		public static void AlarmArmCustomBypass(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_arm_custom_bypass", new
			{
			@code
			}

			);
		}

		public static void AlarmArmHome(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmArmHomeParameters data)
		{
			entity.CallService("alarm_arm_home", data);
		}

		public static void AlarmArmHome(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_arm_home", new
			{
			@code
			}

			);
		}

		public static void AlarmArmNight(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmArmNightParameters data)
		{
			entity.CallService("alarm_arm_night", data);
		}

		public static void AlarmArmNight(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_arm_night", new
			{
			@code
			}

			);
		}

		public static void AlarmArmVacation(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmArmVacationParameters data)
		{
			entity.CallService("alarm_arm_vacation", data);
		}

		public static void AlarmArmVacation(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_arm_vacation", new
			{
			@code
			}

			);
		}

		public static void AlarmDisarm(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmDisarmParameters data)
		{
			entity.CallService("alarm_disarm", data);
		}

		public static void AlarmDisarm(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_disarm", new
			{
			@code
			}

			);
		}

		public static void AlarmTrigger(this AlarmControlPanelEntity entity, AlarmControlPanelAlarmTriggerParameters data)
		{
			entity.CallService("alarm_trigger", data);
		}

		public static void AlarmTrigger(this AlarmControlPanelEntity entity, string? @code = null)
		{
			entity.CallService("alarm_trigger", new
			{
			@code
			}

			);
		}
	}

	public static class AutomationEntityExtensionMethods
	{
		public static void Toggle(this AutomationEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void Trigger(this AutomationEntity entity, AutomationTriggerParameters data)
		{
			entity.CallService("trigger", data);
		}

		public static void Trigger(this AutomationEntity entity, bool? @skipCondition = null)
		{
			entity.CallService("trigger", new
			{
			@skip_condition = @skipCondition
			}

			);
		}

		public static void TurnOff(this AutomationEntity entity, AutomationTurnOffParameters data)
		{
			entity.CallService("turn_off", data);
		}

		public static void TurnOff(this AutomationEntity entity, bool? @stopActions = null)
		{
			entity.CallService("turn_off", new
			{
			@stop_actions = @stopActions
			}

			);
		}

		public static void TurnOn(this AutomationEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class CameraEntityExtensionMethods
	{
		public static void DisableMotionDetection(this CameraEntity entity)
		{
			entity.CallService("disable_motion_detection");
		}

		public static void EnableMotionDetection(this CameraEntity entity)
		{
			entity.CallService("enable_motion_detection");
		}

		public static void PlayStream(this CameraEntity entity, CameraPlayStreamParameters data)
		{
			entity.CallService("play_stream", data);
		}

		public static void PlayStream(this CameraEntity entity, string @mediaPlayer, string? @format = null)
		{
			entity.CallService("play_stream", new
			{
			@media_player = @mediaPlayer, @format
			}

			);
		}

		public static void Record(this CameraEntity entity, CameraRecordParameters data)
		{
			entity.CallService("record", data);
		}

		public static void Record(this CameraEntity entity, string @filename, long? @duration = null, long? @lookback = null)
		{
			entity.CallService("record", new
			{
			@filename, @duration, @lookback
			}

			);
		}

		public static void Snapshot(this CameraEntity entity, CameraSnapshotParameters data)
		{
			entity.CallService("snapshot", data);
		}

		public static void Snapshot(this CameraEntity entity, string @filename)
		{
			entity.CallService("snapshot", new
			{
			@filename
			}

			);
		}

		public static void TurnOff(this CameraEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this CameraEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class ClimateEntityExtensionMethods
	{
		public static void SetAuxHeat(this ClimateEntity entity, ClimateSetAuxHeatParameters data)
		{
			entity.CallService("set_aux_heat", data);
		}

		public static void SetAuxHeat(this ClimateEntity entity, bool @auxHeat)
		{
			entity.CallService("set_aux_heat", new
			{
			@aux_heat = @auxHeat
			}

			);
		}

		public static void SetFanMode(this ClimateEntity entity, ClimateSetFanModeParameters data)
		{
			entity.CallService("set_fan_mode", data);
		}

		public static void SetFanMode(this ClimateEntity entity, string @fanMode)
		{
			entity.CallService("set_fan_mode", new
			{
			@fan_mode = @fanMode
			}

			);
		}

		public static void SetHumidity(this ClimateEntity entity, ClimateSetHumidityParameters data)
		{
			entity.CallService("set_humidity", data);
		}

		public static void SetHumidity(this ClimateEntity entity, long @humidity)
		{
			entity.CallService("set_humidity", new
			{
			@humidity
			}

			);
		}

		public static void SetHvacMode(this ClimateEntity entity, ClimateSetHvacModeParameters data)
		{
			entity.CallService("set_hvac_mode", data);
		}

		public static void SetHvacMode(this ClimateEntity entity, string? @hvacMode = null)
		{
			entity.CallService("set_hvac_mode", new
			{
			@hvac_mode = @hvacMode
			}

			);
		}

		public static void SetPresetMode(this ClimateEntity entity, ClimateSetPresetModeParameters data)
		{
			entity.CallService("set_preset_mode", data);
		}

		public static void SetPresetMode(this ClimateEntity entity, string @presetMode)
		{
			entity.CallService("set_preset_mode", new
			{
			@preset_mode = @presetMode
			}

			);
		}

		public static void SetSwingMode(this ClimateEntity entity, ClimateSetSwingModeParameters data)
		{
			entity.CallService("set_swing_mode", data);
		}

		public static void SetSwingMode(this ClimateEntity entity, string @swingMode)
		{
			entity.CallService("set_swing_mode", new
			{
			@swing_mode = @swingMode
			}

			);
		}

		public static void SetTemperature(this ClimateEntity entity, ClimateSetTemperatureParameters data)
		{
			entity.CallService("set_temperature", data);
		}

		public static void SetTemperature(this ClimateEntity entity, double? @temperature = null, double? @targetTempHigh = null, double? @targetTempLow = null, string? @hvacMode = null)
		{
			entity.CallService("set_temperature", new
			{
			@temperature, @target_temp_high = @targetTempHigh, @target_temp_low = @targetTempLow, @hvac_mode = @hvacMode
			}

			);
		}

		public static void TurnOff(this ClimateEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this ClimateEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class FanEntityExtensionMethods
	{
		public static void DecreaseSpeed(this FanEntity entity, FanDecreaseSpeedParameters data)
		{
			entity.CallService("decrease_speed", data);
		}

		public static void DecreaseSpeed(this FanEntity entity, long? @percentageStep = null)
		{
			entity.CallService("decrease_speed", new
			{
			@percentage_step = @percentageStep
			}

			);
		}

		public static void IncreaseSpeed(this FanEntity entity, FanIncreaseSpeedParameters data)
		{
			entity.CallService("increase_speed", data);
		}

		public static void IncreaseSpeed(this FanEntity entity, long? @percentageStep = null)
		{
			entity.CallService("increase_speed", new
			{
			@percentage_step = @percentageStep
			}

			);
		}

		public static void Oscillate(this FanEntity entity, FanOscillateParameters data)
		{
			entity.CallService("oscillate", data);
		}

		public static void Oscillate(this FanEntity entity, bool @oscillating)
		{
			entity.CallService("oscillate", new
			{
			@oscillating
			}

			);
		}

		public static void SetDirection(this FanEntity entity, FanSetDirectionParameters data)
		{
			entity.CallService("set_direction", data);
		}

		public static void SetDirection(this FanEntity entity, string @direction)
		{
			entity.CallService("set_direction", new
			{
			@direction
			}

			);
		}

		public static void SetPercentage(this FanEntity entity, FanSetPercentageParameters data)
		{
			entity.CallService("set_percentage", data);
		}

		public static void SetPercentage(this FanEntity entity, long @percentage)
		{
			entity.CallService("set_percentage", new
			{
			@percentage
			}

			);
		}

		public static void SetPresetMode(this FanEntity entity, FanSetPresetModeParameters data)
		{
			entity.CallService("set_preset_mode", data);
		}

		public static void SetPresetMode(this FanEntity entity, string @presetMode)
		{
			entity.CallService("set_preset_mode", new
			{
			@preset_mode = @presetMode
			}

			);
		}

		public static void SetSpeed(this FanEntity entity, FanSetSpeedParameters data)
		{
			entity.CallService("set_speed", data);
		}

		public static void SetSpeed(this FanEntity entity, string @speed)
		{
			entity.CallService("set_speed", new
			{
			@speed
			}

			);
		}

		public static void Toggle(this FanEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void TurnOff(this FanEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this FanEntity entity, FanTurnOnParameters data)
		{
			entity.CallService("turn_on", data);
		}

		public static void TurnOn(this FanEntity entity, string? @speed = null, long? @percentage = null, string? @presetMode = null)
		{
			entity.CallService("turn_on", new
			{
			@speed, @percentage, @preset_mode = @presetMode
			}

			);
		}
	}

	public static class InputBooleanEntityExtensionMethods
	{
		public static void Toggle(this InputBooleanEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void TurnOff(this InputBooleanEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this InputBooleanEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class InputSelectEntityExtensionMethods
	{
		public static void SelectFirst(this InputSelectEntity entity)
		{
			entity.CallService("select_first");
		}

		public static void SelectLast(this InputSelectEntity entity)
		{
			entity.CallService("select_last");
		}

		public static void SelectNext(this InputSelectEntity entity, InputSelectSelectNextParameters data)
		{
			entity.CallService("select_next", data);
		}

		public static void SelectNext(this InputSelectEntity entity, bool? @cycle = null)
		{
			entity.CallService("select_next", new
			{
			@cycle
			}

			);
		}

		public static void SelectOption(this InputSelectEntity entity, InputSelectSelectOptionParameters data)
		{
			entity.CallService("select_option", data);
		}

		public static void SelectOption(this InputSelectEntity entity, string @option)
		{
			entity.CallService("select_option", new
			{
			@option
			}

			);
		}

		public static void SelectPrevious(this InputSelectEntity entity, InputSelectSelectPreviousParameters data)
		{
			entity.CallService("select_previous", data);
		}

		public static void SelectPrevious(this InputSelectEntity entity, bool? @cycle = null)
		{
			entity.CallService("select_previous", new
			{
			@cycle
			}

			);
		}

		public static void SetOptions(this InputSelectEntity entity, InputSelectSetOptionsParameters data)
		{
			entity.CallService("set_options", data);
		}

		public static void SetOptions(this InputSelectEntity entity, object @options)
		{
			entity.CallService("set_options", new
			{
			@options
			}

			);
		}
	}

	public static class LightEntityExtensionMethods
	{
		public static void Toggle(this LightEntity entity, LightToggleParameters data)
		{
			entity.CallService("toggle", data);
		}

		public static void Toggle(this LightEntity entity, long? @transition = null, object? @rgbColor = null, string? @colorName = null, object? @hsColor = null, object? @xyColor = null, long? @colorTemp = null, long? @kelvin = null, long? @whiteValue = null, long? @brightness = null, long? @brightnessPct = null, string? @profile = null, string? @flash = null, string? @effect = null)
		{
			entity.CallService("toggle", new
			{
			@transition, @rgb_color = @rgbColor, @color_name = @colorName, @hs_color = @hsColor, @xy_color = @xyColor, @color_temp = @colorTemp, @kelvin, @white_value = @whiteValue, @brightness, @brightness_pct = @brightnessPct, @profile, @flash, @effect
			}

			);
		}

		public static void TurnOff(this LightEntity entity, LightTurnOffParameters data)
		{
			entity.CallService("turn_off", data);
		}

		public static void TurnOff(this LightEntity entity, long? @transition = null, string? @flash = null)
		{
			entity.CallService("turn_off", new
			{
			@transition, @flash
			}

			);
		}

		public static void TurnOn(this LightEntity entity, LightTurnOnParameters data)
		{
			entity.CallService("turn_on", data);
		}

		public static void TurnOn(this LightEntity entity, long? @transition = null, object? @rgbColor = null, object? @rgbwColor = null, object? @rgbwwColor = null, string? @colorName = null, object? @hsColor = null, object? @xyColor = null, long? @colorTemp = null, long? @kelvin = null, long? @brightness = null, long? @brightnessPct = null, long? @brightnessStep = null, long? @brightnessStepPct = null, long? @white = null, string? @profile = null, string? @flash = null, string? @effect = null)
		{
			entity.CallService("turn_on", new
			{
			@transition, @rgb_color = @rgbColor, @rgbw_color = @rgbwColor, @rgbww_color = @rgbwwColor, @color_name = @colorName, @hs_color = @hsColor, @xy_color = @xyColor, @color_temp = @colorTemp, @kelvin, @brightness, @brightness_pct = @brightnessPct, @brightness_step = @brightnessStep, @brightness_step_pct = @brightnessStepPct, @white, @profile, @flash, @effect
			}

			);
		}
	}

	public static class MediaPlayerEntityExtensionMethods
	{
		public static void ClearPlaylist(this MediaPlayerEntity entity)
		{
			entity.CallService("clear_playlist");
		}

		public static void Join(this MediaPlayerEntity entity, MediaPlayerJoinParameters data)
		{
			entity.CallService("join", data);
		}

		public static void Join(this MediaPlayerEntity entity, object? @groupMembers = null)
		{
			entity.CallService("join", new
			{
			@group_members = @groupMembers
			}

			);
		}

		public static void MediaNextTrack(this MediaPlayerEntity entity)
		{
			entity.CallService("media_next_track");
		}

		public static void MediaPause(this MediaPlayerEntity entity)
		{
			entity.CallService("media_pause");
		}

		public static void MediaPlay(this MediaPlayerEntity entity)
		{
			entity.CallService("media_play");
		}

		public static void MediaPlayPause(this MediaPlayerEntity entity)
		{
			entity.CallService("media_play_pause");
		}

		public static void MediaPreviousTrack(this MediaPlayerEntity entity)
		{
			entity.CallService("media_previous_track");
		}

		public static void MediaSeek(this MediaPlayerEntity entity, MediaPlayerMediaSeekParameters data)
		{
			entity.CallService("media_seek", data);
		}

		public static void MediaSeek(this MediaPlayerEntity entity, double @seekPosition)
		{
			entity.CallService("media_seek", new
			{
			@seek_position = @seekPosition
			}

			);
		}

		public static void MediaStop(this MediaPlayerEntity entity)
		{
			entity.CallService("media_stop");
		}

		public static void PlayMedia(this MediaPlayerEntity entity, MediaPlayerPlayMediaParameters data)
		{
			entity.CallService("play_media", data);
		}

		public static void PlayMedia(this MediaPlayerEntity entity, string @mediaContentId, string @mediaContentType)
		{
			entity.CallService("play_media", new
			{
			@media_content_id = @mediaContentId, @media_content_type = @mediaContentType
			}

			);
		}

		public static void RepeatSet(this MediaPlayerEntity entity, MediaPlayerRepeatSetParameters data)
		{
			entity.CallService("repeat_set", data);
		}

		public static void RepeatSet(this MediaPlayerEntity entity, string @repeat)
		{
			entity.CallService("repeat_set", new
			{
			@repeat
			}

			);
		}

		public static void SelectSoundMode(this MediaPlayerEntity entity, MediaPlayerSelectSoundModeParameters data)
		{
			entity.CallService("select_sound_mode", data);
		}

		public static void SelectSoundMode(this MediaPlayerEntity entity, string? @soundMode = null)
		{
			entity.CallService("select_sound_mode", new
			{
			@sound_mode = @soundMode
			}

			);
		}

		public static void SelectSource(this MediaPlayerEntity entity, MediaPlayerSelectSourceParameters data)
		{
			entity.CallService("select_source", data);
		}

		public static void SelectSource(this MediaPlayerEntity entity, string @source)
		{
			entity.CallService("select_source", new
			{
			@source
			}

			);
		}

		public static void ShuffleSet(this MediaPlayerEntity entity, MediaPlayerShuffleSetParameters data)
		{
			entity.CallService("shuffle_set", data);
		}

		public static void ShuffleSet(this MediaPlayerEntity entity, bool @shuffle)
		{
			entity.CallService("shuffle_set", new
			{
			@shuffle
			}

			);
		}

		public static void Toggle(this MediaPlayerEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void TurnOff(this MediaPlayerEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this MediaPlayerEntity entity)
		{
			entity.CallService("turn_on");
		}

		public static void Unjoin(this MediaPlayerEntity entity)
		{
			entity.CallService("unjoin");
		}

		public static void VolumeDown(this MediaPlayerEntity entity)
		{
			entity.CallService("volume_down");
		}

		public static void VolumeMute(this MediaPlayerEntity entity, MediaPlayerVolumeMuteParameters data)
		{
			entity.CallService("volume_mute", data);
		}

		public static void VolumeMute(this MediaPlayerEntity entity, bool @isVolumeMuted)
		{
			entity.CallService("volume_mute", new
			{
			@is_volume_muted = @isVolumeMuted
			}

			);
		}

		public static void VolumeSet(this MediaPlayerEntity entity, MediaPlayerVolumeSetParameters data)
		{
			entity.CallService("volume_set", data);
		}

		public static void VolumeSet(this MediaPlayerEntity entity, double @volumeLevel)
		{
			entity.CallService("volume_set", new
			{
			@volume_level = @volumeLevel
			}

			);
		}

		public static void VolumeUp(this MediaPlayerEntity entity)
		{
			entity.CallService("volume_up");
		}
	}

	public static class NeatoEntityExtensionMethods
	{
		public static void CustomCleaning(this VacuumEntity entity, NeatoCustomCleaningParameters data)
		{
			entity.CallService("custom_cleaning", data);
		}

		public static void CustomCleaning(this VacuumEntity entity, long? @mode = null, long? @navigation = null, long? @category = null, string? @zone = null)
		{
			entity.CallService("custom_cleaning", new
			{
			@mode, @navigation, @category, @zone
			}

			);
		}
	}

	public static class NumberEntityExtensionMethods
	{
		public static void SetValue(this NumberEntity entity, NumberSetValueParameters data)
		{
			entity.CallService("set_value", data);
		}

		public static void SetValue(this NumberEntity entity, string? @value = null)
		{
			entity.CallService("set_value", new
			{
			@value
			}

			);
		}
	}

	public static class OnvifEntityExtensionMethods
	{
		public static void Ptz(this CameraEntity entity, OnvifPtzParameters data)
		{
			entity.CallService("ptz", data);
		}

		public static void Ptz(this CameraEntity entity, string? @tilt = null, string? @pan = null, string? @zoom = null, double? @distance = null, double? @speed = null, double? @continuousDuration = null, string? @preset = null, string? @moveMode = null)
		{
			entity.CallService("ptz", new
			{
			@tilt, @pan, @zoom, @distance, @speed, @continuous_duration = @continuousDuration, @preset, @move_mode = @moveMode
			}

			);
		}
	}

	public static class SceneEntityExtensionMethods
	{
		public static void TurnOn(this SceneEntity entity, SceneTurnOnParameters data)
		{
			entity.CallService("turn_on", data);
		}

		public static void TurnOn(this SceneEntity entity, long? @transition = null)
		{
			entity.CallService("turn_on", new
			{
			@transition
			}

			);
		}
	}

	public static class ScriptEntityExtensionMethods
	{
		public static void Toggle(this ScriptEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void TurnOff(this ScriptEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this ScriptEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class SelectEntityExtensionMethods
	{
		public static void SelectOption(this SelectEntity entity, SelectSelectOptionParameters data)
		{
			entity.CallService("select_option", data);
		}

		public static void SelectOption(this SelectEntity entity, string @option)
		{
			entity.CallService("select_option", new
			{
			@option
			}

			);
		}
	}

	public static class SqueezeboxEntityExtensionMethods
	{
		public static void CallMethod(this MediaPlayerEntity entity, SqueezeboxCallMethodParameters data)
		{
			entity.CallService("call_method", data);
		}

		public static void CallMethod(this MediaPlayerEntity entity, string @command, object? @parameters = null)
		{
			entity.CallService("call_method", new
			{
			@command, @parameters
			}

			);
		}

		public static void CallQuery(this MediaPlayerEntity entity, SqueezeboxCallQueryParameters data)
		{
			entity.CallService("call_query", data);
		}

		public static void CallQuery(this MediaPlayerEntity entity, string @command, object? @parameters = null)
		{
			entity.CallService("call_query", new
			{
			@command, @parameters
			}

			);
		}

		public static void Sync(this MediaPlayerEntity entity, SqueezeboxSyncParameters data)
		{
			entity.CallService("sync", data);
		}

		public static void Sync(this MediaPlayerEntity entity, string @otherPlayer)
		{
			entity.CallService("sync", new
			{
			@other_player = @otherPlayer
			}

			);
		}

		public static void Unsync(this MediaPlayerEntity entity)
		{
			entity.CallService("unsync");
		}
	}

	public static class SwitchEntityExtensionMethods
	{
		public static void Toggle(this SwitchEntity entity)
		{
			entity.CallService("toggle");
		}

		public static void TurnOff(this SwitchEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this SwitchEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class TimerEntityExtensionMethods
	{
		public static void Cancel(this TimerEntity entity)
		{
			entity.CallService("cancel");
		}

		public static void Finish(this TimerEntity entity)
		{
			entity.CallService("finish");
		}

		public static void Pause(this TimerEntity entity)
		{
			entity.CallService("pause");
		}

		public static void Start(this TimerEntity entity, TimerStartParameters data)
		{
			entity.CallService("start", data);
		}

		public static void Start(this TimerEntity entity, string? @duration = null)
		{
			entity.CallService("start", new
			{
			@duration
			}

			);
		}
	}

	public static class VacuumEntityExtensionMethods
	{
		public static void CleanSpot(this VacuumEntity entity)
		{
			entity.CallService("clean_spot");
		}

		public static void Locate(this VacuumEntity entity)
		{
			entity.CallService("locate");
		}

		public static void Pause(this VacuumEntity entity)
		{
			entity.CallService("pause");
		}

		public static void ReturnToBase(this VacuumEntity entity)
		{
			entity.CallService("return_to_base");
		}

		public static void SendCommand(this VacuumEntity entity, VacuumSendCommandParameters data)
		{
			entity.CallService("send_command", data);
		}

		public static void SendCommand(this VacuumEntity entity, string @command, object? @params = null)
		{
			entity.CallService("send_command", new
			{
			@command, @params
			}

			);
		}

		public static void SetFanSpeed(this VacuumEntity entity, VacuumSetFanSpeedParameters data)
		{
			entity.CallService("set_fan_speed", data);
		}

		public static void SetFanSpeed(this VacuumEntity entity, string @fanSpeed)
		{
			entity.CallService("set_fan_speed", new
			{
			@fan_speed = @fanSpeed
			}

			);
		}

		public static void Start(this VacuumEntity entity)
		{
			entity.CallService("start");
		}

		public static void StartPause(this VacuumEntity entity)
		{
			entity.CallService("start_pause");
		}

		public static void Stop(this VacuumEntity entity)
		{
			entity.CallService("stop");
		}

		public static void TurnOff(this VacuumEntity entity)
		{
			entity.CallService("turn_off");
		}

		public static void TurnOn(this VacuumEntity entity)
		{
			entity.CallService("turn_on");
		}
	}

	public static class YeelightEntityExtensionMethods
	{
		public static void SetAutoDelayOffScene(this LightEntity entity, YeelightSetAutoDelayOffSceneParameters data)
		{
			entity.CallService("set_auto_delay_off_scene", data);
		}

		public static void SetAutoDelayOffScene(this LightEntity entity, long? @minutes = null, long? @brightness = null)
		{
			entity.CallService("set_auto_delay_off_scene", new
			{
			@minutes, @brightness
			}

			);
		}

		public static void SetColorFlowScene(this LightEntity entity, YeelightSetColorFlowSceneParameters data)
		{
			entity.CallService("set_color_flow_scene", data);
		}

		public static void SetColorFlowScene(this LightEntity entity, long? @count = null, string? @action = null, object? @transitions = null)
		{
			entity.CallService("set_color_flow_scene", new
			{
			@count, @action, @transitions
			}

			);
		}

		public static void SetColorScene(this LightEntity entity, YeelightSetColorSceneParameters data)
		{
			entity.CallService("set_color_scene", data);
		}

		public static void SetColorScene(this LightEntity entity, object? @rgbColor = null, long? @brightness = null)
		{
			entity.CallService("set_color_scene", new
			{
			@rgb_color = @rgbColor, @brightness
			}

			);
		}

		public static void SetColorTempScene(this LightEntity entity, YeelightSetColorTempSceneParameters data)
		{
			entity.CallService("set_color_temp_scene", data);
		}

		public static void SetColorTempScene(this LightEntity entity, long? @kelvin = null, long? @brightness = null)
		{
			entity.CallService("set_color_temp_scene", new
			{
			@kelvin, @brightness
			}

			);
		}

		public static void SetHsvScene(this LightEntity entity, YeelightSetHsvSceneParameters data)
		{
			entity.CallService("set_hsv_scene", data);
		}

		public static void SetHsvScene(this LightEntity entity, object? @hsColor = null, long? @brightness = null)
		{
			entity.CallService("set_hsv_scene", new
			{
			@hs_color = @hsColor, @brightness
			}

			);
		}

		public static void SetMode(this LightEntity entity, YeelightSetModeParameters data)
		{
			entity.CallService("set_mode", data);
		}

		public static void SetMode(this LightEntity entity, string @mode)
		{
			entity.CallService("set_mode", new
			{
			@mode
			}

			);
		}

		public static void SetMusicMode(this LightEntity entity, YeelightSetMusicModeParameters data)
		{
			entity.CallService("set_music_mode", data);
		}

		public static void SetMusicMode(this LightEntity entity, bool @musicMode)
		{
			entity.CallService("set_music_mode", new
			{
			@music_mode = @musicMode
			}

			);
		}

		public static void StartFlow(this LightEntity entity, YeelightStartFlowParameters data)
		{
			entity.CallService("start_flow", data);
		}

		public static void StartFlow(this LightEntity entity, long? @count = null, string? @action = null, object? @transitions = null)
		{
			entity.CallService("start_flow", new
			{
			@count, @action, @transitions
			}

			);
		}
	}
}