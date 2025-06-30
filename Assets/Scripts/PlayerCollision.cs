using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public static int enemiesKilled = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            float playerY = transform.position.y;
            float monsterY = collision.transform.position.y;

            if (playerY > monsterY + 0.3f)
            {
                collision.gameObject.GetComponent<Monster>().TriggerCrushEffect();

                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f);

                AudioManager.instance.Play("monsterDie");
                enemiesKilled++;
            }
        }
            

        if (collision.transform.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage();
            
        }
    }


}
