using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keycode : MonoBehaviour
{
    [SerializeField] private TMP_Text oneText;
    // Start is called before the first frame update
    void Start()
    {
        oneText.text = "0";
    }

    // Update is called once per frame
    public void AddNumber()
    {
        int num = int.Parse(oneText.text);
        if (num ==9)
        {
            oneText.text = 0.ToString();
        }else{
            oneText.text = (num+1).ToString();
        }
    }
}
