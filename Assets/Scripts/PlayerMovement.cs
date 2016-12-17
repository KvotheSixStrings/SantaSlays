using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10.0F;
	private Camera cam;

	void Start()
	{
        cam = GameObject.FindObjectOfType<Camera>();
	}

    void Update() {
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.02f, 0.98f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
        transform.position = cam.ViewportToWorldPoint(viewPos);
    }
}
