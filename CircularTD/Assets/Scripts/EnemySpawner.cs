using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemiesSpawned;
    public float waitTime = 0.8f;
    float timer;
    Dictionary<int, string> enemies = new Dictionary<int, string>();
    System.Random rnd;

    private void Start()
    {
        int iterator = 0;
        foreach (KeyValuePair<string, Enemy> e in GetComponent<EnemyManager>().enemies)
        {
            enemies.Add(iterator, e.Key);
            iterator += 1;
        }
        rnd = new System.Random();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime){
            timer -= waitTime;
            SpawnEnemy();
        }

    }


    void SpawnEnemy()
    {
        float r = 5.5f;
        float x = 1f;
        float y = 1f;
        float angle = UnityEngine.Random.Range(0f, 360f);
        float tangens = Mathf.Tan(angle * Mathf.PI/180f);
        y = tangens * x;
        x = Mathf.Sqrt(r * r / (y * y + x * x));
        y = tangens * x;
        if (angle > 180f && angle < 360f)
        {
            x = -x;
            y = -y;
        }
        GameObject tempEnemy = Instantiate(enemy, new Vector3(x, y, 0f), Quaternion.identity);
        tempEnemy.GetComponent<EnemyMovement>().Initialize(GetRandomEnemy());
        enemiesSpawned.Add(tempEnemy);
    }


    Enemy GetRandomEnemy()
    {
        Enemy e = new Enemy();
        int it = rnd.Next(0, GetComponent<EnemyManager>().enemies.Count);
        string enemyName = "";
        enemies.TryGetValue(it, out enemyName);
        GetComponent<EnemyManager>().enemies.TryGetValue(enemyName, out e);
        return e;
    }
}
