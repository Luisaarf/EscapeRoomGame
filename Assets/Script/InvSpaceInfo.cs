using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSpaceInfo : MonoBehaviour
{
   [SerializeField] private string objectName;

   public void SetObjectName(string name)
   {
      objectName = name;
   }

   public string GetObjectName()
   {
      return objectName;
   }
}
