using BlazorCosmosDBSPA.Server.DataAccess;
using BlazorCosmosDBSPA.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDBSPA.Server.Controllers
{
    public class BooksController : Controller
    {
        private static readonly string CollectionId = "Books";
        [HttpGet]
        [Route("api/Books/Get")]
        public async Task<IEnumerable<Book>> Get()
        {
            var result = await CosmosDBRepository<Book>.GetItemsAsync(CollectionId);
            return result;
        }

        [HttpPost]
        [Route("api/Books/Create")]
        public async Task CreateAsync([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                await CosmosDBRepository<Book>.CreateItemAsync(book, CollectionId);
            }
        }

        [HttpGet]
        [Route("api/Books/Details/{id}")]
        public async Task<Book> Details(string id)
        {
            var result = await CosmosDBRepository<Book>.GetSingleItemAsync(id, CollectionId);
            return result;
        }

        [HttpPut]
        [Route("api/Books/Edit")]
        public async Task EditAsync([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                await CosmosDBRepository<Book>.UpdateItemAsync(book.Id, book, CollectionId);
            }
        }

        [HttpDelete]
        [Route("api/Books/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await CosmosDBRepository<Book>.DeleteItemAsync(id, CollectionId);
        }
    }
}
