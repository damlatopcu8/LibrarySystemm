using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using LibrarySystemm.Models;

namespace LibrarySystemm.Services
{
    public class BookService
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private readonly IMongoCollection<Book> _book;
        public BookService(IMongoDBSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _book = _database.GetCollection<Book>(settings.CollectionName);
        }

        /* Butun Todo'lari Listeleme */
        public List<Book> GetList()
        {
            return _book.Find(book => true).ToList();
        }

        /* Bir Todo Getirme */
        public Book GetById(string id)
        {
            var docId = new ObjectId(id);
            return _book.Find<Book>(m => m.Id == id).FirstOrDefault();
        }

        /* Yeni Bir Todo Ekleme */
        public Book Create(Book model)
        {
            _book.InsertOne(model);
            return model;
        }

        /* Bir Todo Guncelleme */
        public void Update(string id, Book model)
        {
            var docId = new ObjectId(id);
            _book.ReplaceOne(m => m.Id == id, model);
        }

        /* Bir Todo Silme */
        public void Delete(string id)
        {
            var docId = new ObjectId(id);
            _book.DeleteOne(m => m.Id == id);
        }
    }
}
