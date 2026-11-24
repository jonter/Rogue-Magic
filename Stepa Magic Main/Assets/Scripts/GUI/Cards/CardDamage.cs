using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDamage : Card
{
    [SerializeField] float damageMult = 1.4f;
    protected override void ApplyModifier()
    {
        MagicStuff stuff = FindAnyObjectByType<MagicStuff>();
        var modif = stuff.gameObject.AddComponent<MoreDamageModifier>();
        modif.mult = damageMult;
    }
}
