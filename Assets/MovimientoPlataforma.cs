using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    // Start is called before the first frame update
   public float velocidad;
   public Transform Suelo;
   public float distancia;
   public bool Derecha;
   private Rigidbody2D rb;
   private void Start(){

    rb=GetComponent<Rigidbody2D>();
   }
    private void FixedUpdate() 
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(Suelo.position, Vector2.down, distancia);
        rb.velocity= new Vector2(velocidad, rb.velocity.y);
        if(infoSuelo == false)
        {
            //Girar
            Girar();
        }
    }
    private void Girar(){
        Derecha=!Derecha;
        transform.localScale= new Vector2(-transform.localScale.x,transform.localScale.y);
        //transform.eulerAngles=new Vector3(0,transform.eulerAngles.y+180,0);
        velocidad*=-1;
    }
     private void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawLine(Suelo.transform.position,Suelo.transform.position+Vector3.down*distancia);
        
    }
}
