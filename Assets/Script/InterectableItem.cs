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
    //declaração de variável privada que guarda o botão do item verde
    [SerializeField] private Button greenButton;

    [SerializeField] private GameObject doorMessage;
    [SerializeField] private GameObject doorFrameMessage;
    [SerializeField] private GameObject doorClickMessage;

    void Start(){
        doorMessage.SetActive(false);
        doorFrameMessage.SetActive(false);
        doorClickMessage.SetActive(false);
        
    }

    //procedimento público que ativa a interação do botão selecionado
    public void GreenInteract(){
        //atribui o retorno da função GetSelectedItem() à variável selectedItem //essa função existe no objeto inventory
        selectedItem = inventory.GetSelectedItem();
        if (selectedItem != null){
            //atribui a cor do botão selecionado ao botão do item verde
            greenButton.image.color = selectedItem.image.color;
            //destroi o item do inventário
            inventory.DestroySelectedItem();
        }
    }

    public void DoorInteract(){
        doorMessage.SetActive(true);
        doorFrameMessage.SetActive(true);
        doorClickMessage.SetActive(true);
    }

    public void DoorFrameInteract(){
        doorMessage.SetActive(false);
        doorFrameMessage.SetActive(false);
        doorClickMessage.SetActive(false);
    }

}
