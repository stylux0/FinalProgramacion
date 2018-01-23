using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVision : MonoBehaviour {

    public bool heroIsNear;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO)
                    heroIsNear = true;          
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO)
            heroIsNear = false;
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.layer == Layers.HERO)
        {
            Hero player = c.gameObject.GetComponentInChildren<Hero>();
       
            player.isGettingDamage = true;
            Debug.Log(player.isGettingDamage);

        }

    }
}


