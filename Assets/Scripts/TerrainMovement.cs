using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TerrainMovement : MonoBehaviour {

    private Rigidbody2D body;
    private float speed = 1;
	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        body.AddForce(-Vector2.right.normalized * speed);
	}

    public void Exit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
