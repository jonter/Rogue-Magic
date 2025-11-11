using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicProjectile : MonoBehaviour
{
    float damage = 10;
    [SerializeField] DamageType damageType = DamageType.Pure;
    
    public void Launch(Vector3 velocity, float damage)
    {
        this.damage = damage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;

        Destroy(gameObject, 10);

    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable obj = other.GetComponent<IDamagable>();
        if (obj != null) obj.GetDamage(damage, damageType);
        Destroy(gameObject);
    }


}
