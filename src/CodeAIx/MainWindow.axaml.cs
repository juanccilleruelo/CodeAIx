using System;
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
      WindowStartupLocation = WindowStartupLocation.Manual;
      Opened += OnOpened;
   }

   private void InitializeComponent() {
      AvaloniaXamlLoader.Load(this);
   }

   private void OnOpened(object? sender, EventArgs e) {
      if (Screens.Primary is { } primaryScreen) {
         var workingArea = primaryScreen.WorkingArea;
         Width = workingArea.Width / 3.0;
         Height = workingArea.Height;
         Position = new PixelPoint(workingArea.X, workingArea.Y);
      }
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

   private void OnAddDraftClick(object? sender, RoutedEventArgs e) {
      var text = TryGetEditorText(out var editor);
      if (string.IsNullOrWhiteSpace(text)) {
         return;
      }

      AppendConversationEntry("Borrador", text!, "#3A6EA5");
      editor!.Clear();
   }

   private void OnSendClick(object? sender, RoutedEventArgs e) {
      var text = TryGetEditorText(out var editor);
      if (string.IsNullOrWhiteSpace(text)) {
         return;
      }

      AppendConversationEntry("Enviado", text!, "#1E8C5C");
      if (this.FindControl<TextBlock>("GreetingText") is { } greeting) {
         greeting.Text = "Conversación en curso";
      }

      editor!.Clear();
   }

   private string? TryGetEditorText(out TextBox? editor) {
      editor = this.FindControl<TextBox>("InstructionEditor");
      return editor?.Text?.Trim();
   }

   private void AppendConversationEntry(string title, string message, string accentHex) {
      if (this.FindControl<StackPanel>("ConversationList") is not { } list) {
         return;
      }

      var accent = Brush.Parse(accentHex);
      var headerPanel = new StackPanel {
         Orientation = Orientation.Horizontal,
         Spacing = 8,
         Children = {
            new Border {
               Background = accent,
               CornerRadius = new CornerRadius(4),
               Padding = new Thickness(10, 4),
               Child = new TextBlock {
                  Text = title.ToUpperInvariant(),
                  FontSize = 12,
                  FontWeight = FontWeight.SemiBold,
                  Foreground = Brushes.White
               }
            },
            new TextBlock {
               Text = DateTime.Now.ToString("HH:mm"),
               VerticalAlignment = VerticalAlignment.Center,
               Foreground = Brushes.Gray
            }
         }
      };

      var card = new Border {
         Background = new SolidColorBrush(Color.Parse("#1C2027")),
         CornerRadius = new CornerRadius(10),
         Padding = new Thickness(16),
         Child = new StackPanel {
            Spacing = 8,
            Children = {
               headerPanel,
               new TextBlock {
                  Text = message,
                  TextWrapping = TextWrapping.Wrap,
                  Foreground = Brushes.White
               }
            }
         }
      };

      list.Children.Add(card);
   }
}
