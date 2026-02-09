using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.CategoriesUseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Execute(Category category)
        {
            categoryRepository.AddCategory(category);
        }
    }
}
