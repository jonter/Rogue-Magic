using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(DamageVulnarabilities))]
public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float hp = 50;
    float maxHp;
    bool alive = true;
    Animator anim;
    DamageVulnarabilities dv;

    public event Action<float> OnDamage;
    public event Action OnDeath;

    [SerializeField] int killCoins = 3;

    void Awake()
    {
        maxHp = hp;
        anim = GetComponent<Animator>();
        dv = GetComponent<DamageVulnarabilities>();
    }

    public void GetDamage(float damage, DamageType dtype = DamageType.Pure)
    {
        if (alive == false) return;
        damage = dv.CalculateDamage(damage, dtype);
        hp -= damage;
        anim.SetTrigger("hit");
        if(OnDamage != null) OnDamage(hp/maxHp);
        DamageTextDisplay.Show(transform.position, damage, dtype);

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
        alive = false;
        GetComponent<Collider>().enabled = false;
        transform.parent = null;
        RewardForKill();
    }

    void RewardForKill()
    {
        CoinsManager.Instance.AddCoins(killCoins);   
    }

  

    
}
