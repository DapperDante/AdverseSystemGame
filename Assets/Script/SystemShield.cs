using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemShield : MonoBehaviour
{
    private Animator anim;
    public static SystemShield obj;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        System();
    }
    public void System()
    {
        if(Player.obj.lives == 3)
        {
            anim.SetBool("Shield75%", false);
        }
        else if(Player.obj.lives == 2)
        {
            anim.SetBool("Shield75%", true);
            anim.SetBool("Shield50%", false);
        }
        else if(Player.obj.lives == 1)
        {
            anim.SetBool("Shield50%", true);
            anim.SetBool("Shield75%", false);
        }
    }
}
