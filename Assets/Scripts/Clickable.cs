using UnityEngine;

public class Clickable : MonoBehaviour
{
    public enum Kind { Node, Path }
    public Kind kind;

    private void OnMouseDown()
    {
        var sel = FindAnyObjectByType<SelectionController>();
        if (sel == null) { Debug.LogWarning("SelectionController not found in scene."); return; }

        switch (kind)
        {
            case Kind.Node:
                var node = GetComponent<NodeChecker>();
                if (node != null) sel.OnNodeClicked(node);
                break;

            case Kind.Path:
                var path = GetComponent<PathSegments>();
                if (path != null) sel.OnPathClicked(path);
                break;
        }
    }
}