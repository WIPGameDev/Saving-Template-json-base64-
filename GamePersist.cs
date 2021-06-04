using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class GamePersist : MonoBehaviour
{
    GameData gameData = new GameData();
    string saveLocation;

    //To Add ->  Serializefield array of persists

    void Awake() => saveLocation = Path.Combine(Application.persistentDataPath + "/SaveGame.json");

    void Start() => Load();
    
    void OnApplicationPause() => Save();

    void OnApplicationQuit() => Save();

    public void Load()
    {
        try
        {
            using (StreamReader streamReader = new StreamReader(saveLocation))
            {
                var b64 = streamReader.ReadToEnd();
                var plainTextBytes = Convert.FromBase64String(b64);
                var json = Encoding.UTF8.GetString(plainTextBytes);

                gameData = JsonUtility.FromJson<GameData>(json);

                foreach (var persist in FindObjectsOfType<MonoBehaviour>(includeInactive: true).OfType<IPersist>())
                {
                    persist.Load(gameData);
                }
            }
        }
        catch
        {
            Debug.Log("No Save");
        }
    }

    public void Save()
    {
        foreach (var persist in FindObjectsOfType<MonoBehaviour>(includeInactive:true).OfType<IPersist>())
        {
            persist.Save(gameData);
        }
       
        var json = JsonUtility.ToJson(gameData);
        var plainTextBytes = Encoding.UTF8.GetBytes(json);
        var b64 = Convert.ToBase64String(plainTextBytes);

        using (StreamWriter streamWriter = new StreamWriter(saveLocation))
        {
            streamWriter.Write(b64);
        }
    }
    
    public void FullWipe()
    {
        File.Delete(saveLocation);
    }
}
