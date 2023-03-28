using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Features;

namespace DN.BookStore
{
    public class BookStoreFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("BookStore");

            myGroup.AddFeature("BookStore.Book", "true");
            myGroup.AddFeature("BookStore.Author", "true");
        }
    }
}
