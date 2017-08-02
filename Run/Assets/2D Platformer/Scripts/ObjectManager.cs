using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager> {

    public List<iBaseGame> listGameUpdate = new List<iBaseGame>();
    void Start()
    {
        for(int i=0;i< listGameUpdate.Count;i++)
        {
            listGameUpdate[i].Initiate();
        }
    }
    void Update()
    {
        for(int i=0;i< listGameUpdate.Count;i++)
        {
            listGameUpdate[i].UpdateGame(Time.deltaTime);
        }
    }
}
