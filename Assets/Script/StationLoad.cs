using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationLoad : MonoBehaviour
{
    private static StationLoad obj;
    private Animator anim;
    public int giveLives = 1, timesLoad = 2;
    public float timeRecharge = 2f;
    private bool action = false;
    void Awake() { obj = this; }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        TimesAction();
    }
    //metodo para colisionar con la estacion de carga
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Player.obj.lives < 3)
        {
            action = true;
            Player.obj.LivesGive(giveLives);
            anim.enabled = true;
            timesLoad--;
            AudioManager.obj.PlayRecharge();
        }
    }
    //metodo mientras no esta colisionando
    private void OnTriggerExit2D(Collider2D collision)
    {
        action = false;
    }
    //recarga de veces que puede dar vidas
    public void TimesAction()
    {
        if(action)
        {
            if(timesLoad > 1)
            {
                if(timeRecharge <= 0)
                {
                    timeRecharge += 2f;
                    Player.obj.LivesGive(giveLives);
                    Debug.Log("Lives Bonus");
                    timesLoad -= 1;
                    anim.SetBool("Recharge", false);
                    AudioManager.obj.PlayRecharge();
                }
                else
                {
                    timeRecharge -= Time.deltaTime;
                    anim.SetBool("Recharge", true);
                }
            }
            else
            {
                action = false;
                anim.SetBool("Empty", true);
                Destroy(obj, .5f);
                Debug.Log("Empty");
            }
        }
    }
}
