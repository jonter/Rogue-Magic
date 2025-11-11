using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVulnarabilities : MonoBehaviour
{
    [Header("Неуязвимость")]
    [SerializeField] DamageType[] immuneTypes;
    [Header("Сопротивление (-50% урона)")]
    [SerializeField] DamageType[] resistTypes;
    [Header("Уязвимость (х2 урона)")]
    [SerializeField] DamageType[] vulnarTypes;

    public float CalculateDamage(float damage, DamageType dt)
    {
        bool hasImmune = CheckType(immuneTypes, dt);
        if (hasImmune == true) return 0;
        bool hasResist = CheckType(resistTypes, dt);
        if (hasResist == true) return damage / 2;
        bool hasVulnar = CheckType(vulnarTypes, dt);
        if (hasVulnar == true) return damage * 2;

        return damage;
    }

    bool CheckType(DamageType[] types, DamageType dt)
    {
        foreach(DamageType i in types)
        {
            if (i == dt) return true;
        }
        return false;
    }


}
