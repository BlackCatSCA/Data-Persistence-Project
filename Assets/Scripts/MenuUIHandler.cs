using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInput;
    public string playerName;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        DisplayScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInput()
    {
        playerName = nameInput.text;
        Debug.Log("El usuario ingreso: " + playerName);
        DataManager.Instance.SetCurrentPlayer(playerName);
        DataManager.Instance.SavePlayerScore(0);
    }

    public void DisplayScores()
    {
        // Verifica si existe la instancia de DataManager.
        if (DataManager.Instance == null || DataManager.Instance.playerScores.Count == 0)
        {
            scoreText.text = "No hay puntajes registrados.";
            return;
        }

        string scoreList = "Puntajes más altos:\n";

        // Itera sobre cada jugador en el diccionario de puntajes.
        foreach (var player in DataManager.Instance.playerScores)
        {
            scoreList += $"{player.Key}: {player.Value} puntos\n"; // Agrega nombre y puntaje.
        }

        // Asigna el texto generado al objeto UI Text.
        scoreText.text = scoreList;
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
