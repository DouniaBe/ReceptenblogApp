using System.Threading.Tasks;
using ReceptenblogApp.Models;
using SQLite;

namespace ReceptenblogAPP.Services
{
    public class OfflineStorageService
    {
        private readonly SQLiteAsyncConnection _database;

        public OfflineStorageService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        // Voeg recept toe aan lokale opslag
        public async Task<int> SaveRecipeAsync(Recipe recipe)
        {
            return await _database.InsertAsync(recipe);
        }

        // Haal recepten op uit lokale opslag
        public async Task<List<Recipe>> GetRecipesAsync()
        {
            return await _database.Table<Recipe>().ToListAsync();
        }

        // Verwijder recept uit lokale opslag
        public async Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return await _database.DeleteAsync(recipe);
        }
    }
}
