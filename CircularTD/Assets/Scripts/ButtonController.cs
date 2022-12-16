using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void CloseTabMenu()
    {
        transform.parent.GetComponentInChildren<TabGroup>().selectedButton = null;
        transform.parent.GetComponentInChildren<TabGroup>().ResetTabs();
        GetComponentInParent<TabMenuController>().PlayAnim();
    }
}
