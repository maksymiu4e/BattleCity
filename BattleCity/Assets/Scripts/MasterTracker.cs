using UnityEngine;

public class MasterTracker : MonoBehaviour
{
    static MasterTracker instance = null;
    public static bool stageCleared = false;
    public static int enemyTankDestroyed;
    public static int stageNumber;
    public static int playerLives = 1;
    public static int speed = 5;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
