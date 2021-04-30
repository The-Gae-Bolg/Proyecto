using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    
    // Update is called once per frame
    public float speed = 4f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    public GameObject initialMap;

    void Awake(){
        Assert.IsNotNull(initialMap);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        Camera.main.GetComponent<MainCamera>().SetBound(initialMap);
    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (mov != Vector2.zero) {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        } else {
            anim.SetBool("walking", false);
        }

        // Buscamos el estado actual mirando la información del animador
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Player_Attack");

        if(Input.GetKeyDown("space") && !attacking) {
            anim.SetTrigger("attacking");
        }

        // Vamos actualizando la posición de la colisión de ataque
        if (mov != Vector2.zero) {
            attackCollider.offset = new Vector2(mov.x/2, mov.y/2);
        }
        
        if (attacking) {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66) {
                attackCollider.enabled = true;
            } else {
                attackCollider.enabled = false;
            }
        }
    }

    void FixedUpdate () {
        // Nos movemos en el fixed por las físicas
        rb2d.MovePosition(rb2d.position + mov.normalized * speed * Time.deltaTime);
    }

}
