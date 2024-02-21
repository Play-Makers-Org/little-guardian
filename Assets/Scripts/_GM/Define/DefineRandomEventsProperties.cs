using UnityEngine;

public class DefineRandomEventsProperties : MonoBehaviour
{
    [SerializeField] private GameObject[] randomEventObjects;
    [SerializeField] private RandomizedHarmfulGameEvent[] randomizedHarmfulGameEvents;

    private void Awake()
    {
        foreach (var obj in randomEventObjects)
        {
            HarmfulGameEventProperties properties;
            var harmfulEvent = obj.GetComponent<HarmfulGameEvent>();
            harmfulEvent.properties = HarmfulGameEventConstants.GetEventProperties(harmfulEvent);
        }

        foreach (var randomizedHarmfulGameEvent in randomizedHarmfulGameEvents)
        {
            RandomizedHarmfulGameEventConstants.GetRandomizedHarmfulEvent(randomizedHarmfulGameEvent);
        }
    }
}