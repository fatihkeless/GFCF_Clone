using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionScript : MonoBehaviour
{

    bool move;
    public GameObject money;
    private PlayerScript playerNew;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
        if (transform.CompareTag("Player"))
        {
            playerNew = GetComponentInParent<PlayerScript>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.localPosition = new Vector3(0.0165999997f, 0.00779999979f, 0.0465999991f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coffee"))
        {
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
            StackingManager.instance.stackCoffee(other.gameObject, StackingManager.instance.coffeeIndex());
            
            other.gameObject.AddComponent<CollisionScript>();
            other.gameObject.tag = "SelectedCoffee";

        }

        if (other.gameObject.CompareTag("Hand"))
        {

            Hand newHand = other.gameObject.GetComponent<Hand>();

            if (StackingManager.instance.coffeeIndex() != 0)
            {

                if(newHand.coffeeList.Count < 2)
                {
                    
                    StackingManager.instance.removeList();
                    newHand.coffeeList.Add(gameObject);
                }
                

            }
            


        }

        if (other.gameObject.CompareTag("Obstacle"))
        {


        }

        if (gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                PlayerScript.speedDown();
                ;
                transform.parent.gameObject.transform.DOMove(money.transform.position, 1f).OnComplete(() => StartCoroutine(gameManager.stackMoney()));
                transform.parent.gameObject.transform.DORotateQuaternion(new Quaternion(0, 0, 0.707106829f, 0.707106829f), 1f).OnComplete(()=>
                transform.GetChild(1).transform.localPosition = new Vector3(0.0120000001f, 0, -0.112999998f));
            }
        }


    }
}
