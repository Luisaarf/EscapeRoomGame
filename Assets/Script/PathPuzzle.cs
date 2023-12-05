using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PathPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject firstDot;
    [SerializeField] private GameObject pathParent;
    [SerializeField] private GameObject PathPuzzleScene;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject pathSelected;

     [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject pinEnd;
    [SerializeField] private GameObject Knife;
    GameObject activePiece;
    bool isDragging;
    bool endPath;

    string[] DotPathNumbers = new string[15] { "house","01", "02", "12", "23", "33", "43", "44",  "53", "63", "64", "74","85", "76", "86"};

    int counterClick;
    int orderToBeginLine = 0;
     int orderToEndLine = 1;

    void Start()
    {
        firstDot.gameObject.SetActive(true);
        counterClick = 0;
        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                GameObject dot = Instantiate(firstDot, new Vector2(firstDot.transform.position.x + i, firstDot.transform.position.y+ j), transform.rotation);
                dot.transform.parent = pathParent.transform;
                dot.name=  System.Convert.ToString(i) + System.Convert.ToString(j);
            }
        }
        lineRenderer.positionCount = 1;
        lineRenderer.startWidth = 0.3f;
        endPath = false;
        Knife.SetActive(false);
    }

    //procedimento que verifica o caminho
    void verifyDotPath(){
        //aumenta a contagem de cliques
        counterClick++;
        //se o contador de cliques for par
        if(counterClick % 2 == 0){
            //verificar se é o próximo número do array e terminar o traçp
            isDragging = false;
            //se o objeto atingido for o próximo da lista
            if(pathSelected.name == DotPathNumbers[orderToEndLine]){ 
                //aumenta o contador para peggar próximo índice
                orderToEndLine++;
                orderToBeginLine++;
                //se o contador de final de linha for igual aa 15 (final do caminho)
                if(orderToEndLine == 15){
                    //ativa o botão de pinEnd
                    pinEnd.GetComponent<Button>().interactable = true;
                    Vector3 otherPosn = pinEnd.transform.position; //pegar e alterar posição do pin
                    pinEnd.transform.position = new Vector3(otherPosn.x, otherPosn.y, -5);
                    //determina o final do caminho
                    endPath = true;
                    Knife.SetActive(true); //ativa a faca

                }
            } else {
                //se o objeto atingido não for o próximo da lista
                //ele reduz o contador e contagem de posição do componente lineRenderer
                counterClick = counterClick - 2;
                lineRenderer.positionCount--;
                //não ta mais arrastando com o mouse
                isDragging= false;
            }
        } else { //se o contador de cliques for ímpar
            //verificar se é o próximo número do array e começar o traço
            if(pathSelected.name == DotPathNumbers[orderToBeginLine]){
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(0, new Vector3(firstDot.transform.position.x, firstDot.transform.position.y, -4));
                isDragging = true;
               //começa a traçar, linha no cursor
            } else {
                 //não começa o traço
                counterClick --;
                isDragging = false;
                //deletar o traço !
            }
        }
    }

    void Update()  //roda a cada atualização de frame
    {
        //se houver clique no botão esquerdo do mouse e o puzzle estiver ativo e o caminho não estiver completo
        if(Input.GetMouseButtonDown(0)&& PathPuzzleScene.activeSelf && endPath == false){
            //através do raycast (linha) que sai da câmera ele localiza a posição do mouse na  hora do clique
            Ray Cameraray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //pega o que o raycast atingiu e armazena em hit
            RaycastHit2D hit = Physics2D.GetRayIntersection(Cameraray);
            //se o raycast atingiu algo e o item selecionado no inventário for carvão
            if(hit.collider != null && inventory.GetSelectedItemName() == "Carvão"){ 
                //armazena o gameObject na variável pathSelected
                pathSelected = hit.collider.gameObject;
                //se o objeto atingido tiver a tag ponto
                if (pathSelected.tag == "Dot")
                {
                    //chama o método verifyDotPath
                    verifyDotPath();
                }
            } else if (isDragging== true){ // se a linha estiver sendo formada e não atender os requisitos anteriores
                counterClick --; //diminui o contador de cliques usado pra fazer a linha 
                isDragging = false; //para de traçar a linha
                lineRenderer.positionCount--; //diminui o número de pontos da linha
                // a contagem é importante pois o clique par e ímpar são usados para traçar a linha de forma diferente
                // ímpar começa o traço e par termina

            }
            else { 
                //se não atender nenhum dos requisitor anteriores
                isDragging = false; // para de traçar a linha
                //deletar o traço !
            }
        }
        //se o bool isDragging for verdadeiro

        if(isDragging){
            //atualiza a posição do mouse
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //atualiza a posição do mouse no eixo z para sempre ser -4 
            mousePos.z = -4;
            lineRenderer.SetPosition(orderToEndLine, mousePos);
        }
    }
}
