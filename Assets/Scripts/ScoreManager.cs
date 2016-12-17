using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public Text scoreText;    
    public int score = 0;

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
    }

    void Start()
    {
        SetScoreText();
    }

    public static void AddToScore(int amount)
    {
        instance.score += amount;
        instance.SetScoreText();
    }

    

    void SetScoreText()
    {
        scoreText.text = "Score\n" + score;
    }
        
}
