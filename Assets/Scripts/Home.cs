using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    public event Action Entered;
    public event Action Exited;

    public bool IsEnter {  get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Croock>(out Croock croock))
        {
            _alarmSystem.StopCoroutine();
            IsEnter = true;
            Entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Croock>(out Croock croock))
        {
            _alarmSystem.StopCoroutine();
            IsEnter = false;
            Exited?.Invoke();
        }
    }
}
