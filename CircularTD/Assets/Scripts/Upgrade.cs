using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade 
{
    public string upgradeName;
    public float nextUpgradeCostMultiplyer;
    public string description;
    public float benefit;
    public Sprite upgradeIcon;
    public int upgradeCost;
    public int upgradeLevel;
    public Upgrade(string upgradeName = "", float nextUpgradeCostMultiplyer = 0f, string description = "", float benefit = 0, Sprite upgradeIcon = null, int upgradeCost = 0)
    {
        this.upgradeName = upgradeName;
        this.nextUpgradeCostMultiplyer = nextUpgradeCostMultiplyer;
        this.description = description;
        this.benefit = benefit;
        this.upgradeIcon = upgradeIcon;
        this.upgradeCost = upgradeCost;
        upgradeLevel = 0;
    }
}
