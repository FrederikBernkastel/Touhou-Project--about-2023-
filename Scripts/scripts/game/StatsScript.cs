using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsScript : MonoBehaviour
{
    private TextMeshProUGUI Record;
    private TextMeshProUGUI Tablo;
    private Image Health;
    private Image Mombs;
    private Vector2 SizeDeltaPower;
    private Image Power;
    private TextMeshProUGUI PowerDop;
    private TextMeshProUGUI Greyz;
    private TextMeshProUGUI Ochki;

    public int iRecord {get; private set;}
    public int iTablo {get; private set;}
    public int iHealth {get; private set;}
    public int iBombs {get; private set;}
    public int iPower {get; private set;}
    public int iGreyz {get; private set;}
    public int iOchki {get; private set;}

    public static StatsScript Stats {get; private set;}
    
    private void Start()
    {
        Record ??= GameObject.FindGameObjectWithTag("рекорд").GetComponent<TextMeshProUGUI>();
        Tablo ??= GameObject.FindGameObjectWithTag("счёт").GetComponent<TextMeshProUGUI>();
        Health ??= GameObject.FindGameObjectWithTag("жизнь").GetComponent<Image>();
        Mombs ??= GameObject.FindGameObjectWithTag("бомбы").GetComponent<Image>();
        Power ??= GameObject.FindGameObjectWithTag("сила").GetComponent<Image>();
        PowerDop ??= Power.transform.Cast<Transform>().First().gameObject.GetComponent<TextMeshProUGUI>();
        Greyz ??= GameObject.FindGameObjectWithTag("грейз").GetComponent<TextMeshProUGUI>();
        Ochki ??= GameObject.FindGameObjectWithTag("очки").GetComponent<TextMeshProUGUI>();

        SizeDeltaPower = Power.rectTransform.sizeDelta;

        Stats = this;

        Default();
    }
    public void Default()
    {
        SetRecord(0);
        SetTablo(0);
        SetHealth(3);
        SetBomb(3);
        SetPower(0);
        SetGreyz(0);
        SetOchki(0);
    }
    public void UpRecord(int rec)
    {
        iRecord = iRecord + rec > 999999999 ? 999999999 : iRecord + rec;
        Record.text = iRecord.ToString("D9");
    }
    public void DownRecord(int rec)
    {
        iRecord = iRecord - rec < 0 ? 0 : iRecord - rec;
        Record.text = iRecord.ToString("D9");
    }
    public void SetRecord(int rec)
    {
        iRecord = rec > 999999999 ? 999999999 : rec < 0 ? 0 : rec;
        Record.text = iRecord.ToString("D9");
    }
    public void UpTablo(int tablo)
    {
        iTablo = iTablo + tablo > 999999999 ? 999999999 : iTablo + tablo;
        Tablo.text = iTablo.ToString("D9");
    }
    public void DownTablo(int tablo)
    {
        iTablo = iTablo - tablo < 0 ? 0 : iTablo - tablo;
        Tablo.text = iTablo.ToString("D9");
    }
    public void SetTablo(int tablo)
    {
        iTablo = tablo > 999999999 ? 999999999 : tablo < 0 ? 0 : tablo;
        Tablo.text = iTablo.ToString("D9");
    }
    public void UpHealth()
    {
        iHealth = iHealth + 1 > 6 ? 6 : iHealth + 1;
        Health.rectTransform.sizeDelta = 
            new(Health.sprite.rect.size.x * iHealth, Health.rectTransform.sizeDelta.y);
    }
    public void DownHealth()
    {
        iHealth = iHealth - 1 < 0 ? 0 : iHealth - 1;
        Health.rectTransform.sizeDelta = 
            new(Health.sprite.rect.size.x * iHealth, Health.rectTransform.sizeDelta.y);
    }
    public void SetHealth(int health)
    {
        iHealth = health > 6 ? 6 : health < 0 ? 0 : health;
        Health.rectTransform.sizeDelta = 
            new(Health.sprite.rect.size.x * iHealth, Health.rectTransform.sizeDelta.y);
    }
    public void UpBomb()
    {
        iBombs = iBombs + 1 > 6 ? 6 : iBombs + 1;
        Mombs.rectTransform.sizeDelta = 
            new(Mombs.sprite.rect.size.x * iBombs, Mombs.rectTransform.sizeDelta.y);
    }
    public void DownBomb()
    {
        iBombs = iBombs - 1 < 0 ? 0 : iBombs - 1;
        Mombs.rectTransform.sizeDelta = 
            new(Mombs.sprite.rect.size.x * iBombs, Mombs.rectTransform.sizeDelta.y);
    }
    public void SetBomb(int bomb)
    {
        iBombs = bomb > 6 ? 6 : bomb < 0 ? 0 : bomb;
        Mombs.rectTransform.sizeDelta = 
            new(Mombs.sprite.rect.size.x * iBombs, Mombs.rectTransform.sizeDelta.y);
    }
    public void UpPower(int power)
    {
        iPower = iPower + power > 150 ? 150 : iPower + power;
        PowerDop.text = iPower == 150 ? "MAX" : iPower.ToString();
        Power.rectTransform.sizeDelta = new(SizeDeltaPower.x * (int.Parse(PowerDop.text) * 1f / 150), 
            SizeDeltaPower.y);
    }
    public void DownPower(int power)
    {
        iPower = iPower - power < 0 ? 0 : iPower - power;
        PowerDop.text = iPower.ToString();
        Power.rectTransform.sizeDelta = new(SizeDeltaPower.x * (int.Parse(PowerDop.text) * 1f / 150), 
            SizeDeltaPower.y);
    }
    public void SetPower(int power)
    {
        iPower = power > 150 ? 150 : power < 0 ? 0 : power;
        PowerDop.text = iPower == 150 ? "MAX" : iPower.ToString();
        Power.rectTransform.sizeDelta = new(SizeDeltaPower.x * (int.Parse(PowerDop.text) * 1f / 150), 
            SizeDeltaPower.y);
    }
    public void UpGreyz(int greyz)
    {
        iGreyz = iGreyz + greyz > 999 ? 999 : iGreyz + greyz;
        Greyz.text = iGreyz.ToString();
    }
    public void DownGreyz(int greyz)
    {
        iGreyz = iGreyz - greyz < 0 ? 0 : iGreyz - greyz;
        Greyz.text = iGreyz.ToString();
    }
    public void SetGreyz(int greyz)
    {
        iGreyz = greyz > 999 ? 999 : greyz < 0 ? 0 : greyz;
        Greyz.text = iGreyz.ToString();
    }
    public void UpOchki(int ochki)
    {
        iOchki = iOchki + ochki > 999 ? 999 : iOchki + ochki;
        Ochki.text = iOchki.ToString();
    }
    public void DownOchki(int ochki)
    {
        iOchki = iOchki - ochki < 0 ? 0 : iOchki - ochki;
        Ochki.text = iOchki.ToString();
    }
    public void SetOchki(int ochki)
    {
        iOchki = ochki > 999 ? 999 : ochki < 0 ? 0 : ochki;
        Ochki.text = iOchki.ToString();
    }
}
