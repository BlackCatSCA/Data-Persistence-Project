using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public InputField inputField;
    public string namePlayer;
    // Start is called before the first frame update
    void Start()
    {
    
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInput()
    {
        namePlayer = inputField.text;
        Debug.Log("El usuario ingreso: " +  namePlayer);
        
    }

    public void OnClicStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
        Aplication.Quit()
        #endif
    }
}