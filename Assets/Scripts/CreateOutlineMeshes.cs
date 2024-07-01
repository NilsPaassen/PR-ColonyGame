using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CreateOutlineMeshes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] buildings = GameObject.FindFirstObjectByType<BuildingsSelector>().buildings;

        foreach (GameObject building in buildings)
        {
            GenerateOutlineMesh(building);
        }
    }

    private void GenerateOutlineMesh(GameObject p)
    {
        Mesh mesh = p.GetComponent<MeshFilter>().sharedMesh;

        if (mesh.subMeshCount > 1 && mesh.GetSubMesh(mesh.subMeshCount - 1).indexStart != 0)
        {
            List<int> triIndices = new List<int>();
            for (int i = 0; i < mesh.subMeshCount; i++)
            {
                int[] indices = mesh.GetIndices(i);
                triIndices.AddRange(indices);
            }
            mesh.subMeshCount = mesh.subMeshCount + 1;
            SubMeshDescriptor combinedSubmesh = mesh.GetSubMesh(mesh.subMeshCount - 1);
            combinedSubmesh.firstVertex = combinedSubmesh.baseVertex = 0;
            combinedSubmesh.vertexCount = mesh.vertexCount;
            combinedSubmesh.indexStart = 0;
            combinedSubmesh.indexCount = triIndices.Count;
            mesh.SetSubMesh(mesh.subMeshCount - 1, combinedSubmesh);
        }
    }
}
