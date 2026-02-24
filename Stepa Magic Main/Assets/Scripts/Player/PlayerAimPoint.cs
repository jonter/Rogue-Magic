using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAimPoint : MonoBehaviour
{
    Vector3 startPos = new Vector3(0, 1, 0);
   
    [SerializeField] float distance = 2;
    [SerializeField] float animTime = 0.5f;

    bool isAim = false;
    private void OnDisable()
    {
        transform.DOKill();
    }

    public void Aim()
    {
        if (isAim == true) return;
        isAim = true;
        Vector3 endPos = startPos + new Vector3(0, 0, distance);
        transform.DOLocalMove(endPos, animTime);
    }

    public void Return()
    {
        if(isAim == false) return;
        isAim = false;
        transform.DOLocalMove(startPos, animTime);
    }


}
