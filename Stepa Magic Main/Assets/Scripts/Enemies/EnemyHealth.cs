using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float hp = 50;
    float maxHp;
    bool alive = true;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GetDamage(float damage)
    {
        if (alive == false) return;
        hp -= damage;
        anim.SetTrigger("hit");
        // отобразить жизни и урон
        if (hp < 0.001f)
        {
            Death();
        }
    }

    void Death()
    {
        print("Враг убит");
        GetComponent<EnemyAI>().enabled = false;
        Destroy(gameObject);
    }

  

    
}
