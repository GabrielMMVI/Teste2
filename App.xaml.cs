namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Carrega a preferência de tema salva
            if (Preferences.ContainsKey("TemaEscuro"))
            {
                bool temaEscuro = Preferences.Get("TemaEscuro", false);

                if (temaEscuro)
                {
                    UserAppTheme = AppTheme.Dark;
                }
                else
                {
                    UserAppTheme = AppTheme.Light;
                }
            }

            MainPage = new AppShell();
        }
    }
}