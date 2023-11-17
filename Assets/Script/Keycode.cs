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

    [SerializeField] private TMP_Text sixthText;
    private bool isCorrect = false;

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
        sixthText.text = "0";
        isCorrect = false;
    }

    // Update is called once per frame
    public void AddNumber()
    {
        if(isCorrect == false){
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
    }

    public void VerifyCode(){
        if (oneText.text == "1" && secondText.text == "1" && thirdText.text == "1" && fourthText.text == "1" && fithText.text == "1" && sixthText.text == "1"){
            isCorrect = true;
        }
    }

    public bool GetIsCorrect(){
        return isCorrect;
    }
}
