using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	TileMap tileMap;
    float tileSize;

	Vector3 currentTileCoord;

    void Start(){
		tileMap = GetComponent<TileMap>();
		tileSize = tileMap.tileSize;
	}

	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;

		if(GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity)){
			int x = Mathf.FloorToInt(hitInfo.point.x / tileSize);
			int z = Mathf.FloorToInt(hitInfo.point.z / tileSize);
			Debug.Log("Tile: " + x + ", " + z);
			currentTileCoord.x = x;
			currentTileCoord.z = z;
		}

	}
}
