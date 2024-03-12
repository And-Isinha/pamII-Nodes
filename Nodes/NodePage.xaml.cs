namespace Nodes;

public partial class NodePage : ContentPage
{
	string _filepath = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	public NodePage()

	{
		InitializeComponent();
		if(File.Exists(_filepath))
		{
            TextEditor.Text = File.ReadAllText(_filepath);
        }
		
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		File.WriteAllText(_filepath, TextEditor.Text);
		await DisplayAlert("Sucesso", "Arquivo Criado com Sucesso", "Ok");
    }

	private async void DeleteButton_Clicked(object sender, EventArgs e)
	{
		if (File.Exists(_filepath))
		{
            File.Delete(_filepath);
            await DisplayAlert("Sucesso", "Arquivo Excluído", "Ok");
			TextEditor.Text = "";
		}
		else
		{
            await DisplayAlert("Sucesso", "Arquivo Não Encontrado", "Fora");
        }
		
    }
}