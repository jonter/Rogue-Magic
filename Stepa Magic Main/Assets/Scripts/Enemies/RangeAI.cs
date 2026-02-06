using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAI : EnemyAI
{
    RockProjectile projectile;

    protected override void OnEnable()
    {
        base.OnEnable();
        projectile = GetComponentInChildren<RockProjectile>();
    }
    protected override void ChaseTarget(float distance)
    {
        if(CanThrow(distance) == false)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
            RotateToPlayer();
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

        Vector3 dir = target.transform.position - origin;
        LayerMask layers = LayerMask.GetMask("Default", "Player");
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, attackDistance, layers);
        if (hitInfo.transform == null) return false;
        PlayerHealth player = hitInfo.transform.GetComponent<PlayerHealth>();
        if (player == null) return false;
        return true;
    }


    public void Throw()
    {
        // TODO: доделать тут функцию
        RockProjectile clone = Instantiate(projectile, projectile.transform.parent);
        clone.Launch(target.transform.position, damage);
        StartCoroutine(HideHandProjCoroutine());
    }

    IEnumerator HideHandProjCoroutine()
    {
        projectile.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        projectile.gameObject.SetActive(true);
    }

}
