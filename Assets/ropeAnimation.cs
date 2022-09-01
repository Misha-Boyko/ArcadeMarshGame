using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeAnimation : MonoBehaviour
{
    private float chY_Animate;
    private float chX_Animate;

    private float chY;
    private float chX;
    public Transform marsh;
    public Transform refTran;

    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        //scale = new Vector3(0, 0.08f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        chY = marsh.position.y - refTran.position.y;
        chX = marsh.position.z - refTran.position.z;
        Debug.Log("the distance differences = " + Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2)) + " vs. " + Mathf.Sqrt(Mathf.Pow(chX, 2) + Mathf.Pow(chY, 2)));
        float dist = Mathf.Sqrt(Mathf.Pow(chX, 2) + Mathf.Pow(chY, 2)) - Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2));
        float ang = Mathf.Atan2((chY-chY_Animate), (chX - chX_Animate));
        scale = new Vector3(0, dist * Mathf.Sin(ang), dist * Mathf.Cos(ang));
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + scale.magnitude, transform.rotation.z, transform.rotation.w);
        transform.localScale = transform.localScale + new Vector3(0, scale.magnitude, 0); ;
        
        //if (Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2))< Mathf.Sqrt(Mathf.Pow(chX, 2) + Mathf.Pow(chY, 2)))
        //{
        //    Debug.Log("should be changing");
        //    transform.localScale = transform.localScale + scale;
        //} 
        //if(Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2)) > Mathf.Sqrt(Mathf.Pow(chX, 2) + Mathf.Pow(chY, 2)))
        //{
        //    transform.localScale = transform.localScale - scale;
        //}

        chY_Animate = marsh.position.y - refTran.position.y; ;
        chX_Animate = marsh.position.z - refTran.position.z;
    }
}
