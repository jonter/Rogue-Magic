using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float maxSpeed = 8;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        HandleAnim();
    }

    void MovePlayer()
    {
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(inputX, 0, inputZ);
        if(dir.magnitude > 1) dir = dir.normalized;
        rb.velocity = dir * maxSpeed;
    }

    void HandleAnim()
    {
        float currentSpeed = rb.velocity.magnitude / maxSpeed;
        anim.SetFloat("speed", currentSpeed);

        Vector3 forward = transform.forward;
        Vector3 vel = rb.velocity;
        float angle = Vector3.Angle(forward, vel);
        float dot = Vector3.Dot(vel, transform.right);
        if (dot < 0) angle = -angle;
        
        anim.SetFloat("rotation", angle);
    }
}
