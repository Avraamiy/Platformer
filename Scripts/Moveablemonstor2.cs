using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveablemonstor2 : MonoBehaviour {
    private float Speed = 3.0f;
    public Transform[] Points = new Transform[2];
    Rigidbody2D EnemyRgb;
    SpriteRenderer SpREnemy;
    bool OnRight;



    void Awake () {
        SpREnemy = GetComponent<SpriteRenderer>();
        EnemyRgb = GetComponent<Rigidbody2D>();

 }

 void Update () {
        SpREnemy.flipX = OnRight;
        if (GetComponent<Transform>().position.x < Points[0].position.x)
        {
            OnRight = true;
        }
        else if (GetComponent<Transform>().position.x > Points[1].position.x)
        {
            OnRight = false;
        }
        if (OnRight)
        {
            EnemyRgb.velocity = new Vector2(Speed, EnemyRgb.velocity.y);
        }
        else
        {
            EnemyRgb.velocity = new Vector2(-Speed, EnemyRgb.velocity.y);
        }
}
}
