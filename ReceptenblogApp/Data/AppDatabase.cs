using ReceptenblogApp.Models;
using SQLite;

namespace ReceptenblogAPP.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        // Functie om recepten op te slaan
        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            return _database.InsertAsync(recipe);
        }

        // Functie om recepten op te halen
        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        // Functie om een recept te verwijderen
        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }
    }
}
