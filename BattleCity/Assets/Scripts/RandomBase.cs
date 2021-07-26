using UnityEngine;

public class RandomBase : MonoBehaviour
{
    public Sprite[] baseSprites;
    private int spriteIdx;

    public string MakeRandom()
    {

        spriteIdx = Random.Range(0, baseSprites.Length);
        GetComponent<SpriteRenderer>().sprite = baseSprites[spriteIdx];
        string baseName = baseSprites[spriteIdx].name;
        return baseName;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeRandom();
    }
}
