using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    [SerializeField] float appearTime = 0.5f;
    [SerializeField] float chosenTime = 1;
    [SerializeField] float hoverTime = 0.1f;

    public void Show()
    {
        transform.DOKill();
        transform.DOLocalMoveY(0, appearTime).SetEase(Ease.OutBack).SetUpdate(true);
    }

    public void Hover()
    {
        transform.DOKill();
        transform.DOScale(1.1f, hoverTime).SetEase(Ease.OutElastic).SetUpdate(true);
    }

    public void Unhover()
    {
        transform.DOKill();
        transform.DOScale(1, hoverTime).SetEase(Ease.InSine).SetUpdate(true);
    }

    public void Select()
    {
        transform.DOKill();
        transform.DOLocalMoveY(100, chosenTime / 4).SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutSine).SetUpdate(true);
        transform.DOScale(1.3f, chosenTime / 2).SetDelay(chosenTime / 2)
            .SetEase(Ease.InBounce).SetUpdate(true);

        transform.DOLocalMoveY(1000, appearTime).SetEase(Ease.InSine)
            .SetDelay(chosenTime).SetUpdate(true);
    }

    public void Hide()
    {
        transform.DOKill();
        transform.DOLocalMoveY(-1000, appearTime).SetEase(Ease.InSine).SetUpdate(true);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }

}
