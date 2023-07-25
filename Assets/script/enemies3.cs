using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies3 : MonoBehaviour
{
    public float idleTime = 0;
    Rigidbody2D rb;
    Animator anim;
    Vector3 vt;
    bool grounded;
    int h = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        vt = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            idleTime+=Time.deltaTime;
            if (idleTime >= 1)
            {
                if (transform.position.x - vt.x > 2)
                {
                    h = -1;
                }else if(transform.position.y - vt.y <= -2)
                {
                    h = 1;
                }
                grounded = false;
                idleTime = 0;
                anim.SetBool("ground", true);
                rb.velocity = new Vector2(h * 2f, 8f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grounded")
        {
            grounded = true;
            anim.SetBool("ground",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet"){
            anim.SetBool("death", true);
            grounded = false;
            Destroy(gameObject,0.5f);
        }
    }
}
