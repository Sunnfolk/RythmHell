using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

namespace Menu_World
{
    public class LightScript : MonoBehaviour
    {
        private Light2D m_FailLight;

        private void Start()
        {
            m_FailLight = GetComponent<Light2D>();
        }

        public void FadeLights()
        {
            StartCoroutine(nameof(Timer));
        }

        private void Update()
        {
            if (Keyboard.current.gKey.wasPressedThisFrame)
            {
                FadeLights();
            }
        }

        private IEnumerator Timer()
        {
            for (int i = 0; i <= 10; i++)
            {
                m_FailLight.intensity = i / 10f;
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(0.1f);
            for (int i = 10; i >= 0; i--)
            {
                m_FailLight.intensity = i / 10f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}