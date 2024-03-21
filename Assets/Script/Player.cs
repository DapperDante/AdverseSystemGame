using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public static Player obj;
    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer spr;
    //variables internas del personaje
    public float velocityRun = 2f, forceJump = 5f;
    public int lives = 3;
    //variables del control de movimiento
    private bool rightButton = false, leftButton = false, UpButton = false, grounded = false;
    private void Awake() { obj = this; }
    //iniciacion de componentes
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    //actualizacion constante
    void Update()
    {
        MovePlayer();
    }
    //control de movimiento
    public void MovePlayer()
    {
        if(leftButton)
        {
            rb2D.velocity = new Vector2(-velocityRun, rb2D.velocity.y);
            spr.flipX = true;
            anim.SetBool("Run", true);
        }
        else if(rightButton)
        {
            rb2D.velocity = new Vector2(velocityRun, rb2D.velocity.y);
            spr.flipX = false;
            anim.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("Run", false);
        }
        if(UpButton && grounded )
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, forceJump);
            AudioManager.obj.PlayFireJump();
            anim.SetBool("Run", false);
            anim.SetBool("Jump", true);
        }
    }
    //contacto con una colisión
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded"))
        {
            grounded = true;
            anim.SetBool("Jump", false);
        }
    }
    //no entra en contacto con esa colisión
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded"))
        {
            grounded = false;
            anim.SetBool("Jump", true);
        }
    }
    //metodo para obtener vidas
    public void LivesGive(int livesgives)
    {
        if(Player.obj.lives < 3)
        {
            lives += livesgives;
        }
        else
        {
            Debug.Log("Live +1");
        }
    }
    //metodo para recibir daño
    public void GetDamage(int damage)
    {
        lives -= damage;
        Debug.Log("Damage");
        anim.Play("DamagePlayer");
    }
    //metodos llamados por los canvas "Botones"
    public void PressLeft() { leftButton = true; }
    public void NotPressLeft() { leftButton = false; }
    public void PressRight() { rightButton = true; }
    public void NotPressRight() { rightButton = false; }
    public void PressUp() { UpButton = true; }
    public void NotPressUp() { UpButton = false; }
}
