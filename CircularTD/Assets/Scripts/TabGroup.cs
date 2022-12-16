using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color idleColor;
    public Color hoverColor;
    public Color selectedColor;
    public TabButton selectedButton;
    public List<GameObject> panels;


    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (button != selectedButton)
        {
            button.background.color = hoverColor;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (!GetComponentInParent<TabMenuController>().isTabMenuOpened)
        {
            GetComponentInParent<TabMenuController>().PlayAnim();
        }
        selectedButton = button;
        ResetTabs();
        button.background.color = selectedColor;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < panels.Count; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (button != selectedButton)
            {
                button.background.color = idleColor;
            }
        }
    }
}
