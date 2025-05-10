using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public string namePlayer;
    public Text bestNameScore;

    string bestPlayerName = DataManager.Instance?.playerName ?? "Jugador Desconocido";
    int bestsScore = DataManager.Instance?.mScore ?? 00;

    // Start is called before the first frame update
    void Start()
    {
        BestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInput()
    {
        if (inputField != null)
        {
            namePlayer = inputField.text;
            Debug.Log("El usuario ingreso: " + namePlayer);
        }
        if(DataManager.Instance != null)
        {
            DataManager.Instance.playerName = namePlayer;
        }
    }

    void BestScore()
    { 
        bestNameScore.text = $" Best Player Score: {bestPlayerName} : {bestsScore} ";  
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
        Application.Quit()
        #endif
    }
}
