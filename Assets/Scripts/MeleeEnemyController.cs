using UnityEngine;
using System.Collections;

public class MeleeEnemyController : MonoBehaviour {

	private GameObject player;
    private Rigidbody2D body;
    public float speed = 1.0F;
    public float turnSpeed = 5f;  
    private bool canCharge;
    private Vector3 dir;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody2D>();  
    }
    void Update()
    {
        if (!canCharge)
        {
            if (gameObject.transform.position.x - player.transform.position.x <= 7)
            {
                canCharge = true;
            }

        }
        dir = player.transform.position - new Vector3(body.position.x, body.position.y, 0);        
    }
    
    void FixedUpdate()
    {
        if (!canCharge)
        {
            body.MovePosition(body.position + -Vector2.right * speed * Time.deltaTime);
            
        }
        else if (gameObject.transform.position.x > player.transform.position.x)
        {
            body.AddForce(dir * speed * 3);
        }
    }   
}
