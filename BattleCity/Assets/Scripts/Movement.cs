using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected bool isMoving = false;

    protected IEnumerator MoveHorizontal(float movementHorizontal, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(transform.position.x, transform.position.y);

        Quaternion rotation = Quaternion.Euler(0, 0, -movementHorizontal * 90f);
        transform.rotation = rotation;

        float movementProgress = 0f;
        Vector2 movement, endPos;

        while (movementProgress < Mathf.Abs(movementHorizontal))
        {
            movementProgress += MasterTracker.speed * Time.deltaTime;
            movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);
            movement = new Vector2(MasterTracker.speed * Time.deltaTime * movementHorizontal, 0f);
            endPos = rb2d.position + movement;

            rb2d.MovePosition(endPos);

            yield return new WaitForFixedUpdate();
        }

        isMoving = false;
    }

    protected IEnumerator MoveVertical(float movementVertical, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(transform.position.x, transform.position.y);

        Quaternion rotation;

        if (movementVertical < 0)
        {
            rotation = Quaternion.Euler(0, 0, movementVertical * 180f);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.rotation = rotation;

        float movementProgress = 0f;
        Vector2 endPos, movement;

        while (movementProgress < Mathf.Abs(movementVertical))
        {
            movementProgress += MasterTracker.speed * Time.deltaTime;
            movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);

            movement = new Vector2(0f, MasterTracker.speed * Time.deltaTime * movementVertical);
            endPos = rb2d.position + movement;

            rb2d.MovePosition(endPos);

            yield return new WaitForFixedUpdate();
        }

        isMoving = false;
    }
}
