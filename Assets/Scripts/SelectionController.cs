using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [Header("Refs")]
    public GameBase game;                 // assign in Inspector

    [Header("Rules")]
    public bool allowNeutralOnRoutes = false;

    // temp selection: click first node = start, second node = destination
    private NodeChecker startNode;
    private NodeChecker destNode;

    public void OnNodeClicked(NodeChecker node)
    {
        if (node == null) return;
        if (game == null) { Debug.LogWarning("SelectionController: GameBase not assigned."); return; }

        if (startNode == null)
        {
            startNode = node;
            Debug.Log($"Start node: {node.name}");
            return;
        }

        if (destNode == null)
        {
            destNode = node;
            Debug.Log($"Destination node: {node.name}");

            var player = game.GetCurrentPlayer();
            if (player == null) { Debug.LogWarning("No current player."); ResetSelection(); return; }

            bool ok = RouteChecker.HasConnectedRoute(startNode, destNode, player.id, allowNeutralOnRoutes);
            Debug.Log($"Route {startNode.name} -> {destNode.name} for P{player.id} " +
                      (allowNeutralOnRoutes ? "(owned or neutral)" : "(owned only)") +
                      $": {(ok ? "FOUND ✅" : "NOT FOUND ❌")}");

            ResetSelection();
        }
    }

    public void OnPathClicked(PathSegments path)
    {
        if (path == null) return;
        if (game == null) { Debug.LogWarning("SelectionController: GameBase not assigned."); return; }

        var player = game.GetCurrentPlayer();
        if (player == null) { Debug.LogWarning("No current player."); return; }

        if (path.ownerId == player.id)
        {
            Debug.Log($"Path {path.name} already owned by Player {player.id}.");
            return;
        }

        path.SetOwner(player);  // tints the segment and sets ownerId
        Debug.Log($"Path {path.name} now owned by Player {player.id}.");
    }

    private void ResetSelection()
    {
        startNode = null;
        destNode = null;
    }
}
