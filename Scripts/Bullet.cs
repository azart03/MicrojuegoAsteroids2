using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float velocidad = 10f;
    public float duracionBala = 3f;
    public Vector3 vectorDireccion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duracionBala);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(velocidad * vectorDireccion * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }

    private void IncreaseScore(){
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
    }
}
