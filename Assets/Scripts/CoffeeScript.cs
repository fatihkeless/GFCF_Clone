using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum coffeeStatus {empty,full,closed,sleeve }


public class CoffeeScript : MonoBehaviour
{
    public coffeeStatus CoffeeStatus = new coffeeStatus();

    public List<GameObject> objList = new List<GameObject>();

    private void Awake()
    {

        foreach (Transform child in transform)
        {
            objList.Add(child.gameObject);
        }

        CoffeeStatus = coffeeStatus.empty;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CoffeeStatus)
        {
            case coffeeStatus.empty:
                for(int i = 1;i < objList.Count; i++)
                {
                    objList[i].SetActive(false);
                }
                break;
            case coffeeStatus.full:
                objList[1].SetActive(true);
                break;
            case coffeeStatus.closed:
                objList[2].SetActive(true);
                break;
            case coffeeStatus.sleeve:
                objList[3].SetActive(true);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SleeveMachine"))
        {
            CoffeeStatus = coffeeStatus.closed;
        }
        else if (other.gameObject.CompareTag("SleeveWýnd"))
        {
            StackingManager.instance.jumpCoffee(gameObject);
            CoffeeStatus = coffeeStatus.sleeve;

        }
        else if (other.gameObject.CompareTag("CoffeeMachine"))
        {
            CoffeeStatus = coffeeStatus.full;
        }
    }

}
