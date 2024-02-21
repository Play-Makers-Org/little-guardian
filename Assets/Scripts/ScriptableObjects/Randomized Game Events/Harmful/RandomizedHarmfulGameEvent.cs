using UnityEngine;

[CreateAssetMenu(fileName = "NewRandomizedGameEvent", menuName = "ScriptableObjects/RandomizedHarmfulGameEvent")]
public class RandomizedHarmfulGameEvent : ScriptableObject
{
    public int minCount;
    public int maxCount;
    public float timeBetweenNextEvent;
    public float nextEventTime;
    public GameObject eventPrefab;
}