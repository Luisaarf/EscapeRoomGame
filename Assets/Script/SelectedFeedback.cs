using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedFeedback : MonoBehaviour
{
    [SerializeField] private GameObject frameSelectedObject;
    [SerializeField] private TextMeshProUGUI textSelectedObject;
    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject coffeInterior;
    // Start is called before the first frame update
    void Start()
    {
        frameSelectedObject.SetActive(false);
        coffeInterior.SetActive(false);
    }

    public void showObjectSelectedName(){
        if(inventory.GetSelectedItemName() != null){
            frameSelectedObject.SetActive(true);
            textSelectedObject.text = inventory.GetSelectedItemName();
        } else {
            frameSelectedObject.SetActive(false);}
    }

    public void CoffeeInteract(){
        if (inventory.GetSelectedItemName() == "Café"){
            coffeInterior.SetActive(true);
        } else {
            coffeInterior.SetActive(false);
        }
    }

}
