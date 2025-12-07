using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Croock>(out Croock croock))
            _alarmSystem.OnEnableAlarmSystem();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Croock>(out Croock croock))
            _alarmSystem.OnDisableAlarmSystem();
    }
}
