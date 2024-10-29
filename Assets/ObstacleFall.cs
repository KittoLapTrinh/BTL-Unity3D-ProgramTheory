using UnityEngine;
using System.Collections;
public class ObstacleFall : MonoBehaviour
{
    private bool hasFallen = false;
    private Quaternion originalRotation;
    public float fallSpeed = 50f; // Tốc độ ngã

    private void Start()
    {
        // Lưu lại rotation ban đầu của cây
        originalRotation = transform.rotation;
    }

    // Kiểm tra nếu xe đến gần
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log(other.gameObject.CompareTag("xe1"));

        if (other.gameObject.CompareTag("Untagged") && !hasFallen)
        {
            // Bắt đầu quá trình làm cây ngã
            Debug.Log("Untagged");
            hasFallen = true;
        }
       
       
    }

    private void Update()
    {
        if (hasFallen)
        {
            // Quay đối tượng dần theo trục Y cho đến khi đạt góc mong muốn
            float step = fallSpeed * Time.deltaTime;
            Quaternion targetRotation = Quaternion.Euler(90f, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);

            // Quay từ từ về góc ngã
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            // Ngăn ngã thêm sau khi đạt vị trí mục tiêu
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                hasFallen = false; // Ngừng ngã khi đạt tới mục tiêu
                
            }
        }
    }
}