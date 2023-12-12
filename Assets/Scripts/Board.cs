using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Building[,] buildings = new Building[100,100];

    public void AddBuilding(Building building, Vector3 position) {
        buildings[(int)position.x, (int)position.z] = Instantiate(building, position, Quaternion.identity);
    }

    public void RemoveBuilding(Vector3 position) {        
        Destroy(buildings[(int)position.x, (int)position.z].gameObject);
        buildings[(int)position.x, (int)position.z] = null;
    }

    public int GetBuildingCost(Vector3 position) {
        return buildings[(int)position.x, (int)position.z].cost;
    }

    public int GetBuildingId(Vector3 position) {
        return buildings[(int)position.x, (int)position.z].id;
    }

    public bool CheckForBuildingAtPosition(Vector3 position) {
        return buildings[(int)position.x, (int)position.z] != null;
    }

    public Vector3 CalculateGridPosition(Vector3 position) {
        return new Vector3(Mathf.Round(position.x), 0.5f, Mathf.Round(position.z));
    }
}
