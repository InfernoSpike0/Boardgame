using UnityEngine;

public class PathSegments : MonoBehaviour
{
    public int id;                 // Unique ID for path
    public int ownerId = 0;        // 0 = unowned
    public NodeChecker nodeA;      // One end of the path
    public NodeChecker nodeB;      // Other end of the path

    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetOwner(Player player)
    {
        ownerId = player.id;
        rend.material.color = player.color; // visually show ownership
    }

    // Optional: reset path to neutral
    public void ResetOwnership(Color neutralColor)
    {
        ownerId = 0;
        rend.material.color = neutralColor;
    }
}