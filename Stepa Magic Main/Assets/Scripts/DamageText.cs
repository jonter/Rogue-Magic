using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageText : MonoBehaviour
{
    TMP_Text mytext;
    Color textcolor;
    [SerializeField] float animTime = 0.3f;


    private void Awake()
    {
        mytext = GetComponent<TMP_Text>();
        textcolor = mytext.color;
    }

    public void Show(Vector3 pos, float num)
    {
        mytext.color = textcolor;
        transform.position = pos;
        mytext.text = "" + num;
        StartCoroutine(PlayAnimCoroutine());
    }

    IEnumerator PlayAnimCoroutine()
    {
        Vector3 endPos = transform.position + transform.up * Random.Range(0.5f, 1.5f)
            + transform.right * Random.Range(-1.5f, 1.5f);
        transform.DOMove(endPos, animTime);
        yield return new WaitForSeconds(animTime / 2);
        Color c = textcolor;
        c.a = 0;
        mytext.DOColor(c, animTime / 2);
        yield return new WaitForSeconds(animTime / 2);
        transform.DOKill();
        mytext.DOKill();
        // отключаем текст и возвращаем его обратно в Object Pool
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyHealth enemy = FindFirstObjectByType<EnemyHealth>();
            Vector3 pos = enemy.transform.position + new Vector3(0, 3, 0);
            Show(pos, 15);
        }
    }
}
