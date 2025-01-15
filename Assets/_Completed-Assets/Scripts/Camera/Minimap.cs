using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    [HideInInspector] public Transform m_Target;    // �~�j�}�b�v�ۑ�:�J�����̃^�[�Q�b�g�ƂȂ�v���C���[

    private Camera m_Camera;                        // Used for referencing the camera.
    public Vector3 offset = new Vector3(0, 30, 0);  // �~�j�}�b�v�ۑ�:�J�����I�t�Z�b�g


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


    private void FixedUpdate()
    {
        // Move the camera towards a desired position.
        Move();
    }


    private void Move()
    {
        transform.position = new Vector3(m_Target.position.x, transform.position.y, m_Target.position.z);
        transform.rotation = Quaternion.Euler(0, m_Target.eulerAngles.y, 0);
        // Start is called before the first frame update
    }
}
