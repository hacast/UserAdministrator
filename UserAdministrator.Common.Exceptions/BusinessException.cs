namespace UserAdministrator.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string msg) : base(msg)
        {

        }
    }
}