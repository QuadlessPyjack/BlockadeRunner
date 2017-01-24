using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleItem : MonoBehaviour {
    public int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dealDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
