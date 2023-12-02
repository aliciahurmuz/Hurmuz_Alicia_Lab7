
using Hurmuz_Alicia_Lab7.Models;


namespace Hurmuz_Alicia_Lab7;
public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource=await App.Database.GetShopListsAsync();
	}
	async void OnShoppingListAddedClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ListPage
		{
			BindingContext = new ShopList() 
		});
	}
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if(e.SelectedItem == null)
		{
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as ShopList
            });
        }
	}
}