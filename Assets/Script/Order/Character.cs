using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float life;
    public float CurrnetMaxspeed;
    public float currentspeed;
    public float runSpeed;
    public float walkSpeed;
    public float slowSpeed;
    public float damageSpeed;

	public bool isTouchingTheFloor;
	public float jumpStrength;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
            Destroy(gameObject);

        if(life < 10)
        {
            currentspeed = damageSpeed;
        }
	}

    

	private void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.layer == Layers.FLOOR)
		{
			isTouchingTheFloor = true;
		}

		if (c.gameObject.layer == Layers.ENEMY)
		{


			//Debug.Log(enemy.isAttaking);

			//isGettingDamage = true;
			//Debug.Log("GetDamage");
			//if (render.flipX && isGettingDamage)
			//{
		//		rb.velocity = new Vector2(0, 0);
		//		rb.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);

				//isrunning = false;
		//	}


		}

	}

}
