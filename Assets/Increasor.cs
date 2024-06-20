using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Increasor : MonoBehaviour
{
    [SerializeField] private Text _buttonText;

    private Coroutine _coroutine;
    private bool _isSwiched = true;
    private int _startNumber = 0;
    private float _timeInterval = 0.5f;

    private void Start()
    {
        _buttonText.text = "ÆÌÈ ÑÞÄÀ";
    }

    public void ControlOfCouner()
    {
        if (_isSwiched)
        {
            _isSwiched = false;
            _coroutine = StartCoroutine(CountUp(_timeInterval));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isSwiched = true;
            }
        }
    }

    private IEnumerator CountUp(float timeInterval)
    {
        var delay = new WaitForSeconds(timeInterval);

        while (_startNumber >= 0)
        {
            _startNumber++;
            ShowInDisplay(_startNumber);
            yield return delay;
        }
    }

    private void ShowInDisplay(int count)
    {
        _buttonText.text = count.ToString();
    }
}