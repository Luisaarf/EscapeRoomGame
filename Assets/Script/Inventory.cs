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
    //declaração do script SelectedFeedback
    [SerializeField] private SelectedFeedback selectedFeedback;
    [SerializeField] private GameObject spaceIn;
    [SerializeField] private Sprite square;

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

    //método que retorna o botão selecionado
    public Button GetSelectedItem(){
        if (selectedItem != null){
            return selectedItem;
        }
        return null;
    }

    //função que retorna o nome do item selecionado
    public string GetSelectedItemName(){
        //se o item selecionado não for nulo
        if(selectedItem != null){
            //retorna o nome
            return selectedItem.GetComponent<InvSpaceInfo>().GetObjectName();
        }
        return null;
    }


    //procedimento que atribui o botão selecionado à variável selectedItem
    public void SetSelectedItemButton(){
        //pega o componente do novo item selecionado
        newSelectedItem = system.currentSelectedGameObject.GetComponent<Button>();
        if(newSelectedItem != selectedItem){ //se o novo item selecionado não for o mesmo que o item selecionado anteriormente
            if(selectedItem != null){
                //ele volta o contorno do item anterior para preto
                selectedItem.GetComponent<Outline>().effectColor = Color.black;
            }
            //atribui o novo item selecionado à variável selectedItem
            selectedItem = newSelectedItem;
            //atribui a cor amarela ao contorno do novo item selecionado
            newSelectedItem.GetComponent<Outline>().effectColor = Color.yellow;
            //chama o método showObjectSelectedName do script SelectedFeedback
            selectedFeedback.showObjectSelectedName();
        } else {
            //se o novo item selecionado for o mesmo que o item selecionado anteriormente ele tira a seleção
            selectedItem = null;
            newSelectedItem.GetComponent<Outline>().effectColor = Color.black;
            selectedFeedback.showObjectSelectedName();
        }
        selectedFeedback.CoffeeInteract();
        
    }

    //procedimento que tem a função de tirar a seleção do item quando utilizado 
    //volta ao padrão 
    public void SetSelectedItemButtonNull(){
        selectedItem = null;
        newSelectedItem.GetComponent<Outline>().effectColor = Color.black;
        selectedFeedback.showObjectSelectedName();
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
                //pega o filho do botão do inventário da posição i e atribui à variável spaceIn
                spaceIn = allSpaces[i].gameObject.transform.GetChild(0).gameObject;
                //atribui o sprite do botão ao filho do botão do inventário
                spaceIn.GetComponent<Image>().sprite = item.image.sprite;
                //atribui a cor do botão ao filho do botão do inventário
                spaceIn.GetComponent<Image>().color = item.image.color;
                //acessa o nome do objeto escrito no componente collectInfo de cada objeto coletável
                // ao filho do botão do inventário
                allSpaces[i].GetComponent<InvSpaceInfo>().SetObjectName(item.GetComponent<CollectInfo>().GetObjectName());
                //ativa a interação do botão do inventário 
                //assim ele poderá ser selecionado e será compreendido como um botão que tem um item armazenado nele
                allSpaces[i].interactable = true;
                item.gameObject.SetActive(false); //desativa o botão do item
                break; //para o loop
            }
        }
    }

    //procedimento público que destrói o item do inventário
    public void DestroySelectedItem(){
        selectedItem.GetComponent<Image>().sprite = square; //sprite do botão nulo
        selectedItem.GetComponent<Image>().color =Color.white; //botão volta a ter cor padrão
        selectedItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = square; //sprite do filho do botão nulo
        selectedItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(0.784f, 0.784f, 0.784f, 1f); //cor do filho do botão volta a ser padrão
        selectedItem.interactable = false; //botão não fica mais interativo
        SetSelectedItemButtonNull(); //botão selecionado volta a ser nulo
    }

}
