using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Vinder.Common;

namespace VinderApi.Binders
{
    public class FormFileModelBinderProvider : IModelBinderProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType) return null;

            var isIEnumerableFormFiles = context.Metadata.ModelType.GetInterfaces().Contains(typeof(IEnumerable<CommonFile>));

            var isFormFile = context.Metadata.ModelType.IsAssignableFrom(typeof(CommonFile));

            if (!isFormFile && !isIEnumerableFormFiles) return null;

            return new FormFileModelBinder();
        }
    }
}