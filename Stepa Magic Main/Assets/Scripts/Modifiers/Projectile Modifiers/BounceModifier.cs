using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceModifier : MonoBehaviour, IProjectileModifier
{
    private void Awake()
    {
        GetComponent<MagicStuff>().AddProjModif(this);
    }

    public void OnProjectiteSpawn(MagicProjectile proj)
    {
        proj.bounceCount += 1;
    }
}
