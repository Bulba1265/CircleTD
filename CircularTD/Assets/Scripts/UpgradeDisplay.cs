using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI upgradeDescription;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI upgradeLevel;
    public Image upgradeIcon;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Upgrade()
    {
        if (gameManager.money >= upgrade.upgradeCost)
        {
            gameManager.SubstractMoney(upgrade.upgradeCost);
            upgrade.upgradeLevel += 1;
            upgrade.upgradeCost = (int)(upgrade.upgradeCost * upgrade.nextUpgradeCostMultiplyer);
            UpdateUI();
            gameManager.GetComponent<UpgradeManager>().UpdateUpgrade(upgrade);
        }
    }
    void UpdateUI()
    {
        upgradeCost.text = "Cost: " + upgrade.upgradeCost.ToString();
        upgradeLevel.text = "Level: " + upgrade.upgradeLevel.ToString();
    }

    public void Initialize(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        upgradeName.text = upgrade.upgradeName;
        upgradeDescription.text = upgrade.description;
        upgradeIcon.sprite = upgrade.upgradeIcon;
        upgradeCost.text = "Cost: " + upgrade.upgradeCost.ToString();
        upgradeLevel.text = "Level: " + upgrade.upgradeLevel.ToString();
    }
}
