namespace CleanCode_Task9
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        public event Action<TextBox> EnterButtonClicked;

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
            EnterButtonClicked?.Invoke(this.EnteredText);
        }
    }
}