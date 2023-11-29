using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeInfo : MonoBehaviour
{
    [SerializeField] private Sprite CutCake;
    [SerializeField] private GameObject TheCake;
    [SerializeField] private GameObject secondPin;
    // Start is called before the first frame update

    void Start()
    {
        secondPin.SetActive(false);
    }
    public void cutTheCake()
    {    
        this.GetComponent<Image>().sprite = CutCake;
        secondPin.SetActive(true);
    }

}
