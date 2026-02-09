using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorepluginInterfaces;
using UseCases.interfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category? Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }
    }
}
