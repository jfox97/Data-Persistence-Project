using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager Instance { get; private set; }

	public string PlayerName;
	public int HighScore;
	public string HighScorePlayerName;

	public void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		Load();
	}

	[System.Serializable]
	class SaveData
	{
		public string PlayerName;
		public int HighScore;
		public string HighScorePlayerName;
	}

	public void Save()
	{
		SaveData data = new SaveData();
		data.PlayerName = PlayerName;
		data.HighScore = HighScore;
		data.HighScorePlayerName = HighScorePlayerName;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void Load()
	{
		string path = Application.persistentDataPath + "/saveFile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			PlayerName = data.PlayerName;
			HighScore = data.HighScore;
			HighScorePlayerName = data.HighScorePlayerName;
		}
	}
}
