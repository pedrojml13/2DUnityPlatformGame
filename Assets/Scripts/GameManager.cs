using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject victoryPanel;
    public GameObject barrier;
    public static int coinNumber;


    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coinsVictoryText;
    public TextMeshProUGUI enemiesKilled;

    public GameObject[] trofeos;

    private int trofeosRecogidos = 0;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        victoryPanel.SetActive(false);
        barrier.SetActive(true);
        isGameOver = false;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (GameObject trofeo in trofeos)
        {
            var spriteRenderer = trofeo.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = 0.5f;
                spriteRenderer.color = color;
            }
        }
    }

    void Start()
    {
        AudioManager.instance.Play("backgroundLevel");
    }

    void Update()
    {
        coinsText.text = coinNumber.ToString();
        coinsVictoryText.text = "Coins collected: " + coinNumber.ToString();
        enemiesKilled.text =  "Enemies killed: " + PlayerCollision.enemiesKilled.ToString();
    }

    public void ReplayLevel()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void clickSound()
    {
        AudioManager.instance.Play("click");
    }

    public void RecogerTrofeo()
    {
        if (trofeosRecogidos < trofeos.Length)
        {
            GameObject trofeo = trofeos[trofeosRecogidos];
            var spriteRenderer = trofeo.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;
            }

            trofeosRecogidos++;
            AudioManager.instance.Play("Trophy");

            if (trofeosRecogidos == trofeos.Length)
            {
                barrier.SetActive(false);
                
            }
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            AudioManager.instance.StopAllSounds();
            gameOverScreen.SetActive(true);
            AudioManager.instance.Play("GameOver");
        }
    }


}
