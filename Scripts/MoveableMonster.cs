using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


  public class MoveableMonster :  MonoBehaviour
{
    private SpriteRenderer sprite;

    private Vector3 direction;

    private float speed = 2.0F;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void Update(){
      Move();
    }
    private void Start(){
      direction = transform.right;
    }



    private void Move()
       {
         Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.7f, 0.1F);
           if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F;

           transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

       }
  }
