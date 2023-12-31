using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public int PuntosTotales { get { return puntosTotales; } }
    public HUD hud;
    private int puntosTotales;
    private int vidas = 3;

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
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            SceneManager.LoadScene(2);
        }
        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if(vidas == 3)
        {
            return false;
        }

        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
