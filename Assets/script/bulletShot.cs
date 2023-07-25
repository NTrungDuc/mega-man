using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShot : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed = 15f;
    public float bulletDamage = 10;
    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemrobot")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "grounded")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enemies")
        {
            Destroy(gameObject);
        }
    }
}
