using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager instance;
    public AudioMixer mixer;
    public Slider volume;

    public int vidas = 3;
    public int coleccionables = 0;

    private void Awake()
    {
        AudioManager.instance.Play("background");
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float value;
        mixer.GetFloat("volume", out value);


        if (volume != null)
            volume.value = value;

        AudioManager.instance.Play("background");
    }


    public void CargarEscena(int escena)
    {
        AudioManager.instance.Stop("background");
        SceneManager.LoadScene(escena);

    }

  public void SalirJuego()
{
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
}


    public void SetVolume(float value)
    {
        mixer.SetFloat("volume", value);
    }

    public void clickSound()
    {
        AudioManager.instance.Play("click");
    }

}
