using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicManager : MonoBehaviour
{
   public  GameObject Playercamera;
   public  GameObject GameOverMenu;
   public GameObject Meta;
   public static int Puntaje;
   public TextMeshProUGUI puntajetexto;

   public void Dead(){
      Playercamera.SetActive(false);
      GameOverMenu.SetActive(true);
   }
   public void retry()
   {
      SceneManager.LoadScene(1);
   }
   public void Win()
   {
      Meta.SetActive(true);

   }

   private void Update() {
      puntajetexto.text = Puntaje.ToString();
   }
   
}
