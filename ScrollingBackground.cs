using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float speed;

    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new UnityEngine.Vector2(speed * Time.deltaTime, 0);  
    }
}
