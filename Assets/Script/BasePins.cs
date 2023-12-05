//classe responsável pela base dos pins
// declaração das classes a serem utilizadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePins : MonoBehaviour //classe pública BasePins que herda de MonoBehaviour
{
    //declaração do script Inventory
    [SerializeField] private Inventory inventory;
    //declaração dos botões que serão utilizados para interagir com os pins
    [SerializeField] private Button firstPinBase;
    [SerializeField] private Button secondPinBase;
    [SerializeField] private Button thirdPinBase;
    // Start is called before the first frame update
    void Start()
    {
        //inicialização dos botões que mudam para a cor preta quando o jogo começa através do componente Image
        firstPinBase.gameObject.GetComponent<Image>().color = Color.black;
        secondPinBase.gameObject.GetComponent<Image>().color = Color.black;
        thirdPinBase.gameObject.GetComponent<Image>().color = Color.black;
        
    }

    //procedimento público que é chamado ao interagir com a base do primeiro pin
    public void interactFirstPinBase()
    {
        //se o item selecionado for o primeiro pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "1st Pin")
        {
            firstPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
        }
    }

    //procedimento público que é chamado ao interagir com a base do segundo pin
    public void interactSecondPinBase()
    {
        //se o item selecionado for o segundo pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "2nd Pin")
        {
            secondPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
        }
    }

    //procedimento público que é chamado ao interagir com a base do terceiro pin
    public void interactThirdPinBase()
    {
        //se o item selecionado for o terceiro pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "3rd Pin")
        {
            thirdPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
        }
    }
}
