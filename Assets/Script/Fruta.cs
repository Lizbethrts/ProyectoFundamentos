using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    public GameObject efecto;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Instantiate(efecto, transform.position,Quaternion.identity);
            Destroy(gameObject);
            LogicManager.Puntaje += 100;
        }
        
    }
}
