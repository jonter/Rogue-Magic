using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] Room startRoom;

    [SerializeField] int count = 10;

    [SerializeField] RoomContainer container;

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
            GameObject newPassage = Instantiate(container.GetRandomPassage());
            GameObject newRoom = Instantiate(container.GetRandomRoom());

            ExitPoint exitRoom = lastRoom.GetComponentInChildren<ExitPoint>();
            newPassage.transform.position = exitRoom.transform.position;

            ExitPoint exitPassage = newPassage.GetComponentInChildren<ExitPoint>();
            newRoom.transform.position = exitPassage.transform.position;

            lastRoom.GetComponent<Room>().pass = newPassage.GetComponent<Passage>();
            lastRoom = newRoom;

            newPassage.GetComponent<Passage>().nextRoom = newRoom.GetComponent<Room>();
        }
        CreateFinalRoom(lastRoom.GetComponent<Room>());
        FindObjectOfType<NavMeshSurface>().BuildNavMesh();
    }

    void CreateFinalRoom(Room lastRoom)
    {
        GameObject newPassage = Instantiate(container.GetRandomPassage());
        ExitPoint exitPoint = lastRoom.GetComponentInChildren<ExitPoint>();
        newPassage.transform.position = exitPoint.transform.position;
        Passage pass = newPassage.GetComponent<Passage>();
        lastRoom.pass = pass;

        GameObject room = container.GetFinalRoom();
        GameObject final = Instantiate(room);

        Vector3 spawnPos = pass.GetComponentInChildren<ExitPoint>().transform.position;
        final.transform.position = spawnPos;
        pass.nextRoom = final.GetComponent<Room>();
    }


    
}
