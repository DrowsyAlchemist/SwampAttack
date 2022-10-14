using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private NextWaveButton _nextWaveButton;
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction<int, int> EnemyCountChanged;

    private void OnEnable()
    {
        _nextWaveButton.Clicked += OnButtonClick;
        SetWave(_currentWaveNumber);
    }

    private void OnDisable()
    {
        _nextWaveButton.Clicked -= OnButtonClick;
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            _timeAfterLastSpawn = 0;
        }
        if (_spawned >= _currentWave.Count)
        {
            _currentWave = null;
            _spawned = 0;

            if (_currentWaveNumber + 1 < _waves.Count)
                _nextWaveButton.Activate();
        }
    }

    private void InstantiateEnemy()
    {
        float verticalOffset = 0;

        if (_currentWave.Template.TryGetComponent(out Zombie zombie))
            verticalOffset = zombie.VerticalOffset;

        Vector2 position = _spawnPoint.position + new Vector3(0, verticalOffset);
        GameObject obj = Instantiate(_currentWave.Template, position, _spawnPoint.rotation, _spawnPoint);
        Enemy enemy = obj.GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Died += OnEnemyDied;
    }

    private void OnButtonClick()
    {
        SetWave(_currentWaveNumber + 1);
        _nextWaveButton.Deactivate();
    }

    private void SetWave(int number)
    {
        _currentWave = _waves[number];
        _currentWaveNumber = number;
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _target.AddMoney(enemy.Reward);
    }

    [System.Serializable]
    private class Wave
    {
        public GameObject Template;
        public float Delay;
        public int Count;
    }
}