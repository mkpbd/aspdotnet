using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApiPractices.Reflection
{
    public class ReflectionApply
    {
        public void ReplactionImplentions()
        {


            Type t = Type.GetType("ReflectionApiPractices.Reflection.Customer");

            Console.WriteLine("Class Name with NameSpace = "+t.FullName + ",  Class or Object name = "+ t.Name);
            Console.WriteLine("NameSpace = "+t.Namespace);
            Console.WriteLine("Relactions Typs = "+t.ReflectedType);
            Console.WriteLine("Base type = "+t.BaseType);
            Console.WriteLine("Attributes = "+t.Attributes);
            Console.WriteLine("Methods = "+t.MemberType);
            Console.WriteLine("Properties = "+t.GetProperties());
            Console.WriteLine("Fields = "+t.GetFields());
            Console.WriteLine("Custom Attributes = "+t.CustomAttributes);
            Console.WriteLine("Get Member = "+t.GetMember("Customer"));

            Console.WriteLine("======================= Get Properties ==================");

            foreach(PropertyInfo p in t.GetProperties())
            {

                Console.WriteLine("property Name = "+ p.Name + " , Property Type = "+ p.PropertyType);
            }
            Console.WriteLine("=========================== Get members ========================");
            foreach (MemberInfo m in t.GetMembers())
            {
                Console.WriteLine("Member Name = "+m.Name + ",  Reflection Type ="+  m.ReflectedType);
            }

            Console.WriteLine("=================== get Methods =====================");

            MethodInfo[] methodInfos = t.GetMethods();
                

            foreach(MethodInfo m in methodInfos) {
                Console.WriteLine("Method Name = "+ m.Name + ", Method Return Type "+m.ReturnType);
                    
                    
                    }
        }
    }
}
