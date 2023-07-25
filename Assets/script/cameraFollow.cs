using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 0, -1);
        if (Player.position.x <= 0)
        {
            transform.position = new Vector3(0, 0, -1);
        }
        if(Player.position.y < -3)
        {
            transform.position = new Vector3(Player.transform.position.x, -10, -1);
        }
    }

}
