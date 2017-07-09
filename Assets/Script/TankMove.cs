using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public float rotationSpeed;
    public float controlStick;

    Rigidbody2D rb2d;

    Move move;

    List<KeyCode> keyHistory;

    bool wPress, aPress, sPress, dPress;

	// Use this for initialization
	void Start () {
        keyHistory = new List<KeyCode> {
            KeyCode.W,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D
        };
        move = new Move(gameObject, speed, rotationSpeed);
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!wPress && Input.GetKey(KeyCode.W)) MoveItemToFront(keyHistory, KeyCode.W);
        if (!aPress && Input.GetKey(KeyCode.A)) MoveItemToFront(keyHistory, KeyCode.A);
        if (!sPress && Input.GetKey(KeyCode.S)) MoveItemToFront(keyHistory, KeyCode.S);
        if (!dPress && Input.GetKey(KeyCode.D)) MoveItemToFront(keyHistory, KeyCode.D);

        Vector2 toMove = Vector2.zero;

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet).GetComponent<Bullet>().parent = gameObject;
        }

        foreach (KeyCode key in keyHistory) {
            if (Input.GetKey(key)) {
                if (key == KeyCode.W) {
                    move.Up();
                    break;
                }
                if (key == KeyCode.A) {
                    move.Left();
                    break;
                }
                if (key == KeyCode.S) {
                    move.Down();
                    break;
                }
                if (key == KeyCode.D) {
                    move.Right();
                    break;
                }
            }
        }

        wPress = Input.GetKey(KeyCode.W);
        aPress = Input.GetKey(KeyCode.A);
        sPress = Input.GetKey(KeyCode.S);
        dPress = Input.GetKey(KeyCode.D);

        move.EndMove();
	}

    void MoveItemToFront(List<KeyCode> list, KeyCode item) {
        int index = list.IndexOf(item);
        //print(item);
        //print(index);
        list.RemoveAt(index);
        list.Insert(0, item);
    }
}
