using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWave
{
    int GetTypeOFWave(); // 0 WaveConfig, 1 MeteorWaveConfig, ...

    public Transform GetStartingWayPoint();

    public List<Transform> GetWavePoints();


    public float GetMoveSpeed();


    public int getEnemyCount();


    public float GetRandomSpawnTime();
}
