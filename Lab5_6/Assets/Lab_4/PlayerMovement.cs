//  лас дл€ керуванн€ рухом гравц€.
// ¬≥дпов≥даЇ за рух гравц€ вперед та назад в≥дпов≥дно до введенн€ клав≥ш.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Ўвидк≥сть руху гравц€
    public float speed = 5f;

    //  ожен кадр оновленн€
    void Update()
    {
        // ќтримуЇмо введенн€ дл€ руху по вертикал≥
        float moveInput = Input.GetAxis("Vertical");
        // ¬изначаЇмо напр€мок руху
        Vector3 moveDirection = transform.forward * moveInput;
        // «астосовуЇмо рух гравц€
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}