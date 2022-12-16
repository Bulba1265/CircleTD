using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string enemyName;
    public float enemyHp;
    public float enemyDamage;
    public float enemyReward;
    public float enemyMovementSpeed;
    public Color enemyColor;

    public Enemy(string enemyName = "", float enemyHP = 0f, float enemyDamage = 0f, float enemyReward = 0f, float enemyMovementSpeed = 0f, Color enemyColor = new Color())
    {
        this.enemyName = enemyName;
        this.enemyDamage = enemyDamage;
        this.enemyReward = enemyReward;
        this.enemyMovementSpeed = enemyMovementSpeed;
        this.enemyHp = enemyHP;
        this.enemyColor = enemyColor;
    }
}
