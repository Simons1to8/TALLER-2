using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float directionMov;
    Vector2 movement;
    public float enemySpeed;
    public Rigidbody2D enemyRb;
    public float detectionRadius = 0.5f;

    public Transform actualObjective;

    public Transform[] enemyMovementPoints;
    public Animator enemyAnimator;

    public bool isFacingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        actualObjective = enemyMovementPoints[0];
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToObjective = Vector2.Distance(transform.position, actualObjective.position);

        if (distanceToObjective < detectionRadius)
        {
            if (actualObjective == enemyMovementPoints[0])
            {
                actualObjective = enemyMovementPoints[1];

            }
            else if (actualObjective == enemyMovementPoints[1])
            {
                actualObjective = enemyMovementPoints[0];
            }
        }

        Vector2 direction = (actualObjective.position - transform.position).normalized;

        int roundDirection = Mathf.RoundToInt(direction.x);




        movement = new Vector2(roundDirection, 0);


        if (!isFacingRight && directionMov > 0f)
        {
            Flip();
        }
        else if (isFacingRight && directionMov < 0f)

        {
            Flip();
        }


        enemyAnimator.SetFloat("Direction", roundDirection);


        enemyRb.MovePosition(enemyRb.position + movement * enemySpeed * Time.deltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }

}
