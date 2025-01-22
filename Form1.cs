using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitcoin_to_dollars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://api.coindesk.com/v1/bpi/currentprice/USD.json";

            try
            {
                float btcRate = await GetBitcoinRate(apiUrl);

                label4.Text = btcRate.ToString() + "$";

                if (float.TryParse(textBox1.Text, out float dollars))
                {
                    float bitcoins = dollars / btcRate;
                    textBox2.Text = bitcoins.ToString("F8");
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть правильне число у поле доларів.", "Помилка вводу");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка");
            }
        }

        private async Task<float> GetBitcoinRate(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Помилка запиту: {response.StatusCode}");
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                try
                {
                    using (JsonDocument document = JsonDocument.Parse(responseBody))
                    {
                        JsonElement root = document.RootElement;

                        if (root.TryGetProperty("bpi", out JsonElement bpi) &&
                            bpi.TryGetProperty("USD", out JsonElement usd) &&
                            usd.TryGetProperty("rate_float", out JsonElement rateFloat))
                        {
                            return rateFloat.GetSingle();
                        }
                        else
                        {
                            throw new Exception("Не знайдено властивості 'rate_float' у JSON-відповіді.");
                        }
                    }
                }
                catch (JsonException ex)
                {
                    throw new Exception($"Помилка обробки JSON: {ex.Message}");
                }
            }
        }
    }
}
