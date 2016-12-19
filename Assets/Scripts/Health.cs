using UnityEngine;
using System.Collections;
using Paraphernalia.Components;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int health;
    public bool hasShield;
    public GameObject[] powerUps;
    public GameObject losePrompt;
	
    void Awake()
    {
        health = maxHealth;
        if(gameObject.tag == "Player")
        {
            losePrompt.SetActive(false);
        }

    }
    void OnEnable()
    {
        health = maxHealth;
    }
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            if(gameObject.tag == "Enemy")
            {
                AudioManager.PlayVariedEffect("angry_cat");
                ScoreManager.AddToScore(10);
                if (powerUps != null)
                {
                    float rng = Random.Range(0f, 1f);
                    if (rng <= 0.25f)
                    {
                        int rngIndex = Random.Range(0, powerUps.Length);
                        GameObject present = Instantiate(powerUps[rngIndex]);
                        present.transform.position = gameObject.transform.position;
                    }
                }                
            }
            else if(gameObject.tag == "Player")
            {
                losePrompt.SetActive(true);
            }
            gameObject.SetActive(false);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!hasShield)
        {
            health -= 1;
            if (gameObject.tag == "Player")
            {
                ScoreManager.subtractFromHealth(1);
            }
        }

        if(col.gameObject.tag == "Player")
        {
            AudioManager.PlayVariedEffect("SantaHit");
            gameObject.SetActive(false);
        }
    }
}
