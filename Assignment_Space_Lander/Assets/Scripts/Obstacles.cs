using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float SpawnTimer;
    public float bulletSpeed;

    private void Start()
    {
        StartCoroutine(BulletSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BulletSpawn()
    {
        while (true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = newBullet.GetComponent<Rigidbody2D>();

            if (rb2d != null)
            {
                rb2d.velocity = new Vector2(bulletSpeed, 0f);
            }
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
