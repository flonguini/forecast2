using Flunt.Notifications;
using Flunt.Validations;
using Forecast.Domain.Commands.Contracts;
using Forecast.Domain.Entities.Enroll;

namespace Forecast.Domain.Commands.Enroll
{
    public class CreateClientCommand : Notifiable, ICommand
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public CreateClientCommand()
        {

        }

        public CreateClientCommand(Client client)
        {
            FullName = client.FullName;
            Phone = client.Phone;
            CellPhone = client.CellPhone;
            Email = client.Email;
            Cpf = client.Cpf;
            Rg = client.Rg;
        }

        public CreateClientCommand(string fullName, string phone, string cellPhone, string email, string cpf, string rg)
        {
            FullName = fullName;
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
            Cpf = cpf;
            Rg = rg;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(FullName, 3, nameof(FullName), "Nome deve conter mais de 3 caracteres"));

            AddNotifications(
                new Contract()
                .Requires()
                .IsEmail(Email, nameof(Email), "Email inválido"));

            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(CellPhone, 10, nameof(CellPhone), "Número de celular inválido"));
        }
    }
}
