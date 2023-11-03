
public class WaspInBox
{
    private InputBooleanEntity _waspEntity;
    private List<BinarySensorEntity> _boxSensors;
    private List<BinarySensorEntity> _waspSensors;
    private int _delay;
    private string _state = "off";

    private const string STATE_WASP = "on";
    private const string STATE_NO_WASP = "off";
    private const string STATE_BOX_OPEN = "on";
    private const string STATE_BOX_CLOSED = "off";
    private const string STATE_WASP_IN_BOX = "on";
    private const string STATE_NO_WASP_IN_BOX = "off";

    public void Initialize(InputBooleanEntity waspEntity, List<BinarySensorEntity> boxSensors,
        List<BinarySensorEntity> waspSensors, int delay = 0)
    {
        _waspEntity = waspEntity;
        _boxSensors = boxSensors;
        _waspSensors = waspSensors;
        _delay = 0;

        _state = STATE_NO_WASP_IN_BOX;
        WaspInABox(STATE_BOX_OPEN, STATE_NO_WASP, _waspEntity);

        _boxSensors.Select(sensor => sensor.StateChanges()).Merge()
        .Subscribe(entityState =>
        {
            if (_delay > 0)
            {
                // STATE_NO_WASP_IN_BOX;
                _waspEntity.TurnOff();
            }
            //RunIn(WaspInABoxCallback, _delay, new { boxState = entityState.New, entity = entityState.Entity });
        });

        _waspSensors.Select(sensor => sensor.StateChanges()).Merge()
        .Subscribe(entityState =>
        {
            //RunIn(WaspInABoxCallback, 0, new { waspState = entityState.New, entity = entityState.Entity });
        });
    }


    private void WaspInABox(string boxState, string waspState, InputBooleanEntity entity)
    {
        if (waspState == STATE_WASP)
        {
            // STATE_WASP_IN_BOX
            entity.TurnOn();
        }
        if (waspState == STATE_NO_WASP && boxState == STATE_BOX_OPEN)
        {
            // STATE_NO_WASP_IN_BOX
            entity.TurnOff();
        }
        if (waspState == STATE_NO_WASP && boxState == STATE_BOX_CLOSED)
        {
            // No change in state
        }
    }
}
