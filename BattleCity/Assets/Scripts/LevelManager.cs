using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int enemyTanksInThisLevel, playerAITanksInThisLevel, stageNumber;
    public static int enemyTanks, playerAITanks;
    [SerializeField]
    float spawnRateInThisLevel = 5;
    public static float spawnRate { get; private set; }
    private void Awake()
    {
        MasterTracker.stageNumber = stageNumber;
        enemyTanks = enemyTanksInThisLevel;
        playerAITanks = playerAITanksInThisLevel;
        spawnRate = spawnRateInThisLevel;
    }
}
