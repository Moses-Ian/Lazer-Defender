using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] public Transform pathPrefab;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float timeBetweenEnemySpawns = 1f;

    [SerializeField] List<GameObject> enemyPrefabs;


    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        return pathPrefab.Cast<Transform>().ToList();
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
}
