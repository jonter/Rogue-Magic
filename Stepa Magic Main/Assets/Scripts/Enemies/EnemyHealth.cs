using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float hp = 50;
    float maxHp;
    bool alive = true;
    Animator anim;

    public event Action<float> OnDamage;
    public event Action OnDeath;

    void Start()
    {
        maxHp = hp;
        anim = GetComponent<Animator>();
    }

    public void GetDamage(float damage)
    {
        if (alive == false) return;
        hp -= damage;
        anim.SetTrigger("hit");
        if(OnDamage != null) OnDamage(hp/maxHp);

        if (hp < 0.001f)
        {
            Death();
        }
    }

    void Death()
    {
        print("Враг убит");
        if (OnDeath != null) OnDeath();
        GetComponent<EnemyAI>().enabled = false;
        Destroy(gameObject, 10);
        GetComponent<RagdollActivator>().Activate();
    }

  

    
}
