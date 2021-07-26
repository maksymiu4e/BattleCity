using UnityEngine;

public class RandomTower : MonoBehaviour
{
    public Sprite[] towerSprites;
    private int spriteIdx;

    // Start is called before the first frame update
    void Start()
    {
        spriteIdx = Random.Range(0, towerSprites.Length);
        GetComponent<SpriteRenderer>().sprite = towerSprites[spriteIdx];
    }
}
