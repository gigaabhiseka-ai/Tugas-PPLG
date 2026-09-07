using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void OnEnable()
    {
        GameManager.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        this.enabled = (state == GameState.Playing);
    }

    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // KANAN - KIRI (Sumbu X)
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;

        // ATAS - BAWAH (Sumbu Y)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moveY = -1f;

        // Gabungkan X dan Y (Z tetap 0)
        Vector3 move = new Vector3(moveX, moveY, 0f).normalized;
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}