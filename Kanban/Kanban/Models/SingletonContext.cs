using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class SingletonContext
    {
        private static Contexto ctx;
        private SingletonContext() { }

        public static Contexto GetInstance()
        {
            if (ctx == null)
            {
                ctx = new Contexto();
            }
            return ctx;
        }
    }
}