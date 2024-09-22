using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // UI del menú de pausa
    private bool isPaused = false;  // Estado del juego, pausado o no

    void Update()
    {
        // Detectar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // Reanudar el juego si está pausado
            }
            else
            {
                Pause();  // Pausar el juego si no está pausado
            }
        }
    }

    // Método para reanudar el juego
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Oculta el menú de pausa
        Time.timeScale = 1f;           // Reanuda el tiempo en el juego
        isPaused = false;              // Cambia el estado a no pausado
    }

    // Método para pausar el juego
    void Pause()
    {
        pauseMenuUI.SetActive(true);   // Muestra el menú de pausa
        Time.timeScale = 0f;           // Pausa el tiempo en el juego
        isPaused = true;               // Cambia el estado a pausado
    }

    // Método para salir del juego (para juegos de escritorio)
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();  // Sale del juego
    }
}
