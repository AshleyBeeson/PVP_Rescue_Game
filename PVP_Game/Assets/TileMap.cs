using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {
	
	public int sizeX = 100;
	public int sizeZ = 50;
	public float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
		BuildMesh();
	}
	
	public void BuildMesh(){

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
			for(x = 0; x < sizeX; x++){
				vertices[z * vSizeX + x] = new Vector3(x * tileSize,Random.Range(-1.0f , 1.0f),z * tileSize);
				normals[z * vSizeX + x] = Vector3.up;
				uv[z * vSizeX + x] = new Vector2((float)x/vSizeX,(float)z/vSizeZ);
			}
		}

		for(z = 0; z < sizeZ; z++){
			for(x = 0; x < sizeX; x++){
				int squareIndex = z * sizeX + x;
				int triOffset = squareIndex * 6;
				triangles[triOffset + 0] = z * vSizeX + x + 0;
				triangles[triOffset + 1] = z * vSizeX + x + vSizeX + 0;
				triangles[triOffset + 2] = z * vSizeX + x + vSizeX + 1;

				triangles[triOffset + 3] = z * vSizeX + x + 0;
				triangles[triOffset + 4] = z * vSizeX + x + vSizeX + 1;
				triangles[triOffset + 5] = z * vSizeX + x + 1;
				
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
		mc.sharedMesh = mesh;
	}
}
