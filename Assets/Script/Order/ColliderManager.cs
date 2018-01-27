using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour {

    // Use this for initialization
    public Collider2D[] colliders;


	void Start () {
        colliders = GetComponentsInChildren<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActiveCollider(string name)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].name == name)
                colliders[i].enabled = true;
        }
    }

    public void DesactiveCollider(string name)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].name == name)
                colliders[i].enabled = false;
        }
    }

}
