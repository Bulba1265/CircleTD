using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulllet : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * GetComponentInParent<Tower>().bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float bulletDamage = GetComponentInParent<Tower>().bulletDamage;
            collision.gameObject.GetComponent<EnemyMovement>().hp -= bulletDamage;
            if (collision.gameObject.GetComponent<EnemyMovement>().hp <= 0)
            {
                FindObjectOfType<GameManager>().AddMoney((int)collision.gameObject.GetComponent<EnemyMovement>().enemyStats.enemyReward);
                GetComponentInParent<Tower>().EnemyDestroyed(collision.gameObject);
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
