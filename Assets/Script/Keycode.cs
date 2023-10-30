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
    [SerializeField] private TMP_Text fithText;

    public Button currentButton;
    public TMP_Text currentText;
    // Start is called before the first frame update
    void Start()
    {
        oneText.text = "0";
        secondText.text = "0";
        thirdText.text = "0";
        fourthText.text = "0";
        fithText.text = "0";
    }

    // Update is called once per frame
    public void AddNumber()
    {
        currentButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        currentText = currentButton.GetComponentInChildren<TMP_Text>();
        int num = int.Parse(currentText.text);
        if(num ==9)
        {
            currentText.text = 0.ToString();
        }
        else{
            currentText.text = (num+1).ToString();
        }
       VerifyCode();
    }

    public void VerifyCode(){
        if (oneText.text == "9" && secondText.text == "3" && thirdText.text == "4" && fourthText.text == "8" && fithText.text == "2"){
            Debug.Log("Certo");
        }else{
            Debug.Log("Errado");
        }
    }
}
