using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text damageUp;
    public Text reloadSpeed;
    public Text gunMode;
    public Text dCost;
    public Text rCost;
    public Text gCost;
    public Text playerCoins;
    public GameObject dUpgrade;
    public GameObject rUpgrade;
    public GameObject gUpgrade;
    public Image gunModeImage;
    public Sprite[] gunModeSprites = new Sprite[3];
    AudioSource upgradeSound;
    int _dCost = 1;
    int _rCost = 2;
    int _gCost = 15;
    int _playerCoins;
    int damage = 1;
    float reload = 1;
    string[] _gunMode = { "FirstGunMode", "SecondGunMode", "ThirdGunMode" };
    int _gunModeNow = 0;
    void Start()
    {
        upgradeSound = FindObjectOfType<AudioController>().upgrade;
        _playerCoins = PlayerPrefs.GetInt("Coins");
        if (CheckKeys("Characteristics"))
        {
            damage = PlayerPrefs.GetInt("Damage");
            reload = PlayerPrefs.GetFloat("Reload");
            _gunModeNow = CheckIndex();
        }
        if (CheckKeys("prices"))
        {
            _dCost = PlayerPrefs.GetInt("DamageCost");
            _rCost = PlayerPrefs.GetInt("ReloadCost");
            _gCost = PlayerPrefs.GetInt("GunModeCost");
        }
        CheckForMaxValue();
    }

    void Update()
    {
        gunModeImage.sprite = gunModeSprites[_gunModeNow];
        if(PlayerPrefs.HasKey("Coins"))
            playerCoins.text = "You coins: " + PlayerPrefs.GetInt("Coins");
        if(dCost != null)
            dCost.text = "Cost: " + _dCost;
        if(rCost != null)
            rCost.text = "Cost: " + _rCost;
        if(gCost != null)
            gCost.text = "Cost: " + _gCost;
        if (CheckKeys("Characteristics"))
        {
            damageUp.text = "You Damage: " + damage;
            reloadSpeed.text = "You Reload Speed: " + reload;
            gunMode.text = $"You Gun Mode: {_gunModeNow + 1}";
        }
    }

    

    public void DamageUpgrade()
    {
        if(damage != 4 && _playerCoins >= _dCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins - _dCost);
            upgradeSound.Play();
            _playerCoins -= _dCost;
            damage += 1;
            _dCost *= 2;
            SetKeys();
        }
        else if(damage == 4 && _playerCoins >= _dCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins -_dCost);
            upgradeSound.Play();
            _playerCoins -= _dCost;
            damage += 1;
            dUpgrade.SetActive(false);
            Destroy(dCost);
            SetKeys();
        }
    }
    public void ReloadSpeedUpgrade()
    {
        if (!Mathf.Approximately(reload, 4f / 10) && _playerCoins >= _rCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins - _rCost);
            upgradeSound.Play();
            _playerCoins -= _rCost;
            reload -= 0.2f;
            _rCost *= 2;
            SetKeys();
        }
        else if(Mathf.Approximately(reload, 4f / 10) && _playerCoins >= _rCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins - _rCost);
            upgradeSound.Play();
            _playerCoins -= _rCost;
            reload -= 0.2f;
            rUpgrade.SetActive(false);
            Destroy(rCost);
            SetKeys();
        }
    }
    public void GunModeUpgrade()
    {
        if(_gunModeNow != 1 && _playerCoins >= _gCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins - _gCost);
            upgradeSound.Play();
            _playerCoins -= _gCost;
            _gunModeNow += 1;
            _gCost *= 3;
            SetKeys();
        }
        else if(_gunModeNow == 1 && _playerCoins >= _gCost)
        {
            PlayerPrefs.SetInt("Coins", _playerCoins - _gCost);
            upgradeSound.Play();
            _playerCoins -= _gCost;
            _gunModeNow += 1;
            gUpgrade.SetActive(false);
            Destroy(gCost);
            SetKeys();
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    int CheckIndex()
    {
        for (int i = 0; i < _gunMode.Length; i++)
            if (_gunMode[i] == PlayerPrefs.GetString("GunMode"))
                return i;
        return 0;
    }

    bool CheckKeys(string keys)
    {
        if (PlayerPrefs.HasKey("Damage") && PlayerPrefs.HasKey("Reload") && PlayerPrefs.HasKey("GunMode") && keys == "Characteristics")
            return true;
        else if (keys == "prices" && PlayerPrefs.HasKey("DamageCost") && PlayerPrefs.HasKey("ReloadCost") && PlayerPrefs.HasKey("GunModeCost"))
            return true;
        else
        {
            return false;
        }
    }

    void CheckForMaxValue()
    {
        if (damage == 5)
        {
            dUpgrade.SetActive(false);
            Destroy(dCost);
        }
        if (Mathf.Approximately(reload, 2f / 10))
        {
            rUpgrade.SetActive(false);
            Destroy(rCost);
        }
        if (_gunModeNow == 2)
        {
            gUpgrade.SetActive(false);
            Destroy(gCost);
        }
    }

    void SetKeys()
    {
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetFloat("Reload", reload);
        PlayerPrefs.SetString("GunMode", _gunMode[_gunModeNow]);
        PlayerPrefs.SetInt("DamageCost", _dCost);
        PlayerPrefs.SetInt("ReloadCost", _rCost);
        PlayerPrefs.SetInt("GunModeCost", _gCost);
    }
}
