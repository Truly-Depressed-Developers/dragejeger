using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smaug : MonoBehaviour
{
   [SerializeField] private float maxHealth = 100f;
   public float health = 100f;


   public static Smaug instance;


   // Start is called before the first frame update
   void Start()
   {
      instance = this;
      HealthBar.instance.SetMaxHealth(100f);
   }

   // Update is called once per frame
   void Update()
   {
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.transform.CompareTag("Spear")) return;

      health = Mathf.Clamp(health - 10, 0, maxHealth);

      HealthBar.instance.SetHealth(health);

      Destroy(other.gameObject);

      if (health == 0)
      {
         Destroy(gameObject);
      }
   }
}
