using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    public float velocidad = 4;

    private Vector2 movimiento = new Vector2();

    // Update is called once per frame
    void Update() {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        transform.Translate(movimiento.normalized * velocidad * Time.deltaTime);
    }
    
}
