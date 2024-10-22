using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem Instance;
    public int currentWave;
    public List<Wave> waves;
    public Transform waveParent;

    public GameObject movingEnemyPrefab,
        shootingEnemyPrefab;
    private bool _waveStillSpawning;

    private void Start()
    {
        // testing
        InstanceManager();
        SpawnNewWave();
    }

    private void InstanceManager()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void SpawnNewWave()
    {
        if (waveParent.childCount > 0 || currentWave >= waves.Count || _waveStillSpawning)
            return;
        var wave = waves[currentWave];
        StartCoroutine(SpawnWave(wave));
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        _waveStillSpawning = true;
        foreach (var enemyGroup in wave.enemyGroups)
        {
            SpawnEnemyGroup(enemyGroup);
            yield return new WaitForSeconds(enemyGroup.timeUntilNextGroup);
        }
        currentWave++;
        _waveStillSpawning = false;
    }

    private void SpawnEnemyGroup(EnemyGroup enemyGroup)
    {
        foreach (var enemy in enemyGroup.enemies)
            SpawnEnemy(enemy);
    }

    private void SpawnEnemy(Enemy enemy)
    {
        switch (enemy.enemyType)
        {
            case EnemyType.MovingToPlayer:
                MovingEnemy(enemy, true);
                break;
            case EnemyType.MovingWrappingScreen:
                MovingEnemy(enemy);
                break;
            case EnemyType.ShootingToPlayer:
                ShootingEnemy(enemy, true);
                break;
            case EnemyType.ShootingToDirection:
                ShootingEnemy(enemy);
                break;
        }
    }

    private void MovingEnemy(Enemy enemy, bool moveToPlayer = false)
    {
        var newEnemy = Instantiate(
                movingEnemyPrefab,
                enemy.spawnPosition,
                Quaternion.identity,
                waveParent
            )
            .GetComponent<MovingEnemy>();
        newEnemy.moveToPlayer = moveToPlayer;
        StartCoroutine(newEnemy.SetupEnemy(enemy));
    }

    private void ShootingEnemy(Enemy enemy, bool shootToPlayer = false) { }
}

[Serializable]
public class Wave
{
    public string name; // debugging and maybe for the player to see
    public List<EnemyGroup> enemyGroups;
}

[Serializable]
public class EnemyGroup
{
    public string name; // debugging and maybe for the player to see
    public float timeUntilNextGroup;
    public List<Enemy> enemies;
}

[Serializable]
public class Enemy
{
    public Vector2 spawnPosition;
    public Vector2 moveTowards;
    public EnemyType enemyType;
    public float timeToStart;
    public int hitPoints;
    public int powerUpChance;
}

public enum EnemyType
{
    MovingToPlayer,
    MovingWrappingScreen,
    ShootingToPlayer,
    ShootingToDirection
}
