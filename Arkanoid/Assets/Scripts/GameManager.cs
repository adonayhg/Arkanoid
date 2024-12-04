using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI puntos;
    [SerializeField] TMPro.TextMeshProUGUI tiempo;
    [SerializeField] GameObject pantallaGameOver;
    [SerializeField] private TMPro.TextMeshProUGUI textoPuntajeFinal;

    void Start()
    {
        if(pantallaGameOver != null)
        {
            pantallaGameOver.SetActive(false);

        }
    }

    public void MostrarGameOver()
    {
        if (pantallaGameOver != null)
        {
            puntos.text = SistemaPuntos.instancia.ObtenerPuntaje().ToString();
            pantallaGameOver.SetActive(true);
            tiempo.text = SistemaPuntos.instancia.ObtenerTiempoFinal().ToString("00:00");
        }
    }

    public void ReiniciarNivel()
    {
        SistemaPuntos.instancia.ReiniciarPuntaje();
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void MostrarPuntajeFinal()
    {
        if (textoPuntajeFinal != null)
        {
            textoPuntajeFinal.text = SistemaPuntos.instancia.ObtenerPuntaje().ToString();
        }
    }

}
