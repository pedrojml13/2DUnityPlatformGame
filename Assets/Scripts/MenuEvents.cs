using UnityEngine;
using UnityEngine.UI;

public class MenuEvents : MonoBehaviour
{
    public Slider volume;

    private void Start()
    {
        float value;
        GameMenuManager.instance.mixer.GetFloat("volume", out value);
        volume.value = value;
    }

    public void CambiarVolumen()
    {
        GameMenuManager.instance.SetVolume(volume.value);
    }

    public void BotonJugar(int escena)
    {
        GameMenuManager.instance.CargarEscena(escena);
    }

    public void BotonSalir()
    {
        GameMenuManager.instance.SalirJuego();
    }
}
