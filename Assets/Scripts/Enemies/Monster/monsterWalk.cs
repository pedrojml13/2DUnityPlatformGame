using UnityEngine;

public class monsterWalk : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public float speed = 0.5f;
    public float detectionRange = 2f;
    public float followRange = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (player != null){
            Vector2 direction = new Vector2(player.position.x - animator.transform.position.x, 0);
            Vector2 moveVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

            rb.linearVelocity = moveVelocity;

            if (direction.x > 0)
                animator.transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                animator.transform.localScale = new Vector3(1f, 1f, 1f);

            float distance = Vector2.Distance(player.position, animator.transform.position);
            if (distance < detectionRange)
            {
                animator.SetBool("isAttacking", true);
            }

            if(distance > followRange){
                animator.SetBool("isChasing", false);
            }
        }
    }




}
