namespace ColorAleatorio
{
    public partial class MainPage : ContentPage
    {
        private Random random = new Random();
        private string currentColorHex = "#FFFFFF";

        public MainPage()
        {
            InitializeComponent();
            myAds.AdsId = "ca-app-pub-7110513556928885/7130570156";
        }

        private void OnNewColorClicked(object sender, EventArgs e)
        {
            Color randomColor = GenerateRandomColor();
            ApplyRandomColor(randomColor);
        }

        private Color GenerateRandomColor()
        {
            return Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)
            );
        }

        private void ApplyRandomColor(Color color)
        {
            mainGrid.BackgroundColor = color;
            currentColorHex = ColorToHex(color);
            colorLabel.Text = $"Color: {currentColorHex}";
        }

        private string ColorToHex(Color color)
        {
            return $"#{(int)(color.Red * 255):X2}{(int)(color.Green * 255):X2}{(int)(color.Blue * 255):X2}";
        }

        private async void OnCopyColorClicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(currentColorHex);

        }
    }
}