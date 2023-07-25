using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinbox : MonoBehaviour
{
    Animator anim;
    public GameObject coinBox;
    AudioSource coin;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("change", true);
            coinBox.SetActive(true);
            Destroy(coinBox,0.5f);
            coin.enabled = true;
        }
    }
}
