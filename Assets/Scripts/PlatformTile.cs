using UnityEngine;
public class PlatformTile : MonoBehaviour
{
    public enum TileColor { BigPink, BigTurquoise }
    public TileColor tileColor;
    private Renderer rend;
    private bool isFalling = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
        AssignRandomColor();
    }

    public void AssignRandomColor()
    {
        tileColor = (Random.value > 0.5f) ? TileColor.BigPink : TileColor.BigTurquoise;
        if (tileColor == TileColor.BigPink)
        {
            rend.material.color = new Color(0.75f, 0.1f, 0.4f);
        }
        else
        {
            rend.material.color = new Color(0.15f, 0.55f, 0.3f);
        }
    }

     public void StartFalling(float delay = 1f)
    {
        if (isFalling) return;
        isFalling = true;
        Invoke(nameof(FallPlatform), delay);
    }

    private void FallPlatform()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = 1f; 
        rb.useGravity = true;

        Destroy(gameObject, 1f);
    }

}
