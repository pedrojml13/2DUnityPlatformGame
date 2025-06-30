using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public RawImage[] hearts;
    private Vector3 initialPosition;
    public float invulnerabilityTime = 2f;
    private bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        UpdateHealthUI();
    }

    public void TakeDamage()
    {
        if (!isInvulnerable && currentHealth > 0)
        {
            currentHealth--;
            AudioManager.instance.Play("Punch");
            StartCoroutine(HeartBlinkAndDisable(hearts[currentHealth]));

            StartCoroutine(InvulnerabilityRoutine());

            if (currentHealth <= 0)
            {
                GameManager.instance.GameOver();
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator HeartBlinkAndDisable(RawImage heart)
    {
        Color originalColor = heart.color;

        for (int j = 0; j < 3; j++)
        {
            heart.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            yield return new WaitForSeconds(0.1f);
            heart.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }

        heart.enabled = false;
    }



    private IEnumerator InvulnerabilityRoutine()
    {
        isInvulnerable = true;


        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Color originalColor = sprite.color;
        Color invulnerableColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);

        float elapsed = 0f;
        while (elapsed < invulnerabilityTime)
        {
            sprite.color = (elapsed % 0.2f < 0.1f) ? invulnerableColor : originalColor;
            elapsed += Time.deltaTime;
            yield return null;
        }

        sprite.color = originalColor;

        

        isInvulnerable = false;
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    public int getCurrentHealth(){
        return currentHealth;
    }


    private IEnumerator HeartBlink(RawImage heart)
    {
        Color originalColor = heart.color;
        for (int j = 0; j < 3; j++)
        {
            heart.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
            yield return new WaitForSeconds(0.1f);
            heart.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void increaseCurrentHealth(){
        if (currentHealth < hearts.Length)
        {
            hearts[currentHealth].enabled = true;
            StartCoroutine(HeartBlink(hearts[currentHealth]));
            currentHealth++;
            AudioManager.instance.Play("Healing");
        }
    }
}
