using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    protected Animator anim;
    protected NavMeshAgent agent;

    protected float maxSpeed;
    protected float currentSpeed;

    protected virtual void OnEnable()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<PlayerHealth>();
        currentSpeed = 0;
        maxSpeed = agent.speed;

        палпатин_который_решил_создать_совет_по_поводу_истребления = GetComponent<EnemyHealth>();
        палпатин_который_решил_создать_совет_по_поводу_истребления.OnDamage += RageEnemy;
    }

    protected virtual void OnDisable()
    {
        палпатин_который_решил_создать_совет_по_поводу_истребления.OnDamage -= RageEnemy;
        agent.destination = transform.position;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rageRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }


    protected virtual void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < rageRadius) isSeen = true;

        if (isSeen == true) ChaseTarget(distance);

        SetWalkAnimation(distance);
    }

    protected virtual void SetWalkAnimation(float distance)
    {
        float realSpeed = agent.desiredVelocity.magnitude / maxSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, realSpeed, Time.deltaTime * 10);

        anim.SetFloat("speed", currentSpeed);
    }

    protected virtual void ChaseTarget(float distance)
    {
        // если расстояние до игрока меньше дистанции атаки (0.9 от дистанции)
        // то он будет останавливаться
        if (distance < attackDistance * 0.9)
        {
            agent.destination = transform.position;
            RotateToPlayer();
        }
        else
            agent.destination = target.transform.position;

        if (distance < attackDistance * 1.5f)
        {
            if (isBusy == true) return;
            StartCoroutine(AttackCoroutine());
        }
    }

    protected void RotateToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,
            Time.deltaTime * 5);
    }


    protected virtual IEnumerator AttackCoroutine()
    {
        anim.SetTrigger("attack");
        isBusy = true;
        yield return new WaitForSeconds(1.5f);
        isBusy = false;
    }



}
