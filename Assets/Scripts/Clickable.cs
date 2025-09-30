using UnityEngine;

[RequireComponent(typeof(Collider2D))]           // ensure it’s clickable in 2D
[DisallowMultipleComponent]
public class Clickable : MonoBehaviour
{
    public enum Kind { Node, Path }

    [SerializeField] private Kind kind = Kind.Node;   

    private void OnMouseDown()
    {
        var sel = FindAnyObjectByType<SelectionController>();
        if (sel == null) { Debug.LogWarning("SelectionController not found in scene."); return; }

        switch (kind)
        {
            case Kind.Node:
                if (TryGetComponent<NodeChecker>(out var node))
                    sel.OnNodeClicked(node);
                else
                    Debug.LogWarning($"{name}: Clickable set to Node but NodeChecker missing.");
                break;

            case Kind.Path:
                if (TryGetComponent<PathSegments>(out var path))
                    sel.OnPathClicked(path);
                else
                    Debug.LogWarning($"{name}: Clickable set to Path but PathSegments missing.");
                break;
        }
    }

#if UNITY_EDITOR
    // Auto-set Kind when you add the component or click "Reset"
    private void Reset()
    {
        if (GetComponent<NodeChecker>() != null) kind = Kind.Node;
        else if (GetComponent<PathSegments>() != null) kind = Kind.Path;
    }
#endif
}
