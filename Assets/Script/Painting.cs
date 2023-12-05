//classe responsável pelo quadro
// declaração das classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Painting : MonoBehaviour //classe pública Painting que herda de MonoBehaviour
{
    //declaração de botão que será utilizado para aproximar o quadro
    [SerializeField] Button paintingFocus;
    //declaração do script DrawerInteraction
    [SerializeField] DrawerInteraction drawerInteraction;
    //declaração de botão que será utilizado para afastar o quadro
    [SerializeField] Button disfocusButton;
    [SerializeField] GameObject painting;
    //declaração de objetos que serão utilizados para mostrar os números nos quadros após serem pintados
    // cada número é um objeto na cena
    [SerializeField] GameObject numberSky;
    [SerializeField] GameObject numberCloud;
    [SerializeField] GameObject numberSun;
    [SerializeField] GameObject numberLeaves;
    [SerializeField] GameObject numberTreeWood;
    [SerializeField] GameObject numberHouse;

    [SerializeField] GameObject Cloud1;
    [SerializeField] GameObject Cloud2;

    //declaração de variáveis do tipo imagem e string, serão utilizadas posteriormente como temporárias
    private Image image;
    string currentColor;

    //declaração de objeto da classe EventSystem
    EventSystem system;
    //declaração de variáveis do tipo Vector3 que serão utilizadas para guardar a posição e escala inicial do quadro
    Vector3 initialPosition;
    Vector3 initialScale;
 
    // Start is called before the first frame update
    void Start()
    {
        //inicialização dos objetos
        disfocusButton.gameObject.SetActive(false);
        system = EventSystem.current;
        numberCloud.SetActive(false);
        numberSky.SetActive(false);
        numberSun.SetActive(false);
        numberLeaves.SetActive(false);
        numberTreeWood.SetActive(false);
        numberHouse.SetActive(false);
        //atualiza as variáveis com a posição e escala inicial do quadro
        initialPosition = painting.transform.position;
        initialScale = painting.transform.localScale;
    }

    // procedimento que é chamado ao clicar nas tintas do quadro
    public void getColor(){
        //pega
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
                image =system.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>();
                numberTreeWood.SetActive(true);
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            }
        }
        if(gameObject == "house"){
            if(currentColor == "colors-L"){
                image =system.currentSelectedGameObject.GetComponent<Image>();
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                numberHouse.SetActive(true);
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
        paintingFocus.gameObject.SetActive(false);
        drawerInteraction.disableDrawerButton();
    }

    public void disfocusOnPainting(){
        painting.transform.localScale = initialScale;
        painting.transform.position = initialPosition;
        disfocusButton.gameObject.SetActive(false);
        paintingFocus.gameObject.SetActive(true);
        drawerInteraction.enableDrawerButton();
    }

}
