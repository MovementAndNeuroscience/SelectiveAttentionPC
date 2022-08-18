using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class FileSaver : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void saveFile(string subjectID,float[] visRTs, 
       float[] visOnsetTimes, float[] visOffsetTimes, float[] visFixOnsetTimes, float[] visFixOffsetTimes, float[] visBlankOnsetTimes, float[] visBlankOffsetTimes, float[] visFeedbackOnsetTimes, float[] visFeedbackOffsetTimes,
       float[] visStimuliOnScreenTime, string[] visPresentedConditions, string[] visAnswers, int[] visAnswerCodes,
       float[] audVisRTs, float[] audVisOnsetTimes, float[] audVisOffsetTimes, float[] audVisFixOnsetTimes, float[] audVisFixOffsetTimes, float[] audVisBlankOnsetTimes, float[] audVisBlankOffsetTimes, float[] audVisFeedbackOnsetTimes, float[] audVisFeedbackOffsetTimes,
       float[] audVisStimuliOnScreenTimes, string[] audVisPresentedConditions, string[] audVisAnswers, int[] audVisAnswerCodes,
       float[] audRTs, float[] audOnsetTimes, float[] audOffsetTimes, float[] audFixOnsetTimes, float[] audFixOffsetTimes, float[] audBlankOnsetTimes, float[] audBlankOffsetTimes, float[] audFeedbackOnsetTimes, float[] audFeedbackOffsetTimes,
       float[] audStimuliOnScreenTimes, string[] audPresentedConditions, string[] audAnswers, int[] audAnswerCodes)
    {
        // Creating First row of titles manually..
        string[] rowDataTemp = new string[39];
        rowDataTemp[0] = "Visual ReactionTime";
        rowDataTemp[1] = "Visual Stimuli Onset Time";
        rowDataTemp[2] = "Visual Stimuli Offset Time";
        rowDataTemp[3] = "Visual Fixation Cross Onset Time";
        rowDataTemp[4] = "Visual Fixation Cross Offset Time";
        rowDataTemp[5] = "Visual Blank Screen Onset Time";
        rowDataTemp[6] = "Visual Blank Screen Offset Time";
        rowDataTemp[7] = "Visual Feedback Onset Time";
        rowDataTemp[8] = "Visual Feedback Offset Time";
        rowDataTemp[9] = "Visual Stimuli On Screen Time";
        rowDataTemp[10] = "Visual Presented Condition";
        rowDataTemp[11] = "Visual Answers";
        rowDataTemp[12] = "Visual Answer Codes";
        rowDataTemp[13] = "Audio Visual ReactionTime";
        rowDataTemp[14] = "Audio Visual Stimuli Onset Time";
        rowDataTemp[15] = "Audio Visual Stimuli Offset Time";
        rowDataTemp[16] = "Audio Visual Fixation Cross Onset Time";
        rowDataTemp[17] = "Audio Visual Fixation Cross Offset Time";
        rowDataTemp[18] = "Audio Visual Blank Screen Onset Time";
        rowDataTemp[19] = "Audio Visual Blank Screen Offset Time";
        rowDataTemp[20] = "Audio Visual Feedback Onset Time";
        rowDataTemp[21] = "Audio Visual Feedback Offset Time";
        rowDataTemp[22] = "Audio Visual Stimuli On Screen Time";
        rowDataTemp[23] = "Audio Visual Presented Condition";
        rowDataTemp[24] = "Audio Visual Answers";
        rowDataTemp[25] = "Audio Visual Answer Codes";
        rowDataTemp[26] = "Audio ReactionTime";
        rowDataTemp[27] = "Audio Stimuli Onset Time";
        rowDataTemp[28] = "Audio Stimuli Offset Time";
        rowDataTemp[29] = "Audio Fixation Cross Onset Time";
        rowDataTemp[30] = "Audio Fixation Cross Offset Time";
        rowDataTemp[31] = "Audio Blank Screen Onset Time";
        rowDataTemp[32] = "Audio Blank Screen Offset Time";
        rowDataTemp[33] = "Audio Feedback Onset Time";
        rowDataTemp[34] = "Audio Feedback Offset Time";
        rowDataTemp[35] = "Audio Stimuli On Screen Time";
        rowDataTemp[36] = "Audio Presented Condition";
        rowDataTemp[37] = "Audio Answers";
        rowDataTemp[38] = "Audio Answer Codes";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for (int i = 0; i < visRTs.Length; i++)
        {
            rowDataTemp = new string[39];
            rowDataTemp[0] = visRTs[i].ToString();
            rowDataTemp[1] = visOnsetTimes[i].ToString();
            rowDataTemp[2] = visOffsetTimes[i].ToString();
            rowDataTemp[3] = visFixOnsetTimes[i].ToString();
            rowDataTemp[4] = visFixOffsetTimes[i].ToString();
            rowDataTemp[5] = visBlankOnsetTimes[i].ToString();
            rowDataTemp[6] = visBlankOffsetTimes[i].ToString();
            rowDataTemp[7] = visFeedbackOnsetTimes[i].ToString();
            rowDataTemp[8] = visFeedbackOffsetTimes[i].ToString();
            rowDataTemp[9] = visStimuliOnScreenTime[i].ToString();
            rowDataTemp[10] = visPresentedConditions[i].ToString();
            rowDataTemp[11] = visAnswers[i].ToString();
            rowDataTemp[12] = visAnswerCodes[i].ToString();
            rowDataTemp[13] = audVisRTs[i].ToString();
            rowDataTemp[14] = audVisOnsetTimes[i].ToString();
            rowDataTemp[15] = audVisOffsetTimes[i].ToString();
            rowDataTemp[16] = audVisFixOnsetTimes[i].ToString();
            rowDataTemp[17] = audVisFixOffsetTimes[i].ToString();
            rowDataTemp[18] = audVisBlankOnsetTimes[i].ToString();
            rowDataTemp[19] = audVisBlankOffsetTimes[i].ToString();
            rowDataTemp[20] = audVisFeedbackOnsetTimes[i].ToString();
            rowDataTemp[21] = audVisFeedbackOffsetTimes[i].ToString();
            rowDataTemp[22] = audVisStimuliOnScreenTimes[i].ToString();
            rowDataTemp[23] = audVisPresentedConditions[i].ToString();
            rowDataTemp[24] = audVisAnswers[i].ToString();
            rowDataTemp[25] = audVisAnswerCodes[i].ToString();
            rowDataTemp[26] = audRTs[i].ToString();
            rowDataTemp[27] = audOnsetTimes[i].ToString();
            rowDataTemp[28] = audOffsetTimes[i].ToString();
            rowDataTemp[29] = audFixOnsetTimes[i].ToString();
            rowDataTemp[30] = audFixOffsetTimes[i].ToString();
            rowDataTemp[31] = audBlankOnsetTimes[i].ToString();
            rowDataTemp[32] = audBlankOffsetTimes[i].ToString();
            rowDataTemp[33] = audFeedbackOnsetTimes[i].ToString();
            rowDataTemp[34] = audFeedbackOffsetTimes[i].ToString();
            rowDataTemp[35] = audStimuliOnScreenTimes[i].ToString();
            rowDataTemp[36] = audPresentedConditions[i].ToString();
            rowDataTemp[37] = audAnswers[i].ToString();
            rowDataTemp[38] = audAnswerCodes[i].ToString();
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ";";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath(subjectID);

        StreamWriter outStream = File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(string SubjectID)
    {
        var fileName = SubjectID + "_SelectAttention_Data.csv";
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + fileName;
#elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+fileName;
#else
        return Application.dataPath +"/"+fileName;
#endif
    }
}
