using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidesPrefab;
    public float spawnRatioPorMinuto = 30f;
    public float spawnRatioIncremento = 1f;
    public float xLimit;
    public float duracionAsteroide = 2f;
    private float spawnSiguiente = 0;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnSiguiente){ //Condicion para que spawnee el siguinte, cuando el tiempo de juego haya superado el tiempo en el que tiene que spawnear el siguiente, aparecera el siguinte
            spawnSiguiente = Time.time + 60 / spawnRatioPorMinuto; //Cuando tendra que spawnear el siguiente

            spawnRatioPorMinuto += spawnRatioIncremento; //Vamos aumentando el ratio de spawn para mayor dificultad

            float rand = Random.Range(-xLimit, xLimit); //Rango en el que se generan los asteroides

            Vector2 spawnPosicion = new Vector2(rand, 8f); //Vector de posicion de los asteroides

            GameObject asteroide = Instantiate(asteroidesPrefab, spawnPosicion, Quaternion.identity); //Instanciar asteroides
            
            Destroy(asteroide, duracionAsteroide);


        }
    }
}
