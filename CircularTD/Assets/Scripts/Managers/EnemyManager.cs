using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

    private void Awake()
    {
        EnemySO[] objects = Resources.LoadAll<EnemySO>("ScriptableObjects/Enemies");
        for (int i = 0; i < objects.Length; i++)
        {
            Enemy enemy = new Enemy(objects[i].enemyName, objects[i].enemyHp, objects[i].enemyDamage, objects[i].enemyReward, objects[i].enemyMovementSpeed, objects[i].enemyColor);
            enemies.Add(enemy.enemyName, enemy);
        }
    }
}
