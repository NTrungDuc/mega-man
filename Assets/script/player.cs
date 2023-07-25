using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Text txtscore;
    float score=0;
    Rigidbody2D rb;
    Animator anim;
    public float speed = 5f;
    bool grounded;
    public float jumpHeight = 8f;
    bool idle;
    bool run;
    public Slider hearth;
    float hp = 60;
    [HideInInspector] public bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hearth.value = hp;
        Move();
        PlayerShot();
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        if (h > 0)
        {
            run = true;
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            anim.SetBool("speed", true);
            anim.SetBool("runS", false);
            isFacingRight = true;
        }
        else if (h < 0)
        {
            run = true;
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
            anim.SetBool("speed", true);
            anim.SetBool("runS", false);
            isFacingRight= false;
        }
        else if (h == 0)
        {
            idle = true;
            anim.SetBool("speed", false);
            anim.SetBool("idleS", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                idle = false;
                grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                anim.SetBool("ground", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
            anim.SetBool("dash", true);
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
            anim.SetBool("dash", false);
        }
    }
    
    void PlayerShot()
    {
        if (Input.GetMouseButton(0))
        {
            if (idle)
            {
                idle = false;
                anim.SetBool("idleS",true);
                anim.SetBool("runS", false);
            }
            else if (run)
            {
                run = false;
                anim.SetBool("idleS", false);
                anim.SetBool("runS", true);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "grounded" || collision.gameObject.tag == "plank" || collision.gameObject.tag == "box")
        {
            grounded = true;
            anim.SetBool("ground", false);
        }
        if (collision.gameObject.tag == "enemies")
        {
            hp -= 10;
        }
        if (collision.gameObject.tag == "enemrobot")
        {
            hp -= 10;
        }
        if(collision.gameObject.tag == "arrow")
        {
            hp -= 10;
            grounded = true;
            anim.SetBool("ground", false);
        }
        if(collision.gameObject.tag == "gate")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag == "gateA")
        {
                transform.position = new Vector3(-7,- 6, 0);
        }
        if (collision.gameObject.tag == "gateB")
        {
            transform.position = new Vector3(95.5f, -0.5f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enembullet"))
        {
            float damege = collision.GetComponent<enembulletShot>().bulletDamage;
            hp -= damege;
        }
        if(collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject,0.4f);
            score += 10;
            txtscore.text = score.ToString();
        }
        if (collision.gameObject.tag == "star")
        {
            Destroy(collision.gameObject, 1f);
            hp += 10;
        }
        if (collision.gameObject.tag == "box")
        {
            score += 20;
            txtscore.text = score.ToString();
        }
    }
}
