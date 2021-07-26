using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health health = GameObject.Find("Enemy'sBase").GetComponent<Health>();
            health.TakeDamage();
        }
    }
}
