using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private Button firstSkillButton;
    [SerializeField] private GameObject radius;
    private Score score;

    private void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    public void UseFirstSkill()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(var enemy in enemys)
        {
            var distanceToPlayer = CalculateDistance(enemy);
            if (distanceToPlayer <= 10f)
            {
                Destroy(enemy);
                score.UpdateScore(enemy);
                ReloadSkill(15f);
            }
        }
    }

    private float CalculateDistance(GameObject enemy)
    {
        return Vector3.Distance(transform.position, enemy.transform.position);
    }

    private void ReloadSkill(float time)
    {
        StartCoroutine(WaitSkill(time));
    }

    IEnumerator WaitSkill(float time)
    {
        radius.SetActive(true);
        firstSkillButton.interactable = false;
        yield return new WaitForSeconds(1f);
        radius.SetActive(false);
        yield return new WaitForSeconds(time - 1f);
        firstSkillButton.interactable = true;
    }
}

