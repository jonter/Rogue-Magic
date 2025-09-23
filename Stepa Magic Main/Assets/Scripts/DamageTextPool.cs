using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    Queue<DamageText> pool;

    private void Awake()
    {
        pool = new Queue<DamageText>();
        for(int i = 0; i < 5; i++)
        {
            CreateText();
        }
    }

    void CreateText()
    {
        GameObject newText = Instantiate(textPrefab, transform);
        DamageText text = newText.GetComponent<DamageText>();
        pool.Enqueue(text);
        newText.SetActive(false);
    }

    public void Return(DamageText t)
    {
        t.gameObject.SetActive(false);
        pool.Enqueue(t);
    }

    public DamageText Get()
    {
        if (pool.Count == 0) CreateText();
        DamageText t = pool.Dequeue();
        t.gameObject.SetActive(true);
        return t;
    }

    

}
