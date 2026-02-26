using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IDamagable
{
    bool isOpen = false;
    [SerializeField] float openAnimTime = 0.5f;
    [SerializeField] float rotationY = -90;
    bool isTwitching = false;
    float twitchTime = 0.2f;
    public void GetDamage(float damage, DamageType dtype = DamageType.Pure)
    {
        if (isOpen == true) return;
        if (isTwitching == true) return;

        isTwitching = true;
        Vector3 rot = new Vector3(0, rotationY/10, 0);
        transform.DOLocalRotate(rot, twitchTime).SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutSine).OnComplete(EnableTwitch);

    }

    void EnableTwitch() { isTwitching = false; }

    public void Open()
    {
        if (isOpen == true) return;
        transform.DOKill();
        isOpen = true;
        Vector3 rot = new Vector3(0, rotationY, 0);
        transform.DOLocalRotate(rot, openAnimTime).SetEase(Ease.OutBack);
    }


    private void OnDisable()
    {
        transform.DOKill();
    }
}
