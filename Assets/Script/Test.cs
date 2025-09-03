using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Test : MonoBehaviour
{
    public List<Transform> list;
    [SerializeField] private float spacingMultiplier = 1.5f; // Hệ số điều chỉnh khoảng cách

    [Button]
    private void HandleDistance()
    {
        if (list == null || list.Count == 0) return;

        Vector3 basePosition = list[0].position; // Lấy vị trí của object đầu tiên làm gốc
        float currentOffset = 0f;

        foreach (var item in list)
        {
            // Đặt vị trí mới cho object chính
            item.position = basePosition + new Vector3(currentOffset, 0, 0);
            
            // Lấy kích thước của object hiện tại (nếu có Renderer)
            float objectWidth = 0f;
            var renderer = item.GetComponent<Renderer>();
            if (renderer != null)
            {
                objectWidth = renderer.bounds.size.x;
            }

            // Cập nhật offset cho object tiếp theo
            currentOffset += objectWidth * spacingMultiplier;

            // Xử lý các object con (nếu cần)
            Transform[] children = item.GetComponentsInChildren<Transform>();
            foreach (var child in children)
            {
                if (child != item) // Chỉ xử lý các object con, không xử lý object cha
                {
                    // Giữ nguyên vị trí tương đối với object cha
                    child.localPosition = child.localPosition;
                }
            }
        }
        Debug.Log("Done");
    }
     [Button]
    private void HandleDistance2()
    {
    //    foreach (var item in list)
    //    {
    //     foreach (var item2 in item.GetComponentsInChildren<Transform>())
    //     {
    //       item2.position *= new Vector3(0.1f,0,0);
    //     }
    //    }
    }
}
