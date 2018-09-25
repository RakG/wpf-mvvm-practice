using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZzaDesktop
{
    public abstract class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public bool HasErrors => this.errors.Count > 0;

        public IEnumerable GetErrors(string propertyName)
        {
            if (this.errors.TryGetValue(propertyName, out List<string> errors))
            {
                return errors;
            }
            else
            {
                return null;
            }
        }

        protected override void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(ref member, value, propertyName);
            this.ValidateProperty(propertyName, value);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            Validator.TryValidateProperty(value, context, validationResults);

            if (validationResults.Any())
            {
                this.errors[propertyName] = validationResults.Select(vr => vr.ErrorMessage).ToList();
            }
            else
            {
                this.errors.Remove(propertyName);
            }

            this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
