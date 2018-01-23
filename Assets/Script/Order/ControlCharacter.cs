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

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Character>();
        feets = GetComponentInChildren<FeetPart>();
        //player.currentspeed = player.speed;

    }
	
	// Update is called once per frame
	void Update ()
    {
        FeedControl();

      

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
        

        else if (Input.GetKey (KeyCode.R)) {
			player.currentspeed = player.damageSpeed;

			feets.MoveFeet (1, player.currentspeed, player);
		}  

		


        else {
            feets.IdleFeet();
           // Debug.Log("stay");
        }

    }




}
