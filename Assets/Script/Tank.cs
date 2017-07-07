using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    public float MaxHP;

    [HideInInspector]
    public float HP;

	// Use this for initialization
	void Start () {
        HP = MaxHP;
	}
	
	// Update is called once per frame
    void Update () {
        if (HP <= 0) {
            Destroy(gameObject);
        }
	}
}
