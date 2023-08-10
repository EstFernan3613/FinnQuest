using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.Log("Mas de un Game Manager en escena");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}
