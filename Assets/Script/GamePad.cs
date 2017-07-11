using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GamePad : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {

    // Use this for initialization
    void Start() {
#if !UNITY_IOS
        //Destroy(gameObject);
#endif
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log(gameObject.name + " Was Clicked.");
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
        
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
        
    }
}
