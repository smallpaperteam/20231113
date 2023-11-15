using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static List<Enemy> EnemiesInGame;
    public static Dictionary<int, GameObject> EnemyPrefabs;
    public static Dictionary<int, Queue<Enemy>> EnemyObjectPools;


    void Start()
    {
        EnemyPrefabs = new Dictionary<int, GameObject>();
        EnemyObjectPools = new Dictionary<int, Queue<Enemy>>();
        EnemiesInGame = new List<Enemy>();

        EnemySpawnData[] enemies = Resources.LoadAll<EnemySpawnData>("Enemy");
        Debug.Log(enemies[0].name);

        foreach(EnemySpawnData enemy in enemies)
        {
            EnemyPrefabs.Add(enemy.EnemyID, enemy.EnemyPrefab);
            EnemyObjectPools.Add(enemy.EnemyID, new Queue<Enemy>());
        }
    }
}
