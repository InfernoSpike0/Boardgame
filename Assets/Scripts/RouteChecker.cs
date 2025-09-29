using System.Collections.Generic;
using UnityEngine;

public static class RouteChecker
{
    // allowNeutral: if true, you can traverse unowned paths (ownerId == 0)
    public static bool HasConnectedRoute(NodeChecker start, NodeChecker destination, int playerId, bool allowNeutral = false)
    {
        if (start == null || destination == null) return false;
        if (start == destination) return true;

        var visited = new HashSet<NodeChecker>();
        var queue = new Queue<NodeChecker>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var paths = current.connectedPaths; // must be a List<PathSegments>

            if (paths == null) continue;

            foreach (var path in paths)
            {
                if (path == null) continue;

                // Ownership rule
                bool traversable = allowNeutral
                    ? (path.ownerId == 0 || path.ownerId == playerId)
                    : (path.ownerId == playerId);

                if (!traversable) continue;

                var next = GetOtherNode(path, current);
                if (next == null || !visited.Add(next)) continue;

                if (next == destination) return true;
                queue.Enqueue(next);
            }
        }

        return false;
    }

    private static NodeChecker GetOtherNode(PathSegments path, NodeChecker current)
    {
        return path.nodeA == current ? path.nodeB :
               path.nodeB == current ? path.nodeA : null;
    }
}
