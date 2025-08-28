namespace GermanBocanegra.Test.Infodesign.Domain.Models.Presenters
{
    public class BaseResponse : BasePresenter
    {
        public string Message { get; set; } = string.Empty;
        public dynamic? Data { get; set; }
    }
}
