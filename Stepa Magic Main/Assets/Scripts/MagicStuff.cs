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


    List<IShootModifier> shootModifiers = new List<IShootModifier>();
    List<IProjectileModifier> projModifiers = new List<IProjectileModifier>();

    public void AddShootModif(IShootModifier mod) { shootModifiers.Add(mod); }
    public void AddProjModif(IProjectileModifier mod) { projModifiers.Add(mod); }   

    public void Attack(Vector3 dir)
    {
        Vector3 pos = transform.GetChild(0).position;
        if (shootModifiers.Count > 0)
        {
            foreach (var mod in shootModifiers) mod.OnShoot(this, pos, dir);
        }
        else
        {
            SpawnOneProjectile(dir);

        }

    }

    public void SpawnOneProjectile(Vector3 dir)
    {
        Vector3 pos = transform.GetChild(0).position;
        GameObject proj = Instantiate(projectilePrefab, pos, Quaternion.identity);
        MagicProjectile mp = proj.GetComponent<MagicProjectile>();
        foreach (var mod in projModifiers) mod.OnProjectiteSpawn(mp);

        mp.Launch(this, dir * GetProjSpeed(), GetDamage(), DamageType.Physical);
    }

    //IEnumerator AttackCoroutine(Vector3 dir)
    //{
    // TODO: Смотрим Gemini и переписываем логику атаки наших посохов, чтобы все было согласно
    // принципам SOLID
        
    //}

}
