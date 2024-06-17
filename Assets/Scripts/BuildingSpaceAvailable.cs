using UnityEngine;

public class BuildingSpaceAvailable : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Preview"))
        {

            //Collider has to be set up to only detect buildings
            //Colors the preview red (only a previewd building should possibly be detected)
            foreach (MeshRenderer meshRenderer in c.GetComponentsInChildren<MeshRenderer>())
            {
                foreach (Material mat in meshRenderer.materials)
                {
                    //Checks if the current object is the preview because c reffers to both objects
                    if (mat.HasInt("_isPreview") && mat.GetInt("_isPreview") == 1)
                    {
                        mat.SetColor("_previewColor", new Color(1f, 0.1f, 0.1f));
                    }
                }
            }
        }
    }
}
