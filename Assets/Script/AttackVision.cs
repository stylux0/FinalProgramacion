using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVision : MonoBehaviour {

    public bool heroIsNear;
    public Enemy me;

    private void Start()
    {
        me = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO)
        {
         
            heroIsNear = true;
        }
                            
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO)
            heroIsNear = false;
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO && me.canMove)
        {

            ControlCharacter player = c.gameObject.GetComponentInParent<ControlCharacter>();
            Character p = c.gameObject.GetComponentInParent<Character>();

            //player.bodyComplete.isGettingDamage = true;

            me.Attack();


            if (me.endAttackin && !player.bodyComplete.isGettingDamage)
            {
                
                player.bodyComplete.GetDamage(me.Attack(),me.direcction);
                me.SetDamage(me.damage, p);            
            }    
        }



    }
}


