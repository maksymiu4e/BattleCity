using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    GameObject bullet, bullet2, fire;
    Bullet canon, canon2;
    [SerializeField]
    int speed;


    // Start is called before the first frame update
    void Start()
    {
        bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        canon = bullet.GetComponent<Bullet>();
        canon.speed = speed;
        fire = transform.GetChild(0).gameObject;
    }
    public void GenerateSecondCanonBall()
    {
        bullet2 = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        canon2 = bullet2.GetComponent<Bullet>();
        canon2.speed = speed;
    }

    public void Fire()
    {
        if (bullet.activeSelf == false)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            StartCoroutine(ShowFire());
            bullet.SetActive(true);
        }
        else
        {
            if (bullet2 != null)
            {
                if (bullet2.activeSelf == false)
                {
                    bullet2.transform.position = transform.position;
                    bullet2.transform.rotation = transform.rotation;
                    StartCoroutine(ShowFire());
                    bullet2.SetActive(true);
                }
            }
        }
    }

    IEnumerator ShowFire()
    {
        fire.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fire.SetActive(false);
    }

    private void OnDestroy()
    {
        if (bullet != null) canon.DestroyBulllet();
        if (bullet2 != null) canon2.DestroyBulllet();
    }

    public void UpgradeProjectileDamage2()
    {
        speed = 15;
        canon.speed = speed; 
    }
    public void UpgradeProjectileDamage3()
    {
        speed = 20;
        canon.speed = speed; 
    }
}
