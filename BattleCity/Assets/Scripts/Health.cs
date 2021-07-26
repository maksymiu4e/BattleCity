using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    int acctualHealth;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetHealth();
    }
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void SetHealth()
    {
        currentHealth = acctualHealth;
    }

    void Death()
    {
        GamePlayManager GPM = GameObject.Find("Canvas").GetComponent<GamePlayManager>();
        if (gameObject.CompareTag("Player"))
        {
            if (LevelManager.playerAITanks > 0 && MasterTracker.playerLives > 0)
            {
                GPM.SpawnPlayerAI();
                LevelManager.playerAITanks--;
            }
            else 
                StartCoroutine(GPM.GameOver());
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            MasterTracker.enemyTankDestroyed++;
            GPM.GenerateBonusModule();
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("BaseP"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(GPM.GameOver());
        }
        else if (gameObject.CompareTag("BaseE"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            MasterTracker.stageCleared = true;
            SceneManager.LoadScene("Score");
            //StartCoroutine(GPM.GameOver());
        }
    }
}
