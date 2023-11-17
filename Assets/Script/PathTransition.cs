using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTransition : MonoBehaviour
{
    [SerializeField] private GameObject pathScene;
    [SerializeField] private GameObject canvasWall3;

    [SerializeField] private GameObject littleDot;
    [SerializeField] private GameObject littleDotsParent;

    public void ClosePathPuzzle()
    {
        pathScene.SetActive(false);
        canvasWall3.SetActive(true);
    }

    public void OpenPathPuzzle()
    {
        pathScene.SetActive(true);
        canvasWall3.SetActive(false);
    }

    void Start()
    {
      pathScene.SetActive(false); 

        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                GameObject littleDots = Instantiate(littleDot, new Vector2((littleDot.transform.position.x + i)/2, (littleDot.transform.position.y+ j)/2), Quaternion.identity);
                littleDots.transform.localScale = new Vector3(0.02403646f *2, 0.02403646f*2, 0.4699604f);
                littleDots.transform.parent = littleDotsParent.transform;
                littleDots.name=  System.Convert.ToString(i) + System.Convert.ToString(j);
            }
        } 

        littleDot.SetActive(false);
    }

}
