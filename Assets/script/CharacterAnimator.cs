using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAnimator : MonoBehaviour
{
    public Transform visual;
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;

    public float swingSpeed = 6f;
    public float swingAmount = 30f;

    void Update()
    {
        float moveInput = 0f;

        if (Keyboard.current.aKey.isPressed)
            moveInput = -1f;

        if (Keyboard.current.dKey.isPressed)
            moveInput = 1f;

        if (moveInput != 0f)
        {
            float swing = Mathf.Sin(Time.time * swingSpeed) * swingAmount;

            if (leftArm != null)
                leftArm.localRotation = Quaternion.Euler(swing, 0f, 0f);

            if (rightArm != null)
                rightArm.localRotation = Quaternion.Euler(-swing, 0f, 0f);

            if (leftLeg != null)
                leftLeg.localRotation = Quaternion.Euler(-swing, 0f, 0f);

            if (rightLeg != null)
                rightLeg.localRotation = Quaternion.Euler(swing, 0f, 0f);

            if (visual != null)
            {
                if (moveInput > 0f)
                    visual.localRotation = Quaternion.Euler(0f, 0f, 0f);
                else
                    visual.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        else
        {
            if (leftArm != null)
                leftArm.localRotation = Quaternion.identity;

            if (rightArm != null)
                rightArm.localRotation = Quaternion.identity;

            if (leftLeg != null)
                leftLeg.localRotation = Quaternion.identity;

            if (rightLeg != null)
                rightLeg.localRotation = Quaternion.identity;
        }
    }
}