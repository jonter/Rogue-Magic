using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : Room
{
    UpgradeBook book;

    public override void Activate()
    {
        base.Activate();
        book = GetComponentInChildren<UpgradeBook>();
        book.OnPickup += OpenNextPassage;
    }

    public override void OpenNextPassage()
    {
        GetComponentInChildren<ExitLevel>().OpenGates();
    }
    
}
