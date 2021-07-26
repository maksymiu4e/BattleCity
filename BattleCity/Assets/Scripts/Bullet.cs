using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    bool toBeDestroyed = false;
    public bool destroyAmmunition = false;
    Tilemap tilemap;
    GameObject stoneGameObject, ammunitionGameObject, level1, level2;
    public int speed = 5;
    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        stoneGameObject = GameObject.FindGameObjectWithTag("Stones");
        level1 = GameObject.FindGameObjectWithTag("Level1");
        level2 = GameObject.FindGameObjectWithTag("Level2");
        ammunitionGameObject = GameObject.FindGameObjectWithTag("Ammunition");
    }

    private void OnEnable()
    {
        if (rb2d != null)
        {
        rb2d.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        tilemap = collision.gameObject.GetComponent<Tilemap>();
        if(collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
        }
        if((collision.gameObject == stoneGameObject)|| (collision.gameObject == level1) || (collision.gameObject == level2))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (toBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroyBulllet()
    {
        if (gameObject.activeSelf == false)
        {
        Destroy(this.gameObject);
        }
        toBeDestroyed = true;
    }
}
