using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// GetKey(KeyCode.Tecla) Leer mientras mantengo pulsada esa tecla
// GetKeyDown(KeyCode.Tecla) Leer solo cuando pulso esa tecla
// GetKeyUp(KeyCode.Tecla) Leer solo cuando dejo de pulsar esa tecla


public class MovimientoLobo : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool tocandoSuelo;
    public bool dentroDelArea;
    public int vida;
    public GameObject caja;
    bool llaveCogida;
    public bool caer;
    public GameObject prefabBala;
    public GameObject puntoDisparo;
    public GameObject camara;
    int maxSaltos=2;
    int saltosHechos=0;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

        if(vida<=0){
           Destroy(gameObject);
           //FindObjectOfType<LevelManager>().Restart();
       }
       
       //GetComponent<Animator>().SetBool("andar",false);
       //GetComponent<Animator>().SetBool("caer",false);
       //GetComponent<Animator>().SetBool("agacharse",false);
       //GetComponent<Animator>().SetBool("caerSuave",false);
        
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.eulerAngles=new Vector3(0f,0f,0f);
            transform.Translate(speed*Time.deltaTime,0f,0f);
            if(tocandoSuelo==true){
             //GetComponent<Animator>().SetBool("andar",true);   
            }

        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.eulerAngles=new Vector3(0f,180f,0f);
            transform.Translate(speed*Time.deltaTime,0f,0f);
            if(tocandoSuelo==true){
              //GetComponent<Animator>().SetBool("andar",true);  
            }
            
        }
        if(tocandoSuelo==false){
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0f,-speed*Time.deltaTime,0f);
            //GetComponent<Animator>().SetBool("agacharse",true);
        }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)){// Pulsamos la tecla flecha abajo
            caer=true;
        }

        /*if(Input.GetKeyDown(KeyCode.P)){
            Instantiate(prefabBala,puntoDisparo.transform.position,puntoDisparo.transform.rotation);
        }*/

       if(Input.GetKeyDown(KeyCode.UpArrow)){
           if(saltosHechos<maxSaltos){
            //if(tocandoSuelo==true){
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
                    saltosHechos++;
            //}
           }
        }
        if(tocandoSuelo==false){
            //GetComponent<Animator>().SetBool("caer",true);
        }
    }

    private void OnCollisionEnter2D(Collision2D infoColision) {
        switch(infoColision.collider.tag){
            case "cabeza":
                //Debug.Log(infoColision.collider.name);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
                //Destroy(gameObject);
            break;
             case "muerte":
                Destroy(gameObject);
             break;
             case "Suelo":
             //GetComponent<Animator>().SetBool("caerSuave",true);
                tocandoSuelo=true;
                caer=false;
                saltosHechos=0;
             break;
             case "enemigo":

                Destroy(gameObject);
            break;
             
        
        }
        
    }

    private void OnCollisionExit2D(Collision2D infoColision) {
        switch(infoColision.collider.tag){
            case "cabeza":
                Destroy(infoColision.collider.gameObject.transform.root.gameObject);
            break;
            case "Suelo":
                tocandoSuelo=false;
            break;
        }
        
    }
    private void OnTriggerStay2D(Collider2D arbusto) {
        if(arbusto.CompareTag("arbusto")){
        
            dentroDelArea=true;
        }
     
        }
        private void OnTriggerExit2D(Collider2D arbusto) {
        if(arbusto.CompareTag("arbusto")){
        
            dentroDelArea=false;
        }
        

        }

    /*public void RestoreVidaStats (int vida){

        this.vida = vida;

        this.ui.loboStats(this.vida);

    }

    public void Damage(){

        this.vida--;
        this.ui.loboStats(this.vida);

        if(this.vida<=0){

            if(Res_GameMAnager.s_current != null){

                Res_GameMAnager.s_current.OnProtagonistDeath(this.gameObject);
            }
            else if (Res_GameMAnager.s_current != null){
                Res_GameMAnager.s_current.OnProtagonistDeath(this.gameObject);

            }

        }
    }*/


    /*private void OnTriggerEnter2D(Collider2D objetoQueHaDisparadoElTrigger) {
         switch(objetoQueHaDisparadoElTrigger.tag){
            case "ItemVida":
                vida+=50;
                Destroy(objetoQueHaDisparadoElTrigger.gameObject);
            break;
            //  case "area":
            //     caja.GetComponent<Rigidbody2D>().gravityScale=1;
            //  break;
            case "llave":
                llaveCogida=true;
                Destroy(objetoQueHaDisparadoElTrigger.gameObject);
            break;
            case "Puerta":
                SceneManager.LoadScene(objetoQueHaDisparadoElTrigger.GetComponent<Puerta>().levelAcargar);
                if(objetoQueHaDisparadoElTrigger.GetComponent<Puerta>().destroyPlayer==true){
                    Destroy(gameObject);
                }
            break;
         }
    }

    private void OnTriggerStay2D(Collider2D objetoQueHaDisparadoElTrigger) {
        switch(objetoQueHaDisparadoElTrigger.tag){
            case "area":
                if(Input.GetKeyDown(KeyCode.E)){
                    if(llaveCogida==true){
                        caja.GetComponent<Rigidbody2D>().gravityScale=1;
                    }
                }
            break;
        }
    }*/


    


}
