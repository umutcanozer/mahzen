using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BGCore
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Slider slider;
        Health health;

        private void Start()
        {
            health = GetComponent<Health>();
            SetMaxHealth(health.MaxHealth);
        }

        private void Update()
        {
            SetHealth(health.CurrentHealth);
        }
        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        public void SetHealth(float health)
        {
            slider.value = health;
        }
    }
}
