using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour
{
    //Al poner public permites que las variables sean editadas desde la escena en el motor grafico. Con private estas variables no aparecerian para modificarse desde la escena
    public float fuerzaEmpuje = 100f;
    public float velocidadRotacion = 120f;

    public GameObject pistola, balaPrefab;
    private Rigidbody rigidAux;
    // Start is called before the first frame update

    public static int SCORE = 0;
    public static float limiteEjeX, limiteEjeY;
    void Start()
    {
        rigidAux = GetComponent<Rigidbody>();

        limiteEjeY = Camera.main.orthographicSize+1;
        limiteEjeX = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {   

        var nuevaPosicion = transform.position;
        if(nuevaPosicion.x > limiteEjeX){
            nuevaPosicion.x = -limiteEjeX+1;
        }
        else if(nuevaPosicion.x < -limiteEjeX){
            nuevaPosicion.x = limiteEjeX-1;
        }
        else if(nuevaPosicion.y>limiteEjeY){
            nuevaPosicion.y = -limiteEjeY+1;
        }
        else if(nuevaPosicion.y< -limiteEjeY){
            nuevaPosicion.y = limiteEjeY-1;
        }
        transform.position = nuevaPosicion;
        //Con vertical detectas el movimiento asignado a las teclas verticales al jugar, la W y la S, la flecha arriba o abajo y en caso de mando joystick arriba o abajo
        float empuje = Input.GetAxis("Vertical") * Time.deltaTime; //Detectar interaccion del usuario con el teclado para el empuje de la nave
        //Con deltaTime establecemos el tiempo que hay entre dos frames, sirve para limitar el empuje de la nave, pq cuanto mejor grafica tengamos, mas pequeno y mas pequeno el empuje
        //cuanto mas tiempo entre fp, mas grande y mas fuerte el empuje, para nivelar
        Vector3 direccionEmpuje=transform.right; //La direccion de empuje hacia donde es, como la nave mira a la derecha inicialmente, el empuje hacia delante es hacia la derecha

        rigidAux.AddForce(direccionEmpuje * empuje * fuerzaEmpuje); //Anadimos el movimiento al componente Rigidbody segun los parametros que he establecido

        float rotacion = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Rotate(Vector3.forward, -rotacion * velocidadRotacion);

        //Gestionar el disparar
        if(Input.GetKeyDown(KeyCode.Space)){

            GameObject bala = Instantiate(balaPrefab, pistola.transform.position, Quaternion.identity); //instanciar la bala

            //Cambiar la direccion  de la bala en funcion de a donde mire la nave 
            Bullet balaScript = bala.GetComponent<Bullet>();

            balaScript.vectorDireccion = transform.right;

        }

    }

    private void OnCollisionEnter(Collision collision){ //Gestiona las colisiones con la nave

        if(collision.gameObject.CompareTag("Enemy")){
            SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Funcion para cargar cualquier otra escena, reiniciar nivel, pasar a otro nivel...

        }
        else{
            Debug.Log(message:"He colisionado con otra cosa...");
        }

    }
}
