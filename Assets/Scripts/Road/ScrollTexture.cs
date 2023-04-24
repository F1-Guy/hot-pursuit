using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    [SerializeField]
    private Renderer rend;

    void Update()
    {
        rend.material.mainTextureOffset += new Vector2(0, -scrollSpeed * Time.deltaTime);
    }
}
