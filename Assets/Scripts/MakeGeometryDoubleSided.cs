using UnityEngine;

// @kurtdekker - simple runtime geometry double-siding mechanism.
//
// Place or add this Component to things with at
// least a MeshFilter on them.
//
// Presently only for single-submesh geometry.
//
// Copies vertex position and uv, then recalculates
// all the normals. You could add a normal copy-over
// if you wish to preserve normals on the new geometry.

[RequireComponent( typeof( MeshFilter))]
public class MakeGeometryDoubleSided : MonoBehaviour
{
	void Awake()
	{
		MeshFilter mf = GetComponent<MeshFilter>();

		// If this blows up you failed to meet the documented
		// requirement above that a MeshFilter be present.
		Mesh mesh = mf.mesh;

		Vector3[] originalVerts = mesh.vertices;
		Vector2[] originalUVs = mesh.uv;

		int vertCount = originalVerts.Length;

		// original vertices will be copied over first,
		// then the duplicated ones will be added.
		Vector3[] verts = new Vector3[ vertCount * 2];
		Vector2[] uvs = new Vector2[ vertCount * 2];

		for (int i = 0; i < vertCount; i++)
		{
			Vector3 vertex = originalVerts[i];
			verts [i] = vertex;
			verts [i + vertCount] = vertex;

			Vector2 uv = originalUVs[i];
			uvs [i] = uv;
			uvs [i + vertCount] = uv;
		}

		int[] originalTriangles = mesh.triangles;
		int triCount = originalTriangles.Length;

		// original triangles will be copied over first,
		// then the flipped-over versions will be added.
		int[] tris = new int[ triCount * 2];

		for (int i = 0; i < triCount; i += 3)
		{
			int index0 = originalTriangles[i + 0];
			int index1 = originalTriangles[i + 1];
			int index2 = originalTriangles[i + 2];

			// re-add the original triangles, no change
			tris[i + 0] = index0;
			tris[i + 1] = index1;
			tris[i + 2] = index2;

			// now add triangles flipped the opposite way
			tris[i + triCount + 0] = index0 + vertCount;
			tris[i + triCount + 1] = index2 + vertCount;	// <-- reverse!
			tris[i + triCount + 2] = index1 + vertCount;	// <-- reverse!
		}

		mesh.vertices = verts;
		mesh.uv = uvs;

		mesh.triangles = tris;

		// remove this if you add normal-copying above!
		mesh.RecalculateNormals ();
	}
}
