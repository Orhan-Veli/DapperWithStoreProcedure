using FluentValidation;
using LibraryDapperExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Validations
{
    public class BookModelValidation:AbstractValidator<BookModel>
    {
        public BookModelValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x=> x.WriterId).NotEqual(Guid.Empty);
            RuleFor(x => x.Libraries.Count).NotEqual(0);
            RuleFor(x => x.Categories.Count).NotEqual(0);
        }
    }
}
