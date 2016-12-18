using UnityEngine;
using System.Collections;

public class DisableObject : MonoBehaviour {

    private Camera cam;

    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if(viewPos.x < 0)
        {
            gameObject.SetActive(false);
        }
    }
   
}
