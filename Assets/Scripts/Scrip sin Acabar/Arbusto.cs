using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbusto : MonoBehaviour
{

    public bool dentroDelArea;

    private void OnTriggerStay2D(Collider2D arbusto) {
        if(arbusto.CompareTag("Player")){
        
            dentroDelArea=true;
        }
     
        }
        private void OnTriggerExit2D(Collider2D arbusto) {
        if(arbusto.CompareTag("Player")){
        
            dentroDelArea=false;
        }
        

        }

       
    }


