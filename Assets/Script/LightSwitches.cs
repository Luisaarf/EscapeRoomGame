using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitches : MonoBehaviour
{
    EventSystem system;
    private Button thisLightSwitch;
    [SerializeField] private Button[] whiteLightSwitches;
    [SerializeField] private Button[] greenLightSwitches;
    [SerializeField] private Image spotlight;

    [SerializeField] private ImageRotation imageRotation;

    [SerializeField] private Sprite lightOn;

    void Start()
    {
        system = EventSystem.current;
        whiteLightSwitches = new Button[6];
        greenLightSwitches = new Button[6];
        GameObject[] whiteTempObjects = GameObject.FindGameObjectsWithTag ("whiteLightButton");
        GameObject[] greenTempObjects = GameObject.FindGameObjectsWithTag ("greenLightButton");
        for(int i = 0; i <= 5; i++){
            whiteLightSwitches[i] = whiteTempObjects[i].GetComponent<Button>();
            greenLightSwitches[i] = greenTempObjects[i].GetComponent<Button>();
        }
    }
    // Start is called before the first frame update
    public void ChangeColor()
    {   
        thisLightSwitch = system.currentSelectedGameObject.GetComponent<Button>();
        if (thisLightSwitch.image.color == Color.green){
            thisLightSwitch.image.color = Color.white;
        }else{
            thisLightSwitch.image.color = Color.green;
        }
        verifyCode();
    }
    void disableLightButtons(){
        for(int i = 0; i <= 5; i++){
            whiteLightSwitches[i].interactable = false;
            greenLightSwitches[i].interactable = false;
        }
    }

    void verifyCode(){
        bool isCorrect = true;
        for(int i = 0; i <= 5; i++){
            if(whiteLightSwitches[i].image.color != Color.white){
                isCorrect = false;
            }
        }
        for(int i = 0; i <= 5; i++){
            if(greenLightSwitches[i].image.color != Color.green){
                isCorrect = false;
            }
        }
        if(isCorrect){
            disableLightButtons();
            spotlight.color = Color.white;
            imageRotation.SetSpotlightActive();
            spotlight.sprite = lightOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
