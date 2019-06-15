using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character :  MonoBehaviour
{
  [SerializeField]
  public int coins = 0;
    public bool key = false;
    private float speed = 5.0f;
    private float jumpForce = 15.0f;
    private bool isGrounded = false;
    public bool isDead = false;

  private CharState State{
      get {return (CharState)animator.GetInteger("State");}
      set {animator.SetInteger("State", (int)value);}
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;


    private void Awake(){

      rigidbody = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate(){
      CheckGround();

    }

    private void Update(){
      if (isDead) State = CharState.Die;

      if (isGrounded) State = CharState.Idle;
      if (Input.GetButton("Horizontal")) Run();
      if (isGrounded && Input.GetButtonDown("Jump")) Jump();

    }

    private void Run(){
      Vector3 direction = transform.right * Input.GetAxis("Horizontal");

      transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

      sprite.flipX = direction.x < 0.0f;

      if (isGrounded) State = CharState.Run;
    }

    private void Jump(){
      rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
}

    private void CheckGround(){
      Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

      isGrounded = colliders.Length > 1;

      if(!isGrounded) State = CharState.Jump;

    }


    void OnCollisionEnter2D(Collision2D col){
              if (col.gameObject.tag == "enemy")
              Die();
      }

    private void Die(){
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 15.0f + transform.right * 15.0f - transform.right * 15.0f, ForceMode2D.Impulse);
        isDead = true;
        Debug.Log(isDead);
        Invoke("Restart", 1.2f);
        //Destroy(gameObject, 1.0f);
      }
      private void Restart(){
         SceneManager.LoadScene("main", LoadSceneMode.Single);
      }




      void OnGUI(){
	GUI.Box (new Rect (0, 0, 100, 20), "COINS: " + coins + "/3");
}
}

public enum CharState
{
  Idle,
  Run,
  Jump,
  Die
}
