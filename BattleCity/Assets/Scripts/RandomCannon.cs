using UnityEngine;

public class RandomCannon : MonoBehaviour
{
    public Sprite[] cannonSprites;
    private int spriteIdx;

    // Start is called before the first frame update
    void Start()
    {
        spriteIdx = Random.Range(0, cannonSprites.Length);
        GetComponent<SpriteRenderer>().sprite = cannonSprites[spriteIdx];
    }
}
