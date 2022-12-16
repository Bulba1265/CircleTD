using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenuController: MonoBehaviour
{
    public bool isTabMenuOpened = false;
    Animator anim;
    int counter = 0;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        if (counter == 0)
        {
            if (!isPlaying(anim, "test2"))
            {
                counter += 1;
                anim.Play("test");
                isTabMenuOpened = true;
            }
        }
        else
        {
            if (!isPlaying(anim, "test"))
            {
                counter -= 1;
                anim.Play("test2");
                isTabMenuOpened = false;
            }
        }
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
