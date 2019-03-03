using System;
using Xamarin.Forms;
using XamarinConsultarCP.Service;

namespace XamarinConsultarCP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Btn.Clicked += DevolverCp;
        }

        private void DevolverCp(object sender, EventArgs args)
        {
            var cp = CP.Text.Trim();

            if (cp.Length == 4) cp += "000";

            if (!IsValidCp(cp)) return;
            try
            {
                var morada = CodigoPostalServico.GetCpFromService(cp);
                if (morada != null)
                {
                    Result.Text = $"Morada: {morada.Localidade}, {morada.Arteria} {morada.LocalZona}, {morada.Troco}";
                }
                else
                {
                    DisplayAlert("ERRO", "A morada não foi encontrada para o CP inserido", "OK");
                }
            }
            catch (Exception e)
            {
                DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
            }
        }

        private bool IsValidCp(string cp)
        {
            var valid = true;

            if (cp.Length != 7)
            {
                DisplayAlert("ERRO", "CP inválido! O CP deve conter ou 4 ou 7 caracteres", "OK");
                valid = false;
            }

            if (int.TryParse(cp, out _)) return valid;
            DisplayAlert("ERRO", "CP inválido! O CP deve ser composto apenas por números", "OK");
            valid = false;
            return valid;
        }
    }
}
