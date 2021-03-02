using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWebApplication
{
    public static class Converter
    {
        public static BookModel ToModel(this BookContract contract)
        {
            return new BookModel
            {
                ReferenceId = contract.ReferenceId,
                Name = contract.Name,
                Author = contract.Author,
                Genre = contract.Genre,
                Price = contract.Price
            };
        }

        public static BookContract ToContract(this BookModel model)
        {
            return new BookContract
            {
                ReferenceId = model.ReferenceId,
                Name = model.Name,
                Author = model.Author,
                Genre = model.Genre,
                Price = model.Price
            };
        }

        public static BookEntity ToEntity(this BookModel model)
        {
            return new BookEntity
            {
                Name = model.Name,
                Author = model.Author,
                Genre = model.Genre,
                Price = model.Price
            };
        }

        public static BookEntity ToModel(this BookEntity entity)
        {
            return new BookEntity
            {
                Id = entity.Id,
                ReferenceId = entity.ReferenceId,
                Name = entity.Name,
                Author = entity.Author,
                Genre = entity.Genre,
                Price = entity.Price
            };
        }
    }
}