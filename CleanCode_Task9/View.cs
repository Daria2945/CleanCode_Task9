namespace CleanCode_Task9
{
    public partial class View : Form, IView
    {
        private readonly IPresenter _presenter;

        public View(PresenterFactory presenterFactory)
        {
            InitializeComponent();

            _presenter = presenterFactory.Create(this);
        }

        public void ShowMessageBox(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            MessageBox.Show(message);
        }

        public void ShowTextResult(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            this.TextResult.Text = message;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            _presenter.ProccessEnteredText(this.EnteredText);
        }
    }
}