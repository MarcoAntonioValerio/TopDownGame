using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_BulletBehaviour : MonoBehaviour
{
    public GameObject hitEffect;
    
    
    private void Update()
    {
        Destroy(gameObject, 2.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
