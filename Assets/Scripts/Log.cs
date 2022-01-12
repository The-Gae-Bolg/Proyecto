using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy {
    private Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        CheckDistance();
    }

    void CheckDistance() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius) {
            Vector3 position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidBody.MovePosition(position);
        }
    }
}
