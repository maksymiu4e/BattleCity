using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text stageText;
    // Use this for initialization
    void Start()
    {
        stageText.text = "STAGE " + MasterTracker.stageNumber;
        StartCoroutine(Updates());
    }
    IEnumerator Updates()
    {
        yield return new WaitForSeconds(2f);
        if (MasterTracker.stageCleared)
        {
            SceneManager.LoadScene("Stage" + (MasterTracker.stageNumber + 1));
        }
        else
        { 
            SceneManager.LoadScene("GameOver");
        }
    }
}
