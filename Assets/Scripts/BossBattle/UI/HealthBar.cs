using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private Slider slider;

   public static HealthBar instance;

   private void Awake()
   {
      instance = this;
   }

   public void SetHealth(float health)
   {
      slider.value = health;
   }

   public void SetMaxHealth(float health)
   {
    //   Debug.Log("sfdrfgyujiok");
      slider.maxValue = health;
      slider.value = health;
   }
}