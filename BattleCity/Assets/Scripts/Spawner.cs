using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] tanks;
    GameObject tank;
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameObject enemyTank, playerTank;

    enum tankType
    {
        enemyTank
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            tanks = new GameObject[1] { playerTank };
        }
        else
        {
            tanks = new GameObject[1] { enemyTank };
        }
    }

    public void StartSpawning()
    {
        if (!isPlayer)
        {
            List<int> tankToSpawn = new List<int>();
            tankToSpawn.Clear();
            if (LevelManager.enemyTanks > 0) tankToSpawn.Add((int)tankType.enemyTank);
            int tankID = tankToSpawn[Random.Range(0, tankToSpawn.Count)];
            tank = Instantiate(tanks[tankID], transform.position, transform.rotation);

            if (tankID == (int)tankType.enemyTank) LevelManager.enemyTanks--;
        }
        else
        {
        tank = Instantiate(tanks[Random.Range(0, tanks.Length)], transform.position, transform.rotation);
        }
    }

    public void SpawnNewTank()
    {
        if (tank != null) tank.SetActive(true);
    }
}
