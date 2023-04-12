using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject money;
    public Transform moneyTransform;
    public GameObject player;
    private PlayerScript playerScript;
    public StackingManager stacking;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }


    public IEnumerator stackMoney()
    {
        for (int i = 0; i < 20; i++)
        {
            stacking.stackMoney(money.gameObject);
            playerScript.target = playerScript.hand.transform;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
}
