using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject muzzleFlash;

    public float bulletForce = 20f;

    
    // Update is called once per frame
    void Update()
    {
        //Fires the shoot method on fire1 press
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Instantiates the bullet prefab at our firepoint position
        GameObject firedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Locates the rigidbody2d attached to the bullet we just cloned
        Rigidbody2D rb = firedBullet.GetComponent<Rigidbody2D>();
        //Adds some force to the rigidbody in order to shoot
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //Muzzle flash effect
        var effects = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        //Destroy effect after a bit
        Destroy(effects, 1.5f);
    }

    
}
