using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMController : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidbody;
    private bool lookDerecha = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
    }

    // Logica de Movimiento 

    void MovimientoPersonaje()
    {
        float InputMovimiento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(InputMovimiento * velocidad, rigidbody.velocity.y);

        OrientacionPersonaje(InputMovimiento);
    }

    void OrientacionPersonaje(float InputMovimiento)
    {
        if ((lookDerecha == true && InputMovimiento < 0) || (lookDerecha == false && InputMovimiento > 0) )
        {
            lookDerecha = !lookDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
