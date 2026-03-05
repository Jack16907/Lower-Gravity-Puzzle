using UnityEngine;

public class GravityPressurePlate : MonoBehaviour
{
    public PuzzleManager manager;
    public int plateID; // Set one to 1, the other to 2 in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.PlatePressed(plateID);
        }
    }
}