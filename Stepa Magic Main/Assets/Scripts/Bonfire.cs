using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] float dps = 20;
    [SerializeField] float damageRadius = 0.7f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BurnCoroutine());
    }

    IEnumerator BurnCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        LayerMask layer = LayerMask.GetMask("Player", "Enemy");
        Collider[] colliders = Physics.OverlapSphere(
            transform.position, damageRadius, layer);
        float damage = dps * 0.3f;
        foreach(Collider c in colliders)
        {
            IDamagable obj = c.GetComponent<IDamagable>();
            if (obj != null) obj.GetDamage(damage);
        }
        StartCoroutine(BurnCoroutine());
    }
   
}
