using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Control : MonoBehaviour
{
    public static Control control;

    public InputField inputField;

    public string nametxt;

    private void Awake()
    {
        if (control != null)
        {
            Destroy(gameObject);
            return;
        }
        control = this;
        DontDestroyOnLoad(gameObject);
        nametxt = inputField.text;
        LoadScore();
    }

    [System.Serializable]
    class Name
    {
        //public string name;

        public int betterScore;
    }

    public void SaveScore()
    {
        Name bestname = new Name();
        //bestname.name = nametxt;
        bestname.betterScore = MainManager.max;

        string json = JsonUtility.ToJson(bestname);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            
            string json = File.ReadAllText(path);
            Name name = JsonUtility.FromJson<Name>(json);
            //nametxt = name.name;
            MainManager.max = name.betterScore;
        }
    }
}
