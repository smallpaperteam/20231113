using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static List<Enemy> EnemiesInGame;
    public static Dictionary<int, GameObject> EnemyPrefabs;
    public static Dictionary<int, Queue<Enemy>> EnemyObjectPools;

    private static bool IsInitialized;

    void Start()
    {
        if (!IsInitialized)
        {
            EnemyPrefabs = new Dictionary<int, GameObject>();
            EnemyObjectPools = new Dictionary<int, Queue<Enemy>>();
            EnemiesInGame = new List<Enemy>();

            EnemySpawnData[] enemies = Resources.LoadAll<EnemySpawnData>("Enemy");
            Debug.Log(enemies[0].name);

            foreach (EnemySpawnData enemy in enemies)
            {
                EnemyPrefabs.Add(enemy.EnemyID, enemy.EnemyPrefab);
                EnemyObjectPools.Add(enemy.EnemyID, new Queue<Enemy>());
            }

            IsInitialized = true;
        }
        else
        {
            Debug.Log("Entity spawned, calss Is Initialized");
        }
    }

    public static Enemy SpawnEnemy(int EnemyID)
    {
        Enemy SpawnedEnemy = null;

        if(EnemyPrefabs.ContainsKey(EnemyID))
        {
            Queue<Enemy> ReferencedQuene = EnemyObjectPools[EnemyID];

            if(ReferencedQuene.Count >0)
            {
                SpawnedEnemy = ReferencedQuene.Dequeue();
                SpawnedEnemy.Init();
            }
            else
            {
                GameObject NewEnemy = Instantiate(EnemyPrefabs[EnemyID], Vector3.zero, Quaternion.identity);
                SpawnedEnemy = NewEnemy.GetComponent<Enemy>();
            }
        }
        else
        {
            Debug.Log($"ENTITYSUMMONER : ENEMY WITH ID OF {EnemyID} DOES NOT EXIST!");
            return null;
        }

        return SpawnedEnemy;
    }
}
 