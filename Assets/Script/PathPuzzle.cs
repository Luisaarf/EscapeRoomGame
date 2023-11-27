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

    void verifyDotPath(){
        counterClick++;
        if(counterClick % 2 == 0){
            //verificar se é o próximo número do array e traçar
            isDragging = false;
            if(pathSelected.name == DotPathNumbers[orderToEndLine]){
                orderToEndLine++;
                orderToBeginLine++;
                if(orderToEndLine == 15){
                    pinEnd.GetComponent<Button>().interactable = true;
                    Vector3 otherPosn = pinEnd.transform.position;
                    pinEnd.transform.position = new Vector3(otherPosn.x, otherPosn.y, -5);
                    endPath = true;
                    Knife.SetActive(true);

                }
            } else {
                counterClick = counterClick - 2;
                lineRenderer.positionCount--;
                isDragging= false;
            }
        } else {
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

    void Update()
    {
            if(Input.GetMouseButtonDown(0)&& PathPuzzleScene.activeSelf && endPath == false){
                Ray Cameraray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(Cameraray);
                if(hit.collider != null && inventory.GetSelectedItemName() == "Carvão"){  //hit collider não é nulo
                    pathSelected = hit.collider.gameObject;
                    if (pathSelected.tag == "Dot")
                    {
                        verifyDotPath();
                    }
                } else if (isDragging== true){
                    counterClick --;
                    isDragging = false;
                    lineRenderer.positionCount--;

                }
                else { 
                    //se o carvão não estiver selecionado else if(hit.collider != null && inventory.selectedItem == "carvao")
                    isDragging = false;
                    //deletar o traço !
                }
            }

            if(isDragging){
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = -4;
                lineRenderer.SetPosition(orderToEndLine, mousePos);
            }
    }
}
