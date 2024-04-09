
namespace SignalRApp.Blazor.Infrastructure;
#nullable disable
public class DiscountService : IDiscountService
{
    #region Fields
    List<string> _codes = new List<string>();
    #endregion

    #region Public Methods
    public string ConfirmDiscount(string code)
    {
        if (!_codes.Contains(code))
        {
            return "Invalid code";
        }
        return "Code is valid";
    }    

    public List<string> GenerateDiscountCodesAsync(ushort numberOfCode, byte length)
    {
        if(length < 7 || length> 8)
        {
            throw new Exception($"{nameof(length)} is not valid, please enter either 7 or 8");
        }
        while(numberOfCode > 0)
        {
            _codes.Add( GenerateCode( _codes, length));
            numberOfCode--;
        }
        return _codes;
    }
    #endregion


    #region Private Methods
    private string GenerateCode(List<string> _service, int length)
    {
        int intLength = length - 2;

        int num ;
        string myString;
        char firstChar = char.MinValue;
        char secondChar = char.MinValue;
        if(_service.Count< 1)
        {
            num = 0;
            firstChar = 'A';
            secondChar = 'A';
        }
        else
        {
            num = int.Parse(_service[_service.Count - 1].Substring(2, intLength));
            myString = _service[_service.Count - 1];
            firstChar = myString[0];
            secondChar = myString[1];
        }
        if (num + 1 > 99999)
        {
            secondChar = (char)(secondChar + 1);
            num = 0;
            if (secondChar > 'Z')
            {
                firstChar = (char)(firstChar + 1);
                secondChar = (char)(secondChar - 26);

                if (firstChar > 'Z')
                {
                    firstChar = (char)(firstChar - 26);
                }
            }
        }
        var temp = (num + 1).ToString($"D{intLength}");
        return (firstChar.ToString() + secondChar.ToString() + temp);
    }
    #endregion
}
