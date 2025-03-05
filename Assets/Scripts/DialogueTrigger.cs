
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
/*public TextAsset inkJSON;
    private Story story;*/
    public Message[] messages;
    public Actor[] actors;
    

    public void StartDialogue(){
        FindObjectOfType<DialogueManager>().OpenDialogue(messages,actors);
    }
 
    /*void Start(){
        //story = new Story(inkJSON.text);
        Debug.Log(inkJSON);
    }*/
   
    
    /*[Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(inkJSON);
        DialogueManager.instance.EnterDialogueMode(inkJSON); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(inkJSON);
        DialogueManager.instance.EnterDialogueMode(inkJSON); 
        }
    }*/
}
[System.Serializable]
 public class Message{
        public int actorId;
        public string message;
    }
[System.Serializable]
    public class Actor{
        public string name;
        public Sprite sprite;
    }
    
