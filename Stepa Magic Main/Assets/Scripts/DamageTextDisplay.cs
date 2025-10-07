using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DamageTextDisplay : MonoBehaviour
{
    static DamageTextPool pool;
    private void Awake()
    {
        pool = GetComponent<DamageTextPool>();
    }

    public static void Show(Vector3 pos, float num)
    {
        DamageText text = pool.Get();
        text.Show(pos, num);
    }

    public static void Show(Vector3 pos, float num, Color c)
    {
        DamageText text = pool.Get();
        text.Show(pos, num, c);
    }


    public static void Return(DamageText text)
    {
        pool.Return(text);
    }

}
