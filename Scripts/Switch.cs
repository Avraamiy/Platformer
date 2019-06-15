using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
  private Character character;
  private Animator animator;

  private void Awake(){
           character = FindObjectOfType<Character>();
      }
void Update(){
  if(character.key){
    animator.SetBool("open", true);
    }
  }
}
