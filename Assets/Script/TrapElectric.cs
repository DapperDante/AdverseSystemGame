using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapElectric : MonoBehaviour
{
    public int damageLive = 1;
    bool action = false;
    float timeaction = 2f;
    void Start()
    {
        
    }
    void Update()
    {
        System();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            action = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        action = false;
    }
    public void System()
    {
        if(action)
        {
            if (timeaction <= 0)
            {
                Player.obj.GetDamage(damageLive);
                timeaction += 2f;
                Debug.Log("Daño");
            }
            else
            {
                timeaction -= Time.deltaTime;
            }
        }
    }
}
