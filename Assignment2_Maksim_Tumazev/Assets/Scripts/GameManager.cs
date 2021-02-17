using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

public class GameManager : MonoBehaviour
{
    private string path;

    public List<ObjectToSave> objects;
        
    private void Awake()
    {
        objects = new List<ObjectToSave>();
        path = Application.persistentDataPath + "/save.xml";
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) Save();
        if (Input.GetKeyDown(KeyCode.Backspace)) Load();
    }

    public void Save()
    {
        Debug.Log("Save");

        XElement root = new XElement("root");

        foreach (ObjectToSave obj in objects)
        {
            root.Add(obj.GetElement());
        }

        root.AddFirst(new XElement("score", Data.score));

        Debug.Log(root);

        XDocument docToSave = new XDocument(root);

        File.WriteAllText(path, docToSave.ToString());
        Debug.Log(path);
    }

    public void Load()
    {
        XElement root = null;

        Debug.Log("Load");

        if (!File.Exists(path))
        {
            Debug.Log("Save data not found...");
            if (File.Exists(Application.persistentDataPath + "/scene.xml"))
            {
                root = XDocument.Parse(File.ReadAllText(Application.persistentDataPath + "/scene.xml")).Element("root");
            }
        }
        else
        {
            root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        }

        if (root == null)
        {
            Debug.Log("Scene load failed");
            return;
        }

        GenerateScene(root);
        
    }

    void GenerateScene(XElement root)
    {

        foreach (ObjectToSave obj in objects)
        {
            obj.DestroySelf();
        }

        foreach (XElement instance in root.Elements("instance"))
        {
            Vector3 position = Vector3.zero;

            position.x = float.Parse(instance.Attribute("x").Value);
            position.y = float.Parse(instance.Attribute("y").Value);
            position.z = float.Parse(instance.Attribute("z").Value);

            Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.identity);
        }
    }
}
