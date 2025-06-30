using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    public int maxCollectables = 5;
    private int currentCollectables = 0;

    public ParticleSystem smokeEffect;

    void Start()
    {
    }

    public void AddCollectable()
    {
        currentCollectables++;

        if (currentCollectables >= maxCollectables)
        {
            smokeEffect.gameObject.SetActive(true);
            smokeEffect.Play();
        }
    }
}
