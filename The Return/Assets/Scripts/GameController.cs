using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayLocation(bool additive = false)
    {
        string desc = player.currentLocation.description + "\n";
        desc += player.currentLocation.GetConnectionsText();
        desc += player.currentLocation.getItemsText();
        if (additive) {
            currentText.text = currentText.text + "\n" + desc;
        }
        else
        {
            currentText.text = desc;
        }
        

    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    public void LogCurrentText() {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] seperatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if(action.keyword.Equals(seperatedWords[0], System.StringComparison.OrdinalIgnoreCase))
            {
                /*if(seperatedWords.Length > 1 && action.keyword.ToLower() == "get") { 
                    action.RespondToInput(this, seperatedWords[1] + " " + seperatedWords[2]);
                }*/
                if(seperatedWords.Length > 1)
                {
                    action.RespondToInput(this, seperatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! (having trouble? type Help)";
    }
}
