using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies4 : MonoBehaviour
{
    [HideInInspector] public bool isFacingRight = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
