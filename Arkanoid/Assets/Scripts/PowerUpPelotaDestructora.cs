using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPelotaDestructora : MonoBehaviour
{
    [SerializeField] private float velocidadCaida = 1f;
    [SerializeField] private float limiteInferior = -5f;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ActivarEfectoPowerUp();

            Destroy(gameObject);
        }
    }

    private void DestruirPowerUp()
    {
        Destroy(gameObject);
    }

}
