using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Camera mycam;
    [SerializeField] float rotationSpeed = 10;
    PlayerAimPoint aimPoint;
    // Start is called before the first frame update
    void Start()
    {
        aimPoint = GetComponentInChildren<PlayerAimPoint>();
        mycam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Aim();
            aimPoint.Aim();
        }
        else
        {
            aimPoint.Return();
        }
    }

    void Aim()
    {
        Ray r = mycam.ScreenPointToRay(Input.mousePosition);
        LayerMask layer = LayerMask.GetMask("Aim");
        RaycastHit hitInfo;
        Physics.Raycast(r, out hitInfo, 100, layer);
        if (hitInfo.transform == null) return;
        RotateToAim(hitInfo.point);
    }

    void RotateToAim(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot = Quaternion.Euler(0, rot.eulerAngles.y ,0);
        transform.rotation = Quaternion.Slerp(transform.rotation, 
            rot, Time.deltaTime * rotationSpeed);
    }
}
