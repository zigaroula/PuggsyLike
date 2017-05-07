using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Level;
using Game.Player;

namespace Game.GameCamera
{
    public class CameraController : MonoBehaviour
    {
        #region Properties
        private LevelBounds m_Bounds;
        private Transform m_Target;
        private Camera m_Camera;
        private float m_ScreenRatio = 1.0f;
        private float m_FOVWidth = 10.0f;
        private float m_FOVHeight = 10.0f;
        private float m_SpeedX = 0.1f;
        private float m_SpeedY = 0.1f;
        #endregion

        #region Private Methods
        private void Awake()
        {
            m_Bounds = FindObjectOfType<LevelBounds>();
            m_Target = FindObjectOfType<PlayerInformation>().transform;
            m_Camera = GetComponent<Camera>();
        }
        private void Update()
        {
            ComputeBoundaries();
        }
        private void LateUpdate()
        {
            transform.position = ComputeTargetPosition();
        }
        private void ComputeBoundaries()
        {
            m_ScreenRatio = Screen.width / Screen.height;
            m_FOVHeight = m_Camera.orthographicSize;
            m_FOVWidth = m_Camera.orthographicSize * m_ScreenRatio;
        }
        private Vector3 ComputeTargetPosition()
        {
            Vector3 targetPosition = new Vector3(0.0f, 0.0f, transform.position.z);
            if (m_Target.position.x < m_Bounds.Left + m_FOVWidth / 2)
            {
                targetPosition.x = m_Bounds.Left + (m_Camera.orthographicSize * m_ScreenRatio) / 2;
            }
            else if (m_Target.position.x > m_Bounds.Right - m_FOVWidth / 2)
            {
                targetPosition.x = m_Bounds.Right - (m_Camera.orthographicSize * m_ScreenRatio) / 2;
            }
            else
            {
                targetPosition.x = m_Target.position.x;
            }
            if (m_Target.position.y > m_Bounds.Top - m_FOVHeight / 2)
            {
                targetPosition.y = m_Bounds.Top - m_Camera.orthographicSize / 2;
            }
            else if (m_Target.position.y < m_Bounds.Bottom + m_FOVHeight / 2)
            {
                targetPosition.y = m_Bounds.Bottom + m_Camera.orthographicSize / 2;
            }
            else
            {
                targetPosition.y = m_Target.position.y;
            }
            float currentVelocityX = 0.0f, currentVelocityY = 0.0f;
            targetPosition.x = Mathf.SmoothDamp(transform.position.x, targetPosition.x, ref currentVelocityX, m_SpeedX);
            targetPosition.y = Mathf.SmoothDamp(transform.position.y, targetPosition.y, ref currentVelocityY, m_SpeedY);
            return targetPosition;
        }
        #endregion

        #region Public Methods

        #endregion
    }
}