using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SceneController : MonoBehaviour
{
    public GameObject subjectIdTextField;
    public GameObject InsertSubIdText;
    public GameObject slowTrainingSession;
    public GameObject normalTrainingSession;
    public GameObject StimuliController;
    public GameObject audioStimuliController;
    public GameObject visualaudioStimuliController;
    public GameObject introtext;
    public GameObject vejledningstext;
    public GameObject pause; 
    public GameObject p_target;
    public GameObject b_target;
    public GameObject p_distractor;
    public GameObject b_distractor;
    public GameObject g_distractor;
    public GameObject h_filler;
    public GameObject l_filler;
    public GameObject y_filler;
    public GameObject x_fixation;
    public GameObject faster;
    public GameObject happyFace;
    public GameObject sadFace; 

    public string subjectId;

    private bool enableIntroText = true;
    private bool enablePauseAfterSlowTraining = true;
    private bool enablePauseAfterNormTraining = true;
    private bool enablePauseAfterVisualDis = true;
    private bool enablePauseAfterAudioVisualDis = true;
    private bool savefile = true; 

    // Start is called before the first frame update
    void Start()
    {
        StimuliController.SetActive(false);
        audioStimuliController.SetActive(false);
        visualaudioStimuliController.SetActive(false); 
        slowTrainingSession.SetActive(false); ;
        normalTrainingSession.SetActive(false); 
        vejledningstext.SetActive(false);
        subjectIdTextField.SetActive(true);
        InsertSubIdText.SetActive(true);
        introtext.SetActive(false);
        pause.SetActive(false); 
        p_target.SetActive(false);
        b_target.SetActive(false);
        p_distractor.SetActive(false);
        b_distractor.SetActive(false);
        g_distractor.SetActive(false);
        h_filler.SetActive(false);
        l_filler.SetActive(false);
        y_filler.SetActive(false);
        x_fixation.SetActive(false);   
        faster.SetActive(false);
        happyFace.SetActive(false);
        sadFace.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && enableIntroText)
        {
            var textField = subjectIdTextField.GetComponent<TMPro.TMP_InputField>();
            subjectId = textField.text;

            subjectIdTextField.SetActive(false);
            InsertSubIdText.SetActive(false);
            introtext.SetActive(true);
            enableIntroText = false; 
        }
        
        if (slowTrainingSession.GetComponent<SlowTrainingController>().AllReactionTimesFound() && enablePauseAfterSlowTraining)
        {
            pause.SetActive(true);
            enablePauseAfterSlowTraining = false;
            slowTrainingSession.SetActive(false);
        }
       
        if (normalTrainingSession.GetComponent<StimuliController>().AllReactionTimesFound() && enablePauseAfterNormTraining)
        {
            pause.SetActive(true);
            enablePauseAfterNormTraining = false;
            normalTrainingSession.SetActive(false);
        }
        
        if (StimuliController.GetComponent<StimuliController>().AllReactionTimesFound() && enablePauseAfterVisualDis)
        {
           pause.SetActive(true);
            enablePauseAfterVisualDis = false;
            StimuliController.SetActive(false);  
        }

        
        if (visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().AllReactionTimesFound() && enablePauseAfterAudioVisualDis)
        {
            pause.SetActive(true);
            enablePauseAfterAudioVisualDis = false;
            visualaudioStimuliController.SetActive(false);
        }

        if (StimuliController.GetComponent<StimuliController>().AllReactionTimesFound() && visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().AllReactionTimesFound() && audioStimuliController.GetComponent<AudioStimuliController>().AllReactionTimesFound())
        {
            pause.SetActive(true);  

            if (savefile == true)
            {
            var visRTs = StimuliController.GetComponent<StimuliController>().GetRTs();
            var visOnsetTimes = StimuliController.GetComponent<StimuliController>().GetOnSetTimes();
            var visOffsetTimes = StimuliController.GetComponent<StimuliController>().GetOffSetTimes();
            var visFixOnsetTimes = StimuliController.GetComponent<StimuliController>().GetFixationOnSetTimes();
            var visFixOffsetTimes = StimuliController.GetComponent<StimuliController>().GetFixationOffSetTimes();
            var visBlankOnsetTimes = StimuliController.GetComponent<StimuliController>().GetBlankOnSetTimes();
            var visBlankOffsetTimes = StimuliController.GetComponent<StimuliController>().GetBlankOffSetTimes();
            var visFeedbackOnsetTimes = StimuliController.GetComponent<StimuliController>().GetFeedbackOnSetTimes();
            var visFeedbackOffsetTimes = StimuliController.GetComponent<StimuliController>().GetFeedbackOffSetTimes();
            var visStimuliOnScreenTimes = StimuliController.GetComponent<StimuliController>().GetStimuliScreenTimes();
            var visPresentedConditions = StimuliController.GetComponent<StimuliController>().GetPresentedConditions();
            var visAnswers = StimuliController.GetComponent<StimuliController>().GetAnswers();
            var visAnswerCodes = StimuliController.GetComponent<StimuliController>().GetAnswerCodes();

            var audVisRTs = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetRTs();
            var audVisOnsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetOnSetTimes();
            var audVisOffsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetOffSetTimes();
            var audVisFixOnsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetFixationOnSetTimes();
            var audVisFixOffsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetFixationOffSetTimes();
            var audVisBlankOnsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetBlankOnSetTimes();
            var audVisBlankOffsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetBlankOffSetTimes();
            var audVisFeedbackOnsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetFeedbackOnSetTimes();
            var audVisFeedbackOffsetTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetFeedbackOffSetTimes();
            var audVisStimuliOnScreenTimes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetStimuliScreenTimes();
            var audVisPresentedConditions = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetPresentedConditions();
            var audVisAnswers = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetAnswers();
            var audVisAnswerCodes = visualaudioStimuliController.GetComponent<AudioVisualStimuliController>().GetAnswerCodes();

            var audRTs = audioStimuliController.GetComponent<AudioStimuliController>().GetRTs();
            var audOnsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetOnSetTimes();
            var audOffsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetOffSetTimes();
            var audFixOnsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetFixationOnSetTimes();
            var audFixOffsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetFixationOffSetTimes();
            var audBlankOnsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetBlankOnSetTimes();
            var audBlankOffsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetBlankOffSetTimes();
            var audFeedbackOnsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetFeedbackOnSetTimes();
            var audFeedbackOffsetTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetFeedbackOffSetTimes();
            var audStimuliOnScreenTimes = audioStimuliController.GetComponent<AudioStimuliController>().GetStimuliScreenTimes();
            var audPresentedConditions = audioStimuliController.GetComponent<AudioStimuliController>().GetPresentedConditions();
            var audAnswers = audioStimuliController.GetComponent<AudioStimuliController>().GetAnswers();
            var audanswerCodes = audioStimuliController.GetComponent<AudioStimuliController>().GetAnswerCodes();

            
                GetComponent<FileSaver>().saveFile(subjectId, visRTs,
                    visOnsetTimes, visOffsetTimes, visFixOnsetTimes, visFixOffsetTimes, visBlankOnsetTimes, visBlankOffsetTimes, visFeedbackOnsetTimes, visFeedbackOffsetTimes,
                    visStimuliOnScreenTimes, visPresentedConditions, visAnswers, visAnswerCodes,
                    audVisRTs, audVisOnsetTimes, audVisOffsetTimes, audVisFixOnsetTimes, audVisFixOffsetTimes, audVisBlankOnsetTimes, audVisBlankOffsetTimes, audVisFeedbackOnsetTimes, audVisFeedbackOffsetTimes,
                    audVisStimuliOnScreenTimes, audVisPresentedConditions, audVisAnswers, audVisAnswerCodes,
                    audRTs, audOnsetTimes, audOffsetTimes, audFixOnsetTimes, audFixOffsetTimes, audBlankOnsetTimes, audBlankOffsetTimes, audFeedbackOnsetTimes, audFeedbackOffsetTimes,
                    audStimuliOnScreenTimes, audPresentedConditions, audAnswers, audanswerCodes);

                savefile = false; 
            }
        }


    }
}
