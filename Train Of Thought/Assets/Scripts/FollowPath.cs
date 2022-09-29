using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowPath : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints, rail;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] float turnSpeed = 5f;
    GameManager gameManager;
    private int waypointIndex = 0;
    private void Start()
    {
        if (waypoints != null)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }

    private void Update()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                          waypoints[waypointIndex].gameObject.transform.position,
                          moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, waypoints[waypointIndex].gameObject.transform.localRotation, turnSpeed * Time.deltaTime);

            if (transform.position.x == waypoints[waypointIndex].transform.position.x)
            {
                waypointIndex += 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "House")
        {
            gameObject.SetActive(false);
        }
        if (other.tag == "Rail")
        {
            foreach (Transform wayPointObj in other.transform)
            {
                waypoints.Add(wayPointObj.gameObject.transform);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Rail")
        {
            foreach (Transform wayPointObj in other.transform)
            {
                waypoints.Remove(wayPointObj.gameObject.transform);
            }
        }
    }
}
