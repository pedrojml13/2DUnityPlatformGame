using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    public GameObject trophy;

    void Start()
    {
        animator = GetComponent<Animator>();
        trophy.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            AudioManager.instance.Play("OpenChest");
            animator.SetTrigger("OpenChest");
            trophy.SetActive(true);
            isOpen = true;
        }
    }
}
