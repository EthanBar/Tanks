using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public float MaxHP;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [HideInInspector]
    public float HP;

	// Use this for initialization
	void Start () {
        HP = MaxHP;
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
    void Update () {
        if (HP <= 0) {
            Destroy(gameObject);
        }
	}

    public void Heal (float amount) {
        HP += amount;
        if (HP > MaxHP) HP = MaxHP;
    }

    //void OnMouseEnter() {
    //    print("hey");
    //    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit() {
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}
}
