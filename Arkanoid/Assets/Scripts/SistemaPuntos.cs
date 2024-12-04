using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuntos : MonoBehaviour
{
    public static SistemaPuntos instancia;

    [SerializeField] private TMPro.TextMeshProUGUI textoPuntaje;
    [SerializeField] GameObject popUpFelicidades;
    [SerializeField] TMPro.TextMeshProUGUI puntos;
    [SerializeField] TMPro.TextMeshProUGUI tiempo;
    private int puntajeActual = 0;
    public int numeroBloques;
    private int puntuacionMaxima;
    private int puntos2;

    public float tiempoTranscurrido = 0f;
    [SerializeField] TMPro.TextMeshProUGUI textoTiempo;

    bool nivelEnCurso = false;

    void Start()
    {
        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque").Length;
    }
    void Update()
    {
        if (nivelEnCurso)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTextoTiempo();
        }
    }

    void Awake()
    {

        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CargarPuntuacionMaxima();
    }

    public void AgregarPuntos(int puntos, int cantidad)
    {
        puntajeActual += puntos;
        puntos2 += cantidad;
        ActualizarUI();
        if (puntos > puntuacionMaxima)
        {
            puntuacionMaxima = puntos;
            GuardarPuntuacionMaxima();
        }
        if (puntos2 > puntuacionMaxima)
        {
            puntuacionMaxima = puntos;
            GuardarPuntuacionMaxima();
        }
    }
    private void GuardarPuntuacionMaxima()
    {
        PlayerPrefs.SetInt("PuntuacionMaxima", puntuacionMaxima);
        PlayerPrefs.Save();
    }

    private void CargarPuntuacionMaxima()
    {
        if (PlayerPrefs.HasKey("PuntuacionMaxima"))
        {
            puntuacionMaxima = PlayerPrefs.GetInt("PuntuacionMaxima");
        }
        else
        {
            puntuacionMaxima = 0;
        }
    }

    public void ResetearPuntuacion()
    {
        puntos2 = 0;
        GuardarPuntuacionMaxima();
    }

    public int ObtenerPuntuacionMaxima()
    {
        return puntuacionMaxima;
    }


    private void ActualizarUI()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = " " + puntajeActual;
        }
    }

    public int ObtenerPuntaje()
    {
        return puntajeActual;
    }

    public void ReiniciarPuntaje()
    {
        puntajeActual = 0;
        ActualizarUI();
    }
    public void DestruirBloques()
    {
        numeroBloques--;
        if (numeroBloques <= 0)
        {
            popUpFelicidades.SetActive(true);
            DetenerCronometro();
            puntos.text = ObtenerPuntaje().ToString();
            tiempo.text = ObtenerTiempoFinal().ToString("00:00");
            DetenerCronometro();
        }
    }

    public void ActualizarTextoTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public float ObtenerTiempoFinal()
    {
        return tiempoTranscurrido;
    }

    public void DetenerCronometro()
    {
        nivelEnCurso = false;
    }

    public void EmpezarCronometro()
    {
        nivelEnCurso = true;
    }
}
