using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {
	
	int sizeX = 100;
	int sizeZ = 50;
	float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
		BuildMesh();
	}
	
	void BuildMesh(){

		int numTiles = sizeX * sizeZ;
		int numTris = numTiles * 2;
		int vSizeX = sizeX + 1;
		int vSizeZ = sizeZ + 1;
		int numVerts = vSizeX * vSizeZ; 
		// Create Mesh Data
		Vector3[] vertices = new Vector3[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		Vector2[] uv = new Vector2[numVerts];

		int [] triangles = new int[numTris * 3];

		int x,z;
		for(z = 0; z < sizeZ; z++){
			for(x = 0; x <sizeX; x++){
				vertices[z * vSizeX + x] = new Vector3(x * tileSize,0,z * tileSize);
			}
		}

		// Create a new Mesh
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;

		//Assign our mesh to the filter/renderer/collider
		MeshFilter mf = GetComponent<MeshFilter>();
		MeshRenderer mr = GetComponent<MeshRenderer>();
		MeshCollider mc = GetComponent<MeshCollider>();

		mf.mesh = mesh;
	}
}
