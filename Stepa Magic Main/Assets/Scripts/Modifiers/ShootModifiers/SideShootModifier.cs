using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideShootModifier : MonoBehaviour, IShootModifier
{
    static int sideShootCount = 0;

    private void Awake()
    {
        if (sideShootCount == 0) GetComponent<MagicStuff>().AddShootModif(this);
        sideShootCount += 1;
    }

    public void OnShoot(MagicStuff weapon, Vector3 pos, Vector3 dir)
    {
        

        for (int i = 0; i < sideShootCount; i++)
        {
            float angle = 30 * (i + 1);
            Vector3 dir1 = Quaternion.AngleAxis(-angle, Vector3.up) * dir;
            Vector3 dir2 = Quaternion.AngleAxis(angle, Vector3.up) * dir;

            weapon.SpawnOneProjectile(dir1);
            weapon.SpawnOneProjectile(dir2);
        }

    }
}
