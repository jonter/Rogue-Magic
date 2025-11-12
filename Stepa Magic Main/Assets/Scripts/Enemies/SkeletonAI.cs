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
public class SkeletonAI : EnemyAI
{
    [SerializeField] float rageRadius = 15;
    [SerializeField] float damage = 20;
    [SerializeField] float attackDistance = 1.5f;
    

    Animator anim;
    NavMeshAgent agent;
    bool isSeen = false;

    PlayerHealth target;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = FindAnyObjectByType<PlayerHealth>();
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
        float animSpeed = agent.desiredVelocity.magnitude / agent.speed;
        anim.SetFloat("speed", animSpeed);
    }

    void ChaseTarget(float distance)
    {
        // если расстояние до игрока меньше дистанции атаки (0.9 от дистанции)
        // то он будет останавливаться
        if (distance < attackDistance * 0.9)
            agent.destination = transform.position;
        else 
            agent.destination = target.transform.position;
    }



}
