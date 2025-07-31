using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    float damage = 10;
    public void Launch(Vector3 velocity, float damage)
    {
        this.damage = damage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;

        Destroy(gameObject, 10);
    }

    
}
