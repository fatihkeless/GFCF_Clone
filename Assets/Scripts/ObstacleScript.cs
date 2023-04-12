using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public List<Vector3> poslist = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 newVector = new Vector3(Random.Range(-0.33f , 0.33f), 0, Random.Range(transform.localPosition.z + 0.5f, transform.localPosition.z + 2.5f));
            poslist.Add(newVector);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < poslist.Count; i++)
        {
            Gizmos.DrawSphere(poslist[i], 0.1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        


    }
}
