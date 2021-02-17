using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class ObjectToSave : MonoBehaviour
{
    [SerializeField] private string objName;

    GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        manager.objects.Add(this);
    }

    private void OnDestroy()
    {
        manager.objects.Remove(this);
    }

    public XElement GetElement()
    {
        XAttribute x = new XAttribute("x", transform.position.x);
        XAttribute y = new XAttribute("y", transform.position.y);
        XAttribute z = new XAttribute("z", transform.position.z);

        XElement element = new XElement("instance", objName, x, y, z);
        
        return element;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
