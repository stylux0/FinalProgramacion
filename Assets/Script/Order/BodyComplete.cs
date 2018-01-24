using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyComplete : MonoBehaviour {


  
    public AnimationControllerCustom anim;
    public SpriteRenderer render;
    public Rigidbody2D rb;

    public bool isMoving;
    public bool isDowning;
    public bool isShooting;
    public bool select1;
    public bool select2;
    public bool isReloading;
    public bool isDying;
    public bool isGettingDamage;
    public bool isAttackingMelee;
    public bool isAttackingMelee2;
    public bool isAttackingMelee3;
    public bool isThrowing;
    public bool gunActive;
    public bool gunShotActive;

    // Use this for initialization
    void Start () {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void LateUpdate()
    {
        if (isDowning) anim.ChangeAnimation("idleDown");
        if (isMoving) anim.ChangeAnimation("moveDown");
        
          
        
    }

    public void GetDown()
    {
        isDowning = true;
        isMoving = false;
    }

    public void MoveDown(int direcction, float speed)
    {
        if (direcction < 0)
            render.flipX = true;
        else render.flipX = false;

        isDowning = false; 
        isMoving = true;
        rb.velocity = new Vector2(speed * direcction, rb.velocity.y);
    }


}
