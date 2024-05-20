using Client.Data;
using Client.Data.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;

namespace Client.Pages;

public partial class Home : ComponentBase
{
    private CalculateRequest? _calculateRequest = new();
    private string _kioskId = null!;
    private List<Kiosk> _kiosks = null!;
    private List<string>? _path = new();
    private string _storeName = null!;
    private List<Store> _stores = null!;

    private void CurrentKiosk(string id)
    {
        _kioskId = id;
        _calculateRequest!.Kiosk = _kiosks.Find(x => x.Id == Convert.ToUInt16(id));
    }

    private void CurrentStore(string name)
    {
        _storeName = name;
        _calculateRequest!.Store = _stores.Find(x => x.Name == name);
        
    }

    private void HandleCalculate()
    {
        Calculation calculation = new();
        _path = calculation.GetStoreWay(_calculateRequest);
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        _kiosks = StaticData.Kiosks;
        _stores = StaticData.Stores;
    }
}