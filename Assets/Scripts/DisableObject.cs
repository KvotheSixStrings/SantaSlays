using UnityEngine;
using System.Collections;

public class DisableObject : MonoBehaviour {

    void Update()
    {
        if (transform.position.y < -1f)
        {
            gameObject.SetActive(false);
        }       
    }
   
}
