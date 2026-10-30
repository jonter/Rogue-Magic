using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuoShootModifier : MonoBehaviour, IShootModifier
{
    // TODO: продолжаем здесь. 
    // скорее всего придется SpawnOneProjectile() оставить внутри MagicStuff
    static int extraCount = 0;
    float timeBetween = 0.2f;
    private void Awake()
    {
        if (extraCount == 0) GetComponent<MagicStuff>().AddShootModif(this);
        extraCount += 1;
    }

    public void OnShoot(MagicStuff weapon, Vector3 pos, Vector3 dir)
    {
        weapon.SpawnOneProjectile(dir);
        StartCoroutine(ShootExtraCoroutine(weapon, dir));
    }

    IEnumerator ShootExtraCoroutine(MagicStuff weapon, Vector3 dir)
    {
        for(int i = 0; i < extraCount; i++)
        {
            yield return new WaitForSeconds(timeBetween);
            weapon.SpawnOneProjectile(dir);
        }
    }
}
