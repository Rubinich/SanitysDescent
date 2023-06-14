using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationTrigger : MonoBehaviour
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
    private BoxCollider objectCollider;

    private void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();
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

    IEnumerator EnableNotification()
    {
        objectCollider.enabled = false;
        notificationAnim.Play("Objective1In");
        notificationTextUI.text = notificationMessage;
        characterIconUI.sprite = yourIcon;

        if (disableAfterTimer)
        {
            yield return new WaitForSeconds(disableTimer);
            RemoveNotification();
        }
    }

    void RemoveNotification()
    {
        notificationAnim.Play("Objective1Out");
        gameObject.SetActive(false);
    }
}
