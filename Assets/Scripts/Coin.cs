using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.transform.tag == "Player"){
            GameManager.coinNumber++;
            AudioManager.instance.Play("Coin");
            Destroy(gameObject);
        }
    }
}
