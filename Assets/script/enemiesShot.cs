using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesShot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform shotPos;
    public GameObject bulletPrefab;
    float timeUntilFire;
    enemies4 pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<enemies4>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( timeUntilFire < Time.time)
        {
            shot();
            timeUntilFire = Time.time + fireRate;
        }
    }
    void shot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, shotPos.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
