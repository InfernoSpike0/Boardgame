using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public void OnNodeClicked(NodeChecker node)
    {
        Debug.Log("Node clicked: " + node.name);
    }

    public void OnPathClicked(PathSegments path)
    {
        Debug.Log("Path clicked: " + path.name);
    }
}