using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePins : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Button firstPinBase;
    [SerializeField] private Button secondPinBase;
    [SerializeField] private Button thirdPinBase;
    // Start is called before the first frame update
    void Start()
    {
        firstPinBase.gameObject.GetComponent<Image>().color = Color.black;
        secondPinBase.gameObject.GetComponent<Image>().color = Color.black;
        thirdPinBase.gameObject.GetComponent<Image>().color = Color.black;
        
    }

    public void interactFirstPinBase()
    {
        if (inventory.GetSelectedItemName() == "1st Pin")
        {
            firstPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
        }
    }

    public void interactSecondPinBase()
    {
        if (inventory.GetSelectedItemName() == "2nd Pin")
        {
            secondPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
        }
    }

    public void interactThirdPinBase()
    {
        if (inventory.GetSelectedItemName() == "3rd Pin")
        {
            thirdPinBase.gameObject.GetComponent<Image>().color = new Color(1f, 0, 0.8f, 1f);
            inventory.DestroySelectedItem();
        }
    }
}
