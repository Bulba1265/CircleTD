using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    public GameObject upgradePrefab;
    Transform content;
    Dictionary<string, Upgrade> upgrades = new Dictionary<string, Upgrade>();
    private void Start()
    {
        content = transform.GetChild(0).transform.GetChild(0).transform;
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        upgrades = FindObjectOfType<GameManager>().GetComponent<UpgradeManager>().upgrades;
        foreach (KeyValuePair<string, Upgrade> upgrade in upgrades)
        {
            DisplayUpgrade(upgrade.Value);
        }

    }

    void DisplayUpgrade(Upgrade upgrade)
    {
        GameObject go = Instantiate(upgradePrefab, content);
        go.GetComponent<UpgradeDisplay>().Initialize(upgrade);
    }
}
