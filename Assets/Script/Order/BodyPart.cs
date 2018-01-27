using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {


    public FeetPart feets;
    public AnimationControllerCustom anim;
    public SpriteRenderer render;
     public ColliderManager collideras;

    public bool isbeingAttackin;
    public bool isShooting;
    public bool select1;
    public bool select2;
    public bool isReloading;
    public bool doAction;
    public bool isAttackingMelee;
    public bool isAttackingMelee2;
    public bool isThrowing;
    public bool gunActive;
    public bool gunShotActive;


    private void Start()
    {
        feets = GetComponentInParent<FeetPart>();
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        collideras = GetComponentInParent<ColliderManager>();

        gunActive = true;
        
    }

    private void Update()
    {
        if (feets.render.flipX)
        render.flipX = true;
        else render.flipX = false;
    }

    private void LateUpdate()
    {
        

        AnimationControlBody();

       
    }


    
    void ActiveColliderHit()
    {
        if (render.flipX)
        {
            if (isAttackingMelee) collideras.ActiveCollider("left_StandupStick");
            if (isAttackingMelee2) collideras.ActiveCollider("left_StandupAxe");
        }
        else
        {
            if (isAttackingMelee)  collideras.ActiveCollider("right_StandupStick");            
            if (isAttackingMelee2) collideras.ActiveCollider("right_StandupAxe");
        }
     
}

    void DesactiveColliderHit()
    {
        collideras.DesactiveCollider("left_StandupStick");
        collideras.DesactiveCollider("left_StandupAxe");
        collideras.DesactiveCollider("right_StandupStick");
        collideras.DesactiveCollider("right_StandupAxe");
    }

    void EndAtackMelee()
    {
        isAttackingMelee = false;
        isAttackingMelee2 = false;
    }

    void EndReload()
    {
        isReloading = false;
    }

    void EndShooting()
    {
        isShooting = false;
    }
    void EndThrow()
    {
        isThrowing = false;
    }

    void EndSelectWeapon()
    {
        select1 = false;
        select2 = false;
    }


    private void AnimationControlBody()
    {
        if (gunActive)
        {
            if (select1) anim.ChangeAnimation(AnimationName.gun_selectGun);
            

            else if (isShooting) anim.ChangeAnimation(AnimationName.gun_shoot);
            else if (isAttackingMelee && !isShooting) anim.ChangeAnimation(AnimationName.gun_attackMelee_stick);
            else if (isAttackingMelee2 && !isShooting) anim.ChangeAnimation(AnimationName.gun_attackMelee_axe);
            else if (isReloading && !isShooting) anim.ChangeAnimation(AnimationName.gun_reload);
            else if (isThrowing) anim.ChangeAnimation(AnimationName.gun_throw);




            else if (feets.isJumping)
            {

                if (feets.rb.velocity.x == 0)
                    anim.ChangeAnimation(AnimationName.gun_jumpUp);
                else anim.ChangeAnimation(AnimationName.gun_jumpFront);
            }

            else if (!feets.isJumping) anim.ChangeAnimation(AnimationName.gun_idle);

            else if (feets.ismoving)
            {
                if (feets.iswalking) anim.ChangeAnimation(AnimationName.gun_walk);
            }

            else anim.ChangeAnimation(AnimationName.gun_idle);
        }

     
        
         else if (gunShotActive)
        {

            if (select2) anim.ChangeAnimation(AnimationName.shotGun_selectGun);

            else
            {

                if (isShooting) anim.ChangeAnimation(AnimationName.shotGun_shoot);
                else if (isAttackingMelee && !isShooting) anim.ChangeAnimation(AnimationName.shotGun_attackMelee_stick);
                else if (isAttackingMelee2 && !isShooting) anim.ChangeAnimation(AnimationName.shotGun_attackMelee_axe);
                else if (isReloading && !isShooting) anim.ChangeAnimation(AnimationName.shotGun_reload);
                else if (isThrowing) anim.ChangeAnimation(AnimationName.shotGun_throw);




                else if (feets.isJumping)
                {

                    if (feets.rb.velocity.x == 0)
                        anim.ChangeAnimation(AnimationName.shotGun_jumpUp);
                    else anim.ChangeAnimation(AnimationName.shotGun_jumpFront);
                }

                else if (!feets.isJumping) anim.ChangeAnimation(AnimationName.shotGun_idle);

                else if (feets.ismoving)
                {
                    if (feets.iswalking) anim.ChangeAnimation(AnimationName.shotGun_walk);
                }

                else anim.ChangeAnimation(AnimationName.shotGun_idle);
            }

        }
      
    }

    


    public void Shooting()
    {
        isShooting = true;
        

    }

    public void Throw()
    {
        isThrowing = true;

    }
        
    public void Reloading()
    {
        isReloading = true;

    }

    public void AttackStick()
    {
        isAttackingMelee = true;
        
    }
    public void AttackAxe()
    {
        isAttackingMelee2 = true;

    }

    public void SelectGun()
    {
        select1 = true;
        gunActive = true;
        gunShotActive = false;
        isShooting = false;

    }

    public void SelectShotGun()
    {
        select2 = true;
        gunShotActive = true;
        gunActive = false;
        isShooting = false;

    }


}
