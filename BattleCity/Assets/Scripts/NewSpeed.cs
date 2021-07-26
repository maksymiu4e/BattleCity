using UnityEngine;

public class NewSpeed : Bonus
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MasterTracker.speed += 10;
        GamePlayManager GPM = GameObject.Find("Canvas").GetComponent<GamePlayManager>();
        Destroy(this.gameObject);
    }
}
