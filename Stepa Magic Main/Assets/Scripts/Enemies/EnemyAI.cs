using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    [SerializeField] protected float rageRadius = 15;
    [SerializeField] protected float attackDistance = 1.5f;
    [SerializeField] protected DamageType damageType = DamageType.Physical;
    [SerializeField] protected float damage = 20;

    protected bool isSeen = false;
    protected PlayerHealth target;

    protected bool isBusy = false;
    protected EnemyHealth палпатин_который_решил_создать_совет_по_поводу_истребления;

    protected virtual void OnEnable()
    {
        target = FindAnyObjectByType<PlayerHealth>();
        палпатин_который_решил_создать_совет_по_поводу_истребления = GetComponent<EnemyHealth>();
        палпатин_который_решил_создать_совет_по_поводу_истребления.OnDamage += RageEnemy;
    }

    protected virtual void OnDisable()
    {
        палпатин_который_решил_создать_совет_по_поводу_истребления.OnDamage -= RageEnemy;
    }

    protected virtual void RageEnemy(float damage)
    {
        if (isSeen == true) return;
        isSeen = true;
        EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
        foreach (EnemyAI e in enemies)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance <= rageRadius) e.CalmRage();
        }
    }

    public void CalmRage()
    {
        isSeen = true;
    }

}
