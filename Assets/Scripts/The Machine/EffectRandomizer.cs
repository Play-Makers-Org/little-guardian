using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class RandomEffect
//{
//    public float minCount;
//    public float maxCount;
//    public GameObject effectPrefab;
//}

public class EffectRandomizer : MonoBehaviour
{
    [System.Serializable]
    private class Effect
    {
        public int minCount;
        public int maxCount;
        //public float effectTime;
        public GameObject effectPrefab;
    }

    [SerializeField] private Effect[] _effects;
    private Effect _currentEffect;

    public bool isRandomizerReady = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (isRandomizerReady)
        {
            int effectIndex = Random.RandomRange(0, _effects.Length);
            _currentEffect = _effects[effectIndex];
            int effectCount = Random.RandomRange(_currentEffect.minCount, _currentEffect.maxCount);
            for (int i = 0; i < effectCount; i++)
            {
                Instantiate(_currentEffect.effectPrefab);
            }
            isRandomizerReady=false;
        }
    }
}
