using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFireRateModifier : MonoBehaviour
{
    public float mult = 1.4f;
    private void Awake()
    {
        MagicStuff stuff = GetComponent<MagicStuff>();
        stuff.IncreaseFireRate(mult);
    }

}
