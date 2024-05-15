using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int Jump1 = Animator.StringToHash("Jump");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        
        

        public void ProcessJumpAnimationGroup()
        {
            animator.SetBool(IsGrounded, false);
            animator.SetTrigger(Jump1);
        }

        public void ProcessLandAnimationGroup()
        {
            animator.SetBool(IsGrounded, true);
        }

        public void ProcessDeathAnimationGroup()
        {
            animator.Play("Death");
        }
    }
}
