using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveHighScore(Score score)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.childHentai";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData(score);

        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }

    public static HighScoreData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/score.childHentai";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScoreData data = binaryFormatter.Deserialize(stream) as HighScoreData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
