using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int health;
	
    void Start()
    {
        health = maxHealth;
    }
    void OnEnable()
    {
        health = maxHealth;
    }
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        health -= 1;
        if(col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
