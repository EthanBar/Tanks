using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string[] levels;
    public int startLevel;

    int level;

    // Use this for initialization
    void Start() {
        level = startLevel;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(levels[startLevel]);
    }

    // Update is called once per frame
    void Update() {
        //SceneManager.LoadScene();
    }
}