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

    // Update is called once per frame
    public void salir()
    {
        Application.Quit();
    }
}