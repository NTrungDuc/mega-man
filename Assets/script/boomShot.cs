using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomShot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform shotPos;
    public GameObject bulletPrefab;
    float timeUntilFire;
    boss pm;
    public float idleTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<boss>();
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;
        if(idleTime >= 2.5)
        {
            if (timeUntilFire < Time.time)
            {
                shot();
                timeUntilFire = Time.time + fireRate;
            }
            idleTime = 0;
        }

    }
    void shot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, shotPos.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
