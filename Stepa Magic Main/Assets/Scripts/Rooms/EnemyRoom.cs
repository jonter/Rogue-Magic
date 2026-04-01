using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{
    [SerializeField] GameObject enemiesFolder;

    private void Start()
    {
        enemiesFolder.SetActive(false);
    }

    public override void Activate()
    {
        base.Activate();
        enemiesFolder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == false) return;
        if(enemiesFolder.transform.childCount == 0)
        {
            OpenNextPassage();
            activated = false;
        }
        
    }
}
