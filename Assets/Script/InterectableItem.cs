// declaração de classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
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

    //procedimento público que ativa a interação do botão selecionado
    public void GreenInteract(){
        //atribui o retorno da função GetSelectedItem() à variável selectedItem //essa função existe no objeto inventory
        selectedItem = inventory.GetSelectedItem();
        //atribui a cor do botão selecionado ao botão do item verde
        greenButton.image.color = selectedItem.image.color;
    }
}
