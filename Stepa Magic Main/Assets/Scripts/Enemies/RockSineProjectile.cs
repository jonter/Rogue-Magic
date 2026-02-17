using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSineProjectile : RockProjectile
{
    [SerializeField] float period = 1;
    [SerializeField] float amplitude = 10;
    Rigidbody rb;
    float timer = 0;
    public override void Launch(Vector3 pos, float dam)
    {
        rb = GetComponent<Rigidbody>();
        base.Launch(pos, dam);
    }

    private void Update()
    {
        if (launched == false) return;
        timer += Time.deltaTime;
        float sine = Mathf.Cos(timer * period) * amplitude * Time.deltaTime;
        rb.velocity = Quaternion.Euler(0, sine, 0) * rb.velocity;
    }

}
