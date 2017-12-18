using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot:MonoBehaviour { 
public GameObject bulletPrefab;
public Transform bulletSpawn;
public Transform sightStart, sightEnd;
public bool spotted = false;

void Update()
{
    RayCasting();
    Behaviours();
}

void RayCasting()
{
    Debug.DrawLine(sightStart.position, sightEnd.position, Color.red);
    spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
}

void Behaviours()
{
    if (spotted == true)
    {
        //Invoke("Fire", cooldownTimer);
        Fire();
    }
    else if (spotted == false)
    {
        //CancelInvoke ();
    }
}

void Fire()
{
    GameObject bullet = (GameObject)Instantiate(bulletPrefab);
    //GameObject bullet = objectPool.GetPooledObject (); 
    bullet.transform.position = transform.position;
    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 14;
    Destroy(bullet, 2.0f);
}
}