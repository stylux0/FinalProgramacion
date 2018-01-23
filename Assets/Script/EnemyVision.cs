using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {


    public Enemy enemy;
    //public Hero player;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        
            Hero player = c.gameObject.GetComponent<Hero>();

        if(c.gameObject.layer == Layers.HERO && !enemy.isWakeUp && !enemy.canMove)
        {
           
            if (!player.iswalkinglow)
            enemy.isWakeUp = true;
         
        }
        
    }

    private void OnTriggerStay2D(Collider2D c)
    {

    


        if(c.gameObject.layer == Layers.HERO)
        {
            Hero player = c.gameObject.GetComponent<Hero>();

            if (!player.iswalkinglow   && player.rb.velocity.x != 0 && !enemy.isWakeUp)
               enemy.isWakeUp = true;
        }




        if (c.gameObject.layer == Layers.HERO && enemy.canMove && enemy.isWakeUp)
        {



            //Debug.Log(c.name);
            if (enemy.transform.position.x+1 < c.transform.position.x)
            {
                enemy.direcction = 1;
                if (!enemy.render.flipX)
                {
                   
                    enemy.render.flipX = true;
                }
               
            }
                

            if (enemy.transform.position.x > c.transform.position.x )
            {
                
                enemy.direcction =  -1;
                if (enemy.render.flipX)
                {

                    enemy.render.flipX = false;
                }
            }
            
        }
            
    }


}
