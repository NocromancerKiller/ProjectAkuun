using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguidorDePlayer : MonoBehaviour
{

    public float velocidad;
    public float VelocidadDeReversa;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public float rangoDeReversa;
    public float rangoDeDisparo;
    public MovimientoLobo DentroDelArea;
    public Transform player;
    public Rigidbody2D rb2D;



//Este script hace que el enemigo te persiga y si entras en contacto con el "Arbusto" el enemigo se destuye





    private void Update()

    { 


        if(DentroDelArea.dentroDelArea==true){

            Debug.Log( "AAAAAA ta dentro");

            Destroy(gameObject);
        }

        else{
    
        distanciaDelJugador = Vector2.Distance(player.position, rb2D.position);
        if(distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador > rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidad * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        else if (distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador <= rangoDeDisparo)
        {
            {
                Vector2 objetivo = new Vector2(player.position.x, player.position.y);
                Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, 0 * Time.deltaTime);
                rb2D.MovePosition(nuevaPos);
            }
        }
        else if(distanciaDelJugador< rangoDeReversa)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos= Vector2.MoveTowards(rb2D.position, objetivo, VelocidadDeReversa * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
        Gizmos.DrawWireSphere(transform.position, rangoDeReversa);
    }
}
