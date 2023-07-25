using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enembulletShot : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float bulletSpeed = 15f;
    public float bulletDamage = 10;
    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
