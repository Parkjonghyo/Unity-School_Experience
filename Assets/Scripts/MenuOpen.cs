using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuOpen : MonoBehaviour
{
    public bool isSelectScreen = false;
    GameObject[] btns = new GameObject[10];
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        for (int i = 1; i <= btns.Length; i++)
        {
            btns[i-1] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public void OpenClose()
    {
        if (!isSelectScreen)
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].SetActive(true);
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isSelectScreen = true;
        }
        else
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].SetActive(false);
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isSelectScreen = false;
        }
        
    }
    
}
