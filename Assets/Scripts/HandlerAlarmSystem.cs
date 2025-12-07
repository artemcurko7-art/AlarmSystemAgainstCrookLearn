using UnityEngine;

public class HandlerAlarmSystem : MonoBehaviour
{
    [SerializeField] private Home _home;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _home.Entered += _alarmSystem.OnEnableAlarmSystem;
        _home.Exited += _alarmSystem.OnDisableAlarmSystem;
    }

    private void OnDisable()
    {
        _home.Entered -= _alarmSystem.OnEnableAlarmSystem;
        _home.Exited -= _alarmSystem.OnDisableAlarmSystem;
    }
}
