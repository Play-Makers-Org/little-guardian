using UnityEngine;

public class NewWaveManager : MonoBehaviour
{
    private enum WaveStatus
    {
        CHANGING,
        SPAWNING,
    }

    [System.Serializable]
    private class Wave
    {
        public string name;
        public GameObject[] enemyPrefabs;
        public float spawningRate;
    }

    [SerializeField] private Wave[] waves;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private WaveStatus _currentWaveStatus;
    private float _lastSpawnTime;

    private RandomPosGenerator _posGenerator = new RandomPosGenerator();

    public float gameTime;
    private float _waveChangeTime = 10f;
    private int _totalWaveCount = 5;
    private float _gameFinishTime;
    private bool _waveChangingLock = false;
    public int currentWaveNumber = 0;

    private void Awake()
    {
        _currentWaveStatus = WaveStatus.CHANGING;
        _totalWaveCount = waves.Length;
        _gameFinishTime = _totalWaveCount * _waveChangeTime;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (_currentWaveStatus == WaveStatus.CHANGING && !_waveChangingLock)
        {
            if (gameTime >= _gameFinishTime)
            {
                //TODO: END THE GAME
                Time.timeScale = 0;
            }

            DefineCurrentWave();

            if (currentWaveNumber != 1)
            {
                EnemyDifficultyManager.IncreaseAllEnemiesMaxHealth();
            }
        }

        if (_currentWaveStatus == WaveStatus.SPAWNING)
        {
            if (gameTime - _lastSpawnTime >= _currentWave.spawningRate)
            {
                SpawnEnemy();
            }

            if (!_waveChangingLock && Mathf.RoundToInt(gameTime % _waveChangeTime) == 0)
            {
                _currentWaveStatus = WaveStatus.CHANGING;
            }
            else if (_waveChangingLock && Mathf.RoundToInt(gameTime % _waveChangeTime) == 1)
            {
                _waveChangingLock = false;
            }
        }
    }

    private void DefineCurrentWave()
    {
        _currentWave = waves[_currentWaveIndex];
        _currentWaveIndex++;
        currentWaveNumber++;
        _waveChangingLock = true;
        _currentWaveStatus = WaveStatus.SPAWNING;
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _currentWave.enemyPrefabs.Length);

        GameObject enemyPrefab = _currentWave.enemyPrefabs[randomIndex];

        Vector3 spawnPos = _posGenerator.GenerateSpawnPos(10);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        _lastSpawnTime = gameTime;
    }
}