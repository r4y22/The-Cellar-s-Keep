using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMulti : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;

    private int currentIndex = 0;
    private int direction = 1;

    void Update()
    {
        if (points.Length == 0) return;

        Transform target = points[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Vector3 dir = target.position - transform.position;
        if (dir != Vector3.zero)
            transform.forward = dir.normalized;

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentIndex += direction;

            if (currentIndex >= points.Length)
            {
                currentIndex = points.Length - 2;
                direction = -1;
            }
            else if (currentIndex < 0)
            {
                currentIndex = 1;
                direction = 1;
            }
        }
    }
}
