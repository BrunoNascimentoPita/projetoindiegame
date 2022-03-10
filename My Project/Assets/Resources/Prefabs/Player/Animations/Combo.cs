using UnityEngine;

namespace WindRose.Combo
{

    public class Combo : StateMachineBehaviour
    {
        public bool ComboTime;
        public bool ComboReady;
        public float ComboWindowTime;
        public float ComboCount;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Combo");
            ComboTime = false;
            ComboReady = false;
            ComboCount = 0;
        }
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.F) && ComboReady)
            {
                ComboTime = true;
            }
            if (ComboCount > ComboWindowTime)
            {
                ComboReady = true;
            }
            else
            {
                ComboReady = false;
            }

            ComboCount += Time.deltaTime;
        }


        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (ComboTime)
            {
                animator.Play("2°Ataque");
            }
        }


        override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Implement code that processes and affects root motion
        }


        override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Implement code that sets up animation IK (inverse kinematics)
        }
    }
}
