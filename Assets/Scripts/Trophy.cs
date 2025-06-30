using UnityEngine;

public class Trophy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            GameManager.instance.RecogerTrofeo();

            gameObject.SetActive(false);
        }
    }
}
