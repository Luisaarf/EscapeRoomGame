using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject drawerScene;
    [SerializeField] private GameObject paitingScene;
    [SerializeField] private GameObject openFirstDrawerScene;
    [SerializeField] private Button openDrawerButton;
    [SerializeField] private Button openDrawerSecondButton;
    [SerializeField] private Button openDrawerThirdButton;
    [SerializeField] private GameObject pathPuzzleButton;
    [SerializeField] private GameObject focusPaintButton;
    [SerializeField] private Button closeDrawerButton;
    // Start is called before the first frame update
    [SerializeField] private Keycode keycode;
    [SerializeField] private GameObject charcoal;
    [SerializeField] private GameObject coffee;

    [SerializeField] private AudioSource soundDrawer;

    private bool notOpenYet;

    void Start()
    {
        drawerScene.SetActive(false);
        openFirstDrawerScene.SetActive(false);
        notOpenYet = true;
        charcoal.SetActive(false);
    }

    public void OpenFirstDrawer()
    {
        openDrawerButton.gameObject.SetActive(false);
        openDrawerSecondButton.gameObject.SetActive(false);
        openDrawerThirdButton.gameObject.SetActive(false);
        pathPuzzleButton.SetActive(false);
        paitingScene.SetActive(false);
        focusPaintButton.SetActive(false);
        if(keycode.GetIsCorrect() == false || notOpenYet)
        {
            notOpenYet = false;
            drawerScene.SetActive(true);
        }
        else
        {
            soundDrawer.Play();
            openFirstDrawerScene.SetActive(true);
            showCoffee();
            // openDrawerSecondButton.gameObject.SetActive(true);
            // openDrawerThirdButton.gameObject.SetActive(true);
        }

    }

    public void OpenDrawer(){
        soundDrawer.Play();
        openDrawerButton.gameObject.SetActive(false);
        openFirstDrawerScene.SetActive(true);
        openDrawerSecondButton.gameObject.SetActive(false);
        openDrawerThirdButton.gameObject.SetActive(false);
        pathPuzzleButton.SetActive(false);
        paitingScene.SetActive(false);
        focusPaintButton.SetActive(false);
        if (coffee)
        {
            coffee.SetActive(false);
        }
    }
    
    public void DrawerSound()
    {
        soundDrawer.Play();
    }

    public void CloseDrawer()
    { 
        drawerScene.SetActive(false);
        openFirstDrawerScene.SetActive(false);
        openDrawerButton.gameObject.SetActive(true);
        openDrawerSecondButton.gameObject.SetActive(true);
        openDrawerThirdButton.gameObject.SetActive(true);
        pathPuzzleButton.SetActive(true);
        paitingScene.SetActive(true);
        focusPaintButton.SetActive(true);
        if (charcoal)
        {
            charcoal.SetActive(false);
        }
    }

    public void showCoffee(){
        if(coffee){
            coffee.SetActive(true);
        }
    }

    public void showCharcoal(){
        if(charcoal){
            charcoal.SetActive(true);
        }
    }

    public void disableDrawerButton(){
        openDrawerButton.gameObject.SetActive(false);
        openDrawerSecondButton.gameObject.SetActive(false);
        openDrawerThirdButton.gameObject.SetActive(false);
        pathPuzzleButton.SetActive(false);
        focusPaintButton.SetActive(false);
    }

    public void enableDrawerButton(){
        openDrawerButton.gameObject.SetActive(true);
        openDrawerSecondButton.gameObject.SetActive(true);
        openDrawerThirdButton.gameObject.SetActive(true);
        pathPuzzleButton.SetActive(true);
        focusPaintButton.SetActive(true);
    }


}
