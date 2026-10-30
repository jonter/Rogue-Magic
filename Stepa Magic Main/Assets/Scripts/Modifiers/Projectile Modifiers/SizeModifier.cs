using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModifier : MonoBehaviour, IProjectileModifier
{
    private void Awake()
    {
        GetComponent<MagicStuff>().AddProjModif(this);
    }

    public void OnProjectiteSpawn(MagicProjectile proj)
    {
        proj.transform.localScale *= 1.5f;
    }
}
