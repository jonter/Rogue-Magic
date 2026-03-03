using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] Room startRoom;

    [SerializeField] int count = 10;
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] passages;

    // Start is called before the first frame update
    void Start()
    {
        CreateDungeon();
    }

    void CreateDungeon()
    {
        GameObject lastRoom = startRoom.gameObject;
        for(int i = 0; i < count; i++)
        {
            GameObject newPassage = Instantiate(passages[0]);
            GameObject newRoom = Instantiate(rooms[0]);

            ExitPoint exitRoom = lastRoom.GetComponentInChildren<ExitPoint>();
            newPassage.transform.position = exitRoom.transform.position;

            ExitPoint exitPassage = newPassage.GetComponentInChildren<ExitPoint>();
            newRoom.transform.position = exitPassage.transform.position;

            lastRoom = newRoom;
        }
    }

    
}
