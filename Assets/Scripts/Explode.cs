using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Paraphernalia.Extensions;

public class Explode : MonoBehaviour {

    public Projectile[] shards;
    public int numberOfShardsToSpawn = 8;

    private List<Projectile> shardPool = new List<Projectile>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < numberOfShardsToSpawn; i++)
        {
            Shoot();
        }
    }

    public bool Shoot(Vector3 parentVelocity = default(Vector3))
    {
        int shardIndex = Random.Range(0, shards.Length);
        Vector3 dir = Random.insideUnitCircle * 2;
        Vector3 move = Vector3.right;
        float size = Random.Range(0.2f, 1f);
        if (shards.Length > 0)
        {
            Projectile projectile = shardPool.Find((p) => !p.gameObject.activeSelf);
            if (projectile == null)
            {
                projectile = shards[shardIndex].Instantiate() as Projectile;
                shardPool.Add(projectile);
            }

            if (dir.x <= transform.position.x)
            {
                move = -Vector3.right;
            }
            projectile.gameObject.SetActive(true);
            projectile.Fire(move + dir, parentVelocity);
            projectile.transform.position = gameObject.transform.position + dir;
            projectile.transform.localScale = new Vector3(size, size, size);
            return true;
        }
        return false;
    }
}
