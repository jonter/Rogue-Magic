using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShootModifier : MonoBehaviour, IShootModifier
{
    static int count = 0;
    float timeBetween = 0.2f;

    private void Awake()
    {
        if (count == 0) GetComponent<MagicStuff>().AddShootModif(this);
        count += 1;
    }

    public void OnShoot(MagicStuff weapon, Vector3 pos, Vector3 dir)
    {
        StartCoroutine(ShootCoroutine(weapon, pos, dir));
    }

    IEnumerator ShootCoroutine(MagicStuff weapon, Vector3 pos, Vector3 dir)
    {
        dir *= -1;
        for (int i = 0; i < count; i++)
        {
            weapon.SpawnOneProjectile(dir);
            yield return new WaitForSeconds(timeBetween);
        }
    }


}
