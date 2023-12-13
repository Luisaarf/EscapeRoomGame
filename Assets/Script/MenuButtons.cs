//classe representando os botões do menu
// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//declaração de classe pública MenuButtons que herda de MonoBehaviour
public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button arrowLeft;
    [SerializeField] private Button arrowRight;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] AudioSource soundButtons;
    //procedimento para começar o jogo 
    public void StartGame(){
        //chama a função da classe SceneManager para carregar a cena pelo nome dela
        soundButtons.Play();
        SceneManager.LoadScene("SampleScene");
    }
    //procedimento para sair do jogo
    public void QuitGame(){
        soundButtons.Play();
        Application.Quit();
    }

    public void Pause(){
        if (pausePanel.activeSelf){
            soundButtons.Play();
            pausePanel.SetActive(false);
            arrowLeft.interactable = true;
            arrowRight.interactable= true;
            pauseButton.interactable = true;
            inventoryPanel.SetActive(true);
            
        }
        else{
            soundButtons.Play();
            pausePanel.SetActive(true);
            arrowLeft.interactable = false;
            arrowRight.interactable = false;
            pauseButton.interactable = false;
            inventoryPanel.SetActive(false);
        }
    }
    
    public void BackMenu(){
        soundButtons.Play();
        //chama a função da classe SceneManager para carregar a cena pelo nome dela
        SceneManager.LoadScene("Menu");
    }

    void Start(){
        if(pausePanel){
            pausePanel.SetActive(false);
        }
        creditsPanel.SetActive(false);
        if(pauseButton){
            pauseButton.gameObject.SetActive(true);
        }
    }

    public void CreditsPanel(){
        soundButtons.Play();
        creditsPanel.SetActive(true);
    }

    public void CloseCreditsPanel(){
        soundButtons.Play();
        creditsPanel.SetActive(false);
    }

}
