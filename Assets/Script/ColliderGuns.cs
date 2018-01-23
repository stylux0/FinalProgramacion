using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGuns : MonoBehaviour {


    public Transform hero;
    public ManagerPlayerGameplay manager;
    public JannaBody player;
    private int direcction;

    private bool hitSomething;

	// Use this for initialization
	void Start () {
        manager = GetComponentInParent<ManagerPlayerGameplay>();
        player = GetComponentInParent<JannaBody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player.render.flipX) direcction = -1;
        else direcction = 1;

        if(gameObject.activeSelf == true)
        {
            hitSomething = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (!hitSomething && c.gameObject != null )
        {
            hitSomething = true;
            Debug.Log(hitSomething);
            //Debug.Log(manager.DistanceWithTheEnemy(hero.transform.position, c.transform.position));
            Rigidbody2D crb = c.gameObject.GetComponent<Rigidbody2D>();
            crb.AddForce(new Vector2(2 * direcction, 1), ForceMode2D.Impulse);
            
        }

   
    }

   

}
