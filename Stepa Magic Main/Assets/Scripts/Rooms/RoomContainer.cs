using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomContainer : ScriptableObject
{
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] passages;

    public GameObject GetRandomRoom()
    {
        int r = Random.Range(0, rooms.Length);
        return rooms[r];
    }

    public GameObject GetRandomPassage()
    {
        int r = Random.Range(0, passages.Length);
        return passages[r];
    }
    
}
