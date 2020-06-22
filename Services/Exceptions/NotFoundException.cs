using System;


namespace SalesWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException //herda dessa classe
    {
        public NotFoundException (string message) : base(message){
           
        }
    }
}
