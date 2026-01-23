using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GridController : MonoBehaviour
{
    public static GridController Instance;

    [Header("Settings")]
    public Grid unityGrid; 
    
    private Dictionary<Vector3Int, GameObject> gridItems = new Dictionary<Vector3Int, GameObject>();

    private void Awake()
    {

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (unityGrid == null) unityGrid = GetComponent<Grid>();
    }


    public bool TrySpawnItemAt(GameObject itemPrefab, Vector3 screenPosition)
    {

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPos.z = 0; 

        Vector3Int cellPos = unityGrid.WorldToCell(worldPos);


        if (gridItems.ContainsKey(cellPos))
        {
            Debug.Log("Platz belegt!");
            return false;
        }

        Vector3 spawnPos = unityGrid.GetCellCenterWorld(cellPos);
        
        GameObject newItem = Instantiate(itemPrefab, spawnPos, Quaternion.identity);

        gridItems.Add(cellPos, newItem);
        

        return true;
    }

    public void RemoveItemAt(Vector3Int cellPos)
    {
        if (gridItems.ContainsKey(cellPos))
        {
            Destroy(gridItems[cellPos]);
            gridItems.Remove(cellPos);
        }
    }
}