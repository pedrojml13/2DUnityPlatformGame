using UnityEngine;

public class monsterAttack : StateMachineBehaviour
{
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(player != null){
            float distance = Vector2.Distance(player.position, animator.transform.position);

            
            if(distance > 2){
                animator.SetBool("isAttacking", false);
            }
        }

    }


}
