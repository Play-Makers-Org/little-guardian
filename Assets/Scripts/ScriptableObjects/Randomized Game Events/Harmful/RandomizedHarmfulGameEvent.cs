using UnityEngine;

[CreateAssetMenu(fileName = "NewRandomizedGameEvent", menuName = "ScriptableObject/RandomizedHarmfulGameEvent")]
public class RandomizedHarmfulGameEvent : ScriptableObject
{
    public int minCount;
    public int maxCount;
    public float timeBetweenNextEvent;
    public float nextEventTime;
    public GameObject eventPrefab;
}