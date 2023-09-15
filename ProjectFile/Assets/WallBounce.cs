using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public float bounceForce = 3f;
    public float bounceHeight = 2f; // Adjust this value to control the bounce height.

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the bounce direction perpendicular to the collision normal.
            Vector3 collisionNormal = collision.contacts[0].normal;
            Vector3 bounceDirection = Vector3.Reflect(collision.relativeVelocity.normalized, collisionNormal);

            // Apply the force to the player.
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Adjust the bounce direction to include a Y-axis component for height.
                bounceDirection += Vector3.up * bounceHeight;

                // Normalize the direction and apply the force.
                bounceDirection.Normalize();
                playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            }
        }
    }
}