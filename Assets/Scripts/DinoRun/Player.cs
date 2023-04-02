using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private SpriteRenderer _playerSpriteRenderer;
   [SerializeField] private Rigidbody2D rigidbody_;
   [SerializeField] private Camera camera_;

   [SerializeField] private float jump_speed_ = 20f;

   private float _playerWidth;
   private bool sneaking => Input.GetKey("s");
   private float _playerHeight;

   bool isJumping_ = false;

   // Start is called before the first frame update
   void Start()
   {
      _playerWidth = _playerSpriteRenderer.bounds.size.x;
      _playerHeight = _playerSpriteRenderer.bounds.size.y;
   }

   // Update is called once per frame
   void Update()
   {
      transform.position = new Vector2(MainCamera1.instance.xPosition - MainCamera1.instance.cameraWidth * 0.8f, transform.position.y);

      PlayerJump();

      CheckIfHitsWall();
   }

   void PlayerJump()
   {
      if (Input.GetKey("w") && !isJumping_)
      {
         rigidbody_.velocity = new Vector2(0, jump_speed_);

         // rigidbody_.AddForce(new Vector2(0, force_));

         isJumping_ = true;
      }
    //   faster fall down when jump key released
      if (!Input.GetKey("w") && isJumping_ && rigidbody_.velocity.y > 0) {
        rigidbody_.velocity = new Vector3(rigidbody_.velocity.x, rigidbody_.velocity.y / 2, 0);
      }
      if (sneaking)
      {
         transform.localScale = new Vector3(1, 1 , 1);
      } else {
         transform.localScale = new Vector3(1, 2, 1);
      }

      if (rigidbody_.velocity.y == 0)
      {
         isJumping_ = false;
      }
   }

   // private void OnCollisionEnter2D(Collision2D collision)
   // {
   //    Vector2 hitVector2 = new Vector2(transform.position.x, transform.position.y - _playerHeight / 2);
   //    RaycastHit2D hit = Physics2D.Raycast(hitVector2, Vector2.down);


   //    if (hit)
   //    {
   //       if (collision.transform.tag == "Wall" && hit.transform.name != collision.transform.name)
   //       {
   //          Debug.Log("When hit");
   //          SetIsAliveToNot();
   //       }
   //    }
   //    else
   //    {
   //       if (collision.transform.tag == "Wall")
   //       {
   //          Debug.Log("Not Hit");
   //          SetIsAliveToNot();
   //       }
   //    }
   // }

   private void OnTriggerEnter2D(Collider2D other) {
        SetIsAliveToNot();
   }

   void CheckIfHitsWall()
   {
    //   float heightRange = (_playerHeight / 2) * 0.6f;

    //   Vector2 hitVector2_1 = new Vector2(transform.position.x + _playerWidth / 2, transform.position.y - heightRange);
    //   Vector2 hitVector2_2 = new Vector2(transform.position.x + _playerWidth / 2, transform.position.y + heightRange);
    //   RaycastHit2D hit1 = Physics2D.Raycast(hitVector2_1, Vector2.right, 0.1f);
    //   RaycastHit2D hit2 = Physics2D.Raycast(hitVector2_2, Vector2.right, 0.1f);

    //   if (hit1)
    //   {
    //      Debug.Log(hit1.transform.name);
    //   }

    //   if (hit2)
    //   {
    //      Debug.Log(hit2.transform.name);
    //   }
    //   if (hit1 || hit2)
    //   {
    //      SetIsAliveToNot();
    //   }
   }

   void SetIsAliveToNot()
   {
      DinoRunManager.instance.PlayerIsAlive_ = false;
      Debug.Log("AAAAAAAAAAA");
      Destroy(gameObject);
   }

   // OnCo
}
