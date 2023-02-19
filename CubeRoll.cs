using System.Collections;
using UnityEngine;

public class CubeRoll : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 5; // How fast the cube will rotate
    private bool isMoving; // Flag to check if the cube is already rotating

    private void Update()
    {
        if (isMoving) return; // Don't allow movement if the cube is already rotating

        // Check for input to move the cube
        if (Input.GetKey(KeyCode.W))
        {
            Assemble(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Assemble(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Assemble(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Assemble(Vector3.right);
        }
    }

    private void Assemble(Vector3 dir)
    {
        // Calculate the anchor point for the rotation
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;

        // Calculate the axis of rotation
        var axis = Vector3.Cross(Vector3.up, dir);

        // Start the rotation coroutine
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true; // Set the flag to indicate that the cube is rotating

        // Rotate the cube 90 degrees over a number of frames
        for (var i = 0; i < 90 / rollSpeed; i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false; // Clear the flag to indicate that the rotation is complete
    }
}
