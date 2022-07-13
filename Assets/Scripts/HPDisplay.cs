using UnityEngine;
using TMPro;

public class HPDisplay : MonoBehaviour
{
    float hp;
    TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<TextMeshProUGUI>();
        UpdateHP();
    }

    private void UpdateHP()
    {
        hpText.text = hp.ToString();
    }

    public void AddToHP(int amount)
    {
        hp += amount;
        UpdateHP();
    }

    public void SetHP(float hp)
    {
        this.hp = hp;
        //UpdateHP();
    }

    public void LoseHP(int amount)
    {
        if (hp >= amount)
        {
            hp -= amount;
            UpdateHP();
        }
        else if (hp <= 0)
        {
            FindObjectOfType<LevelControler>().HandleLost();
        }
    }
}
