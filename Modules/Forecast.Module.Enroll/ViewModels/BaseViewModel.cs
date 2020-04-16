using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecast.Module.Enroll.ViewModels
{
    public class BaseViewModel : BindableBase, INotifyDataErrorInfo
    {
        #region Private Members

        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        #endregion

        #region Events

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion

        #region Public Properties

        public bool HasErrors => _errorsByPropertyName.Any();

        public IEnumerable GetErrors(string propertyName) => _errorsByPropertyName.ContainsKey(propertyName) ? _errorsByPropertyName[propertyName] : null;

        #endregion

        #region Private Methods

        private void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        #endregion

        #region Validation Methods

        public void ValidateUserName(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "User name cannot be empty.");

            if (string.Equals(value, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(propertyName, "Admin is not valid user name.");

            if (value == null || value?.Length <= 5)
                AddError(propertyName, "User name must be at least 6 characters long.");
        }

        public void ValidatePhone(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "Telefone não pode estar em branco");
        }

        public void ValidateCellPhone(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "Celular não pode estar em branco");
        }

        public void ValidateEmail(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "Email não pode estar em branco");
        }

        public void ValidateCpf(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "CPF não pode estar em branco");
        }

        public void ValidateRg(string propertyName, string value)
        {
            ClearErrors(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                AddError(propertyName, "RG não pode estar em branco");
        }

        #endregion
    }
}
