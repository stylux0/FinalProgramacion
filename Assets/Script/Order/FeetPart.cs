using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetPart : MonoBehaviour {

    public AnimationControllerCustom anim;
    public SpriteRenderer render;
    public Rigidbody2D rb;
    public Character player;


    public bool ismoving;
    public bool iswalkingslowly;
    public bool iswalking;
    public bool isrunning;
    public bool isDamageWalk;

	public bool isJumping;

    public bool isIdle;

    private void Start()
    {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
    
        player = GetComponentInParent<Character>();
        anim.ChangeAnimation(AnimationName.feet_Idle);

        isIdle = true;

    }

    private void Update()
    {
        if (player.isTouchingTheFloor) isJumping = false;
    }

    private void LateUpdate()
    {
        if (isJumping)
        {
            //Debug.Log(rb.velocity.x );

            if (rb.velocity.x == 0)
                anim.ChangeAnimation(AnimationName.feet_jumpUp);
            else anim.ChangeAnimation(AnimationName.feet_jumpFront);
        }
        
        else if (ismoving)
        {
            


            if (iswalking)
                anim.ChangeAnimation(AnimationName.feet_walkNormaly);
            else if (iswalkingslowly)
                anim.ChangeAnimation(AnimationName.feet_walkSlowly);
            else if (isrunning)
                anim.ChangeAnimation(AnimationName.feet_run);
            else if (isDamageWalk)
                anim.ChangeAnimation(AnimationName.feet_walkDamage);
        }

       
 
         else if(!ismoving)  anim.ChangeAnimation(AnimationName.feet_Idle); 

        
    }


	public void JumpFeet()
	{
       // ismoving = true;
        isIdle = false;
        isJumping = true;

        if (player.isTouchingTheFloor ) {

           
            
			rb.AddForce(Vector2.up * player.jumpStrength, ForceMode2D.Impulse);
			player.isTouchingTheFloor = false;
            

        }



    }


    public void IdleFeet()
    {
      
        isIdle = true;
        ismoving = false;
        iswalking = false;
        iswalkingslowly = false;
        isDamageWalk = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }


    public void MoveFeet(int direcction, float currentSpeedy, Character velocityMax)
    {
        
        isIdle = false;

        if (direcction > 0) render.flipX = false;
        else render.flipX = true;

        if (currentSpeedy == velocityMax.slowSpeed)
        {

			ismoving = true;
            rb.velocity = new Vector2(currentSpeedy * direcction, rb.velocity.y);
            iswalkingslowly = true;
            iswalking = false;
            isrunning = false;
            isDamageWalk = false;


        }
        else if (currentSpeedy == velocityMax.walkSpeed)
        {
			ismoving = true;
            rb.velocity = new Vector2(currentSpeedy * direcction, rb.velocity.y);
            iswalking = true;
            iswalkingslowly = false;
            isrunning = false;
            isDamageWalk = false;
        }

        else if (currentSpeedy == velocityMax.runSpeed)
        {
			ismoving = true;
            rb.velocity = new Vector2(currentSpeedy * direcction, rb.velocity.y);
            iswalking = false;
            iswalkingslowly = false;
            isrunning = true;
            isDamageWalk = false;
        }

        else if (currentSpeedy == velocityMax.damageSpeed)
		{

            ismoving = true; 
            rb.velocity = new Vector2(currentSpeedy * direcction , rb.velocity.y);
      
            iswalking = false;
            iswalkingslowly = false;
            isrunning = false;
            isDamageWalk = true;
        }

    }


}
