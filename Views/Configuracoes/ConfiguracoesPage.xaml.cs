namespace Heicomp_2025_2.Views.Configuracoes;

public partial class ConfiguracoesPage : ContentPage
{
    public ConfiguracoesPage()
    {
        InitializeComponent();
    }

    // Evento: Botão Voltar
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Voltar", "Voltando para a tela anterior...", "OK");
        // await Navigation.PopAsync(); // Descomente quando tiver navegação configurada
    }

    // Evento: Salvar Alterações
    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        // Captura os valores dos switches
        bool pushNotif = SwitchPushNotif.IsToggled;
        bool emailNotif = SwitchEmailNotif.IsToggled;
        bool temaEscuro = SwitchTemaEscuro.IsToggled;

        string mensagem = $"Configurações salvas!\n\n" +
                         $"Push Notifications: {(pushNotif ? "Ativado" : "Desativado")}\n" +
                         $"Email Notifications: {(emailNotif ? "Ativado" : "Desativado")}\n" +
                         $"Tema Escuro: {(temaEscuro ? "Ativado" : "Desativado")}";

        await DisplayAlert("Sucesso", mensagem, "OK");
    }

    // Evento: Idioma
    private async void OnIdiomaClicked(object sender, EventArgs e)
    {
        string resultado = await DisplayActionSheet(
            "Selecione o Idioma",
            "Cancelar",
            null,
            "Português",
            "English",
            "Español"
        );

        if (resultado != null && resultado != "Cancelar")
        {
            await DisplayAlert("Idioma", $"Idioma selecionado: {resultado}", "OK");
        }
    }

    // Evento: Ajuda e Suporte
    private async void OnAjudaClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Ajuda e Suporte",
            "Entre em contato:\n\nEmail: suporte@heicomp.com\nTelefone: (35) 1234-5678",
            "OK"
        );
    }

    // Evento: Termos de Uso
    private async void OnTermosClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Termos de Uso",
            "Ao usar este aplicativo, você concorda com nossos termos e políticas de privacidade.",
            "Li e aceito"
        );
    }

    // Mudança : Tema Escuro
    private void AplicarTema(bool temaEscuro)
    {
        try
        {
            if (temaEscuro)
            {
                // Ativa o tema escuro
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                // Ativa o tema claro
                Application.Current.UserAppTheme = AppTheme.Light;
            }

            // Salva a preferência
            Preferences.Set("TemaEscuro", temaEscuro);

            // Força a atualização da interface
            Application.Current.MainPage = new MauiApp1.AppShell();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"❌ Erro: {ex.Message}");
        }
    }
}