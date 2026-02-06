using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] DamageType dType = DamageType.Physical;
    protected bool launched = false;
    float damage;
    public virtual void Launch(Vector3 pos, float dam)
    {
        GetComponentInChildren<TrailRenderer>().emitting = true;
        damage = dam;
        launched = true;
        transform.parent = null;
        Vector3 dir = pos - transform.position;
        dir.y = 0;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = dir.normalized * speed;
        Destroy(gameObject, 8);
        rb.angularVelocity = Random.insideUnitSphere * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (launched == false) return;
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.GetDamage(damage, dType);
        }
        Destroy(gameObject);
    }


}
