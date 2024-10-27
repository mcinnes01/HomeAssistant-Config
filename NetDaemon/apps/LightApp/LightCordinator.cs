namespace NetDaemon.apps.LightApp;

public class LightCoordinator
{
    private readonly object _lock = new object();
    private string _activeLight = null;

    public bool CanTurnOn(string lightName)
    {
        lock (_lock)
        {
            if (_activeLight == null)
            {
                _activeLight = lightName;
                return true;
            }
            return _activeLight == lightName;
        }
    }

    public void TurnOff(string lightName)
    {
        lock (_lock)
        {
            if (_activeLight == lightName)
            {
                _activeLight = null;
            }
        }
    }
}