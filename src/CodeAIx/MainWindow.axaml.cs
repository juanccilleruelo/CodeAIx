using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Layout;
using Avalonia.Media;

namespace CodeAIx;

public partial class MainWindow : Window {
   public MainWindow() {
      InitializeComponent();
   }

   private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
   }

   private async void OnHolaMundoClick(object? sender, RoutedEventArgs e) {
      if (this.FindControl<TextBlock>("GreetingText") is { } greeting) {
         greeting.Text = "Hola Mundo";
      }

      var acceptButton = new Button {
         Content = "Aceptar",
         HorizontalAlignment = HorizontalAlignment.Center,
         MinWidth = 90
      };

      var dialog = new Window {
         Title = "Hola Mundo",
         Width = 320,
         Height = 180,
         CanResize = false,
         WindowStartupLocation = WindowStartupLocation.CenterOwner,
         Content = new StackPanel {
            Margin = new Thickness(12),
            Spacing = 12,
            Children = {
               new TextBlock {
                  Text = "¡Hola Mundo desde CodeAIx!",
                  HorizontalAlignment = HorizontalAlignment.Center,
                  TextWrapping = TextWrapping.Wrap
               },
               acceptButton
            }
         }
      };

      acceptButton.Click += (_, _) => dialog.Close();
      await dialog.ShowDialog(this);
   }

   private void OnSalirClick(object? sender, RoutedEventArgs e) {
      Close();
   }
}
