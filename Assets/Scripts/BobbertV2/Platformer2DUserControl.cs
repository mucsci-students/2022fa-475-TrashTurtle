using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump_down;
        private bool m_Jump_button;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump_down)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump_down = Input.GetButtonDown("Jump");
                m_Jump_button = Input.GetButton("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump_down, m_Jump_button);
            m_Jump_down = false;
            m_Jump_button = false;
        }
    }
}
