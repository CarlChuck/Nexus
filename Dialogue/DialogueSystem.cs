using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }

    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    public Button continueButton;
    public Text dialogueText, nameText;
    int dialogueIndex;

	void Awake ()
    {
        continueButton.onClick.AddListener(delegate { continueDialogue(); });
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}


    public void addNewDialogue(string[] lines, string nName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        foreach(string line in lines)
        {
            dialogueLines.Add(line);
        }
        npcName = nName;
        createDialogue();
    }

    public void createDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void continueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
