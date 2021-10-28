using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Menu_World
{
    public class LightScript : MonoBehaviour
    {
        private Light2D m_FailLight;
        public float speed= 0.01f;

        private void Start()
        {
            m_FailLight = GetComponent<Light2D>();
        }

        private void Update()
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                FadeLights();
            }
        }

        public void FadeLights()
        {
            StartCoroutine(nameof(Timer));
        }
        

        private IEnumerator Timer()
        {
            for (int i = 0; i <= 10; i++)
            {
                m_FailLight.intensity = i / 10f;
                yield return new WaitForSeconds(speed);
            }
            yield return new WaitForSeconds(speed);
            for (int i = 10; i >= 0; i--)
            {
                m_FailLight.intensity = i / 10f;
                yield return new WaitForSeconds(speed);
            }
        }
    }
}