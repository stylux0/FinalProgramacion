using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayerGameplay : MonoBehaviour {


    public JannaBody player;
    public Janna playerr;
    public GameObject shotGun;
    private float time;
    private int direcction;
    private bool hitsomething;
    private RaycastHit2D hit;


	void Start () {
        player = GetComponentInChildren<JannaBody>();
        playerr = GetComponentInChildren<Janna>();
        hitsomething = false;
}


    private void FixedUpdate()
    {
        if (player.render.flipX) direcction = -1;
        else direcction = 1;

        //if(player.shotGunActive && player.isShooting )
        //{
        //    if (!hitsomething)
        //    {
        //        hitsomething = true;
               
        //    }

           
        //    else hitsomething = false;

        //}
        //if (!player.shotGunActive && !player.isShooting) hitsomething = false;


    }
    // Update is called once per frame
    void Update () {

        
         if(direcction < 0)
        {
            shotGun.transform.localPosition = new Vector2(-0.3f, -0.002f);
        }
         else shotGun.transform.localPosition = new Vector2(0.284f, 0.004f);


        if (Input.GetKeyDown(KeyCode.J))
        {
            if(player.shotGunActive )
            {
               
                    hit = Physics2D.Raycast(shotGun.transform.position, Vector2.right * direcction, 5f);
                    Debug.DrawLine(shotGun.transform.position, shotGun.transform.position + new Vector3(5f * direcction, 0, 0), Color.red);
                
    
                if (hit.collider != null )
                {
                    //Debug.Log(hit.collider.gameObject.transform.parent.gameObject.layer);

                    if(hit.collider.gameObject.transform.parent.gameObject.layer == Layers.ENEMY && player.canHurt)
                    {
                        //Debug.Log("hit");

                        float distance = Vector2.Distance(shotGun.transform.position, hit.transform.position);
                        //Debug.Log(hit.collider.name);
                      //  Rigidbody2D hitRB = hit.collider.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
                        EnemySoldier enemy = hit.collider.gameObject.transform.parent.gameObject.GetComponent<EnemySoldier>();
                        float forceX = distance - 6 ;
                        //Debug.Log(enemy.getDamage);
                        
                        enemy.GetDamage(1, -direcction, forceX, 2f);
                       // hitRB.AddForce(new Vector2(distance - 5 * -direcction, 0.3f), ForceMode2D.Impulse);
                        //enemy.Die();
                        //return;
                    }
                    

                }
            }
            
        }


    }






}
