using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStuff : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    public float reloadTime = 1;
    [HideInInspector] public bool isReloaded = true;
    [SerializeField] float damage = 15;
    [SerializeField] float projectileSpeed = 10;

    public void Attack(Vector3 dir)
    {
        StartCoroutine(AttackCoroutine(dir));
    }

    IEnumerator AttackCoroutine(Vector3 dir)
    {
        Vector3 spawnPos = transform.GetChild(0).position;
        GameObject clone = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        MagicProjectile mp = clone.GetComponent<MagicProjectile>();
        mp.Launch(dir * projectileSpeed, damage);
        isReloaded = false;
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
    }

}
