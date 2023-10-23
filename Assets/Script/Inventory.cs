//classe responsável pelo inventário
// declaração das classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour //classe pública Inventory que herda de MonoBehaviour
{
    //array de botões que guarda todos os espaços do inventário
    public Button[] allSpaces;
    //variável pública e estática (preservar valor mesmo depois de sair do escopo) que guarda o botão selecionado
    [SerializeField] private static Button selectedItem;
    [SerializeField] private static Button newSelectedItem;

    //declaração de objeto da classe EventSystem
    EventSystem system;
    
    //procedimento Start é chamado antes da primeira atualização do frame
    void Start()
    {   
        //inicialização do sistema de eventos
        system = EventSystem.current;
        //inicialização do array de botões onde informamos que o array terá 8 posições
        allSpaces = new Button[8];
        //inicialização de cada posição do array de botões
        // por 8 vezes ele irá encontrar o botão com o nome "Space" e o respectivo número e irá atribuir a posição i do array
        for(int i = 0; i <= 7; i++){
            allSpaces[i] = GameObject.Find("Space" + (i+1)).GetComponent<Button>();
            allSpaces[i].interactable = false; //desativa a interação de todos os botões do array
        }
    }

    //método de retorna o botão selecionado
    public Button GetSelectedItem(){
        return selectedItem;
    }

    //procedimento que atribui o botão selecionado à variável selectedItem
    public void SetSelectedItemButton(){
        newSelectedItem = system.currentSelectedGameObject.GetComponent<Button>();
        if(newSelectedItem != selectedItem){
            selectedItem = newSelectedItem;
        } else {
            selectedItem = null;
        }
    }

    //método que ativa a interação do botão selecionado
    public void SetInteractable(int index){
        //ativa a interação botão acessando pelo índice
        allSpaces[index].interactable = true;
    }

    //procedimento que adiciona um item ao inventário
    public void addToInventory(Button item){
        //percorre o array de botões para encontrar um botão que não esteja interagível (que não tenha item)
        for(int i = 0; i <= 7; i++){
            //se o botão não estiver interagível
            if(allSpaces[i].interactable == false){
                //atribui o sprite do botão ao botão do inventário
                allSpaces[i].image.sprite = item.image.sprite;
                //atribui a cor do botão ao botão do inventário
                allSpaces[i].image.color = item.image.color;
                //ativa a interação do botão do inventário
                allSpaces[i].interactable = true;
                item.gameObject.SetActive(false); //desativa o botão do item
                break; //para o loop
            }
        }
    }

    //procedimento público que destrói o item do inventário
    public void DestroySelectedItem(){
        selectedItem.image.sprite = null; //sprite do botão nulo
        selectedItem.image.color = Color.white; //botão volta a ter cor branca
        selectedItem.interactable = false; //botão não fica mais interativo
        selectedItem = null;
    }

}
