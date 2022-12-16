using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public float nextUpgradeCostMultiplyer;
    public string description;
    public float benefit;
    public Sprite upgradeIcon;
    public int upgradeLevel;
    public int upgradeCost;
}
