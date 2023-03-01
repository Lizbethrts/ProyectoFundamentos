using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    // Start is called before the first frame update
    public float vida;
    private MovePlayer movimientoJugador;
    public  float tiempoPerdidaControl;
    private Animator animator;

    private void Start(){
        movimientoJugador=GetComponent<MovePlayer>();
        animator = GetComponent<Animator>();
    }
    public void Daño  (float daño){
        vida-=daño;
    }
    public void Daño(float daño, Vector2 posicion){
        vida-= daño;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        //perder control
        movimientoJugador.Rebote();

    }
    private IEnumerator PerderControl (){
        movimientoJugador.sePuedeMover=false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover=true;
    }
}
