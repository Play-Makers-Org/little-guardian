public static class RandomizedHarmfulGameEventConstants
{
    public static int minCount = 1;
    public static int maxCount = 3;
    public static float timeBetweenNextEvent = 0.5f;
    public static float nextEventTime = 0f;

    public static int lightningMinCount = minCount + 1;
    public static int lightningMaxCount = maxCount;
    public static float lightningTimeBetweenNextEvent = timeBetweenNextEvent;

    public static int meteorMinCount = minCount + 1;
    public static int meteorMaxCount = maxCount;
    public static float meteorTimeBetweenNextEvent = timeBetweenNextEvent;

    public static void GetRandomizedHarmfulEvent(RandomizedHarmfulGameEvent randomizedEvent)
    {
        if (randomizedEvent.eventPrefab.GetComponent<Lightning>() != null)
        {
            randomizedEvent.minCount = lightningMinCount;
            randomizedEvent.maxCount = lightningMaxCount;
            randomizedEvent.timeBetweenNextEvent = lightningTimeBetweenNextEvent;
            randomizedEvent.nextEventTime = nextEventTime;
        }
        else if (randomizedEvent.eventPrefab.GetComponent<Meteor>() != null)
        {
            randomizedEvent.minCount = meteorMinCount;
            randomizedEvent.maxCount = meteorMaxCount;
            randomizedEvent.timeBetweenNextEvent = meteorTimeBetweenNextEvent;
            randomizedEvent.nextEventTime = nextEventTime;
        }
    }
}