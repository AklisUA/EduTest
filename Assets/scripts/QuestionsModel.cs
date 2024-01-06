using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class QuestionsModel    
{
      public string Question;
      public List<string> answers;
      public string  correctAnswer;
}
 
public class ParseReceivedData
{
    public List<QuestionsModel> questions;
    public static ParseReceivedData CreateFromJson(string json)
    {
        return JsonUtility.FromJson<ParseReceivedData>(json);
    }
} 