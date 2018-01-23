using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JannaBody : MonoBehaviour {


    public AnimationControllerCustom anim;
    public SpriteRenderer render;
    public Janna feets;
  
    


    public bool ismoving;
    public bool isrunning;
    public bool isjumping;
    public bool iswalkinglow;
    public bool isShooting;
    public bool select1;
    public bool select2;
    public bool isReloading;
    public bool doAction;
    public bool isAttackingMelee;
    public bool isAttackingMelee2;


    public bool canHurt;


    public bool shotGunActive;
    public bool gunActive;

    public void Start()
    {

        feets = GetComponentInParent<Janna>();
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        //feets.rb = GetComponent<Rigidbody2D>();
        gunActive = true;
        anim.ChangeAnimation("idle");
        canHurt = true;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.K) && !doAction)
        {
            isAttackingMelee = true;
            doAction = true;
            if (render.flipX) transform.localPosition = new Vector2(-0.016f, 0.062f);
            else transform.localPosition = new Vector2(0.017f, 0.059f);


        }

        if (Input.GetKeyDown(KeyCode.L) && !doAction)
        {
            isAttackingMelee2 = true;
            doAction = true;
            if (render.flipX) transform.localPosition = new Vector2(-0.016f, 0.062f);
            else transform.localPosition = new Vector2(0.052f, 0.082f);


        }


        if (Input.GetKeyDown(KeyCode.Alpha1) && !doAction)
        {
            select1 = true;
            doAction = true;
            gunActive = true;
            shotGunActive = false;
            if (render.flipX) transform.localPosition = new Vector2(0.012f, 0.059f);
            else transform.localPosition = new Vector2(-0.006f, 0.059f);


        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !doAction)
        {
            select2 = true;
            doAction = true;
            gunActive = false;
            shotGunActive = true;
            // if (render.flipX) transform.localPosition = new Vector2(0.012f, 0.059f);
            //else transform.localPosition = new Vector2(-0.006f, 0.059f);


        }

        if (Input.GetKeyDown(KeyCode.R) && !doAction)
        {


            isReloading = true;
            doAction = true;
            if (!render.flipX) transform.localPosition = new Vector2(-0.009f, 0.062f);
            if (render.flipX) transform.localPosition = new Vector2(-0.003f, 0.053f);

        }


        if (Input.GetKeyDown(KeyCode.J) && !doAction)
        {
            isShooting = true;
            doAction = true;
            //canHurt = false;



        }
          

        if (Input.GetKey(KeyCode.W))
        {

        }
      

     

        else if (Input.GetKey(KeyCode.D))
        {
            render.flipX = false;
            transform.localPosition = new Vector2(0.04f, transform.localPosition.y);



        }


        else if (Input.GetKey(KeyCode.A))
        {
            render.flipX = true;
            transform.localPosition = new Vector2(-0.04f, transform.localPosition.y);




        }
    }

    public void LateUpdate()
    {


        if ( shotGunActive)
        {


            if (doAction)
            {
                if (select2 ) {
                    anim.ChangeAnimation("selectshotgun");
                    if (render.flipX)
                        transform.localPosition = new Vector2(-0.009f, 0.066f);
                    else transform.localPosition = new Vector2(0.009f, 0.082f);

                }
                if (isShooting) {
                    anim.ChangeAnimation("shootShotgun");
                    canHurt = false;
                }


                if (isReloading)
                {
                    anim.ChangeAnimation("reloadshotgun");
                    if (render.flipX)
                        transform.localPosition = new Vector2(-0.009f, 0.066f);
                    else transform.localPosition = new Vector2(0.009f, 0.082f);
                }


                if (isAttackingMelee) anim.ChangeAnimation("attackmelee1shotgun");

                if (isAttackingMelee2) anim.ChangeAnimation("attackmelee2shotgun");

            }







            else if (!feets.ismoving && !doAction)
            {
                anim.ChangeAnimation("idleshotgun");
                
               if (render.flipX)
                    transform.localPosition = new Vector2(0.007f, 0.062f);
               else transform.localPosition = new Vector2(-0.001f, 0.062f);


            }

            if (feets.ismoving && !doAction)
            {
                anim.ChangeAnimation("idleshotgun");
                if (render.flipX)
                    transform.localPosition = new Vector2(0.007f, 0.062f);
                else transform.localPosition = new Vector2(-0.001f, 0.062f);
            }



            if (feets.isjumping)
            {
                if (feets.rb.velocity.x == 0 && !doAction)
                {
                    anim.ChangeAnimation("jumpupshotgun");
                    //transform.localPosition = new Vector2(0.002f, 0.19f);
                }

                else if (feets.rb.velocity.x != 0 && !doAction)
                {

                    anim.ChangeAnimation("jumpfrontshotgun");
                    //if (render.flipX) transform.localPosition = new Vector2(0.08f, 0.127f);
                    //else transform.localPosition = new Vector2(-0.065f, 0.134f);




                }

                else
                {
                    doAction = true;
                    //if (render.flipX) transform.localPosition = new Vector2(-0.001f, 0.076f);
                    //else transform.localPosition = new Vector2(-0.003f, 0.073f);
                }
            }



        }


        ActionsWithGun();
  
    }



    public void ActionsWithGun()
    {
        if (gunActive)
        {
            if (doAction)
            {
                if (select1) anim.ChangeAnimation("selectgun");


                if (isReloading) anim.ChangeAnimation("reload");

                if (isShooting)
                {
                    anim.ChangeAnimation("shoot");

                    if (render.flipX) transform.localPosition = new Vector2(-0.035f, 0.052f);
                    else transform.localPosition = new Vector2(0.043f, 0.061f);
                }
                if (isAttackingMelee) anim.ChangeAnimation("attackmelee1gun");

                if (isAttackingMelee2) anim.ChangeAnimation("attackmelee2gun");

            }

            if (feets.ismoving && doAction)
            {
                if (select1) anim.ChangeAnimation("selectgun");

                if (isReloading) anim.ChangeAnimation("reload");

                if (isShooting)
                {
                    anim.ChangeAnimation("shoot");

                    if (render.flipX) transform.localPosition = new Vector2(-0.035f, 0.052f);
                    else transform.localPosition = new Vector2(0.043f, 0.061f);
                }


            }

            if (feets.ismoving && !doAction)
            {
                anim.ChangeAnimation("idle");
                if (render.flipX)
                    transform.localPosition = new Vector2(-0.04f, 0.117f);
                else transform.localPosition = new Vector2(0.04f, 0.117f);
            }







            if (feets.isjumping)
            {
                if (feets.rb.velocity.x == 0 && !doAction)
                {
                    anim.ChangeAnimation("jumpup");
                    transform.localPosition = new Vector2(0.002f, 0.19f);
                }

                else if (feets.rb.velocity.x != 0 && !doAction)
                {

                    anim.ChangeAnimation("jumpfront");
                    if (render.flipX) transform.localPosition = new Vector2(0.08f, 0.127f);
                    else transform.localPosition = new Vector2(-0.065f, 0.134f);




                }

                else
                {
                    doAction = true;
                    if (render.flipX) transform.localPosition = new Vector2(-0.001f, 0.076f);
                    else transform.localPosition = new Vector2(-0.003f, 0.073f);
                }
            }
            else if (!feets.ismoving && !doAction)
            {
                anim.ChangeAnimation("idle");
                // transform.localPosition = new Vector2(transform.localPosition.x, 0.15f);
                if (render.flipX)
                    transform.localPosition = new Vector2(-0.04f, 0.117f);
                else transform.localPosition = new Vector2(0.04f, 0.117f);

            }
        }
    }

    public void die()
    {

    }

    void EndAttackMelee()
    {
        isAttackingMelee = false;
        isAttackingMelee2 = false;
        doAction = false;
    }

    void EndReload()
    {
        isReloading = false;
        doAction = false;
    }

    void GetWeapon()
    {
        select1 = false;
        doAction = false;
    }

    void SelectShotGun()
    {
        select2 = false;
        doAction = false;
    }

    void ShootTheWeapon()
    {
        isShooting = false;
        doAction = false;
        canHurt = true;



    }



    public void shoot()
    {

    }
}
