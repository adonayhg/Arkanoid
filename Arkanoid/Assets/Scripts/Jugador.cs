using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidadJugador;
    [SerializeField] float desplazamientoJugadorIzq = 18f;
    [SerializeField] float desplazamientoJugadorDer = -7f;
    [SerializeField] GameObject jugadorDerecha;
    [SerializeField] GameObject jugadorIzquierda;
    private bool enModoDestructivo = false;
    private float tiempoModoDestructivo = 0f;


    void Start()
    {
        
    }
    void Update()
    {
        float movimientoInput = Input.GetAxis("Horizontal");

        Vector3 posiciónJugador = transform.position;
        posiciónJugador.x = Mathf.Clamp(posiciónJugador.x + movimientoInput * velocidadJugador * Time.deltaTime, desplazamientoJugadorDer, desplazamientoJugadorIzq);
        transform.position = posiciónJugador;

        if(Time.timeScale == 1)
        {
            LeanTween.rotateZ(jugadorDerecha, 360, 1).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
            LeanTween.rotateZ(jugadorIzquierda, 360, 1).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
        }
    }

    [SerializeField] private Pelota pelota;


    public void ActivarEfectoPowerUp()
    {
            pelota.ActivarModoDestructivo(5f);

        Debug.Log("Power-Up Activado: Modo destructivo");
    }
}
