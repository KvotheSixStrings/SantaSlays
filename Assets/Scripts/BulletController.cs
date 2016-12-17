using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


    void Update()
    {
        if (transform.position.y > 10f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        gameObject.SetActive(false);
    }

    void OnBecoameInvisible()
    {
        gameObject.SetActive(false);
    }
}
