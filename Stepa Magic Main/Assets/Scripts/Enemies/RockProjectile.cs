using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5;
    bool launched = false;
    float damage;
    public virtual void Launch(Vector3 pos, float dam)
    {
        damage = dam;
        launched = true;
        transform.parent = null;
        Vector3 dir = pos - transform.position;
        dir.y = 0;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = dir.normalized * speed;
        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (launched == false) return;
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.GetDamage(damage);
        }
        Destroy(gameObject);
    }


}
