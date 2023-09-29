using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CollectableItem : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    EventSystem system;
    Button thisCollectableItem;
 
    void Start()
    {
        system = EventSystem.current;
        
    }

    public void addItem(){
        thisCollectableItem = system.currentSelectedGameObject.GetComponent<Button>();
        Debug.Log(thisCollectableItem);
        inventory.addToInventory(thisCollectableItem);
    }


}
