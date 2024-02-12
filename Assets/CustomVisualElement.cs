using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomVisualElement : VisualElement {
    public new class UxmlFactory : UxmlFactory<CustomVisualElement, VisualElement.UxmlTraits> {}

    public CustomVisualElement() {
        generateVisualContent += OnGenerateVisualContent;
    }

    private void OnGenerateVisualContent(MeshGenerationContext mgc) {
        Vertex[] k_Vertices = new Vertex[6];
            ushort[] k_Indices = { 0, 1, 5, 5, 1, 4, 4, 1, 2, 2, 3, 4 };

            Rect r = contentRect;
            if (r.width < 0.01f || r.height < 0.01f)
                return; // Skip rendering when too small.

            k_Vertices[0].tint = new Color(0, 0, 0);
            k_Vertices[1].tint = new Color(255, 255, 255);
            k_Vertices[2].tint = new Color(0, 0, 0);
            k_Vertices[3].tint = new Color(0, 0, 0);
            k_Vertices[4].tint = new Color(255, 255, 255);
            k_Vertices[5].tint = new Color(0, 0, 0);

            float left = 0;
            float right = r.width;
            float top = 0;
            float bottom = r.height;

            k_Vertices[0].position = new Vector3(left, top, Vertex.nearZ);
            k_Vertices[1].position = new Vector3(left + r.width / 2f, top, Vertex.nearZ);
            k_Vertices[2].position = new Vector3(right, top, Vertex.nearZ);
            k_Vertices[3].position = new Vector3(right, bottom, Vertex.nearZ);
            k_Vertices[4].position = new Vector3(left + r.width / 2f, bottom, Vertex.nearZ);
            k_Vertices[5].position = new Vector3(left, bottom, Vertex.nearZ);

            MeshWriteData mwd = mgc.Allocate(k_Vertices.Length, k_Indices.Length);
            mwd.SetAllVertices(k_Vertices);
            mwd.SetAllIndices(k_Indices);
    }
}
