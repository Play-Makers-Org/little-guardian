using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private enum WaveStatus
    {
        WAITING,
        SPAWNING,
        CHANGING,
        CHECKING,
    }

    [System.Serializable]
    private class Wave
    {
        public string name;
        public GameObject[] enemyPrefabs;
        public float waitingTime;
        public float spawningRate;
        public int enemyCount;
        public int minSpawningEnemy;
        public int maxSpawningEnemy;
    }

    [SerializeField] private Wave[] waves;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    [SerializeField] private float _currentWaveWaitingTime;
    private WaveStatus _currentWaveStatus;

    private float _lastSpawnTime;

    private RandomPosGenerator _posGenerator = new RandomPosGenerator();

    private bool isWavesFinished = false;

    private void Awake()
    {
        _currentWaveStatus = WaveStatus.CHANGING;
    }

    private void Update()
    {
        if (_currentWaveStatus == WaveStatus.CHECKING)
        {
            var enemy = GameObject.FindGameObjectWithTag(TagConstants.EnemyTag);
            if (enemy == null)
            {
                _currentWaveStatus = WaveStatus.CHANGING;
            }
        }

        if (_currentWaveStatus == WaveStatus.CHANGING && !isWavesFinished)
        {
            DefineCurrentWave();
            _currentWaveStatus = WaveStatus.WAITING;
            _currentWaveWaitingTime = _currentWave.waitingTime;
        }

        if (!isWavesFinished)
        {
            if (_currentWaveStatus == WaveStatus.WAITING)
            {
                _currentWaveWaitingTime -= Time.deltaTime;
                if (_currentWaveWaitingTime <= 0)
                    _currentWaveStatus = WaveStatus.SPAWNING;
            }

            if (_currentWaveStatus == WaveStatus.SPAWNING)
            {
                if (_currentWave.enemyCount > 0)
                {
                    if (Time.time - _lastSpawnTime >= _currentWave.spawningRate)
                    {
                        var spawningEnemyCount = (int)Random.Range(_currentWave.minSpawningEnemy, _currentWave.maxSpawningEnemy + 1);
                        for (int i = 0; i < spawningEnemyCount; i++)
                        {
                            int randomIndex = (int)Random.Range(0, _currentWave.enemyPrefabs.Length);
                            GameObject enemyPrefab = _currentWave.enemyPrefabs[randomIndex];
                            Vector3 spawnPos = _posGenerator.GenerateSpawnPos(10);
                            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                        }
                        _lastSpawnTime = Time.time;
                        _currentWave.enemyCount -= spawningEnemyCount;
                    }
                }
                else
                    _currentWaveStatus = WaveStatus.CHECKING;
            }
        }
        else
        {
            // ALL waves finished
            Debug.Log("Waves finished ....");
        }
    }

    private void DefineCurrentWave()
    {
        if (_currentWaveIndex == waves.Length)
        {
            isWavesFinished = true;
            return;
        }

        _currentWave = waves[_currentWaveIndex];
        _currentWaveIndex++;
    }
}