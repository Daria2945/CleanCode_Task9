using System.Data.SQLite;

namespace CleanCode_Task9
{
    public class Presenter : IPresenter
    {
        private const string PassportText = "Паспорт";
        private const string ByPassportText = "По паспорту";
        private const string TextMissingFromList = "в списке участников дистанционного голосования НЕ НАЙДЕН";
        private const string AccessGrantedText = "доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
        private const string AccessDeniedText = "доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";

        private readonly IView _view;
        private readonly IService _service;

        public Presenter(IView view, IService service)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void ProccessEnteredText(TextBox enteredText)
        {
            try
            {
                Passport passport = new Passport(enteredText.Text);
                Citizen citizen = _service.TryFoundCitizen(passport);

                if (citizen == null)
                {
                    _view.ShowTextResult($"{PassportText} «{passport.SeriesNumber}» {TextMissingFromList}");
                }
                else
                {
                    if (citizen.CanVote)
                        _view.ShowTextResult($"{ByPassportText} «{citizen.Passport.SeriesNumber}» {AccessGrantedText}");
                    else
                        _view.ShowTextResult($"{ByPassportText} «{citizen.Passport.SeriesNumber}» {AccessDeniedText}");
                }
            }
            catch (SQLiteException ex)
            {
                int sqliteErrorCode = 1;

                if (ex.ErrorCode != sqliteErrorCode)
                    return;

                _view.ShowMessageBox("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
            }
        }
    }
}