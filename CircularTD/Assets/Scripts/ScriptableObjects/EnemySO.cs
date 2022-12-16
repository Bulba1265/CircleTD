using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName;
    public float enemyHp;
    public float enemyDamage;
    public float enemyReward;
    public float enemyMovementSpeed;
    public Color enemyColor;
}
