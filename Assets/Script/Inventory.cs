using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public Button[] allSpaces;
    public Button selectedItem;
    EventSystem system;
    

    void Start()
    {   
        system = EventSystem.current;
        allSpaces = new Button[8];
        for(int i = 0; i <= 7; i++){
            allSpaces[i] = GameObject.Find("Space" + (i+1)).GetComponent<Button>();
            allSpaces[i].interactable = false;
        }
    }

    public void SetInteractable(int index){
        allSpaces[index].interactable = true;
    }

    public void addToInventory(Button item){
        for(int i = 0; i <= 7; i++){
            if(allSpaces[i].interactable == false){
                allSpaces[i].image.sprite = item.image.sprite;
                allSpaces[i].image.color = item.image.color;
                allSpaces[i].interactable = true;
                item.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void SelectedItemButton(){
        selectedItem = system.currentSelectedGameObject.GetComponent<Button>();
    }

    // public void deleteObject(){

    // }


}
