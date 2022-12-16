using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Camera mainCamera;
    public UnityEvent mouseButtonClicked;
    public int money;

    public TextMeshProUGUI moneyText;

    private void Start()
    {
        Time.timeScale = 1f;
        if (mouseButtonClicked == null)
        {
            mouseButtonClicked = new UnityEvent();
        }
        UpdateMoney();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            mouseButtonClicked?.Invoke();
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        foreach (Transform child in GameObject.Find("Canvas").transform)
        {
            if (child.name != "GameOver")
            {
                child.gameObject.SetActive(false);
            }
        }
        Time.timeScale = 0f;
    }

    public void AddMoney(int m)
    {
        money += m;
        UpdateMoney();
    }

    public void SubstractMoney(int m)
    {
        money -= m;
        UpdateMoney();
    }

    void UpdateMoney()
    {
        moneyText.text = money.ToString();
    }
}
