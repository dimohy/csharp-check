using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace No11.ExpandoObject
{
    public class CustomDynamicMetaObject : IDynamicMetaObjectProvider
    {
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            Console.WriteLine($"Called GetMetaObject() : {parameter}");

            throw new NotImplementedException();
        }
    }
}
