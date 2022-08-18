using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ContinueExperiment : MonoBehaviour
{
    public GameObject slowTrainingSession; 
    public GameObject NormalTrainingSession; 
    public GameObject VStimuliController; 
    public GameObject AVstimuliController;
    public GameObject AstimuliController;

    private bool enableSlowTraining = true;
    private bool enableTraining = false;
    private bool enableVStim = false;
    private bool enableAVStim = false;
    private bool enableAStim = false;
    private TMP_Text textMP;

    private string[] vStimAnswers; 
    private string[] aVStimAnswers;
    private string[] aStimAnswers; 
    // Start is called before the first frame update
    void Start()
    {
        textMP = GetComponent<TMP_Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (slowTrainingSession.GetComponent<SlowTrainingController>().AllReactionTimesFound() && enableSlowTraining == true)
        {
            var answers = slowTrainingSession.GetComponent<SlowTrainingController>().GetAnswers();
            CalculateAndInsertAccuracy(answers);
            enableTraining = true;

            if (Input.GetKeyDown(KeyCode.Return) && enableTraining)
            {
                NormalTrainingSession.SetActive(true);
                this.gameObject.SetActive(false);
                enableSlowTraining = false;
            }
        }

        else if (NormalTrainingSession.GetComponent<StimuliController>().AllReactionTimesFound() && enableTraining == true)
        {
            var answers = NormalTrainingSession.GetComponent<StimuliController>().GetAnswers();
            CalculateAndInsertAccuracy(answers);
            enableVStim = true;

            if (Input.GetKeyDown(KeyCode.Return) && enableVStim)
            {
                VStimuliController.SetActive(true);
                gameObject.SetActive(false);
                enableTraining = false;
            }
        }

        else if (VStimuliController.GetComponent<StimuliController>().AllReactionTimesFound() && enableVStim == true)
        {
            vStimAnswers = VStimuliController.GetComponent<StimuliController>().GetAnswers();
            CalculateAndInsertAccuracy(vStimAnswers);
            enableAVStim = true;

            if (Input.GetKeyDown(KeyCode.Return) && enableAVStim)
            {
                AVstimuliController.SetActive(true);
                gameObject.SetActive(false);
                enableVStim = false;
            }
        }

        else if (AVstimuliController.GetComponent<AudioVisualStimuliController>().AllReactionTimesFound() && enableAVStim == true)
        {
            aVStimAnswers = AVstimuliController.GetComponent<AudioVisualStimuliController>().GetAnswers();
            CalculateAndInsertAccuracy(aVStimAnswers);
            enableAStim = true;

            if (Input.GetKeyDown(KeyCode.Return) && enableAStim)
            {
                AstimuliController.SetActive(true);
                gameObject.SetActive(false);
                enableAVStim = false;
            }
        }

        else if (AstimuliController.GetComponent<AudioStimuliController>().AllReactionTimesFound() && enableAStim == true)
        {
            aStimAnswers = AstimuliController.GetComponent<AudioStimuliController>().GetAnswers();
            List<string> answers = new List<string>();
            answers.AddRange(vStimAnswers); 
            answers.AddRange(aStimAnswers);
            answers.AddRange(aVStimAnswers);

            double totanswers = answers.Count;
            double correctAnswerCount = 0;
            foreach (var answer in answers)
            {
                if (answer == "Correct")
                {
                    correctAnswerCount++;
                }
            }
            double procentCorrect = (correctAnswerCount / totanswers) * 100;
            var roundedCorrect = ((int)procentCorrect);
            textMP.text = "Du har reddet julen! \n Tillykke du fangede \n" + roundedCorrect.ToString() + "% af alle b'erne og p'erne \n Julemanden kan nu skrive navne på alle julegaverne \n Tryk på enter for at afslutte";

            enableAVStim = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.SetActive(false);
                enableAVStim = false;
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            }
        }
    }

    private void CalculateAndInsertAccuracy(string[] answers)
    {
        double totanswers = answers.Length;
        double correctAnswerCount = 0;
        foreach (var answer in answers)
        {
            if (answer == "Correct")
            {
                correctAnswerCount++;
            }
        }
        double procentCorrect = (correctAnswerCount / totanswers) * 100;
        int roundedCorrect = (int)Mathf.Round((float)procentCorrect);  
        textMP.text = "Pause \n Tillykke du fangede \n" + roundedCorrect.ToString() + "% af b'erne og p'erne \n Tryk på enter for at fortsætte";
    }
}
