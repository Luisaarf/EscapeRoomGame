//classe representando itens interativos
// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

//declaração de classe pública InterectableItem que herda de MonoBehaviour
public class InterectableItem : MonoBehaviour
{
    //declaração de objeto da classe Inventory
    [SerializeField] Inventory inventory;
    //declaração de variável privada que guarda o botão selecionado
    private Button selectedItem;

    //delcaração das variáveis que vão guardar os objetos relacionados a porta
    [SerializeField] private GameObject doorMessage;
    [SerializeField] private GameObject doorFrameMessage;
    [SerializeField] private GameObject doorClickMessage;
    //[SerializeField] private Button CoffeJar;
    //declaração de variável privada que guarda o sprite da xícara cheia
    [SerializeField] private Sprite filledCoffe;

    //Declaração de variável que faz referência ao script CakeInfo
    [SerializeField] CakeInfo cakeInfo;

    //declaração de variável que faz referência ao script SelectedFeedback
    [SerializeField] private SelectedFeedback selectedFeedback;
    [SerializeField] private GameObject VictoryPanel;


    void Start(){
        //antes do primeiro frame do jogo ele desativa os seguintes objetos
        doorMessage.SetActive(false);
        doorFrameMessage.SetActive(false);
        doorClickMessage.SetActive(false);
        VictoryPanel.SetActive(false);
    }

    //procedimento público que é ativado ao interagir com o bolo

    public void CakeInteract(){
        // com o script inventory ele chama a função GetSelectedItemName que retorna o nome do objeto selecionado
        string nameObject = inventory.GetSelectedItemName();
        //se o nome do objeto selecionado for "Faca" ele chama a função cutTheCake do script CakeInfo que corta o bolo
        if (nameObject == "Faca"){
            cakeInfo.cutTheCake();
        }
    }

    //procedimento público que é ativado ao interagir com a porta
    public void DoorInteract(){
        if(inventory.GetSelectedItemName() == "Chave"){
            VictoryPanel.SetActive(true);
        } else{
            //ativa os objetos
            doorMessage.SetActive(true);
            doorFrameMessage.SetActive(true);
            doorClickMessage.SetActive(true);
        }

    }

    //procedimento público que é ativado ao interagir com o jarro de café
    public void JarInteract(){
        //change coffee sprite
        //selectedItem  do inventory e mudar o sprite
        if (inventory.GetSelectedItemName() == "Xícara")
        inventory.GetSelectedItem().gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = filledCoffe;
        inventory.GetSelectedItem().GetComponent<InvSpaceInfo>().SetObjectName("Café");
        selectedFeedback.showObjectSelectedName();
    }

    //procedimento público que é ativado ao interagir com a porta
    public void DoorFrameInteract(){
        doorMessage.SetActive(false);
        doorFrameMessage.SetActive(false);
        doorClickMessage.SetActive(false);
    }

}
