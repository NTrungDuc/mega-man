using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    [HideInInspector] public bool isFacingRight = true;
    Rigidbody2D rb;
    Vector3 vt;
    public float idleTime = 0;
    int h = 1;
    public float speed = 2f;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vt=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            idleTime += Time.deltaTime;
            if (idleTime > 2)
            {
                if (transform.position.x - vt.x > 2)
                {
                    h = -1;
                    isFacingRight = false;
                    gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (transform.position.y - vt.y <= -2)
                {
                    h = 1;
                    isFacingRight = true;
                    gameObject.transform.localScale = new Vector3(-1, 1, 1);
                }
                grounded = false;
                idleTime = 0;
                rb.velocity = new Vector2(h * 2f, 10f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grounded")
        {
            grounded = true;
        }
    }
}
