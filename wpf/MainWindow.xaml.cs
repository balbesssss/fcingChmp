using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace App;

public partial class MainWindow : Window
{
    static readonly HttpClient _http = new();
private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
    public MainWindow() => InitializeComponent();

    private async void Load_Click(object sender, RoutedEventArgs e)
    {
        try
    {
        var json = await _http.GetStringAsync("http://localhost:5295/users");
        var users = JsonSerializer.Deserialize<List<User>>(json, _jsonOptions);
        Grid.ItemsSource = users;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Ошибка: {ex.Message}");
    }
    }
}

public class User
{
    public int Id { get; set; } 
    public string? Name { get; set; }
}