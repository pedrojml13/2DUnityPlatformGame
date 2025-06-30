using UnityEngine;

public class AddHeart : MonoBehaviour
{
    public PlayerHealth playerHealth;
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.transform.tag == "Player"){
            if(playerHealth.getCurrentHealth() < 3){
                playerHealth.increaseCurrentHealth();
                Destroy(gameObject);
            }
            
        }
    }
}
