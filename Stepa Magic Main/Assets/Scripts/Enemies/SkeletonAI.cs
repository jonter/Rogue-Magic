using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : EnemyAI
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("speed", 0);
        yield return new WaitForSeconds(3);
        anim.SetFloat("speed", 1);
        yield return new WaitForSeconds(3);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(3);
        StartCoroutine(Start());
    }

    
}
