using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Runemark.DialogueSystem;

public class PlayerController : MonoBehaviour
{

    public LayerMask movementMask;

    public Interactable focus;

    public float stoppingDistance = 1f;

    public Text countText;

    Camera cam;
    NavMeshAgent agent;

    Transform target;

    public GameObject player;

    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, movementMask))
            {
                agent.SetDestination(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }

            focus = newFocus;
            FollowTarget(newFocus);
        }

        focus = newFocus;
        newFocus.OnFocused(transform);
        FollowTarget(newFocus);
    }

    void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.OnDeFocused();
        }

        focus = null;
        StopFollowTarget();
    }

    void FollowTarget (Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * stoppingDistance;

        target = newTarget.transform;
    }

    void StopFollowTarget ()
    {
        agent.stoppingDistance = 0f;

        target = null;
    }
}
