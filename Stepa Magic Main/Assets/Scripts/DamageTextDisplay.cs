using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DamageTextDisplay : MonoBehaviour
{
    static DamageTextPool pool;
    [Tooltip("0 - Physics, 1 - Pure, 2 - Saint, \n3 - Fire, 4 - Frozen, 5 - Electro")]
    [SerializeField] Color[] damageColors;
    static DamageTextDisplay instance;

    private void Awake()
    {
        pool = GetComponent<DamageTextPool>();
        instance = this;
    }

    public static void Show(Vector3 pos, float num, DamageType dtype)
    {
        DamageText text = pool.Get();
        Color c = ChooseColor(dtype);
        text.Show(pos, num, c);
    }

    static Color ChooseColor(DamageType dt)
    {
        int index = (int)dt;
        return instance.damageColors[index];
    }


    public static void Return(DamageText text)
    {
        pool.Return(text);
    }

}
