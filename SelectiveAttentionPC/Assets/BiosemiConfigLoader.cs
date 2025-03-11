using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BiosemiConfigLoader : MonoBehaviour
{
    private string comport = "COM3";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public string LoadComportFromConfiq()
    {
        string filePath = getPath();
        if (File.Exists(filePath))
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                string fileContents;
                using (StreamReader reader = new StreamReader(fs))
                {
                    fileContents = reader.ReadToEnd();
                }
                fs.Close();
                return fileContents;
            }
            catch (IOException e)
            {
                print(e);
            }
        }
        return ""; 
    }

    private string getPath()
    {
        var fileName = "biosemiConfig.txt";
#if UNITY_EDITOR
        return Application.dataPath + "/config/" + fileName;
#elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+fileName;
#else
        return Application.dataPath +"/"+fileName;
#endif
    }
}
