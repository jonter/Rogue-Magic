using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagicStuff : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    [HideInInspector] public bool isReloaded = true;
    [SerializeField] float baseDamage = 15;
    [SerializeField] float baseProjectileSpeed = 10;
    [SerializeField] float baseFireRate = 1;

    float damageMult = 1;
    float speedMult = 1;
    float fireRateMult = 1;

    public float GetDamage() { return baseDamage * damageMult; }
    public float GetFireRate() { return baseFireRate * fireRateMult; }
    public float GetProjSpeed() { return baseProjectileSpeed * speedMult; }

    public event Action<float, float> OnShoot;

    List<IShootModifier> shootModifiers = new List<IShootModifier>();
    List<IProjectileModifier> projModifiers = new List<IProjectileModifier>();

    public void AddShootModif(IShootModifier mod) { shootModifiers.Add(mod); }
    public void AddProjModif(IProjectileModifier mod) { projModifiers.Add(mod); }


    public void Attack(Vector3 dir)
    {
        if(shootModifiers.Count > 0)
        {
            foreach (var mod in shootModifiers) mod.OnShoot(this, dir);
        }
        else
        {
            // SpawnOneProjectile()
        }
        
    }

    //IEnumerator AttackCoroutine(Vector3 dir)
    //{
    // TODO: Смотрим Gemini и переписываем логику атаки наших посохов, чтобы все было согласно
    // принципам SOLID
        
    //}

}
