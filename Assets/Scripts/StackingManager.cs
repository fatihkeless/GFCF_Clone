using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackingManager : MonoBehaviour
{
    public static StackingManager instance;

    public List<GameObject> coffeeList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();

    public Transform parent;

    public GameObject money;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

       
    }

    // Start is called before the first frame update
    void Start()
    {
        coffeeList.Add(transform.GetChild(0).gameObject);
        moneyList.Add(transform.GetChild(0).gameObject);
        parent = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            removeList();
        }
    }

    public void stackCoffee(GameObject other, int index)
    {
        other.transform.parent = parent;
        coffeeList.Add(other.gameObject);
        Vector3 newPos = coffeeList[index].transform.localPosition;
        if(coffeeIndex() == 1)
        {

            newPos.z += 0.11f;
            newPos.y = -0.0476f;
        }
        else
        {
            newPos.z += 0.09f;
            newPos.y = -0.0476f;
        }
        
        other.transform.localPosition = newPos;
        StartCoroutine(pickMoney());


        

    }

    public void stackMoney(GameObject obj)
    {

        

        GameObject newObj = Instantiate(obj, transform.position, Quaternion.identity);
        
        newObj.transform.parent = parent;
        newObj.transform.localRotation = new Quaternion(0.707106829f, 0, 0.707106829f, 0);
        moneyList.Insert(0, newObj.gameObject);
        Vector3 newPos = coffeeList[coffeeList.Count - 1].transform.localPosition;



        for (int i = 1; i < moneyList.Count; i++)
        {
            Vector3 prevPos = moneyList[i - 1].transform.localPosition;
            newPos.x = prevPos.x + 0.06f;
            moneyList[i].transform.localPosition = newPos;
            newPos = prevPos;
            
        }

        obj.transform.localPosition = newPos;


    }

    public IEnumerator pickMoney()
    {

        if (coffeeList.Count > 1)
        {
            for (int i = coffeeIndex(); i > 1; i--)
            {
                int index = i;
                coffeeList[index].transform.DOScale(1.1f, 0.1f).OnComplete(() =>
                 coffeeList[index].transform.DOScale(1, 0.1f));
                yield return new WaitForSeconds(0.05f);


            }
        }

    }


    public int coffeeIndex()
    {
        return coffeeList.Count - 1;
    }
    public void moveListCoffee()
    {

        for (int i = 1; i < coffeeList.Count; i++)
        {
            int index;
            index = i;
            Vector3 pos = coffeeList[index].transform.localPosition;
            pos.x = coffeeList[index - 1].transform.localPosition.x;
            coffeeList[i].transform.DOLocalMove(pos, 0.15f);


        }


    }


    public void jumpCoffee(GameObject obj)
    {
        obj.transform.DOMoveY(0.3f, 0.5f).OnComplete(() =>
                  obj.transform.DOMoveY(0, 0.5f));
    }

    public void moveListOrigin()
    {

        for (int i = 1; i < coffeeList.Count; i++)
        {
            int index;
            index = i;
            Vector3 pos = coffeeList[index].transform.localPosition;
            pos.x = coffeeList[0].transform.localPosition.x;
            coffeeList[index].transform.DOLocalMove(pos, 0.15f);


        }


    }

    public void removeList()
    {

        coffeeList.Remove(coffeeList[coffeeIndex()]);

    }


    public void obstacle(ObstacleScript obstcScript)
    {
        List<GameObject> freeCoffeeList = new List<GameObject>();
        


    }

}
