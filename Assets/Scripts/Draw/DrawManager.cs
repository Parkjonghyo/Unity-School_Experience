using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{

    public GameObject drawPrefab;
    private GameObject theTrail;
    Plane planeObj;
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            theTrail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if (planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
            
        }else if (Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if (planeObj.Raycast(mouseRay, out _dis))
            {
                theTrail.transform.position = mouseRay.GetPoint(_dis);
            }
        }
    }
}
