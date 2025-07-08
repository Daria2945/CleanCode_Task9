using System.Data.SQLite;

namespace CleanCode_Task9
{
    public class Presenter
    {
        private const string MissingDataMessage = "Введите серию и номер паспорта";
        private const string InvalidFormatMessage = "Неверный формат серии или номера паспорта";

        private readonly View _view;
        private readonly Service _service;

        public Presenter(View view, Service service)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));

            _view.EnterButtonClicked += ProccessEnteredText;
            _service.CitizenFoundInDataBase += OnCitizenFound;
            _service.CitizenNotFoundInDataBase += OnCitizenNotFound;
        }

        public void ProccessEnteredText(TextBox enteredText)
        {
            ArgumentNullException.ThrowIfNull(enteredText);

            if (enteredText.Text.Trim() == string.Empty)
            {
                _view.ShowMessageBox(MissingDataMessage);

                return;
            }

            string space = " ";
            string rawData = enteredText.Text.Trim().Replace(space, string.Empty);
            int lengthPassportInfo = 10;

            if (rawData.Length != lengthPassportInfo)
            {
                _view.ShowTextResult(InvalidFormatMessage);

                return;
            }

            try
            {
                Passport passport = new Passport(rawData);
                _service.TryFoundCitizen(passport);
            }
            catch (SQLiteException ex)
            {
                int sqliteErrorCode = 1;

                if (ex.ErrorCode != sqliteErrorCode)
                    return;

                _view.ShowMessageBox("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
            }
        }

        private void OnCitizenFound(Citizen citizen)
        {
            ArgumentNullException.ThrowIfNull(citizen);

            string byPassportText = "По паспорту";
            string accessGrantedText = "доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
            string accessDeniedText = "доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";

            if (citizen.CanVote)
                _view.ShowTextResult($"{byPassportText} «{citizen.Passport.SeriesNumber}» {accessGrantedText}");
            else
                _view.ShowTextResult($"{byPassportText} «{citizen.Passport.SeriesNumber}» {accessDeniedText}");
        }

        private void OnCitizenNotFound(Passport passport)
        {
            ArgumentNullException.ThrowIfNull(passport);

            string passportText = "Паспорт";
            string textMissingFromList = "в списке участников дистанционного голосования НЕ НАЙДЕН";

            _view.ShowTextResult($"{passportText} «{passport.SeriesNumber}» {textMissingFromList}");
        }
    }
}