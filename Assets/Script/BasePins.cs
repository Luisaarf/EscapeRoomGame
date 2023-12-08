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

    //declaração do objeto chave
    [SerializeField] GameObject keyButton;


    //declaração de variáveis booleanas que serão utilizadas para verificar se os pins estão na base correta
    bool isThirdPin = false;
    bool isSecondPin = false;
    bool isFirstPin = false;

    // Start is called before the first frame update
    void Start()
    {
        //inicialização dos botões que mudam para a cor preta quando o jogo começa através do componente Image
        firstPinBase.gameObject.GetComponent<Image>().color = Color.black;
        secondPinBase.gameObject.GetComponent<Image>().color = Color.black;
        thirdPinBase.gameObject.GetComponent<Image>().color = Color.black;
       // keyButton.gameObject.SetActive(true);
        keyButton.gameObject.SetActive(false);        
    }

    //procedimento público que é chamado ao interagir com a base do primeiro pin
    public void interactFirstPinBase()
    {
        //se o item selecionado for o primeiro pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "Happy Mask Pin")
        {
            firstPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
            isFirstPin = true;
            verifyBases();
        }
       
    }

    //procedimento público que é chamado ao interagir com a base do segundo pin
    public void interactSecondPinBase()
    {
        //se o item selecionado for o segundo pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "Daughter Bear Pin")
        {
            secondPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
            isSecondPin = true;
            verifyBases();
        }
    }

    //procedimento público que é chamado ao interagir com a base do terceiro pin
    public void interactThirdPinBase()
    {
        //se o item selecionado for o terceiro pin ele muda a cor da base para branco e destroi o item selecionado
        if (inventory.GetSelectedItemName() == "Sad Mask Pin")
        {
            thirdPinBase.gameObject.GetComponent<Image>().color = Color.white;
            inventory.DestroySelectedItem();
            isThirdPin = true;
            verifyBases();
        }
    }

    //procedimento que verifica se as bases dos pins estão corretas
    public void verifyBases(){
        if( isFirstPin && isSecondPin && isThirdPin){
            //activeKey();
            keyButton.gameObject.SetActive(true);
        }
    }

    //procedimento público que ativa o objeto chave
    public void activeKey(){
        //ativa o objeto chave
        keyButton.gameObject.SetActive(true);
    }
}
