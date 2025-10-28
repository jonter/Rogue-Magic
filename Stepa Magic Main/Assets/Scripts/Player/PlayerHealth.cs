using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    float hp = 100;
    float maxHp;

    bool alive = true;
    public event Action OnDeath;
    public event Action<float, float> OnDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
        
    }

    public void GetDamage(float damage, DamageType dtype = DamageType.Pure)
    {
        if (alive == false) return;
        hp -= damage;
        DamageTextDisplay.Show(transform.position, damage, dtype);
        if (OnDamage != null) OnDamage(hp, maxHp);
        if(hp < 0.001f)
        {
            Death();
        }

    }

    void Death()
    {
        // эпичная смерть (анимация или рэгдол)
        alive = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAim>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        if(OnDeath != null) OnDeath();
    }
    
}
