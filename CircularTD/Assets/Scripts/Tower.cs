using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    public float hp = 100f;
    public HealthBar towerHB;
    public float bulletDamage = 10f;
    public float defaultBulletDamage = 10f;
    public float bulletSpeed = 3f;
    public float defaultBulletSpeed = 3f;
    GameManager gameManager;
    UpgradeManager upgradeManager;
    EnemySpawner enemySpawner;
    GameObject b;
    GameObject currTarget;
    float timer;
    float waitTime = 1f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemySpawner = gameManager.GetComponent<EnemySpawner>();
        towerHB.SetMaxValue(hp);

        gameManager.mouseButtonClicked.AddListener(SpawnBullet);
        upgradeManager = gameManager.GetComponent<UpgradeManager>();
        upgradeManager.onUpgraded.AddListener(UpdateStats);
    }

    // Update is called once per frame
    void Update()
    {
        if (currTarget == null)
        {
            PickNewEnemy();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                timer -= waitTime;
                SpawnBullet();
                foreach (Transform child in this.gameObject.transform) {
                    if (Mathf.Pow(child.transform.position.x, 2) + Mathf.Pow(child.transform.position.y, 2) > 30f)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        
       
    }

    void SpawnBullet()
    {
        if (currTarget != null)
        {
            b = Instantiate(bullet, transform);
            Vector3 dir = currTarget.transform.position - b.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            b.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
    }

    public void EnemyDestroyed(GameObject e)
    {
        enemySpawner.enemiesSpawned.Remove(e);
        currTarget = null;
    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        towerHB.UpdateValue(hp);
        if (hp <= 0)
        {
            gameManager.GameOver();
        }
    }

    void PickNewEnemy()
    {
        if (enemySpawner.enemiesSpawned.Count > 0)
        {
            currTarget = enemySpawner.enemiesSpawned[0];
        }
    }

    void UpdateStats()
    {
        bulletSpeed = defaultBulletSpeed + upgradeManager.upgrades["BulletSpeed"].benefit * upgradeManager.upgrades["BulletSpeed"].upgradeLevel;
        bulletDamage = defaultBulletDamage + upgradeManager.upgrades["BulletDamage"].benefit * upgradeManager.upgrades["BulletDamage"].upgradeLevel;
    }
}
