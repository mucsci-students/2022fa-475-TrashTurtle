using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump_down;
        private bool m_Jump_button;
        public AudioSource source;
        public AudioClip heal;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            source = GetComponent<AudioSource>();
            heal = GetComponent<AudioClip>();
        }


        private void Update()
        {
            if (!m_Jump_down)
            {
                // m_Jump_down when jump is pressed
                m_Jump_down = Input.GetButtonDown("Jump");
                // m_Jump_button DURATION jump is pressed
                m_Jump_button = Input.GetButton("Jump");
            }
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool shield = Input.GetKey(KeyCode.S);
            float h = Input.GetAxis("Horizontal");
                          
            // Pass all parameters to the character control script.
            m_Character.Move(h, shield, m_Jump_down, m_Jump_button);
            m_Jump_down = false;
            m_Jump_button = false;
            shield = false;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Kill me");
            if (collision.gameObject.tag == "Powerup")
            {
                heal = source.clip;
                source.PlayOneShot(heal);
            }
        }
    }
}
