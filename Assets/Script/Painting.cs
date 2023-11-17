using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Painting : MonoBehaviour
{
    [SerializeField] Button paintingFocus;
    [SerializeField] Button disfocusButton;
    [SerializeField] GameObject painting;
    [SerializeField] GameObject numberSky;
    [SerializeField] GameObject numberCloud;
    [SerializeField] GameObject numberSun;
    [SerializeField] GameObject numberLeaves;
    [SerializeField] GameObject numberTreeWood;

    [SerializeField] GameObject Cloud1;
    [SerializeField] GameObject Cloud2;

    private Image image;

    //declaração de objeto da classe EventSystem
    EventSystem system;
    string currentColor;
    Vector3 initialPosition;
    Vector3 initialScale;
 
    // Start is called before the first frame update
    void Start()
    {
        disfocusButton.gameObject.SetActive(false);
        system = EventSystem.current;
        numberCloud.SetActive(false);
        numberSky.SetActive(false);
        numberSun.SetActive(false);
        numberLeaves.SetActive(false);
        numberTreeWood.SetActive(false);
        initialPosition = painting.transform.position;
        initialScale = painting.transform.localScale;
    }

    public void getColor(){
        currentColor = system.currentSelectedGameObject.name;
    }

    public void setColor(){
        string gameObject = system.currentSelectedGameObject.name;
        Debug.Log(gameObject);
        Debug.Log(currentColor);
        if (gameObject == "sky"){
            if(currentColor == "colors-C"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                numberSky.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            }
        }
        if (gameObject == "cloud"){
            if(currentColor == "colors-W"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                verifyBothClouds();
            }
        }
        if (gameObject == "sun"){
            if(currentColor == "colors-Y"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                numberSun.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            }
        }
         if (gameObject == "leaves"){
            if(currentColor == "colors-G"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                numberLeaves.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

            }
        }
        if(gameObject == "treewood"){
            if(currentColor == "colors-B"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                numberTreeWood.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            }
        }
    }

    public void verifyBothClouds(){
        if(Cloud1.GetComponent<Image>().color.a == 1f && Cloud2.GetComponent<Image>().color.a == 1f){
            numberCloud.SetActive(true);
        }

    }

    public void focusOnPainting(){
        painting.transform.localScale = new Vector3(1, 0.85f, 1);
        painting.transform.position = new Vector3(Screen.width * 0.5f, (Screen.height * 0.5f)+80f, 0);
        disfocusButton.gameObject.SetActive(true);
    }

    public void disfocusOnPainting(){
        painting.transform.localScale = initialScale;
        painting.transform.position = initialPosition;
        disfocusButton.gameObject.SetActive(false);
    }

}
