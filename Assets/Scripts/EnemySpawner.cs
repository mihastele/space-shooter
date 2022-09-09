using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;

    [SerializeField] List<MeteorWaveConfig> meteorWaveConfigs;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] WaveConfigSO currentWave;

    [SerializeField] MeteorWaveConfig currentMeteorWave;
    [SerializeField] bool isLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(DelayFirstRun());


    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        /* do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.getEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWayPoint().position,
                    Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping); */

        do
        {
            int idx = Random.Range(0, waveConfigs.Count - 1);

            currentWave = waveConfigs[idx];
            for (int i = 0; i < currentWave.getEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWayPoint().position,
                Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        } while (isLooping);
    }

    IEnumerator DelayFirstRun()
    {

        yield return new WaitForSeconds(3 + Random.Range(2, 5));
        StartCoroutine(SpawnEnemyMeteorWaves());

    }
    IEnumerator SpawnEnemyMeteorWaves()
    {

        do
        {
            int idx = Random.Range(0, meteorWaveConfigs.Count - 1);

            currentMeteorWave = meteorWaveConfigs[idx];
            for (int i = 0; i < currentWave.getEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                currentMeteorWave.GetStartingWayPoint().position,
                Quaternion.identity, transform);
                yield return new WaitForSeconds(currentMeteorWave.GetRandomSpawnTime());
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        } while (isLooping);
    }
}
