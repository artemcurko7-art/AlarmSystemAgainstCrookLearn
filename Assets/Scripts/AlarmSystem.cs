using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
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

    public void OnEnableAlarmSystem()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeInclusion(_maxVolume));
    }

    public void OnDisableAlarmSystem()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeInclusion(_minVolume));
    }

    private IEnumerator ChangeInclusion(float targetVolume)
    {
        while (enabled)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _repeatRate * Time.deltaTime);

            yield return null;
        }
    }
}
