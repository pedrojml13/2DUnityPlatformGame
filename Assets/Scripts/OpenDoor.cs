using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            Destroy(other.gameObject);
            GameManager.instance.victoryPanel.SetActive(true);
            AudioManager.instance.StopAllSounds();
            AudioManager.instance.Play("Victory");
            
        }
    }
}
