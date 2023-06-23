using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text ScoreLabel;
    public InputField NameField;

    public void Start()
    {
        ScoreLabel.text = "Best Score : " + SaveDataManager.Instance.HighScorePlayerName + " : " + SaveDataManager.Instance.HighScore;
    }

    public void StartNew()
	{
        SaveDataManager.Instance.PlayerName = NameField.text;
        SceneManager.LoadScene(1);
	}

    public void Exit()
    {
        SaveDataManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
