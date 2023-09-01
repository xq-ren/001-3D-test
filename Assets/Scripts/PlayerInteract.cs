using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
  public GameObject dialoguePanel;
  public Text dialogueText;

    private void Update(){
      if (Input.GetKeyDown(KeyCode.E)) {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray){
          if (collider.TryGetComponent(out NPCInteractable npcInteractable)) {
            npcInteractable.Interact();
            if (dialoguePanel.activeInHierarchy) {
              zeroText();
            } else {
              dialoguePanel.SetActive(true);
              NPCDialogue npcDialogue;
              StartCoroutine(npcDialogue.Typing());
            }
          }
        }
      }
    }

    public void zeroText(){
      dialogueText.text = "";
      index = 0;
      dialoguePanel.SetActive(false);
    }
}
