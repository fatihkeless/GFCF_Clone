using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{

    public Joystick joystick;
    public static float speed;
    private Camera mainCamera;
    public GameObject hand;
    public Transform target;
    private Vector3 offset;

    private static float currentSpeed;

    private void Awake()
    {
        speed = 0.6f;
        currentSpeed = speed;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        target = transform;
        offset = mainCamera.transform.position - target.position;
        hand = transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Mathf.Clamp(hand.transform.position.x, -0.34f, 0.34f);
        hand.transform.position = new Vector3(v, hand.transform.position.y, hand.transform.position.z);

        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        hand.transform.Translate(new Vector3(joystick.Horizontal, 0, 0) * Time.deltaTime);
        if (joystick.Horizontal != 0)
        {
            StackingManager.instance.moveListCoffee();
        }
        else
        {
            StackingManager.instance.moveListOrigin();
        }

        


    }

    private void FixedUpdate()
    {
        
    }
    private void LateUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset + target.position, 2 * Time.deltaTime);

    }

    public static IEnumerator switchState()
    {
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = currentSpeed;
    }
    public static void speedDown()
    {
        speed = 0;
    }
}
