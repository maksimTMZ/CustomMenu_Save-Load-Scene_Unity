using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Data.score++;
        Debug.Log(Data.score);
        Destroy(gameObject);
    }

}
