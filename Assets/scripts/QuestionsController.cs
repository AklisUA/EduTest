using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq; // OrderBy
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsController : MonoBehaviour
{   
    public Button button1;
    public Button button2;
    public Button button3;
    private int QuestionNumber = 0;
    private string JsonName;
    public List<Button> Answers;
    public List<QuestionsModel> questionlist;
    public TMP_Text QuestionText;
    public GameObject correct;
    public GameObject wrong;
    public GameObject CanvasGameOver;
    public GameObject CanvasGame;
    void Start()
    {
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(delegate { CheckAnswer(button1.GetComponentInChildren<TMP_Text>().text); });

        Button btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(delegate { CheckAnswer(button2.GetComponentInChildren<TMP_Text>().text); });

        Button btn3 = button3.GetComponent<Button>();
        btn3.onClick.AddListener(delegate { CheckAnswer(button3.GetComponentInChildren<TMP_Text>().text); });
                      
    }

    public void SetJson(string name)
    {  
        JsonName = name;
        QuestionNumber = 0;
        questionlist.Clear();
        string path = Path.Combine(Application.streamingAssetsPath, JsonName);
        string jsonContent = File.ReadAllText(path,Encoding.UTF8);
      // byte[] fileBytes = File.ReadAllBytes(path);
       // string jsonContent = Encoding.UTF8.GetString(fileBytes);
        ParseReceivedData questionsData = ParseReceivedData.CreateFromJson(jsonContent);
        questionlist = questionsData.questions;
        List<QuestionsModel>shuffledList = questionlist.OrderBy(x => Random.value).ToList();
        questionlist = shuffledList; 
        QuestionChanger();
        
    }
     private void QuestionChanger()
    {
        wrong.SetActive(false);
        correct.SetActive(false);

        if (QuestionNumber < questionlist.Count )
        {
            QuestionText.text = questionlist[QuestionNumber].Question;
            Debug.Log( questionlist[QuestionNumber].Question );
            AnswersChanger();
            
        } 
        else {
            CanvasGame.SetActive(false);
            CanvasGameOver.SetActive(true);
                        
        }
  
    }
    private void AnswersChanger()
    {
        for (int i = 0; i < Answers.Count; ++i)
        {
            Answers[i].GetComponentInChildren<TMP_Text>().text = questionlist[QuestionNumber].answers[i];


        }
    }
    public void CheckAnswer(  string MyAnswer)
    {
        if ( QuestionNumber < questionlist.Count && MyAnswer == questionlist[QuestionNumber].correctAnswer)
        {  
            QuestionNumber++;
            wrong.SetActive(false);
            correct.SetActive(true);
            Invoke("QuestionChanger", 2.0f);
        }
        else
        {
            wrong.SetActive(true);

        }
    }   
    
}
