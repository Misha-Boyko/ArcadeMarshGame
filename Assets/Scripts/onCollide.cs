using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollide : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //int refrence = LayerMask.NameToLayer("Marshmellow");
        //var layerM = other.gameObject.layer;
        //Debug.Log("other.gameObject.layer = " + other.gameObject.layer);

        if (other.gameObject.layer == 8) {     //the 'Marshmellow' layer is layer 8
        // Debug.Log("object shuda went boom");
        StartCoroutine(waitingForBoom());
        }
    }
    IEnumerator waitingForBoom()
    {
        yield return new WaitForSeconds(2);
        Destroy(cube);
    }
}
