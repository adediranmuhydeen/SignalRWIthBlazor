namespace SignalRApp.Blazor.Infrastructure;

public interface IDiscountService
{
    /// <summary>
    /// Generates list of discount codes per reguest from the client
    /// </summary>
    /// <param name="code"></param>
    /// <param name="length"></param>
    /// <returns>List of string</returns>
    List<string> GenerateDiscountCodesAsync(ushort code, byte length);

    /// <summary>
    /// Confirms if the supplied code is correct or not
    /// </summary>
    /// <param name="code"></param>
    /// <returns> string </returns>
    string ConfirmDiscount(string code);
}
