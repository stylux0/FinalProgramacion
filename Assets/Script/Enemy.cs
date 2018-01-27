using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public AnimationControllerCustom anim;

    public float speed;
    public float life;
    public float damage;
    public int direcction;
    public SpriteRenderer render;
    public Rigidbody2D rb;


    public AttackVision attackvision;

    public bool canMove = false;
    public bool attackHero = false;
    public bool death = false;
    public bool isfalling;
    public bool isWakeUp;
    public bool getDamage;
    public bool isAttaking;
    public bool endAttackin;

    public void Start()
    {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        attackvision = GetComponentInChildren<AttackVision>();
        direcction = 1;
        anim.ChangeAnimation("idle");
        getDamage = false;     


    }

    private void Update()
    {

        if (direcction > 0) render.flipX = true;
        else render.flipX = false;

        if (life <= 0)
        {
            Die();
            
        }

        if (attackvision.heroIsNear)
        {
            attackHero = true;
            rb.velocity = new Vector2(0, 0);
        }
            
        else if(!attackvision.heroIsNear)
        {
            //rb.velocity = new Vector2(speed, 0);
            attackHero = false;
        }
      

    }

    private void LateUpdate()
    {

        if (!death)
        {
            if (isWakeUp)
            {
                
                    if (!canMove && !getDamage)
                    {
                        anim.ChangeAnimation("rise");
                    }

                    if (getDamage)
                        anim.ChangeAnimation("getDamage");


                    if (canMove && !isAttaking)
                    {
                        Move(speed);
                        anim.ChangeAnimation("walk");
                    }

                if (isAttaking && !getDamage)
                {
                    
                    anim.ChangeAnimation("bit");
                   
}
            }  
        }

      


    }



    public bool Attack()
    {
      
        //endAttackin = false;
        return isAttaking = true;
    }

    void EndAttack()
    {
        isAttaking = false;
        endAttackin = true;
    }



    public void Die()
    {
        death = true;
        rb.velocity = new Vector2(0, 0);
        anim.ChangeAnimation("die");
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        
        canMove = false;
        getDamage = true;
        isAttaking = false;
            //rb.AddForce(new Vector2(forceX * direcction, forceY), ForceMode2D.Impulse);
        life -= damage;
           
        
           
        

        if (!isWakeUp)
        {
            //life -= damage;
            isWakeUp = true;
        }
       
        
       
      
    }

    public void Move()
    {
        //Debug.Log("canMove");
        canMove = true;
        //getDamage = false;
        //isWakeUp = false;
    }

    public void Move(float speed)
    {
        if (!getDamage)
        {
            rb.velocity = new Vector2(speed * direcction, rb.velocity.y);
        }
       
     
        


    }

    void FreeFromDamage()
    {
        getDamage = false;
        canMove = true;
    }




    public void SetDamage(float damage, Character player)
    {
        // anim.ChangeAnimation("bit");
        if(isAttaking)
         player.life -= damage;



    }
}
