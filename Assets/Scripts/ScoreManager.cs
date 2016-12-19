using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public Text scoreText;    
    public int score = 0;
    public Text healthText;
    public int health;
    private Health playerHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            GameObject.Destroy(gameObject);
        }
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        health = playerHealth.health;
    }

    void Start()
    {        
        SetHealthText();
        SetScoreText();
    }

    public static void AddToScore(int amount)
    {
        instance.score += amount;
        instance.SetScoreText();
    }

    

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public static void subtractFromHealth(int amount)
    {
        instance.health -= amount;
        instance.SetHealthText();
    }



    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

}
