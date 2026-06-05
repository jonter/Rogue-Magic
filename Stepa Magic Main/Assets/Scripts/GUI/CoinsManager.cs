using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    RectTransform myrect;
    TMP_Text mytext;

    int coins = 0;
    public int GetCoins() { return coins; }
    Vector2 startPos;

    public static CoinsManager Instance;

    [SerializeField] float animTime = 0.2f;
    [SerializeField] float yOffset = 30;

    bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        myrect = GetComponent<RectTransform>();
        mytext = GetComponentInChildren<TMP_Text>();
        startPos = myrect.anchoredPosition;
        mytext.text = "" + coins;
    }

    public void AddCoins(int add)
    {
        coins += add;
        mytext.text = "" + coins;
        MakeAnim();
    }

    public bool SpendCoins(int price)
    {
        if(price > coins)
        {
            // играем негативную анимацию и звук
            return false;
        }

        coins -= price;
        mytext.text = "" + coins;
        MakeAnim();
        return true;
    }

    void MakeAnim()
    {
        if (isAnimating == true) return;
        isAnimating = true;
        float yPos = myrect.anchoredPosition.y + yOffset;
        myrect.DOAnchorPosY(yPos, animTime).SetLoops(2, LoopType.Yoyo).OnComplete(EnableAnim);
    }

    void EnableAnim() { isAnimating = false; }

    private void OnDisable()
    {
        myrect.DOKill();
    }

}
