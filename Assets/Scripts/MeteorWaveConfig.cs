using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Meteor Wave config", fileName = "Meteor Wave Config")]
public class MeteorWaveConfig : ScriptableObject
{

    [SerializeField] List<GameObject> enemyPrefabs;

    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenSpans = 1.5f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWavePoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int getEnemyCount()
    {
        int RandomBound = Random.Range(1, 4);

        return RandomBound;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Count - 1)];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpans - spawnTimeVariance, timeBetweenSpans + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
