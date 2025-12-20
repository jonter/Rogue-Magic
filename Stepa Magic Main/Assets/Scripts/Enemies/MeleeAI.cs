using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : EnemyAI
{
    
 


   

  

    public void Attack()
    {
        float distance = Vector3.Distance(transform.position, 
            target.transform.position);
        if (distance < attackDistance)
            target.GetDamage(damage, damageType);
    }
}
