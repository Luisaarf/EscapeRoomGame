//classe representando os botões do menu
// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//declaração de classe pública MenuButtons que herda de MonoBehaviour
public class MenuButtons : MonoBehaviour
{
    //procedimento para começar o jogo 
    public void StartGame(){
        //chama a função da classe SceneManager para carregar a cena pelo nome dela
        SceneManager.LoadScene("SampleScene");
    }
    //procedimento para sair do jogo
    public void QuitGame(){
        Application.Quit();
    }
}
