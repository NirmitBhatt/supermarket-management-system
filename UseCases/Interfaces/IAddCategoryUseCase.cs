﻿using CoreBusinessEntities;

namespace UseCases.CategoriesUseCases
{
    public interface IAddCategoryUseCase
    {
        void Execute(Category category);
    }
}