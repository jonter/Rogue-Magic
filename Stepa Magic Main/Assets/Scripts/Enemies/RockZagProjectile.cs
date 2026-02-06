using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockZagProjectile : RockProjectile
{
    [SerializeField] float degree = 25;
    [SerializeField] float period = 0.3f;
    Rigidbody rb;
    public override void Launch(Vector3 pos, float dam)
    {
        base.Launch(pos, dam);
        rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.AngleAxis(degree, Vector3.up) * rb.velocity;
        StartCoroutine(ZigZagCoroutine());
    }

    IEnumerator ZigZagCoroutine()
    {
        yield return new WaitForSeconds(period);
        degree *= -1;
        rb.velocity = Quaternion.AngleAxis(degree*2, Vector3.up) * rb.velocity;
        StartCoroutine(ZigZagCoroutine());
    }
}
