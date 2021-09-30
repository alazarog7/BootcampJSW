using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Events
{
    public interface IUserEvent
    {
        public Task DeleteUserEvent(int IdUser);
    }
}
