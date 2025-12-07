using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Home _home;
    [SerializeField] private float _repeatRate;

    private readonly float _minVolume = 0;
    private readonly float _maxVolume = 1;

    private AudioSource _audioSource;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void OnEnableAlarmSystem() =>
        _coroutine = StartCoroutine(Include());

    public void OnDisableAlarmSystem() =>
        _coroutine = StartCoroutine(TurnItOff());

    private IEnumerator Include()
    {
        while (enabled)
        {
            if (_home.IsEnter)
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _repeatRate * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator TurnItOff()
    {
        while (enabled)
        { 
            if (_home.IsEnter == false)
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _repeatRate * Time.deltaTime);

            yield return null;
        }
    }
}
