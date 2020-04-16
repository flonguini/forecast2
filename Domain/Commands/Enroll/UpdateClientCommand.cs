using Flunt.Notifications;
using Flunt.Validations;
using Forecast.Domain.Commands.Contracts;
using Forecast.Domain.Entities.Enroll;
using System;

namespace Forecast.Domain.Commands.Enroll
{
    public class UpdateClientCommand : Notifiable, ICommand
    {
        public Guid ClientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public UpdateClientCommand(Guid clientId, string fullname, string phone, string cellphone, string email, string cpf, string rg)
        {
            ClientId = clientId;
            FullName = fullname;
            Phone = phone;
            CellPhone = cellphone;
            Email = email;
            Cpf = cpf;
            Rg = rg;
        }

        public UpdateClientCommand(Client client)
        {
            ClientId = client.Id;
            FullName = client.FullName;
            Phone = client.Phone;
            CellPhone = client.CellPhone;
            Email = client.Email;
            Cpf = client.Cpf;
            Rg = client.Rg;
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
