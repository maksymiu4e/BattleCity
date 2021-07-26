using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    Image topCurtain, bottomCurtain, blackCurtain;
    [SerializeField]
    Text stageNumberText;
    [SerializeField]
    RectTransform canvas;
    [SerializeField]
    Text gameOverText;
    GameObject[] enemySpawnPoints, playerSpawnPoints, playerAISpawnPoints;
    bool tankReserveEmpty = false;
    bool playerAIReserveEmpty = false;
    [SerializeField]
    GameObject[] bonusModules;

    IEnumerator RevealStageNumber()
    {
        while (blackCurtain.rectTransform.localScale.y > 0)
        {
            blackCurtain.rectTransform.localScale = new Vector3(blackCurtain.rectTransform.localScale.x, Mathf.Clamp(blackCurtain.rectTransform.localScale.y - Time.deltaTime, 0, 1), blackCurtain.rectTransform.localScale.z);
            yield return null;
        }
    }

    IEnumerator RevealTopStage()
    {
        float moveTopUpMin = topCurtain.rectTransform.position.y + (canvas.rect.height / 2) + 10;
        stageNumberText.enabled = false;
        while (topCurtain.rectTransform.position.y < moveTopUpMin)
        {
            topCurtain.rectTransform.Translate(new Vector3(0, 500 * Time.deltaTime, 0));
            yield return null;
        }
    }
    IEnumerator RevealBottomStage()
    {
        float moveBottomDownMin = bottomCurtain.rectTransform.position.y - (canvas.rect.height / 2) - 10;
        while (bottomCurtain.rectTransform.position.y > moveBottomDownMin)
        {
            bottomCurtain.rectTransform.Translate(new Vector3(0, -500 * Time.deltaTime, 0));
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        stageNumberText.text = "STAGE" + MasterTracker.stageNumber.ToString();
        playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
        playerAISpawnPoints = GameObject.FindGameObjectsWithTag("PlayerAISpawnPoint");
        enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        StartCoroutine(StartStage());        
    }

    IEnumerator StartStage()
    {
        StartCoroutine(RevealStageNumber());
        yield return new WaitForSeconds(2);
        StartCoroutine(RevealTopStage());
        StartCoroutine(RevealBottomStage());
        yield return null;
        InvokeRepeating("SpawnEnemy", LevelManager.spawnRate, LevelManager.spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (tankReserveEmpty && GameObject.FindWithTag("Enemy") == null)
        {
            MasterTracker.stageCleared = true;
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        tankReserveEmpty = false;
        SceneManager.LoadScene("Score");
    }
    public IEnumerator GameOver()
    {
        while (gameOverText.rectTransform.localPosition.y < 0)
        {
            gameOverText.rectTransform.localPosition = new Vector3(gameOverText.rectTransform.localPosition.x, gameOverText.rectTransform.localPosition.y + 80f * Time.deltaTime, gameOverText.rectTransform.localPosition.z);
            yield return null;
        }
        MasterTracker.stageCleared = false;
        LevelCompleted();
    }

    public void SpawnEnemy()
    {
        if (LevelManager.enemyTanks> 0)
        {
            int spawnPointIndex = Random.Range(0, enemySpawnPoints.Length);
            Animator animator = enemySpawnPoints[spawnPointIndex].GetComponent<Animator>();
            animator.SetTrigger("Spawning");
        }
        else
        {
            CancelInvoke();
            tankReserveEmpty = true;
        }
    }
    public void SpawnPlayer()
    {
        if (MasterTracker.playerLives > 0)
        {
            Animator animator = playerSpawnPoints[0].GetComponent<Animator>();
            animator.SetTrigger("Spawning");
                MasterTracker.playerLives--;
        }
        else
        {
            SceneManager.LoadScene("Score");
            StartCoroutine(GameOver());
        }
    }

    public void SpawnPlayerAI()
    {
        if (LevelManager.playerAITanks > 0)
        {
            int spawnPointIndex = Random.Range(0, playerAISpawnPoints.Length);
            Animator animator = playerAISpawnPoints[spawnPointIndex].GetComponent<Animator>();
            animator.SetTrigger("Spawning");
        }
        else
        {
            CancelInvoke();
            playerAIReserveEmpty = true;
        }
    }


    public void GenerateBonusModule()
    {
        GameObject bonusModule = bonusModules[Random.Range(0, bonusModules.Length)];
        Vector3 createPosition = new Vector3(Random.Range(-19, 19), Random.Range(-19, 19), 0);
        Instantiate(bonusModule, createPosition, Quaternion.identity);
    }
}
