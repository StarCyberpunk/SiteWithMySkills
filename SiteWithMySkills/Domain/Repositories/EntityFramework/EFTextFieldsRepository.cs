﻿using SiteWithMySkills.Domain.Entities;
using SiteWithMySkills.Domain.Repositories.Abstract;

namespace SiteWithMySkills.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository:ITextFieldsRepository
    {
        private readonly AppDbContext context;
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x=>x.Id==id);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
