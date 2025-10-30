using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private bool isGrounded = true;
    private PlatformSpawner spawner; 
    private string selectedButton = "";
    public float fallLimit = -3f;
    public Transform player;
    private float idleTimer = 0f;
    public float maxIdleTime = 2f; 
    public float platformFallDelay = 0.2f;

    void Start()
    {
        spawner = FindObjectOfType<PlatformSpawner>();

    }

    void Update()
    {
        if (!GameManager.Instance.IsGameActive()) return;

         idleTimer += Time.deltaTime;
         if (idleTimer >= maxIdleTime)
          {
              GameManager.Instance.GameOver();
           }

        if (player.position.y < fallLimit)
        {
            GameManager.Instance.GameOver();
        }
        
    }

    public void OnPinkButton()
    {
        if (!GameManager.Instance.IsGameActive()) return;
        idleTimer = 0f; 
        selectedButton = "BigPink";
        TryJump();
    }

    public void OnGreenButton()
    {
        if (!GameManager.Instance.IsGameActive()) return;
        idleTimer = 0f;
        selectedButton = "BigTurquoise";
        TryJump();
    }



public void TryJump()
{
    if (!isGrounded) return;
    PlatformTile nextTile = spawner.GetNextTile();

        if (nextTile == null)
        {
            Debug.Log("No next platform found!");
            return;
        }

    if (nextTile.tileColor.ToString() == selectedButton)
    {
        isGrounded = false;
        selectedButton = "";
        transform.DOKill();

       Vector3 jumpTarget = transform.position + new Vector3(0, 0, 3.25f);
       float jumpHeight = 0.8f;
       float jumpDuration = 0.25f;

       transform.DOJump(jumpTarget, jumpHeight, 1, jumpDuration)
                .SetEase(Ease.OutSine)
                     .OnComplete(() =>
                     {
                         isGrounded = true;
                         GameManager.Instance.AddScore(1);
                         nextTile.StartFalling();

                     });
    }
    else
    {
        GameManager.Instance.GameOver();
    }
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}

