using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Passage pass;
    protected bool activated = false;

    public virtual void Activate()
    {
        activated = true;
        // включить ИИ всем врагами или заспаунить их и т.п.
    }

    public virtual void OpenNextPassage()
    {
        pass.GetComponentInChildren<Door>().Open();
        print(pass.nextRoom.name);
        if (pass.nextRoom == null) return;
        pass.nextRoom.Activate();
    }
    
}
