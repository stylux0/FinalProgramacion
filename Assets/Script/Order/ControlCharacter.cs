using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {

    // Use this for initialization

    public Rigidbody2D rb;
    public int direcction;
    public bool leftShift;
    public Character player;
    public FeetPart feets;
    public BodyPart bodyPart;
    public BodyComplete bodyComplete;

    public bool bodyCompletActive;
    public bool bodyPartsActive;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Character>();
        feets = GetComponentInChildren<FeetPart>();
        bodyPart = GetComponentInChildren<BodyPart>();
        bodyComplete = GetComponentInChildren<BodyComplete>();
        //player.currentspeed = player.speed;

    }
	
	// Update is called once per frame
	void Update ()
    {

        ControlParts();
        BodyCompleteControl();

        if (bodyPartsActive)
        {
            feets.gameObject.SetActive(true);
            bodyComplete.gameObject.SetActive(false);
            FeedControl();
            BodyControl();
        }
        else
        {
            feets.gameObject.SetActive(false);
            bodyComplete.gameObject.SetActive(true);
        }
        

      

    }

    void ControlParts()
    {
        if (Input.GetKey(KeyCode.S))  bodyPartsActive = false;
        else bodyPartsActive = true;
    }


    void BodyCompleteControl()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D)) bodyComplete.MoveDown(1, 2);
            else if (Input.GetKey(KeyCode.A)) bodyComplete.MoveDown(-1, 2);
            else bodyComplete.GetDown();
        }
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
            player.currentspeed = player.walkSpeed;

            feets.MoveFeet(1, player.currentspeed, player);
        }


        else if (Input.GetKey(KeyCode.A)) {
            player.currentspeed = player.walkSpeed;

            feets.MoveFeet(-1, player.currentspeed, player);
        }
        

        else if (Input.GetKey (KeyCode.G)) {
			player.currentspeed = player.damageSpeed;

            
             feets.MoveFeet(1, player.currentspeed, player);
        }  

		


        else {
            feets.IdleFeet();
           // Debug.Log("stay");
        }

    }




}
