using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping = true;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                        currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform
                    );

                    yield return new WaitForSeconds(currentWave.timeBetweenEnemySpawns);
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }

}
