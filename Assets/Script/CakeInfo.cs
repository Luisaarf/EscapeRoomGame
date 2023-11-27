using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeInfo : MonoBehaviour
{
    [SerializeField] private Sprite CutCake;
    [SerializeField] private GameObject TheCake;
    // Start is called before the first frame update
    public void cutTheCake()
    {    
        this.GetComponent<Image>().sprite = CutCake;
    }

}
