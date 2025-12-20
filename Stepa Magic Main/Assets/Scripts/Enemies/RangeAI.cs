using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAI : EnemyAI
{

    protected override void ChaseTarget(float distance)
    {
        if(CanThrow(distance) == false)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            if (isBusy == true) return;
            StartCoroutine(AttackCoroutine());
        }

    }

    bool CanThrow(float distance)
    {
        if (distance > attackDistance) return false;
        Vector3 origin = transform.position + new Vector3(0, 1, 0);
        Vector3 originRight = origin + transform.right * 0.2f;
        Vector3 originLeft = origin - transform.right * 0.2f;
        if(CheckRaycast(originLeft) == false) return false;
        if(CheckRaycast(originRight) == false) return false;

        return true;
    }

    bool CheckRaycast(Vector3 origin)
    {

        Vector3 dir = transform.forward;
        LayerMask layers = LayerMask.GetMask("Default", "Player");
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, attackDistance, layers);
        if (hitInfo.transform == null) return false;
        PlayerHealth player = hitInfo.transform.GetComponent<PlayerHealth>();
        if (player == null) return false;
        return true;
    }

}
