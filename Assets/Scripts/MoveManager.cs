using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public float moveSpeed = 3f; // Controls speed of Shark
    private Animator animator;
    private Vector3[] moveDirections = { Vector3.right, Vector3.down, Vector3.left, Vector3.up };
    private int[] blockCounts = { 5, 4, 5, 4 }; 
    private int currentDirectionIndex = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveInPattern());
    }

    private IEnumerator MoveInPattern()
    {
        while (true) 
        {
            SetAnimationState(moveDirections[currentDirectionIndex]);

            Vector3 targetPosition = transform.position + moveDirections[currentDirectionIndex] * blockCounts[currentDirectionIndex];

            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveDirections[currentDirectionIndex]);

            currentDirectionIndex = (currentDirectionIndex + 1) % moveDirections.Length;

        }
    }

    private void SetAnimationState(Vector3 direction)
    {
        animator.SetBool("Move", true);
    }
}
