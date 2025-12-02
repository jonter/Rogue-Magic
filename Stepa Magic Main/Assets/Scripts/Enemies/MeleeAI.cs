using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
/// <summary>
/// TODO 11.11.2025
/// Разобраться с анимациями, чтобы остановка/разгон были более плавные
/// Разобраться с атакой, сделать так, чтобы персонаж мог атаковать
/// даже на скорости (при помощи Animator layer).
/// У Степы немного колбасит врага, когда он рядом с игроком))
/// </summary>
public class MeleeAI : EnemyAI
{
    [SerializeField] float rageRadius = 15;
    [SerializeField] float attackDistance = 1.5f;

    [SerializeField] DamageType damageType = DamageType.Physical;
    [SerializeField] float damage = 20;
    
    Animator anim;
    NavMeshAgent agent;
    bool isSeen = false;

    PlayerHealth target;

    float maxSpeed;
    float currentSpeed;

    bool isBusy = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<PlayerHealth>();
        currentSpeed = 0;
        maxSpeed = agent.speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rageRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < rageRadius) isSeen = true;

        if (isSeen == true) ChaseTarget(distance);

        SetAnimation(distance);
    }

    void SetAnimation(float distance)
    {
        float realSpeed = agent.desiredVelocity.magnitude / maxSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, realSpeed, Time.deltaTime * 10);

        anim.SetFloat("speed", currentSpeed);
    }

    void ChaseTarget(float distance)
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

        if(distance < attackDistance * 1.5f)
        {
            if (isBusy == true) return;
            StartCoroutine(AttackAnimCoroutine());
        }
    }

    void RotateToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,
            Time.deltaTime * 5);
    }


    IEnumerator AttackAnimCoroutine()
    {
        anim.SetTrigger("attack");
        isBusy = true;
        yield return new WaitForSeconds(1.5f);
        isBusy = false;
    }

    private void OnDisable()
    {
        agent.destination = transform.position;
    }

    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, 
            target.transform.position);
        if (distance < attackDistance)
            target.GetDamage(damage, damageType);
    }
}
