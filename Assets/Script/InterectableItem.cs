using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterectableItem : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    public void GreenInteract(){
        Debug.Log("Green Interact");
        Debug.Log(inventory.selectedItem);
       // Debug.Log(inventory.selectedItem.name);
    }
}
