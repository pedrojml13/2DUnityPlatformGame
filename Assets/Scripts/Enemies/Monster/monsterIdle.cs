using UnityEngine;

public class monsterIdle : StateMachineBehaviour
{
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(!GameManager.isGameOver){
            float distance = Vector2.Distance(player.position, animator.transform.position);

            if(distance < 5){
                animator.SetBool("isChasing", true);
            }
        }

        
    
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioManager.instance.Play("monsterWalk");
    }

}
