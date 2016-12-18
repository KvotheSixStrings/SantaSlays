using UnityEngine;
using System.Collections;
using Paraphernalia.Components;

public class ShootingEnemyController : MonoBehaviour {

    
    private GameObject player;
    private Rigidbody2D body;
    private ProjectileLauncher gun;
    public float speed = 1.0F;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        body = GetComponent<Rigidbody2D>();
        gun = GetComponent<ProjectileLauncher>();
    }
    void Update()
    {
        gun.Shoot(player.transform.position - gameObject.transform.position);
    }
    
    void FixedUpdate()
    {       
        body.MovePosition(body.position + -Vector2.right * speed * Time.deltaTime);
    }   
}
