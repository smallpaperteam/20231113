using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool LoopShouldEnd;

    private void Start()
    {
        EnemySpawner.Init();
    }

    IEnumerable GameLoop()
    {
        while(LoopShouldEnd == false)
        {

        }

    }


    void Update()
    {
        
    }



   
}
