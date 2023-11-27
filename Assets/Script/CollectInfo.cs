using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInfo : MonoBehaviour
{
    [SerializeField] private string objectName;

    public string GetObjectName()
    {
        return objectName;
    }
}
