 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public float rotationSpeed;
    public float raycastDist;
    public float boxDist;

    Move move;

    Transform player;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").transform;
        move = new Move(gameObject, speed, rotationSpeed);
    }

    // Update is called once per frame
    void Update() {
        if (player != null) {
            Vector2 toMove = Vector2.zero;

            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(boxDist, boxDist), 0);
            List<Collider2D> colliders = new List<Collider2D>();
            foreach (Collider2D col in hitColliders) {
                if (col.tag == "Obstacle") colliders.Add(col);
            }

            if (colliders.Count > 0) {
                Collider2D closest = colliders[0];
                foreach (Collider2D col in colliders) {
                    if (Vector2.Distance(transform.position, col.transform.position) >
                        Vector2.Distance(transform.position, closest.transform.position)) {
                        closest = col;
                    }
                }

                float xdiff = closest.transform.position.x - transform.position.x;
                float ydiff = closest.transform.position.y - transform.position.y;

                if (Mathf.Abs(xdiff) < Mathf.Abs(ydiff)) {
                    if (xdiff > 0) {
                        move.Left();
                    } else move.Right();
                } else {
                    if (ydiff > 0) {
                        move.Down();
                    } else move.Up();
                }

            } else {
                float xdiff = player.transform.position.x - transform.position.x;
                float ydiff = player.transform.position.y - transform.position.y;

                if (Mathf.Abs(xdiff) > Mathf.Abs(ydiff)) {
                    if (xdiff > 0) {
                        move.Right();
                    } else move.Left();
                } else {
                    if (ydiff > 0) {
                        move.Up();
                    } else move.Down();
                }
            }
            move.EndMove();
        }
    }

    void TakeCover() {
        
    }
}
