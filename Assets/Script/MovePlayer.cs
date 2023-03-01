using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MovePlayer : MonoBehaviour

{   
    public bool sePuedeMover;
    //public Vector2 velocidadRebote;
    
    
    //Movimiento
    private Rigidbody2D rb2D;
    private float MoveH=0f;
    public float VelocidadMove;
    public float SuavizandoMove;
    private Vector3 velocidad=Vector3.zero;
    private  bool Derecha=true;

    //Salto
    public float distanciaSuelo;
    public float fuerzaSalto;
    public LayerMask Suelo;
    public Transform controladorSuelo;
    public Vector3 Caja;
    public bool EnSuelo;
    private bool salto = false;
    // Animaciones
    private Animator animator;

    //Rebote
    public float velocidadRebote;
    //morir
    public LogicManager scriptlog;
    // Start is called before the first frame update
    private void Start()
    {
       rb2D =GetComponent<Rigidbody2D>();
       animator=GetComponent<Animator>();
       scriptlog = GameObject.Find("GameManager").GetComponent<LogicManager>();
    }

    private void Update() {
        MoveH= Input.GetAxis("Horizontal")*VelocidadMove;
        animator.SetFloat("Horizontal",Mathf.Abs (MoveH));
        if (Input.GetButtonDown("Jump")){
            salto = true;
        }
    }
    private void FixedUpdate() {
        //Salto
        //EnSuelo=Physics2D.OverlapBox(controladorSuelo.position,Caja,0f,Suelo);
        if(Physics2D.Raycast(transform.position,Vector2.down,distanciaSuelo)){
            EnSuelo = true;
        }

        
        animator.SetBool("Suelo",EnSuelo);
        //Moviemnto
        if(sePuedeMover){
            Mover(MoveH*Time.fixedDeltaTime,salto);
       
        }
        salto = false;
    } 
    private void Mover (float mover, bool saltar )
    {
        Vector3 VelocidadObjetivo= new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity= Vector3.SmoothDamp(rb2D.velocity, VelocidadObjetivo,ref velocidad,SuavizandoMove);
        if(mover > 0&& !Derecha){
            //Gira
            Girar();
        }else if ( mover < 0&& Derecha)
        {
            Girar();
        }
        if(EnSuelo && saltar){
            EnSuelo = false;
            rb2D.AddForce(new Vector2(0f,fuerzaSalto));
        }
    }
    //public void Rebote(Vector2 puntoGolpte){
        //negativo porque se va a mover a dirrecion opuesta de ser atacado
        //rb2D.velocity = new Vector2(-velocidadRebote.x*puntoGolpte.x,velocidadRebote.y);

    //}
    public void Rebote()
    {
        rb2D.velocity =new Vector2(rb2D.velocity.x,velocidadRebote);
    }
    private void Girar(){
         Derecha=!Derecha;
         Vector3 escala =transform.localScale;
         escala.x*=-1;
         transform.localScale=escala;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Spikes"){
            scriptlog.Dead();
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Finish"){
            scriptlog.Win();
        }
        
    }



    private void OnDrawGizmos() {
    Gizmos.color=Color.yellow;
    Gizmos.DrawCube(controladorSuelo.position,Caja);
  }
}
