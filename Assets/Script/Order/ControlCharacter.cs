using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {

    // Use this for initialization

    public Rigidbody2D rb;
    //public int direcction;
    public bool leftShift;
    public Character player;
    public FeetPart feets;
    public BodyPart bodyPart;
    public BodyComplete bodyComplete;
    public ColliderManager colliderBox;
    public Collider2D[] collideres;
    public Collider2D thisCollider;

    public bool bodyCompletActive;
    public bool bodyPartsActive;
    public bool bodyStandUpCompleteActive;

    private void Awake()
    {
       
        
    }

    void Start () {
        colliderBox = GetComponent<ColliderManager>();
        collideres = GetComponentsInChildren<Collider2D>();
        thisCollider = GetComponent<Collider2D>(); 
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Character>();
        feets = GetComponentInChildren<FeetPart>();
        bodyPart = GetComponentInChildren<BodyPart>();
        bodyComplete = GetComponentInChildren<BodyComplete>();

        bodyComplete.gameObject.SetActive(false);

        Debug.Log(collideres.Length);
        //player.currentspeed = player.speed;
        for (int i = 0; i < collideres.Length; i++)
        {

            

            if (collideres[i].name == "Down")
                collideres[i].enabled = true;

             if (collideres[i].name == "StandUp")
                collideres[i].enabled = false;

            collideres[i].enabled = false;
           



        }



    }
	
	// Update is called once per frame
	void Update ()
    {
        ControlShooter();
        ControlBoxCollider();
        ControlParts();
        

        if (bodyPartsActive)
        {
            bodyComplete.gunActive = bodyPart.gunActive;
            bodyComplete.gunShotActive = bodyPart.gunShotActive;
            bodyComplete.render.flipX = feets.render.flipX;

          
            //bodyComplete.isDowning = false;
            if (bodyComplete.EndAction)
            {
                feets.gameObject.SetActive(true);
                bodyComplete.gameObject.SetActive(false);
                FeedControl();
                BodyControl();
            }
           

        }

    

        else
        {
            if (bodyComplete.isGettingDamage)
            {
                
                bodyPart.gunShotActive = bodyComplete.gunShotActive;
                bodyPart.gunActive = bodyComplete.gunActive;
                feets.render.flipX = bodyComplete.render.flipX;
                bodyComplete.gameObject.SetActive(true);
                feets.gameObject.SetActive(false);
                
            }
            else
            {
                BodyCompleteControl();
                bodyPart.gunShotActive = bodyComplete.gunShotActive;
                bodyPart.gunActive = bodyComplete.gunActive;
                //bodyPart.gunShotActive = bodyComplete.gunShotActive;
                // bodyPart.gunActive = bodyComplete.gunActive;


                feets.render.flipX = bodyComplete.render.flipX;
                feets.gameObject.SetActive(false);
                bodyComplete.gameObject.SetActive(true);
            }

          


        }
        

      

    }


    void ControlShooter()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (bodyComplete.gunActive || bodyPart.gunActive)
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(bodyPart.transform.position , Vector2.right * -1, 20f);
                //Physics2D.Linecast()
               /Debug.DrawLine(bodyPart.transform.position, hit.collider.transform.parent.position, Color.red);

                Debug.Log(hit.collider.transform.parent.name);
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.transform.parent.gameObject.layer);

                    if (hit.collider.transform.parent.gameObject.layer == Layers.ENEMY )
                    {
                        //Debug.Log("hit");

                        float distance = Vector2.Distance(transform.position, hit.transform.position);
                        //Debug.Log(hit.collider.name);
                        //  Rigidbody2D hitRB = hit.collider.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
                        EnemySoldier enemy = hit.collider.gameObject.transform.parent.gameObject.GetComponent<EnemySoldier>();
                        float forceX = distance - 6;
                        //Debug.Log(enemy.getDamage);

                        enemy.GetDamage(1);
                        // hitRB.AddForce(new Vector2(distance - 5 * -direcction, 0.3f), ForceMode2D.Impulse);
                        //enemy.Die();
                        //return;
                    }
                }
            }
        }
    }

    void ControlBoxCollider()
    {
        if (Input.GetKey(KeyCode.S))
        { colliderBox.ActiveCollider("Down");
            colliderBox.DesactiveCollider("StandUp");
            //thisCollider.enabled = false;

        }
        else
        {
            colliderBox.DesactiveCollider("Down");
            colliderBox.ActiveCollider("StandUp");
            //thisCollider.enabled = true;
        }


    }

    void ControlParts()
    {

        if (bodyComplete.isGettingDamage)
        {
            bodyComplete.gameObject.SetActive(true);
            feets.gameObject.SetActive(false);

        }

        if (Input.GetKey(KeyCode.S)) {
            bodyStandUpCompleteActive = false;
            bodyPartsActive = false; }
        else
        {
            bodyPartsActive = true;
            bodyStandUpCompleteActive = true;
            bodyComplete.isDowning = false;
        }

        if (Input.GetKeyDown(KeyCode.O) && !bodyComplete.isDowning)
        {   bodyPartsActive = false;
            bodyStandUpCompleteActive = true;
        
        }
        if (Input.GetKeyUp(KeyCode.O) && !bodyComplete.isDowning) {
            bodyPartsActive = true;
            bodyStandUpCompleteActive = false;
        }
    }


    void BodyCompleteControl()
    {

        if (Input.GetKeyDown(KeyCode.O) && bodyStandUpCompleteActive) bodyComplete.AttackKickStandUp();

        else if(Input.GetKey(KeyCode.S) && !bodyStandUpCompleteActive)
        {
            
            
            if (Input.GetKeyDown(KeyCode.J)) bodyComplete.ShootDown();
            if (Input.GetKeyDown(KeyCode.K)) bodyComplete.AttackStick();
            if (Input.GetKeyDown(KeyCode.L)) bodyComplete.AttackAxe();
            if (Input.GetKeyDown(KeyCode.O)) bodyComplete.AttackKick();
            if (Input.GetKeyDown(KeyCode.I)) bodyComplete.Throw();
            else if (Input.GetKeyDown(KeyCode.Alpha1)) bodyComplete.SelectGun();
            else if (Input.GetKeyDown(KeyCode.Alpha2)) bodyComplete.SelectShotGun();

            else if (Input.GetKey(KeyCode.D))
            {if (player.life > 10){ bodyComplete.MoveDown(1, 2); }else { bodyComplete.MoveDown(1, 0.5f); } }

            else if (Input.GetKey(KeyCode.A))
            { if (player.life > 10) { bodyComplete.MoveDown(-1, 2); } else { bodyComplete.MoveDown(-1, 0.5f); } }
            else bodyComplete.GetDown();
        }
      
        //else bodyComplete.isAttakcingMelee4 = false;

    }

    void BodyControl()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            bodyPart.Shooting();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            bodyPart.Reloading();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {

            bodyPart.AttackStick();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

            bodyPart.AttackAxe();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            bodyPart.Throw();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            bodyPart.SelectGun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            bodyPart.SelectShotGun();
        }


    }

    void FeedControl()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            feets.JumpFeet();
        }
        

		else if (Input.GetKey (KeyCode.LeftControl) /*&& !isjumping*/) {
			player.currentspeed = player.slowSpeed;

			if (Input.GetKey (KeyCode.D))
				feets.MoveFeet (1, player.currentspeed, player);
			else if (Input.GetKey (KeyCode.A))
				feets.MoveFeet (-1, player.currentspeed, player);
			else
				feets.IdleFeet ();
		}

        else if (Input.GetKey (KeyCode.LeftShift)) {
			player.currentspeed = player.runSpeed;

			if (Input.GetKey (KeyCode.D))
				feets.MoveFeet (1, player.currentspeed, player);
			else if (Input.GetKey (KeyCode.A))
				feets.MoveFeet (-1, player.currentspeed, player);
			else
				feets.IdleFeet ();
		}

        else if (Input.GetKey(KeyCode.D)) {
            if(player.life > 10)
            {
                player.currentspeed = player.walkSpeed;

                feets.MoveFeet(1, player.currentspeed, player);

            }else
            {
                player.currentspeed = player.damageSpeed;


                feets.MoveFeet(1, player.currentspeed, player);
            }
           
        }


        else if (Input.GetKey(KeyCode.A)) {
            if (player.life > 10)
            {
                player.currentspeed = player.walkSpeed;

                feets.MoveFeet(-1, player.currentspeed, player);

            }
            else
            {
                player.currentspeed = player.damageSpeed;


                feets.MoveFeet(-1, player.currentspeed, player);
            }
        }
        

        else {
            feets.IdleFeet();
           // Debug.Log("stay");
        }

    }




}
