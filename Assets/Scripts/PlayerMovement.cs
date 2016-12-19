using UnityEngine;
using System.Collections;
using Paraphernalia.Components;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10.0F;
    public ProjectileLauncher[] guns;
    public GameObject shield;
	private Camera cam;
    private Health health;

	void Start()
	{
        cam = GameObject.FindObjectOfType<Camera>();
        shield.SetActive(false);
        health = GetComponent<Health>();
	}

    void Update() {
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.02f, 0.98f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
        transform.position = cam.ViewportToWorldPoint(viewPos);

        if(Input.GetButton("Fire1"))
        {
            foreach(ProjectileLauncher gun in guns)
            {
                if(gun.gameObject.activeSelf)
                {
                    gun.Shoot(Vector3.right);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CandyCane")
        {
            AudioManager.PlayVariedEffect("PowerUp");
            foreach (ProjectileLauncher gun in guns)
            {
                gun.gameObject.SetActive(false);
                if(gun.gunName == "CandyCane")
                {
                    gun.gameObject.SetActive(true);
                }
            }
            
        }
        if (collision.gameObject.tag == "Ordiment")
        {
            AudioManager.PlayVariedEffect("PowerUp");
            foreach (ProjectileLauncher gun in guns)
            {
                gun.gameObject.SetActive(false);
                if (gun.gunName == "Ordiment")
                {
                    gun.gameObject.SetActive(true);
                }
            }
        }
        if (collision.gameObject.tag == "Shield")
        {
            AudioManager.PlayVariedEffect("PowerUp");
            shield.SetActive(true);
            health.hasShield = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if(shield.activeSelf == true)
            {
                health.hasShield = false;
                shield.SetActive(false);
            }
            else
            {
                foreach (ProjectileLauncher gun in guns)
                {
                    gun.gameObject.SetActive(false);
                }
                guns[0].gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            if (shield.activeSelf == true)
            {
                health.hasShield = false;
                shield.SetActive(false);
            }
            else
            {
                foreach (ProjectileLauncher gun in guns)
                {
                    gun.gameObject.SetActive(false);
                }
                guns[0].gameObject.SetActive(true);
            }
        }
        if(collision.gameObject.tag != "Terrain")
        {
            collision.gameObject.SetActive(false);
        }

    }
}
