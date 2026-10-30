using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceModifier : MonoBehaviour, IProjectileModifier
{
    private void Awake()
    {
        GetComponent<MagicStuff>().AddProjModif(this);
    }

    public void OnProjectiteSpawn(MagicProjectile proj)
    {
        proj.canPierce = true;
    }
}
