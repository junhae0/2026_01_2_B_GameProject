using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{

    public string characterName;
    public int maxHealth = 100;
    public int currentHealth;

    //UI 요소
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    //새로 추가되는 마나 변수
    public int maxMana = 10;                        //최대 마나
    public int currentMana;                         //현재 마나
    public Slider manaBar;                          //마나 바 UI
    public TextMeshProUGUI manaText;                //마나 텍스트 UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        UpdataUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        UpdataUI();
    }

    public void GainMana(int amount)
    {
        currentMana += amount;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        UpdataUI();
    }



    private void UpdataUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }

        if (healthText != null)
        {
            healthText.text = $"{currentHealth} / {maxHealth}";
        }

        if (manaBar != null)
        {
            manaBar.value = (float)currentMana / maxMana;
        }

        if (manaText != null)
        {
            manaText.text = $"{currentMana} / {maxMana}";
        }
    }
}
