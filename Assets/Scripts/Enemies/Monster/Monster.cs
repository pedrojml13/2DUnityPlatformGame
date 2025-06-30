using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

    }

    void Update()
    {
        if(!GameManager.isGameOver){
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(1f, 1f);
            }
            else
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
            if(transform.position.y < -30f){
                Destroy(gameObject);
            }
        }
    }

    public void TriggerCrushEffect()
    {
        StartCoroutine(CrushEffect());
        
    }

    private IEnumerator CrushEffect()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 originalPosition = transform.position;
        float crushDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < crushDuration)
        {
            float scaleY = Mathf.Lerp(1f, 0.1f, elapsedTime / crushDuration);
            transform.localScale = new Vector3(originalScale.x, scaleY, originalScale.z);
            transform.position = new Vector3(originalPosition.x, originalPosition.y - (originalScale.y - scaleY) * 0.5f, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = new Vector3(originalScale.x, 0.1f, originalScale.z);
        transform.position = new Vector3(originalPosition.x, originalPosition.y - (originalScale.y - 0.1f) * 0.5f, originalPosition.z);
        Destroy(gameObject);
        
    }

    public void PlayerDamage(){
        float playerY = player.position.y;
        float monsterY = transform.position.y;

            if (playerY < monsterY + 0.3f)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage();
    }

}
