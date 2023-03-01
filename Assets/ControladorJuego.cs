using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
   public static ControladorJuego Instance;
   public GameObject[] puntosDeControl;
   public GameObject jugador;
   private int indexPuntoControl;

   private void Awake (){
        Instance =this;
        puntosDeControl=GameObject.FindGameObjectsWithTag("PuntoDecontrol");
        indexPuntoControl=PlayerPrefs.GetInt("puntosIndex");
        Instantiate(jugador,puntosDeControl[indexPuntoControl].transform.position,Quaternion.identity);

   }
   public void UltimoPuntoControl(GameObject puntoControl)
   {
        for(int i=0; i< puntosDeControl.Length; i++){
            if (puntosDeControl[i]==puntoControl){
                PlayerPrefs.SetInt("puntosIndex", i);
            }
        }
   }
   private void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
   }
}
