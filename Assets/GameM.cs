using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Photon;


public class GameM : MonoBehaviour
{
    public Button stopButt;
    public Button woodButt;
    private bool buildW;
    private bool build;
    private Vector3 marshCoord;
 //   public MonoBehaviour tMove;
    public Rigidbody marshR;
    private bool clicked;
    public Transform refForMarsh;
    private bool moveAnimate;
    private float chY;
    private float chX;

    // Start is called before the first frame update
    void Start()
    {
        moveAnimate = false;
        clicked = false;
        marshR.useGravity = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        build = true;
        buildW = false;
        Button woodB = woodButt.GetComponent<Button>();
        woodB.onClick.AddListener(BuildWood);
        //   Button stopB = stopButt.GetComponent<Button>();
        stopButt.onClick.AddListener(StopBuilding);
    }

    void StopBuilding()
    {
        build = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void BuildWood()
    {
        buildW = !buildW;
        Debug.Log("Button wood pressed" + "  The state of buildW is = " + buildW);
        if (Input.GetMouseButtonDown(0) && build) {
            {
                if (Input.GetMouseButtonDown(0) && !buildW)
                {
                    Debug.Log("You pressed the mouse, but this is the second time you pressed the wood button");
                    return;
                }
                if(((Input.mousePosition.x) / Screen.width) < 0.8)
                {
                    GameObject Wblock = (GameObject)Instantiate(Resources.Load("WoodP"));
                    Wblock.transform.position = new Vector3(10, 2 + 13 * (Input.mousePosition.y) / Screen.height, 27 - 17 * ((Input.mousePosition.x) / Screen.width));
                }

                       
            }

        }
    }




        // Update is called once per frame
        void Update() {

        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        

        if (!build)
        {
            mouseMove();
            //   if (Input.GetKeyDown("a"))
            // {
            transform.position = new Vector3(10.86f, transform.position.y, transform.position.z);
            //Debug.Log("transform translate");
            //transform.Translate(move * Time.deltaTime, Space.World
            if (!clicked)
                if (Input.GetMouseButtonDown(0) && !clicked)
                {
                    Debug.Log("clicked");

                    clicked = true;
                    chY = refForMarsh.position.y - transform.position.y;
                    chX = refForMarsh.position.z - transform.position.z;

                    Debug.Log("the chY altered = " + Mathf.Pow(chY, 3) + 10);
                    Debug.Log("the chX altered = " + Mathf.Pow(chX, 3));

                    //float thAngle = Mathf.Atan(chY / chX) + Mathf.PI / 2;
                    moveAnimate = true;
                }
            if (moveAnimate)
            {
                float chY_Animate = refForMarsh.position.y - transform.position.y;
                float chX_Animate = refForMarsh.position.z - transform.position.z;
                if (Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2)) > 2)
                {
                    moveAnimate = true;

                    transform.Translate(new Vector3(0, chY, chX) * Mathf.Sqrt(Mathf.Pow(chX_Animate, 2) + Mathf.Pow(chY_Animate, 2)) * Time.deltaTime);
                    chY_Animate = refForMarsh.position.y - transform.position.y;
                    chX_Animate = refForMarsh.position.z - transform.position.z;
                }
                else
                {
                    moveAnimate = false;
                }
                if (!moveAnimate)
                {
                    if (Mathf.Sqrt(Mathf.Pow(Mathf.Pow(chY, 3), 2) + Mathf.Pow(Mathf.Pow(chX, 3), 2)) > 100)
                    {
                        Vector3 moveMarsh = new Vector3(0, Mathf.Pow(chY, 3), Mathf.Pow(chX, 3)).normalized * 3000;
                        marshR.AddForce(moveMarsh);
                    }
                    else
                    {
                        marshR.AddForce(new Vector3(0, Mathf.Pow(chY, 3), Mathf.Pow(chX, 3)) * 30);
                    }

                    marshR.useGravity = true;
                }
                if (buildW)
                    BuildWood();
            }
        }
    }

            
    }

        void mouseMove() {

            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 move = new Vector3(0, y, -x);

            transform.Translate(move, Space.World);
        }
        
}
