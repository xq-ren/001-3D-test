using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
  NPCDialogue npcDialogue;
    public void Interact(){
      Debug.Log("Interact!");
      npcDialogue.Start();

    }
}
