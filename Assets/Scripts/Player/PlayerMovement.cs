namespace BlueGravityTest
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        PlayerInputs mInputs;
        Rigidbody2D mRigidBody;
        [SerializeField] float mWalkSpeed;
        [SerializeField] float mSprintSpeed;
        [SerializeField] Animator mAnimator;
        // Start is called before the first frame update
        void Start()
        {
            mInputs = GetComponent<PlayerInputs>();
            mRigidBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Move();
        }
        void Move()
        {
            Vector2 inputMovement = mInputs.GetInputMovement();
            Vector3 movement = new Vector3(inputMovement.x , inputMovement.y , 0);
            if (movement.magnitude < 0.1)
            {
                mAnimator.SetFloat("MovementSpeed", 0);
                mAnimator.SetBool("Sprint", false);
                mRigidBody.velocity = Vector3.zero;
                return;
            }
            bool isSprinting = mInputs.GetInputSprint();
            movement = isSprinting ?   movement.normalized * mSprintSpeed * Time.deltaTime :
                                       movement.normalized * mWalkSpeed * Time.deltaTime;
            mRigidBody.velocity = movement;

            Vector3 OrientationScale = mAnimator.transform.localScale;
            OrientationScale.x = Mathf.Sign(movement.x) * Mathf.Abs(OrientationScale.x);
            mAnimator.transform.localScale = OrientationScale;
            mAnimator.SetBool("Sprint", isSprinting);
            mAnimator.SetFloat("MovementSpeed", movement.magnitude);
        }
    }
}
