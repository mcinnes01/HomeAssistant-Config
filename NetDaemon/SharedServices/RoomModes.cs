using System.Collections.Generic;
using System.Linq;
using NetDaemon.HassModel.Entities;

namespace NetDaemon.SharedServices;

public class RoomModes
{
    private readonly IHaContext _haContext;

    public RoomModes(IHaContext haContext)
    {
        _haContext = haContext;

        // Subscribe to BedroomMode changes
        _haContext.Entity("select.bedroom_mode").StateChanges()
            .Subscribe(change => HandleBedroomModeChange(change.New?.State, change.Old?.State));

        // Subscribe to LocationMode changes
        _haContext.Entity("input_select.Location").StateChanges()
            .Subscribe(_ => HandleLocationModeChange());
    }

    private void HandleBedroomModeChange(string? newMode, string? oldMode)
    {
        if (newMode == "Sleeping")
        {
            var locationMode = _haContext.Entity("input_select.Location").State;
            if (locationMode != "Guest" && locationMode != "HouseSitter")
            {
                SetAllRoomModes("Sleeping");
            }
        }
        else if (newMode == "Normal")
        {
            var locationMode = _haContext.Entity("input_select.Location").State;
            if (locationMode == "Guest" || locationMode == "HouseSitter")
            {
                // Leave other bedrooms as Sleeping
                return;
            }
            SetAllRoomModes("Normal");
        }
    }

    private void HandleLocationModeChange()
    {
        // Re-evaluate BedroomMode logic when LocationMode changes
        var bedroomMode = _haContext.Entity("select.bedroom_mode").State;
        HandleBedroomModeChange(bedroomMode, null);
    }

    private void SetAllRoomModes(string mode)
    {
        // List of all room mode entities
        var roomEntities = new List<string>
        {
            "select.basement_hall_mode",
            "select.bathroom_mode",
            "select.bedroom_mode",
            "select.dining_room_mode",
            "select.drawing_room_mode",
            "select.dressing_room_mode",
            "select.electric_cabinet_mode",
            "select.garden_mode",
            "select.guest_room_mode",
            "select.hallway_mode",
            "select.kitchen_mode",
            "select.landing_mode",
            "select.lounge_mode",
            "select.porch_mode",
            "select.shed_mode",
            "select.snug_mode",
            "select.studio_mode",
            "select.toilet_mode",
            "select.utility_room_mode"
        };

        foreach (var entityId in roomEntities)
        {
            var entity = new SelectEntity(_haContext, entityId);
            if (entityId == "select.bedroom_mode" || entityId == "select.guest_room_mode")
            {
                // Skip bedrooms if LocationMode is Guest or HouseSitter
                var locationMode = _haContext.Entity("input_select.Location").State;
                if (locationMode == "Guest" || locationMode == "HouseSitter")
                    continue;
            }
            entity.SelectOption(mode);
        }
    }
}
