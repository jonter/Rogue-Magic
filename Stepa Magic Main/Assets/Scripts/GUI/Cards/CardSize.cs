using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSize : Card
{
    protected override void ApplyModifier()
    {
        MagicStuff stuff = FindAnyObjectByType<MagicStuff>();
        stuff.gameObject.AddComponent<SizeModifier>();
    }
}
