// namespace Helpers;

// internal static class MotionHelpers
// {
//     internal static void CreateOccupancyDetection(
//         BinarySensorEntity primaryMotionSensor,
//         BinarySensorEntity[] connectedSensors,
//         InputNumberEntity timeout,
//         InputBooleanEntity occupancyOutput,
//         MediaPlayerEntity? sonosPlayer = null,
//         BinarySensorEntity? additionalSensor = null)
//     {
//         var motionSensorChanges = primaryMotionSensor.MotionSensorToOccupied(timeout, connectedSensors).StartWith(false);
//         var sonosPlaying = sonosPlayer?.StateChanges().Select(s => s.New.IsSonosPlaying()).StartWith(false) ?? Utils.SingleObservable(false);
//         var additionalSensorOn = additionalSensor?.StateChanges().Select(s => s.New.IsOn()).StartWith(false) ?? Utils.SingleObservable(false);

//         motionSensorChanges.CombineLatest(sonosPlaying, additionalSensorOn)
//             .Subscribe((occupiedStates) => occupancyOutput.Set(occupiedStates.First || occupiedStates.Second || occupiedStates.Third));
//     }
// }