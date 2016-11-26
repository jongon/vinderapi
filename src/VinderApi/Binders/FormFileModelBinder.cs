using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vinder.Common;

namespace VinderApi.Binders
{
    public class FormFileModelBinder : IModelBinder
    {
        private readonly Func<IFormFile, CommonFile> _expression;

        /// <summary>
        /// 
        /// </summary>
        public FormFileModelBinder()
        {
            _expression = x => new CommonFile
            {
                File = x.OpenReadStream().ToBytes(),
                Name = x.FileName
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            dynamic model;
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

            var formFiles = bindingContext.ActionContext.HttpContext.Request.Form.Files;

            if (!formFiles.Any()) return Task.CompletedTask;

            if (formFiles.Count > 1)
            {
                model = formFiles.Select(_expression);
            }
            else
            {
                model = formFiles.Select(_expression).First();
            }

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
