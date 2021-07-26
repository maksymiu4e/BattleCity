using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health health = GameObject.Find("Player'sBase").GetComponent<Health>();
            health.TakeDamage();

        }
    }
}
