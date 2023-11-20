//classe representando itens coletáveis
// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

//declaração de classe pública CollectableItem que herda de MonoBehaviour
public class CollectableItem : MonoBehaviour
{
    //declaração de objeto da classe Inventory
    [SerializeField] Inventory inventory;
    //[SerializeField] Button charcoalButton;
    //declaração de objeto da classe EventSystem
    EventSystem system;
    //declaração de variável privada que guarda o botão selecionado 
    Button thisCollectableItem;

    //procedimento Start é chamado antes da primeira atualização do frame
    void Start()
    {
        //inicialização do sistema de eventos
        system = EventSystem.current;
    }

    //procedimento público que adiciona um item ao inventário
    public void addItem(){
        //atribui o botão selecionado à variável thisCollectableItem
        thisCollectableItem = system.currentSelectedGameObject.GetComponent<Button>();
        //chama a função addToInventory() do objeto inventory e passa como parâmetro o botão selecionado
        inventory.addToInventory(thisCollectableItem);
    }

    


}
