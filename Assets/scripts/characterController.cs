using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidad;

    public float fuerzaSalto;

    private Rigidbody2D Rigidbody;    

    private bool mirandoderecha = true;

    private BoxCollider2D boxCollider;

    public LayerMask capaSuelo;

    private Animator animator;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        procesarMovimiento();
        procesarSalto();
    }

    void procesarMovimiento()
    {
        float InputMovimiento = Input.GetAxis("Horizontal");

       if (InputMovimiento != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
       else
        {
            animator.SetBool("IsRunning", false);
        }

       Rigidbody.velocity = new Vector2 (InputMovimiento * velocidad, Rigidbody.velocity.y);

       gestionarOrientacion(InputMovimiento);
        
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    } 

    void procesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
        {
            Rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void gestionarOrientacion (float inputMovimiento)
    {
        if( (mirandoderecha == true && inputMovimiento < 0) || (mirandoderecha == false && inputMovimiento > 0))
        {
            mirandoderecha = !mirandoderecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
