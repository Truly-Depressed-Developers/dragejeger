using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spear : MonoBehaviour
{
   [SerializeField] SpriteRenderer spriteRenderer_;
   private float speed_ = 5f;
   float height;

   // Start is called before the first frame update
   void Start()
   {
      height = spriteRenderer_.bounds.size.y;
   }

   // Update is called once per frame
   void Update()
   {

      moveFireBall();

      if (transform.position.y > MainCamera.instance.yUpPosition + height / 2)
      {
         Destroy(gameObject);
      }
   }

   void moveFireBall()
   {
      transform.Translate(Vector2.up * Time.deltaTime * speed_);
   }
}
