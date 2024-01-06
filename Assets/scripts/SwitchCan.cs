using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchCan : MonoBehaviour
{
   
    public GameObject Canvas;
    public GameObject CategoryCan;
    public void SwitchToCategoryCan()
    {
        Canvas.SetActive(false);  
        CategoryCan.SetActive(true);
        
    }
}
    