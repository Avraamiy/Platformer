using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

  private float distance = 2.0f;
  Color _color;
  public bool start = false;
  public Transform player;
  private Character character;

  private void Awake()
      {
           player = FindObjectOfType<Character>().transform;
           character = FindObjectOfType<Character>();
      }

void Update(){
  if (Vector3.Distance(gameObject.transform.position, player.position) < distance)
  {
    if(character.key){
      start = true;
    }
    if(start){
      _color = gameObject.GetComponent<Renderer>().material.color;
      if(_color.a > 0){
        _color.a -= 0.01f;
        gameObject.GetComponent<Renderer>().material.color = _color;
      }
      if(_color.a < 0.5f){
        Destroy (gameObject, 0.5f);
      }
      }
    }
  }
}
