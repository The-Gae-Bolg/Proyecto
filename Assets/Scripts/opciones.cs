﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opciones : MonoBehaviour
{
    // Start is called before the first frame update
    public void jugar()
    {
        SceneManager.LoadScene("Game");
    }

    public void menuOpcion(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    // Update is called once per frame
    public void salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void pause()
    {
        Time.timeScale = 0f;
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
    }
}