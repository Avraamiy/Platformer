using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent {set{ parent = value;}}

    public float speed = 10.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value;}}

    private SpriteRenderer sprite;

    private void Awake(){
      sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start(){
      Destroy(gameObject, 1.4f);
    }

    private void Update(){

      transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col){
              if (col.gameObject.tag == "enemy" || col.gameObject.tag == "hero" || col.gameObject.tag == "ground")
              Destroy(gameObject);
      }
}
