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
    //procedimento para começar o jogo 
    public void StartGame(){
        //chama a função da classe SceneManager para carregar a cena pelo nome dela
        SceneManager.LoadScene("SampleScene");
    }
    //procedimento para sair do jogo
    public void QuitGame(){
        Application.Quit();
    }

    public void Pause(){
        if (pausePanel.activeSelf){
            pausePanel.SetActive(false);
            arrowLeft.interactable = true;
            arrowRight.interactable= true;
            pauseButton.interactable = true;
            inventoryPanel.SetActive(true);
            
        }
        else{
            pausePanel.SetActive(true);
            arrowLeft.interactable = false;
            arrowRight.interactable = false;
            pauseButton.interactable = false;
            inventoryPanel.SetActive(false);
        }
    }
    
    public void BackMenu(){
        //chama a função da classe SceneManager para carregar a cena pelo nome dela
        SceneManager.LoadScene("Menu");
    }

    void Start(){
        if(pausePanel){
            pausePanel.SetActive(false);
        }
    }

}
