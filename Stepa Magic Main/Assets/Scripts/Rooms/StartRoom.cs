using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom : Room
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Activate();
        yield return new WaitForSeconds(1);
        OpenNextPassage();
    }

    
}
