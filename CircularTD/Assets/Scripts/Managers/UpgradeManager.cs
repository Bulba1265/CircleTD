using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    public Dictionary<string, Upgrade> upgrades = new Dictionary<string, Upgrade>();
    public UnityEvent onUpgraded;

    private void Awake()
    {
        UpgradeSO[] objects = Resources.LoadAll<UpgradeSO>("ScriptableObjects/Upgrades");
        for (int i = 0; i < objects.Length; i++)
        {
            Upgrade upgrade = new Upgrade(objects[i].upgradeName, objects[i].nextUpgradeCostMultiplyer, objects[i].description, objects[i].benefit, objects[i].upgradeIcon, objects[i].upgradeCost);
            upgrades.Add(upgrade.upgradeName, upgrade);
        }
        if (onUpgraded == null)
        {
            onUpgraded = new UnityEvent();
        }
    }

    public void UpdateUpgrade(Upgrade up)
    {
        upgrades[up.upgradeName] = up;
        onUpgraded?.Invoke();
    }
}
