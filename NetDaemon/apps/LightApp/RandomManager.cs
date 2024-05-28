namespace LightManagerV2;

public interface IRandomManager
{
    SwitchEntity RandomSwitchEntity { get; }
    TimeSpan RandomDelay { get; set; }
    void Init(LightEntity entity, IEnumerable<string> randomStates);
    void Init(IEnumerable<LightEntity> entities, IEnumerable<string> randomStates);
    void StartQueue();
    void StopQueue();
}

public class RandomManager : IRandomManager
{
    private readonly ILogger<RandomManager>                                                        _logger;
    private readonly TimeSpan                                                                      _max;
    private readonly TimeSpan                                                                      _min;
    private readonly Random                                                                        _random;
    private readonly bool                                                                          _randomizeList;
    private readonly List<(IEnumerable<LightEntity> _entities, IEnumerable<string> _randomStates)> _rooms = new();
    private readonly IScheduler                                                                    _scheduler;
    private          List<LightEntity>                                                             _currentEntities;
    private          CancellationToken                                                             _token;
    private          CancellationTokenSource                                                       _tokenSource;

    public RandomManager(IScheduler scheduler, SwitchEntity randomSwitchEntity, string min, string max, ILogger<RandomManager> logger, bool randomizeList = true)
    {
        _random            = new Random((int)DateTime.Now.Ticks);
        RandomSwitchEntity = randomSwitchEntity;
        _scheduler         = scheduler;
        _logger            = logger;
        _randomizeList     = randomizeList;
        _min               = TimeSpan.Parse(min);
        _max               = TimeSpan.Parse(max);
        SubscribeRandomModeEvent();
    }

    public void Init(LightEntity entity, IEnumerable<string> randomStates)
    {
        Init(new List<LightEntity> { entity }, randomStates);
    }

    public void Init(IEnumerable<LightEntity> entities, IEnumerable<string> randomStates)
    {
        _rooms.Add(( entities, randomStates ));
    }

    public TimeSpan RandomDelay { get; set; }

    public SwitchEntity RandomSwitchEntity { get; }

    public async void StartQueue()
    {
        _tokenSource = new CancellationTokenSource();
        _token       = _tokenSource.Token;

        while (!_token.IsCancellationRequested)
        {
            _logger.LogInformation("Building Queue");
            var queue                 = _randomizeList ? _rooms.OrderBy(o => _random.Next()).ToList() : _rooms;
            var entities_randomStates = queue.Where(t => t._randomStates.Contains(RandomSwitchEntity.State)).ToList();
            _logger.LogInformation("Random entities enabled: {entities}", string.Join("\n", entities_randomStates.SelectMany(tuple => tuple._entities.Select(e => e.EntityId))));
            foreach (var tuple in entities_randomStates)
            {
                _currentEntities = tuple._entities.ToList();
                SetRandomDuration();

                foreach (var entity in _currentEntities) entity.TurnOn();
                _logger.LogInformation("Turned On '{entities}' for {randomDuration:T} expiring at {expiry:T}", string.Join(",", _currentEntities.Select(e => e.EntityId)), RandomDelay, DateTime.Now + RandomDelay);

                try
                {
                    await _scheduler.Sleep(RandomDelay, _token);
                }
                catch (Exception e)
                {
                }

                foreach (var entity in _currentEntities) entity.TurnOff();
                _logger.LogInformation("Turned Off '{entities}'", string.Join(",", _currentEntities.Select(e => e.EntityId)));
                if (_token.IsCancellationRequested) return;
            }
        }
    }

    public void StopQueue()
    {
        _tokenSource?.Cancel();
    }

    private void SetRandomDuration() => RandomDelay = TimeSpan.FromMilliseconds(_random.Next((int)_min.TotalMilliseconds, (int)_max.TotalMilliseconds));

    private void SubscribeRandomModeEvent()
    {
        _logger.LogInformation("Subscribed to Random Mode Changed Events");
        RandomSwitchEntity?.StateChanges().Subscribe(e =>
        {
            _logger.LogInformation("Random Mode Changed");
            if (_rooms.Any(t => t._randomStates.Contains(RandomSwitchEntity.State))) StartQueue();
            else StopQueue();
        });
    }
}