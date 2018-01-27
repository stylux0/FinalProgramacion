using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAttack : MonoBehaviour {

    public float damage;
    public float forceX;
    public float forceY;
    public ForceMode2D forceMode;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.layer == Layers.ENEMY && c.gameObject != null)
        {
            Enemy enemy = c.GetComponent<Enemy>();
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            
            
            enemy.GetDamage(damage);
            
            rb.AddForce(new Vector2(forceX, forceY), forceMode);
        }
       
    }
}
