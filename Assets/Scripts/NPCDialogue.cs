using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;

    void Update()
    {
      if (dialoguePanel.activeInHierarchy) {
        zeroText();
      } else {
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
      }

    }

    public void zeroText(){
      dialogueText.text = "";
      index = 0;
      dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
      foreach(char letter in dialogue[index].ToCharArray()){
        dialogueText.text += letter;
        yield return new WaitForSeconds(wordSpeed);
      }
    }
}
