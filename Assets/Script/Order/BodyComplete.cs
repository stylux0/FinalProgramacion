using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyComplete : MonoBehaviour {


  
    public AnimationControllerCustom anim;
    public SpriteRenderer render;
    public Rigidbody2D rb;
    public ColliderManager collideras;

    public bool EndAction;
    public bool isMoving;
    public bool isDowning;
    public bool isStandUping;
    public bool isIdleDown;
    public bool isShooting;
    public bool select1;
    public bool select2;
    public bool isReloading;
    public bool isDying;
    public bool isGettingDamage;
    public bool isAttackingMelee;
    public bool isAttackingMelee2;
    public bool isAttackingMelee3;
    public bool isAttakcingMelee4;
    public bool isThrowing;
    public bool gunActive;
    public bool gunShotActive;

    // Use this for initialization
    void Start () {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        collideras = GetComponentInParent<ColliderManager>();

        //isMoving = false;
        ////isDowning = false;
        //isStandUping = false;
        //isIdleDown = false;
        //isShooting = false;
        //select1 = false;
        //select2 = false;
        //isReloading = false;
        //isDying = false;
        //isGettingDamage = false;
        //isAttackingMelee = false;
        //isAttackingMelee2 = false;
        //isAttackingMelee3 = false;
        ////isAttakcingMelee4 = false;
        //isThrowing = false;
        EndAction = true;
    
}
	
	// Update is called once per frame
	void Update () {
         
	}



    private void LateUpdate()
    {

    if (gunActive)
        {


            if (isGettingDamage) anim.ChangeAnimation("getDamageGun");
            else
            {
                if (isDowning)
                {
                    if (isShooting && !select1) anim.ChangeAnimation(AnimationName.down_gun_shoot);

                    else if (isAttackingMelee) anim.ChangeAnimation(AnimationName.down_gun_attackMelee_stick);
                    else if (isAttackingMelee2) anim.ChangeAnimation(AnimationName.down_gun_attackMelee_axe);
                    else if (isAttackingMelee3) anim.ChangeAnimation(AnimationName.down_gun_attackMelee_kick);
                    else if (isThrowing) anim.ChangeAnimation(AnimationName.down_gun_throw);
                    else if (select1) anim.ChangeAnimation(AnimationName.down_selectGun);
                    else if (isMoving) anim.ChangeAnimation(AnimationName.down_gun_walk);
                    else anim.ChangeAnimation(AnimationName.down_gun_idle);

                }
                else if (isAttakcingMelee4) anim.ChangeAnimation(AnimationName.standup_gun_kick);
                else anim.ChangeAnimation("standup_shotgun_idle");
            }
          




        }

        if (gunShotActive)
        {
            if (isDowning)
            {
                if (isShooting && !select2) anim.ChangeAnimation(AnimationName.down_gunshot_shoot);

                else if (isAttackingMelee) anim.ChangeAnimation(AnimationName.down_shotgun_attackMelee_stick);
                else if (isAttackingMelee2) anim.ChangeAnimation(AnimationName.down_shotgun_attackMelee_axe);
                else if (isAttackingMelee3) anim.ChangeAnimation(AnimationName.down_shotgun_attackMelee_kick);
                else if (isThrowing) anim.ChangeAnimation(AnimationName.down_shotgun_throw);
                else if (select2) anim.ChangeAnimation(AnimationName.down_shotgun_selectShotGun);
                else if (isMoving) anim.ChangeAnimation(AnimationName.down_gunshot_walk);
                else anim.ChangeAnimation(AnimationName.down_gunshot_idle);

            }
            else
            {
                if (isAttakcingMelee4) anim.ChangeAnimation(AnimationName.standup_shotgun_attackmelee_kick);
            }
        
        }




    }

    public void GetDown()
    {
        isDowning = true;
      //  isIdleDown = true;
        isMoving = false;
    }

    public void MoveDown(int direcction, float speed)
    {
        if (direcction < 0)
            render.flipX = true;
        else render.flipX = false;

        if (!isShooting)
        {
             rb.velocity = new Vector2(speed * direcction, rb.velocity.y);
            isIdleDown = false;
            isMoving = true;
        }
       
        
    }


    void ActiveColliderHit()
    {
        if (render.flipX)
        {
            if (isAttackingMelee) collideras.ActiveCollider("left_DownStick");
            if (isAttackingMelee2) collideras.ActiveCollider("left_DownAxe");
            if (isAttackingMelee3) collideras.ActiveCollider("left_DownKick");
            if (isAttakcingMelee4) collideras.ActiveCollider("left_StandupKick");

        }
        else
        {
            if (isAttackingMelee) collideras.ActiveCollider("right_DownStick");
            if (isAttackingMelee2) collideras.ActiveCollider("right_DownAxe");
            if (isAttackingMelee3) collideras.ActiveCollider("right_DownKick");
            if (isAttakcingMelee4) collideras.ActiveCollider("right_StandupKick");
            

        }

    }

    void DesactiveColliderHit()
    {
        collideras.DesactiveCollider("left_DownStick");
        collideras.DesactiveCollider("left_DownAxe");
        collideras.DesactiveCollider("left_DownKick");
        collideras.DesactiveCollider("left_StandupKick");

        collideras.DesactiveCollider("right_DownStick");
        collideras.DesactiveCollider("right_DownAxe");
        collideras.DesactiveCollider("right_DownKick");
        collideras.DesactiveCollider("right_StandupKick");

    }


    void EndThrow()
    {
        isThrowing = false;
    }

    void EndAttackMelee()
    {
       // isDowning = true;
        isAttackingMelee = false;
        isAttackingMelee2 = false;
        isAttackingMelee3 = false;
        isAttakcingMelee4 = false;
        EndAction = true;
        //isDowning = false;
    }

    public void Throw()
    {
        isThrowing = true;
     
    }

    public void AttackStick()
    {
        isAttackingMelee = true;
    }

    public void AttackAxe()
    {
        isAttackingMelee2 = true;
    }
    public void AttackKick()
    {
        isAttackingMelee3 = true;
    }

    public void AttackKickStandUp()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        isDowning = false;
        isAttakcingMelee4 = true;
        EndAction = false;
       


    }


    void EndSelectWeapon()
    {
        select1 = false;
        select2 = false;
    }

    public void SelectGun()
    {
        select1 = true;
        isShooting = false;
        gunActive = true;
        gunShotActive = false;
    }

    public void SelectShotGun()
    {
        gunShotActive = true;
        gunActive = false;
        select2 = true;
        isShooting = false;
       
    }

    void EndShootDown()
    {
        isShooting = false;
    }

    public void ShootDown()
    {
        isShooting = true;
        isMoving = false;
        
    }

    public void GetDamage(bool hasPlayerAttaked, int direcction)
    {
        isGettingDamage = hasPlayerAttaked;
        EndAction = false;
        rb.AddForce(new Vector2(3* direcction, 2),ForceMode2D.Impulse);
        
    }

    void EndGetDamage()
    {
        if(rb.velocity.y == 0)
        {
            EndAction = true;
            isGettingDamage = false;
        }
      
    }



}
