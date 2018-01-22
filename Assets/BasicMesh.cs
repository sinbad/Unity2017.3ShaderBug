using UnityEngine;

public class BasicMesh : MonoBehaviour {

	MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    void Start() {
		meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

        meshFilter.mesh = BuildMesh();
    }

	Mesh BuildMesh() {
		float halfSize = 10f;
		Mesh m = new Mesh();
		var vertices = new Vector3[4];
		var texcoords = new Vector2[4];
		int v = 0;
		vertices[v] = new Vector3(-halfSize, -halfSize, 0);
		texcoords[v++] = new Vector2(0, 0);
		vertices[v] = new Vector3(halfSize, -halfSize, 0);
		texcoords[v++] = new Vector2(1, 0);
		vertices[v] = new Vector3(halfSize, halfSize, 0);
		texcoords[v++] = new Vector2(1, 1);
		vertices[v] = new Vector3(-halfSize, halfSize, 0);
		texcoords[v++] = new Vector2(0, 1);
		m.vertices = vertices;
		m.uv = texcoords;

		var triangles = new int[6];
		int t = 0;
		triangles[t++] = 0; triangles[t++] = 2; triangles[t++] = 1;
		triangles[t++] = 0; triangles[t++] = 3; triangles[t++] = 2;
		m.triangles = triangles;

		return m;
	}
    
}