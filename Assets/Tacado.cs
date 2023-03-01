using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacado : MonoBehaviour
{
    public Animator animador;
    //para saber que el jugaedor esa sobre el enemigo
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(ContactPoint2D punto in other.contacts)
            {
                if(punto.normal.y<= -0.9){
                    animador.SetBool("Muerto",true);
                    other.gameObject.GetComponent<MovePlayer>().Rebote();
                    Destroy(gameObject);
                }

            }
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {
        animador=GetComponent<Animator>();
    }

}
