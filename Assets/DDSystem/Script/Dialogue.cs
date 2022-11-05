using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System.Linq;
//using UnityEditor.SceneManagement;

public class Dialogue : MonoBehaviour
{

    public DialogManager dialogManager;


    [TextArea]
    public string[] textEntry;
    public string charaEmote;

    [Header("onClick skipping")]
    public bool skippable;

    [Header("playAnim after")]
    public bool needAnim;

    [Header("disable obj after")]
    public bool needUnable;
    public List<GameObject>  TheUnabled;
    public bool needEnable;
    public List<GameObject> TheEnabled;

    [Header("switch scene after")]
    //public EditorSceneManager sceneManager;
    public bool switchScene;
    public string sceneName;

    [Header("need selection")]
    public bool selectionON;
    private DialogData dialogData;
    public string forCorrect;
    public string forWrong;
    public string respToCorrect;
    public string respToWrong;


    void OnEnable()
    {
      

        var dialogueTexts = new List<DialogData>();
       
        for (int i = 0; i < textEntry.Length; i++)
        {
           
         
            dialogData = new DialogData(textEntry[i], charaEmote);
            dialogData.isSkippable = skippable;
            dialogueTexts.Add(dialogData);
         
            

        }



//----------------------------BOOLS HERE--------------------------------------//
        //if need animation
        //if (needAnim) {
        //    dialogueTexts[dialogueTexts.Count - 1].Callback = () => sceneControl.playAnim(); 
        //}

        //if need something to be disabled after dialogue
        if (needUnable)
        {
            dialogueTexts[dialogueTexts.Count - 1].Callback = () =>disableObj();
        }
        if (needEnable)
        {
            dialogueTexts[dialogueTexts.Count - 1].Callback = () => EnableObj();
        }
        //if need switch scene, switch scene here
        if (switchScene)
        {
            dialogueTexts[dialogueTexts.Count - 1].Callback = () => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        if (selectionON)
        {
            goToSelection();
        }

        //----------------------------BOOLS END HERE--------------------------------------//

        dialogManager.Show(dialogueTexts);
       

    }

    void goToSelection()
    {
    
        var dialogueTexts = new List<DialogData>();
        dialogData.SelectList.Add("correct", forCorrect);
        dialogData.SelectList.Add("wrong", forWrong);
        dialogData.Callback = () => check_correct();
    }

    void check_correct()
    {
      
        if (dialogManager.Result == "correct")
        {
            var dialogueTexts = new List<DialogData>();
            dialogueTexts.Add(new DialogData(respToCorrect));
            dialogManager.Show(dialogueTexts);
        }
        else if (dialogManager.Result == "wrong")
        {
            var dialogueTexts = new List<DialogData>();
            dialogueTexts.Add(new DialogData(respToWrong));
            dialogManager.Show(dialogueTexts);
        }
    }

    void disableObj()
    {
        foreach (GameObject obj in TheUnabled) {
            obj.SetActive(false);
                };
    }

    void EnableObj()
    {
        foreach (GameObject obj in TheEnabled)
        {
            obj.SetActive(true);
        };
    }
}
