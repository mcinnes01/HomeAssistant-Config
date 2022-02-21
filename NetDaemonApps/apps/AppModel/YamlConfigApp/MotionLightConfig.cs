

using System.Collections.Generic;

public class LightControl
{
    public List<Room> Rooms { get; set; }
}

public class Room
{
    
}

public class MotionLight
{
    public List<BinarySensorEntity> MotionSensors { get; set; }
    public LightEntity Light { get; set; }
    public bool IsAmbient { get; set; }
}