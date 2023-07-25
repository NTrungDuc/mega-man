using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies2 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myBody;
    Animator anim;
    public float speed = 2f;
    Vector3 vt;
    int h = 1;
    public float hearth = 50;
    void Start()
    {
        anim = GetComponent<Animator>();
        vt= transform.position;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - vt.x > 3)
        {
            h = -1;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x - vt.x < -3)
        {
            h = 1;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        myBody.velocity = new Vector2(h * speed, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            float damage = collision.GetComponent<bulletShot>().bulletDamage;
            hearth -= damage;
            if (hearth == 0)
            {
                anim.SetBool("death", true);
                Destroy(gameObject, 0.5f);
                h = 0;
            }
        }
    }
}
