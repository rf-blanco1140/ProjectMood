using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNeeds : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySpriteRenderer;

    [SerializeField] private Sprite bodyIcon;
    [SerializeField] private Sprite mindIcon;
    [SerializeField] private Sprite appetiteIcon;
    [SerializeField] private Sprite hygieneIcon;
    [SerializeField] private Sprite socialIcon;

    [SerializeField] private Camera followCamera;

    [SerializeField] private FloatVariable body;
    [SerializeField] private FloatVariable mind;
    [SerializeField] private FloatVariable appetite;
    [SerializeField] private FloatVariable hygiene;
    [SerializeField] private FloatVariable social;

    private int lowThreshold;
    private int statToShow;
    private bool finishedCooldown;
    private enum Stats {None, Body, Mind, Appetite, Hygiene, Social};

    private void Start()
    {
        mySpriteRenderer.sprite = null;
        mySpriteRenderer.color = Color.red;
        StartCoroutine(WaitingForCooldown());
    }

    private void Update()
    {
        if(finishedCooldown)
        {
            //ShowLowStat();
            transform.rotation = Quaternion.Euler(followCamera.transform.eulerAngles.x, 0, 0);
        }
    }

    private void ShowLowStat()
    {
        float retNumb = 0f;
        Stats ret = Stats.None;

        if (body.Value > retNumb)
        {
            retNumb = body.Value;
            ret = Stats.Body;
        }
        if (mind.Value > retNumb)
        {
            retNumb = mind.Value;
            ret = Stats.Mind;
        }
        if (appetite.Value > retNumb)
        {
            retNumb = appetite.Value;
            ret = Stats.Appetite;
        }
        if (hygiene.Value > retNumb)
        {
            retNumb = hygiene.Value;
            ret = Stats.Hygiene;
        }
        if (social.Value > retNumb)
        {
            retNumb = social.Value;
            ret = Stats.Social;
        }
        switch (ret)
        {
            case Stats.Body:
                //Show body icon
                //mySpriteRenderer.enabled = true;
                mySpriteRenderer.sprite = bodyIcon;
                break;
            case Stats.Mind:
                mySpriteRenderer.sprite = mindIcon;
                break;
            case Stats.Appetite:
                mySpriteRenderer.sprite = appetiteIcon;
                break;
            case Stats.Hygiene:
                mySpriteRenderer.sprite = hygieneIcon;
                break;
            case Stats.Social:
                mySpriteRenderer.sprite = socialIcon;
                break;
        }
    }

    private void HideIcon()
    {
        mySpriteRenderer.sprite = null;
    }

    public IEnumerator CooldownTime()
    {
        HideIcon();
        Debug.LogError(":v");
        yield return new WaitForSeconds(5f);
        finishedCooldown = true;
        StartCoroutine(WaitingForCooldown());
    }

    private IEnumerator WaitingForCooldown()
    {
        ShowLowStat();
        Debug.LogError("XO");
        yield return new WaitForSeconds(10f);
        finishedCooldown = true;
        StartCoroutine(CooldownTime());
    }
}
