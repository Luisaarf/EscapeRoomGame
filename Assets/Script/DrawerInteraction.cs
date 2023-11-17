using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject drawerScene;
    [SerializeField] private GameObject openFirstDrawerScene;
    [SerializeField] private Button openDrawerButton;
    [SerializeField] private Button openDrawerSecondButton;
    [SerializeField] private Button openDrawerThirdButton;
    [SerializeField] private Button pathPuzzleButton;
    [SerializeField] private Button closeDrawerButton;
    // Start is called before the first frame update
    [SerializeField] private Keycode keycode;
    [SerializeField] private GameObject charcoal;

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
        pathPuzzleButton.gameObject.SetActive(false);
        if(keycode.GetIsCorrect() == false || notOpenYet)
        {
            notOpenYet = false;
            drawerScene.SetActive(true);
        }
        else
        {
            openFirstDrawerScene.SetActive(true);
            // openDrawerSecondButton.gameObject.SetActive(true);
            // openDrawerThirdButton.gameObject.SetActive(true);
        }

    }

    public void OpenDrawer(){
        openDrawerButton.gameObject.SetActive(false);
        openFirstDrawerScene.SetActive(true);
        openDrawerSecondButton.gameObject.SetActive(false);
        openDrawerThirdButton.gameObject.SetActive(false);
        pathPuzzleButton.gameObject.SetActive(false);
    }

    public void CloseDrawer()
    {
        drawerScene.SetActive(false);
        openFirstDrawerScene.SetActive(false);
        openDrawerButton.gameObject.SetActive(true);
        openDrawerSecondButton.gameObject.SetActive(true);
        openDrawerThirdButton.gameObject.SetActive(true);
        pathPuzzleButton.gameObject.SetActive(true);
        charcoal.SetActive(false);
    }

    public void showCharcoal(){
        charcoal.SetActive(true);
    }


}
