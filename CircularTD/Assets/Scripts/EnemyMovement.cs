using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float hp = 10f;
    public float damage = 10f;
    public float movementSpeed;
    
    public Enemy enemyStats;
    void Start()
    {
        float angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Tower>().EnemyDestroyed(this.gameObject);
            collision.GetComponent<Tower>().DealDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void Initialize(Enemy enemy)
    {
        enemyStats = enemy;
        hp = enemy.enemyHp;
        damage = enemy.enemyDamage;
        movementSpeed = enemy.enemyMovementSpeed;
        GetComponent<SpriteRenderer>().color = enemy.enemyColor;
    }
}
