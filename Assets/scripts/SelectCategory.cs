using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCategory : MonoBehaviour
{
    public GameObject Q_ControllerObj;  
    public string Category;
    private QuestionsController GameScript;
    public void ChooseJsonFile()
    {
         GameScript.SetJson(Category); 
    }
    private void Start()
    {
         GameScript = (QuestionsController)Q_ControllerObj.GetComponent(typeof(QuestionsController));
    }
}
