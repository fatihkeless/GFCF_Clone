using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hand : MonoBehaviour
{


    public List<GameObject> coffeeList = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        if(coffeeList.Count > 0)
        {

            if(coffeeList.Count == 1)
            {
                coffeeList[0].transform.DOMove(transform.GetChild(0).position, 1f);
            }
            else
            {
                for (int i = 0; i < coffeeList.Count; i++)
                {
                    coffeeList[i].transform.DOMove(transform.GetChild(i).position, 1f);
                }
            }

            
        }

        else if(coffeeList.Count == 2)
        {
            transform.tag = "Untagged";
        }
    }
}


