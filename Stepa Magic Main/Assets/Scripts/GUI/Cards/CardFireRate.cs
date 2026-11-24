using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFireRate : Card
{
    protected override void ApplyModifier()
    {
        MagicStuff stuff = FindAnyObjectByType<MagicStuff>();
        stuff.gameObject.AddComponent<MoreFireRateModifier>();
    }
}
