using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float turnSpeed = 20f;

        private Vector3 movement;
        private Quaternion rotation;
        
        private Animator animator;
        private Rigidbody rigidBody;
        private AudioSource audioSource;
        
        private void Awake()
        {
            movement = new Vector3();
            rotation = Quaternion.identity;

            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
        }
        
        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            movement.Set(horizontal, 0f, vertical);
            movement.Normalize();

            var hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            var hasVerticalInput = !Mathf.Approximately(vertical, 0f);

            var isWalking = hasHorizontalInput || hasVerticalInput;
            
            animator.SetBool(JohnLemonAnimatorParameters.IsWalking, isWalking);

            if (isWalking)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }

            var desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
            rotation = Quaternion.LookRotation(desiredForward);
        }

        private void OnAnimatorMove()
        {
            rigidBody.MovePosition(rigidBody.position + movement * animator.deltaPosition.magnitude);
            rigidBody.MoveRotation(rotation);
        }
    }
}
