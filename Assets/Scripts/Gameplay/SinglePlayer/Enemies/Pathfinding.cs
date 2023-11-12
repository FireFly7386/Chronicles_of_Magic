using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding;

public class Pathfinding : MonoBehaviour
{
    float gridSize = 0.5f;
    [SerializeField] float speed = 10f;

    Pathfinder<Vector2> pathfinder;
    [SerializeField] LayerMask obstacles;
    Vector2 targetNode;

    List<Vector2> path;
    List<Vector2> pathLeftToGo = new List<Vector2>();

    public GameObject player;

    void Start()
    {
        pathfinder = new Pathfinder<Vector2>(GetDistance, GetNeighbourNodes, 1000);
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 13)
        {
            GetMoveCommand(player.transform.position);


            if (pathLeftToGo.Count > 0)
            {
                Vector3 dir = (Vector3)pathLeftToGo[0] - transform.position;
                transform.position += dir.normalized * speed * Time.deltaTime;
                if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude < speed * speed * Time.deltaTime * Time.deltaTime)
                {
                    transform.position = pathLeftToGo[0];
                    pathLeftToGo.RemoveAt(0);
                }
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }
    void GetMoveCommand(Vector2 target)
    {
        Vector2 closestNode = GetClosestNode(transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path))
        {
            pathLeftToGo = new List<Vector2>(path);
            pathLeftToGo.Add(target);
        }

    }

    Vector2 GetClosestNode(Vector2 target)
    {
        return new Vector2(Mathf.Round(target.x / gridSize) * gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    Dictionary<Vector2, float> GetNeighbourNodes(Vector2 pos)
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j) * gridSize;
                if (!Physics2D.Linecast(pos, pos + dir, obstacles))
                {
                    neighbours.Add(GetClosestNode(pos + dir), dir.magnitude);
                }
            }

        }
        return neighbours;
    }

    float GetDistance(Vector2 A, Vector2 B)
    {
        return (A - B).sqrMagnitude;
    }
}
