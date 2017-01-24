using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    public int damage = 0;
    public GameObject owner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT! " + other.gameObject.name);
        Debug.Log(gameObject.name);
        if (other.gameObject == owner)
        {
            return;
        }

        DestructibleItem di = other.gameObject.GetComponent<DestructibleItem>();
        if (di != null)
        {
            di.dealDamage(damage);
        }
        Destroy(gameObject, 0.1f);
    }
}
