namespace Forecast.Domain.Entities.Enroll
{
    public class Client : EntityBase
    {
        #region Public Properties

        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }

        #endregion

        #region Constructors

        public Client()
        {

        }

        public Client(string fullname, string phone, string cellphone, string email, string cpf, string rg)
        {
            FullName = fullname;
            Phone = phone;
            CellPhone = cellphone;
            Email = email;
            Cpf = cpf;
            Rg = rg;
        }

        #endregion

        #region Public Methods

        public void ChangeFullName(string newValue) => FullName = newValue;
        public void ChangePhone(string newValue) => Phone = newValue;
        public void ChangeCellPhone(string newValue) => CellPhone = newValue;
        public void ChangeEmail(string newValue) => Email = newValue;
        public void ChangeCpf(string newValue) => Cpf = newValue;
        public void ChangeRg(string newValue) => Rg = newValue;

        #endregion
    }
}
