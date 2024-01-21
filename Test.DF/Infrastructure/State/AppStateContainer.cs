using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Test.DF.Models;

namespace Test.DF.Infrastructure.State;

public class AppStateContainer
{
    private ProtectedSessionStorage _sessionStorage;

    private const string PERSON_KEY = nameof(PERSON_KEY);

    public AppStateContainer(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public event Action OnStateChange;

    public async Task SetPersonAsync(Person person)
    {
        await _sessionStorage.SetAsync(PERSON_KEY, person);
    }

    public async Task<Person?> GetPersonAsync()
    {
        var storageResult = await _sessionStorage.GetAsync<Person>(PERSON_KEY);
        return storageResult.Value;
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
