﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetLevel()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        SceneManager.LoadScene(button.gameObject.name);
        
       
    }
}
