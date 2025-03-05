using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage =0;
    public static bool isActive = false;
    private Button yesBtn;
    private Button NoBtn;
    private void Awake()
    {
        
        yesBtn = transform.Find("YesBtn").GetComponent<Button>();
        NoBtn = transform.Find("NoBtn").GetComponent<Button>();
        

    }

    public void OpenDialogue(Message[] messages,Actor[]actors){
        
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive=true;
        Debug.Log("Started Conversation! Loaded messages:"+ messages.Length);
        DisplayMessage();
    }


    void DisplayMessage(){
        Message messageToDisplay =currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
         

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
    }

    public void NextMessage(){
        activeMessage++;
        if(activeMessage< currentMessages.Length){
            DisplayMessage();
        }else{
            ShowQuestion(messageText.text,()=>{},()=>{});
            Debug.Log("Conversation Ended!");
            isActive=false;
         
        }
    }
    public void ShowQuestion(string questionText,Action yesAction , Action noAction)
    {
           messageText.text = questionText;
        yesBtn.onClick.AddListener(() =>
        {
            
            yesAction();
            Debug.Log("Yes");
            SceneManager.LoadScene(0);
        });
        NoBtn.onClick.AddListener(() =>
        {
            noAction();
            Debug.Log("No");
            SceneManager.LoadScene(0);
        });
    } 

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)&& isActive == true){
            NextMessage();

        }
    }

    private void Hide(){

    }

    
    
    
   /* [Header("Dialogue UI")]

    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;

    private bool dialogueIsPlaying;
    public static DialogueManager instance{get; private set;}

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialouge Manager in the scene");
        }
        instance = this;
    }
    
    public static DialogueManager GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        DialoguePanel.SetActive(false);
    }
    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        DialoguePanel.SetActive(true);

        ContinueStory();
    }

        

private void ExitDialogueMode() {
            dialogueIsPlaying = false;
            DialoguePanel.SetActive(false);
            dialogueText.text = "";
        }

private void ContinueStory(){
if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
}*/

    /* private int count;

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             Dialogue.Instance.ShowQuestion("Apakah Benar 20 X 2 +10 = 30 ?", () => {
                 count++;
                 Debug.Log(count);
                 Dialogue.Instance.ShowQuestion("Apakah Benar 100 X 2 +10 = 200 ?", () =>
                 {
                     count--;
                     Debug.Log(count);
                 },() =>{
                 count++;
                 Debug.Log(count);});
             },

             () => {
                 count--;
                 Debug.Log(count);
                 Dialogue.Instance.ShowQuestion("Apakah Benar 100 X 2 +10 = 200 ?", () =>
                 {
                     count--;
                     Debug.Log(count);
                 },
             () =>
             {
                 count++;
                 Debug.Log(count);
             });
             });
         }
     }*/
}
