using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool lookDerecha = true;
    private int saltosRestantes;
    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        SaltoPersonaje();
    }

    bool EstaSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void SaltoPersonaje()
    {
        if (EstaSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    // Logica de Movimiento 

    void MovimientoPersonaje()
    {
        float InputMovimiento = Input.GetAxis("Horizontal");

        if (InputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

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
