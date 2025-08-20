using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestStatue : MonoBehaviour, IDamagable
{
    [SerializeField] float hp = 100;
    public void GetDamage(float damage)
    {
        hp -= damage;
        transform.DOScale(0.9f, 0.1f).SetLoops(2, LoopType.Yoyo);

        if(hp < 0.001f)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}
