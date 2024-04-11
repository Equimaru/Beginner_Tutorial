using UnityEngine;

public class Variables : MonoBehaviour
{
    private static bool isBobGood = true;
    public bool isBobEvil = !isBobGood;

    private float _moneyAmount;

    public string personName = "Bob";
    private char _firstCharacterInPersonName;

    [SerializeField] private string bankName = "Stellar";
    private char _lastCharacterInBankName;
    
    private void Start()
    {
        _firstCharacterInPersonName = personName[0];
        int lastCharIndex = bankName.Length - 1;
        _lastCharacterInBankName = bankName[lastCharIndex];
        Debug.Log(_firstCharacterInPersonName);
        Debug.Log(_lastCharacterInBankName);
        
        _moneyAmount = Random.Range(0, 100000);
        Debug.Log($"Bob stole {_moneyAmount} dollars from {bankName} bank");
    }
    
}
