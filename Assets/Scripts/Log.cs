using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy {
    private Rigidbody2D myRigidBody;
    private Animator anim;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private bool awake;
    private bool chace;

    // Start is called before the first frame update
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        awake = false;
        chace = false;
    }

    // Update is called once per frame
    void Update() {
        CheckDistance();
    }

    void CheckDistance() {
        float distance = Vector3.Distance(target.position, transform.position);
        Vector3 dir = (target.position - transform.position).normalized;

        anim.SetFloat("movX", dir.x);
        anim.SetFloat("movY", dir.y);

        if (distance <= chaseRadius && !awake) {
            awake = true;
            anim.SetBool("wakeUp", true);
            StartCoroutine(WakeUp());
        }

        if (chace) {
            if (distance > attackRadius) {
                Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(position);
                anim.SetBool("walking", true);
            }
            else {
                anim.SetBool("walking", false);
            }

            if (distance > chaseRadius) {
                StartCoroutine(WakeDown(distance));
            }
        }
    }

    IEnumerator WakeUp() {
        yield return new WaitForSeconds(1);
        chace = true;
    }

    IEnumerator WakeDown(float distance) {
        yield return new WaitForSeconds(3);
        if (distance > chaseRadius) {
            anim.SetBool("wakeUp", false);
            anim.SetBool("walking", false);
            awake = false;
            chace = false;
        }
    }

}
