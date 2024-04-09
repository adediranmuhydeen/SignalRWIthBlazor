
namespace SignalRApp.Blazor.Infrastructure;

public class Discount : IDiscount
{
    List<string> _codes = new() {"AA000000" };   

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
    private  string GenerateCode(List<string> _service, int length)
    {
        int intLength = length - 2;

        int num = int.Parse(_service[_service.Count - 1].Substring(2, intLength));
        string myString = _service[_service.Count - 1];
        char firstChar = myString[0];
        char secondChar = myString[1];
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
}
