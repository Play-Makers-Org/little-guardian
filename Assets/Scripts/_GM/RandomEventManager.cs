using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    [System.Serializable]
    private class RandomEvent
    {
        public int minCount;
        public int maxCount;
        public float timeBetweenNextEvent;
        public float nextEventTime;
        public GameObject eventPrefab;
    }

    [SerializeField] private RandomEvent[] _randomEvents;
    private RandomEvent _currentEvent;

    private enum EventManagerStatus
    {
        CHANGING,
        WAITING,
        READY,
    }

    private EventManagerStatus _managerStatus;

    public float _timeBetweenEvents = 5f;
    private float _eventCooldown;
    public float _eventLength = 5f;
    private float _eventEndingTime;

    private void Start()
    {
        _managerStatus = EventManagerStatus.CHANGING;
        ResetEventCooldown();
    }

    private void Update()
    {
        switch (_managerStatus)
        {
            case EventManagerStatus.CHANGING:
                HandleRandomEventChange();
                break;

            case EventManagerStatus.WAITING:
                HandleRandomEventWaiting();
                break;

            case EventManagerStatus.READY:
                HandleRandomEventReady();
                break;
        }
    }

    private void HandleRandomEventChange()
    {
        int eventIndex = Random.RandomRange(0, _randomEvents.Length);
        _currentEvent = _randomEvents[eventIndex];
        ResetEventCooldown();
        _managerStatus = EventManagerStatus.WAITING;
    }

    private void HandleRandomEventWaiting()
    {
        _eventCooldown -= Time.deltaTime;
        if (_eventCooldown <= 0)
        {
            _eventEndingTime = Time.time + _eventLength;
            _managerStatus = EventManagerStatus.READY;
        }
    }

    private void HandleRandomEventReady()
    {
        if (Time.time >= _eventEndingTime)
        {
            _managerStatus = EventManagerStatus.CHANGING;
            return;
        }

        if (Time.time >= _currentEvent.nextEventTime)
        {
            int eventCount = Random.RandomRange(_currentEvent.minCount, _currentEvent.maxCount);
            for (int i = 0; i < eventCount; i++)
            {
                Instantiate(_currentEvent.eventPrefab);
            }
            _currentEvent.nextEventTime = Time.time + _currentEvent.timeBetweenNextEvent;
        }
    }

    private void ResetEventCooldown()
    {
        _eventCooldown = _timeBetweenEvents;
    }
}