using Cookbook.DAL.EF;

namespace Cookbook.WebApi.DAL.Repositories
{
    public class RepositoriesManager
    {
        private CookbookContext _context;

        private CookBookItemsRepository _cookBookItemsRepository;

        public CookBookItemsRepository CookBookItemsRepository
        {
            get 
            {
                if(_cookBookItemsRepository == null)
                {
                    _cookBookItemsRepository = new CookBookItemsRepository(_context);
                }
                return _cookBookItemsRepository;
            }
        }

        private RecipesRepository _recipesRepository;

        public RecipesRepository RecipesRepository
        {
            get 
            {
                if(_recipesRepository == null)
                {
                    _recipesRepository = new RecipesRepository(_context);
                }
                return _recipesRepository;
            }
        }

        private IngredientsRepository _ingredientsRepository;

        public IngredientsRepository IngredientsRepository
        {
            get 
            {
                if(_ingredientsRepository == null)
                {
                    _ingredientsRepository = new IngredientsRepository(_context);
                }
                return _ingredientsRepository;
            }
        }

        private DescriptionRepository _descriptionsRepository;

        public DescriptionRepository DescriptionsRepository
        {
            get 
            {
                if(_descriptionsRepository == null)
                {
                    _descriptionsRepository = new DescriptionRepository(_context);
                }
                return _descriptionsRepository;
            }
        }

        public RepositoriesManager(CookbookContext context)
        {
            _context = context;
        }
    }
}