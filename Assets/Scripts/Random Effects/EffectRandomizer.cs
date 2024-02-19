using UnityEngine;

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
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
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
            isRandomizerReady = false;
        }
    }
}