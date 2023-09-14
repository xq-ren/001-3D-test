using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialoguePanel;
    public string[] lines;
    public float textSpeed;
    private int index;
    public bool playerIsClose;

    public void Start(){
      textComponent.text = "";
    }

    void Update(){
      if (Input.GetKeyDown(KeyCode.E) && playerIsClose) {
        if (!dialoguePanel.activeInHierarchy){
        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());
        }
        else if (Input.GetMouseButtonDown(0)) {
          if (textComponent.text == lines[index]) {
            NextLine();
          } else {
            StopAllCoroutines();
            textComponent.text = lines[index];
          }
        }
      }
      if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy){
        RemoveText();
      }
    }

    public void RemoveText()
    {
        textComponent.text = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    /*void StartDialogue(){
      index = 0;
      StartCoroutine(TypeLine());
    }*/

    IEnumerator TypeLine(){
      foreach(char c in lines[index].ToCharArray()){
        textComponent.text += c;
        yield return new WaitForSeconds(textSpeed);
      }
    }

    void NextLine(){
      if (index < lines.Length - 1){
        index ++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
      } else {
        RemoveText();
      }
    }

    private void OnTriggerEnter2D(Collider2D other){
      if (other.CompareTag("Player")){
        playerIsClose = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other){
      if (other.CompareTag("Player")){
        playerIsClose = false;
        RemoveText();
      }
    }
}
