using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PS.ActivityManagementStudio.Helpers
{
    public class ValidableObject : ObservableObject, INotifyDataErrorInfo
    {
        #region NotifyPropertyChanged related members
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T backingStorage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingStorage, value)) return false;

            backingStorage = value;

            RaisePropertyChanged(propertyName);

            return true;
        }

        public bool SetProperty<T>(Func<T> getter, Action<T> setter, T value, string propertyName)
        {
            T backingStorage = getter();
            if (!SetProperty(ref backingStorage, value, propertyName))
            {
                return false;
            }

            setter(backingStorage);
            return true;
        }

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        protected bool SetPropertyAndValidate<T>(Func<T> getter, Action<T> setter, T value, [CallerMemberName] string propertyName = null)
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext validationContext = CreateValidationContext<T>(propertyName);

            if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            {
                SetErrors(propertyName, validationResults);
                SetProperty(getter, setter, value, propertyName);
                return false;
            }

            ClearErrors(propertyName);
            return SetProperty(getter, setter, value, propertyName);
        }

        #region NotifyDataErrorInfo related members
        private readonly IDictionary<string, IList<string>> errors = new Dictionary<string, IList<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            IList<string> list;
            return errors.TryGetValue(propertyName, out list) ? list : Enumerable.Empty<string>();
        }

        public bool HasErrors
        {
            get
            {
                return errors.Count > 0;
            }
        }

        private ValidationContext CreateValidationContext<T>(string propertyName)
        {
            var validationContext = new ValidationContext(this)
            {
                MemberName = propertyName
            };
            return validationContext;
        }

        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            RaiseErrorsChanged(propertyName);
        }

        private void SetErrors(string propertyName, IEnumerable<ValidationResult> validationResults)
        {
            List<string> propertyErrors = validationResults
                .Select(x => x.ErrorMessage)
                .ToList();

            errors[propertyName] = propertyErrors;
            RaiseErrorsChanged(propertyName);
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            if (handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }

            RaisePropertyChanged("HasErrors");
        }

        public bool ValidateObject()
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, new ValidationContext(this), validationResults);
            if (isValid)
            {
                ClearErrors(string.Empty);
                //return true;
            }

            IEnumerable<IGrouping<string, ValidationResult>> allResults = validationResults
                .SelectMany(result => result.MemberNames.Select(member => new KeyValuePair<string, ValidationResult>(member, result)))
                .GroupBy(x => x.Key, pair => pair.Value);

            foreach (var memberResults in allResults)
            {
                SetErrors(memberResults.Key, memberResults);
            }

            return !HasErrors;
        }
        #endregion
    }
}
