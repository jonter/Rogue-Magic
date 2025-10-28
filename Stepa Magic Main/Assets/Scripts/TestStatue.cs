using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestStatue : MonoBehaviour, IDamagable
{
    public void GetDamage(float damage, DamageType dtype = DamageType.Pure)
    {
        transform.DOScale(0.9f, 0.1f).SetLoops(2, LoopType.Yoyo);
        Color c = new Color(0.78f, 0.74f, 0.63f);
        Vector3 pos = transform.position + new Vector3(0, 1, 0);
        DamageTextDisplay.Show(pos, damage, dtype);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
