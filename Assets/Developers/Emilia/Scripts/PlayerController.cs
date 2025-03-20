using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(horizontal, 0, vertical);
        moveVec = moveVec.normalized;

        controller.Move(moveVec * speed * Time.deltaTime);
    }

    // Instantiate bullet prefab
    //
}
