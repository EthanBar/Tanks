using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int checkSpeed;
    public string[] levels;
    public int startLevel;

    int level;


    int frame;

    // Use this for initialization
    void Start() {
        frame = 1;
        level = startLevel;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(levels[startLevel]);
    }

    // Update is called once per frame
    void Update() {
        frame++;
        if (frame % checkSpeed == 0) {
            if (FindAll().Length == 0) {
                level++;
                SceneManager.LoadScene(levels[level]);
            }
        }
        //SceneManager.LoadScene();
    }

    GameObject[] FindAll() {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }
}