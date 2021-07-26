using UnityEngine;

public class Tank : Movement
{
    float h, v;
    Rigidbody2D rb2d;
    WeaponController wc;
    [SerializeField]
    Sprite FastcannonIIPlayer, FastcannonIIIPlayer;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        wc = GetComponentInChildren<WeaponController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (h != 0 && !isMoving) StartCoroutine(MoveHorizontal(h, rb2d));
        else if (v != 0 && !isMoving) StartCoroutine(MoveVertical(v, rb2d));
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wc.Fire();
        }
    }

    public void UpgradeTank()
    {
        if (level < 3)
        {
            level++;
            if (level == 2)
            {
                transform.Find("TankCannon").gameObject.GetComponent<SpriteRenderer>().sprite = FastcannonIIPlayer;
                wc.UpgradeProjectileDamage2();
                wc.GenerateSecondCanonBall();
            }
            else if (level == 3)
            {
                transform.Find("TankCannon").gameObject.GetComponent<SpriteRenderer>().sprite = FastcannonIIPlayer;
                wc.UpgradeProjectileDamage3();
                wc.GenerateSecondCanonBall();
            }
        }
    }
}
