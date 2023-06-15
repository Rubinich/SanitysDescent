using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shortcut : MonoBehaviour
{
    [Header("UI Content")]
    [SerializeField] private Text notificationTextUI;
    [SerializeField] private Image characterIconUI;

    [Header("Message Customization")]
    [SerializeField] private Sprite yourIcon;
    [SerializeField] [TextArea] private string notificationMessage;

    [Header("Notification Removal")]
    [SerializeField] private bool removeAfterExit = false;
    [SerializeField] private bool disableAfterTimer = false;
    [SerializeField] private float disableTimer = 1.0f;

    [Header("Notification Animation")]
    [SerializeField] private Animator notificationAnim;

    private bool isCallAudioPlaying;

    private void OnEnable()
    {
        PhoneController.OnCallAudioStartEvent += OnCallAudioStart;
        PhoneController.OnCallAudioStopEvent += OnCallAudioStop;
    }

    private void OnDisable()
    {
        PhoneController.OnCallAudioStartEvent -= OnCallAudioStart;
        PhoneController.OnCallAudioStopEvent -= OnCallAudioStop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && removeAfterExit)
        {
            RemoveNotification();
        }
    }

    private IEnumerator EnableNotification()
    {
        if (notificationAnim != null)
        {
            notificationAnim.Play("Shortcut1In");
            notificationTextUI.text = notificationMessage;
            characterIconUI.sprite = yourIcon;
        }

        if (disableAfterTimer)
        {
            yield return new WaitForSeconds(disableTimer);
            RemoveNotification();
        }
    }

    private void RemoveNotification()
    {
        if (notificationAnim != null)
        {
            notificationAnim.Play("Shortcut1Out");
        }

        gameObject.SetActive(false);
    }

    private void OnCallAudioStart()
    {
        isCallAudioPlaying = true;
        if (isCallAudioPlaying && notificationAnim != null)
        {
            notificationAnim.Play("Shortcut1In");
        }
    }

    private void OnCallAudioStop()
    {
        isCallAudioPlaying = false;
        if (!isCallAudioPlaying && notificationAnim != null)
        {
            notificationAnim.Play("Shortcut1Out");
        }
    }
}
