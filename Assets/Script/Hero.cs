using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public float life;
    public float damageGun;
    public float damagaShotGun;
    public float damageKick;
    public float damageAxe;
    public float damageStick;


    public float speed;
    private float currentSpeed;
    public AnimationControllerCustom anim;
    public SpriteRenderer render;
    public Rigidbody2D rb;
    public float jumpStrength;


    public bool ismoving;
    public bool isrunning;
    public bool isjumping;
    public bool iswalkinglow;
    public bool isGettingDamage;
  

    public void Start()
    {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim.ChangeAnimation("idle");
    }

    public void Update()
    {


     

        if (Input.GetKey(KeyCode.LeftShift)  && !isjumping){

            iswalkinglow = true;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                isrunning = false;
               // iswalkinglow = true;
            }

           
        }
        else
        {
            iswalkinglow = false;
            isrunning = true;
        }

        if(Input.GetKey(KeyCode.D)){
            
            render.flipX = false;
            move(1);
            currentSpeed = speed;

         
        }

     
        else if (Input.GetKey(KeyCode.A))
        {
         
            render.flipX = true;
            move(-1);
            currentSpeed = speed;

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); 
        }




        if (Input.GetKey(KeyCode.S))
        {

        }
       else  if (Input.GetKeyDown(KeyCode.W) && !isjumping)
        {
            jump();
        }
    }

   

    public void LateUpdate()
    {

        //AGREGAR ANIMACION DE RECBIR DAÑO Y SU FUNCION

        if (!isGettingDamage)
        {
            if (isrunning ) anim.ChangeAnimation("walknormal");



            if (iswalkinglow) anim.ChangeAnimation("walklow");

            if (rb.velocity.x == 0) ismoving = false;



            if (!ismoving) anim.ChangeAnimation("idle");

            if (isjumping)
            {
                if (rb.velocity.x == 0)
                    anim.ChangeAnimation("jumpup");
                else
                {
                    anim.ChangeAnimation("jumpfront");
                }
            }
        }

       
    }

    public void die()
    {
        
    }

    public void jump()
    {
        isjumping = true;
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.layer == Layers.FLOOR)
        {
            isjumping = false;
        }

        if (c.gameObject.layer == Layers.ENEMY)
        {
           Enemy enemy = c.gameObject.GetComponent<Enemy>();

            //Debug.Log(enemy.isAttaking);

            isGettingDamage = true;
            Debug.Log("GetDamage");
            if (render.flipX && isGettingDamage)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);
                
                //isrunning = false;
            }
            

        }

    }

    public void move(int direcction)
    {
     
                 

            

        if (iswalkinglow)
        {
            ismoving = true;
            rb.velocity = new Vector2(currentSpeed / 2 * direcction, rb.velocity.y);
        }
        else if(isrunning)
        {
            ismoving = true;
            rb.velocity = new Vector2(currentSpeed * direcction, rb.velocity.y);
        }

           
           
    }


    

    public void shoot()
    {
        
    }
}
