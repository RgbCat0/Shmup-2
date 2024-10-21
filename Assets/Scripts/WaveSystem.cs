using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int currentWave;
    public List<Wave> waves;

    public void SpawnNewWave() { }

    private void SpawnEnemyGroup(EnemyGroup enemyGroup)
    {
        foreach (var enemy in enemyGroup.enemies)
        {
            SpawnEnemy(enemy);
        }
    }

    private void SpawnEnemy(Enemy enemy)
    {
        var enemySpawnPosition = enemy.spawnPosition;
        var enemyMoveTowards = enemy.moveTowards;
        switch (enemy.enemyType) { }
    }
}

[Serializable]
public class Wave
{
    public List<EnemyGroup> enemyGroups;
    public float timeBetweenGroups;
}

[Serializable]
public class EnemyGroup
{
    public List<Enemy> enemies;
}

[Serializable]
public class Enemy
{
    public Vector2 spawnPosition;
    public Vector2 moveTowards;
    public EnemyType enemyType;
    public float speed;
    public int hitPoints;
}

public enum EnemyType
{
    MovingToPlayer,
    MovingWrappingScreen,
    ShootingToPlayer,
    ShootingToDirection
}
