// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Para entendimento da navegação entre as paredes da sala e imaginar um quadrado onde cada aresta é uma parede, o topo do quadrado
// é a parede 1, a esquerda é a parede 2, a de baixo é a parede 3 e a direita é a parede 4. 

public class WallTransition : MonoBehaviour  //classe pública WallTransition que herda de MonoBehaviour
{
    //declaração das paredes do jogo que são variáveis privadas
    [SerializeField] private GameObject wall1;
    [SerializeField] private GameObject wall2;
    [SerializeField] private GameObject wall3;  
    [SerializeField] private GameObject wall4;

    //declaração dos botões de seta que são variáveis privadas e tem função de navegação pelas salas
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;

    //declaração de array que guarda todas as paredes do jogo
    public GameObject[] allWalls;

    //declaração de variável que guarda a parede atual
    [SerializeField] private int currentWall;
    void Start()
    {
        //inicialização das paredes do jogo
        allWalls[0] = wall1;
        allWalls[1] = wall2;
        allWalls[2] = wall3;
        allWalls[3] = wall4;
        //inicialização da parede atual
        wall1.SetActive(true); //ativa parede 1
        wall2.SetActive(false); //desativa parede 2
        wall3.SetActive(false); //desativa parede 3
        wall4.SetActive(false); //desativa parede 4
        currentWall = 0; //parede atual é a parede 1 (índice 0)
    }

    //função chamada ao clicar na seta esquerda
    // retorno vazio e pública
    public void MoveLeft(){
        //desativa parede atual acessando pelo índice
        allWalls[currentWall].SetActive(false);
        //se a parede atual for a parede 4
        if(currentWall == 3){
            // define parede atual como 1
            currentWall = 0;
            //ativa parede atual acessando pelo índice
            allWalls[0].SetActive(true);
        } //se não for
        else{
            currentWall++; //soma o índice da parede atual em 1
            allWalls[currentWall].SetActive(true); //ativa parede atual acessando pelo índice
        }

    }

    //função chamada ao clicar na seta direita
    // retorno vazio e pública
    public void MoveRight(){
        allWalls[currentWall].SetActive(false);
        if(currentWall == 0){
            currentWall = 3;
            allWalls[3].SetActive(true);
        }
        else{
            currentWall--;
            allWalls[currentWall].SetActive(true);
        }
    }

}
