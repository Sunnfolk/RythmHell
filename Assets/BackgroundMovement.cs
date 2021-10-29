using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private bool m_GoingUp;

    private void Update()
    {
        if (transform.position.y >= -14.7f && !m_GoingUp)
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
        else
        {
            m_GoingUp = true;
        }

        if (transform.position.y <= 14.7f && m_GoingUp)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else
        {
            m_GoingUp = false;
        }

    }
}
