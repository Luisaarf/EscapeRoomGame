using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Keycode : MonoBehaviour
{
    [SerializeField] private TMP_Text oneText;
    [SerializeField] private TMP_Text secondText;
    [SerializeField] private TMP_Text thirdText;
    [SerializeField] private TMP_Text fourthText;

    public Button currentButton;
    public TMP_Text currentText;
    // Start is called before the first frame update
    void Start()
    {
        oneText.text = "0";
        // secondText.text = "0";
        // thirdText.text = "0";
        // fourthText.text = "0";
    }

    // Update is called once per frame
    public void AddNumber()
    {
        currentButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Debug.Log(currentButton);
        currentText = currentButton.GetComponentInChildren<TMP_Text>();
        Debug.Log(currentText);

    //     int num = int.Parse(currentTextButton.text);
    //     if(num ==9)
    //     {
    //         currentTextButton.text = 0.ToString();
    //     }
    //     else{
    //         currentTextButton.text = (num+1).ToString();
    //     }
    //    VerifyCode(currentTextButton);
    }

    public void VerifyCode(TMP_Text oneText){
        if (oneText.text == "9" ){
            Debug.Log("Certo");
        }else{
            Debug.Log("Errado");
        }
    }
}
