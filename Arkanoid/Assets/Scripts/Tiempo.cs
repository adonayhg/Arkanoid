using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    float tiempoTranscurrido = 0f; 
    [SerializeField] TMPro.TextMeshProUGUI textoTiempo;

    bool nivelEnCurso = true;

    void Update()
    {
        if (nivelEnCurso)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTextoTiempo();
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
}
