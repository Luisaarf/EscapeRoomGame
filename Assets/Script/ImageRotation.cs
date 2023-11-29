using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageRotation : MonoBehaviour
{
    EventSystem system;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Button imageToRotate;
    [SerializeField] private GameObject spotlightCircle;
    [SerializeField] private Button theaterImage1;
    [SerializeField] private Button theaterImage2;
    [SerializeField] private Button theaterImage3;
    [SerializeField] private Button theaterImage4;
    [SerializeField] private Button theaterImage5;
    [SerializeField] private Button theaterImage6;
    [SerializeField] private GameObject thirdPin;

    // Start is called before the first frame update
    void Start()
    {
        spotlightCircle.SetActive(false);
        system = EventSystem.current;
        theaterImage1.transform.Rotate(0, 0, -90);
        theaterImage2.transform.Rotate(0, 0, 90);
        theaterImage3.transform.Rotate(0, 0, -90);
        theaterImage4.transform.Rotate(0, 0, -90);
        theaterImage5.transform.Rotate(0, 0, 90);
        theaterImage6.transform.Rotate(0, 0, 90);
        thirdPin.SetActive(false);
    }

    public void SetSpotlightActive(){
        spotlightCircle.SetActive(true);
    }

    public void RotateThisImage()
    {
        imageToRotate = system.currentSelectedGameObject.GetComponent<Button>();
        imageToRotate.transform.Rotate(0, 0, -90);
        verifyRotation();
    }

    void turnInteractable(){
        theaterImage1.interactable = false;
        theaterImage2.interactable = false;
        theaterImage3.interactable = false;
        theaterImage4.interactable = false;
        theaterImage5.interactable = false;
        theaterImage6.interactable = false;
    }

    public void verifyRotation(){
        bool isCorrect = false;
        if( theaterImage1.transform.rotation.z == 0 && theaterImage2.transform.rotation.z == 0 && theaterImage3.transform.rotation.z == 0 && theaterImage4.transform.rotation.z == 0 && theaterImage5.transform.rotation.z == 0 && theaterImage6.transform.rotation.z == 0){
            isCorrect = true;
        }
        if(isCorrect){
            turnInteractable();
            thirdPin.SetActive(true);
        }
    }
}
