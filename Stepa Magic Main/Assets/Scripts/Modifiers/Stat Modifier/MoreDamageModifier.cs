using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreDamageModifier : MonoBehaviour
{
    public float mult = 1.4f;
    private void Awake()
    {
        MagicStuff stuff = GetComponent<MagicStuff>();
        stuff.IncreaseDamage(mult);
    }

}
