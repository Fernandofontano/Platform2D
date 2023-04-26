using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float velocidad;

    public float fuerzaSalto;

    private Rigidbody2D Rigidbody;    

    private bool mirandoderecha = true;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        procesarMovimiento();
        procesarSalto();
    }

    void procesarMovimiento()
    {
        float InputMovimiento = Input.GetAxis("Horizontal");
       
       Rigidbody.velocity = new Vector2 (InputMovimiento * velocidad, Rigidbody.velocity.y);

       gestionarOrientacion(InputMovimiento);
    }

    void procesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
