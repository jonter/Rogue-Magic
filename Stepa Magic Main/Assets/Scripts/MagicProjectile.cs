using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class MagicProjectile : MonoBehaviour
{
    float damage = 10;
    [SerializeField] DamageType damageType = DamageType.Pure;


    public int bounceCount = 0;
    public bool canPierce = false;
    MagicStuff owner;
    Rigidbody rb;
    
    public void Launch(MagicStuff stuff,Vector3 velocity, float damage, DamageType dt)
    {
        owner = stuff;
        damageType = dt;
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;

        Destroy(gameObject, 20);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger ==  true) return;
        IDamagable obj = other.GetComponent<IDamagable>();
        if(obj != null) HitEnemy(obj);
    }

    void HitEnemy(IDamagable obj)
    {
        obj.GetDamage(damage, damageType);
        if (canPierce == false) Destroy(gameObject);
        
    }

    void HitObstacle()
    {
        if(bounceCount > 0)
        {
            Bounce();
            bounceCount--;
        }
        else Destroy(gameObject);
    }

    void Bounce()
    {
        float speed = rb.velocity.magnitude;
        Vector3 dir = rb.velocity.normalized;
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, dir,  out hitInfo, 3);
        if (hitInfo.transform == null) return;
        Vector3 reflect = Vector3.Reflect(dir, hitInfo.normal);
        reflect.y = 0;
        reflect *= speed;
        rb.velocity = reflect;
    }


    private void Update()
    {
        LayerMask layer = LayerMask.GetMask("Default");
        
        Vector3 dir = rb.velocity.normalized;
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, dir, out hitInfo, 0.5f, layer);
        if (hitInfo.transform == null) return;
        if (hitInfo.collider.isTrigger == true) return;

        HitObstacle();
    }

}
